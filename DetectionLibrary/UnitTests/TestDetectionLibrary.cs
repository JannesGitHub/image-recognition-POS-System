using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DetectionLibrary;
using KassenmanagementLibrary;
using System.Drawing;

namespace DetectionLibrary.UnitTests
{
    [TestFixture]
    class TestDetectionLibrary
    {
        public List<CLIPVector> DummiVektorForLineofGoods()
        {
            List<CLIPVector> resultList = new List<CLIPVector>();

            string targetFolderPath = "C:\\Users\\Ralf\\source\\repos\\j-kassenscanner\\TestBilder\\Orange"; // Ändern Sie dies entsprechend

            // Überprüfen, ob der Zielordner existiert
            if (Directory.Exists(targetFolderPath))
            {
                // Alle Dateipfade im Zielordner abrufen, die Bitmaps enthalten können
                string[] filePaths = Directory.GetFiles(targetFolderPath, "*.bmp"); // Sie können die Dateierweiterungen entsprechend ändern

                foreach (string filePath in filePaths)
                {
                    Bitmap Test = new Bitmap(filePath);

                    // Test-Methode auf jede Bitmap anwenden
                    CLIPVector result = Detection.GetCLIPVector(Test);

                    // Das Ergebnis zur Liste hinzufügen
                    resultList.Add(result);
                }
            }
            else
            {
                Console.WriteLine("Der Zielordner existiert nicht.");
            }

            return resultList;
        }
    }
}
