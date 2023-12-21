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
        // wird das überhaupt gespeichert ?? bei einer statischen klasse eigentlich nicht möglich?
        private SmartListForProduct LastProducts = new SmartListForProduct();
        private SmartListForProbabilityDictionary LastProbabilites = new DetectionLibrary.SmartListForProbabilityDictionary();

        public (SortedDictionary<double, Product>, Product?) getDetectionOutput(LineOfGoods sortiment, Bitmap frame)
        {
            double minimumProbability = 0.8;

			//erstellt ein Dictionary mit der nähesten Distanz für jede ProduktvectorListe
			Dictionary<double, Product> dictOfClosestDistances = new Dictionary<double, Product>();
            foreach(Product p in sortiment.lineOfGoods)
            {         
                dictOfClosestDistances.Add(DetectionMathLib.SmallestValueOf(ZeroShot.GetCLIPVector(frame).CompareTo(p.Allproductvectors)),p);
            }
            SortedDictionary<double, Product> dictOfProbabilities = DetectionMathLib.Softmax(dictOfClosestDistances);
            LastProbabilites.Add(dictOfProbabilities);
            //Speichert die letzten 10 Ergbnisse um davon dann die Produkterkennung abhängig zu machen
            if(dictOfProbabilities.Last().Key > minimumProbability)
            {
                LastProducts.Add(dictOfProbabilities.Last().Value);
            }
            // Problem: resultDict ist nur basierend auf dem letzten Frame
            return (LastProbabilites.GetResultProbabilityDictionary(), LastProducts.GetResultProduct());
		}

		public static CLIPVector GetCLIPVector(Bitmap frame)
		{
			return ZeroShot.GetCLIPVector(frame);
		}
	}
}