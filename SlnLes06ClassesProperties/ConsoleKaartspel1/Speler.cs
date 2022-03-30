using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleKaartspel1
{
    class Speler
    {
        public string Naam { get; set; }
        public List<Kaart> Kaarten { get; set; } = new List<Kaart>();
        public bool HeeftNogKaarten { get; set; } = true;

        public Speler(string n)
        {
            Naam = n;
        }
        public Speler(string n, List<Kaart> k)
        {
            Naam = n;
            Kaarten = k;
        }

        public Kaart LegKaart()
        {
            Kaart kaart = Kaarten[Kaarten.Count - 1];
            Kaarten.RemoveAt(Kaarten.Count - 1);
            if (Kaarten.Count == 0)
            {
                HeeftNogKaarten = false;
            }
            return kaart;
        }
    }
}
