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
    public class EmployeeRegRepository : IEmployeeRegRepository
    {
        private readonly string connectionString = "Data Source=DESKTOP-62975O3\\SQLEXPRESS;Initial Catalog=eShift;Integrated Security=True;";

        public void AddEmployee(EmployeeRegModel emp)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Employees (Name, NIC, Contact, Age, Gender, Role, Email) " +
                               "VALUES (@Name, @NIC, @Contact, @Age, @Gender, @Role, @Email)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", emp.Name);
                cmd.Parameters.AddWithValue("@NIC", emp.NIC);
                cmd.Parameters.AddWithValue("@Contact", emp.Contact);
                cmd.Parameters.AddWithValue("@Age", emp.Age);
                cmd.Parameters.AddWithValue("@Gender", emp.Gender);
                cmd.Parameters.AddWithValue("@Role", emp.Role);
                cmd.Parameters.AddWithValue("@Email", emp.Email);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateEmployee(EmployeeRegModel emp)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Employees SET Name=@Name, NIC=@NIC, Contact=@Contact, Age=@Age, " +
                               "Gender=@Gender, Role=@Role, Email=@Email WHERE EmployeeID=@EmployeeID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@EmployeeID", emp.EmployeeID);
                cmd.Parameters.AddWithValue("@Name", emp.Name);
                cmd.Parameters.AddWithValue("@NIC", emp.NIC);
                cmd.Parameters.AddWithValue("@Contact", emp.Contact);
                cmd.Parameters.AddWithValue("@Age", emp.Age);
                cmd.Parameters.AddWithValue("@Gender", emp.Gender);
                cmd.Parameters.AddWithValue("@Role", emp.Role);
                cmd.Parameters.AddWithValue("@Email", emp.Email);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteEmployee(int employeeId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Employees WHERE EmployeeID = @EmployeeID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@EmployeeID", employeeId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public EmployeeRegModel GetEmployeeById(int employeeId)
        {
            EmployeeRegModel emp = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Employees WHERE EmployeeID = @EmployeeID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@EmployeeID", employeeId);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    emp = new EmployeeRegModel
                    {
                        EmployeeID = Convert.ToInt32(reader["EmployeeID"]),
                        Name = reader["Name"].ToString(),
                        NIC = reader["NIC"].ToString(),
                        Contact = reader["Contact"].ToString(),
                        Age = Convert.ToInt32(reader["Age"]),
                        Gender = reader["Gender"].ToString(),
                        Role = reader["Role"].ToString(),
                        Email = reader["Email"].ToString()
                    };
                }
            }

            return emp;
        }

        public List<EmployeeRegModel> GetAllEmployees()
        {
            List<EmployeeRegModel> list = new List<EmployeeRegModel>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Employees";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new EmployeeRegModel
                    {
                        EmployeeID = Convert.ToInt32(reader["EmployeeID"]),
                        Name = reader["Name"].ToString(),
                        NIC = reader["NIC"].ToString(),
                        Contact = reader["Contact"].ToString(),
                        Age = Convert.ToInt32(reader["Age"]),
                        Gender = reader["Gender"].ToString(),
                        Role = reader["Role"].ToString(),
                        Email = reader["Email"].ToString()
                    });
                }
            }

            return list;
        }
    }
}
