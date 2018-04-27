using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceSentiment.GenericStructure.FormType.Models
{
    public class DBCameraManager
    {
        private string connectionString = "Server=tcp:cegekafacesentiment.database.windows.net,1433;Initial Catalog=FaceSentimentDatabase;Persist Security Info=False;User ID=ServerAdmin;Password=Familyfour4;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        private const string readCommandString = "SELECT * FROM [dbo].[Camera]";
        private const string createCommandString = @"INSERT INTO [dbo].[Camera] ([IdCamera],  [Type],  [Locality],  [Position]) VALUES (@IdCamera, @Type, @Locality, @Position);";
        private string errorMessage = "";
        public string ConnectionString { get => connectionString; set => connectionString = value; }
        public string ErrorMessage { get => errorMessage; set => errorMessage = value; }

        public async Task<bool> CreateCamera(CameraData camera)
        {
            bool result = true;
            errorMessage = "";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand saveFaceCom = new SqlCommand(createCommandString, conn);
                    saveFaceCom.Parameters.Add("@IdCamera", SqlDbType.NVarChar).Value = camera.Id;
                    saveFaceCom.Parameters.Add("@Type", SqlDbType.NVarChar).Value = camera.Type;
                    saveFaceCom.Parameters.Add("@Locality", SqlDbType.NVarChar).Value = camera.Location;
                    saveFaceCom.Parameters.Add("@Position", SqlDbType.NVarChar).Value = camera.Position;

                    var done = await saveFaceCom.ExecuteNonQueryAsync();
                    if (done == -1)
                    {
                        throw new Exception(saveFaceCom.CommandText);
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                errorMessage = "Error on Reading camera name\n" + ex.Message;
                result = false;
            }
            return result;
        }

        public async Task<List<CameraData>> ReadCamera()
        {
            List<CameraData> cameras = new List<CameraData>();
            errorMessage = "";
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand readComand = new SqlCommand(readCommandString, conn);
                    SqlDataReader cameraReader = await readComand.ExecuteReaderAsync();
                    if (cameraReader.HasRows)
                    {
                        while (cameraReader.Read())
                        {
                            CameraData cam = new CameraData();
                            cam.Id = (string) cameraReader["IdCamera"];
                            cam.Type = (string)cameraReader["Type"];
                            cam.Location = (string)cameraReader["Locality"];
                            cam.Position = (string)cameraReader["Position"];
                            cameras.Add(cam);
                        }
                    }
                    conn.Close();
                }
            }catch(Exception ex)
            {
                errorMessage = "Error on Db Reading Camera\n" + ex.Message;
            }
            return cameras;
        }
    }

    public class CameraData
    {
        public string Id;
        public string Type;
        public string Position;
        public string Location;
        public override string ToString()
        {
            return Type+": "+Location + " " + Position;
        }
    }
}
