using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using eShiftCompany.Business.Interface;
using eShiftCompany.Models;
using eShiftCompany.Repository.Interface;

namespace eShiftCompany.Repository.Services
{
    public class ManageStatusRepository : IManageStatusRepository
    {
        private readonly string connectionString = "Data Source=DESKTOP-62975O3\\SQLEXPRESS;Initial Catalog=eShift;Integrated Security=True;";

        public List<ManageStatusModel> GetAllJobs()
        {
            List<ManageStatusModel> jobs = new List<ManageStatusModel>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Jobs";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    jobs.Add(new ManageStatusModel
                    {
                        JobID = Convert.ToInt32(reader["JobID"]),
                        Status = reader["Status"].ToString(),
                        PaymentStatus = reader["PaymentStatus"].ToString(),
                        StartLocation = reader["StartLocation"].ToString(),
                        Destination = reader["Destination"].ToString(),
                        Distance = Convert.ToDecimal(reader["Distance"]),
                        NumberOfItems = Convert.ToInt32(reader["NumberOfItems"]),
                        Description = reader["Description"].ToString(),
                        JobDate = Convert.ToDateTime(reader["JobDate"])
                    });
                }
            }

            return jobs;
        }

        public bool UpdateJobStatus(int jobId, string newStatus)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Jobs SET Status = @Status WHERE JobID = @JobID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Status", newStatus);
                cmd.Parameters.AddWithValue("@JobID", jobId);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool UpdateJobDetails(ManageStatusModel job)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"UPDATE Jobs 
                                SET StartLocation = @StartLocation,
                                    Destination = @Destination,
                                    Distance = @Distance,
                                    NumberOfItems = @NumberOfItems,
                                    Description = @Description,
                                    JobDate = @JobDate
                                WHERE JobID = @JobID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@StartLocation", job.StartLocation);
                cmd.Parameters.AddWithValue("@Destination", job.Destination);
                cmd.Parameters.AddWithValue("@Distance", job.Distance);
                cmd.Parameters.AddWithValue("@NumberOfItems", job.NumberOfItems);
                cmd.Parameters.AddWithValue("@Description", job.Description);
                cmd.Parameters.AddWithValue("@JobDate", job.JobDate);
                cmd.Parameters.AddWithValue("@JobID", job.JobID);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public ManageStatusModel GetJobById(int jobId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Jobs WHERE JobID = @JobID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@JobID", jobId);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new ManageStatusModel
                    {
                        JobID = Convert.ToInt32(reader["JobID"]),
                        Status = reader["Status"].ToString(),
                        PaymentStatus = reader["PaymentStatus"].ToString(),
                        StartLocation = reader["StartLocation"].ToString(),
                        Destination = reader["Destination"].ToString(),
                        Distance = Convert.ToDecimal(reader["Distance"]),
                        NumberOfItems = Convert.ToInt32(reader["NumberOfItems"]),
                        Description = reader["Description"].ToString(),
                        JobDate = Convert.ToDateTime(reader["JobDate"])
                    };
                }
            }

            return null;
        }
    }
}
