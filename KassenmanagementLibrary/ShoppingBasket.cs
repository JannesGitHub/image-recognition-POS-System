using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using KassenmanagementLibrary;

namespace KassenmanagementLibrary
{

    public class ShoppingBasket : ObserveableObject, IShoppingBasket
    {

        public ShoppingBasket()
        {
            shoppingBasket.CollectionChanged += (sender, e) => UpdateSumPrice();
        }

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
                OnPropertyChanged(nameof(_ShoppingBasket));
                shoppingBasket.CollectionChanged += (sender, e) => UpdateSumPrice();
            }
        }

        private double sumPrice;

        public double SumPrice
        {
            get { return sumPrice; }
            set
            {
                if (sumPrice != value)
                {
                    sumPrice = value;
                    OnPropertyChanged(nameof(SumPrice));
                }
            }
        }


        //summiert preise des selben Artikels auf 
        private void UpdateSumPrice()
        {
            double price = 0;

            foreach (Article ar in _ShoppingBasket)
            {
                price += ar.TotalPrice;
            }

            price = Math.Round(price, 2);

            SumPrice = price;
        }
        // gesamtpreis der articlellist 
        public double GetTotalPrice(ObservableCollection<Article> articlelist)
        {
            double totalPrice = 0;

            foreach (var item in articlelist)
            {
                totalPrice += item.TotalPrice;
            }
            return totalPrice;

        }
        //fügt Artikel dem Shoppingpasket hinzu, wenn er schon im warenkorb vorhanden ist, wird die Menge erhöht.
        public void AddArticle(Product product)
        {
            Article article = new Article(product);

            string articleName = article.Name;

            bool containsArticleName = false;

            foreach (Article a in _ShoppingBasket)
            {
                if (a.Name == articleName)
                {
                    containsArticleName = true;
                    UpQuantity(a);
                }
            }


            if (!containsArticleName)
            {
                _ShoppingBasket.Add(article);
            }
        }

        // leert den Shoppingbasket
        public void Clear()
        {
            _ShoppingBasket.Clear();
        }

        public void UpQuantity(Article article)
        {
            if (article != null)
            {
                _ShoppingBasket[_ShoppingBasket.IndexOf(article)].Quantity += 1;
                _ShoppingBasket[_ShoppingBasket.IndexOf(article)].TotalPrice += _ShoppingBasket[_ShoppingBasket.IndexOf(article)].Price;
                UpdateSumPrice();
            }


        }

        public void DownQuantity(Article article)
        {
            if (article != null)
            {
                _ShoppingBasket[_ShoppingBasket.IndexOf(article)].Quantity -= 1;
                _ShoppingBasket[_ShoppingBasket.IndexOf(article)].TotalPrice -= _ShoppingBasket[_ShoppingBasket.IndexOf(article)].Price;
                UpdateSumPrice();
            }
        }

        public void NewQuantity(Article article, double quantity) //for change in wheigths
        {
            _ShoppingBasket[_ShoppingBasket.IndexOf(article)].Quantity = quantity;
            _ShoppingBasket[_ShoppingBasket.IndexOf(article)].TotalPrice = article.Quantity * article.Price; 
            UpdateSumPrice();
        }


        public string GenerateReciept()
        {
            StringBuilder receiptBuilder = new StringBuilder();
            receiptBuilder.AppendLine("Kassenbeleg");
            receiptBuilder.AppendLine();
            receiptBuilder.AppendLine("--------------------------------------------");

            foreach (Article item in _ShoppingBasket)
            {
                receiptBuilder.AppendLine($"Produkt:{item.Name,-20} {item.Quantity}x  {item.Price,10}");
            }

            receiptBuilder.AppendLine();
            receiptBuilder.AppendLine("--------------------------------------------");
            receiptBuilder.AppendLine();

            double totalprice = GetTotalPrice(_ShoppingBasket);
            receiptBuilder.AppendLine($"SUMME EUR  {Math.Round(totalprice, 2)}");

            Console.WriteLine(receiptBuilder.ToString());

            return receiptBuilder.ToString();
        }

        // speichert den beleg als neue datei ab
        public void SaveReciept()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(string));

            string fileName = "Reciepts.xml";
            string date = $"Receipt_{DateTime.Now:yyyyMMddHHmmssfff}.xml";
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory);
            filePath = filePath.Substring(0, filePath.IndexOf("j-kassenscanner"));
            filePath += "j-kassenscanner\\" + fileName + date;

            //Prüft ob der Dateipfad existiert. Falls nicht wirft er eine Exception

            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentException("Ungültiger Dateipfad.", nameof(filePath));
            }


            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                serializer.Serialize(fs, this);
            }

        }

    }
}
