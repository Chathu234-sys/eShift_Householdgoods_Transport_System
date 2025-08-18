namespace eShiftCompany
{
    partial class ManageStatus
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.employeeRegistrationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transportUnitsManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adminManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customerManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblJobId = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cbJobId = new System.Windows.Forms.ComboBox();
            this.cbNewStatus = new System.Windows.Forms.ComboBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.dgvJobs = new System.Windows.Forms.DataGridView();
            this.lblKm = new System.Windows.Forms.Label();
            this.dtpJobDate = new System.Windows.Forms.DateTimePicker();
            this.numItems = new System.Windows.Forms.NumericUpDown();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtDistance = new System.Windows.Forms.TextBox();
            this.txtDestination = new System.Windows.Forms.TextBox();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.cbJob = new System.Windows.Forms.ComboBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblItems = new System.Windows.Forms.Label();
            this.lblDistance = new System.Windows.Forms.Label();
            this.lbldestination = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblReg = new System.Windows.Forms.Label();
            this.btnUpdateJob = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.linkLabel1logout = new System.Windows.Forms.LinkLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJobs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numItems)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
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
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1521, 36);
            this.menuStrip1.TabIndex = 32;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
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
            this.manageStatusToolStripMenuItem.BackColor = System.Drawing.Color.DarkSlateGray;
            this.manageStatusToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
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
            // lblJobId
            // 
            this.lblJobId.AutoSize = true;
            this.lblJobId.Font = new System.Drawing.Font("Microsoft YaHei", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJobId.Location = new System.Drawing.Point(33, 67);
            this.lblJobId.Name = "lblJobId";
            this.lblJobId.Size = new System.Drawing.Size(93, 22);
            this.lblJobId.TabIndex = 33;
            this.lblJobId.Text = "Select Job";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft YaHei", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(14, 124);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(126, 22);
            this.lblStatus.TabIndex = 34;
            this.lblStatus.Text = "Change Status";
            // 
            // cbJobId
            // 
            this.cbJobId.FormattingEnabled = true;
            this.cbJobId.Location = new System.Drawing.Point(146, 60);
            this.cbJobId.Name = "cbJobId";
            this.cbJobId.Size = new System.Drawing.Size(226, 35);
            this.cbJobId.TabIndex = 35;
            // 
            // cbNewStatus
            // 
            this.cbNewStatus.FormattingEnabled = true;
            this.cbNewStatus.Location = new System.Drawing.Point(146, 117);
            this.cbNewStatus.Name = "cbNewStatus";
            this.cbNewStatus.Size = new System.Drawing.Size(226, 35);
            this.cbNewStatus.TabIndex = 36;
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft YaHei", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnUpdate.Location = new System.Drawing.Point(197, 184);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(126, 45);
            this.btnUpdate.TabIndex = 37;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // dgvJobs
            // 
            this.dgvJobs.BackgroundColor = System.Drawing.Color.DarkCyan;
            this.dgvJobs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvJobs.GridColor = System.Drawing.Color.DarkCyan;
            this.dgvJobs.Location = new System.Drawing.Point(389, 40);
            this.dgvJobs.Name = "dgvJobs";
            this.dgvJobs.RowHeadersWidth = 62;
            this.dgvJobs.RowTemplate.Height = 28;
            this.dgvJobs.Size = new System.Drawing.Size(610, 218);
            this.dgvJobs.TabIndex = 38;
            // 
            // lblKm
            // 
            this.lblKm.AutoSize = true;
            this.lblKm.Font = new System.Drawing.Font("Microsoft YaHei", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKm.Location = new System.Drawing.Point(726, 272);
            this.lblKm.Name = "lblKm";
            this.lblKm.Size = new System.Drawing.Size(37, 22);
            this.lblKm.TabIndex = 53;
            this.lblKm.Text = "Km";
            // 
            // dtpJobDate
            // 
            this.dtpJobDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpJobDate.Location = new System.Drawing.Point(1024, 258);
            this.dtpJobDate.Name = "dtpJobDate";
            this.dtpJobDate.Size = new System.Drawing.Size(200, 26);
            this.dtpJobDate.TabIndex = 52;
            // 
            // numItems
            // 
            this.numItems.Location = new System.Drawing.Point(1024, 131);
            this.numItems.Name = "numItems";
            this.numItems.Size = new System.Drawing.Size(100, 26);
            this.numItems.TabIndex = 51;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(1024, 184);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(281, 48);
            this.txtDescription.TabIndex = 50;
            // 
            // txtDistance
            // 
            this.txtDistance.Location = new System.Drawing.Point(563, 269);
            this.txtDistance.Name = "txtDistance";
            this.txtDistance.Size = new System.Drawing.Size(157, 26);
            this.txtDistance.TabIndex = 49;
            // 
            // txtDestination
            // 
            this.txtDestination.Location = new System.Drawing.Point(563, 218);
            this.txtDestination.Name = "txtDestination";
            this.txtDestination.Size = new System.Drawing.Size(237, 26);
            this.txtDestination.TabIndex = 48;
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(563, 168);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(237, 26);
            this.txtLocation.TabIndex = 47;
            // 
            // cbJob
            // 
            this.cbJob.FormattingEnabled = true;
            this.cbJob.Location = new System.Drawing.Point(563, 118);
            this.cbJob.Name = "cbJob";
            this.cbJob.Size = new System.Drawing.Size(158, 28);
            this.cbJob.TabIndex = 46;
            this.cbJob.SelectedIndexChanged += new System.EventHandler(this.cbJob_SelectedIndexChanged);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft YaHei", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(589, 194);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(48, 22);
            this.lblDate.TabIndex = 45;
            this.lblDate.Text = "Date";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Microsoft YaHei", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(494, 133);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(146, 22);
            this.lblDescription.TabIndex = 44;
            this.lblDescription.Text = "Item Description";
            // 
            // lblItems
            // 
            this.lblItems.AutoSize = true;
            this.lblItems.Font = new System.Drawing.Font("Microsoft YaHei", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItems.Location = new System.Drawing.Point(491, 67);
            this.lblItems.Name = "lblItems";
            this.lblItems.Size = new System.Drawing.Size(149, 22);
            this.lblItems.TabIndex = 43;
            this.lblItems.Text = "Number of Items";
            // 
            // lblDistance
            // 
            this.lblDistance.AutoSize = true;
            this.lblDistance.Font = new System.Drawing.Font("Microsoft YaHei", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDistance.Location = new System.Drawing.Point(416, 272);
            this.lblDistance.Name = "lblDistance";
            this.lblDistance.Size = new System.Drawing.Size(79, 22);
            this.lblDistance.TabIndex = 42;
            this.lblDistance.Text = "Distance";
            // 
            // lbldestination
            // 
            this.lbldestination.AutoSize = true;
            this.lbldestination.Font = new System.Drawing.Font("Microsoft YaHei", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldestination.Location = new System.Drawing.Point(416, 221);
            this.lbldestination.Name = "lbldestination";
            this.lbldestination.Size = new System.Drawing.Size(104, 22);
            this.lbldestination.TabIndex = 41;
            this.lbldestination.Text = "Destination";
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Font = new System.Drawing.Font("Microsoft YaHei", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocation.Location = new System.Drawing.Point(416, 171);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(80, 22);
            this.lblLocation.TabIndex = 40;
            this.lblLocation.Text = "Location";
            // 
            // lblReg
            // 
            this.lblReg.AutoSize = true;
            this.lblReg.Font = new System.Drawing.Font("Microsoft YaHei", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReg.Location = new System.Drawing.Point(416, 118);
            this.lblReg.Name = "lblReg";
            this.lblReg.Size = new System.Drawing.Size(63, 22);
            this.lblReg.TabIndex = 39;
            this.lblReg.Text = "Job ID";
            // 
            // btnUpdateJob
            // 
            this.btnUpdateJob.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnUpdateJob.Font = new System.Drawing.Font("Microsoft YaHei", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateJob.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnUpdateJob.Location = new System.Drawing.Point(438, 253);
            this.btnUpdateJob.Name = "btnUpdateJob";
            this.btnUpdateJob.Size = new System.Drawing.Size(138, 43);
            this.btnUpdateJob.TabIndex = 54;
            this.btnUpdateJob.Text = "Update ";
            this.btnUpdateJob.UseVisualStyleBackColor = false;
            this.btnUpdateJob.Click += new System.EventHandler(this.btnUpdateJob_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnUpdateJob);
            this.groupBox1.Controls.Add(this.lblDate);
            this.groupBox1.Controls.Add(this.lblDescription);
            this.groupBox1.Controls.Add(this.lblItems);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(364, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1001, 314);
            this.groupBox1.TabIndex = 55;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Customer Transport Operations";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvJobs);
            this.groupBox2.Controls.Add(this.lblJobId);
            this.groupBox2.Controls.Add(this.lblStatus);
            this.groupBox2.Controls.Add(this.cbJobId);
            this.groupBox2.Controls.Add(this.cbNewStatus);
            this.groupBox2.Controls.Add(this.btnUpdate);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(354, 356);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1025, 280);
            this.groupBox2.TabIndex = 56;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Change Status";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // linkLabel1logout
            // 
            this.linkLabel1logout.AutoSize = true;
            this.linkLabel1logout.LinkColor = System.Drawing.Color.White;
            this.linkLabel1logout.Location = new System.Drawing.Point(1388, 53);
            this.linkLabel1logout.Name = "linkLabel1logout";
            this.linkLabel1logout.Size = new System.Drawing.Size(62, 20);
            this.linkLabel1logout.TabIndex = 57;
            this.linkLabel1logout.TabStop = true;
            this.linkLabel1logout.Text = "LogOut";
            this.linkLabel1logout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1logout_LinkClicked);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.pictureBox1.Location = new System.Drawing.Point(1, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(333, 745);
            this.pictureBox1.TabIndex = 58;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::eShiftCompany.Properties.Resources.Capture11;
            this.pictureBox2.Location = new System.Drawing.Point(48, 106);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(237, 216);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 59;
            this.pictureBox2.TabStop = false;
            // 
            // ManageStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.DarkCyan;
            this.ClientSize = new System.Drawing.Size(1521, 748);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.linkLabel1logout);
            this.Controls.Add(this.lblKm);
            this.Controls.Add(this.dtpJobDate);
            this.Controls.Add(this.numItems);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtDistance);
            this.Controls.Add(this.txtDestination);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.cbJob);
            this.Controls.Add(this.lblDistance);
            this.Controls.Add(this.lbldestination);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.lblReg);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ManageStatus";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ManageStatus";
            this.Load += new System.EventHandler(this.ManageStatus_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJobs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numItems)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem employeeRegistrationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transportUnitsManagementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadManagementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adminManagementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageStatusToolStripMenuItem;
        private System.Windows.Forms.Label lblJobId;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cbJobId;
        private System.Windows.Forms.ComboBox cbNewStatus;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.DataGridView dgvJobs;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.Label lblKm;
        private System.Windows.Forms.DateTimePicker dtpJobDate;
        private System.Windows.Forms.NumericUpDown numItems;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtDistance;
        private System.Windows.Forms.TextBox txtDestination;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.ComboBox cbJob;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblItems;
        private System.Windows.Forms.Label lblDistance;
        private System.Windows.Forms.Label lbldestination;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label lblReg;
        private System.Windows.Forms.Button btnUpdateJob;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolStripMenuItem productManagementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customerManagementToolStripMenuItem;
        private System.Windows.Forms.LinkLabel linkLabel1logout;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}