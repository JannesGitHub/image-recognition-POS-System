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

        public void AddProduct(Product product);
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
            int indexToChange = LineOfGoods.lineOfGoods.FindIndex(p => p.Articlenumber == product.Articlenumber);

            //Methode um überprüfen, dass Name und ID einzigartig ist

            LineOfGoods.lineOfGoods[indexToChange] = product; //Wenn man Produkt zweimal editiert ohne zu verändern dann wird nicht mehr erkannt
        }


        public void AddProduct(Product product)
        {
            //Methode um überprüfen, dass Name und ID einzigartig ist

            LineOfGoods.lineOfGoods.Add(product);
        }
    }
}
