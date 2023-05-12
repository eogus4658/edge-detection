using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;

namespace DetectReflectObject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
        string image_dir = "";
        // Canny Edge Param
        int canny_thresh1 = 0;
        int canny_thresh2 = 1100;

        // FindContours Param
        RetrievalModes retrievalModes = RetrievalModes.Tree;
        ContourApproximationModes contour_approxModes = ContourApproximationModes.ApproxTC89KCOS;

        //ApproxPolyDP Param
        double approxRate = 0.02;

        // Noise Param
        int length = 500;

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                if(dlg.ShowDialog() == DialogResult.OK)
                {
                    image_dir = dlg.FileName;
                    Mat image = Cv2.ImRead(image_dir);

                    pictureBoxImage.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(image);
                }
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void grayButton_Click(object sender, EventArgs e)
        {
            try
            {
                Mat image = OpenCvSharp.Extensions.BitmapConverter.ToMat((Bitmap)pictureBoxImage.Image);
                Mat grayImage = ManualDetector.shared.toGrayScale(image);
                pictureBoxImage.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(grayImage);
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }   
        }

        private void binaryButton_Click(object sender, EventArgs e)
        {
            try
            {
                Mat image = OpenCvSharp.Extensions.BitmapConverter.ToMat((Bitmap)pictureBoxImage.Image);
                Mat binaryImage = ManualDetector.shared.toBinaryScale(image, 100); // image, thresh
                pictureBoxImage.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(binaryImage);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cannyButton_Click(object sender, EventArgs e)
        {
            try
            {
                Mat image = OpenCvSharp.Extensions.BitmapConverter.ToMat((Bitmap)pictureBoxImage.Image);
                Mat cannyImage = ManualDetector.shared.cannyEdge(image, canny_thresh1, canny_thresh2);
                pictureBoxImage.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(cannyImage);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void detectContourButton_Click(object sender, EventArgs e)
        {
            try
            {
                Mat image = OpenCvSharp.Extensions.BitmapConverter.ToMat((Bitmap)pictureBoxImage.Image);
                Mat cannyImage = ManualDetector.shared.cannyEdge(image, canny_thresh1, canny_thresh2);
                List<OpenCvSharp.Point[]> contours = ManualDetector.shared.getContours(cannyImage, retrievalModes, contour_approxModes, length, approxRate);
                // Cv2.DrawContours(contourImage, contours, -1, new Scalar(0, 0, 255), 30, LineTypes.AntiAlias, null, 1);
                foreach (OpenCvSharp.Point[] contour in contours)
                {
                    cannyImage.FillConvexPoly(contour, Scalar.White, LineTypes.AntiAlias);
                }
                
                contourLabel.Text = String.Format("contourCount = {0}", contours.Count);
                pictureBoxImage.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(cannyImage);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            statusLabel.Text = "running...";
            string in_path = "C:\\TrueProj.2023\\공간영상 수동반사객체 구현업무\\반사투과 객체 검출 소프트웨어_ETRI_2022년결과\\test\\input";
            string out_path = "C:\\TrueProj.2023\\공간영상 수동반사객체 구현업무\\반사투과 객체 검출 소프트웨어_ETRI_2022년결과\\test\\output";
            try
            {
                ManualDetector.shared.Run(in_path, out_path);
                statusLabel.Text = "finished";
            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
