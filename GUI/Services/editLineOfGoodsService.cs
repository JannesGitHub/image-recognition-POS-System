using KassenmanagementLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GUI.Services
{

    public interface IeditLineOfGoods
    {
        public LineOfGoods LineOfGoods { get; set; }

        public Product toEditProduct {  get; set; }

        public Bitmap currentBitmap { get; set; }

        public void DeleteProduct(Product product);

        public void EditProduct(Product product);
    }

    public class editLineOfGoodsService : IeditLineOfGoods
    {
        public LineOfGoods LineOfGoods { get; set; }

        public Product toEditProduct { get; set; }

        public Bitmap currentBitmap { get; set; }

        public void DeleteProduct(Product product)
        {
            LineOfGoods.Remove(product);
        }

        public void EditProduct(Product product)
        {
            int indexToChange = LineOfGoods.lineOfGoods.IndexOf(toEditProduct);

            if (indexToChange != -1)  // Überprüfe, ob toEditProduct in der Liste enthalten ist
            {
                LineOfGoods.lineOfGoods[indexToChange] = product;
            }
            else
            {
                MessageBox.Show("Nicht enthalten");
            }
        }
    }
}
