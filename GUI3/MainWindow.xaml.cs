using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using KassenmanagementLibrary;
using System.Windows;
using System.Windows.Media.Imaging;
using Camera;
using System.Timers;
using DetectionLibrary;
using System.Windows.Media.Media3D;
using System.Drawing;
using System.Windows.Input;
using System.Threading.Tasks;

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            camera = new Cam();

            camera.NewFrame += OnNewFrame;
        }

        private Cam camera;

        private Bitmap currentBitmap;

        private Timer timer;

        ///////////////////////////////////////////////////////BILDDARSTELLUNG///////////////////////////////////////////////////////////
       
        public virtual void OnNewFrame(object sender, EventArgs e)
        {
            if (camera != null)
            {
                Bitmap bitmap = camera.GetCurrentBitmap();

                currentBitmap = bitmap; //speichern in lokaler Variable
                if (bitmap != null)
                {
                    // Führe die Anzeigeoperation auf dem UI-Thread aus
                    Dispatcher.Invoke(() => ShowBitmap(bitmap));
                }
            }
        }
        
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            // Übertrage und zeige das aktuelle Bitmap
            if (camera != null)
            {
                Bitmap bitmap = camera.GetCurrentBitmap();

                currentBitmap = bitmap; //speichern in lokaler Variable
                if (bitmap != null)
                {
                    // Führe die Anzeigeoperation auf dem UI-Thread aus
                    Dispatcher.Invoke(() => ShowBitmap(bitmap));
                }
            }
        }

        private void ShowBitmap(Bitmap bitmap)
        {
            // Konvertiere das Bitmap in ein BitmapImage und zeige es in der GUI an
            BitmapImage bitmapImage = BmpImageFromBmp(bitmap);
            anzeigeBild.Source = bitmapImage;
        }

        private BitmapImage BmpImageFromBmp(Bitmap bmp) //Aus Forum: Transformiert Bitmap in GUI nutzbares BitmapSource
        {
            using (var memory = new System.IO.MemoryStream())
            {
                bmp.Save(memory, System.Drawing.Imaging.ImageFormat.Png);
                memory.Position = 0;

                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                bitmapImage.Freeze();

                return bitmapImage;
            }
        }
    }
}
