using FaceSentiment.GenericStructure.FormType.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;

namespace FaceSentiment.GenericStructure.FormType
{
    public partial class AcquisitionForm : Form
    {
        //Default Variable
        private string streamConnection = "http://172.16.1.141:80/video1.mjpg";
        private string streamUser = "admin";
        private string streamPassword = "cegeka";
        //private string streamConnection= @"http://admin:@172.16.2.247:99/snapshot.cgi?user=admin&pwd=&count=0";
        private const string FREEfaceApiKey = "987dfd8276384149b82fdc21da1219eb";//Free Face Api;
        private const string PayfaceApiKey = "57807fd35bf54f0fa59be422bd39a3a5";//Pay Face Api
        private string faceApiKey;//Pay Face Api
        private string faceApiUri = "https://westeurope.api.cognitive.microsoft.com/face/v1.0";
        private string databaseConnection = "Server=tcp:cegekafacesentiment.database.windows.net,1433;Initial Catalog=FaceSentimentDatabase;Persist Security Info=False;User ID=ServerAdmin;Password=Familyfour4;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        private bool streamOnComputer = false;
        private bool useFreeFaceApi = true;
        private int selectedTimeIndex = 2;
        private int selectedTrackIndex = 3;
        private Bitmap waitingBitmap;

        //Managers
        IStreamManager streamManager;
        FaceSentimentManager faceSentimentManager;
        FaceDetectionManager faceDetectionManager;
        DBCameraManager dBCameraManager;


        //Event 
        private DispatcherTimer save_timer;
        private DispatcherTimer time_timer;


        //Auxiliary Variable
        private bool Recording = false;
        private bool Saving = false;
        private int secondForAnalysis = 3;
        private int countRequest = 0;
        private int countFaceRequest = 0;
        private CameraData DefaultEmptyCamera= new CameraData() {Id="",Type="Default",Location="",Position="" };

        //Default Constructor
        public AcquisitionForm()
        {
            InitializeComponent();

            //Initializing Manager Classes
            streamManager = new StreamManager();
            faceSentimentManager = new FaceSentimentManager();
            faceDetectionManager = new FaceDetectionManager();
            dBCameraManager = new DBCameraManager();

            //-----------------------------------------------------------------

            //Enable Event
            this.FormClosing += streamManager.Closing_Video_Event;
            streamManager.FrameHandler += this.ShowStream;
            streamManager.ErrorStreamHandler += ErrorStream;


            waitingBitmap = new Bitmap("waiting_Video.png");
            float scale = Math.Min(1080 / waitingBitmap.Width, 720 / waitingBitmap.Height);
            waitingBitmap = new Bitmap(waitingBitmap, new Size((int)(waitingBitmap.Width * scale), (int)(waitingBitmap.Height * scale)));
            ShowBox.Image = waitingBitmap;

            //Timer Initialization
            save_timer = new DispatcherTimer();
            save_timer.Tick += new EventHandler(SaveStream);
            save_timer.Tick += new EventHandler(ResetProgressBar);
            save_timer.Interval = new TimeSpan(0, 0, 0, secondForAnalysis, 0);

            Save_ProgresBar.Visible = false;


            time_timer = new DispatcherTimer();
            time_timer.Tick += new EventHandler(IncrementProgressBar);
            time_timer.Interval = new TimeSpan(0, 0, 0, 1, 0);

            //Initializing ComboBox
            object[] precisionArray = new object[] { 0.0, 0.01, 0.05, 0.1, 0.15, 0.2, 0.3 };
            this.TrackPrecision_ComboBox.Items.AddRange(precisionArray);

            object[] sencondForAnalysis = new object[] { 1, 2, 3, 4, 5, 10, 20, 60 };
            this.SecondForAnalysis_ComboBox.Items.AddRange(sencondForAnalysis);
            
            //Setting Connection strings
            this.Reset_Button_Click(this, null);
            streamManager.UseLocalCamera = streamOnComputer;

            populateCameraComboBox();
        }


        //Function Called by Event
        public void ShowStream(object sender, Bitmap e)
        {
            ShowBox.Image = e;
        }

        private void ErrorStream(object sender, string e)
        {
            this.StopStream_Button_Click("", new EventArgs());
        }

        public async void SaveStream(object sender, EventArgs e)
        {
            try
            {
                Bitmap image = (Bitmap)this.ShowBox.Image.Clone();
                bool findFace = faceDetectionManager.CheckAndTrackFaces(image);
                if (!findFace)
                {
                    OutputResult.Text = "Request not Sent\n" + faceDetectionManager.ErrorMessage;
                    return;
                }
                var findSentiment = faceSentimentManager.DetectFaceSentiment(image);
                if (!(await findSentiment))
                {
                    if (!useFreeFaceApi && faceSentimentManager.RequestSent)
                    {
                        countRequest++;
                        image.Save($@"C:\Users\giorgira\Desktop\FaceDetected\RequestNotDetected_{countRequest - countFaceRequest}.jpg");
                        WarningPay_Label.Text = $"Warning: You did a total of {countRequest}\n Estimated Cost {0.84 * countRequest / 1000.0} Euro.\n Face detected {countFaceRequest} on {countRequest}";
                    }
                    else if (!useFreeFaceApi)
                    {
                        WarningPay_Label.Text = $"Warning: You did a total of {countRequest}\n Estimated Cost {0.84 * countRequest / 1000.0} Euro.\n Face detected {countFaceRequest} on {countRequest}";
                    }
                    else
                        WarningPay_Label.Text = "";
                    OutputResult.Text = faceSentimentManager.ErrorMessage;
                    return;
                }
                if (!useFreeFaceApi)
                {
                    countRequest += faceSentimentManager.NumOfFaceDetected;
                    countFaceRequest += faceSentimentManager.NumOfFaceDetected;
                    WarningPay_Label.Text = $"Warning: You did a total of {countRequest}\n Estimated Cost {0.84 * countRequest / 1000.0} Euro.\n Face detected {countFaceRequest} on {countRequest}";
                }
                else
                    WarningPay_Label.Text = "";
                var isSaved = await faceSentimentManager.AddToDbAsync();
                if (isSaved)
                {
                    OutputResult.Text = $"Correctly saved {faceSentimentManager.NumOfFaceDetected} faces sentiment";
                }
                else
                {
                    OutputResult.Text = faceSentimentManager.ErrorMessage;
                }
            }
            catch (Exception ex)
            {
                OutputResult.Text = ex.Message;
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                    OutputResult.Text += "\n" + ex.Message;
                }
                this.StopSave_Button_Click(sender, e);
            }
        }

        private void IncrementProgressBar(object sender, EventArgs e)
        {
            int Increment = (int)Math.Round((double)Save_ProgresBar.Maximum / (double)secondForAnalysis);
            if (Save_ProgresBar.Value + Increment > Save_ProgresBar.Maximum)
            {
                Save_ProgresBar.Value = Save_ProgresBar.Maximum;
                return;
            }
            Save_ProgresBar.Value += Increment;
        }

        private void ResetProgressBar(object sender, EventArgs e)
        {
            Save_ProgresBar.Value = Save_ProgresBar.Minimum;
        }

        private void SetFaceDetectionAttributes()
        {
            faceDetectionManager.FaceMinDimension = Convert.ToInt32(FaceMD_toolStripComboBox.SelectedItem);
            faceDetectionManager.FacePercentage = Convert.ToDouble(FacePerc_toolStripComboBox.SelectedItem);
            faceDetectionManager.FaceNeighboors = Convert.ToInt32(FaceNeighboor_toolStripComboBox.SelectedItem);
            faceDetectionManager.EyeMinDimension = Convert.ToInt32(EyeMinimal_toolStripComboBox.SelectedItem);
            faceDetectionManager.EyePercentage = Convert.ToDouble(EyePerc_toolStripComboBox.SelectedItem);
            faceDetectionManager.EyeNeighboors = Convert.ToInt32(EyeNeighBoors_toolStripComboBox2.SelectedItem);
        }


        //Button and Combo Box Event
        private void StartStream_Button_Click(object sender, EventArgs e)
        {
            streamManager.ConnectionString = this.StreamConnection_Box.Text;
            streamManager.Password = this.Password_TextBox.Text;
            streamManager.User = this.User_TextBox.Text;
            StreamConnection_Box.Enabled = false;
            User_TextBox.Enabled = false;
            Password_TextBox.Enabled = false;
            DatabaseConnection_Box.Enabled = false;
            FaceApiKey_Box.Enabled = false;
            FaceApiUri_Box.Enabled = false;
            selectCameraToolStripMenuItem.Enabled = false;
            try
            {
                streamManager.StartStream();
                Recording = true;
                this.VideoStatus.Text = "On Stream";
            }
            catch (Exception ex)
            {
                OutputResult.Text = ex.Message;
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                    OutputResult.Text += "\n" + ex.Message;
                }
                this.StopStream_Button_Click(sender, e);
            }
        }

        private void StopStream_Button_Click(object sender, EventArgs e)
        {
            try
            {
                streamManager.StopStream();
                this.VideoStatus.Text = "No Stream";
                Recording = false;
                if (Saving)
                {
                    this.StopSave_Button_Click(sender, e);
                }
                
            }
            catch (Exception ex)
            {
                OutputResult.Text = ex.Message;
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                    OutputResult.Text += "\n" + ex.Message;
                }
                Recording = false;
                if (Saving)
                {
                    this.StopSave_Button_Click(sender, e);
                }
            }
            this.ShowBox.Image = waitingBitmap;
            this.VideoStatus.Text = "No Stream";

            StreamConnection_Box.Enabled = true;
            User_TextBox.Enabled = true;
            Password_TextBox.Enabled = true;
            DatabaseConnection_Box.Enabled = true;
            FaceApiKey_Box.Enabled = true;
            FaceApiUri_Box.Enabled = true;
            selectCameraToolStripMenuItem.Enabled = true;
        }

        private void StartSaving_Button_Click(object sender, EventArgs e)
        {
            if (!Recording)
            {
                Saving = false;
                this.SaveStatus.Text = "No Saving";
                return;
            }
            if (!Saving)
            {
                //Settings
                faceSentimentManager.DatabaseConnection = this.DatabaseConnection_Box.Text;
                faceSentimentManager.FaceApiKey = this.FaceApiKey_Box.Text;
                faceSentimentManager.FaceApiUriBase = this.FaceApiUri_Box.Text;

                //Prepare progress Bar
                Save_ProgresBar.Visible = true;
                Save_ProgresBar.Value = Save_ProgresBar.Minimum;

                //Start Saving Event Request
                time_timer.Start();
                save_timer.Start();

                this.SaveStatus.Text = "On Saving";
                Saving = true;

            }
        }

        private void StopSave_Button_Click(object sender, EventArgs e)
        {
            if (Saving)
            {
                Save_ProgresBar.Visible = false;
                this.SaveStatus.Text = "No Saving";
                Saving = false;
                save_timer.Stop();
                time_timer.Stop();
            }
        }

        private void TrackPrecision_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            faceDetectionManager.PrecisionTrack = (double)this.TrackPrecision_ComboBox.SelectedItem;
        }

        private void SecondForAnalysis_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            secondForAnalysis = (int)SecondForAnalysis_ComboBox.SelectedItem;
            save_timer.Interval = new TimeSpan(0, 0, 0, secondForAnalysis, 0);
        }

        private void ComputerCamera_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            bool restartStream = Recording;
            bool restartSave = Saving;
            if (Recording)
                this.StopStream_Button_Click(sender, e);

            streamOnComputer = ComputerCamera_checkBox.Checked;
            streamManager.UseLocalCamera = streamOnComputer;

            if (restartStream)
                this.StartStream_Button_Click(sender, e);
            if (restartSave)
                this.StartSaving_Button_Click(sender, e);
        }

        private void Reset_Button_Click(object sender, EventArgs e)
        {

            faceApiKey = useFreeFaceApi ? FREEfaceApiKey : PayfaceApiKey;
            //Reset Connection strings
            streamManager.User = streamUser;
            streamManager.Password = streamPassword;
            streamManager.ConnectionString = streamConnection;
            faceSentimentManager.DatabaseConnection = databaseConnection;
            faceSentimentManager.FaceApiKey = faceApiKey;
            faceSentimentManager.FaceApiUriBase = faceApiUri;

            //Reset Strings Showed
            this.StreamConnection_Box.Text = streamConnection;
            this.User_TextBox.Text = streamUser;
            this.Password_TextBox.Text = streamPassword;
            this.DatabaseConnection_Box.Text = databaseConnection;
            this.FaceApiKey_Box.Text = faceApiKey;
            this.FaceApiUri_Box.Text = faceApiUri;

            //Reset CheckBox
            //UseJpeg_checkBox.Checked = useJpegForIp;
            ComputerCamera_checkBox.Checked = streamOnComputer;
            ComputerCamera_checkBox_CheckedChanged(sender, e);
            //UseJpeg_checkBox_CheckedChanged(sender, e);

            //Reset ComboBox
            this.SecondForAnalysis_ComboBox.SelectedIndex = selectedTimeIndex;
            this.TrackPrecision_ComboBox.SelectedIndex = selectedTrackIndex;
            this.SecondForAnalysis_ComboBox_SelectedIndexChanged(sender, e);
            this.TrackPrecision_ComboBox_SelectedIndexChanged(sender, e);

            //Reset FaceDetection Attributes
            this.EyeMinimal_toolStripComboBox.SelectedIndex = 0;
            this.EyeNeighBoors_toolStripComboBox2.SelectedIndex = 5;
            this.EyePerc_toolStripComboBox.SelectedIndex = 0;
            this.FaceMD_toolStripComboBox.SelectedIndex = 0;
            this.FaceNeighboor_toolStripComboBox.SelectedIndex = 5;
            this.FacePerc_toolStripComboBox.SelectedIndex = 0;
            SetFaceDetectionAttributes();
        }

        private void UseFreeApi_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            useFreeFaceApi = UseFreeApi_CheckBox.Checked;
            if (!useFreeFaceApi)
            {
                DialogResult res = MessageBox.Show(
                    "You are Passing to Pay modality.\n The cost is 0.84 Euro/ 1000 Requests.\n Are sure?",
                    "Passing Pay Mode",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );
                if (res == DialogResult.No)
                {
                    UseFreeApi_CheckBox.Checked = true;
                    useFreeFaceApi = true;
                }
            }
            faceSentimentManager.FaceApiKey = useFreeFaceApi ? FREEfaceApiKey : PayfaceApiKey;
        }

        private void EyeNeighBoors_toolStripComboBox2_Click(object sender, EventArgs e)
        {
            SetFaceDetectionAttributes();
        }

        private void EyeMinimal_toolStripComboBox_Click(object sender, EventArgs e)
        {
            SetFaceDetectionAttributes();
        }

        private void EyePerc_toolStripComboBox_Click(object sender, EventArgs e)
        {
            SetFaceDetectionAttributes();
        }

        private void FaceMD_toolStripComboBox_Click(object sender, EventArgs e)
        {
            SetFaceDetectionAttributes();
        }

        private void FaceNeighboor_toolStripComboBox_Click(object sender, EventArgs e)
        {
            SetFaceDetectionAttributes();
        }

        private void FacePerc_toolStripComboBox_Click(object sender, EventArgs e)
        {
            SetFaceDetectionAttributes();
        }

        private void newCamera_DoubleClickEvent(object sender, EventArgs e)
        {
            NewCameraForm newCameraForm = new NewCameraForm(dBCameraManager);
            newCameraForm.ShowDialog();
            populateCameraComboBox();
        }

        private async void populateCameraComboBox()
        {
            SelectCamera_toolStripComboBox.Items.Clear();
            int index = SelectCamera_toolStripComboBox.SelectedIndex;
            var ListOfCameras = await dBCameraManager.ReadCamera();
            if (dBCameraManager.ErrorMessage != "")
                throw new Exception(dBCameraManager.ErrorMessage);
            SelectCamera_toolStripComboBox.Items.Add(DefaultEmptyCamera);
            SelectCamera_toolStripComboBox.Items.AddRange(ListOfCameras.ToArray());
            if (index < 0)
                index = 0;
            SelectCamera_toolStripComboBox.SelectedIndex = index;
        }

        private void SelectCamera_toolStripComboBox_Click(object sender, EventArgs e)
        {
        }

        private void SelectCamera_toolStripComboBox_SelectionChanged(object sender, EventArgs e)
        {
            CameraData selec = (CameraData)SelectCamera_toolStripComboBox.SelectedItem;
            faceSentimentManager.CameraId = selec.Id;
        }
    }
}
