using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleKaartspel1
{
    
    class Deck
    {
        public List<Kaart> Kaarten { get; set; } = new List<Kaart>();
        public Deck()
        {
            int n = 1, j = -1;
            string[] k = { "C", "S", "H", "D" };
            for (int i = 0; i < 52; i++)
            {
                if (i % 13 == 0)
                {
                    j++;
                    n = 1;
                }
                Kaarten.Add(new Kaart(n, k[j]));
                n++;
            }
        }
        public void Schudden()
        {
            //Fisher–Yates shuffle
            Random r = new Random();
            for (int n = Kaarten.Count - 1; n > 0; --n)
            {
                int k = r.Next(n + 1);
                Kaart temp = Kaarten[n];
                Kaarten[n] = Kaarten[k];
                Kaarten[k] = temp;
            }
        }
        public Kaart NeemKaart()
        {
            Kaart kaart = Kaarten[Kaarten.Count - 1];
            Kaarten.RemoveAt(Kaarten.Count - 1);
            return kaart;
        }
    }
}
