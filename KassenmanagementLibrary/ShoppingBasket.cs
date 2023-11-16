using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KassenmanagementLibrary
{
    public class ShoppingBasket //: IShoppingBasket
    {
        public Dictionary<Product, uint> _articleList { get; set; }

        private double _totalPrice { get; set; }



        public double getTotalPrice()
        {


            foreach (var pair in _articleList)
            {
                this._totalPrice += pair.Key.Price * pair.Value;
            }
            return this._totalPrice;

        }

        //fügt einen artikel mit der jeweiligen menge dem Dictionary(artikelliste) hinzu
        public void addArticle(Product product, uint amount)
        {
            _articleList.Add(product, amount);
        }
        public void ChangeArticleAmount(uint menge, Product key)
        {
            if (_articleList.ContainsKey(key))
            {
                _articleList[key] = menge;
            }

        }

    }
}
