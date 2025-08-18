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
using iTextSharp.text;
using iTextSharp.text.pdf;
using ClosedXML.Excel;
using System.Drawing.Printing;
using System.IO;
using DrawingRectangle = System.Drawing.Rectangle;
using eShiftCompany.Business.Interface;
using eShiftCompany.Business.Services;
using eShiftCompany.Repository.Interface;
using eShiftCompany.Repository.Services;


namespace eShiftCompany
{
    public partial class Reports: Form
    {
        private readonly IReportsService _reportsService;

        public Reports(IReportsService reportsService)
        {
            InitializeComponent();
            _reportsService = reportsService;
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

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (cbReportType.SelectedIndex == -1)
            {
                MessageBox.Show("Select a report type.");
                return;
            }

            try
            {
                string reportType = cbReportType.SelectedItem.ToString();
                DateTime from = dtpFrom.Value.Date;
                DateTime to = dtpTo.Value.Date;

                DataTable dt = _reportsService.GenerateReport(reportType, from, to);
                dgvReport.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        

        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog { Filter = "PDF files (*.pdf)|*.pdf" };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                ExportToPDF(dgvReport, sfd.FileName);
                MessageBox.Show("Exported to PDF successfully.");
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Excel Files (*.xlsx)|*.xlsx"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                ExportToExcel_ClosedXML(dgvReport, sfd.FileName);
                MessageBox.Show("Exported to Excel successfully!");
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += (s, ev) =>
            {
                Bitmap bmp = new Bitmap(dgvReport.Width, dgvReport.Height);
                dgvReport.DrawToBitmap(bmp, new DrawingRectangle(0, 0, dgvReport.Width, dgvReport.Height));
                ev.Graphics.DrawImage(bmp, 0, 0);
            };
            PrintPreviewDialog preview = new PrintPreviewDialog { Document = pd };
            preview.ShowDialog();
        }

        private void ExportToPDF(DataGridView dgv, string filePath)
        {
            Document doc = new Document(PageSize.A4.Rotate(), 10f, 10f, 20f, 20f);
            PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
            doc.Open();

            // Use full namespace for Font
            iTextSharp.text.Font headerFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font cellFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL);

            PdfPTable table = new PdfPTable(dgv.Columns.Count)
            {
                WidthPercentage = 100
            };

            float[] widths = new float[dgv.Columns.Count];
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                widths[i] = 1f; // Equal width
            }
            table.SetWidths(widths);

            // Add header row
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(col.HeaderText, headerFont))
                {
                    BackgroundColor = new BaseColor(230, 230, 230),
                    Padding = 5,
                    HorizontalAlignment = Element.ALIGN_CENTER
                };
                table.AddCell(cell);
            }

            // Add data rows
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow) continue;
                foreach (DataGridViewCell cell in row.Cells)
                {
                    PdfPCell dataCell = new PdfPCell(new Phrase(cell.Value?.ToString() ?? "", cellFont))
                    {
                        Padding = 5,
                        HorizontalAlignment = Element.ALIGN_LEFT
                    };
                    table.AddCell(dataCell);
                }
            }

            doc.Add(table);
            doc.Close();
        }
        private void ExportToExcel_ClosedXML(DataGridView dgv, string filePath)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Report");

                // Add headers
                for (int col = 0; col < dgv.Columns.Count; col++)
                {
                    worksheet.Cell(1, col + 1).Value = dgv.Columns[col].HeaderText;
                }

                // Add data rows
                for (int row = 0; row < dgv.Rows.Count; row++)
                {
                    for (int col = 0; col < dgv.Columns.Count; col++)
                    {
                        worksheet.Cell(row + 2, col + 1).Value = dgv.Rows[row].Cells[col].Value?.ToString();
                    }
                }

                workbook.SaveAs(filePath);
            }

            MessageBox.Show("Excel file created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void Reports_Load(object sender, EventArgs e)
        {
            cbReportType.Items.Clear();
            cbReportType.Items.Add("Job Utilization");
            cbReportType.Items.Add("All Job Details");
            cbReportType.Items.Add("Payments");
            cbReportType.Items.Add("Customers");
            cbReportType.Items.Add("Employees");
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

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IReportsRepository repo = new ReportsRepository();
            IReportsService service = new ReportsService(repo);
            Reports reportsForm = new Reports(service);
            reportsForm.Show();
        }

        private void linkLabelLogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void cbReportType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
    
}
