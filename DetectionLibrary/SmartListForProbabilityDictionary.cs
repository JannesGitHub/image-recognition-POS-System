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
			if(LastResults != null || LastResults.Count > 9)
			{
				Dictionary<Product, double> solution = new Dictionary<Product, double>();
				//LINQ ausruck für Dictionary finden
				foreach (SortedDictionary<double, Product> d in LastResults)
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
					solution[p] = solution[p] / LastResults.Count();
				}
				// Tauscht Key und Values	
				return new SortedDictionary<double, Product>(solution.ToDictionary(kvp => kvp.Value, kvp => kvp.Key));
			}
			// leeres Dictionary Object
			return(new SortedDictionary<double, Product>());

		}
	}
}
