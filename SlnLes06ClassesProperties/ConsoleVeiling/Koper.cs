using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleVeiling
{
    class Koper
    {
        public string Naam { get; set; }
        public List<Item> Items { get; set; } = new List<Item>();


        public Koper(string naam)
        {
            Naam = naam;
        }

        public Koper(string naam, List<Item> gekochteItem)
        {
            Naam = naam;
            Items = gekochteItem;
        }
    }
}
