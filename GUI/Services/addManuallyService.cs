using KassenmanagementLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Services
{

    public interface IaddManuallyService
    {
        public ShoppingBasket shoppingBasket { get; set; }

        public SortedDictionary<double, Product> scanData { get; set; }

        public SortedDictionary<double, Product> getScanData();

        public void AddArticleManually(Product product);
    }

    public class addManuallyService : IaddManuallyService
    {
        public ShoppingBasket shoppingBasket { get; set; }

        public SortedDictionary<double, Product> scanData { get; set; }

        public SortedDictionary<double, Product> getScanData()
        {
            return scanData;
        }

        public void AddArticleManually(Product product)
        {
            shoppingBasket.AddArticle(product);
        }
    }
}
