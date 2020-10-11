using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Image_Processing_1
{
    public partial class Form1 : Form
    {
        Bitmap image1;
        Bitmap image2;
        public Form1()
        {
            InitializeComponent();
        }

        private void symilarityOfTwoImagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog1 = new OpenFileDialog();
            dialog1.Filter = "Image files|*.png;*.jpg;*.bmp|All filec(*.*)|*.*";
            if (dialog1.ShowDialog() == DialogResult.OK)
            {
                image1 = new Bitmap(dialog1.FileName);
                pictureBox1.Image = image1;
                pictureBox1.Width = 370;
                pictureBox1.Refresh();
            }
            else { return; }

            OpenFileDialog dialog2 = new OpenFileDialog();
            dialog2.Filter = "Image files|*.png;*.jpg;*.bmp|All filec(*.*)|*.*";
            if (dialog2.ShowDialog() == DialogResult.OK)
            {
                image2 = new Bitmap(dialog2.FileName);
                pictureBox2.Image = image2;
                pictureBox2.Show();
                pictureBox2.Refresh();
                
            }
            else { return; }

            if (image1.Width != image2.Width || image1.Height != image2.Height)
            {
                MessageBox.Show("Image are not the same size!");
                return;
            }

            double mseR = 0;
            double mseG = 0;
            double mseB = 0;

            for (int i = 0; i < image1.Width; i++)
                for (int j = 0; j < image1.Height; j++)
                {
                    mseR += Math.Pow(image1.GetPixel(i, j).R - image2.GetPixel(i, j).R, 2);
                    mseG += Math.Pow(image1.GetPixel(i, j).G - image2.GetPixel(i, j).G, 2);
                    mseB += Math.Pow(image1.GetPixel(i, j).B - image2.GetPixel(i, j).B, 2);
                }

            int countOfPixels = (image1.Width - 1) * (image1.Height - 1);
            mseR /= countOfPixels;
            mseG /= countOfPixels;
            mseB /= countOfPixels;

            double mse = mseR + mseG + mseB;
            MessageBox.Show("MSE is " + mse);
        }

        private void shapesOfGrayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog1 = new OpenFileDialog();
            dialog1.Filter = "Image files|*.png;*.jpg;*.bmp|All filec(*.*)|*.*";
            if (dialog1.ShowDialog() == DialogResult.OK)
            {
                image1 = new Bitmap(dialog1.FileName);
                pictureBox1.Image = image1;
                pictureBox1.Width = 760;
                pictureBox2.Hide();
                pictureBox1.Refresh();
            }
            else { return; }
        }
    }
}
