﻿using System;
using System.Drawing;
using Accord.Video;
using Accord.Video.DirectShow;

namespace Camera
{
    public class Cam : ICamera
    {
        private VideoCaptureDevice videoSource;
        private Bitmap currentBitmap;

        public event EventHandler NewFrame;

        public Cam()
        {
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

        public void VideoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            if (eventArgs.Frame != null)
            {
                currentBitmap = (Bitmap)eventArgs.Frame.Clone(); //geschützten Thread einbauen

                NewFrame?.Invoke(this, eventArgs);
            }
        }

        public Bitmap GetCurrentBitmap()
        {
            return currentBitmap;
        }
    }
}