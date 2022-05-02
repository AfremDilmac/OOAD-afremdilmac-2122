using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleKassaTicket
{
    class Program
    {
        static void Main(string[] args)
        {
            Product bananen = new Product("P02384", "bananen", 1);
            Product brood = new Product("P01820", "brood", 5);
            Product kaas = new Product("P45612", "kaas", 4);
            Product koffie = new Product("P98754", "koffie", 3);
            Product jam = new Product("P45974", "jam", 2);
            Product tomaat = new Product("P43142", "tomaat", 1);

            Ticket ticketCash = new Ticket("Afrem", Betaalwijze.Cash);
            ticketCash.Producten.Add(bananen);
            ticketCash.Producten.Add(brood);
            ticketCash.DrukTicket();

            Ticket ticketVisa = new Ticket("Saskia", Betaalwijze.Visa);
            ticketVisa.Producten.Add(kaas);
            ticketVisa.Producten.Add(koffie);
            ticketVisa.DrukTicket();

            Ticket ticketBancontact = new Ticket("Huawei", Betaalwijze.Bancontact);
            ticketBancontact.Producten.Add(jam);
            ticketBancontact.Producten.Add(tomaat);
            ticketBancontact.DrukTicket();
            Console.ReadLine();
        }
    }
}
