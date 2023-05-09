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
                Mat binaryImage = ManualDetector.shared.toBinaryScale(image);
                pictureBoxImage.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(binaryImage);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
