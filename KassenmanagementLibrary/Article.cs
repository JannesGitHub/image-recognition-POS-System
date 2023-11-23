using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KassenmanagementLibrary
{
    public class Article : INotifyPropertyChanged
    {
        public Product Source;

        private double quantity;

        private double price;
        public string Name { get; set; }

        private double totalPrice;

        public Article() { }

        public Article(Product _product)
        {
            Name = _product.Name;
            Price = _product.Price;
            totalPrice = _product.Price;
            Quantity = 1;
            Source = _product;
        }

        public double TotalPrice
        {
            get { return totalPrice; }
            set
            {
                if (totalPrice!= value)
                {
                    totalPrice = value;
                    OnPropertyChanged(nameof(TotalPrice));
                }
            }
        }

        public double Quantity
        {
            get { return quantity; }
            set
            {
                if (quantity != value)
                {
                    quantity = value;
                    OnPropertyChanged(nameof(Quantity));
                }
            }
        }

        public double Price
        {
            get { return price; }
            set
            {
                if (price != value)
                {
                    price = value;
                    OnPropertyChanged(nameof(Price));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
