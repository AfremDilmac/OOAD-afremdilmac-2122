using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleKassaTicket
{
    public enum Betaalwijze { Visa, Cash, Bancontact}
    class Ticket
    {
        private decimal _prijs = 0;
        public List<Product> Producten { get; set; } = new List<Product>();
        public Betaalwijze Betaalwijze { get; set; } = Betaalwijze.Cash;
        public string Voornaam { get; set; }
        public decimal TotaalPrijs
        {
            get
            {
                for (int i = 0; i < Producten.Count; i++)
                {
                    _prijs += Producten[i].EenheidPrijs;
                }
                return _prijs;
            }
        }
        public Ticket(string v, Betaalwijze b)
        {
            Voornaam = v;
            Betaalwijze = b;
        }

        public void DrukTicket()
        {
            const decimal VISA_KOSTEN = 0.12m;
            Console.WriteLine("KASSATICKET");
            Console.WriteLine("===========");
            Console.WriteLine($"Uw kassier : {Voornaam} \n");
            for (int i = 0; i < Producten.Count; i++)
            {
                Console.WriteLine($"({Producten[i].Code}) {Producten[i].Naam}: {Producten[i].EenheidPrijs}");
            }
            Console.WriteLine("-----------");
            if (Betaalwijze == Betaalwijze.Visa)
            {
                Console.WriteLine($"Visa kosten: €{VISA_KOSTEN}");
                Console.WriteLine($"Totaal: €{ TotaalPrijs + VISA_KOSTEN} ");
                return;
            }
            Console.WriteLine($"Betaalwijze: €{Betaalwijze} ");
            Console.WriteLine($"Totaal: €{ TotaalPrijs} ");
        }
    }
}
