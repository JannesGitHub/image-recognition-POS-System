using KassenmanagementLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetectionLibrary
{
	internal class SmartListForProbabilityDictionary<T> : SmartListBase<T> where T : SortedDictionary<double,Product>
	{
		public SortedDictionary<double, Product> GetResultProbabilityDictionary()
		{
			//LINQ ausruck für Dictionary finden
			throw new NotImplementedException();
		}
	}
}
