using System;
using System.Drawing;

namespace FaceSentiment.GenericStructure.FormType.Models
{
    public interface IStreamManager
    {
        string ConnectionString { get; set; }
        EventHandler<string> ErrorStreamHandler { get; set; }
        EventHandler<Bitmap> FrameHandler { get; set; }
        string Password { get; set; }
        bool UseLocalCamera { get; set; }
        string User { get; set; }

        void Closing_Video_Event(object sender, EventArgs e);
        void StartStream();
        void StopStream();
    }
}