using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eShiftCompany.Models;
using eShiftCompany.Repository.Interface;
using System.Data.SqlClient;

namespace eShiftCompany.Repository.Services
{
    public class AdminLoginRepository : IAdminLoginRepository
    {
        private readonly string _connectionString;

        public AdminLoginRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool ValidateLogin(AdminLoginModel admin)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM AdminLogin WHERE Username = @username AND Password = @password";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", admin.Username);
                cmd.Parameters.AddWithValue("@password", admin.Password);

                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
    }
}
