using Microsoft.ProjectOxford.Face;
using Microsoft.ProjectOxford.Face.Contract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FaceSentiment.GenericStructure.FormType.Models
{

    public class FaceSentimentManager
    {
        //Database Variable
        private string databaseConnection = "Server=tcp:cegekafacesentiment.database.windows.net,1433;Initial Catalog=FaceSentimentDatabase;Persist Security Info=False;User ID=ServerAdmin;Password=Familyfour4;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        private const string SqlAddFaceQuery = @"INSERT INTO dbo.[Table] ([Age],  [Gender],  [EmotionAnger],  [EmotionContempt],  [EmotionDisgust],  [EmotionFear],  [EmotionHappiness],  [EmotionNeutral],  [EmotionSadness],  [EmotionSurprise],  [Blur], [Date],  [Smile],[FaceId],[HairBald],[HairInvisible],[HairColorFirst],[HairColorSecond],[Moustache],[Beard],[Sideburns],[Glasses],[MakeupEye],[MakeupLip],[Accessories1],[Accessories2],[CameraId]) VALUES (@Age, @Gender, @EmotionAnger, @EmotionContempt, @EmotionDisgust, @EmotionFear, @EmotionHappiness, @EmotionNeutral, @EmotionSadness, @EmotionSurprise, @Blur,@Date, @Smile,@FaceId,@HairBald,@HairInvisible,@HairColorFirst,@HairColorSecond,@Moustache,@Beard,@Sideburns,@Glasses,@MakeupEye,@MakeupLip,@Accessories1,@Accessories2,@CameraId)";

        //Face Api Variable
        private IFaceServiceClient _faceServiceClient;
        private string uriBase = "https://westeurope.api.cognitive.microsoft.com/face/v1.0";
        private string faceApiKey = "987dfd8276384149b82fdc21da1219eb";
        

        //Generic Variable
        private string errorMessage = "";
        private Face[] faces;
        private int numOfFaceDetected = 0;
        private bool requestSent = false;

        //Face Tracking in Time
        private List<Guid> FaceIdSeen;
        private List<DateTime> FaceTimeSeen;
        private double confidenceLevel=0.8;
        private int maxNumberOfFaceComparable=100;
        private string cameraId = "";

        public FaceSentimentManager()
        {
            FaceIdSeen = new List<Guid>();
            FaceTimeSeen = new List<DateTime>();
        }
        //Properties
        public string ErrorMessage { get => errorMessage; }
        public string DatabaseConnection { get => databaseConnection; set => databaseConnection = value; }
        public string FaceApiUriBase { get => uriBase; set => uriBase = value; }
        public string FaceApiKey { get => faceApiKey; set => faceApiKey = value; }
        public int NumOfFaceDetected { get => numOfFaceDetected; private set => numOfFaceDetected = value; }
        public bool RequestSent { get => requestSent; private set => requestSent = value; }
        public double ConfidenceLevel { get => confidenceLevel; set => confidenceLevel = value<0?0:(value>1?1:value); }
        public int MaxNumberOfFaceComparable { get => maxNumberOfFaceComparable; set => maxNumberOfFaceComparable = value>=4?value:4; }
        public string CameraId { get => cameraId; set => cameraId = value; }

        //Saving Face on Db
        public async Task<bool> AddToDbAsync()
        {
            if (faces == null || faces.Length == 0)
                return false;
            bool allCorrect = true;
            DateTime date = DateTime.Now;
            using (SqlConnection conn = new SqlConnection(databaseConnection))
            {
                foreach (var face in faces)
                {
                    try
                    {
                        conn.Open();
                        SqlCommand saveFaceCom = new SqlCommand(SqlAddFaceQuery, conn);

                        saveFaceCom.Parameters.Add("@Age", SqlDbType.Float).Value = face.FaceAttributes.Age;
                        saveFaceCom.Parameters.Add("@Gender", SqlDbType.NChar).Value = face.FaceAttributes.Gender;
                        saveFaceCom.Parameters.Add("@EmotionAnger", SqlDbType.Float).Value = face.FaceAttributes.Emotion.Anger;
                        saveFaceCom.Parameters.Add("@EmotionContempt", SqlDbType.Float).Value = face.FaceAttributes.Emotion.Contempt;
                        saveFaceCom.Parameters.Add("@EmotionDisgust", SqlDbType.Float).Value = face.FaceAttributes.Emotion.Disgust;
                        saveFaceCom.Parameters.Add("@EmotionFear", SqlDbType.Float).Value = face.FaceAttributes.Emotion.Fear;
                        saveFaceCom.Parameters.Add("@EmotionHappiness", SqlDbType.Float).Value = face.FaceAttributes.Emotion.Happiness;
                        saveFaceCom.Parameters.Add("@EmotionNeutral", SqlDbType.Float).Value = face.FaceAttributes.Emotion.Neutral;
                        saveFaceCom.Parameters.Add("@EmotionSadness", SqlDbType.Float).Value = face.FaceAttributes.Emotion.Sadness;
                        saveFaceCom.Parameters.Add("@EmotionSurprise", SqlDbType.Float).Value = face.FaceAttributes.Emotion.Surprise;
                        saveFaceCom.Parameters.Add("@Blur", SqlDbType.Float).Value = face.FaceAttributes.Blur.Value;
                        saveFaceCom.Parameters.Add("@Date", SqlDbType.DateTime).Value = date;
                        saveFaceCom.Parameters.Add("@Smile", SqlDbType.Float).Value = face.FaceAttributes.Smile;
                        var faceID = face.FaceId.ToString();
                        saveFaceCom.Parameters.Add("@FaceId", SqlDbType.NVarChar).Value = faceID;
                        
                        saveFaceCom.Parameters.Add("@HairBald", SqlDbType.Float).Value = face.FaceAttributes.Hair.Bald;
                        saveFaceCom.Parameters.Add("@HairInvisible", SqlDbType.Bit).Value = face.FaceAttributes.Hair.Invisible;
                        
                        saveFaceCom.Parameters.Add("@Moustache", SqlDbType.Float).Value = face.FaceAttributes.FacialHair.Moustache;
                        saveFaceCom.Parameters.Add("@Beard", SqlDbType.Float).Value = face.FaceAttributes.FacialHair.Beard;
                        saveFaceCom.Parameters.Add("@Sideburns", SqlDbType.Float).Value = face.FaceAttributes.FacialHair.Sideburns;
                        saveFaceCom.Parameters.Add("@Glasses", SqlDbType.NChar).Value = face.FaceAttributes.Glasses.ToString();
                        saveFaceCom.Parameters.Add("@MakeupEye", SqlDbType.Bit).Value = face.FaceAttributes.Makeup.EyeMakeup;
                        saveFaceCom.Parameters.Add("@MakeupLip", SqlDbType.Bit).Value = face.FaceAttributes.Makeup.LipMakeup;


                        //Possible Null Value
                        var ColorList = face.FaceAttributes.Hair.HairColor;
                        if (ColorList != null || ColorList.Length != 0)
                        {
                            ColorList.OrderByDescending(c => c.Confidence);
                            saveFaceCom.Parameters.Add("@HairColorFirst", SqlDbType.NChar).Value = ColorList[0].Color.ToString();
                            saveFaceCom.Parameters.Add("@HairColorSecond", SqlDbType.NChar).Value = ColorList[1].Color.ToString();
                        }
                        else
                        {
                            saveFaceCom.Parameters.Add("@HairColorFirst", SqlDbType.NChar).Value = DBNull.Value;
                            saveFaceCom.Parameters.Add("@HairColorSecond", SqlDbType.NChar).Value = DBNull.Value;
                        }
                        var ListAccessories = face.FaceAttributes.Accessories;
                        if(ListAccessories==null || ListAccessories.Length == 0)
                        {
                            saveFaceCom.Parameters.Add("@Accessories1", SqlDbType.NChar).Value = DBNull.Value;
                            saveFaceCom.Parameters.Add("@Accessories2", SqlDbType.NChar).Value = DBNull.Value;
                        }
                        else if(ListAccessories.Length == 1)
                        {
                            saveFaceCom.Parameters.Add("@Accessories1", SqlDbType.NChar).Value = ListAccessories[0].Type.ToString();
                            saveFaceCom.Parameters.Add("@Accessories2", SqlDbType.NChar).Value = DBNull.Value;
                        }
                        else
                        {

                            saveFaceCom.Parameters.Add("@Accessories1", SqlDbType.NChar).Value = ListAccessories[0].Type.ToString();
                            saveFaceCom.Parameters.Add("@Accessories2", SqlDbType.NChar).Value = ListAccessories[1].Type.ToString();
                        }
                        if (cameraId == null || cameraId == "")
                        {
                            saveFaceCom.Parameters.Add("@CameraId", SqlDbType.NVarChar).Value = DBNull.Value;
                        }
                        else
                        {
                            saveFaceCom.Parameters.Add("@CameraId", SqlDbType.NVarChar).Value = cameraId;
                        }

                        var result = await saveFaceCom.ExecuteNonQueryAsync();
                        if (result == -1)
                        {
                            throw new Exception(saveFaceCom.CommandText);
                        }
                        conn.Close();

                    }
                    catch (Exception ex)
                    {
                        this.errorMessage = "Error while saving on Db\n" + ex.Message;
                        allCorrect = false;
                        break;
                    }
                }
            }
            if (allCorrect)
                errorMessage = "";
            return allCorrect;
        }
        public async Task<bool> DetectFaceSentiment(Bitmap image)
        {
            requestSent = false;
            bool result = true;
            numOfFaceDetected = 0;
            faces = null;
            try
            {
                _faceServiceClient= new FaceServiceClient(faceApiKey, uriBase);
                var faceAttributes = new FaceAttributeType[] {
                    FaceAttributeType.Emotion ,
                    FaceAttributeType.Age,
                    FaceAttributeType.Blur,
                    FaceAttributeType.Gender,
                    FaceAttributeType.Smile,
                    FaceAttributeType.FacialHair,
                    FaceAttributeType.Glasses,
                    FaceAttributeType.Hair,
                    FaceAttributeType.Makeup,
                    FaceAttributeType.Accessories
                };
                using (var fromBitmapToBit = new MemoryStream())
                {
                    image.Save(fromBitmapToBit, ImageFormat.Jpeg);
                    using (var imgStream = new MemoryStream(fromBitmapToBit.ToArray()))
                    {
                        faces = await _faceServiceClient.DetectAsync(imgStream, true, false, faceAttributes);
                        requestSent = true;
                    }
                }
                numOfFaceDetected = faces.Length;
                if (numOfFaceDetected == 0)
                {
                    errorMessage = "Request Correctly sent but no face Detected";
                    result = false;
                }
                else
                {
                    await FindSimilarFaces();
                }
            }
            catch (Exception ex)
            {
                errorMessage = "Error on FaceSentiment Detection\n" + ex.Message;
                result = false;
            }
            return result;
        }
        private async Task FindSimilarFaces()
        {
            while (FaceIdSeen.Count > maxNumberOfFaceComparable)
            {
                int percentRemoved = (int) Math.Round(maxNumberOfFaceComparable * 0.3);
                FaceIdSeen.RemoveRange(0, percentRemoved);
                FaceTimeSeen.RemoveRange(0, percentRemoved);
            }
            if (FaceIdSeen.Count != 0)
            {
                foreach (var face in faces)
                {
                    var similarFace = await _faceServiceClient.FindSimilarAsync(face.FaceId, FaceIdSeen.ToArray(), FindSimilarMatchMode.matchFace, 1);
                    face.FaceId = (similarFace != null && similarFace[0].Confidence > confidenceLevel) ? similarFace[0].FaceId : face.FaceId;
                }
            }
            foreach (var face in faces)
            {
                FaceIdSeen.Add(face.FaceId);
                FaceTimeSeen.Add(DateTime.Now);
            }
        }
    }
}
