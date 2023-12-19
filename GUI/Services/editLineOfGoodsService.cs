using KassenmanagementLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Services
{

    public interface IeditLineOfGoods
    {
        public LineOfGoods LineOfGoods { get; set; }

        public void DeleteProduct(Product product);

        public void EditProduct(Product product);
    }

    public class editLineOfGoodsService : IeditLineOfGoods
    {
        public LineOfGoods LineOfGoods { get; set; }

        public void DeleteProduct(Product product)
        {
            LineOfGoods.Remove(product);
        }

        public void EditProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
