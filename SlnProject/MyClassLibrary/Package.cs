using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLibrary
{
   public class Package
    {
        private static string connString = ConfigurationManager.AppSettings["connString"];

        public int Id { get; set; }
        public int PackageId { get; set; }
        public int OptionId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double PricePerDay { get; set; }
        public string PetTypeName { get; set; }

        public static List<Package> GetAll()
        {
            List<Package> users = new List<Package>();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                // open connectie
                conn.Open();

                // voer SQL commando uit
                SqlCommand comm = new SqlCommand("SELECT * FROM [Package]", conn);
                SqlDataReader reader = comm.ExecuteReader();

                // lees en verwerk resultaten

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["id"]);
                    string Name = Convert.ToString(reader["name"]);
                    string Description = Convert.ToString(reader["description"]);
                    double PricePerDay = Convert.ToDouble(reader["priceperday"]);
                    string PetTypeName = Convert.ToString(reader["pettype_name"]);

                    users.Add(new Package(id, Name, Description, PricePerDay, PetTypeName));
                }
            }
            return users;
        }

        public static Package FindById(int empId)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                // open connectie
                conn.Open();

                // voer SQL commando uit
                SqlCommand comm = new SqlCommand("SELECT name, description, priceperday, pettype_name FROM [Package] WHERE ID = @parID", conn);
                comm.Parameters.AddWithValue("@parID", empId);
                SqlDataReader reader = comm.ExecuteReader();

                // lees en verwerk resultaten
                if (!reader.Read()) return null;
                string Name = Convert.ToString(reader["name"]);
                string Description = Convert.ToString(reader["description"]);
                double PricePerDay = Convert.ToDouble(reader["priceperday"]);
                string PetTypeName = Convert.ToString(reader["pettype_name"]);
                return new Package(empId, Name, Description, PricePerDay, PetTypeName);
            }
        }

        public static Package FindPackagesForPet(int empId)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                // open connectie
                conn.Open();

                // voer SQL commando uit
                SqlCommand comm = new SqlCommand("SELECT pk.name, pk.description, pk.priceperday FROM [Package] pk JOIN [Pet] pt ON pk.pettype_name = pt.type_name WHERE package_id = @parID", conn);
                comm.Parameters.AddWithValue("@parID", empId);
                SqlDataReader reader = comm.ExecuteReader();

                // lees en verwerk resultaten
                if (!reader.Read()) return null;
                string Name = Convert.ToString(reader["name"]);
                string Description = Convert.ToString(reader["description"]);
                double PricePerDay = Convert.ToDouble(reader["priceperday"]);
                return new Package(Name, Description, PricePerDay);
            }
        }

        public static List<Package> GetAllPackageOptions()
        {
            List<Package> users = new List<Package>();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                // open connectie
                conn.Open();

                // voer SQL commando uit
                SqlCommand comm = new SqlCommand("SELECT * FROM [PackageOption]", conn);
                SqlDataReader reader = comm.ExecuteReader();

                // lees en verwerk resultaten

                while (reader.Read())
                {
                    int packageid = Convert.ToInt32(reader["package_id"]);
                    int optionid = Convert.ToInt32(reader["option_id"]);

                    users.Add(new Package(packageid, optionid));
                }
            }
            return users;
        }

        public static Package FindPackageOptionById(int empId)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                // open connectie
                conn.Open();

                // voer SQL commando uit
                SqlCommand comm = new SqlCommand("SELECT option_id FROM [PackageOption] WHERE package_id = @parID", conn);
                comm.Parameters.AddWithValue("@parID", empId);
                SqlDataReader reader = comm.ExecuteReader();

                // lees en verwerk resultaten
                if (!reader.Read()) return null;
                int OptionId = Convert.ToInt32(reader["option_id"]);
                return new Package(empId, OptionId);
            }
        }

        public static Package GetAllOptionsById(int empId)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                // open connectie
                conn.Open();

                // voer SQL commando uit
                SqlCommand comm = new SqlCommand("SELECT op.id, op.name, op.description, op.priceperday FROM [Option] op JOIN [PackageOption] po ON op.id = po.option_id WHERE package_id = @parID", conn);
                comm.Parameters.AddWithValue("@parID", empId);
                SqlDataReader reader = comm.ExecuteReader();

                // lees en verwerk resultaten
                if (!reader.Read()) return null;
                int id = Convert.ToInt32(reader["id"]);
                string Name = Convert.ToString(reader["name"]);
                string Description = Convert.ToString(reader["description"]);
                double PricePerDay = Convert.ToDouble(reader["priceperday"]);
                return new Package(empId, id, Name, Description, PricePerDay);
            }
        }



        public Package()
        { 
        }

        public Package(int packageid, int optionid)
        {
            PackageId = packageid;
            OptionId = optionid;
        }

        public Package(int id, string name, string description, double priceperday)
        {
            Id = id;
            Name = name;
            Description = description;
            PricePerDay = priceperday;
        }

        public Package(int id, string name, string description, double priceperday, string pettypename)
        {
            Id = id;
            Name = name;
            Description = description;
            PricePerDay = priceperday;
            PetTypeName = pettypename;
        }

        public Package(int packageid, int optionid, string name, string description, double pricePerDay) : this(packageid, optionid)
        {
            Name = name;
            Description = description;
            PricePerDay = pricePerDay;
        }

        public Package(string name, string description, double pricePerDay)
        {
            Name = name;
            Description = description;
            PricePerDay = pricePerDay;
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
