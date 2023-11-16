using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KassenmanagementLibrary
{
    public class LineOfGoods //: ILineOfGoods
    {
        private static LineOfGoods instance;

        public static LineOfGoods Instance { get
            { if (instance == null)
                {
                    instance = new LineOfGoods();
                }
                return instance;
            }
        }
       public List<Product> lineOfGoods {  get; set; }
       
        // prüft ob atrikel im sortiment existiert anhand des namens
        public bool Containsname(string name)
        {
            bool exists = false;
            foreach (Product p in lineOfGoods)
            {if(p.Name == name)
                {
                    exists = true;
                }
            }
            return exists;
        }

        // überladung der containsmethode, sucht anhand der atrikelnummer
        public bool Containsn(uint atriclenumber)
        {
            bool exists = false;
            foreach(Product p in lineOfGoods)
            {
                if (atriclenumber== p.Articlenumber)
                {
                    exists = true;
                }
            }
            return exists;
            }

        //fügt akritel dem sortiment hinzu
        public void Add(Product p)
        {
            lineOfGoods.Add(p);
        }

        // löscht artikel aus sortiment
        public void Remove(Product p)
        {
            lineOfGoods.Remove(p);
        }


        // 
        public void editproduct(Product product)
        {

        }


       

       

       
    }
}
