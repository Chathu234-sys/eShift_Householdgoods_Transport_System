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
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using System.Text.RegularExpressions;
using DocumentFormat.OpenXml.Bibliography;
using eShiftCompany.Business.Interface;
using eShiftCompany.Business.Services;
using eShiftCompany.Repository.Services;
using eShiftCompany.Models;
using eShiftCompany.Repository.Interface;

namespace eShiftCompany
{
    public partial class LoadManagement: Form
    {
        private readonly ILoadManagementService _loadService;

        string connectionString = "Data Source=DESKTOP-62975O3\\SQLEXPRESS;Initial Catalog=eShift;Integrated Security=True;";


        public LoadManagement(ILoadManagementService loadService)
        {
            InitializeComponent();
            _loadService = loadService;
        }

        public LoadManagement()
        {
        }

        private void LoadManagement_Load(object sender, EventArgs e)
        {
            LoadJobIDs();
            LoadTransportUnitIDs();
            LoadData();
            LoadPendingJobs();
        }

        private void LoadPendingJobs()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT JobID, CustomerID, StartLocation, Destination, JobDate 
                         FROM Jobs WHERE Status = 'Pending'";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvPendingJobs.DataSource = dt;
            }
        }

        private void LoadJobIDs()
        {
            cbJobId.Items.Clear();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT JobID FROM Jobs", conn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cbJobId.Items.Add(dr["JobID"].ToString());
                }
            }
        }
        private void LoadTransportUnitIDs()
        {
            cbLorryId.Items.Clear();
            cbDriverID.Items.Clear();
            cbAssistantId.Items.Clear();
            cbContainerId.Items.Clear();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Lorries
                SqlCommand cmd = new SqlCommand("SELECT LorryID FROM Lorries", conn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cbLorryId.Items.Add(dr["LorryID"].ToString());
                }
                dr.Close();

                // Drivers from Employees
                cmd = new SqlCommand("SELECT EmployeeID FROM Employees WHERE Role = 'Driver'", conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cbDriverID.Items.Add(dr["EmployeeID"].ToString());
                }
                dr.Close();

                // Assistants from Employees
                cmd = new SqlCommand("SELECT EmployeeID FROM Employees WHERE Role = 'Assistant'", conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cbAssistantId.Items.Add(dr["EmployeeID"].ToString());
                }
                dr.Close();

                // Containers
                cmd = new SqlCommand("SELECT ContainerID FROM Containers", conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cbContainerId.Items.Add(dr["ContainerID"].ToString());
                }
                dr.Close();
            }
        }



        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtWeight.Text, out decimal weight) || !decimal.TryParse(txtVolume.Text, out decimal volume))
            {
                MessageBox.Show("Enter valid numbers for weight and volume.");
                return;
            }

            var load = new LoadManagementModel
            {
                JobID = int.Parse(cbJobId.Text),
                Description = txtDescription.Text,
                Weight = weight,
                Volume = volume,
                SpecialHandling = txtSpecial.Text,
                LorryID = int.Parse(cbLorryId.Text),
                DriverID = int.Parse(cbDriverID.Text),
                AssistantID = int.Parse(cbAssistantId.Text),
                ContainerID = int.Parse(cbContainerId.Text)
            };

            _loadService.AddLoad(load);
            MessageBox.Show("Load Added Successfully.");

            LoadData();
            ClearFields();

            // Then send email
            SendEmailToCustomer(cbJobId.Text);

               
            
        }
        // Fix for CS1503: Ensure the correct MimeMessage type from MimeKit is used.

        private void SendEmailToCustomer(string jobId)
        {
            try
            {
                string customerName = "Customer";
                string customerEmail = "default@example.com";
                string lorryPlate = "Not Assigned";
                string driverName = "Not Assigned";
                string assistantName = "Not Assigned";
                string containerNumber = "Not Assigned";
                string specialInstructions = txtSpecial.Text;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Fetch customer name and email
                    using (SqlCommand cmd = new SqlCommand(@"
                SELECT c.Name, c.Email
                FROM Jobs j
                INNER JOIN Customers c ON j.CustomerID = c.RegNo
                WHERE j.JobID = @JobID", conn))
                    {
                        cmd.Parameters.AddWithValue("@JobID", jobId);
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                customerName = dr["Name"].ToString();
                                customerEmail = dr["Email"].ToString();
                            }
                        }
                    }

                    // Fetch transport assignment (lorry, driver, assistant, container)
                    using (SqlCommand cmd = new SqlCommand(@"
                SELECT 
                    ISNULL(l.PlateNumber, 'Not Assigned') AS PlateNumber,
                    ISNULL(d.Name, 'Not Assigned') AS DriverName,
                    ISNULL(a.Name, 'Not Assigned') AS AssistantName,
                    ISNULL(co.ContainerNumber, 'Not Assigned') AS ContainerNumber
                FROM Loads ld
                LEFT JOIN Lorries l ON ld.LorryID = l.LorryID
                LEFT JOIN Employees d ON ld.DriverID = d.EmployeeID
                LEFT JOIN Employees a ON ld.AssistantID = a.EmployeeID
                LEFT JOIN Containers co ON ld.ContainerID = co.ContainerID
                WHERE ld.JobID = @JobID", conn))
                    {
                        cmd.Parameters.AddWithValue("@JobID", jobId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                lorryPlate = reader["PlateNumber"].ToString();
                                driverName = reader["DriverName"].ToString();
                                assistantName = reader["AssistantName"].ToString();
                                containerNumber = reader["ContainerNumber"].ToString();
                            }
                        }
                    }
                }

                // Prepare email content
                string subject = "Transport Assignment Notification - eShift";
                string body = $"Dear {customerName},\n\n" +
                              $"Your load with Job ID: {jobId} has been assigned transport units.\n\n" +
                              $"Lorry Plate Number : {lorryPlate}\n" +
                              $"Driver Name        : {driverName}\n" +
                              $"Assistant Name     : {assistantName}\n" +
                              $"Container Number   : {containerNumber}\n\n" +
                              $"Special Instructions:\n{specialInstructions}\n\n" +
                              $"Thank you for using eShift services.\n\n" +
                              $"Best regards,\n" +
                              $"eShift Company";

                // Send email using MailKit
                var message = new MimeKit.MimeMessage();
                message.From.Add(new MimeKit.MailboxAddress("eShift Company", "chathumikaumadi614@gmail.com"));
                message.To.Add(new MimeKit.MailboxAddress(customerName, customerEmail));
                message.Subject = subject;
                message.Body = new MimeKit.TextPart(MimeKit.Text.TextFormat.Plain) { Text = body };

                using (var smtp = new MailKit.Net.Smtp.SmtpClient())
                {
                    smtp.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                    smtp.Authenticate("chathumikaumadi614@gmail.com", "phteskplonbsgxyd"); // Use your Gmail App Password
                    smtp.Send(message);
                    smtp.Disconnect(true);
                }

                MessageBox.Show("Email sent to customer successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to send email: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtLoadId.Text))
            {
                MessageBox.Show("Please enter Load ID to update.");
                return;
            }

            var load = new LoadManagementModel
            {
                LoadID = int.Parse(txtLoadId.Text),
                JobID = int.Parse(cbJobId.Text),
                Description = txtDescription.Text,
                Weight = decimal.Parse(txtWeight.Text),
                Volume = decimal.Parse(txtVolume.Text),
                SpecialHandling = txtSpecial.Text,
                LorryID = int.Parse(cbLorryId.Text),
                DriverID = int.Parse(cbDriverID.Text),
                AssistantID = int.Parse(cbAssistantId.Text),
                ContainerID = int.Parse(cbContainerId.Text)
            };

            _loadService.UpdateLoad(load);
            MessageBox.Show("Load Updated Successfully.");
            LoadData();
            ClearFields();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtLoadId.Text == "")
            {
                MessageBox.Show("Select Load ID to delete.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "DELETE FROM Loads WHERE LoadID=@LoadID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@LoadID", txtLoadId.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Load Deleted Successfully.");

                LoadData();
                ClearFields();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtLoadId.Text, out int loadId))
            {
                MessageBox.Show("Enter a valid Load ID.");
                return;
            }

            var load = _loadService.GetLoadById(loadId);
            if (load != null)
            {
                cbJobId.Text = load.JobID.ToString();
                txtDescription.Text = load.Description;
                txtWeight.Text = load.Weight.ToString();
                txtVolume.Text = load.Volume.ToString();
                txtSpecial.Text = load.SpecialHandling;
                cbLorryId.Text = load.LorryID.ToString();
                cbDriverID.Text = load.DriverID.ToString();
                cbAssistantId.Text = load.AssistantID.ToString();
                cbContainerId.Text = load.ContainerID.ToString();
            }
            else
            {
                MessageBox.Show("Load not found.");
            }
        }
        private void LoadData()
        {
            dgvLoads.DataSource = _loadService.GetAllLoads();
        }
        private void ClearFields()
        {
            txtLoadId.Clear();
            cbJobId.SelectedIndex = -1;
            txtDescription.Clear();
            txtWeight.Clear();
            txtVolume.Clear();
            txtSpecial.Clear();
            cbLorryId.SelectedIndex = -1;
            cbDriverID.SelectedIndex = -1;
            cbAssistantId.SelectedIndex = -1;
            cbContainerId.SelectedIndex = -1;
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (txtLoadId.Text == "")
            {
                MessageBox.Show("Select Load ID to delete.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "DELETE FROM Loads WHERE LoadID=@LoadID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@LoadID", txtLoadId.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Load Deleted Successfully.");

                LoadData();
                ClearFields();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (dgvPendingJobs.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a job to accept.");
                return;
            }

            string selectedJobId = dgvPendingJobs.SelectedRows[0].Cells["JobID"].Value.ToString();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Jobs SET Status = 'Accepted' WHERE JobID = @JobID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@JobID", selectedJobId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            
            SendStatusEmailToCustomer(selectedJobId, "Accepted");
            MessageBox.Show("Job accepted and email sent.");
            LoadPendingJobs(); // Refresh list
            LoadData(); // Refresh loads if needed
        }
        private void SendStatusEmailToCustomer(string jobId, string newStatus)
        {
            try
            {
                string customerName = "";
                string customerEmail = "";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(
                     @"SELECT c.Email, c.Name 
                       FROM Customers c 
                       INNER JOIN Jobs j ON c.RegNo = j.CustomerID 
                       WHERE j.JobID = @JobID", conn);
                    cmd.Parameters.AddWithValue("@JobID", jobId);

                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        customerEmail = dr["Email"].ToString();
                        customerName = dr["Name"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Customer email not found for this job.");
                        return;
                    }
                    dr.Close();
                }

                // Compose the email
                var message = new MimeKit.MimeMessage(); // Fix: Use MimeKit.MimeMessage instead of eShiftCompany.MimeMessage
                message.From.Add(new MimeKit.MailboxAddress("eShift Company", "chathumikaumadi614@gmail.com"));
                message.To.Add(new MimeKit.MailboxAddress(customerName, customerEmail)); // Fix: Correctly add recipient using MimeKit.MailboxAddress
                message.Subject = "Job Status Update - eShift";

                message.Body = new MimeKit.TextPart("plain") // Fix: Use MimeKit.TextPart
                {
                    Text = $"Dear {customerName},\n\n" +
                           $"Your job with ID {jobId} has been {newStatus.ToUpper()} by our staff.\n\n" +
                           $"Thank you for using eShift.\n\n" +
                           $"- eShift Company"
                };

                // Send the email using MailKit
                using (var client = new MailKit.Net.Smtp.SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                    client.Authenticate("chathumikaumadi614@gmail.com", "phteskplonbsgxyd"); // App password

                    client.Send(message); // Fix: Ensure the correct MimeKit.MimeMessage is passed
                    client.Disconnect(true);
                }

                MessageBox.Show($"Email sent to customer: Job {newStatus}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sending status email: " + ex.Message);
            }
        }

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            if (dgvPendingJobs.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a job to view.");
                return;
            }

            string selectedJobId = dgvPendingJobs.SelectedRows[0].Cells["JobID"].Value.ToString();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT * FROM Loads WHERE JobID = @JobID";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@JobID", selectedJobId);

                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvLoads.DataSource = dt;
            }

            cbJobId.Text = selectedJobId;
        }

        private void btnDecline_Click(object sender, EventArgs e)
        {
            if (dgvPendingJobs.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a job to decline.");
                return;
            }

            string selectedJobId = dgvPendingJobs.SelectedRows[0].Cells["JobID"].Value.ToString();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Jobs SET Status = 'Declined' WHERE JobID = @JobID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@JobID", selectedJobId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Job declined.");
            SendStatusEmailToCustomer(selectedJobId, "Declined");
            MessageBox.Show("Job declined and email sent.");
            LoadPendingJobs();
        }

        private void loadManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ILoadManagementService service = new LoadManagementService();
            LoadManagement loadForm = new LoadManagement(service);
            loadForm.Show();
            
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

        private void employeeRegistrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeeReg employeeReg = new EmployeeReg();
            employeeReg.Show();
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

        private void linkLabellogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }
    }
}
