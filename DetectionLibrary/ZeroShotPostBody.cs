using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetectionLibrary
{
    internal class ZeroShotPostBody
    {
        public HttpContent HttpBody 
        {
            get
            {
                return new ByteArrayContent(ImageBLOB);
            }
                
        }
        private byte[] ImageBLOB;
        public ZeroShotPostBody(Bitmap image) 
        {
            if(image == null) throw new ArgumentNullException("image is Null");
            ImageBLOB = GetBytesOfImage(image);
        }
        private static byte[] GetBytesOfImage(Bitmap img)
        {
            ImageConverter converter = new();
#pragma warning disable CS8603 // Mögliche Nullverweisrückgabe augeblendet das Überprüfe ich im Konstruktor.
            return converter.ConvertTo(img, typeof(byte[])) as byte[];
#pragma warning restore CS8603 // Mögliche Nullverweisrückgabe augeblendet das Überprüfe ich im Konstruktor.
        }
    }
}
