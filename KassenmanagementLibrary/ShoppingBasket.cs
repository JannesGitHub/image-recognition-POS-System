using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KassenmanagementLibrary
{
    public class ShoppingBasket : IShoppingBasket
    {

        public ShoppingBasket getShoppingBasket() //Interface
        {
            return this;
        }

        private ObservableCollection<Article> shoppingBasket = new ObservableCollection<Article>();  //ShoppingBasket

        public ObservableCollection<Article> _ShoppingBasket
        {
            get { return shoppingBasket; }
            
            set
            {
                shoppingBasket = value;
            }
        }
        private double sumPrice;

        public double SumPrice
        {
            get { return sumPrice; }
            private set { sumPrice = value; }
        }
        private void UpdateSumPrice()
        {
            double price = 0;

            foreach (Article ar in _ShoppingBasket)
            {
                price += ar.TotalPrice;
            }

            price = Math.Round(price, 2); // nur 2 Nachkommastellen anzeigen

            SumPrice = price;
        }

        public void Add(Product product)
        {
            Article article = new Article(product);

            if(_ShoppingBasket.Contains(article))
            {
                UpQuantity(article);
            }
            else
            {
                _ShoppingBasket.Add(article);
            }
            UpdateSumPrice();
        }

        public void Clear()
        {
            _ShoppingBasket.Clear();
            UpdateSumPrice();
        }

        public void UpQuantity(Article article)
        {
            _ShoppingBasket[_ShoppingBasket.IndexOf(article)].Quantity += 1;
            _ShoppingBasket[_ShoppingBasket.IndexOf(article)].TotalPrice += _ShoppingBasket[_ShoppingBasket.IndexOf(article)].Price;
            UpdateSumPrice();
        }

        public void DownQuantity(Article article)
        {
            _ShoppingBasket[_ShoppingBasket.IndexOf(article)].Quantity -= 1;
            _ShoppingBasket[_ShoppingBasket.IndexOf(article)].TotalPrice -= _ShoppingBasket[_ShoppingBasket.IndexOf(article)].Price;
            UpdateSumPrice();
        }

        public void NewQuantity(Article article, double quantity) //for change in wheigths
        {
            _ShoppingBasket[_ShoppingBasket.IndexOf(article)].Quantity = quantity;
            UpdateSumPrice();
        }




        /*public  string generateReciept(ShoppingBasket shoppingBasket) 
       {
           StringBuilder receiptBuilder = new StringBuilder();
            receiptBuilder.AppendLine("Kassenbeleg");
            receiptBuilder.AppendLine();
            receiptBuilder.AppendLine("--------------------------------------------");

            foreach (var item in ArticleList)
            {
                if (item.Key.Quantityarticle == true)
                {
                    receiptBuilder.AppendLine($"Produkt:{item.Key.Name,-20} {item.Value}x  {item.Key.Price,10}");
                }
                else
                {
                    receiptBuilder.AppendLine($"Produkt:{item.Key.Name,-20} {item.Value}kg {item.Key.Price,10}");
                }
                
                
            }

            receiptBuilder.AppendLine();
            receiptBuilder.AppendLine("--------------------------------------------");
            receiptBuilder.AppendLine();

            double totalprice = getTotalPrice(shoppingBasket.ArticleList);
            receiptBuilder.AppendLine($"SUMME EUR  {Math.Round(totalprice,2)}");



            Console.WriteLine(receiptBuilder.ToString());
            
            return receiptBuilder.ToString();
       }*/

    }
}
