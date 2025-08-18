using eShiftCompany.Business.Interface;
using eShiftCompany.Business.Services;
using eShiftCompany.Repository.Interface;
using eShiftCompany.Repository.Services;
using eShiftCompany.Models;
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
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using DocumentFormat.OpenXml.Vml;
using System.Xml.Linq;


namespace eShiftCompany
{
    public partial class Payments : Form
    {

        private string connectionString = "Data Source=DESKTOP-62975O3\\SQLEXPRESS;Initial Catalog=eShift;Integrated Security=True;";
        private readonly IPaymentsService _paymentsService;

        public object SecureSocketOptions { get; private set; }

        public Payments()
        {

            InitializeComponent();
            var repository = new PaymentsRepository(); // Assumes default connectionString inside repo
            _paymentsService = new PaymentsService(repository);

        }

        private void Payments_Load(object sender, EventArgs e)
        {
            LoadJobIDs();
            LoadPayments();
            dgvPayments.DataSource = _paymentsService.GetAllPayments();
        }
        private void LoadJobIDs()
        {

            cbJobID.Items.Clear();
            var jobIds = _paymentsService.GetPendingOrAcceptedJobIds();

            foreach (int id in jobIds)
            {
                cbJobID.Items.Add(id.ToString());
            }

        }

        private void LoadPayments()
        {
            dgvPayments.DataSource = _paymentsService.GetAllPayments();
        }
        private decimal CalculateAmount(int jobId)
        {

            decimal totalAmount = 0;
            decimal distance = 0;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Step 1: Get Distance from Jobs table
                SqlCommand cmdDistance = new SqlCommand("SELECT Distance FROM Jobs WHERE JobID = @JobID", conn);
                cmdDistance.Parameters.AddWithValue("@JobID", jobId);
                object distanceResult = cmdDistance.ExecuteScalar();

                if (distanceResult != null)
                    distance = Convert.ToDecimal(distanceResult);
                else
                {
                    MessageBox.Show("Job not found!");
                    return 0;
                }

                // Step 2: Get all ProductIDs from JobItems
                SqlCommand cmdItems = new SqlCommand(@"
            SELECT P.Price 
            FROM JobItems JI 
            JOIN Products P ON JI.ProductID = P.ProductID 
            WHERE JI.JobID = @JobID", conn);
                cmdItems.Parameters.AddWithValue("@JobID", jobId);

                SqlDataReader reader = cmdItems.ExecuteReader();
                decimal totalProductPrice = 0;
                int numberOfItems = 0;

                while (reader.Read())
                {
                    decimal price = Convert.ToDecimal(reader["Price"]);
                    totalProductPrice += price;
                    numberOfItems++;
                }
                reader.Close();

                // Step 3: Calculate final total
                totalAmount = totalProductPrice + (distance * 100);

                // Optionally update NumberOfItems in Jobs table if needed
                SqlCommand updateJob = new SqlCommand("UPDATE Jobs SET NumberOfItems = @Count WHERE JobID = @JobID", conn);
                updateJob.Parameters.AddWithValue("@Count", numberOfItems);
                updateJob.Parameters.AddWithValue("@JobID", jobId);
                updateJob.ExecuteNonQuery();
            }

            return totalAmount;
        }



        // Update the line causing the error in the SendEmail method
        public void SendEmail(string email, string jobId, decimal amount)
        {
            string fromEmail = "chathumikaumadi614@gmail.com";
            string fromName = "eShift Company";
            string emailPassword = "phteskplonbsgxyd";

            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                client.Authenticate(fromEmail, emailPassword);

                var message = new MimeKit.MimeMessage();
                message.From.Add(new MimeKit.MailboxAddress(fromName, fromEmail));
                message.To.Add(new MimeKit.MailboxAddress(email, email)); // Fix: Provide both name and email
                message.Subject = $"Payment Confirmation for Job ID: {jobId}";
                message.Body = new MimeKit.TextPart("plain")
                {
                    Text = $"Dear Customer,\n\nYour payment of Rs. {amount} for Job ID {jobId} has been received.\n\nThank you,\neShift Team"
                };

                client.Send(message);
                client.Disconnect(true);
                MessageBox.Show("Email sent to customer successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            MessageBox.Show("Email sent to customer successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cbJobID.Text))
            {
                MessageBox.Show("Select a Job ID.");
                return;
            }

            int jobId = Convert.ToInt32(cbJobID.Text);
            decimal amount = _paymentsService.CalculateAmount(jobId);

            txtAmount.Text = "Rs. " + amount.ToString("0.00");
            txtStatus.Text = "Pending";
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cbJobID.Text))
            {
                MessageBox.Show("Select a Job ID.");
                return;
            }

            int jobId = Convert.ToInt32(cbJobID.Text);
            decimal amount = _paymentsService.CalculateAmount(jobId);

            _paymentsService.ProcessPayment(jobId, amount);

            string email = _paymentsService.GetCustomerEmail(jobId);
            if (!string.IsNullOrEmpty(email))
            {
                SendEmail(email, jobId.ToString(), amount);
            }

            MessageBox.Show("Payment Completed Successfully!");
            LoadPayments();
            LoadJobIDs();
            ClearFields();
        }
        

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cbJobID.Text))
            {
                MessageBox.Show("Select a Job ID to cancel.");
                return;
            }

            int jobId = Convert.ToInt32(cbJobID.Text);
            _paymentsService.CancelJobPayment(jobId);

            MessageBox.Show("Job Cancelled.");
            LoadPayments();
            LoadJobIDs();
            ClearFields();
        }
        
        private void ClearFields()
        {
            cbJobID.Text = "";
            txtAmount.Text = "Rs. 0.00";
            txtStatus.Text = "";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void createNewJobToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerDashboard customerDashboard = new CustomerDashboard();
            customerDashboard.Show();
            this.Hide();
        }

        private void paymentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Payments payments = new Payments();
            payments.Show();
            this.Hide();
        }

        private void linkLabel1logout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }
    }
}
