using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;


namespace KassenmanagementLibrary
{
    public class Product
    {
        public string Name { get; set; }

        public uint Articlenumber { get; set; }

        public double Price { get; set; }

        public bool Quantityarticle { get; set; }


        // Liste von Vektoren für das Produkt
        public List<CLIPVector> allproductvectors { get; set; } //-> using namespace probleme 






        //konstruktor
        public Product(string name, uint atriclenumber, double price, bool quantityarticle)
        {
            Name = name;
            Articlenumber = atriclenumber;
            Price = price;
            Quantityarticle = quantityarticle;
        }

        public Product()
        {
        }
    }
}
