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
    public class AdminDashboardRepository : IAdminDashboardRepository
    {
        private readonly string connectionString;

        public AdminDashboardRepository(string connStr)
        {
            connectionString = connStr;
        }

        public List<AdminDashboardModel> GetAllAdmins()
        {
            List<AdminDashboardModel> admins = new List<AdminDashboardModel>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM AdminLogin";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    admins.Add(new AdminDashboardModel
                    {
                        AdminID = (int)reader["AdminID"],
                        Username = reader["Username"].ToString(),
                        Password = reader["Password"].ToString()
                    });
                }
            }
            return admins;
        }

        public AdminDashboardModel GetAdminById(int adminId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM AdminLogin WHERE AdminID = @AdminID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@AdminID", adminId);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new AdminDashboardModel
                    {
                        AdminID = (int)reader["AdminID"],
                        Username = reader["Username"].ToString(),
                        Password = reader["Password"].ToString()
                    };
                }
            }
            return null;
        }

        public void AddAdmin(AdminDashboardModel admin)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO AdminLogin (Username, Password) VALUES (@Username, @Password)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", admin.Username);
                cmd.Parameters.AddWithValue("@Password", admin.Password);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteAdmin(int adminId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM AdminLogin WHERE AdminID = @AdminID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@AdminID", adminId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
