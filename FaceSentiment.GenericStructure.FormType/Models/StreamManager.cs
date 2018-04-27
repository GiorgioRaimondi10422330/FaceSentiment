using System;
using System.Drawing;
using AForge.Video;
using AForge.Video.DirectShow;

namespace FaceSentiment.GenericStructure.FormType.Models
{

    public class StreamManager : IStreamManager
    {
        //Private Fields
        private FilterInfoCollection videoDevicesList;
        private IVideoSource computerStream;
        private MJPEGStream webCamIpStream;
        private volatile object _locker = new object();
        private string connectionString = "";
        private string user = "";
        private string password = "";
        private bool useLocalCamera = true;

        //Public fields
        public EventHandler<Bitmap> frameHandler;
        private EventHandler<string> errorStreamHandler;

        //Properties
        public string ConnectionString { get => connectionString; set => connectionString = value; }
        public bool UseLocalCamera { get => useLocalCamera; set => useLocalCamera = value; }
        public string Password { get => password; set => password = value; }
        public string User { get => user; set => user = value; }
        public EventHandler<Bitmap> FrameHandler { get => frameHandler; set => frameHandler = value; }
        public EventHandler<string> ErrorStreamHandler { get => errorStreamHandler; set => errorStreamHandler = value; }

        //Constructor
        public StreamManager()
        {
            videoDevicesList = new FilterInfoCollection(FilterCategory.VideoInputDevice);
        }
        //Event
        public void Closing_Video_Event(object sender, EventArgs e)
        {
            if (computerStream != null && computerStream.IsRunning)
            {
                computerStream.SignalToStop();
                return;
            }
            if (webCamIpStream != null && webCamIpStream.IsRunning)
            {
                webCamIpStream.SignalToStop();
            }
        }
        private void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            try
            {
                if (FrameHandler != null)
                {
                    Bitmap bi = (Bitmap)eventArgs.Frame.Clone();
                    FrameHandler.Invoke(sender, bi);
                }
                else
                {
                    throw new Exception("No event Listener");
                }

            }
            catch (Exception ex)
            {
                if (errorStreamHandler != null)
                {
                    errorStreamHandler.Invoke("", "Error while showing Frame\n" + ex.Message);
                }
                else
                {
                    this.StopStream();
                    throw new Exception("Error while showing Frame\n", ex);
                }
            }
        }
        public void StartStream()
        {
            if (!useLocalCamera)
            {
                if (connectionString == "" || user == "" || password == "")
                {
                    throw new Exception("Error while starting Streaming\n No connection string set");
                }
                try
                {
                    webCamIpStream = new MJPEGStream(connectionString);
                    webCamIpStream.Login = user;
                    webCamIpStream.Password = password;
                    webCamIpStream.NewFrame += new NewFrameEventHandler(video_NewFrame);
                    webCamIpStream.Start();

                }
                catch (Exception ex)
                {
                    this.StopStream();
                    throw new Exception("Error while starting Streaming IP", ex);
                }
            }
            else
            {
                if (videoDevicesList.Count == 0)
                {
                    throw new Exception("Error while starting Streaming\n No device found");
                }
                try
                {
                    computerStream = new VideoCaptureDevice(videoDevicesList[0].MonikerString);
                    computerStream.NewFrame += new NewFrameEventHandler(video_NewFrame);
                    computerStream.Start();
                }
                catch (Exception ex)
                {
                    this.StopStream();
                    throw new Exception("Error while starting Streamin on DeviceList", ex);
                }
            }
        }
        public void StopStream()
        {
            if (useLocalCamera)
            {
                if (computerStream != null)
                    computerStream.SignalToStop();
            }
            else
            {
                if (webCamIpStream != null)
                    webCamIpStream.SignalToStop();
            }
        }
    }
}
