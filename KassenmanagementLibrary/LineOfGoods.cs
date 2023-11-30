using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace KassenmanagementLibrary
{
    [Serializable]
    public class LineOfGoods : ILineOfGoods
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
                //überprüfe ob filePath leer ist
                // wenn nicht leer-> direkt vorhandenes laden


                // wenn leer -> neues erstellen
                lineOfGoods = new List<Product>();
            }
        }
        public List<Product> lineOfGoods { get; set; }

       
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

        //fügt akritel dem sortiment hinzu
        public void Add(Product p)
        {
            lineOfGoods.Add(p);
        }

        // löscht artikel aus sortiment
        public void Remove(Product p)
        {
            lineOfGoods.Remove(p);
        }


        //Nutzt die FindProduct methode um zu schauen ob das Produkt existiert
        // und setzt das von der Methodenzurückgegebene Produkt dem neuen Übergebenen Produkt gleich
        public void editproduct(Product product)
        {
            FindProduct(product.Name).Articlenumber= product.Articlenumber;
            FindProduct(product.Name).Price = product.Price;
            FindProduct(product.Name).Quantityarticle = product.Quantityarticle;
            FindProduct(product.Name).Allproductvectors = product.Allproductvectors;

        }


        //speichert das Sortment objekt in angegebenen Pfad ab.
        //Pfad wird momentan noch als string übergeben
        public void Safe(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentException("Ungültiger Dateipfad.", nameof(filePath));
            }


            XmlSerializer serializer = new XmlSerializer(typeof(LineOfGoods));

           
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                serializer.Serialize(fs, this);
            }
        }

        public void getFromXML(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(LineOfGoods));

            using (Stream reader = File.OpenRead(filePath))
            {
                 instance = (LineOfGoods)serializer.Deserialize(reader);
            }
        }









    }
}
