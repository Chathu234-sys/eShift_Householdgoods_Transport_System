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
    public class MyHistoryRepository : IMyHistoryRepository
    {
        private readonly string connectionString;

        public MyHistoryRepository(string connStr)
        {
            connectionString = connStr;
        }

        public (string Name, string Email, string Contact) GetCustomerProfile(int customerId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT Name, Email, Contact FROM Customers WHERE RegNo = @CustomerID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CustomerID", customerId);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return (
                        reader["Name"].ToString(),
                        reader["Email"].ToString(),
                        reader["Contact"].ToString()
                    );
                }
            }

            return ("", "", "");
        }

        public List<MyHistoryModel> GetUpcomingJobs(int customerId)
        {
            var list = new List<MyHistoryModel>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"SELECT JobID, StartLocation, Destination, JobDate, Status 
                                 FROM Jobs 
                                 WHERE CustomerID = @CustomerID AND Status IN ('Pending', 'Accepted', 'In-Progress')";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CustomerID", customerId);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new MyHistoryModel
                    {
                        JobID = Convert.ToInt32(reader["JobID"]),
                        StartLocation = reader["StartLocation"].ToString(),
                        Destination = reader["Destination"].ToString(),
                        JobDate = Convert.ToDateTime(reader["JobDate"]),
                        Status = reader["Status"].ToString()
                    });
                }
            }

            return list;
        }

        public List<MyHistoryModel> GetJobHistory(int customerId)
        {
            var list = new List<MyHistoryModel>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"SELECT JobID, StartLocation, Destination, JobDate, Status 
                                 FROM Jobs 
                                 WHERE CustomerID = @CustomerID AND Status IN ('Completed', 'Cancelled', 'Declined')";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CustomerID", customerId);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new MyHistoryModel
                    {
                        JobID = Convert.ToInt32(reader["JobID"]),
                        StartLocation = reader["StartLocation"].ToString(),
                        Destination = reader["Destination"].ToString(),
                        JobDate = Convert.ToDateTime(reader["JobDate"]),
                        Status = reader["Status"].ToString()
                    });
                }
            }

            return list;
        }
    }
}
