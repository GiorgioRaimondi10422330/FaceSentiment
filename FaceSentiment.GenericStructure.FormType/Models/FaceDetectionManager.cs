using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceSentiment.GenericStructure.FormType.Models
{
    public class FaceDetectionManager
    {
        //Auxiliar Element
        private double precisionTrack = 0.1;
        private string errorMessage = "None";

        //Face and Eye Position
        private CascadeClassifier faceClassifier;
        private CascadeClassifier eyeLeftClassifier;
        private CascadeClassifier eyeRightClassifier;

        private string faceHaarPath;
        private string eyeLeftPath;
        private string eyeRightPath;

        private Rectangle[] oldFaceRectangles;
        private Rectangle[] oldEyeLeftRectangles;
        private Rectangle[] oldEyeRightRectangles;

        private Rectangle[] defaultRect = new Rectangle[] { new Rectangle(new Point(0, 0), new Size(0, 0)) };

        //Settings
        private int eyeMinDimension = 1;
        private int faceMinDimension = 1;
        private double eyePercentage = 1.1;
        private double facePercentage = 1.1;
        private int eyeNeighboors = 5;
        private int faceNeighboors = 3;


        //Default Constructor
        public FaceDetectionManager()
        {
            faceHaarPath = Path.Combine("haarcascadeFile", "haarcascade_frontalface_alt_tree.xml");
            eyeLeftPath = Path.Combine("haarcascadeFile", "haarcascade_lefteye_2splits.xml");
            eyeRightPath = Path.Combine("haarcascadeFile", "haarcascade_righteye_2splits.xml");

            faceClassifier = new CascadeClassifier(faceHaarPath);
            eyeLeftClassifier = new CascadeClassifier(eyeLeftPath);
            eyeRightClassifier = new CascadeClassifier(eyeRightPath);

            oldFaceRectangles = defaultRect;
            oldEyeLeftRectangles = defaultRect;
            oldEyeRightRectangles = defaultRect;
        }

        //Properties
        public double PrecisionTrack
        {
            get => precisionTrack;
            set => precisionTrack = setPrecision(value);
        }
        public string ErrorMessage { get => errorMessage; }
        public int EyeMinDimension { get => eyeMinDimension; set => eyeMinDimension = value; }
        public int FaceMinDimension { get => faceMinDimension; set => faceMinDimension = value; }
        public double EyePercentage { get => eyePercentage; set => eyePercentage = value; }
        public double FacePercentage { get => facePercentage; set => facePercentage = value; }
        public int EyeNeighboors { get => eyeNeighboors; set => eyeNeighboors = value; }
        public int FaceNeighboors { get => faceNeighboors; set => faceNeighboors = value; }

        //Public Method
        public bool CheckAndTrackFaces(Bitmap image)
        {
            try
            {
                if (image == null)
                {
                    errorMessage = "Image for Facedetection is Empty";
                    return false;
                }

                errorMessage = "None";
                Image<Bgr, Byte> currentFrame = new Image<Bgr, byte>(image);
                Image<Gray, Byte> grayFrame = currentFrame.Convert<Gray, Byte>();

                var faceRectangles = faceClassifier.DetectMultiScale(grayFrame, facePercentage, faceNeighboors, new System.Drawing.Size(faceMinDimension, faceMinDimension));
                var eyeLeftRectangles = eyeLeftClassifier.DetectMultiScale(grayFrame, eyePercentage, eyeNeighboors, new System.Drawing.Size(eyeMinDimension, eyeMinDimension));
                var eyeRightRectangles = eyeRightClassifier.DetectMultiScale(grayFrame, eyePercentage, eyeNeighboors, new System.Drawing.Size(eyeMinDimension, eyeMinDimension));

                if ((faceRectangles == null || faceRectangles.Length == 0) && (eyeLeftRectangles == null || eyeLeftRectangles.Length == 0) && (eyeRightRectangles == null || eyeRightRectangles.Length == 0))
                {
                    oldFaceRectangles = defaultRect;
                    oldEyeLeftRectangles = defaultRect;
                    oldEyeRightRectangles = defaultRect;
                    errorMessage = "No face detected";
                    return false;
                }

                bool noChange = trackerNotChanged(faceRectangles, oldFaceRectangles, eyeLeftRectangles, oldEyeLeftRectangles, eyeRightRectangles, oldEyeRightRectangles, precisionTrack);

                if (noChange)
                {
                    errorMessage = "Face detected, but no Face tracking";
                    return false;
                }
                oldEyeLeftRectangles = eyeLeftRectangles;
                oldEyeRightRectangles = eyeRightRectangles;
                oldFaceRectangles = faceRectangles;
                return true;

            }
            catch (Exception ex)
            {
                errorMessage = "Error during face detection\n" + ex.Message;
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                    errorMessage += "\n" + ex.Message;
                }
                return false;
            }
        }

        //Private Methods
        private bool trackerNotChanged(Rectangle[] recsFace, Rectangle[] oldRecsFace, Rectangle[] recsLeftEye, Rectangle[] oldRecsLeftEye, Rectangle[] recsRightEye, Rectangle[] oldRecsRightEye, double prec = 0.1)
        {
            //Check changes of number of rectangles
            if ((recsFace != null && recsFace.Length != oldRecsFace.Length) ||
                (recsLeftEye != null && recsLeftEye.Length != oldRecsLeftEye.Length) ||
                (recsRightEye != null && recsRightEye.Length != oldRecsRightEye.Length))
                return false;

            //Check changes on Face rectangles
            if (recsFace != null && recsFace.Length != 0)
                return allEqualRectangle(recsFace, oldRecsFace, (int)Math.Round(recsFace[0].Height * prec));

            //Check changes on Eyes
            bool equalRight;
            bool equalLeft;

            if (recsLeftEye == null || recsLeftEye.Length == 0)
                equalLeft = true;
            else
                equalLeft = allEqualRectangle(recsLeftEye, oldRecsLeftEye, (int)Math.Round(recsLeftEye[0].Height * prec));

            if (recsRightEye == null || recsRightEye.Length == 0)
                equalRight = true;
            else
                equalRight = allEqualRectangle(recsRightEye, oldRecsRightEye, (int)Math.Round(recsRightEye[0].Height * prec));

            return equalLeft && equalRight;
        }
        private bool allEqualRectangle(Rectangle[] recs, Rectangle[] oldRecs, int delta = 3)
        {
            if (recs == null || recs.Length == 0 || oldRecs == null || oldRecs.Length == 0)
                return false;
            bool allEqual;
            bool equal;
            foreach (var rec in recs)
            {
                allEqual = false;
                foreach (var oldrec in oldRecs)
                {
                    equal = true;
                    if (rec.Location.X > oldrec.Location.X + delta || rec.Location.X < oldrec.Location.X - delta)
                        equal = false;
                    if (rec.Location.Y > oldrec.Location.Y + delta || rec.Location.Y < oldrec.Location.Y - delta)
                        equal = false;
                    if (rec.Location.X > oldrec.Location.X + delta || rec.Location.X < oldrec.Location.X - delta)
                        equal = false;
                    if (rec.Location.X > oldrec.Location.X + delta || rec.Location.X < oldrec.Location.X - delta)
                        equal = false;
                    if (equal)
                    {
                        allEqual = true;
                        break;
                    }
                }
                if (!allEqual)
                    return false;
            }
            return true;
        }
        private double setPrecision(double value)
        {
            if (value > 1.0)
                return 1.0;
            if (value < 0.0)
                return 0.0;
            return value;
        }

    }
}
