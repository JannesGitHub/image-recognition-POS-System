using System;
using System.Drawing;
using Accord.Video;
using Accord.Video.DirectShow;

namespace Camera
{
    public class Camera : ICamera
    {
        private VideoCaptureDevice videoSource;
        private Bitmap currentBitmap;

        public Camera()
        {
            // Initialisiere die Kamera
            FilterInfoCollection videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (videoDevices.Count > 0)
            {
                videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
                videoSource.NewFrame += VideoSource_NewFrame;
                videoSource.Start();
            }
            else
            {
                Console.WriteLine("Keine Kamera gefunden.");
            }
        }

        private void VideoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            // Überprüfe, ob das Frame-Objekt nicht null ist
            if (eventArgs.Frame != null)
            {
                // Aktualisiere das aktuelle Bitmap bei jedem neuen Frame
                currentBitmap = (Bitmap)eventArgs.Frame.Clone();
            }
        }

        public Bitmap GetCurrentBitmap()
        {
            return currentBitmap;
        }

        public void StopCapture()
        {
            // Stoppe die Kameraaufnahme
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
                videoSource.WaitForStop();
            }
        }
    }
}