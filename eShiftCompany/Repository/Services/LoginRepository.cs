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
    public class LoginRepository : ILoginRepository
    {
        private readonly string connectionString = "Data Source=DESKTOP-62975O3\\SQLEXPRESS;Initial Catalog=eShift;Integrated Security=True;";

        public LoginModel Login(string username, string password)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT RegNo, Username FROM Customers WHERE Username = @Username AND Password = @Password";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new LoginModel
                    {
                        RegNo = Convert.ToInt32(reader["RegNo"]),
                        Username = reader["Username"].ToString()
                    };
                }
                return null;
            }
        }
    }
}
