using KassenmanagementLibrary;
using System.Collections.Generic;
using System.Drawing;
using System.Linq.Expressions;
using DetectionLibrary;

namespace DetectionLibrary
{
    public static class Detection //: IDetection
    {
        // Sortiment bei Objekterstellung übergeben
        // potentiell Detection als Statische Klasse einführen


        public static (SortedDictionary<double, Product>, Product?) getDetectionOutput(LineOfGoods sortiment, List<Bitmap> frames)
        {
            double minimumProbability = 0.75;
            double SofmaxFactor = 6.0;

            List<Product?> lastProducts = new List<Product?>();
            List<SortedDictionary<double, Product>> lastProbabilites = new List<SortedDictionary<double, Product>>();

            foreach (Bitmap frame in frames)
            {
                //erstellt ein Dictionary mit der nähesten Distanz für jede ProduktvectorListe
                Dictionary<double, Product> dictOfClosestDistances = new Dictionary<double, Product>();
                foreach (Product p in sortiment.lineOfGoods)
                {
                    dictOfClosestDistances.Add(DetectionMathLib.SmallestValueOf(ZeroShot.GetCLIPVector(frame).CompareTo(p.Allproductvectors)), p);
                }
                SortedDictionary<double, Product> dictOfProbabilities = DetectionMathLib.Softmax(dictOfClosestDistances, SofmaxFactor);
                lastProbabilites.Add(dictOfProbabilities);
                if (dictOfProbabilities.Last().Key > minimumProbability)
                {
                    lastProducts.Add(dictOfProbabilities.Last().Value);
                }
            }

            return (DetectionMathLib.Average(lastProbabilites), DetectionMathLib.MostLikelyProduct(lastProducts));
        }

        public static CLIPVector GetCLIPVector(Bitmap frame)
        {
            return ZeroShot.GetCLIPVector(frame);
        }
    }
}