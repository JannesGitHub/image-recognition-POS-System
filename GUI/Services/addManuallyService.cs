using KassenmanagementLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Services
{

    public interface IAddManuallyService
    {
        public ShoppingBasket ShoppingBasket { get; set; }

        public SortedDictionary<double, Product> ScanData { get; set; }

        public SortedDictionary<double, Product> GetScanData();

        public void AddArticleManually(Product product);
    }

    public class AddManuallyService : IAddManuallyService
    {
        public ShoppingBasket ShoppingBasket { get; set; }

        public SortedDictionary<double, Product> ScanData { get; set; }

        public SortedDictionary<double, Product> GetScanData()
        {
            return ScanData;
        }

        public void AddArticleManually(Product product)
        {
            ShoppingBasket.AddArticle(product);
        }
    }
}
