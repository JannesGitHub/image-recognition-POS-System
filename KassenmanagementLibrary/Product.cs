using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using DetectionLibrary;

namespace KassenmanagementLibrary
{
    public class Product
    {
        public string Name { get; set; }

        public uint Articlenumber { get; set; }

        public double Price { get; set; }

        public bool Quantityarticle { get; set; }


        // Liste von Vektoren für das Produkt
        public List<CLIPVector> Allproductvectors { get; set; } 






        //konstruktor
        public Product(string name, uint atriclenumber, double price, bool quantityarticle,List<CLIPVector> allproductvectors)
        {
            this.Name = name;
            this.Articlenumber = atriclenumber;
            this.Price = price;
           this.Quantityarticle = quantityarticle;
            this.Allproductvectors = allproductvectors;

        }

        
    }
}
