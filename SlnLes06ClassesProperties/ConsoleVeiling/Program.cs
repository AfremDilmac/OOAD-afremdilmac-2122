using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleVeiling
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> koper1Items = new List<string>(3);
            List<string> koper2Items = new List<string>(3);
            List<string> koper3Items = new List<string>(3);

            Item item1 = new Item("Apple Laptop");
            Item item2 = new Item("Playstation 5");
            Item item3 = new Item("Coca cola vanille");
            Item item4 = new Item("Huawei Laptop");

            Koper koper1 = new Koper("Afrem");
            Koper koper2 = new Koper("Hasbulla");
            Koper koper3 = new Koper("Batman");

            Bod bod1 = new Bod(400);
            Bod bod2 = new Bod(450);
            Bod bod3 = new Bod(500);
            Bod bod4 = new Bod(4);
            Bod bod5 = new Bod(700);

            Console.WriteLine($"Item te koop: {item1.Naam}!");
            Console.WriteLine($"{koper1.Naam} bied {bod1._nummer}");

            Timer();
            Console.WriteLine($"Proficiat aan {koper1.Naam} voor {item1.Naam}");
            koper1Items.Add(item1.Naam);

            Console.WriteLine("");

            Console.WriteLine($"Item te koop: {item4.Naam}!");
            Console.WriteLine($"{koper1.Naam} bied {bod5._nummer}");

            Timer();
            Console.WriteLine($"Proficiat aan {koper1.Naam} voor {item4.Naam}");
            koper1Items.Add(item4.Naam);

            Console.WriteLine("");


            Console.WriteLine($"Item te koop: {item2.Naam}!");
          
            Console.WriteLine($"{koper3.Naam} bied {bod2._nummer}");
           
            try
            {
                if (bod3._nummer > bod2._nummer)
                {
                    Console.WriteLine($"{koper2.Naam} bied {bod3._nummer}");
                    Timer();
                    Console.WriteLine($"Proficiat aan {koper2.Naam} voor {item2.Naam}");
                    koper2Items.Add(item2.Naam);
                }
                else
                {
                    Console.WriteLine("test" + bod3._nummer);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            Console.WriteLine("");
            Console.WriteLine($"Item te koop: {item3.Naam}!");
            Console.WriteLine($"{koper3.Naam} bied {bod4._nummer}");
            Timer();
            koper3Items.Add(item3.Naam);
            Console.WriteLine($"Proficiat aan {koper3.Naam} voor {item3.Naam}");
            Console.WriteLine("");

            Console.WriteLine($"{koper1.Naam} Items: ");
            foreach (string item in koper1Items)
            {
                Console.WriteLine(item);
                Console.WriteLine("");
            }
            Console.WriteLine($"{koper2.Naam} Items: ");
            foreach (string item in koper2Items)
            {
              
                Console.WriteLine(item);
                Console.WriteLine("");

            }
            Console.WriteLine($"{koper3.Naam} Items: ");
            foreach (string item in koper3Items)
            {
                Console.WriteLine(item);
                Console.WriteLine("");
            }

            Console.ReadLine();
        }

        public static void Timer() {
            Console.WriteLine("Timer start:");
            for (int i = 1; i < 4; i++)
            {
                Console.WriteLine("Tot drie tellen: " + i);
                Thread.Sleep(2000);
            }
            Console.WriteLine("Sold!");
        }
       
    }
}
