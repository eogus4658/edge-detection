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
                Mat cannyImage = ManualDetector.shared.cannyEdge(image);
                List<OpenCvSharp.Point[]> contours = ManualDetector.shared.getContours(cannyImage);
                Mat contourImage = Cv2.ImRead(image_dir);
                Cv2.DrawContours(contourImage, contours, -1, new Scalar(0, 0, 255), 30, LineTypes.AntiAlias, null, 1);

                pictureBoxImage.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(contourImage);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
