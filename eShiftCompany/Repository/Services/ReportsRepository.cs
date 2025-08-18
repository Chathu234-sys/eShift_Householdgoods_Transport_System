using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eShiftCompany.Repository.Interface;
using System.Data;
using System.Data.SqlClient;

namespace eShiftCompany.Repository.Services
{
    public class ReportsRepository : IReportsRepository
    {
        private readonly string connectionString = "Data Source=DESKTOP-62975O3\\SQLEXPRESS;Initial Catalog=eShift;Integrated Security=True;";

        public DataTable GetJobUtilization(DateTime from, DateTime to)
        {
            string query = "SELECT J.JobID, CONVERT(VARCHAR(10), J.JobDate, 103) AS JobDate, L.PlateNumber, L.Model FROM Jobs J JOIN Loads LD ON J.JobID = LD.JobID JOIN Lorries L ON LD.LorryID = L.LorryID WHERE J.JobDate BETWEEN @From AND @To";
            return ExecuteQuery(query, from, to);
        }

        public DataTable GetAllJobDetails(DateTime from, DateTime to)
        {
            string query = "SELECT J.JobID, CONVERT(VARCHAR(10), J.JobDate, 103) AS JobDate, J.StartLocation, J.Destination, J.Distance, J.Status, J.PaymentStatus, J.NumberOfItems, C.RegNo AS CustomerID, C.Name AS CustomerName, C.Email, C.Contact FROM Jobs J JOIN Customers C ON J.CustomerID = C.RegNo WHERE J.JobDate BETWEEN @From AND @To";
            return ExecuteQuery(query, from, to);
        }

        public DataTable GetPayments(DateTime from, DateTime to)
        {
            string query = "SELECT P.PaymentID, P.Amount, P.PaymentStatus, CONVERT(VARCHAR(10), P.PaymentDate, 103) AS PaymentDate, C.Name AS CustomerName FROM Payments P JOIN Customers C ON P.CustomerID = C.RegNo WHERE P.PaymentDate BETWEEN @From AND @To";
            return ExecuteQuery(query, from, to);
        }

        public DataTable GetCustomers()
        {
            string query = "SELECT RegNo, Name, Email, Contact, Address FROM Customers";
            return ExecuteQuery(query);
        }

        public DataTable GetEmployees()
        {
            string query = "SELECT EmployeeID AS ID, Name, NIC, Contact, Age, Gender, Role, Email FROM Employees";
            return ExecuteQuery(query);
        }

        private DataTable ExecuteQuery(string query, DateTime? from = null, DateTime? to = null)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                if (from.HasValue && to.HasValue)
                {
                    cmd.Parameters.AddWithValue("@From", from);
                    cmd.Parameters.AddWithValue("@To", to);
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}
