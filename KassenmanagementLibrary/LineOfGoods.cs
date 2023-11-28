using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KassenmanagementLibrary
{
    public class LineOfGoods : ILineOfGoods
    {
        private static LineOfGoods instance;

        public LineOfGoods GetLineOfGoods()
        {
            return instance;
        }

        public static LineOfGoods Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LineOfGoods();
                }
                return instance;
            }
        }
        private LineOfGoods()
        {
            // Initialisiere die Liste, wenn noch nicht geschehen
            if (lineOfGoods == null)
            {
                lineOfGoods = new List<Product>();
            }
        }
        public List<Product> lineOfGoods { get; set; }

       
        // prüft ob atrikel im sortiment existiert anhand des namens
        public bool Containsname(string name)
        {
            bool exists = false;
            foreach (Product p in lineOfGoods)
            {
                if (p.Name == name)
                {
                    exists = true;
                }
            }
            return exists;
        }
        

        // überladung der containsmethode, sucht anhand der atrikelnummer
        public Product Contains(uint articlenumber)//umbenennen
        {
            
            foreach (Product p in lineOfGoods)
            {
                if (articlenumber == p.Articlenumber)
                {
                    return p;
                }
            }
            return null;
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


        // nicht sicher wie die methode genau funktionieren soll, interaktiv? sprich: es wird gefragt was geändert werden soll
        public void editproduct()
        {
            
        }

        public void safe()
        { 

        }









    }
}
