using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    public class Article
    {
        public string Name { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }

        public Article(Product product, int quantity)
        {
            Name = product.Name;
            Quantity = quantity;
            Price = product.Price * quantity;
        }

        public Article() { }


    }
}
