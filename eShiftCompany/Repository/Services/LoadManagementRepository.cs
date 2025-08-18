using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eShiftCompany.Models;
using eShiftCompany.Repository.Interface;
using System.Data;

namespace eShiftCompany.Repository.Services
{
    public class LoadManagementRepository : ILoadManagementRepository
    {
        private readonly string connectionString = "Data Source=DESKTOP-62975O3\\SQLEXPRESS;Initial Catalog=eShift;Integrated Security=True;";

        public void AddLoad(LoadManagementModel load)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Loads 
                                (JobID, Description, Weight, Volume, SpecialHandling, LorryID, DriverID, AssistantID, ContainerID)
                                VALUES 
                                (@JobID, @Description, @Weight, @Volume, @SpecialHandling, @LorryID, @DriverID, @AssistantID, @ContainerID)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@JobID", load.JobID);
                cmd.Parameters.AddWithValue("@Description", load.Description);
                cmd.Parameters.AddWithValue("@Weight", load.Weight);
                cmd.Parameters.AddWithValue("@Volume", load.Volume);
                cmd.Parameters.AddWithValue("@SpecialHandling", load.SpecialHandling);
                cmd.Parameters.AddWithValue("@LorryID", load.LorryID);
                cmd.Parameters.AddWithValue("@DriverID", load.DriverID);
                cmd.Parameters.AddWithValue("@AssistantID", load.AssistantID);
                cmd.Parameters.AddWithValue("@ContainerID", load.ContainerID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateLoad(LoadManagementModel load)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"UPDATE Loads SET 
                                JobID=@JobID, Description=@Description, Weight=@Weight, Volume=@Volume,
                                SpecialHandling=@SpecialHandling, LorryID=@LorryID, DriverID=@DriverID,
                                AssistantID=@AssistantID, ContainerID=@ContainerID
                                WHERE LoadID=@LoadID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@LoadID", load.LoadID);
                cmd.Parameters.AddWithValue("@JobID", load.JobID);
                cmd.Parameters.AddWithValue("@Description", load.Description);
                cmd.Parameters.AddWithValue("@Weight", load.Weight);
                cmd.Parameters.AddWithValue("@Volume", load.Volume);
                cmd.Parameters.AddWithValue("@SpecialHandling", load.SpecialHandling);
                cmd.Parameters.AddWithValue("@LorryID", load.LorryID);
                cmd.Parameters.AddWithValue("@DriverID", load.DriverID);
                cmd.Parameters.AddWithValue("@AssistantID", load.AssistantID);
                cmd.Parameters.AddWithValue("@ContainerID", load.ContainerID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteLoad(int loadId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Loads WHERE LoadID=@LoadID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@LoadID", loadId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public LoadManagementModel GetLoadById(int loadId)
        {
            LoadManagementModel load = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Loads WHERE LoadID=@LoadID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@LoadID", loadId);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    load = new LoadManagementModel
                    {
                        LoadID = (int)dr["LoadID"],
                        JobID = (int)dr["JobID"],
                        Description = dr["Description"].ToString(),
                        Weight = (decimal)dr["Weight"],
                        Volume = (decimal)dr["Volume"],
                        SpecialHandling = dr["SpecialHandling"].ToString(),
                        LorryID = (int)dr["LorryID"],
                        DriverID = (int)dr["DriverID"],
                        AssistantID = (int)dr["AssistantID"],
                        ContainerID = (int)dr["ContainerID"]
                    };
                }
            }
            return load;
        }

        public DataTable GetAllLoads()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Loads", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable GetLoadsByJobId(int jobId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Loads WHERE JobID=@JobID", conn);
                da.SelectCommand.Parameters.AddWithValue("@JobID", jobId);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable GetPendingJobs()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT JobID, CustomerID, StartLocation, Destination, JobDate FROM Jobs WHERE Status = 'Pending'", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}
