using KassenmanagementLibrary;
using System.Collections.Generic;
using System.Drawing;
using System.Linq.Expressions;
using DetectionLibrary;

namespace DetectionLibrary
{
    public class Detection : IDetection
    {
        public (SortedDictionary<double, Product>, Product?) getDetectionOutput(LineOfGoods sortiment, List<Bitmap> frames)
        {
            //mindest Warscheinlichkeit, dass ein Produkt als erkannt zählt
            double minimumProbability = 0.75;
            //zusätzlicher Faktor der Softmax Funktion
            double SofmaxFactor = 6.0;
            //Wie oft muss ein Produkt in den übergebenen Frames erkannt werden, damit es auch final als Erkannt gilt
            int WieOftMussEinProduktErkanntWerden = 3;

            List<Product?> lastProducts = new List<Product?>();
            List<SortedDictionary<double, Product>> lastProbabilites = new List<SortedDictionary<double, Product>>();

            foreach (Bitmap frame in frames)
            {
                #region erstellt ein Dictionary mit der nähesten Distanz für jede ProduktVectorListe
                //das Kamera-Frame wird in einen Clip-Vector übersetzt und dann wird die Distanz mit den Produkctvectoren Verglichen
                //hierbei speichere ich aus der Liste von Distanzen die aus jeder Produkt-Vector-Liste resultiert, den Wert mit der kürzesten distanz ab.
                Dictionary<double, Product> dictOfClosestDistances = new Dictionary<double, Product>();
                foreach (Product p in sortiment.lineOfGoods)
                {
                    dictOfClosestDistances.Add(DetectionMathLib.SmallestValueOf(ZeroShot.GetCLIPVector(frame).CompareTo(p.Allproductvectors)), p);
                }
                #endregion
                #region wandelt das closest Distance Dictionary in ein Dictionary mit Warscheinlichkeiten um
                SortedDictionary<double, Product> dictOfProbabilities = DetectionMathLib.Softmax(dictOfClosestDistances, SofmaxFactor);
                #endregion
                #region speichert die Probability Dictionarys für jedes Camera-Frame in einer Liste 
                lastProbabilites.Add(dictOfProbabilities);
				#endregion
				#region speichern des erkannten Produktes
				//Wenn ein Produkt aus unserem Sortiment die mindestwarscheinlichkeit übersteigt
				//wird es in einer Liste
				if (dictOfProbabilities.Last().Key > minimumProbability)
                {
                    lastProducts.Add(dictOfProbabilities.Last().Value);
                }
				#endregion
			}
            // gibt den Durschnittswert, der zuletzt abgespeicherten Dictionarys zurück und das warscheinlichste Produkt
			return (DetectionMathLib.Average(lastProbabilites), DetectionMathLib.MostLikelyProduct(lastProducts, WieOftMussEinProduktErkanntWerden));
            // Average nur danne rzeugen, wenn a
        }

        public CLIPVector GetCLIPVector(Bitmap frame)
        {
            return ZeroShot.GetCLIPVector(frame);
        }
    }
}