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
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using eShiftCompany.Business.Services;
using eShiftCompany.Repository.Services;
using eShiftCompany.Business.Interface;

namespace eShiftCompany
{
    public partial class CustomerDashboard: Form
    {
        string connectionString = "Data Source=DESKTOP-62975O3\\SQLEXPRESS;Initial Catalog=eShift;Integrated Security=True;";

        List<(int ProductID, string ProductName)> selectedItems = new List<(int, string)>();
        private readonly ICustomerDashboardService _service;

        public CustomerDashboard()
        {
            InitializeComponent();
            var repo = new CustomerDashboardRepository(connectionString);
            _service = new CustomerDashboardService(repo);
        }

        private void LoadCustomerIDs()
        {

            cbRegID.Items.Clear();
            cbRegID.Items.AddRange(_service.GetCustomerIDs().ToArray());
            
        }
        private void LoadCategories()
        {
            cbCategory.Items.Clear();
            cbCategory.Items.AddRange(_service.GetCategories().ToArray());
            
        }
        private void createNewJobToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            CustomerDashboard customerDashboard = new CustomerDashboard();
            customerDashboard.Show();
        }

        private void paymentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Open Payments Form");
            Payments payments = new Payments();
            payments.Show();
            this.Hide();
        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                

                cbItems.Items.Clear();

                if (cbCategory.SelectedItem != null)
                {
                    var category = cbCategory.SelectedItem.ToString();
                    var items = _service.GetItemsByCategory(category);

                    if (items != null && items.Any())
                    {
                        cbItems.Items.AddRange(items.ToArray());
                    }
                    else
                    {
                        MessageBox.Show("No items found for this category.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading items: " + ex.Message);
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (cbRegID.Text == "" || txtLocation.Text == "" || txtDestination.Text == "" || txtDistance.Text == "")
            {
                MessageBox.Show("Please fill all required fields.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                
                try
                {
                    int customerId = Convert.ToInt32(cbRegID.Text);
                    string startLocation = txtLocation.Text;
                    string destination = txtDestination.Text;
                    decimal distance = Convert.ToDecimal(txtDistance.Text);
                    string description = txtDescription.Text;
                    DateTime jobDate = dtpJobDate.Value;
                    int itemCount = selectedItems.Count;

                    // Call service to create job and get new JobID
                    int jobId = _service.CreateJob(customerId, startLocation, destination, distance, itemCount, description, jobDate);

                    // Insert each selected item into JobItems table
                    foreach (var item in selectedItems)
                    {
                        _service.InsertJobItem(jobId, item.ProductID);
                    }

                    
                    MessageBox.Show("Job requested successfully with selected items.");
                    ClearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error creating job: " + ex.Message);
                }

            }
        }

        private void CustomerDashboard_Load(object sender, EventArgs e)
        {
            LoadCustomerIDs();
            LoadCategories();

            dgvItems.Columns.Clear();
            dgvItems.Columns.Add("Product", "Product");
        }

        

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void myHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyHistory myHistory = new MyHistory();
            myHistory.Show();
            this.Hide();
        }

       

        private void cbItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            string productName = cbItems.Text;

            if (string.IsNullOrEmpty(productName))
            {
                MessageBox.Show("Select a valid product.");
                return;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string productName = cbItems.Text;

            if (string.IsNullOrEmpty(productName))
            {
                MessageBox.Show("Select a valid product.");
                return;
            }
            int productId = _service.GetProductIdByName(productName);
            
            

            if (productId != -1 && !selectedItems.Any(x => x.ProductID == productId))
            {
                selectedItems.Add((productId, productName));
                dgvItems.Rows.Add(productName);
            }
            else
            {
                MessageBox.Show("Item already added.");
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        private void ClearFields()
        {
            cbRegID.Text = "";
            txtLocation.Clear();
            txtDestination.Clear();
            txtDistance.Clear();
            cbCategory.SelectedIndex = -1;
            cbItems.Items.Clear();
            numItems.Value = 1;
            txtDescription.Clear();
            dtpJobDate.Value = DateTime.Now;
            dgvItems.Rows.Clear();
            selectedItems.Clear();
        }

        private void linkLabellogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }
    }
}
