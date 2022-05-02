using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleKassaTicket
{
    class Product
    {
        private string _code;
        private const int AANTAL_TEKENS = 6;
        public string Naam { get; set; }
        public decimal EenheidPrijs { get; set; }
        public string Code
        {
            get { return _code; }
            set
            {
                if (value.Substring(0, 1) == "P" && value.Length == AANTAL_TEKENS)
                {
                    _code = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException($"Code moet met p beginnen en 5 cijfers");
                }
            }
        }

        public Product(string code, string naam, decimal eenheidsprijs)
        {
            Naam = naam;
            EenheidPrijs = eenheidsprijs;
            Code = code;
        }

        public static bool ValideerCode(string code)
        {
            return code.Substring(0, 1) == "P" && code.Length == AANTAL_TEKENS;
        }
        public override string ToString()
        {
            return $"{Code} {Naam} {EenheidPrijs}";
        }
    }
}
