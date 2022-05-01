using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleVeiling
{

    class Item
    {

        public string Naam { get; set; }
        private decimal _minimumprijs;

        public Bod HoogsteBod {
            get {
                Bod hoogsteBod = null;
                foreach (Bod x in GeregistreerdeBiedingen)
                {
                    if (hoogsteBod == null || hoogsteBod.Prijs < x.Prijs) hoogsteBod = x;
                }
                return hoogsteBod;
            }
        }

        public void AddBod(Bod x) {
            if (x.Prijs < MinimumPrijs) throw new ArgumentException("Bod is te laag");
            GeregistreerdeBiedingen.Add(x);
        }

        public List<Bod> Biedingen
        {
            get {
                return GeregistreerdeBiedingen;
            }
        }

        private List<Bod> GeregistreerdeBiedingen { get; set; } = new List<Bod>();

        public decimal MinimumPrijs {
            get { return _minimumprijs; }
            set {
                if (value < 0)
                {
                    throw new Exception("Minimum prijs mag niet minder dan 0 zijn.");
                }
                else
                {
                    _minimumprijs = value;
                }
            }
        }

        public Item(string naam, decimal minPrijs) : this(naam) 
        {
            MinimumPrijs = minPrijs;
        }

        public Item(string naam)
        {
            Naam = naam;
            MinimumPrijs = 0;
        }
    }
}
