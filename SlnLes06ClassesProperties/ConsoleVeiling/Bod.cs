using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleVeiling
{
    class Bod
    {
        public decimal Prijs { get; set; }
        public Koper Koper { get; set; }
        public Item Item { get; set; }


        public Bod(decimal prijs, Item item, Koper koper)
        {
            Prijs = prijs;
            Item = item;
            Koper = koper;
        }

    }
}
