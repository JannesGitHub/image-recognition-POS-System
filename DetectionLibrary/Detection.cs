using KassenmanagementLibrary;
using System.Drawing;

namespace DetectionLibrary
{
    public class Detection : IDetection
    {
        private Dictionary<Product, double> ValuedLineOfGoods
        

        public LineOfGoods LineOfGoods
        {
            get
            {
                return new LineOfGoods();// soll das aktuelle Sortiment Objekt abrufen
            }
            set 
            { 
                this.LineOfGoods = value; //
            }
        }
        public Product LastProduct { get; private set; }
        //Frage zu LineOfGoods und ValuedLineOfGoods, wo soll ich die Eigenschaften zuweisen im Getter oder im setter? 
        //eigentlich im Getter und den setter einfach weglassen/privat stellen?
        
        private CLIPVector ImageAsVector (Image image)
        {
            get { return ZeroshotDemo(currentImage)} // tauscht das von der GUI bekomme Image Object in einen CLIPVector
        }
        public Dictionary<Product, double> getValuedLineOfGoods(Image image)
        {
            ImageAsVector(image)
            //muss das aktuellste Dictionory mit den Produkt/warscheinlichkeitspaaren zurrückgeben
            return this.ValuedLineOfGoods;
            //Webclient, MIME decodierung, welche IMAGE Klasse nehmen wir, 
            //Kommunikation mit CLIP: eigenes Nebenprojekt machen - und einfachen Befehl testen. (PROG 2 Serialisierung?)
        }

    }
}