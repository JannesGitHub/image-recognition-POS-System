using KassenmanagementLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetectionLibrary
{
	internal class SmartListBase<T>
	{
		internal List<T>? LastResults;
		double length = 10;
		public void Add (T detectedproduct)
		{
			if (LastResults == null)
			{
				LastResults = new List<T>
				{
					detectedproduct
				};
			}
			if(LastResults.Count > length)
			{
				LastResults.RemoveAt(0);
			}
			LastResults.Add(detectedproduct);
		}

	}
}
