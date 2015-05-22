using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace VessellDetection
{
    class Filters
    {
        private Image<Gray,Byte> img  = null;
        public int enbüyükx = 0;
        public int enbüyüky = 0;
        private Image<Gray, Byte> cannyimg = null;
        public Bitmap GrayScaleChannel(Bitmap image)
        {
            img = new Image<Gray, Byte>((image));
            return img.ToBitmap();
        }
        public Bitmap MatchedFilter3x3(Bitmap image)
        {
            //img = new Image<Gray, Byte>(image);
            Bitmap b = image;
          
            int width = b.Width;
            int height = b.Height;
            Bitmap n = new Bitmap(width, height);

            int[,] R = new int[width, height];
            int[,] G = new int[width, height];
            int[,] B = new int[width, height];

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    R[i, j] = b.GetPixel(i, j).R;
                    G[i, j] = b.GetPixel(i, j).G;
                    B[i, j] = b.GetPixel(i, j).B;
                }
            }

            for (int i = 1; i < b.Width - 1; i++)
            {
                for (int j = 1; j < b.Height - 1; j++)
                {
                    int red = ((R[i - 1, j - 1] * 1 + R[i - 1, j] * 4 + R[i - 1, j + 1] * 1 +
                                R[i, j - 1] * 4 + R[i, j] * 7 + R[i, j + 1] * 4 +
                                R[i + 1, j - 1] * 1 + R[i + 1, j] * 4 + R[i + 1, j + 1] * 1) / 27);

                    int green = ((G[i - 1, j - 1] * 1 + G[i - 1, j] * 4 + G[i - 1, j + 1] * 1 +
                                 G[i, j - 1] * 4 + G[i, j] * 7 + G[i, j + 1] * 4 +
                                 G[i + 1, j - 1] * 1 + G[i + 1, j] * 4 + G[i + 1, j + 1] * 1) / 27);

                    int blue = ((B[i - 1, j - 1] * 1 + B[i - 1, j] * 4 + B[i - 1, j + 1] * 1 +
                                 B[i, j - 1] * 4 + B[i, j] * 7 + B[i, j + 1] * 4 +
                                 B[i + 1, j - 1] * 1 + B[i + 1, j] * 4 + B[i + 1, j + 1] * 1) / 27);
                    n.SetPixel(i, j, Color.FromArgb(red, green, blue));
                }
            }
             return n;
        }
        public Bitmap Canny(Bitmap image)
        {
            Image<Gray, Byte> cannyimg = new Image<Gray, Byte>(image);
           // cannyimg = cannyimg.Canny(10, 19);
           cannyimg = cannyimg.Canny(13, 45);
            return cannyimg.ToBitmap();
        }
        public Bitmap Maskeleme(Bitmap cannyresim, Bitmap maskBitmap) // index imagecollectionlarda doğru maskeyi bulmamız  için kullanıyoruz
        {
            Image<Gray, Byte> mask = new Image<Gray, byte>(maskBitmap);
            Bitmap b = cannyresim;
            int width = b.Width;
            int height = b.Height;
            Bitmap maskb = mask.ToBitmap();
            Bitmap bit = cannyresim;
            Image<Bgr, Byte> bitresimmm = new Image<Bgr, byte>(bit);
            bit = bitresimmm.ToBitmap();

            for (int i = 6; i < width - 6; i++)
            {
                for (int j = 6; j < height - 6; j++)
                {
                    if (maskb.GetPixel(i, j).R <= Color.Black.R && (maskb.GetPixel(i + 5, j + 5).R == Color.White.R ||
                        maskb.GetPixel(i - 3, j - 3).R == Color.White.R))
                    {
                        for (int k = -6; k <= 6; k++)
                        {
                            bit.SetPixel(i + k, j - 6, Color.Black);
                            bit.SetPixel(i + k, j - 5, Color.Black);
                            bit.SetPixel(i + k, j - 4, Color.Black);
                            bit.SetPixel(i + k, j - 3, Color.Black);
                            bit.SetPixel(i + k, j - 2, Color.Black);
                            bit.SetPixel(i + k, j - 1, Color.Black);
                            bit.SetPixel(i + k, j,     Color.Black);
                            bit.SetPixel(i + k, j + 1, Color.Black);
                            bit.SetPixel(i + k, j + 2, Color.Black);
                            bit.SetPixel(i + k, j + 3, Color.Black);
                            bit.SetPixel(i + k, j + 4, Color.Black);
                            bit.SetPixel(i + k, j + 5, Color.Black);
                            bit.SetPixel(i + k, j + 6, Color.Black);


                        }
                    }
                }
            }
            cannyimg = new Image<Gray, byte>(bit);
            return cannyimg.ToBitmap();
        }
        public Point enParlak(Bitmap resim)
        {
            int width = resim.Width;
            int height = resim.Height;
            Bitmap n = new Bitmap(width, height);
            n = resim;


            int[,] allPixR = new int[width, height];
            int[,] allPixG = new int[width, height];
            int[,] allPixB = new int[width, height];
            int parlak = 0;
            int enparlak = 0;
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    allPixR[i, j] = n.GetPixel(i, j).R;
                    allPixG[i, j] = n.GetPixel(i, j).G;
                    allPixB[i, j] = n.GetPixel(i, j).B;
                }
            }
            Color color = Color.FromArgb(255, 255, 255);
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    parlak = (allPixR[i, j] * 299) + (allPixG[i, j] * 587) + (allPixB[i, j] * 114) / 1000;
                    //toplam = parlak + toplam;
                    if (parlak > enparlak)
                    {
                        enbüyükx = i;
                        enbüyüky = j;
                        enparlak = parlak;
                        //MessageBox.Show("+");
                    }
                }
            }

            Point nokta  = new Point(enbüyükx ,enbüyüky);
            return nokta;
        }
        public Bitmap OptikDiskRoi(Bitmap resultBitmap)
        {
            Image<Bgr, Byte> img = new Image<Bgr, Byte>(resultBitmap);
            Point nokta = enParlak(img.ToBitmap());
            Image<Gray, Byte> img2 = new Image<Gray, Byte>(img.ToBitmap());
            img2.ROI = new Rectangle(enbüyükx - 70, enbüyüky - 50, 140, 100);
            return img2.ToBitmap();
        }
        public Bitmap OptikDiskKmeans(Bitmap resultBitmap)
        {
            Image<Gray, Byte> img2 = new Image<Gray, Byte>(resultBitmap);
            Image<Bgr, float> src = new Image<Bgr, float>(resultBitmap);
            Matrix<float> samples = new Matrix<float>(src.Rows * src.Cols, 1, 3);
            Matrix<int> finalClusters = new Matrix<int>(src.Rows * src.Cols, 1);

            for (int y = 0; y < src.Rows; y++)
            {
                for (int x = 0; x < src.Cols; x++)
                {
                    samples.Data[y + x * src.Rows, 0] = (float)src[y, x].Blue;
                    samples.Data[y + x * src.Rows, 1] = (float)src[y, x].Green;
                    samples.Data[y + x * src.Rows, 2] = (float)src[y, x].Red;
                }
            }

            MCvTermCriteria term = new MCvTermCriteria(10000, 0.0001);
            term.type = TERMCRIT.CV_TERMCRIT_ITER | TERMCRIT.CV_TERMCRIT_EPS;

            int clusterCount = 3;
            int attempts = 5;
            Matrix<Single> centers = new Matrix<Single>(clusterCount, samples.Cols, 3);
            CvInvoke.cvKMeans2(samples, clusterCount, finalClusters, term, attempts, IntPtr.Zero, KMeansInitType.PPCenters, centers, IntPtr.Zero);

            Image<Bgr, Byte> new_image = new Image<Bgr, Byte>(src.Size);

            for (int y = 0; y < src.Rows; y++)
            {
                for (int x = 0; x < src.Cols; x++)
                {
                    int cluster_idx = finalClusters[y + x * src.Rows, 0];
                    MCvScalar sca1 = CvInvoke.cvGet2D(centers, cluster_idx, 0);
                    Bgr color2 = new Bgr(sca1.v0, sca1.v1, sca1.v2);

                    PointF p = new PointF(x, y);
                    new_image.Draw(new CircleF(p, 1.0f), color2, 1);
                }
            }
            CvInvoke.cvShowImage("clustered image", new_image);
            CvInvoke.cvShowImage("clustered image2", img2);
            CvInvoke.cvWaitKey(0);
            CvInvoke.cvKMeans2(samples, clusterCount, finalClusters, term, attempts, IntPtr.Zero, KMeansInitType.PPCenters, centers, IntPtr.Zero);
            return new_image.ToBitmap();
        }
        public Bitmap OptikDisk(Bitmap originalBitmap)
        {
            Image< Bgr, Byte> img = new Image<Bgr, Byte>(originalBitmap);
            //enbüyükx = enParlak(img.ToBitmap()).X;
            //enbüyüky = enParlak(img.ToBitmap()).Y;
            int width = img.Width;
            int height = img.Height;
            Bitmap n = new Bitmap(width, height);
            n = img.ToBitmap();


            int[,] allPixR = new int[width, height];
            int[,] allPixG = new int[width, height];
            int[,] allPixB = new int[width, height];
            int parlak = 0;
            int enparlak = 0;
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    allPixR[i, j] = n.GetPixel(i, j).R;
                    allPixG[i, j] = n.GetPixel(i, j).G;
                    allPixB[i, j] = n.GetPixel(i, j).B;
                }
            }
            Color color = Color.FromArgb(255, 255, 255);
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    parlak = (allPixR[i, j] * 299) + (allPixG[i, j] * 587) + (allPixB[i, j] * 114) / 1000;

                    if (parlak > enparlak)
                    {
                        enbüyükx = i;
                        enbüyüky = j;
                        enparlak = parlak;

                    }
                }

            }
            Image<Gray, Byte> img2 = new Image<Gray, Byte>(img.ToBitmap());
     
            Image<Gray, Byte> img3 = new Image<Gray, Byte>(img.ToBitmap());
            Point center = new Point(enbüyükx,enbüyüky);

            img2.ROI = new Rectangle(enbüyükx - 70, enbüyüky - 50, 140, 100);
          //img2.ROI = new Rectangle(enbüyükx - 85, enbüyüky - 50, 130, 100);
            //////////// roi yapılmış img2
            //////////////////////////////////////////////////////////////
            /////// ///////kmeans/////////////////////////////////////////  
            
            Image<Bgr, float> src = new Image<Bgr, float>(img2.ToBitmap());
            Matrix<float> samples = new Matrix<float>(src.Rows * src.Cols, 1, 3);
            Matrix<int> finalClusters = new Matrix<int>(src.Rows * src.Cols, 1);

            for (int y = 0; y < src.Rows; y++)
            {
                for (int x = 0; x < src.Cols; x++)
                {
                    samples.Data[y + x * src.Rows, 0] = (float)src[y, x].Blue;
                    samples.Data[y + x * src.Rows, 1] = (float)src[y, x].Green;
                    samples.Data[y + x * src.Rows, 2] = (float)src[y, x].Red;
                }
            }

            MCvTermCriteria term = new MCvTermCriteria(10000, 0.0001);
            term.type = TERMCRIT.CV_TERMCRIT_ITER | TERMCRIT.CV_TERMCRIT_EPS;

            int clusterCount = 3;
            int attempts = 5;
            Matrix<Single> centers = new Matrix<Single>(clusterCount, samples.Cols, 3);
            CvInvoke.cvKMeans2(samples, clusterCount, finalClusters, term, attempts, IntPtr.Zero, KMeansInitType.PPCenters, centers, IntPtr.Zero);
            
            Image<Bgr, Byte> new_image = new Image<Bgr, Byte>(src.Size);
            
            for (int y = 0; y < src.Rows; y++)
            {
                for (int x = 0; x < src.Cols; x++)
                {
                    int cluster_idx = finalClusters[y + x * src.Rows, 0];
                    MCvScalar sca1 = CvInvoke.cvGet2D(centers, cluster_idx, 0);
                    Bgr color2 = new Bgr(sca1.v0, sca1.v1, sca1.v2);
 
                    PointF p = new PointF(x, y);
                    new_image.Draw(new CircleF(p, 1.0f), color2, 1);
                }
            }
            CvInvoke.cvShowImage("clustered image", new_image);
            CvInvoke.cvShowImage("clustered image2", img2);

            CvInvoke.cvWaitKey(0);
     

            CvInvoke.cvKMeans2(samples, clusterCount, finalClusters, term, attempts, IntPtr.Zero, KMeansInitType.PPCenters, centers, IntPtr.Zero);
          ///////////////
            Bitmap damar = new_image.ToBitmap();
            int deneme = 0;
            int gecici = 0;
            int[,] allPixRr = new int[damar.Width, damar.Height];
            int[,] allPixGr = new int[damar.Width, damar.Height];
            int[,] allPixBr = new int[damar.Width, damar.Height];

            for (int i = 0; i < damar.Width; i++)
            {
                for (int j = 0; j < damar.Height; j++)
                {
                    allPixRr[i, j] = damar.GetPixel(i, j).R;
                    allPixGr[i, j] = damar.GetPixel(i, j).G;
                    allPixBr[i, j] = damar.GetPixel(i, j).B;
                }
            }
            int[] renkdizi = { 1, 2, 3 };
            int kontrol = 0;
            int sayi = 0;
            for (int i = 0; i < damar.Width; i++)
            {
                for (int j = 0; j < damar.Height - 1; j++)
                {
                    deneme = (allPixRr[i, j] * 299) + (allPixGr[i, j] * 587) + (allPixBr[i, j] * 114) / 1000;
                    //MessageBox.Show(deneme.ToString());
                    gecici = (allPixRr[i, j + 1] * 299) + (allPixGr[i, j + 1] * 587) + (allPixBr[i, j + 1] * 114) / 1000;
                    //toplam = parlak + toplam;
                    //listBox1.Items.Add(gecici);
                    if (deneme != gecici)
                    {
                        for (int k = 0; k < 3; k++)
                        {
                            if (renkdizi[k] == gecici)
                            {
                                kontrol = 1;
                            }
                        }
                        if (kontrol == 0)
                        {
                            renkdizi[sayi] = gecici;
                            sayi++;
                        }
                        kontrol = 0;
                    }
                }

            }
            
            for (int i = 0; i < damar.Width; i++)
            {
                for (int j = 0; j < damar.Height; j++)
                {
                    deneme = (allPixRr[i, j] * 299) + (allPixGr[i, j] * 587) + (allPixBr[i, j] * 114) / 1000;
                    if (deneme == renkdizi[0])
                    {
                        damar.SetPixel(i, j, Color.White);
                    }
                    else if (deneme == renkdizi[1])
                    {
                        damar.SetPixel(i, j, Color.Black);
                    }
                    else if (deneme == renkdizi[2])
                    {
                        damar.SetPixel(i, j, Color.Black);
                    }
                }
            }

            Image<Bgr, float> resim = new Image<Bgr, float>(damar);
            CvInvoke.cvShowImage("cluddsstered image", resim);
    
           // return new_image.ToBitmap() ;
          return resim.ToBitmap();
        }
    }
}
