using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLibrary
{
    public class Residency
    {
        //variable
        private static string connString = ConfigurationManager.AppSettings["connString"];
  

        public int Id { get; set; }
        public DateTime? Startdate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Remarks { get; set; }
        public int PackageId { get; set; }
        public int PetId { get; set; }
        public int Status { get; set; }

        public static List<Residency> GetAll()
        {
            List<Residency> users = new List<Residency>();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                // open connectie
                conn.Open();

                // voer SQL commando uit
                SqlCommand comm = new SqlCommand("SELECT * FROM [Residency]", conn);
                SqlDataReader reader = comm.ExecuteReader();

                // lees en verwerk resultaten

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["id"]);
                    DateTime? StartDate = reader["startdate"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["startdate"]);
                    DateTime? EndDate = reader["enddate"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["enddate"]);
                    string Remarks = Convert.ToString(reader["remarks"]);
                    int PackageId = Convert.ToInt32(reader["package_id"]);
                    int PetId = Convert.ToInt32(reader["pet_id"]);
                    int Status = Convert.ToInt32(reader["status"]);
                    users.Add(new Residency(id, StartDate, EndDate, Remarks, PackageId, PetId, Status));
                }
            }
            return users;
        }

        public static List<Residency> GetAllResidence(int id)
        {
            List<Residency> users = new List<Residency>();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                // open connectie
                conn.Open();

                // voer SQL commando uit
                SqlCommand comm = new SqlCommand("SELECT * FROM [Residency] WHERE ID IN (SELECT pet_id FROM [Residency]) ", conn);
                comm.Parameters.AddWithValue("@par1", id);
                SqlDataReader reader = comm.ExecuteReader();
                // lees en verwerk resultaten

                while (reader.Read())
                {
                    DateTime? StartDate = reader["startdate"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["startdate"]);
                    DateTime? EndDate = reader["enddate"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["enddate"]);
                    string Remarks = Convert.ToString(reader["remarks"]);
                    int PackageId = Convert.ToInt32(reader["package_id"]);
                    int PetId = Convert.ToInt32(reader["pet_id"]);
                    int Status = Convert.ToInt32(reader["status"]);
                    users.Add(new Residency(id, StartDate, EndDate, Remarks, PackageId, PetId, Status));
                }
            }
            return users;
        }

        public static Residency FindById(int empId)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                // open connectie
                conn.Open();

                // voer SQL commando uit
                SqlCommand comm = new SqlCommand("SELECT startdate, enddate, remarks, package_id, pet_id, status FROM [Residency] WHERE ID = @parID", conn);
                comm.Parameters.AddWithValue("@parID", empId);
                SqlDataReader reader = comm.ExecuteReader();

                // lees en verwerk resultaten
                if (!reader.Read()) return null;
                DateTime? StartDate = reader["startdate"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["startdate"]);
                DateTime? EndDate = reader["enddate"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["enddate"]);
                string Remarks = Convert.ToString(reader["remarks"]);
                int PackageId = Convert.ToInt32(reader["package_id"]);
                int PetId = Convert.ToInt32(reader["pet_id"]);
                int Status = Convert.ToInt32(reader["status"]);
                return new Residency(empId, StartDate, EndDate, Remarks, PackageId, PetId, Status);
            }
        }

        public void Update()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand(@"UPDATE [Residency] SET startdate=@parA, enddate=@parB, remarks=@parC, package_id=@parD, pet_id=@parE, status=@parF WHERE id = @parID", conn);
                comm.Parameters.AddWithValue("@parA", Startdate);
                comm.Parameters.AddWithValue("@parB", EndDate);
                comm.Parameters.AddWithValue("@parC", Remarks);
                comm.Parameters.AddWithValue("@parD", PackageId);
                comm.Parameters.AddWithValue("@parE", PetId);
                comm.Parameters.AddWithValue("@parF", Status);
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
                  "INSERT INTO [Residency](startdate,enddate,remarks,package_id,pet_id,status) output INSERTED.ID VALUES(@par1,@par2,@par3,@par4,@par5,@par6)", conn);
                comm.Parameters.AddWithValue("@par1", Startdate);
                comm.Parameters.AddWithValue("@par2", EndDate);
                comm.Parameters.AddWithValue("@par3", Remarks);
                comm.Parameters.AddWithValue("@par4", PackageId);
                comm.Parameters.AddWithValue("@par5", PetId);
                comm.Parameters.AddWithValue("@par6", Status);

                comm.ExecuteNonQuery();
            }
        }
        public Residency(int id, DateTime? startDate, DateTime? endDate, string remarks, int packageId, int petId, int status)
        {
            Id = id;
            Startdate = startDate;
            EndDate = endDate;
            Remarks = remarks;
            PackageId = packageId;
            PetId = petId;
            Status = status;
        }

        public Residency()
        {
        }

        public override string ToString()
        {
            return $"{Id}: {PetId} -> {Startdate} - {EndDate}";
        }
        
    }
}
