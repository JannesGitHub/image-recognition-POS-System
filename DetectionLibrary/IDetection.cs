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
        (Dictionary<Product, double>,Product?) getDetectionOutput(LineOfGoods sortiment, Bitmap frame);

    }
}
