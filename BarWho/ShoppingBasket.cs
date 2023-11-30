﻿/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KassenmanagementLibrary
{
    
    public class ShoppingBasket : IShoppingBasket
    {
        public Dictionary<Product, uint> ArticleList { get; set; }

        private double TotalPrice { get
            {
                return getTotalPrice(this.ArticleList);
            } 
        }

        public ShoppingBasket getShoppingBasket()
        {
            return new ShoppingBasket(ArticleList);
        }


        //konstruktor
        public ShoppingBasket (Dictionary<Product,uint> articlelist) 
        {
            this.ArticleList = articlelist;
        }

        public ShoppingBasket()
        {

        }


        public double getTotalPrice(Dictionary<Product,uint> articlelist)
        {
            double totalPrice = 0;

            foreach (var pair in articlelist)
            {
                if (pair.Key.Quantityarticle == true)
                {
                    totalPrice += pair.Key.Price * pair.Value;
                }
                else totalPrice += pair.Key.Price;
            }
            return totalPrice;

        }

        //fügt einen artikel mit der jeweiligen menge dem Dictionary(Artikelliste) hinzu
        public void addArticle(Product product, uint amount)
        {
            ArticleList.Add(product, amount);
        }
        public void ChangeArticleAmount(uint menge, Product key)
        {
            if (ArticleList.ContainsKey(key))
            {
                ArticleList[key] = menge;
            }

        }

        public void deleteArticle(Product product)
        {
            foreach(var pair in ArticleList)
            {
                if (pair.Key == product)
                {
                    ArticleList.Remove(pair.Key);
                }
            }
        }


        //benutzt die stringbuilder methode um aus verschiedenen eingaben einen einzigen String zu erstellen.
       public  string generateReciept(ShoppingBasket shoppingBasket) 
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
       }
        


    }
}
*/