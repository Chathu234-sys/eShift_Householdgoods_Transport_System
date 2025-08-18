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
using eShiftCompany.Business.Interface;
using eShiftCompany.Business.Services;
using eShiftCompany.Repository.Services;
using eShiftCompany.Repository.Interface;

namespace eShiftCompany
{
    public partial class AdminDashboard: Form
    {
        private readonly IAdminDashboardService _adminService;

        string connectionString = "Data Source=DESKTOP-62975O3\\SQLEXPRESS;Initial Catalog=eShift;Integrated Security=True;";


        public AdminDashboard()
        {
            InitializeComponent();
            var repo = new AdminDashboardRepository(connectionString);
            _adminService = new AdminDashboardService(repo);
        }

        private void LoadAdminIDs()
        {
            cbAdminId.Items.Clear();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT AdminID FROM AdminLogin";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cbAdminId.Items.Add(reader["AdminID"].ToString());
                }
            }
        }

        private void LoadAdminDetails(int adminId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT Username, Password FROM AdminLogin WHERE AdminID = @AdminID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@AdminID", adminId);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtAdminUsername.Text = reader["Username"].ToString();
                    txtAdminPassword.Text = reader["Password"].ToString(); // If storing hashed passwords, don't auto-fill this
                }
                else
                {
                    txtAdminUsername.Text = "";
                    txtAdminPassword.Text = "";
                }
            }
        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {
            LoadAdminIDs();
        }

        private void employeeRegistrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Open Employee registration Form");
            EmployeeReg employeeReg = new EmployeeReg();
            employeeReg.Show();
            this.Hide();
        }

        private void transportUnitsManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ITransportUnitManagementRepository repo = new TransportUnitManagementRepository();
            ITransportUnitManagementService service = new TransportUnitManagementService(repo);

            // Inject into form
            TransportUnitManagement form = new TransportUnitManagement(service);
            form.Show();
            this.Hide();
        }

        private void loadManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ILoadManagementService service = new LoadManagementService();
            LoadManagement loadForm = new LoadManagement(service);
            loadForm.Show();
            this.Hide();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string username = txtAdminUsername.Text.Trim();
            string password = txtAdminPassword.Text.Trim();

            if (username == "" || password == "")
            {
                MessageBox.Show("Please enter both Username and Password.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO AdminLogin (Username, Password) VALUES (@Username, @Password)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Admin added successfully.");
                    LoadAdminIDs(); // Refresh the ComboBox
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627) // Unique constraint error
                        MessageBox.Show("Username already exists.");
                    else
                        MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (cbAdminId.SelectedItem == null)
            {
                MessageBox.Show("Please select an Admin ID to delete.");
                return;
            }

            int adminId = int.Parse(cbAdminId.SelectedItem.ToString());

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM AdminLogin WHERE AdminID = @AdminID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@AdminID", adminId);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("Admin deleted successfully.");
                    LoadAdminIDs(); // Refresh list
                }
                else
                {
                    MessageBox.Show("Admin not found.");
                }
            }
        }

        private void cbAdminId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbAdminId.SelectedItem != null)
            {
                int selectedAdminId = int.Parse(cbAdminId.SelectedItem.ToString());
                LoadAdminDetails(selectedAdminId);
            }
        }

        private void adminManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void manageStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IManageStatusRepository repository = new ManageStatusRepository();
            IManageStatusService service = new ManageStatusService(repository);
            ManageStatus manageStatusForm = new ManageStatus(service);
            manageStatusForm.Show();
            this.Hide();
        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IReportsRepository repo = new ReportsRepository();
            IReportsService service = new ReportsService(repo);
            Reports reportsForm = new Reports(service);
            reportsForm.Show();
            this.Hide();
        }

        private void productMangementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IProductManagementRepository repository = new ProductManagementRepository();
            IProductManagementService service = new ProductManagementService(repository);
            ProductManagement productForm = new ProductManagement(service);
            productForm.Show();
            this.Hide();
        }

        private void customerManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SignUp adminSignup = new SignUp("admin");
            adminSignup.Show();
            this.Hide();
        }

        private void linkLabelLogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }
    }
}
