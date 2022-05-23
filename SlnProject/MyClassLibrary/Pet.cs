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
        private static string connString = ConfigurationManager.AppSettings["connString"];
        public int Id { get; set; }
        public string Name { get; set; }
        public string Remarks { get; set; }
        public int Age { get; set; }
        public int Sex { get; set; }
        public int? Size { get; set; }
        public int UserId { get; set; }
        public string TypeName { get; set; }

        public static List<Pet> GetAll()
        {
            List<Pet> users = new List<Pet>();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                // open connectie
                conn.Open();

                // voer SQL commando uit
                SqlCommand comm = new SqlCommand("SELECT * FROM [Pet]", conn);
                SqlDataReader reader = comm.ExecuteReader();

                // lees en verwerk resultaten

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["id"]);
                    string name = Convert.ToString(reader["name"]);
                    string remarks = Convert.ToString(reader["remarks"]);
                    int sex = Convert.ToInt32(reader["sex"]);
                    int? size = reader["size"] == DBNull.Value ? null : (int?)Convert.ToInt32(reader["size"]);
                    int age = Convert.ToInt32(reader["age"]);
                    int userId = Convert.ToInt32(reader["user_id"]);
                    string typeName = Convert.ToString(reader["type_name"]);
                    users.Add(new Pet(id, name, remarks, sex, size, age, userId, typeName));
                }
            }
            return users;
        }
        public static List<Pet> GetAllPets(int id)
        {
            List<Pet> users = new List<Pet>();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                // open connectie
                conn.Open();

                // voer SQL commando uit
                SqlCommand comm = new SqlCommand("SELECT * FROM [Pet] WHERE ID IN (SELECT ID FROM [User]) ", conn);
                comm.Parameters.AddWithValue("@par1", id);
                SqlDataReader reader = comm.ExecuteReader();
                // lees en verwerk resultaten

                while (reader.Read())
                {
                    string name = Convert.ToString(reader["name"]);
                    string remarks = Convert.ToString(reader["remarks"]);
                    int sex = Convert.ToInt32(reader["sex"]);
                    int? size = reader["size"] == DBNull.Value ? null : (int?)Convert.ToInt32(reader["size"]);
                    int age = Convert.ToInt32(reader["age"]);
                    int userId = Convert.ToInt32(reader["user_id"]);
                    string typeName = Convert.ToString(reader["type_name"]);
                    users.Add(new Pet(id, name, remarks, sex, size, age, userId, typeName));
                }
            }
            return users;
        }

        public static Pet FindById(int empId)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                // open connectie
                conn.Open();

                // voer SQL commando uit
                SqlCommand comm = new SqlCommand("SELECT name, remarks, sex, size, age, user_id, type_name FROM [Pet] WHERE ID = @parID", conn);
                comm.Parameters.AddWithValue("@parID", empId);
                SqlDataReader reader = comm.ExecuteReader();

                // lees en verwerk resultaten
                if (!reader.Read()) return null;
                string name = Convert.ToString(reader["name"]);
                string remarks = Convert.ToString(reader["remarks"]);
                int sex = Convert.ToInt32(reader["sex"]);
                int? size = reader["size"] == DBNull.Value ? null : (int?)Convert.ToInt32(reader["size"]);
                int age = Convert.ToInt32(reader["age"]);
                int userId = Convert.ToInt32(reader["user_id"]);
                string typeName = Convert.ToString(reader["type_name"]);
                return new Pet(empId, name, remarks, sex, size, age, userId, typeName);
            }
        }

        public Pet()
        {
        }

        public Pet(int id, string name, string remarks, int age,int sex, int? size, int userid, string type)
        {
            Id = id;
            Name = name;
            Remarks = remarks;
            Sex = sex;
            Age = age;
            Size= size;
            UserId = userid;
            TypeName = type;
        }

        public Pet(int id, string name, string remarks, int sex, int? size, int age, int userId, string typeName)
        {
            Id = id;
            Name = name;
            Remarks = remarks;
            Sex = sex;
            Size = size;
            Age = age;
            UserId = userId;
            TypeName = typeName;
        }

        public override string ToString()
        {
            return $"{Id}: {Name} {TypeName} {UserId}";
        }
    }
}
