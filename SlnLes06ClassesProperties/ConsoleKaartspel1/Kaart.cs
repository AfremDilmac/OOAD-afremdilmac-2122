using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleKaartspel1
{
    class Kaart
    {
        private int _nummer;
        private string _kleur;

        public int Nummer
        {
            get { return _nummer; }
            set { _nummer = value < 1 || value > 13 ? throw new ArgumentOutOfRangeException($"Nummer moet tussen 1 en 13 liggen") : _nummer = value; }
        }
        public string Kleur
        {
            get { return _kleur; }
            set { _kleur = value == "C" || value == "S" || value == "H" || value == "D" ? _kleur = value : throw new ArgumentOutOfRangeException($"Kleur moet tussen C,S,H en D liggen"); }
        }

        public Kaart(int n, string k)
        {
            Nummer = n;
            Kleur = k;
        }
    }
}
