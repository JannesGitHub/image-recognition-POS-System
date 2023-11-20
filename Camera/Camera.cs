using System.Drawing;
using Accord.Video;
using Accord.Video.DirectShow;
using Accord.Imaging;

namespace program
{
    class program
    {
        static void Main()
        {
            // Erstelle eine Instanz deiner Kamera
            Camera camera = new Camera();

            // Rufe GetCurrentFrame auf
            Bitmap frame = camera.GetCurrentFrame();

            // Überprüfe, ob ein Bild empfangen wurde
            if (frame != null)
            {
                // Speichere das Bild oder zeige es an, wie du möchtest
                frame.Save("captured_frame.jpg");
                Console.WriteLine("Bild erfolgreich gespeichert.");
            }
            else
            {
                Console.WriteLine("Fehler beim Empfangen des Bildes.");
            }
        }
    }
}

public interface ICamera
{
    Bitmap GetCurrentFrame();
}

public class Camera : ICamera
{
    private FilterInfoCollection videoDevices;
    private VideoCaptureDevice Webcam;

    public Camera()
    {
        this.videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
        this.Webcam = new VideoCaptureDevice(videoDevices[0].MonikerString);
    }

    public Bitmap GetCurrentFrame()
    {
        Webcam.Start();

        Bitmap currentFrame = new Bitmap(0,0);
        using (var g = Graphics.FromImage(currentFrame))
        {
            g.CopyFromScreen(0, 0, 0, 0, currentFrame.Size);
        }

        Webcam.SignalToStop();
        Webcam.WaitForStop();

        return currentFrame;
    }
}