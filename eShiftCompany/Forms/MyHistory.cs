using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Xml.Linq;
using eShiftCompany.Business.Interface;
using eShiftCompany.Business.Services;
using eShiftCompany.Repository.Interface;
using eShiftCompany.Repository.Services;
using eShiftCompany.Models;

namespace eShiftCompany
{

    public partial class MyHistory: Form
    {
        private int customerID;
        private readonly IMyHistoryService _historyService;
        string connectionString = "Data Source=DESKTOP-62975O3\\SQLEXPRESS;Initial Catalog=eShift;Integrated Security=True;";

        public MyHistory()
        {
            throw new InvalidOperationException("You must use the constructor with a customer ID.");
        }

        public MyHistory(int customerId)
        {
            InitializeComponent();
            this.customerID = customerId;
            IMyHistoryRepository repo = new MyHistoryRepository(connectionString);
            _historyService = new MyHistoryService(repo);//  Assign the passed customerId to class-level customerID
        }

        private void myHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int loggedInCustomerId = 5; // Replace with actual value
            MyHistory form = new MyHistory(loggedInCustomerId); // ✅ this uses correct constructor
            form.Show();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadProfileInfo();
            LoadUpcomingJobs();
            LoadJobHistory();
        }

        private void MyHistory_Load(object sender, EventArgs e)
        {
            LoadProfileInfo();
            LoadUpcomingJobs();
            LoadJobHistory();
        }
        private void LoadProfileInfo()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT Name, Email, Contact FROM Customers WHERE RegNo = @CustomerID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@CustomerID", customerID);

                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        txtName.Text = dr["Name"].ToString();
                        txtEmail.Text = dr["Email"].ToString();
                        txtContact.Text = dr["Contact"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Profile not found.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading profile: " + ex.Message);
            }
        }
        private void LoadUpcomingJobs()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"SELECT JobID, StartLocation, Destination, JobDate, Status 
                                     FROM Jobs 
                                     WHERE CustomerID = @CustomerID AND Status IN ('Pending', 'Accepted','In-Progress')";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.SelectCommand.Parameters.AddWithValue("@CustomerID", customerID);

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvUpcomingJobs.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading upcoming jobs: " + ex.Message);
            }
        }

        private void LoadJobHistory()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"SELECT JobID, StartLocation, Destination, JobDate, Status 
                                     FROM Jobs 
                                     WHERE CustomerID = @CustomerID AND Status IN ('Completed', 'Cancelled' , 'Declined')";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.SelectCommand.Parameters.AddWithValue("@CustomerID", customerID);

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvJobHistory.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading job history: " + ex.Message);
            }
        }

        private void paymentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Payments paymentsForm = new Payments();
            paymentsForm.Show();
            this.Hide();
        }

        private void createNewJobToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerDashboard customerDashboard = new CustomerDashboard();
            customerDashboard.Show();
            this.Hide();
        }

        private void lblName_Click(object sender, EventArgs e)
        {

        }

        private void linkLabellogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }
    }
}
