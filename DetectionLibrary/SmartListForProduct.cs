using KassenmanagementLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetectionLibrary
{
	internal class SmartListForProduct : SmartListBase<Product>
	{

		public Product? GetResultProduct(int mindestErkennungsAnzahl = 3)
		{
			Product result = null;
			Dictionary<Product, int> counter = new Dictionary<Product, int>();
			if (LastResults != null || LastResults.Count() > 9)
			{
				foreach (Product p in this.LastResults)
				{
					if (counter.ContainsKey(p))
						counter[p]++;
					else
						counter[p] = 1;
				}

				var filteredResults = counter.Where(x => x.Value >= mindestErkennungsAnzahl).ToList();

				if (filteredResults.Any())
				{
					// Sort by count and return the product with the highest count
					return filteredResults.OrderByDescending(x => x.Value).First().Key;
				}
				else
				{
					// Return null = handle the absence of products meeting the threshold
					return null;
				}
			}
			return result;





			int count = 0;

			//Den kompletten nächsten Teil als LINQ Ausdruck zusammenführen
				if (LastResults.Count < 10)
				{
					return null;
				}
				// erstellen des Dictionary
				foreach (Product detectedproduct in LastResults)
				{
					counter.Add(detectedproduct, 0);
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

			
		}
	}
}
