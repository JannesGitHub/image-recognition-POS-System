using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KassenmanagementLibrary;

namespace DetectionLibrary
{
    internal interface IDetection
    {
        //Trennen vom Dictionary und Produkt?
        (SortedDictionary<double, Product>, Product?) getDetectionOutput(LineOfGoods sortiment, List<Bitmap> frames);
        public static CLIPVector GetCLIPVector(Bitmap frame) { return ZeroShot.GetCLIPVector(frame); }
    }
}
