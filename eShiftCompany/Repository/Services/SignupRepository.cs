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
    public class SignupRepository : ISignupRepository
    {
        private readonly string connectionString = "Data Source=DESKTOP-62975O3\\SQLEXPRESS;Initial Catalog=eShift;Integrated Security=True;";

        public void InsertCustomer(SignupModel model)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO Customers (Name, Username, Password, Email, Contact, Address, NIC) " +
                               "VALUES (@Name, @Username, @Password, @Email, @Contact, @Address, @NIC)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", model.Name);
                cmd.Parameters.AddWithValue("@Username", model.Username);
                cmd.Parameters.AddWithValue("@Password", model.Password);
                cmd.Parameters.AddWithValue("@Email", model.Email);
                cmd.Parameters.AddWithValue("@Contact", model.Contact);
                cmd.Parameters.AddWithValue("@Address", model.Address);
                cmd.Parameters.AddWithValue("@NIC", model.NIC);

                cmd.ExecuteNonQuery();
            }
        }

        public SignupModel GetCustomer(int regNo)
        {
            SignupModel customer = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Customers WHERE RegNo = @RegNo";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@RegNo", regNo);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    customer = new SignupModel
                    {
                        RegNo = Convert.ToInt32(reader["RegNo"]),
                        Name = reader["Name"].ToString(),
                        Username = reader["Username"].ToString(),
                        Password = reader["Password"].ToString(),
                        Email = reader["Email"].ToString(),
                        Contact = reader["Contact"].ToString(),
                        Address = reader["Address"].ToString(),
                        NIC = reader["NIC"].ToString()
                    };
                }
            }

            return customer;
        }

        public void UpdateCustomer(SignupModel model)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE Customers SET Name = @Name, Username = @Username, Password = @Password, " +
                               "Email = @Email, Contact = @Contact, Address = @Address, NIC = @NIC WHERE RegNo = @RegNo";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@RegNo", model.RegNo);
                cmd.Parameters.AddWithValue("@Name", model.Name);
                cmd.Parameters.AddWithValue("@Username", model.Username);
                cmd.Parameters.AddWithValue("@Password", model.Password);
                cmd.Parameters.AddWithValue("@Email", model.Email);
                cmd.Parameters.AddWithValue("@Contact", model.Contact);
                cmd.Parameters.AddWithValue("@Address", model.Address);
                cmd.Parameters.AddWithValue("@NIC", model.NIC);

                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteCustomer(int regNo)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "DELETE FROM Customers WHERE RegNo = @RegNo";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@RegNo", regNo);
                cmd.ExecuteNonQuery();
            }
        }

        public List<int> GetAllCustomerIds()
        {
            List<int> ids = new List<int>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT RegNo FROM Customers", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ids.Add(Convert.ToInt32(reader["RegNo"]));
                }
            }

            return ids;
        }
    }
}
