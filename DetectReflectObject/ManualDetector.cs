using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;
using System.IO;

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

        // toBinaryScale 1 param
        // cannyEdge 2 param
        // in_path 경로의 이미지들을 읽어서 반사객체 검출한 이미지를 out_path에 저장
        public void Run(string in_path, string out_path)
        {
            string[] inputFiles = Directory.GetFiles(in_path);
            foreach(string image_dir in inputFiles)
            {
                string file_name = Path.GetFileName(image_dir);
                // 이미지 불러오기
                Mat image = Cv2.ImRead(image_dir);

                // image이 1채널이 아닌 경우 전처리 작업 진행
                if(image.Channels() != 1)
                {
                    image = ManualDetector.shared.toGrayScale(image);
                    image = ManualDetector.shared.toBinaryScale(image, 100);
                    if (image.Channels() != 1)
                    {
                        throw new Exception("이미지 전처리 작업 실패");
                    }
                }

                // canny edge 이미지 이진화
                image = cannyEdge(image, 100, 1000);

                // 외곽선 검출
                List<Point[]> contours = getContours(image, RetrievalModes.Tree, ContourApproximationModes.ApproxTC89KCOS, 500, 0.02);

                // ** 후처리 작업 - 외곽선 내부를 흰색으로 채움 **
                foreach (OpenCvSharp.Point[] contour in contours)
                {
                    image.FillConvexPoly(contour, Scalar.White, LineTypes.AntiAlias);
                }

                // 이미지 저장
                string out_imgPath = out_path + "\\" + file_name;
                Cv2.ImWrite(out_imgPath, image);
            }

        }

        // ----------------------------------------------------------
        // 1. RGB값을 Gray Scale로 변환
        public Mat toGrayScale(Mat image)
        {
            Mat grayImage = new Mat();
            Console.WriteLine("test");
            Console.WriteLine("channel before convert : " + image.Channels());
            Cv2.CvtColor(image, grayImage, ColorConversionCodes.BGR2GRAY);
            Console.WriteLine("channel after convert : " + grayImage.Channels());
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

        // 3. Canny Edge 이진화
        // - Cv2.Canny(원본, 결과, threshold1, threshold2, 소벨 연산 마스크 크기, L2 그래디언트)
        // - threshold1 : 다른 엣지와의 인접 부분(엣지가 되기 쉬운 부분)에 있어 엣지인지 아닌지를 판단하는 임계값
        // - threshold2 : 엣지인지 아닌지를 판단하는 임계값
        public Mat cannyEdge(Mat image, int thresh1, int thresh2)
        {
            Mat cannyImage = new Mat();
            Cv2.Canny(image, cannyImage, thresh1, thresh2, 3, true);
            return cannyImage;
        }

        // 4. 외곽선 검출
        public List<Point[]> getContours(Mat image, RetrievalModes retrieval, ContourApproximationModes modes, int lengthNoise, double approxRate)
        {
            Point[][] contours;
            HierarchyIndex[] hierarchy;

            // 외곽선 검출
            Cv2.FindContours(image, out contours, out hierarchy, retrieval, modes);

            // 외곽선 필터링
            List<Point[]> new_contours = new List<Point[]>();
            foreach (Point[] p in contours)
            {
                new_contours.Add(p);
                //double length = Cv2.ArcLength(p, true);
                //if (length > lengthNoise) // 윤곽선 길이 lengthNoise 이하는 무시
                //{
                    
                //    // 추출한 외곽선 근사화 (근사치 정확도 : 전체 길이의 x%, 하이퍼파라미터)
                //    //Point[] new_points = Cv2.ApproxPolyDP(p, length * approxRate, true);
                //    //new_contours.Add(new_points);
                //    //if (new_points.Length == 4) // 코너가 4개인 것만 외곽선에 추가
                //    //{
                //    //    new_contours.Add(new_points);
                //    //}
                //}
            }
            return new_contours;
        }
    }
}
