using KassenmanagementLibrary;

namespace DetectionLibrary
{
    public class Detection : IDetection
    {
        public Dictionary<Product, double> ValuedLineOfGoods
        {
            get
            {
                return this.ValuedLineOfGoods;
            }
            set
            {
                this.ValuedLineOfGoods = value;// Value muss Funktion sein, die das Dictionary erstellt
            }
        }
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
        public CLIPVector ImageAsVector 
        {
            get { return ZeroshotDemo(currentImage)} // tauscht das von der GUI bekomme Image Object in einen CLIPVector
        }
        public Dictionary<Product, double> getValuedLineOfGoods()
        {
            //muss das aktuellste Dictionory mit den Produkt/warscheinlichkeitspaaren zurrückgeben
            return this.ValuedLineOfGoods;
        }

    }
}