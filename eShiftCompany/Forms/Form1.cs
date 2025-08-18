using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eShiftCompany.Business.Services;
using eShiftCompany.Models;
using eShiftCompany.Repository;
using eShiftCompany.Repository.Interface;
using eShiftCompany.Repository.Services;

namespace eShiftCompany
{
    public partial class Form1 : Form
    {
        string connectionString = "Data Source=DESKTOP-62975O3\\SQLEXPRESS;Initial Catalog=eShift;Integrated Security=True;";


        public Form1()
        {
            InitializeComponent();
        }



        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }

            ILoginRepository loginRepo = new LoginRepository();
            var loginService = new LoginService(loginRepo);
            LoginModel user = loginService.Authenticate(username, password);

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "SELECT RegNo FROM Customers WHERE Username = @Username AND Password = @Password";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        int customerId = Convert.ToInt32(reader["RegNo"]);
                        MessageBox.Show("Login successful!");

                        // Open dashboard or MyHistory form with correct ID
                        MyHistory myHistory = new MyHistory(customerId);
                        myHistory.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Open the Sign Up Form
            SignUp customerSignup = new SignUp("customer");
            customerSignup.Show();

            // Hide the current Login Form
            this.Hide();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            AdminLogin adminForm = new AdminLogin();
            adminForm.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
         
        }
        
        //private void button1_Click(object sender, EventArgs e)
        

        private void button1_Click_1(object sender, EventArgs e)
        {
            if(txtPassword.PasswordChar== '●')
            {
                button2.BringToFront();
                txtPassword.PasswordChar = '\0'; // Show password
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '\0')
            {
                button1.BringToFront();
                txtPassword.PasswordChar = '●'; // Hide password
            }
        }

        //private void txtUsername_TextChanged(object sender, EventArgs e)
        

        
    }
}
