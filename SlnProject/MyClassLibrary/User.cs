using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MyClassLibrary
{
   public class User
    {
        //variable
        private static string connString = ConfigurationManager.AppSettings["connString"];

        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? CreateDate { get; set; }
        public string Role { get; set; }
        public static List<User> GetAll()
        {
            List<User> users = new List<User>();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                // open connectie
                conn.Open();

                // voer SQL commando uit
                SqlCommand comm = new SqlCommand("SELECT * FROM [User]", conn);
                SqlDataReader reader = comm.ExecuteReader();

                // lees en verwerk resultaten

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["id"]);
                    string Login = Convert.ToString(reader["login"]);
                    string Password = Convert.ToString(reader["password"]);
                    string FirstName = Convert.ToString(reader["firstname"]);
                    string LastName = Convert.ToString(reader["lastname"]);
                    DateTime? CreateDate = reader["createdate"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["createdate"]);
                    string Role = Convert.ToString(reader["role"]);
                    users.Add(new User(id, Login, Password, FirstName, LastName, Role, CreateDate));
                }
            }
            return users;
        }

        public static User FindById(int empId)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                // open connectie
                conn.Open();

                // voer SQL commando uit
                SqlCommand comm = new SqlCommand("SELECT login, password, firstname, lastname, role, createdate FROM [User] WHERE ID = @parID", conn);
                comm.Parameters.AddWithValue("@parID", empId);
                SqlDataReader reader = comm.ExecuteReader();

                // lees en verwerk resultaten
                if (!reader.Read()) return null;
                string Login = Convert.ToString(reader["login"]);
                string Password = Convert.ToString(reader["password"]);
                string FirstName = Convert.ToString(reader["firstname"]);
                string LastName = Convert.ToString(reader["lastname"]);
                DateTime? CreateDate = reader["createdate"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["createdate"]);
                string Role = Convert.ToString(reader["role"]);
                return new User(empId, Login, Password, FirstName, LastName, Role, CreateDate);
            }
        }

        public static bool LoginInDb(string cp, string ps)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand comn = new SqlCommand("SELECT login, password FROM [User] WHERE login=@par1 AND password=@par2", conn);
                comn.Parameters.AddWithValue("@par1", cp);
                comn.Parameters.AddWithValue("@par2", ps);
                SqlDataReader reader = comn.ExecuteReader();

                if (reader.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public User()
        { 
        }

        public User(int id, string login, string password, string firstname, string lastname, string role, DateTime? cd)
        {
            Id = id;
            Login = login;
            Password = password;
            FirstName = firstname;
            LastName = lastname;
            Role = role;
            CreateDate = cd;
        }

        public override string ToString()
        {
            return $"{Id}: {FirstName} {LastName}";
        }

    }
}
