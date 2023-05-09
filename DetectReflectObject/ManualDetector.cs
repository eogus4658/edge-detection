using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;

namespace DetectReflectObject
{
    public class ManualDetector
    {
        private static ManualDetector detector = null;

        private ManualDetector() {}

        public static ManualDetector shared
        {
            get
            {
                if (detector == null)
                {
                    detector = new ManualDetector();
                }
                return detector;
            }
        }

        // ----------------------------------------------------------
        // 1. RGB값을 Gray Scale로 변환
        public Mat toGrayScale(Mat image)
        {
            Mat grayImage = new Mat();
            Cv2.CvtColor(image, grayImage, ColorConversionCodes.BGR2GRAY);
            return grayImage;
        }
    }
}
