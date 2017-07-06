using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.IO;
using System.Drawing;

using Emgu;
using Emgu.CV;
using Emgu.Util;
using Emgu.CV.Structure;

namespace CMesMesures
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void btnOpenPicture_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();

                openFileDialog.Title = "Open Image";
                openFileDialog.Filter = "Image File|*.bmp; *.gif; *.jpg; *.jpeg; *.png;";

                if (openFileDialog.ShowDialog() == true)
                {
                    string pathFile = openFileDialog.FileName;
                    txtNamePicture.Text = pathFile;

                    Image<Bgr, byte> imf = new Image<Bgr, byte>(pathFile);

                    // CvInvoke.Imshow("Image", imf);
                    System.Drawing.Image imgTest;
                    imgTest = imf.ToBitmap();
                    var bi = new BitmapImage();

                    using (var ms = new MemoryStream())
                    {
                        imgTest.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                        ms.Position = 0;
                        bi.BeginInit();
                        bi.CacheOption = BitmapCacheOption.OnLoad;
                        bi.StreamSource = ms;
                        bi.EndInit();
                    }

                    imageBox.Source = bi;
                    imgTest.Dispose();
                    
                    
                    // CvInvoke.WaitKey(0);

                    // imgPicture.Source = new BitmapImage(new Uri(pathFile));
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
