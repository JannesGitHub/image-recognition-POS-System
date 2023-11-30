using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace KassenmanagementLibrary
{
    public class CLIPVector
    {
        public double[] Vector;
        public CLIPVector(double[] vector) 
        {  
            vector.CopyTo(Vector,0); 
        }

        //Parameterloser Konstruktor war nötig zur Serialisierung
        public CLIPVector()
        {
        }
        public List<double> CompareTo(List<CLIPVector> cLIPVectors)
        {
            List<double> result = new List<double>();
            foreach(CLIPVector cLIP in cLIPVectors)
            {
                result.Add(GetMagnitude(this.Subtract(cLIP)));
            }
            return result;
        }
        private static double GetMagnitude(CLIPVector cLIPVector)
        {
            double presquareroot = 0;
            foreach (double value in cLIPVector.Vector)
            {
                presquareroot += Math.Pow(value, 2);
            }
            return Math.Sqrt(presquareroot);
        }
        /// <summary>
        /// this CLIPVector gets subtracted by the Parameter
        /// </summary>
        /// <param name="cLIPVector">Vector To be subtracted</param>
        /// <returns></returns>
        private CLIPVector Subtract (CLIPVector cLIPVector)
        {
            List<double> result = new List<double>();
            for(int i = 0; i < cLIPVector.Vector.Length; i++)
            {
                result.Add(this.Vector[i] - cLIPVector.Vector[i]);
            }
            return new CLIPVector(result.ToArray());
        }
        
    }

}
