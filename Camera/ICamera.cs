﻿using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camera
{
    public interface ICamera
    {
        Bitmap GetCurrentBitmap();
    }
}
