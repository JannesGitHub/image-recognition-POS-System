/*using KassenmanagementLibrary;
using System.Drawing;

namespace DetectionLibrary
{
    public class Detection : IDetection
    {
        /private Bitmap testBitmap
        {
            get
            {
                //Testbild aus meinem Verzeichnis Lesen
                Image pictureApple = Image.FromFile("C://Users/cansc/OneDrive/Desktop/HTW/Progammierprojekt/Apfel.jpg");
                return (Bitmap)pictureApple;
            }
        }
        private Dictionary<Product, double> ValuedLineOfGoods;       
        private LineOfGoods LineOfGoods { get; set; }
        public Detection(LineOfGoods lineOfGoods)
        {
            LineOfGoods = lineOfGoods;
        }
        public (Dictionary<Product, double>, Product?) getDetectionOutput()
        {
            throw new NotImplementedException();
        }

        public Product LastProduct { get; private set; }
        //Frage zu LineOfGoods und ValuedLineOfGoods, wo soll ich die Eigenschaften zuweisen im Getter oder im setter? 
        //eigentlich im Getter und den setter einfach weglassen/privat stellen?


    }
}*/