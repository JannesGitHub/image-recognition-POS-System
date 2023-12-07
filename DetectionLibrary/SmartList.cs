using KassenmanagementLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetectionLibrary
{
	internal class SmartList
	{
		List<Product> LastResults;
		double length = 10;
		public void Add (Product detectedproduct)
		{
			if(LastResults.Count > length)
			{
				LastResults.RemoveAt(0);
			}
			LastResults.Add(detectedproduct);
		}
		public Product? GetResultProduct(int mindestErkennungsAnzahl = 3)
		{
			Product result = null;
			int count = 0;
			if (LastResults == null | LastResults.Count < 10)
			{
				return null;
			}
			Dictionary<Product, int> counter = new Dictionary<Product, int>();
			// erstellen des Dictionary
			foreach (Product detectedproduct in LastResults)
			{
				counter.Add(detectedproduct,0);
			}
			// zählen der häufigkeit der Produkte
			foreach (Product detectedproduct in LastResults)
			{
				counter[detectedproduct] += 1;
			}
			// maxmale Anzahl finden
			foreach (Product detectedproduct in LastResults)
			{
				if (count < counter[detectedproduct])
					count = counter[detectedproduct];
			}
			// Produkt mit maximaler Anzahl speichern - Problem: wenn mehrere Produkte gleich oft erkannt werden, wird das ignoriert
			foreach (Product detectedproduct in LastResults)
			{
				if (count == counter[detectedproduct] && count >= mindestErkennungsAnzahl)
					result = detectedproduct;
			}
			return result;
		}

	}
}
