using AForge.Imaging;
using AForge.Imaging.Filters;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VessellDetection
{
    public partial class Form1 : Form
    {
        public int LoginKontrol = 0;
        public Bitmap backup = null;

        int kontrol = 0;
        public Bitmap bmpLoaded = null;
        public Bitmap histBitmap = null;
        //matrix for Grey level 
        public static byte[,] Grey;
        public static byte[,] GreyTmp;
        public int[, ,] H3D;
        public byte[,] R;
        public byte[,] G;
        public byte[,] B;


        int[] EMaxPos = new int[8];



        public int[,] HiGrey = new int[2, 256];

        public double[] HiGreyN = new double[256];
        public double[] EiGrey = new double[256];

        /// <summary>
        /// ///////////////////////////////////////////////////7
        /// </summary>
        public Bitmap orginalBitmap = null;
        public Bitmap GeciciBitmap = null;
        public static Bitmap resultBitmap = null;
        private Bitmap maskBitmap = null;



        public static int index = 0;
        Filters Filtreler = new Filters();



        public Form1()
        {
            InitializeComponent();

            menuStrip1.Items[1].Visible = false; // this works
            menuStrip1.Items[2].Visible = false; // this works
            menuStrip1.Items[3].Visible = false; // this works
            menuStrip1.Items[4].Visible = false; // this works
          
          
  


        }
        private void görüntüYükleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyFolderDialog.ShowDialog();
            string[] fileEntries = Directory.GetFiles(MyFolderDialog.SelectedPath, "*.tif"); // seçilenn klasördeki tif dosyalarını çek dicez buray
            if (fileEntries.Length > 0)
            {
                foreach (string file in fileEntries)
                {
                    imageCollection1.Images.Add(AForge.Imaging.Image.FromFile(file));
                    imageCollection2.Images.Add(AForge.Imaging.Image.FromFile(file));
                    imageCollection3.Images.Add(AForge.Imaging.Image.FromFile(file));
                }

                for (int i = 0; i < imageCollection1.Images.Count; i++)
                {
                    ImageComboBoxItem someItem = new ImageComboBoxItem();
                    someItem.Description = (i + 1).ToString();
                    someItem.ImageIndex = i;
                    someItem.Value = i;
                    imageComboBoxEdit1.Properties.Items.Add(someItem);
                }
            }
            MessageBox.Show("Mask  Resimleri Yükleyiniz.");
            MyFolderDialog.ShowDialog();
            string[] MaskfileEntries = Directory.GetFiles(MyFolderDialog.SelectedPath, "*.gif"); // seçilenn klasördeki tif dosyalarını çek dicez buray
            if (MaskfileEntries.Length > 0)
            {
                foreach (string file in MaskfileEntries)
                {
                    imageCollection1Mask.Images.Add(AForge.Imaging.Image.FromFile(file)); //mask resimler imagecollectiona eklenir

                }

            }

            imageComboBoxEdit1.SelectedIndex = 0; // imagecombobox a varsayılan olarak ilk resmi atasın

        }

        private void görüntüKaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (resultBitmap != null)
            {
                index = index + 1; // doğru kaydetmek için 1 artırıyoruz imagecollectionlara kaydederken 0 dan başladığı için.
                resultBitmap.Save(@"C:\Users\Ali\Desktop\Retina Sonuçlar\" + index + "_output.tif");
                index = index - 1; // tekrar aynı resmi kaydederse farklı isimli kaydetmesin diye 1 azaltıyoruz
                resultBitmap = null;
            }
            MessageBox.Show("Resim Kaydedildi.");
        }

        private void optikDiskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap kmeansOptikDisk = new Bitmap(Filtreler.OptikDisk(orginalBitmap));

            Image<Bgr, Byte> img = new Image<Bgr, byte>(kmeansOptikDisk);
            Image<Gray, Byte> gray = img.Convert<Gray, Byte>().PyrDown().PyrUp();
            Image<Gray, Byte> cannyEdges = gray.Canny(50, 80).Not();

            Bitmap color;
            Bitmap bgray;
            IdentifyContours(cannyEdges.Bitmap, 50, true, out bgray, out color);
            CvInvoke.cvShowImage("Contour image", new Image<Gray, byte>(cannyEdges.ToBitmap()));




            Image<Bgra, Byte> image1 = new Image<Bgra, byte>(resultBitmap);// orjinal resmi image1 e atıyoruz
            Image<Bgra, Byte> image2 = new Image<Bgra, byte>(kmeansOptikDisk);// kmeans yapılmış optik diski image ye atıyoruz 

            resultBitmap = Overlay(image1, image2).ToBitmap(); // image2 yi image1 in optik disk kısmına ekliyoruz

            pictureBox1.Image = resultBitmap;
        }


        private void radioButtonMatchedFilter3x3_CheckedChanged(object sender, EventArgs e)
        {


            //   resultBitmap = Filtreler.GreenChannel(orginalBitmap);
            //  resultBitmap = Filtreler.GrayScaleChannel(orginalBitmap);
            resultBitmap = Filtreler.MatchedFilter3x3(orginalBitmap);
            resultBitmap = Filtreler.Canny(resultBitmap);


            //maskBitmap = (Bitmap)imageCollection1Mask.Images[index];// combobox ta seçilmiş image in mask image ini getiriyor
            //resultBitmap = Filtreler.Maskeleme(resultBitmap, maskBitmap);

            // radioButtonMatchedFilter3x3.Checked = false;
            pictureBox1.Image = resultBitmap; //Filtreler.MatchedFilter3x3(resultBitmap);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            // resultBitmap = Filtreler.GrayScaleChannel(orginalBitmap);
            Bitmap kmeansOptikDisk = new Bitmap(Filtreler.OptikDisk(resultBitmap));

            Image<Bgr, Byte> img = new Image<Bgr, byte>(kmeansOptikDisk);
            Image<Gray, Byte> gray = img.Convert<Gray, Byte>().PyrDown().PyrUp();
            Image<Gray, Byte> cannyEdges = gray.Canny(50, 80).Not();

            Bitmap color;
            Bitmap bgray;
            IdentifyContours(cannyEdges.Bitmap, 50, true, out bgray, out color);
            CvInvoke.cvShowImage("Contour image", new Image<Gray, byte>(cannyEdges.ToBitmap()));




            Image<Bgra, Byte> image1 = new Image<Bgra, byte>(Filtreler.GrayScaleChannel(orginalBitmap));// orjinal resmi image1 e atıyoruz
            Image<Bgra, Byte> image2 = new Image<Bgra, byte>(kmeansOptikDisk);// kmeans yapılmış optik diski image ye atıyoruz 

            resultBitmap = Overlay(image1, image2).ToBitmap(); // image2 yi image1 in optik disk kısmına ekliyoruz

            pictureBox1.Image = resultBitmap;

        }

        private void ımageComboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ImageComboBoxEdit editor = sender as ImageComboBoxEdit;
            index = editor.SelectedIndex;
            orginalBitmap = (Bitmap)imageCollection3.Images[index];
            GeciciBitmap = (Bitmap)imageCollection3.Images[index];
            pictureBox1.Image = imageCollection3.Images[index];
            resultBitmap = orginalBitmap;
        }

        public Image<Bgra, Byte> Overlay(Image<Bgra, Byte> image1, Image<Bgra, Byte> image2)
        {
            Image<Bgra, Byte> result = image1.Copy();
            Image<Bgra, Byte> src = image2;
            Image<Bgra, Byte> dst = image1;
            int rows = result.Rows;
            int cols = result.Cols;
            int eny = Filtreler.enbüyüky - 60;
            int enx = Filtreler.enbüyükx - 60;

            for (int y = 0; y < 100; ++y)
            {
                for (int x = 0; x < 130; ++x)
                {

                    double srcA = 1.0 / 255 * src.Data[y, x, 3];
                    double dstA = 1.0 / 255 * dst.Data[y, x, 3];
                    double outA = (srcA + (dstA - dstA * srcA));

                    result.Data[eny, enx, 0] = (Byte)(((src.Data[y, x, 0] * srcA) + (dst.Data[y, x, 0] * (1 - srcA))) / outA);  // Blue
                    result.Data[eny, enx, 1] = (Byte)(((src.Data[y, x, 1] * srcA) + (dst.Data[y, x, 1] * (1 - srcA))) / outA);  // Green
                    result.Data[eny, enx, 2] = (Byte)(((src.Data[y, x, 2] * srcA) + (dst.Data[y, x, 2] * (1 - srcA))) / outA);  // Red
                    result.Data[eny, enx, 3] = (Byte)(outA * 255);

                    enx++;
                    if (enx == Filtreler.enbüyükx + 85)
                    {
                        enx = Filtreler.enbüyükx - 85;
                        break;
                    }

                }
                eny++;
                if (eny == Filtreler.enbüyüky + 50)
                {

                    break;
                }
            }
            return result;
        }
        public void IdentifyContours(Bitmap colorImage, int thresholdValue, bool invert, out Bitmap processedGray, out Bitmap processedColor)
        {
            Image<Gray, byte> grayImage = new Image<Gray, byte>(colorImage);
            Image<Bgr, byte> color = new Image<Bgr, byte>(colorImage);

            grayImage = grayImage.ThresholdBinary(new Gray(thresholdValue), new Gray(255));

            if (invert)
            {
                grayImage._Not();
            }

            using (MemStorage storage = new MemStorage())
            {
                Contour<Point> contours;
                for (contours = grayImage.FindContours(Emgu.CV.CvEnum.CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_NONE, Emgu.CV.CvEnum.RETR_TYPE.CV_RETR_LIST, storage); contours != null; contours = contours.HNext)
                {

                    Contour<Point> currentContour = contours.ApproxPoly(contours.Perimeter * 0.015, storage);
                    CvInvoke.cvDrawContours(color, contours, new MCvScalar(255),
                                                                new MCvScalar(255), -1, 1,
                                                                Emgu.CV.CvEnum.LINE_TYPE.EIGHT_CONNECTED,
                                                                new Point(0, 0));
                    color.Draw(currentContour.BoundingRectangle, new Bgr(0, 255, 0), 1);

                    Point[] pts = currentContour.ToArray();

                    // rect = CvInvoke.cvMinAreaRect2(contours, storage);
                    foreach (Point p in pts)
                    {

                        // listBox1.Items.Add(p);

                    }
                }
            }

            processedColor = color.ToBitmap();
            processedGray = grayImage.ToBitmap();

        }
        private void ApplyFilter(IFilter filter)
        {
            try
            {
                // set wait cursor
                this.Cursor = Cursors.WaitCursor;

                // apply filter to the image
                Bitmap newImage = filter.Apply(resultBitmap);


                resultBitmap = newImage;
                pictureBox1.Image = resultBitmap;
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Bu Görüntüye Seçilen Filtre Uygulanamaz", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // restore cursor
                this.Cursor = Cursors.Default;
            }
        }
        private void ApplyFilter(IFilter filter, Bitmap image)
        {
            try
            {
                // set wait cursor
                this.Cursor = Cursors.WaitCursor;

                // apply filter to the image
                Bitmap newImage = filter.Apply(image);


                image = newImage;

            }
            catch (ArgumentException)
            {
                MessageBox.Show("Bu Görüntüye Seçilen Filtre Uygulanamaz", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // restore cursor
                this.Cursor = Cursors.Default;
            }
        }
        private void greenChannelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplyFilter(new ExtractChannel(RGB.G));
        }
        private void contrastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Contrast();
        }
        private void Contrast()
        {
            if (orginalBitmap.PixelFormat != PixelFormat.Format24bppRgb)
            {
                MessageBox.Show("Contrast filter using HSL color space is available for color images only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            ContrastCorrection filter = new ContrastCorrection();

            filter.Factor = 15;
            ApplyFilter(filter);
        }
        private void gaussianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GaussianBlur filter = new GaussianBlur();
         //   GaussianSharpen filter = new GaussianSharpen();
            filter.Size = 5;
            filter.Sigma = 0.6;

            ApplyFilter(filter);
        }
        private void sharpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplyFilter(new Sharpen());
        }
        private void cannyEdgeDedectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            resultBitmap = Filtreler.Canny(resultBitmap);
         
            maskBitmap = (Bitmap)imageCollection1Mask.Images[index];// combobox ta seçilmiş image in mask image ini getiriyor
            resultBitmap = Filtreler.Maskeleme(resultBitmap, maskBitmap);
            pictureBox1.Image = resultBitmap;
           // CannyEdgeDetector filter = new CannyEdgeDetector();
           // filter.GaussianSigma = 2.1;
           // filter.LowThreshold = 10;
           // filter.HighThreshold = 19;

           //ApplyFilter(filter);
      
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            kontrol = 1;
            //Bitmap a = new Bitmap(pictureBox1.Image);
            //textBox2.Text = "red : " + a.GetPixel(100, 168).R.ToString()+" green : " + a.GetPixel(100, 168).G.ToString()+ 
            //                                                               "blue : " + a.GetPixel(100, 168).B.ToString();
        }

        private void pROGRAMCIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuStrip1.Items[1].Visible = true; // dosya işlemleri
            menuStrip1.Items[2].Visible = false; // dosya işlemleri
            menuStrip1.Items[3].Visible = true; // görüntü işleme
            menuStrip1.Items[4].Visible = true; // performans

        }
        private void dOKTORToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuStrip1.Items[1].Visible = true; // dosya işlemleri
            menuStrip1.Items[2].Visible = true; //görüntü işle
            menuStrip1.Items[3].Visible = false; //görüntü işleme
            menuStrip1.Items[4].Visible = true; // performans
        }

        private void connectedCompenetAnalysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // create filter
            ConnectedComponentsLabeling filter = new ConnectedComponentsLabeling();
            // apply the filter
            ApplyFilter(filter);

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            Bitmap roiImage = Filtreler.OptikDiskRoi(resultBitmap);

            ApplyFilter(new Sharpen(), roiImage);
            Image<Bgr, Byte> img = new Image<Bgr, byte>(roiImage);
            CvInvoke.cvShowImage("clustered image", img);
            GaussianBlur filter = new GaussianBlur();
            filter.Size = 5;
            filter.Sigma = 0.6;
            ApplyFilter(filter, roiImage);

            Bitmap kmeansImage = Filtreler.OptikDiskKmeans(roiImage);


            pictureBox1.Image = resultBitmap;


        }

        private void otsuThresholdingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OtsuThreshold filter = new OtsuThreshold();
            ApplyFilter(filter);
        }

        private void dİlateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dilatation filter = new Dilatation();
            ApplyFilter(filter);
        }

        private void erosionAşındırmaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Erosion filter = new Erosion();
            ApplyFilter(filter);

        }

        private void performansÖlçümüToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // aa();
            Performance performanceForm = new Performance();
            performanceForm.Show();



        }

        private void matchedFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            resultBitmap = Filtreler.MatchedFilter3x3(resultBitmap);
            pictureBox1.Image = resultBitmap;
        }

        private void damarBulToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplyFilter(new ExtractChannel(RGB.G));
            if (orginalBitmap.PixelFormat != PixelFormat.Format24bppRgb)
            {
                MessageBox.Show("Contrast filter using HSL color space is available for color images only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            ContrastCorrection filter = new ContrastCorrection();

            filter.Factor = 15;
            ApplyFilter(filter);

            GaussianBlur filter2 = new GaussianBlur();
            //   GaussianSharpen filter = new GaussianSharpen();
            filter2.Size = 5;
            filter2.Sigma = 0.6;

            ApplyFilter(filter2);


            resultBitmap = Filtreler.Canny(resultBitmap);

            maskBitmap = (Bitmap)imageCollection1Mask.Images[index];// combobox ta seçilmiş image in mask image ini getiriyor
            
            resultBitmap = Filtreler.Maskeleme(resultBitmap, maskBitmap);
           
            Dilatation filter3 = new Dilatation();
            ApplyFilter(filter3);

            pictureBox1.Image = resultBitmap;

        }
        private void button1_Click_2(object sender, EventArgs e)
        {
            // create the filter

            Bitmap result = resultBitmap.Clone(new Rectangle(0, 0, resultBitmap.Width, resultBitmap.Height),
                                        PixelFormat.Format32bppRgb);
            Bitmap mask = resultBitmap.Clone(new Rectangle(0, 0, maskBitmap.Width, maskBitmap.Height),
                                      PixelFormat.Format32bppRgb);
            MaskedFilter maskedFilter = new MaskedFilter(new Sepia(), mask);
            // apply the filter
            maskedFilter.ApplyInPlace(result);
            pictureBox1.Image = result;
        }
      }
}



       