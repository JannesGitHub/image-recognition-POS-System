using KassenmanagementLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetectionLibrary
{
	internal static class DetectionMathLib
	{
		public static SortedDictionary<double, Product> Softmax(Dictionary<double, Product> list,double factor = 6)
		{
			double divider = 0;
			SortedDictionary<double, Product> result = new SortedDictionary<double, Product>();
			foreach (double d in list.Keys)
			{
				divider += Math.Pow(Math.E, factor * d * (-1));
			}
			foreach (KeyValuePair<double, Product> d in list)
			{
				result.Add(Math.Pow(Math.E, factor * d.Key * (-1)) / divider, d.Value);
			}
			return result;
		}
		public static double SmallestValueOf(List<double> list)
		{
			if (list.Count == 0) return 0;
			return list.Min();
		}

		public static bool IsInDict(Dictionary<Product, double> dict, Product prod)
		{
			bool solution = false;
			foreach (Product p in dict.Keys)
			{
				if (p.Name == prod.Name)
					solution = true;
			}
			return solution;
		}
		public static SortedDictionary<double, Product> Average(List<SortedDictionary<double, Product>> lastResults)
		{
			if (lastResults != null)
			{
				Dictionary<Product, double> solution = new Dictionary<Product, double>();
				//LINQ ausruck für Dictionary finden
				foreach (SortedDictionary<double, Product> d in lastResults)
				{
					foreach (KeyValuePair<double, Product> kvp in d)
					{
						double probability = kvp.Key;
						Product product = kvp.Value;

						if (DetectionMathLib.IsInDict(solution, product)) // evtl. auch für die eigene Classification Klasse geeignet
						{
							solution[product] += probability;
						}
						else
						{
							solution[product] = probability;
						}
					}
				}
				foreach (Product p in solution.Keys)
				{
					solution[p] = solution[p] / lastResults.Count();
				}
				// Tauscht Key und Values	
				return new SortedDictionary<double, Product>(solution.ToDictionary(kvp => kvp.Value, kvp => kvp.Key));
			}
			// leeres Dictionary Object
			return (new SortedDictionary<double, Product>());

		}
		public static Product? MostLikelyProduct(List<Product?> productList, int mindestErkennungsAnzahl = 3)
		{
			Product result = null;
			Dictionary<Product, int> counter = new Dictionary<Product, int>();
			if (productList != null)
			{
				if (productList.Count() > 9)
				{
					foreach (Product p in productList)
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
			}
			return result;
		}
	}
}
