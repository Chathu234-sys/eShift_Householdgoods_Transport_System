using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eShiftCompany.Models;
using eShiftCompany.Repository.Interface;
using System.Data.SqlClient;
using eShiftCompany.Repository.Services;

namespace eShiftCompany.Repository.Services
{
    public class PaymentsRepository : IPaymentsRepository
    {
        private readonly string connectionString;

        public PaymentsRepository(string connStr)
        {
            connectionString = connStr;
        }
        public PaymentsRepository()
        {
            connectionString = "Data Source=DESKTOP-62975O3\\SQLEXPRESS;Initial Catalog=eShift;Integrated Security=True;";
        }
        public List<int> GetPendingJobIDs()
        {
            var jobIds = new List<int>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT JobID FROM Jobs WHERE LOWER(Status) IN ('pending', 'accepted')", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    jobIds.Add(Convert.ToInt32(reader["JobID"]));
                }
            }

            return jobIds;
        }

        public decimal CalculateAmount(int jobId)
        {
            decimal totalAmount = 0;
            decimal distance = 0;
            int itemCount = 0;
            decimal productTotal = 0;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmdDistance = new SqlCommand("SELECT Distance FROM Jobs WHERE JobID = @JobID", conn);
                cmdDistance.Parameters.AddWithValue("@JobID", jobId);
                object result = cmdDistance.ExecuteScalar();

                if (result != null)
                    distance = Convert.ToDecimal(result);

                SqlCommand cmdItems = new SqlCommand(@"
                    SELECT P.Price FROM JobItems JI 
                    JOIN Products P ON JI.ProductID = P.ProductID 
                    WHERE JI.JobID = @JobID", conn);
                cmdItems.Parameters.AddWithValue("@JobID", jobId);
                SqlDataReader reader = cmdItems.ExecuteReader();
                while (reader.Read())
                {
                    productTotal += Convert.ToDecimal(reader["Price"]);
                    itemCount++;
                }
                reader.Close();

                totalAmount = productTotal + (distance * 100);

                SqlCommand updateCount = new SqlCommand("UPDATE Jobs SET NumberOfItems = @Count WHERE JobID = @JobID", conn);
                updateCount.Parameters.AddWithValue("@Count", itemCount);
                updateCount.Parameters.AddWithValue("@JobID", jobId);
                updateCount.ExecuteNonQuery();
            }

            return totalAmount;
        }

        public string GetCustomerEmailByJobID(int jobId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "SELECT c.Email FROM Jobs j JOIN Customers c ON j.CustomerID = c.RegNo WHERE j.JobID = @JobID", conn);
                cmd.Parameters.AddWithValue("@JobID", jobId);
                return Convert.ToString(cmd.ExecuteScalar());
            }
        }

        public void InsertPayment(PaymentsModel payment)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(@"
                    INSERT INTO Payments (JobID, CustomerID, Amount, PaymentStatus, PaymentDate)
                    SELECT @JobID, CustomerID, @Amount, @Status, @Date FROM Jobs WHERE JobID = @JobID", conn);
                cmd.Parameters.AddWithValue("@JobID", payment.JobID);
                cmd.Parameters.AddWithValue("@Amount", payment.Amount);
                cmd.Parameters.AddWithValue("@Status", payment.PaymentStatus);
                cmd.Parameters.AddWithValue("@Date", payment.PaymentDate);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateJobStatus(int jobId, string status)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(
                    "UPDATE Jobs SET PaymentStatus = @status, Status = @jobStatus WHERE JobID = @JobID", conn);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@jobStatus", status == "Completed" ? "In-Progress" : "Cancelled");
                cmd.Parameters.AddWithValue("@JobID", jobId);
                cmd.ExecuteNonQuery();
            }
        }

        public void CancelPayment(int jobId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("UPDATE Payments SET PaymentStatus = 'Cancelled' WHERE JobID = @JobID", conn);
                cmd.Parameters.AddWithValue("@JobID", jobId);
                cmd.ExecuteNonQuery();
            }
        }

        public List<PaymentsModel> GetAllPayments()
        {
            var payments = new List<PaymentsModel>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Payments", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    payments.Add(new PaymentsModel
                    {
                        PaymentID = Convert.ToInt32(reader["PaymentID"]),
                        JobID = Convert.ToInt32(reader["JobID"]),
                        CustomerID = Convert.ToInt32(reader["CustomerID"]),
                        Amount = Convert.ToDecimal(reader["Amount"]),
                        PaymentStatus = reader["PaymentStatus"].ToString(),
                        PaymentDate = Convert.ToDateTime(reader["PaymentDate"])
                    });
                }
            }

            return payments;
        }

        public List<int> GetPendingOrAcceptedJobIds()
        {
            var jobIds = new List<int>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT JobID FROM Jobs WHERE LOWER(Status) IN ('pending', 'accepted')", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    jobIds.Add(Convert.ToInt32(reader["JobID"]));
                }
            }
            return jobIds;
        }

        public string GetCustomerEmail(int jobId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT c.Email FROM Jobs j JOIN Customers c ON j.CustomerID = c.RegNo WHERE j.JobID = @JobID", conn);
                cmd.Parameters.AddWithValue("@JobID", jobId);
                return Convert.ToString(cmd.ExecuteScalar());
            }
        }

        public void ProcessPayment(int jobId, decimal amount)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Insert Payment
                var cmd = new SqlCommand(@"
            INSERT INTO Payments (JobID, CustomerID, Amount, PaymentStatus, PaymentDate)
            SELECT JobID, CustomerID, @Amount, 'Completed', GETDATE()
            FROM Jobs WHERE JobID = @JobID", conn);
                cmd.Parameters.AddWithValue("@Amount", amount);
                cmd.Parameters.AddWithValue("@JobID", jobId);
                cmd.ExecuteNonQuery();

                // Update Job Status and PaymentStatus
                var updateCmd = new SqlCommand("UPDATE Jobs SET PaymentStatus = 'Completed', Status = 'In-Progress' WHERE JobID = @JobID", conn);
                updateCmd.Parameters.AddWithValue("@JobID", jobId);
                updateCmd.ExecuteNonQuery();
            }
        }

        public void CancelJobPayment(int jobId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                var cmd = new SqlCommand("UPDATE Jobs SET Status = 'Cancelled', PaymentStatus = 'Cancelled' WHERE JobID = @JobID", conn);
                cmd.Parameters.AddWithValue("@JobID", jobId);
                cmd.ExecuteNonQuery();

                var cancelPaymentCmd = new SqlCommand("UPDATE Payments SET PaymentStatus = 'Cancelled' WHERE JobID = @JobID", conn);
                cancelPaymentCmd.Parameters.AddWithValue("@JobID", jobId);
                cancelPaymentCmd.ExecuteNonQuery();
            }
        }
    }
}
