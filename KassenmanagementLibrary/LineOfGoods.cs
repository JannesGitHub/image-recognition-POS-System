using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace KassenmanagementLibrary
{

    [Serializable]
    public class LineOfGoods : ObserveableObject, ILineOfGoods
    {


        private static LineOfGoods instance;

        public LineOfGoods GetLineOfGoods()
        {
            return instance;
        }

        public static LineOfGoods Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LineOfGoods();
                }
                return instance;
            }

        }
        private LineOfGoods()
        {
            // Initialisiere die Liste, wenn noch nicht geschehen
            if (lineOfGoods == null)
            {
                lineOfGoods = new List<Product>();
            }

        }

        private List<Product> _lineOfGoods;

        public List<Product> lineOfGoods
        {
            get => _lineOfGoods;
            set
            {
                if (_lineOfGoods != value)
                {
                    _lineOfGoods = value;
                    OnPropertyChanged(nameof(lineOfGoods));
                    OnPropertyChanged(nameof(_lineOfGoods));
                }
            }
        }


        // prüft ob atrikel im sortiment existiert anhand des namens
        public Product FindProduct(string name)
        {

            foreach (Product p in lineOfGoods)
            {
                if (p.Name == name)
                {
                    return p;
                }
            }
            return null;
        }


        // überladung der containsmethode, sucht anhand der atrikelnummer
        public Product FindProduct(uint articlenumber)//umbenennen
        {

            foreach (Product p in lineOfGoods)
            {
                if (articlenumber == p.Articlenumber)
                {
                    return p;
                }
            }
            return null;

        }

        //fügt artikel dem sortiment hinzu
        public void Add(Product p)
        {
            lineOfGoods.Add(p);
        }

        // löscht artikel aus sortiment
        public void Remove(Product p)
        {
            lineOfGoods.Remove(p);
        }



        XmlSerializer serializer = new XmlSerializer(typeof(LineOfGoods));

        //speichert das Sortiment objekt in executeable

        public void Safe()
        {
            string fileName = "LineOfGoods.xml";
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory);
            filePath = filePath.Substring(0, filePath.IndexOf("image-recognition-POS-System"));
            filePath += "image-recognition-POS-System\\" + fileName;

            //Prüft ob der Dateipfad existiert. Falls nicht wirft er eine Exception


            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentException("Ungültiger Dateipfad.", nameof(filePath));
            }

            string directoryPath = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }


            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                serializer.Serialize(fs, this);
            }
        }


        //methode ruft sortiment aus XML datei auf
        public static LineOfGoods GetFromXML()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(LineOfGoods));

            string fileName = "LineOfGoods.xml";
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory);
            filePath = filePath.Substring(0, filePath.IndexOf("image-recognition-POS-System"));
            filePath += "image-recognition-POS-System\\" + fileName;
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentException("Ungültiger Dateipfad.", nameof(filePath));
            }
            else
            {
                using (Stream reader = File.OpenRead(filePath))
                {
                    instance = (LineOfGoods)serializer.Deserialize(reader);
                }
            }
            return instance;
        }




    }
}
