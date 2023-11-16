using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KassenmanagementLibrary
{
    public class ShoppingBasket //: IShoppingBasket
    {
    public Dictionary<Product, uint> atricleList { get; set; }

    private double totalPrice { get; set; }



        public double getTotalPrice(ShoppingBasket basket)
        {
            
           foreach(var pair in atricleList)
            {
                this.totalPrice += pair.Key.Price;
            }
           return totalPrice;
           
        }
    }
}
