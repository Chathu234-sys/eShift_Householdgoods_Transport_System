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
using eShiftCompany.Models;
using eShiftCompany.Business.Services;
using eShiftCompany.Repository.Services;
using eShiftCompany.Repository.Interface;
using eShiftCompany.Business.Interface;

namespace eShiftCompany
{
    public partial class AdminLogin: Form
    {

        private readonly IAdminLoginService _loginService;
        // Connection string to the SQL Server database
        

        public AdminLogin()
        {
            InitializeComponent();
            IAdminLoginRepository repository = new AdminLoginRepository("Data Source=DESKTOP-62975O3\\SQLEXPRESS;Initial Catalog=eShift;Integrated Security=True;");
            _loginService = new AdminLoginService(repository);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please enter Username and Password.");
                return;
            }

            AdminLoginModel admin = new AdminLoginModel
            {
                Username = txtUsername.Text,
                Password = txtPassword.Text
            };

            bool isValid = _loginService.Login(admin);

            if (isValid)
            {
                MessageBox.Show("Login Successful!");
                AdminDashboard adminDashboard = new AdminDashboard();
                adminDashboard.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password.");
            }
        }
        

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AdminLogin_Load(object sender, EventArgs e)
        {
            
        }

        private void linkLabelLogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Show password
            txtPassword.PasswordChar = '\0';

            // Swap buttons
            button1.Visible = false;
            button2.Visible = true;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            // Hide password
            txtPassword.PasswordChar = '●';

            // Swap buttons
            button2.Visible = false;
            button1.Visible = true;
        }

        
    }
}
