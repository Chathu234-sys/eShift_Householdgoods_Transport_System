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
using eShiftCompany.Repository;
using eShiftCompany.Repository.Interface;
using eShiftCompany.Business.Interface;
using eShiftCompany.Business.Services;
using eShiftCompany.Repository.Services;
using System.Text.RegularExpressions;

namespace eShiftCompany
{
    public partial class SignUp: Form
    {
        string connectionString = "Data Source=DESKTOP-62975O3\\SQLEXPRESS;Initial Catalog=eShift;Integrated Security=True;";


        private string userRole;

        public SignUp(string role)
        {
            InitializeComponent();
            userRole = role;
        }

        private void ClearFields()
        {
            txtName.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            txtEmail.Clear();
            txtContact.Clear();
            txtAddress.Clear();
            txtNic.Clear();

        }

        private void btnReg_Click(object sender, EventArgs e)
        {

            SignupModel customer = new SignupModel
            {
                Name = txtName.Text,
                Username = txtUsername.Text,
                Password = txtPassword.Text,
                Email = txtEmail.Text,
                Contact = txtContact.Text,
                Address = txtAddress.Text,
                NIC = txtNic.Text
            };

            // Validate required fields first
            if (string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtNic.Text))
            {
                MessageBox.Show("Username, Email, and NIC are required and cannot be empty.");
                return;
            }

            if (!txtContact.Text.All(char.IsDigit) || txtContact.Text.Length != 10)
            {
                MessageBox.Show("Contact must be a 10-digit numeric value.");
                return;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Please enter a valid email address.");
                return;
            }
            // NIC Validation
            string nic = txtNic.Text;
            string oldNicPattern = @"^\d{9}[Vv]$";
            string newNicPattern = @"^\d{12}$";

            if (!Regex.IsMatch(nic, oldNicPattern) && !Regex.IsMatch(nic, newNicPattern))
            {
                MessageBox.Show("Please enter a valid NIC. (e.g., 123456789V or 200278906543)");
                return;
            }
            // Name Validation
            string name = txtName.Text;

            if (!Regex.IsMatch(name, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("Name can contain only letters and spaces.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Check if Username, Email, or NIC already exists
                    string checkQuery = "SELECT COUNT(*) FROM Customers WHERE Username = @Username OR Email = @Email OR NIC = @NIC";
                    SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                    checkCmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    checkCmd.Parameters.AddWithValue("@NIC", txtNic.Text);

                    int exists = (int)checkCmd.ExecuteScalar();
                    if (exists > 0)
                    {
                        MessageBox.Show("Username, Email, or NIC already exists.");
                        return;
                    }

                    // Insert into Customers
                    string query = "INSERT INTO Customers (Name, Username, Password, Email, Contact, Address, NIC) " +
                                   "VALUES (@Name, @Username, @Password, @Email, @Contact, @Address, @NIC)";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Name", txtName.Text);
                    cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                    cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@Contact", txtContact.Text);
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@NIC", txtNic.Text);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Customer Registered Successfully");
                    ClearFields();
                    LoadRegNos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        //private void btnUpdate_Click(object sender, EventArgs e)
        

            
        

        private void btnSearch_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM Customers WHERE RegNo = @RegNo";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@RegNo", cbReg.Text);

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        txtName.Text = dr["Name"].ToString();
                        txtUsername.Text = dr["Username"].ToString();
                        txtPassword.Text = dr["Password"].ToString();
                        txtEmail.Text = dr["Email"].ToString();
                        txtContact.Text = dr["Contact"].ToString();
                        txtAddress.Text = dr["Address"].ToString();
                        txtNic.Text = dr["NIC"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Customer not found.");
                    }

                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE Customers SET Name=@Name, Username=@Username, Password=@Password, " +
                                   "Email=@Email, Contact=@Contact, Address=@Address, NIC=@NIC WHERE RegNo=@RegNo";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@RegNo", cbReg.Text);
                    cmd.Parameters.AddWithValue("@Name", txtName.Text);
                    cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                    cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@Contact", txtContact.Text);
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@NIC", txtNic.Text);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Customer Updated Successfully");
                    ClearFields();
                    LoadRegNos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void SignUp_Load(object sender, EventArgs e)
        {
            LoadRegNos();
            if (userRole == "customer")
            {
                cbReg.Visible = false;
                btnSearch.Visible = false;
                btnUpdate.Visible = false;
                btnButton.Visible = false; // Delete button
                lblReg.Visible = false;  
            }
        }
        private void LoadRegNos()
        {
            cbReg.Items.Clear();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT RegNo FROM Customers", conn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    cbReg.Items.Add(dr["RegNo"].ToString());
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnButton_Click(object sender, EventArgs e)
        {
            if (cbReg.Text == "")
            {
                MessageBox.Show("Please select a Reg No to delete.");
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to delete this customer?",
                                                  "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();

                        string query = "DELETE FROM Customers WHERE RegNo = @RegNo";

                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@RegNo", cbReg.Text);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Customer deleted successfully.");
                            ClearFields();
                            LoadRegNos();
                        }
                        else
                        {
                            MessageBox.Show("Customer not found.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
    }
}
