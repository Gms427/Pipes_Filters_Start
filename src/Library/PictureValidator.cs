using System;
using CognitiveCoreUCU;

namespace CompAndDel
{

    public class PictureValidator
    {
        private CognitiveFace cogFace;

        public PictureValidator(string key = "620e818a46524ceb92628cde08068242")
        {
            this.cogFace = new CognitiveFace(key);
        }

        public bool ValidatePictureContainFace(string path)
        {
            this.cogFace.Recognize(path);
            return this.cogFace.FaceFound;
        }

        public bool ValidatePictureContainFaceSmiling(string path)
        {
            this.cogFace.Recognize(path);
            return (this.cogFace.FaceFound && this.cogFace.SmileFound);
        }
    }
}
