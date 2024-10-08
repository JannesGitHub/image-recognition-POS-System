﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;


namespace KassenmanagementLibrary
{
    [Serializable]
    public class Product : IComparable<Product>
    {
        public string Name { get; set; }

        public uint Articlenumber { get; set; }

        public double Price { get; set; }

        public bool Quantityarticle { get; set; }

        // Liste von Vektoren für das Produkt
        public List<CLIPVector> Allproductvectors { get; set; }


        //Parameterloser Konstruktor war nötig zur Serialisierung
        public Product()
        {

        }

        //konstruktor
        public Product(string name, uint atriclenumber, double price, bool quantityarticle, List<CLIPVector> allproductvectors)
        {
            this.Name = name;
            this.Articlenumber = atriclenumber;
            this.Price = price;
            this.Quantityarticle = quantityarticle;
            this.Allproductvectors = allproductvectors;
        }

        public int CompareTo(Product? other)
        {
            if (this.Name.CompareTo(other.Name) < 0) return -1;
            if (this.Name.CompareTo(other.Name) == 0) return 0;
            if (this.Name.CompareTo(other.Name) > 0) return 1;
            return 0;
        }
    }
}
