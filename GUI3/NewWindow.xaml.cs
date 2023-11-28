using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using Camera;
using System.Timers;

namespace GUI
{
    /// <summary>
    /// Interaktionslogik für NewWindow.xaml
    /// </summary>
    public partial class NewWindow : Window
    {
        private Cam camera;
        private Timer timer;

        public NewWindow()
        {
            InitializeComponent();

            camera = new Cam();

            // Initialisiere den Timer mit einer Periodendauer von 30 ms
            timer = new Timer(100);
            timer.Elapsed += Timer_Elapsed;
            timer.AutoReset = true;

            // Starte den Timer
            timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            // Übertrage und zeige das aktuelle Bitmap
            if (camera != null)
            {
                Bitmap bitmap = camera.GetCurrentBitmap();
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
            testBild.Source = bitmapImage;
        }

        private BitmapImage BmpImageFromBmp(Bitmap bmp)
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
