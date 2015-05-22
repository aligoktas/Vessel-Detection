using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VessellDetection
{
    public partial class Performance : Form
    {
    
        
        public Performance()
        {
            InitializeComponent();
        }

        private void Performance_Load(object sender, EventArgs e)
        {  

            try
            {
                MessageBox.Show("Manual  Görüntüleri Yükleyiniz.");
                MyFolderDialog.ShowDialog();
                string[] fileEntries = Directory.GetFiles(MyFolderDialog.SelectedPath, "*.gif"); // seçilenn klasördeki tif dosyalarını çek dicez buray
                if (fileEntries.Length > 0)
                {
                    foreach (string file in fileEntries)
                    {
                        imageCollectionTest.Images.Add(AForge.Imaging.Image.FromFile(file));
                       
                    }
                }
              

                int resimindex= Form1.index;
          
                Bitmap bizimki = Form1.resultBitmap;
                Bitmap orjinal = (Bitmap)imageCollectionTest.Images[resimindex];
                pictureBox1.Image = bizimki;
                pictureBox2.Image = orjinal;
            
                  int bizimbeyazsayimiz = 0;
                  int orjinalbeyazsayisi = 0;
                  int kesisenbeyazsayisi = 0;
                  int kesismeyenbeyazsayisi = 0;
            for (int i = 0; i < bizimki.Width; i++)
            {
                for (int j = 0; j < bizimki.Height; j++)
                {
                    /////bizimdamarlarımız
                    if (bizimki.GetPixel(i, j).R.Equals(Color.White.R) &&
                        bizimki.GetPixel(i, j).G.Equals(Color.White.G) &&
                        bizimki.GetPixel(i, j).B.Equals(Color.White.B))
                    {
                        bizimbeyazsayimiz++;
                    }
                    //////orjinaldamarlar
                    if (orjinal.GetPixel(i, j).R.Equals(Color.White.R) &&
                        orjinal.GetPixel(i, j).G.Equals(Color.White.G) &&
                        orjinal.GetPixel(i, j).B.Equals(Color.White.B))
                    {
                        orjinalbeyazsayisi++;
                    }
                    //////kesisendamarlar
                    if (bizimki.GetPixel(i, j).G.Equals(orjinal.GetPixel(i, j).G) &&
                        bizimki.GetPixel(i, j).B.Equals(orjinal.GetPixel(i, j).B) &&
                        bizimki.GetPixel(i, j).R.Equals(orjinal.GetPixel(i, j).R) &&
                        orjinal.GetPixel(i, j).R.Equals(Color.White.R) &&
                        orjinal.GetPixel(i, j).G.Equals(Color.White.G) &&
                        orjinal.GetPixel(i, j).B.Equals(Color.White.B)
                        )
                    {
                        kesisenbeyazsayisi++;
                    }
                    else
                    {
                        kesismeyenbeyazsayisi++;
                    }
                }
            }
           
            double precision, recall, accuracy;
            double fp = bizimbeyazsayimiz - kesisenbeyazsayisi;
            double fn = orjinalbeyazsayisi - kesisenbeyazsayisi;
            double tn = kesismeyenbeyazsayisi - fp - fn;
            double tp = kesisenbeyazsayisi;
            accuracy = ((tp + tn) / (tp + tn + fp + fn)) * 100;
            recall = (tp / (tp + fn)) * 100;
            precision = (tp / (tp + fp)) * 100;
            recall = (kesisenbeyazsayisi / Convert.ToDouble(orjinalbeyazsayisi)) * 100;
            precision = (kesisenbeyazsayisi / Convert.ToDouble(bizimbeyazsayimiz)) * 100;
           
            this.chart1.Titles.Add("Performans Ölçümü");

            chart1.ChartAreas[0].AxisY.Maximum = 100;
            chart1.Series["recall"].Points.AddXY("sonuç", recall);
            chart1.Series["precision"].Points.AddXY("sonuç", precision);
            chart1.Series["accurary"].Points.AddXY("sonuç", accuracy);

            }
            catch (Exception xx)
            {

                MessageBox.Show(xx.Message);
            }
           
         
            double[] recallHepsi = { 80.12, 81.65, 71.91, 76.48, 73.93, 72.29, 78.39, 69.29, 74.48, 73.25,
                                79.09, 76.09, 73.92, 79.45, 81.81, 77.61, 71.63, 71.81, 75.62, 72.60 };
            double[] precisionHepsi = {38.17, 43.92, 45.86, 42.83, 51.96, 49.39, 43.03, 43.64, 48.79, 42.66, 
                                  36.05, 38.19, 39.30, 38.47, 32.50, 41.70, 39.94, 35.97, 36.90, 38.54};
            double gecici = 0;

            Dictionary<double,double> dictionary = new Dictionary<double, double>();//recall lar key precision value
           
            dictionary.Add(80.12, 38.17);
            dictionary.Add(81.65, 43.92);
            dictionary.Add(71.91, 45.86);
            dictionary.Add(76.48, 42.83);
            dictionary.Add(73.93, 51.96);
            dictionary.Add(72.29, 49.39);
            dictionary.Add(78.39, 43.03);
            dictionary.Add(69.29, 43.64);
            dictionary.Add(74.48, 48.79);
            dictionary.Add(73.25, 42.66);
            dictionary.Add(79.09, 36.05);
            dictionary.Add(76.09, 38.19);
            dictionary.Add(73.92, 39.30);
            dictionary.Add(79.45, 38.47);
            dictionary.Add(81.81, 32.50);
            dictionary.Add(77.61, 41.70);
            dictionary.Add(71.63, 39.94);
            dictionary.Add(71.81, 35.97);
            dictionary.Add(75.62, 36.90);
            dictionary.Add(72.60, 38.54);

            //sıralama küçükten büyüğe grafikte göstermek için 
            for (int i = 0; i < recallHepsi.Length; i++)
			 {
			  for (int j = i+1; j < recallHepsi.Length; j++)
			  {
			    if (recallHepsi[j]<recallHepsi[i])
	            {
                   gecici         = recallHepsi[i];
                   recallHepsi[i] = recallHepsi[j];
                   recallHepsi[j] = gecici; 
	            }
			   }
			}

            //sıralama küçükten büyüğe grafikte göstermek için 
            for (int i = 0; i < precisionHepsi.Length; i++)
            {
                for (int j = i + 1; j < precisionHepsi.Length; j++)
                {
                    if (precisionHepsi[j] < precisionHepsi[i])
                    {
                        gecici = precisionHepsi[i];
                        precisionHepsi[i] = precisionHepsi[j];
                        precisionHepsi[j] = gecici;
                    }
                }
            }


            chart2.Titles.Add("Performans Ölçüm Sonuçları");
            chart2.ChartAreas[0].AxisY.Maximum = 100;
            chart2.ChartAreas[0].AxisY.Interval = 10;
            chart2.ChartAreas[0].AxisX.Interval = 1;
            chart2.Series["Precision - Recall"].BorderWidth = 3;

            chart2.Series["Precision - Recall"].Points.AddXY(recallHepsi[0], dictionary[recallHepsi[0]]);
            chart2.Series["Precision - Recall"].Points.AddXY(recallHepsi[1], dictionary[recallHepsi[1]]);
            chart2.Series["Precision - Recall"].Points.AddXY(recallHepsi[2], dictionary[recallHepsi[2]]);
            chart2.Series["Precision - Recall"].Points.AddXY(recallHepsi[3], dictionary[recallHepsi[3]]);
            chart2.Series["Precision - Recall"].Points.AddXY(recallHepsi[4], dictionary[recallHepsi[4]]);
            chart2.Series["Precision - Recall"].Points.AddXY(recallHepsi[5], dictionary[recallHepsi[5]]);
            chart2.Series["Precision - Recall"].Points.AddXY(recallHepsi[6], dictionary[recallHepsi[6]]);
            chart2.Series["Precision - Recall"].Points.AddXY(recallHepsi[7], dictionary[recallHepsi[7]]);
            chart2.Series["Precision - Recall"].Points.AddXY(recallHepsi[8], dictionary[recallHepsi[8]]);
            chart2.Series["Precision - Recall"].Points.AddXY(recallHepsi[9], dictionary[recallHepsi[9]]);
            chart2.Series["Precision - Recall"].Points.AddXY(recallHepsi[10], dictionary[recallHepsi[10]]);
            chart2.Series["Precision - Recall"].Points.AddXY(recallHepsi[11], dictionary[recallHepsi[11]]);
            chart2.Series["Precision - Recall"].Points.AddXY(recallHepsi[12], dictionary[recallHepsi[12]]);
            chart2.Series["Precision - Recall"].Points.AddXY(recallHepsi[13], dictionary[recallHepsi[13]]);
            chart2.Series["Precision - Recall"].Points.AddXY(recallHepsi[14], dictionary[recallHepsi[14]]);
            chart2.Series["Precision - Recall"].Points.AddXY(recallHepsi[15], dictionary[recallHepsi[15]]);
            chart2.Series["Precision - Recall"].Points.AddXY(recallHepsi[16], dictionary[recallHepsi[16]]);
            chart2.Series["Precision - Recall"].Points.AddXY(recallHepsi[17], dictionary[recallHepsi[17]]);
            chart2.Series["Precision - Recall"].Points.AddXY(recallHepsi[18], dictionary[recallHepsi[18]]);
            chart2.Series["Precision - Recall"].Points.AddXY(recallHepsi[19], dictionary[recallHepsi[19]]);

 
      
        }
    }
}
