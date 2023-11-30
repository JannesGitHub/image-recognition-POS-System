using KassenmanagementLibrary;
using System.Drawing;

namespace DetectionLibrary
{
    public class Detection : IDetection
    {
        private Bitmap testBitmap
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
        public (Dictionary<Product, double>, Product?) getValuedLineOfGoods(LineOfGoods sortiment, Bitmap frame)
        {
            Dictionary<Product, double> vlgdict = new Dictionary<Product, double>();
            foreach (Product p in sortiment.lineOfGoods)
            {
                List<double> similarityList = ZeroShot.GetCLIPVector(frame).CompareTo(p.Allproductvectors);
                vlgdict.Add(p, DummyCompare(similarityList));
            }
            foreach(KeyValuePair<Product,double> d in vlgdict)
            {
                if (d.Value > 10000000) //hier müsste man herrausfinden, ab welchem double Wert wir triggern wollen,
                                        //dazu müsste man sich die resultirenden Werte eratmal anscheun.
                {
                    continue;
                }
            }
            return (vlgdict, null);
        }

        public double DummyCompare(List<double> list) // returnt einfach den durchschnitt der distanzen zwischen dem live vector und dern Product vectoren
        {
            double averager = 0;
            foreach(double d in list)
            {
                averager += d;
            }
            return averager / list.Count;
        }

        public Product LastProduct { get; private set; }
        //Frage zu LineOfGoods und ValuedLineOfGoods, wo soll ich die Eigenschaften zuweisen im Getter oder im setter? 
        //eigentlich im Getter und den setter einfach weglassen/privat stellen?


    }
}