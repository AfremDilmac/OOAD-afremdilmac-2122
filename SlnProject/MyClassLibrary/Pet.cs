using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLibrary
{
    public class Pet
    {
        public string Name { get; set; }

        //public static List<Pet> GetAllPets()
        //{
        //    List<Pet> pets = new List<Pet>();

        //    string connString = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
        //    using (SqlConnection conn = new SqlConnection(connString))
        //    {
        //        conn.Open();
        //        SqlCommand comm = new SqlCommand("SELECT * FROM Medewerker", conn);
        //        SqlDataReader reader = comm.ExecuteReader();

        //    }

        //}
    }
}
