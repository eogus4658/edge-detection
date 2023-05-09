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
        // thresh(임계값) 기준으로 이미지 이진화 진행
        public Mat toBinaryScale(Mat image, double thresh)
        {
            Mat thresImage = new Mat();

            //Cv2.Threshold(원본, 결과, 임계값, 최댓값, ThresholdTypes);
            //임계값은 100일 경우 100을 기준으로 100보다 이하면 0으로 100보다 이상이면 최댓값으로 변경합니다.
            Cv2.Threshold(image, thresImage, thresh, 255, ThresholdTypes.Binary);
            return thresImage;
        }

        public Mat cannyEdge(Mat image)
        {
            Mat cannyImage = new Mat();
            //Cv2.Canny(원본, 결과, 하위 임계값, 상위 임계값, 소벨 연산 마스크 크기, L2 그래디언트)
            // 픽셀이 상위 임계값보다 큰 기울기를 가지면 픽셀을 가장자리로 분류하고,
            // 하위 임계값보다 낮은 경우 가장자리로 고려하지 않는다.
            Cv2.Canny(image, cannyImage, 100, 500, 3, true);
            return cannyImage;
        }

        // 외곽선 검출
        public List<Point[]> getContours(Mat image)
        {
            Point[][] contours;
            HierarchyIndex[] hierarchy;

            Cv2.FindContours(image, out contours, out hierarchy, RetrievalModes.Tree, ContourApproximationModes.ApproxTC89KCOS);

            List<Point[]> new_contours = new List<Point[]>();
            foreach (Point[] p in contours)
            {
                double length = Cv2.ArcLength(p, true);
                if (length > 100) // 윤곽선 길이 100 이하는 무시
                {
                    new_contours.Add(p);
                }
            }
            return new_contours;
        }
    }
}
