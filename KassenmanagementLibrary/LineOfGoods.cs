using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml.Serialization;

namespace KassenmanagementLibrary
{
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
                lineOfGoods = new List<Product>();
            }
        }
        public List<Product> lineOfGoods { get; set; }


        // prüft ob atrikel im sortiment existiert anhand des namens
        public Product FindProductByName(string name)
        {
            foreach (Product p in lineOfGoods)
            {
                if (name == p.Name)
                {
                    return p;
                }
            }
            return null;
        }


        // überladung der containsmethode, sucht anhand der atrikelnummer
        public Product FindProductByNumber(uint articlenumber)//umbenennen
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
        public void AddProduct(Product p)
        {
            lineOfGoods.Add(p);
        }

        // löscht artikel aus sortiment
        public void RemoveProduct(Product p)
        {
            lineOfGoods.Remove(p);
        }



        public void editproduct(Product product)
        {
            if (FindProductByName(product.Name) != null)
            {
                FindProductByName(product.Name).Articlenumber = product.Articlenumber;
                FindProductByName(product.Name).Quantityarticle = product.Quantityarticle;
                FindProductByName(product.Name).Allproductvectors = product.Allproductvectors;
                FindProductByName(product.Name).Price = product.Price;

            }
            else
            {
                AddProduct(product);
            }

        }

        public void safe(ShoppingBasket shoppingbasket)
        {

            string bon = shoppingbasket.generateReciept(shoppingbasket);

            string filePath = "D:\\ProgProjekt\\Belege";

            // Rufe die generateReceipt-Methode auf, um den String zu erhalten.


            // Erstelle einen XmlSerializer für den Typ string.
            XmlSerializer serializer = new XmlSerializer(typeof(string));

            // Öffne eine Datei zum Schreiben (oder erstelle sie, wenn sie nicht existiert).
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Serialisiere den String und schreibe ihn in die Datei.
                serializer.Serialize(writer, bon);
            }









        }
    }
}
