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

        public static List<User> GetAllClients()
        {
            List<User> users = new List<User>();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                // open connectie
                conn.Open();

                // voer SQL commando uit
                SqlCommand comm = new SqlCommand("SELECT * FROM [User] WHERE role=@user", conn);
                comm.Parameters.AddWithValue("@user", "user");
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

        public static bool LoginInDbUser(string cp, string ps)
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

        public static bool LoginInDbAdmin(string cp, string ps)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand comn = new SqlCommand("SELECT login, password FROM [User] WHERE login=@par1 AND password=@par2 AND role=@user", conn);
                comn.Parameters.AddWithValue("@par1", cp);
                comn.Parameters.AddWithValue("@par2", ps);
                comn.Parameters.AddWithValue("@user", "admin");
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

        public static User GetId(string name)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                // open connectie
                conn.Open();

                // voer SQL commando uit
                SqlCommand comm = new SqlCommand("SELECT id FROM [User] WHERE login = @Par1", conn);
                comm.Parameters.AddWithValue("@Par1", name);
                SqlDataReader reader = comm.ExecuteReader();

                // lees en verwerk resultaten
                if (!reader.Read()) return null;
                
                int Id = Convert.ToInt32(reader["id"]);
                return new User(Id);
            }
        }

        public void DeleteFromDb()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand("DELETE FROM [User] WHERE ID = @par1", conn);
                comm.Parameters.AddWithValue("@par1", Id);
                comm.ExecuteNonQuery();
            }
        }

        public void UpdateUser()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand(@"UPDATE [User] SET login=@parA, password=@parB, firstname=@parC, lastname=@parD, role=@parE WHERE id = @parID", conn);
                comm.Parameters.AddWithValue("@parA", Login);
                comm.Parameters.AddWithValue("@parB", Password);
                comm.Parameters.AddWithValue("@parC", FirstName);
                comm.Parameters.AddWithValue("@parD", LastName);
                comm.Parameters.AddWithValue("@parE", Role);
                comm.Parameters.AddWithValue("@parID", Id);
                comm.ExecuteNonQuery();
            }
        }

        public void InsertToDb()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand(
                  "INSERT INTO [User](login,password,firstname,lastname,role) output INSERTED.ID VALUES(@par1,@par2,@par3,@par4,@par5)", conn);
                comm.Parameters.AddWithValue("@par1", Login);
                comm.Parameters.AddWithValue("@par2", Password);
                comm.Parameters.AddWithValue("@par3", FirstName);
                comm.Parameters.AddWithValue("@par4", LastName);
                comm.Parameters.AddWithValue("@par5", Role);
                comm.ExecuteNonQuery();
            }
        }


        public User()
        { 
        }
        public User(int id)
        {
            Id = id;
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
