namespace eShiftCompany
{
    partial class TransportUnitManagement
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblUnitType = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.lblPlateorName = new System.Windows.Forms.Label();
            this.lblModelorLicense = new System.Windows.Forms.Label();
            this.lblSizeorCapacity = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtPlateorName = new System.Windows.Forms.TextBox();
            this.txtModelorLicense = new System.Windows.Forms.TextBox();
            this.txtSizeorCapacity = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.cbUnitType = new System.Windows.Forms.ComboBox();
            this.dgvUnits = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.employeeRegistrationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transportUnitsManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adminManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customerManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.linkLabellogout = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnits)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUnitType
            // 
            this.lblUnitType.AutoSize = true;
            this.lblUnitType.Font = new System.Drawing.Font("Microsoft YaHei", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnitType.Location = new System.Drawing.Point(719, 171);
            this.lblUnitType.Name = "lblUnitType";
            this.lblUnitType.Size = new System.Drawing.Size(88, 22);
            this.lblUnitType.TabIndex = 0;
            this.lblUnitType.Text = "Unit Type";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Font = new System.Drawing.Font("Microsoft YaHei", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblId.Location = new System.Drawing.Point(719, 222);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(28, 22);
            this.lblId.TabIndex = 1;
            this.lblId.Text = "ID";
            // 
            // lblPlateorName
            // 
            this.lblPlateorName.AutoSize = true;
            this.lblPlateorName.Font = new System.Drawing.Font("Microsoft YaHei", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlateorName.Location = new System.Drawing.Point(719, 271);
            this.lblPlateorName.Name = "lblPlateorName";
            this.lblPlateorName.Size = new System.Drawing.Size(123, 22);
            this.lblPlateorName.TabIndex = 2;
            this.lblPlateorName.Text = "Plate Number";
            // 
            // lblModelorLicense
            // 
            this.lblModelorLicense.AutoSize = true;
            this.lblModelorLicense.Font = new System.Drawing.Font("Microsoft YaHei", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModelorLicense.Location = new System.Drawing.Point(719, 317);
            this.lblModelorLicense.Name = "lblModelorLicense";
            this.lblModelorLicense.Size = new System.Drawing.Size(67, 22);
            this.lblModelorLicense.TabIndex = 3;
            this.lblModelorLicense.Text = "Model ";
            // 
            // lblSizeorCapacity
            // 
            this.lblSizeorCapacity.AutoSize = true;
            this.lblSizeorCapacity.Font = new System.Drawing.Font("Microsoft YaHei", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSizeorCapacity.Location = new System.Drawing.Point(719, 364);
            this.lblSizeorCapacity.Name = "lblSizeorCapacity";
            this.lblSizeorCapacity.Size = new System.Drawing.Size(79, 22);
            this.lblSizeorCapacity.TabIndex = 5;
            this.lblSizeorCapacity.Text = "Capacity";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(861, 218);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(283, 26);
            this.txtId.TabIndex = 7;
            // 
            // txtPlateorName
            // 
            this.txtPlateorName.Location = new System.Drawing.Point(861, 267);
            this.txtPlateorName.Name = "txtPlateorName";
            this.txtPlateorName.Size = new System.Drawing.Size(283, 26);
            this.txtPlateorName.TabIndex = 8;
            // 
            // txtModelorLicense
            // 
            this.txtModelorLicense.Location = new System.Drawing.Point(861, 313);
            this.txtModelorLicense.Name = "txtModelorLicense";
            this.txtModelorLicense.Size = new System.Drawing.Size(283, 26);
            this.txtModelorLicense.TabIndex = 9;
            // 
            // txtSizeorCapacity
            // 
            this.txtSizeorCapacity.Location = new System.Drawing.Point(861, 360);
            this.txtSizeorCapacity.Name = "txtSizeorCapacity";
            this.txtSizeorCapacity.Size = new System.Drawing.Size(283, 26);
            this.txtSizeorCapacity.TabIndex = 11;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft YaHei", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(719, 410);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(61, 22);
            this.lblStatus.TabIndex = 12;
            this.lblStatus.Text = "Status";
            // 
            // cbStatus
            // 
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Location = new System.Drawing.Point(861, 409);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(283, 28);
            this.cbStatus.TabIndex = 13;
            // 
            // cbUnitType
            // 
            this.cbUnitType.FormattingEnabled = true;
            this.cbUnitType.Location = new System.Drawing.Point(861, 167);
            this.cbUnitType.Name = "cbUnitType";
            this.cbUnitType.Size = new System.Drawing.Size(283, 28);
            this.cbUnitType.TabIndex = 14;
            // 
            // dgvUnits
            // 
            this.dgvUnits.BackgroundColor = System.Drawing.Color.DarkCyan;
            this.dgvUnits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUnits.GridColor = System.Drawing.Color.DarkCyan;
            this.dgvUnits.Location = new System.Drawing.Point(505, 456);
            this.dgvUnits.Name = "dgvUnits";
            this.dgvUnits.RowHeadersWidth = 62;
            this.dgvUnits.RowTemplate.Height = 28;
            this.dgvUnits.Size = new System.Drawing.Size(740, 181);
            this.dgvUnits.TabIndex = 15;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAdd.Location = new System.Drawing.Point(697, 673);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(101, 39);
            this.btnAdd.TabIndex = 16;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnUpdate.Location = new System.Drawing.Point(832, 673);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(101, 39);
            this.btnUpdate.TabIndex = 17;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDelete.Location = new System.Drawing.Point(971, 673);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(101, 39);
            this.btnDelete.TabIndex = 18;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSearch.Location = new System.Drawing.Point(1105, 673);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(101, 39);
            this.btnSearch.TabIndex = 19;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnExit.Location = new System.Drawing.Point(1294, 48);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(92, 45);
            this.btnExit.TabIndex = 20;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.employeeRegistrationToolStripMenuItem,
            this.transportUnitsManagementToolStripMenuItem,
            this.loadManagementToolStripMenuItem,
            this.adminManagementToolStripMenuItem,
            this.manageStatusToolStripMenuItem,
            this.reportsToolStripMenuItem,
            this.productManagementToolStripMenuItem,
            this.customerManagementToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(5, 2);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1487, 33);
            this.menuStrip1.TabIndex = 21;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // employeeRegistrationToolStripMenuItem
            // 
            this.employeeRegistrationToolStripMenuItem.Name = "employeeRegistrationToolStripMenuItem";
            this.employeeRegistrationToolStripMenuItem.Size = new System.Drawing.Size(205, 29);
            this.employeeRegistrationToolStripMenuItem.Text = "Employee Registration";
            this.employeeRegistrationToolStripMenuItem.Click += new System.EventHandler(this.employeeRegistrationToolStripMenuItem_Click);
            // 
            // transportUnitsManagementToolStripMenuItem
            // 
            this.transportUnitsManagementToolStripMenuItem.BackColor = System.Drawing.Color.DarkSlateGray;
            this.transportUnitsManagementToolStripMenuItem.Name = "transportUnitsManagementToolStripMenuItem";
            this.transportUnitsManagementToolStripMenuItem.Size = new System.Drawing.Size(257, 29);
            this.transportUnitsManagementToolStripMenuItem.Text = "Transport Units Management";
            this.transportUnitsManagementToolStripMenuItem.Click += new System.EventHandler(this.transportUnitsManagementToolStripMenuItem_Click);
            // 
            // loadManagementToolStripMenuItem
            // 
            this.loadManagementToolStripMenuItem.Name = "loadManagementToolStripMenuItem";
            this.loadManagementToolStripMenuItem.Size = new System.Drawing.Size(177, 29);
            this.loadManagementToolStripMenuItem.Text = "Load Management";
            this.loadManagementToolStripMenuItem.Click += new System.EventHandler(this.loadManagementToolStripMenuItem_Click);
            // 
            // adminManagementToolStripMenuItem
            // 
            this.adminManagementToolStripMenuItem.Name = "adminManagementToolStripMenuItem";
            this.adminManagementToolStripMenuItem.Size = new System.Drawing.Size(191, 29);
            this.adminManagementToolStripMenuItem.Text = "Admin Management";
            this.adminManagementToolStripMenuItem.Click += new System.EventHandler(this.adminManagementToolStripMenuItem_Click);
            // 
            // manageStatusToolStripMenuItem
            // 
            this.manageStatusToolStripMenuItem.Name = "manageStatusToolStripMenuItem";
            this.manageStatusToolStripMenuItem.Size = new System.Drawing.Size(145, 29);
            this.manageStatusToolStripMenuItem.Text = "Manage Status";
            this.manageStatusToolStripMenuItem.Click += new System.EventHandler(this.manageStatusToolStripMenuItem_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(89, 29);
            this.reportsToolStripMenuItem.Text = "Reports";
            this.reportsToolStripMenuItem.Click += new System.EventHandler(this.reportsToolStripMenuItem_Click);
            // 
            // productManagementToolStripMenuItem
            // 
            this.productManagementToolStripMenuItem.Name = "productManagementToolStripMenuItem";
            this.productManagementToolStripMenuItem.Size = new System.Drawing.Size(200, 29);
            this.productManagementToolStripMenuItem.Text = "Product Management";
            this.productManagementToolStripMenuItem.Click += new System.EventHandler(this.productManagementToolStripMenuItem_Click);
            // 
            // customerManagementToolStripMenuItem
            // 
            this.customerManagementToolStripMenuItem.Name = "customerManagementToolStripMenuItem";
            this.customerManagementToolStripMenuItem.Size = new System.Drawing.Size(215, 29);
            this.customerManagementToolStripMenuItem.Text = "Customer Management";
            this.customerManagementToolStripMenuItem.Click += new System.EventHandler(this.customerManagementToolStripMenuItem_Click);
            // 
            // linkLabellogout
            // 
            this.linkLabellogout.AutoSize = true;
            this.linkLabellogout.LinkColor = System.Drawing.Color.White;
            this.linkLabellogout.Location = new System.Drawing.Point(453, 682);
            this.linkLabellogout.Name = "linkLabellogout";
            this.linkLabellogout.Size = new System.Drawing.Size(62, 20);
            this.linkLabellogout.TabIndex = 22;
            this.linkLabellogout.TabStop = true;
            this.linkLabellogout.Text = "LogOut";
            this.linkLabellogout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabellogout_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(618, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(648, 55);
            this.label1.TabIndex = 23;
            this.label1.Text = "Transport Unit Management";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::eShiftCompany.Properties.Resources.Capture11;
            this.pictureBox2.Location = new System.Drawing.Point(67, 102);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(265, 232);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 25;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.pictureBox1.Location = new System.Drawing.Point(1, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(412, 841);
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            // 
            // TransportUnitManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.DarkCyan;
            this.ClientSize = new System.Drawing.Size(1494, 750);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.linkLabellogout);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgvUnits);
            this.Controls.Add(this.cbUnitType);
            this.Controls.Add(this.cbStatus);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.txtSizeorCapacity);
            this.Controls.Add(this.txtModelorLicense);
            this.Controls.Add(this.txtPlateorName);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.lblSizeorCapacity);
            this.Controls.Add(this.lblModelorLicense);
            this.Controls.Add(this.lblPlateorName);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.lblUnitType);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TransportUnitManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TransportUnitManagement";
            this.Load += new System.EventHandler(this.TransportUnitManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnits)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUnitType;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblPlateorName;
        private System.Windows.Forms.Label lblModelorLicense;
        private System.Windows.Forms.Label lblSizeorCapacity;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtPlateorName;
        private System.Windows.Forms.TextBox txtModelorLicense;
        private System.Windows.Forms.TextBox txtSizeorCapacity;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.ComboBox cbUnitType;
        private System.Windows.Forms.DataGridView dgvUnits;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem employeeRegistrationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transportUnitsManagementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadManagementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adminManagementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageStatusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productManagementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customerManagementToolStripMenuItem;
        private System.Windows.Forms.LinkLabel linkLabellogout;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}