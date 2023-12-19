using KassenmanagementLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetectionLibrary
{
	internal class SmartListForProbabilityDictionary : SmartListBase<SortedDictionary<double, Product>>
	{
		public SortedDictionary<double, Product> GetResultProbabilityDictionary()
		{
			SortedDictionary<Product,double> solution = new SortedDictionary<Product, double>();
			//LINQ ausruck für Dictionary finden
			foreach (SortedDictionary<double, Product> d in LastResults)
			{
				foreach (KeyValuePair<double, Product> kvp in d)
				{
					double probability = kvp.Key;
					Product product = kvp.Value;

					if (solution.ContainsKey(product))
					{
						solution[product] += probability;
					}
					else
					{
						solution[product] = probability;
					}
				}
				foreach(Product p in solution.Keys)
				{
					solution[p] = solution[p] / 10;
				}
				// Tauscht Key und Values
				return new SortedDictionary<double, Product>(solution.ToDictionary(kvp => kvp.Value, kvp => kvp.Key));
			}
		}
	}
}
