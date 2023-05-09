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

        // 2. Gray Scale -> Binary Scale
        public Mat toBinaryScale(Mat image)
        {
            Mat thresImage = new Mat();

            //Cv2.Threshold(원본, 결과, 임계값, 최댓값, ThresholdTypes);
            //임계값은 100일 경우 100을 기준으로 100보다 이하면 0으로 100보다 이상이면 최댓값으로 변경합니다.
            Cv2.Threshold(image, thresImage, 100, 255, ThresholdTypes.Binary);
            return thresImage;
        }
    }
}
