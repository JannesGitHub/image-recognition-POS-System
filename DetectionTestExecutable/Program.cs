using DetectionLibrary;
using KassenmanagementLibrary;
using System.Drawing;

internal class Program
{
    private static void Main(string[] args)
    {
        LineOfGoods sortiment = LineOfGoods.Instance;
        //sortiment = LineOfGoods.GetFromXML();
        Product apfel = new Product("Apfel", 69420, 1.90, true, GetProductVectorsFromFolder("Apfel"));
        sortiment.Add(apfel);
        Product orange = new Product("Orange", 696969, 2.01, false, GetProductVectorsFromFolder("Orange"));
        sortiment.Add(orange);
        sortiment.Safe();
        Console.WriteLine(sortiment.FindProduct("Orange").Name);
        Console.WriteLine(sortiment.FindProduct("Apfel").Name);
    }
    public static List<CLIPVector> GetProductVectorsFromFolder(string Ordnername)
    {
        IDetection detectionObj = new Detection();
        List<CLIPVector> resultList = new List<CLIPVector>();
        string DateipfadmitBildern = Path.Combine(AppDomain.CurrentDomain.BaseDirectory); // geht warsch. nur auf Windows - ".." - Befehl für directory auf hörer Ebene
        DateipfadmitBildern = DateipfadmitBildern.Substring(0, DateipfadmitBildern.IndexOf("j-kassenscanner"));
        DateipfadmitBildern += "j-kassenscanner\\TestBilder\\";
        DateipfadmitBildern += Ordnername;
        // Überprüfen, ob der Zielordner existiert
        if (Directory.Exists(DateipfadmitBildern))
        {
            foreach (string d in Directory.GetFiles(DateipfadmitBildern, "*.jpg"))
            {
                Bitmap bmp = new Bitmap(d);
                resultList.Add(detectionObj.GetCLIPVector(bmp));
            }
            // Alle Dateipfade im Zielordner abrufen, die Bitmaps enthalten können
            string[] filePaths = Directory.GetFiles(DateipfadmitBildern, "*.bmp"); // Sie können die Dateierweiterungen entsprechend ändern

            foreach (string filePath in filePaths)
            {
                Bitmap Test = new Bitmap(filePath);

                // Test-Methode auf jede Bitmap anwenden
                CLIPVector result = detectionObj.GetCLIPVector(Test);

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