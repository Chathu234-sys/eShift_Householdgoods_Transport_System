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
    public partial class TransportUnitManagement: Form
    {

        private readonly ITransportUnitManagementService _service;

        

        public TransportUnitManagement(ITransportUnitManagementService service)
        {
            InitializeComponent();
            _service = service;
        }
        

        private void TransportUnitManagement_Load(object sender, EventArgs e)
        {
            cbUnitType.Items.AddRange(new string[] { "Lorry", "Container" });
            cbStatus.Items.AddRange(new string[] { "Free", "In-Use", "Maintenance" });
        }       

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string unitType = cbUnitType.Text;
            string status = cbStatus.Text;

            if (unitType == "Lorry")
            {
                var lorry = new TransportUnitManagementModel
                {
                    PlateOrContainer = txtPlateorName.Text,
                    ModelOrSize = txtModelorLicense.Text,
                    Capacity = Convert.ToDecimal(txtSizeorCapacity.Text),
                    Status = status
                };
                _service.AddLorry(lorry);
            }
            else if (unitType == "Container")
            {
                var container = new TransportUnitManagementModel
                {
                    PlateOrContainer = txtPlateorName.Text,
                    ModelOrSize = txtModelorLicense.Text,
                    Capacity = Convert.ToDecimal(txtSizeorCapacity.Text),
                    Status = status
                };
                _service.AddContainer(container);
            }

            MessageBox.Show("Added Successfully.");
            LoadData();
        }
        

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string id = txtId.Text;
            string unitType = cbUnitType.Text;

            if (unitType == "Lorry")
            {
                var lorry = _service.GetLorryById(int.Parse(id));
                if (lorry != null)
                {
                    txtPlateorName.Text = lorry.PlateOrContainer;
                    txtModelorLicense.Text = lorry.ModelOrSize;
                    txtSizeorCapacity.Text = lorry.Capacity.ToString();
                    cbStatus.Text = lorry.Status;
                }
                else
                {
                    MessageBox.Show("Lorry Not Found.");
                }
            }
            else if (unitType == "Container")
            {
                var container = _service.GetContainerById(int.Parse(id));
                if (container != null)
                {
                    txtPlateorName.Text = container.PlateOrContainer;
                    txtModelorLicense.Text = container.ModelOrSize;
                    txtSizeorCapacity.Text = container.Capacity.ToString();
                    cbStatus.Text = container.Status;
                }
                else
                {
                    MessageBox.Show("Container Not Found.");
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string id = txtId.Text;
            string unitType = cbUnitType.Text;
            string status = cbStatus.Text;

            var model = new TransportUnitManagementModel
            {
                ID = int.Parse(id),
                PlateOrContainer = txtPlateorName.Text,
                ModelOrSize = txtModelorLicense.Text,
                Capacity = Convert.ToDecimal(txtSizeorCapacity.Text),
                Status = status
            };

            if (unitType == "Lorry")
            {
                _service.UpdateLorry(model);
            }
            else if (unitType == "Container")
            {
                _service.UpdateContainer(model);
            }

            MessageBox.Show("Updated Successfully.");
            LoadData();
        }
        

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string id = txtId.Text;
            string unitType = cbUnitType.Text;

            if (unitType == "Lorry")
            {
                _service.DeleteLorry(int.Parse(id));
            }
            else if (unitType == "Container")
            {
                _service.DeleteContainer(int.Parse(id));
            }

            MessageBox.Show("Deleted Successfully.");
            LoadData();
        }
      
        private void LoadData()
        {
            string unitType = cbUnitType.Text;
            if (unitType == "Lorry")
            {
                dgvUnits.DataSource = _service.GetAllLorries();
            }
            else if (unitType == "Container")
            {
                dgvUnits.DataSource = _service.GetAllContainers();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
