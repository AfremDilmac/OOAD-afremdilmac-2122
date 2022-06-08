using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;


namespace MyClassLibrary
{
    public class Foto
    {
        private static string connString = ConfigurationManager.AppSettings["connString"];
        public int Id { get; set; }
        public int? ResidencyId { get; set; }
        public int PetId { get; set; }
        public BitmapImage Image { get; set; }

        public static List<Foto> GetAll()
        {
            List<Foto> items = new List<Foto>();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                // open connectie
                conn.Open();

                // voer SQL commando uit
                SqlCommand comm = new SqlCommand("SELECT * FROM [Photo]", conn);
                SqlDataReader reader = comm.ExecuteReader();

                // lees en verwerk resultaten

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["id"]);
                    BitmapImage image = new BitmapImage();
                    image.BeginInit();
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.StreamSource = new System.IO.MemoryStream((byte[])reader["data"]);
                    image.EndInit();
                    int? residency_id = reader["residency_id"] == DBNull.Value ? null : (int?)Convert.ToInt32(reader["residency_id"]);
                    int pet_id = Convert.ToInt32(reader["pet_id"]);
                    items.Add(new Foto(id, image, residency_id, pet_id));
                }
            }
            return items;
        }

        public static List<Foto> GetPetById(int id)
        {
            List<Foto> users = new List<Foto>();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand("SELECT * from [Photo] WHERE pet_id = @parID", conn);
                comm.Parameters.AddWithValue("@parID", id);
                SqlDataReader reader = comm.ExecuteReader();

                if (!reader.Read()) return null;
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = new System.IO.MemoryStream((byte[])reader["data"]);
                image.EndInit();
                int? residency_id = reader["residency_id"] == DBNull.Value ? null : (int?)Convert.ToInt32(reader["residency_id"]);
                int pet_id = Convert.ToInt32(reader["pet_id"]);
                users.Add(new Foto(id,image, residency_id, pet_id));
            }
            return users;
        }

        public static List<Foto> GetResidencyById(int id)
        {
            List<Foto> users = new List<Foto>();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand("SELECT * from [Photo] WHERE residency_id = @parID", conn);
                comm.Parameters.AddWithValue("@parID", id);
                SqlDataReader reader = comm.ExecuteReader();

                if (!reader.Read()) return null;
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = new System.IO.MemoryStream((byte[])reader["data"]);
                image.EndInit();
                int? residency_id = reader["residency_id"] == DBNull.Value ? null : (int?)Convert.ToInt32(reader["residency_id"]);
                int pet_id = Convert.ToInt32(reader["pet_id"]);
                users.Add(new Foto(id, image, residency_id, pet_id));
            }
            return users;
        }

        public Foto(int id, BitmapImage image, int? rd, int pi)
        {
            Id = id;
            Image = image;
            ResidencyId = rd;
            PetId = pi;
        }

        public override string ToString()
        {
            return $"{PetId}";
        }

    }
}
