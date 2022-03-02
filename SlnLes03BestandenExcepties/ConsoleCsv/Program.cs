using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCsv
{
    class Program
    {
        static void Main(string[] args)
        {
            const int AANTAL_WEDSTRIJDEN = 100;

            string[] NaamSpelers = new string[] { "Bilal", "Zakaria", "Anthony", "Omar", "Rogier", "Serge" };
            string[] Spellen = new string[] { "Schaken", "Backgammon", "Dammen" };
            string[] Scores = new string[] { "1--2", "0--3", "2--1", "3--0" };

            int SpelerA;
            Random r = new Random();

            string csvDocument = " ";

            for (int i = 0; i < AANTAL_WEDSTRIJDEN; i++)
            {
                int SpelerB = r.Next(0, NaamSpelers.Length);
                SpelerA = r.Next(0, NaamSpelers.Length);
                int typeSpelKiezen = r.Next(0, Spellen.Length);

                int Punten = r.Next(0, Scores.Length);

                string typeSpel = Spellen[typeSpelKiezen];
                string score = Scores[Punten];
                string Speler1 = NaamSpelers[SpelerB];
                string Speler2 = NaamSpelers[SpelerA];

                csvDocument += $"{i + 1};{Speler1};{Speler2};{typeSpel};{score.ToString()}{Environment.NewLine}";
            }

            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = System.IO.Path.Combine(folderPath, "Wedstrijden.csv");

            using (StreamWriter writer = File.CreateText(filePath))
            {
                writer.WriteLine(csvDocument);
            }

            Console.WriteLine("csv document gemaakt op pc");
            Console.ReadKey();
        }
    }
}