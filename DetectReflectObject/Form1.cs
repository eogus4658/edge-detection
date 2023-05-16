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
            this.binaryTB.Text = ManualDetector.shared.GetBinaryParam().ToString();
            this.canny1TB.Text = ManualDetector.shared.GetCanny1Param().ToString();
            this.canny2TB.Text = ManualDetector.shared.GetCanny2Param().ToString();
            this.noiselenTB.Text = ManualDetector.shared.GetNoiseLength().ToString();
            this.approxRateTB.Text = ManualDetector.shared.GetApproxRate().ToString();
            this.gaussianTB.Text = ManualDetector.shared.GetGaussianSigma().ToString();
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
                Mat image = Cv2.ImRead(image_dir);
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
                int binaryParam = int.Parse(this.binaryTB.Text);
                Mat binaryImage = ManualDetector.shared.toBinaryScale(image, binaryParam); // image, thresh
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
                // set param
                ManualDetector.shared.SetBinaryParameter(double.Parse(this.binaryTB.Text));
                ManualDetector.shared.SetCannyParameter(int.Parse(this.canny1TB.Text), int.Parse(this.canny2TB.Text));
                ManualDetector.shared.SetContourParameter(int.Parse(this.noiselenTB.Text), double.Parse(this.approxRateTB.Text));
                ManualDetector.shared.SetGaussianSigma(int.Parse(this.gaussianTB.Text));

                int contourCount;
                Mat image = Cv2.ImRead(image_dir);
                (contourCount, image) = ManualDetector.shared.testRun(image, gaussianCheck.Checked);
                contourLabel.Text = String.Format("contourCount = {0}", contourCount);
                pictureBoxImage.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(image);
                statusLabel.Text = "finished";
            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        void FileRun()
        {
            statusLabel.Text = "running...";
            string in_path = "C:\\TrueProj.2023\\공간영상 수동반사객체 구현업무\\반사투과 객체 검출 소프트웨어_ETRI_2022년결과\\test\\input";
            string out_path = "C:\\TrueProj.2023\\공간영상 수동반사객체 구현업무\\반사투과 객체 검출 소프트웨어_ETRI_2022년결과\\test\\output";
            try
            {
                // set param
                ManualDetector.shared.SetBinaryParameter(double.Parse(this.binaryTB.Text));
                ManualDetector.shared.SetCannyParameter(int.Parse(this.canny1TB.Text), int.Parse(this.canny2TB.Text));
                ManualDetector.shared.SetContourParameter(int.Parse(this.noiselenTB.Text), double.Parse(this.approxRateTB.Text));
                ManualDetector.shared.SetGaussianSigma(int.Parse(this.gaussianTB.Text));

                ManualDetector.shared.Run(in_path, out_path, this.gaussianCheck.Checked);
                statusLabel.Text = "finished";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void batchRunButton_Click(object sender, EventArgs e)
        {
            FileRun();
        }
    }
}
