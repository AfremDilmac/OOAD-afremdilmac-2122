using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyClassLibrary
{
   public class Option
    {
        private static string connString = ConfigurationManager.AppSettings["connString"];

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double PricePerDay { get; set; }

        public static List<Option> GetAll()
        {
            List<Option> users = new List<Option>();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                // open connectie
                conn.Open();

                // voer SQL commando uit
                SqlCommand comm = new SqlCommand("SELECT * FROM [Option]", conn);
                SqlDataReader reader = comm.ExecuteReader();

                // lees en verwerk resultaten

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["id"]);
                    string Name = Convert.ToString(reader["name"]);
                    string Description = Convert.ToString(reader["description"]);
                    double PricePerDay = Convert.ToDouble(reader["priceperday"]);

                    users.Add(new Option(id, Name, Description, PricePerDay));
                }
            }
            return users;
        }

        public Option()
        {
        }

        public Option(int id, string name, string description, double priceperday)
        {
            Id = id;
            Name = name;
            Description = description;
            PricePerDay = priceperday;
        }

        public override string ToString()
        {
            return $"{Name}: {Description}, €{PricePerDay}";
        }

    }
}
