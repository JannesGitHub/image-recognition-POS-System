using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KassenmanagementLibrary
{
    public class ShoppingBasket : IShoppingBasket
    {
        ShoppingBasket IShoppingBasket.ShoppingBasket => throw new NotImplementedException();

        private ShoppingBasket()
        {

        }


        // singleton -> stelllt
        private static ShoppingBasket instance;

        public static ShoppingBasket Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new ShoppingBasket();
                }
                return instance;
            }
        }

    }
}
