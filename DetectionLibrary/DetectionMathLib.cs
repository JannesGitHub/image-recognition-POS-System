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
		public static SortedDictionary<double, Product> Softmax(Dictionary<double, Product> list)
		{
			double factor = 1;
			double divider = 0;
			SortedDictionary<double, Product> result = new SortedDictionary<double, Product>();
			foreach (double d in list.Keys)
			{
				divider += Math.Pow(Math.E, factor * d);
			}
			foreach (KeyValuePair<double,Product> d in list)
			{
				result.Add(Math.Pow(Math.E, factor * d.Key) / divider,d.Value);
			}
			return result;
		}
		public static double SmallestValueOf(List<double> list)
		{
			return list.Min();
		}
	}
}
