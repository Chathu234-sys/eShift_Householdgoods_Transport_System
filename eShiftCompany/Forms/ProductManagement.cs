using eShiftCompany.Business.Interface;
using eShiftCompany.Business.Services;
using eShiftCompany.Models;
using eShiftCompany.Repository.Interface;
using eShiftCompany.Repository.Services;
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

namespace eShiftCompany
{
    public partial class ProductManagement: Form
    {
        private readonly IProductManagementService _productService;

        string connectionString = "Data Source=DESKTOP-62975O3\\SQLEXPRESS;Initial Catalog=eShift;Integrated Security=True;";
        int selectedProductID = -1;

        public ProductManagement(IProductManagementService productService)
        {
            InitializeComponent();
            _productService = productService;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProductName.Text) || cbCategory.SelectedIndex == -1 || !decimal.TryParse(txtPrice.Text, out decimal price))
            {
                MessageBox.Show("Please enter valid details.");
                return;
            }

            var product = new ProductManagementModel
            {
                ProductName = txtProductName.Text,
                Category = cbCategory.SelectedItem.ToString(),
                Price = price
            };

            _productService.AddProduct(product);
            MessageBox.Show("Product added.");
            LoadProducts();
            LoadProductIDs();
            ClearInputs();
        }

        private void ProductManagement_Load(object sender, EventArgs e)
        {
            LoadProducts();
            LoadProductIDs();
            cbCategory.Items.AddRange(new string[] { "Furniture", "Electronics", "Kitchenware", "Decorative" });
        }
        private void LoadProducts()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Products", conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvProducts.DataSource = dt;
            }
        }
        private void LoadProductIDs()
        {
            cbSearchID.Items.Clear();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT ProductID FROM Products", conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cbSearchID.Items.Add(reader["ProductID"].ToString());
                }
            }
        }

        private void cbSearchID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(int.TryParse(cbSearchID.SelectedItem?.ToString(), out int id))
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Products WHERE ProductID = @id", conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        selectedProductID = id;
                        txtProductName.Text = reader["ProductName"].ToString();
                        cbCategory.SelectedItem = reader["Category"].ToString();
                        txtPrice.Text = reader["Price"].ToString();
                    }
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedProductID == -1)
            {
                MessageBox.Show("Select a product from Search to update.");
                return;
            }

            var product = new ProductManagementModel
            {
                ProductID = selectedProductID,
                ProductName = txtProductName.Text,
                Category = cbCategory.SelectedItem.ToString(),
                Price = Convert.ToDecimal(txtPrice.Text)
            };

            _productService.UpdateProduct(product);
            MessageBox.Show("Product updated.");
            LoadProducts();
            ClearInputs();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedProductID == -1)
            {
                MessageBox.Show("Select a product to delete.");
                return;
            }

            _productService.DeleteProduct(selectedProductID);
            MessageBox.Show("Product deleted.");
            LoadProducts();
            LoadProductIDs();
            ClearInputs();
        }
        private void ClearInputs()
        {
            txtProductName.Clear();
            cbCategory.SelectedIndex = -1;
            txtPrice.Clear();
            cbSearchID.SelectedIndex = -1;
            selectedProductID = -1;
        }

        private void productManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IProductManagementRepository repository = new ProductManagementRepository();
            IProductManagementService service = new ProductManagementService(repository);
            ProductManagement productForm = new ProductManagement(service);
            productForm.Show();

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
    }
    
}

