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

namespace FaceSentiment.GenericStructure.FormType
{
    public partial class NewCameraForm : Form
    {
        DBCameraManager Camera;
        public NewCameraForm(DBCameraManager camM)
        {
            InitializeComponent();
            Camera = camM;
        }

        private async void SaveBtn_Click(object sender, EventArgs e)
        {
            var mx = MessageBox.Show(this,"Do you want to create a new camera?","Confirm Saving", MessageBoxButtons.YesNo);
            if (mx == DialogResult.Yes)
            {
                Guid NewId = Guid.NewGuid();
                CameraData cam = new CameraData();
                cam.Id = NewId.ToString();
                cam.Type = Type_textBox.Text;
                cam.Location = Location_textBox.Text;
                cam.Position = Position_textBox.Text;
                bool done = await Camera.CreateCamera(cam);
                if (!done)
                {
                    MessageBox.Show(Camera.ErrorMessage);
                }
                this.Close();
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
