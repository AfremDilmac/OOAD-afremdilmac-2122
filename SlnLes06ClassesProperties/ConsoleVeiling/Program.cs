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
            //Kopers
            Koper koperAfrem = new Koper("Afrem");
            Koper koperOmar = new Koper("Omar");
            Koper koperGeert = new Koper("Geert");

            //Items
            Item item1 = new Item("Apple Laptop", 220);
            Item item2 = new Item("Playstation 5", 500);
            Item item3 = new Item("Coca cola vanille", 1);
            Item item4 = new Item("Huawei Laptop", 300);

            //Bod
            item1.AddBod(new Bod(270, item1, koperAfrem));
            item1.AddBod(new Bod(290, item1, koperOmar));
            item1.AddBod(new Bod(300, item1, koperGeert));
            item1.AddBod(new Bod(400, item1, koperAfrem));
            //item1.AddBod(new Bod(50, item1, koperOmar));

            //Einde biedingen
            Bod hoogsteItem1 = item1.HoogsteBod;
            if (hoogsteItem1 == null)
            {
                Console.WriteLine("Nog geen bod");
            }
            else
            {
               Console.WriteLine($"Hoogste bod is {hoogsteItem1.Prijs}, gedaan door {hoogsteItem1.Koper.Naam}");
                item1.HoogsteBod.Koper.Items.Add(item1);
            }

            //Bod
            item2.AddBod(new Bod(550, item2, koperAfrem));
            item2.AddBod(new Bod(600, item2, koperOmar));
            item2.AddBod(new Bod(620, item2, koperGeert));
            item2.AddBod(new Bod(800, item2, koperAfrem));

            //Einde biedingen
            Bod hoogsteItem2 = item2.HoogsteBod;
            if (hoogsteItem2 == null)
            {
                Console.WriteLine("Nog geen bod");
            }
            else
            {
                Console.WriteLine($"Hoogste bod is {hoogsteItem2.Prijs}, gedaan door {hoogsteItem2.Koper.Naam}");
                item2.HoogsteBod.Koper.Items.Add(item2);
            }

            //Bod
            item3.AddBod(new Bod(5, item3, koperAfrem));
            item3.AddBod(new Bod(10, item3, koperOmar));
            item3.AddBod(new Bod(30, item3, koperGeert));
            item3.AddBod(new Bod(100, item3, koperOmar));

            //Einde biedingen
            Bod hoogsteItem3 = item3.HoogsteBod;
            if (hoogsteItem3 == null)
            {
                Console.WriteLine("Nog geen bod");
            }
            else
            {
                Console.WriteLine($"Hoogste bod is {hoogsteItem3.Prijs}, gedaan door {hoogsteItem3.Koper.Naam}");
                item3.HoogsteBod.Koper.Items.Add(item3);
            }

            //Bod
            item4.AddBod(new Bod(550, item4, koperAfrem));
            item4.AddBod(new Bod(600, item4, koperOmar));
            item4.AddBod(new Bod(620, item4, koperGeert));
            item4.AddBod(new Bod(800, item4, koperAfrem));
            item4.AddBod(new Bod(1000, item4, koperGeert));

            //Einde biedingen
            Bod hoogsteItem4 = item4.HoogsteBod;
            if (hoogsteItem4 == null)
            {
                Console.WriteLine("Nog geen bod");
            }
            else
            {
                Console.WriteLine($"Hoogste bod is {hoogsteItem4.Prijs}, gedaan door {hoogsteItem4.Koper.Naam}");
                item4.HoogsteBod.Koper.Items.Add(item4);
            }

            foreach (Item item in koperAfrem.Items)
            {
                Console.WriteLine($"{item.HoogsteBod.Koper.Naam}: {item.Naam} - {item.HoogsteBod.Prijs}");
            }
            foreach (Item item in koperGeert.Items)
            {
                Console.WriteLine($"{item.HoogsteBod.Koper.Naam}: {item.Naam} - {item.HoogsteBod.Prijs}");
            }
            foreach (Item item in koperOmar.Items)
            {
                Console.WriteLine($"{item.HoogsteBod.Koper.Naam}: {item.Naam} - {item.HoogsteBod.Prijs}");
            }
            Console.ReadLine();
        } 
    }
}
