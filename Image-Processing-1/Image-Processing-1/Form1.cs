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
using OpenCvSharp.Extensions;

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

        public void compare()
        {
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

            compare();
        }

        private void shapesOfGrayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MyFilter
            OpenFileDialog dialog1 = new OpenFileDialog();
            dialog1.Filter = "Image files|*.png;*.jpg;*.bmp|All filec(*.*)|*.*";
            if (dialog1.ShowDialog() == DialogResult.OK)
            {
                image1 = new Bitmap(dialog1.FileName);
                pictureBox1.Image = image1;
                //pictureBox1.Width = image1.Width;
                pictureBox2.Hide();
                pictureBox1.Refresh();
            }
            else { return; }

            Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
            {
                Color sourceColor = sourceImage.GetPixel(x, y);
                int intensity = (int)(0.2952 * sourceColor.R + 0.5547 * sourceColor.G + 0.148 * sourceColor.B);
                Color resultColor = Color.FromArgb(intensity, intensity, intensity);
                return resultColor;
            }

            Bitmap resultImage = new Bitmap(image1.Width, image1.Height);
            for (int i = 0; i < image1.Width; i++)
            {
                for (int j = 0; j < image1.Height; j++)
                {
                    resultImage.SetPixel(i, j, calculateNewPixelColor(image1, i, j));
                }
            }
            pictureBox1.Image = resultImage;
            pictureBox1.Refresh();

            //OpenCV Filter
            Mat sourceImg = Cv2.ImRead(dialog1.FileName);
            Mat grayImg = new Mat();
            Cv2.CvtColor(sourceImg, grayImg, ColorConversionCodes.BGR2GRAY);

            image2 = new Bitmap(grayImg.ToBitmap());
            pictureBox2.Image = image2;
            pictureBox2.Show();
            pictureBox2.Refresh();

            //if (dialog1.ShowDialog() == DialogResult.OK)
            //{
            //    Mat sourceImg = Cv2.ImRead(dialog1.FileName);
            //    Mat grayImg = new Mat();
            //    Cv2.CvtColor(sourceImg, grayImg, ColorConversionCodes.BGR2GRAY);

            //    image2 = new Bitmap(grayImg.ToBitmap());
            //    pictureBox2.Image = image2;
            //    pictureBox2.Show();
            //    pictureBox2.Refresh();
            //}


        }

        public class HSV
        {
            public double h;
            public double s;
            public double v;

            public HSV()
            {
                h = 0;
                s = 0;
                v = 0;
            }
        }


        public HSV[,] RGBtoHSV(Bitmap image)
        {
            HSV[,] hsv = new HSV[image.Width, image.Height];
            for (int i = 0; i < image.Width; i++)
                for (int j = 0; j < image.Height; j++)
                    hsv[i, j] = new HSV();


            for (int i = 0; i < image.Width; i++)
                for (int j = 0; j < image.Height; j++)
                {
                    double r = image1.GetPixel(i, j).R;
                    double g = image1.GetPixel(i, j).G;
                    double b = image1.GetPixel(i, j).B;

                    hsv[i, j].h = image.GetPixel(i, j).GetHue();
                    double max = Math.Max(r, Math.Max(g, b)) / 255;
                    double min = Math.Min(r, Math.Min(g, b)) / 255;
                    hsv[i, j].v = max;




                    if (max == 0)
                        hsv[i, j].s = 0;
                    else
                        hsv[i, j].s = (max - min) / max
                            ;
                }
            return hsv;
        }

        public Bitmap HSVtoRGB(HSV[,] hsv)
        {
            Bitmap image = new Bitmap(hsv.GetLength(0), hsv.GetLength(1));

            for (int i = 0; i < hsv.GetLength(0); i++)
                for (int j = 0; j < hsv.GetLength(1); j++)
                {
                    double r = 0, g = 0, b = 0;

                    if (hsv[i, j].s == 0)
                    {
                        r = hsv[i, j].v;
                        g = hsv[i, j].v;
                        b = hsv[i, j].v;
                    }
                    else
                    {
                        int sw;
                        double f, p, q, t;

                        if (hsv[i, j].h == 360)
                            hsv[i, j].h = 0;
                        else
                            hsv[i, j].h = hsv[i, j].h / 60;

                        sw = (int)Math.Truncate(hsv[i, j].h);
                        f = hsv[i, j].h - sw;

                        p = hsv[i, j].v * (1.0 - hsv[i, j].s);
                        q = hsv[i, j].v * (1.0 - (hsv[i, j].s * f));
                        t = hsv[i, j].v * (1.0 - (hsv[i, j].s * (1.0 - f)));

                        switch (sw)
                        {
                            case 0:
                                r = hsv[i, j].v;
                                g = t;
                                b = p;
                                break;

                            case 1:
                                r = q;
                                g = hsv[i, j].v;
                                b = p;
                                break;

                            case 2:
                                r = p;
                                g = hsv[i, j].v;
                                b = t;
                                break;

                            case 3:
                                r = p;
                                g = q;
                                b = hsv[i, j].v;
                                break;

                            case 4:
                                r = t;
                                g = p;
                                b = hsv[i, j].v;
                                break;

                            default:
                                r = hsv[i, j].v;
                                g = p;
                                b = q;
                                break;
                        }

                    }
                    Color color = Color.FromArgb((byte)(r * 255), (byte)(g * 255), (byte)(b * 255));
                    image.SetPixel(i, j, color);
                }
            return image;
        }
      

        private void convertationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog1 = new OpenFileDialog();
            dialog1.Filter = "Image files|*.png;*.jpg;*.bmp|All filec(*.*)|*.*";
            if (dialog1.ShowDialog() == DialogResult.OK)
            {
                image1 = new Bitmap(dialog1.FileName);
                pictureBox1.Image = image1;
                pictureBox1.Refresh();
            }
            else { return; }

            pictureBox1.Image = HSVtoRGB(RGBtoHSV(image1));

            // Convertation in OpenCV



            // ^^^^^^Convertation in OpenCV^^^^^^
        }

        int Clamp(int i)
        {
            if (i < 0) return 0;
            if (i > 255) return 255;
            return i;
        }

        private void brightnessIncreaseToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog dialog1 = new OpenFileDialog();
            dialog1.Filter = "Image files|*.png;*.jpg;*.bmp|All filec(*.*)|*.*";
            if (dialog1.ShowDialog() == DialogResult.OK)
            {
                image1 = new Bitmap(dialog1.FileName);
                pictureBox1.Image = image1;
                pictureBox1.Refresh();
            }
            else { return; }

            HSV[,] hsv = RGBtoHSV(image1);
            var watch1 = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 0; i < image1.Width; i++)
                for (int j = 0; j < image1.Height; j++)
                {
                    int r = (int)(image1.GetPixel(i, j).R * 1.25 * 128 / 100);
                    int g = (int)(image1.GetPixel(i, j).G * 1.25 * 128 / 100);
                    int b = (int)(image1.GetPixel(i, j).B * 1.25 * 128 / 100);

                    image1.SetPixel(i, j, Color.FromArgb(Clamp(r), Clamp(g), Clamp(b)));
                }
            pictureBox1.Image = image1;
            watch1.Stop();
            var elapsedMs1 = watch1.ElapsedMilliseconds;


            image2 = new Bitmap(image1.Width, image1.Height);
            var watch2 = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 0; i < image2.Width; i++)
                for (int j = 0; j < image2.Height; j++)
                {
                    hsv[i, j].v *= 1.6;
                    hsv[i, j].v = hsv[i, j].v > 1 ? 1 : hsv[i, j].v;
                    hsv[i, j].v = hsv[i, j].v < 0 ? 0 : hsv[i, j].v;
                }
            watch2.Stop();
            var elapsedMs2 = watch2.ElapsedMilliseconds;
            


            image2 = HSVtoRGB(hsv);
            pictureBox2.Image = image2;
            MessageBox.Show("Brightness increase execution time in RGB: " + elapsedMs1 + " ms.\nBrightness increase execution time in HVS: " + elapsedMs2 + " ms.");
            compare();
        }
    }
}
