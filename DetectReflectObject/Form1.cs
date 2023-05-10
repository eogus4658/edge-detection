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
        int canny_thresh2 = 100;

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
                Mat contourImage = Cv2.ImRead(image_dir);
                Cv2.DrawContours(contourImage, contours, -1, new Scalar(0, 0, 255), 30, LineTypes.AntiAlias, null, 1);

                contourLabel.Text = String.Format("contourCount = {0}", contours.Count);
                pictureBoxImage.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(contourImage);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
