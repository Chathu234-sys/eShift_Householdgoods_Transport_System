using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eShiftCompany.Models;
using eShiftCompany.Repository.Interface;

namespace eShiftCompany.Repository.Services
{
    public class CustomerDashboardRepository : ICustomerDashboardRepository
    {
        private readonly string connectionString;

        public CustomerDashboardRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<string> GetCustomerIDs()
        {
            var ids = new List<string>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT RegNo FROM Customers", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ids.Add(reader["RegNo"].ToString());
                }
            }
            return ids;
        }

        public List<string> GetCategories()
        {
            var categories = new List<string>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT Category FROM Products", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    categories.Add(reader["Category"].ToString());
                }
            }
            return categories;
        }

        public List<string> GetItemsByCategory(string category)
        {
            var items = new List<string>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT ProductName FROM Products WHERE LOWER(Category) = LOWER(@cat)", conn);
                cmd.Parameters.AddWithValue("@cat", category);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    items.Add(reader["ProductName"].ToString());
                }
            }
            return items;
        }

        public int GetProductIdByName(string productName)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT ProductID FROM Products WHERE ProductName = @name", conn);
                cmd.Parameters.AddWithValue("@name", productName);
                object result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : -1;
            }
        }

        public int CreateJob(int customerId, string startLocation, string destination, decimal distance, int itemCount, string description, DateTime jobDate)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    string insertJob = "INSERT INTO Jobs (CustomerID, StartLocation, Destination, Distance, NumberOfItems, Description, JobDate) " +
                                       "OUTPUT INSERTED.JobID VALUES (@CustomerID, @StartLocation, @Destination, @Distance, @NumberOfItems, @Description, @JobDate)";
                    SqlCommand cmd = new SqlCommand(insertJob, conn, transaction);
                    cmd.Parameters.AddWithValue("@CustomerID", customerId);
                    cmd.Parameters.AddWithValue("@StartLocation", startLocation);
                    cmd.Parameters.AddWithValue("@Destination", destination);
                    cmd.Parameters.AddWithValue("@Distance", distance);
                    cmd.Parameters.AddWithValue("@NumberOfItems", itemCount);
                    cmd.Parameters.AddWithValue("@Description", description);
                    cmd.Parameters.AddWithValue("@JobDate", jobDate);

                    int jobId = (int)cmd.ExecuteScalar();
                    transaction.Commit();
                    return jobId;
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public void InsertJobItem(int jobId, int productId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO JobItems (JobID, ProductID) VALUES (@JobID, @ProductID)", conn);
                cmd.Parameters.AddWithValue("@JobID", jobId);
                cmd.Parameters.AddWithValue("@ProductID", productId);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
