using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    public class Article : INotifyPropertyChanged
    {
        private int quantity;

        private double price;
        public string Name { get; set; }

        private double totalPrice;

        public Article() { }


        public Article(Product _product, int _quantity)
        {
            Name = _product.Name;
            Price = _product.Price;
            Quantity = _quantity;
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

        public int Quantity
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
