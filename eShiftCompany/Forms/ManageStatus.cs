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
using eShiftCompany.Models;
using eShiftCompany.Business.Services;
using eShiftCompany.Repository.Interface;
using eShiftCompany.Repository.Services;


namespace eShiftCompany
{
    public partial class ManageStatus : Form
    {
        private readonly IManageStatusService _statusService;

        string connectionString = "Data Source=DESKTOP-62975O3\\SQLEXPRESS;Initial Catalog=eShift;Integrated Security=True;";

        public ManageStatus(IManageStatusService statusService)
        {
            InitializeComponent();
            _statusService = statusService;
        }

        private void employeeRegistrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
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

        private void adminManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdminDashboard adminDashboard = new AdminDashboard();
            adminDashboard.Show();
            this.Hide();
        }

        private void manageStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IManageStatusRepository repository = new ManageStatusRepository();
            IManageStatusService service = new ManageStatusService(repository);
            ManageStatus manageStatusForm = new ManageStatus(service);
            manageStatusForm.Show();
        }

        private void ManageStatus_Load(object sender, EventArgs e)
        {
            LoadJobs();
            LoadJobIDs();
            cbNewStatus.Items.AddRange(new string[] { "Pending", "In Progress", "Declined" , "Completed", "Cancelled" });
            LoadJobTable();
        }
        private void LoadJobIDs()
        {
            cbJobId.Items.Clear();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT JobID FROM Jobs";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cbJobId.Items.Add(dr["JobID"].ToString());
                }
                dr.Close();
            }
        }
        private void LoadJobs()
        {
            try
            {
                cbJob.Items.Clear();
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT JobID FROM Jobs", conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        cbJob.Items.Add(reader["JobID"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading Job IDs: " + ex.Message);
            }
        }
        private void LoadJobTable()
        {
            dgvJobs.DataSource = _statusService.GetAllJobs();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (cbJobId.SelectedIndex == -1 || cbNewStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Please select both Job ID and new Status.");
                return;
            }

            int jobId = int.Parse(cbJobId.Text);
            string newStatus = cbNewStatus.Text;

            bool success = _statusService.ChangeJobStatus(jobId, newStatus);

            if (success)
            {
                MessageBox.Show("Job status updated successfully.");
                LoadJobTable();
            }
            else
            {
                MessageBox.Show("Update failed. Check Job ID.");
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IReportsRepository repo = new ReportsRepository();
            IReportsService service = new ReportsService(repo);
            Reports reportsForm = new Reports(service);
            reportsForm.Show();
            this.Hide();
        }

        private void btnUpdateJob_Click(object sender, EventArgs e)
        {
            if (cbJob.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a Job ID.");
                return;
            }

            var job = new ManageStatusModel
            {
                JobID = int.Parse(cbJob.Text),
                StartLocation = txtLocation.Text,
                Destination = txtDestination.Text,
                Distance = decimal.TryParse(txtDistance.Text, out decimal d) ? d : 0,
                NumberOfItems = (int)numItems.Value,
                Description = txtDescription.Text,
                JobDate = dtpJobDate.Value
            };

            bool success = _statusService.EditJob(job);

            if (success)
            {
                MessageBox.Show("Job updated successfully.");
                LoadJobTable();
            }
            else
            {
                MessageBox.Show("Update failed. Please check the Job ID.");
            }
        }

        private void cbJob_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (int.TryParse(cbJob.Text, out int jobId))
            {
                var job = _statusService.GetJob(jobId);

                if (job != null)
                {
                    txtLocation.Text = job.StartLocation;
                    txtDestination.Text = job.Destination;
                    txtDistance.Text = job.Distance.ToString();
                    numItems.Value = job.NumberOfItems;
                    txtDescription.Text = job.Description;
                    dtpJobDate.Value = job.JobDate;
                }
                else
                {
                    MessageBox.Show("Job not found.");
                }
            }
        }

        private void productManagementToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void linkLabel1logout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
    
}
