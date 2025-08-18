namespace eShiftCompany
{
    partial class MyHistory
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
            this.createNewJobToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paymentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.myHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvUpcomingJobs = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.dgvJobHistory = new System.Windows.Forms.DataGridView();
            this.lblUpcoming = new System.Windows.Forms.Label();
            this.lblHistory = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblContact = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtContact = new System.Windows.Forms.TextBox();
            this.linkLabellogout = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUpcomingJobs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJobHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createNewJobToolStripMenuItem,
            this.paymentsToolStripMenuItem,
            this.myHistoryToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(1, 1);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(10, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(395, 35);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // createNewJobToolStripMenuItem
            // 
            this.createNewJobToolStripMenuItem.Name = "createNewJobToolStripMenuItem";
            this.createNewJobToolStripMenuItem.Size = new System.Drawing.Size(164, 29);
            this.createNewJobToolStripMenuItem.Text = "Request New Job";
            this.createNewJobToolStripMenuItem.Click += new System.EventHandler(this.createNewJobToolStripMenuItem_Click);
            // 
            // paymentsToolStripMenuItem
            // 
            this.paymentsToolStripMenuItem.Name = "paymentsToolStripMenuItem";
            this.paymentsToolStripMenuItem.Size = new System.Drawing.Size(104, 29);
            this.paymentsToolStripMenuItem.Text = "Payments";
            this.paymentsToolStripMenuItem.Click += new System.EventHandler(this.paymentsToolStripMenuItem_Click);
            // 
            // myHistoryToolStripMenuItem
            // 
            this.myHistoryToolStripMenuItem.BackColor = System.Drawing.Color.DarkSlateGray;
            this.myHistoryToolStripMenuItem.Name = "myHistoryToolStripMenuItem";
            this.myHistoryToolStripMenuItem.Size = new System.Drawing.Size(115, 29);
            this.myHistoryToolStripMenuItem.Text = "My History";
            // 
            // dgvUpcomingJobs
            // 
            this.dgvUpcomingJobs.BackgroundColor = System.Drawing.Color.DarkCyan;
            this.dgvUpcomingJobs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUpcomingJobs.GridColor = System.Drawing.Color.DarkCyan;
            this.dgvUpcomingJobs.Location = new System.Drawing.Point(322, 112);
            this.dgvUpcomingJobs.Name = "dgvUpcomingJobs";
            this.dgvUpcomingJobs.RowHeadersWidth = 62;
            this.dgvUpcomingJobs.RowTemplate.Height = 28;
            this.dgvUpcomingJobs.Size = new System.Drawing.Size(702, 171);
            this.dgvUpcomingJobs.TabIndex = 2;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRefresh.Location = new System.Drawing.Point(568, 625);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(116, 43);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // dgvJobHistory
            // 
            this.dgvJobHistory.BackgroundColor = System.Drawing.Color.DarkCyan;
            this.dgvJobHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvJobHistory.GridColor = System.Drawing.Color.DarkCyan;
            this.dgvJobHistory.Location = new System.Drawing.Point(322, 305);
            this.dgvJobHistory.Name = "dgvJobHistory";
            this.dgvJobHistory.RowHeadersWidth = 62;
            this.dgvJobHistory.RowTemplate.Height = 28;
            this.dgvJobHistory.Size = new System.Drawing.Size(702, 173);
            this.dgvJobHistory.TabIndex = 5;
            // 
            // lblUpcoming
            // 
            this.lblUpcoming.AutoSize = true;
            this.lblUpcoming.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpcoming.Location = new System.Drawing.Point(104, 175);
            this.lblUpcoming.Name = "lblUpcoming";
            this.lblUpcoming.Size = new System.Drawing.Size(132, 20);
            this.lblUpcoming.TabIndex = 6;
            this.lblUpcoming.Text = "Upcoming Jobs";
            // 
            // lblHistory
            // 
            this.lblHistory.AutoSize = true;
            this.lblHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHistory.Location = new System.Drawing.Point(104, 360);
            this.lblHistory.Name = "lblHistory";
            this.lblHistory.Size = new System.Drawing.Size(99, 20);
            this.lblHistory.TabIndex = 7;
            this.lblHistory.Text = "Job History";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(378, 525);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(55, 20);
            this.lblName.TabIndex = 8;
            this.lblName.Text = "Name";
            this.lblName.Click += new System.EventHandler(this.lblName_Click);
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(700, 525);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(53, 20);
            this.lblEmail.TabIndex = 9;
            this.lblEmail.Text = "Email";
            // 
            // lblContact
            // 
            this.lblContact.AutoSize = true;
            this.lblContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContact.Location = new System.Drawing.Point(952, 525);
            this.lblContact.Name = "lblContact";
            this.lblContact.Size = new System.Drawing.Size(72, 20);
            this.lblContact.TabIndex = 10;
            this.lblContact.Text = "Contact";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(287, 562);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(261, 26);
            this.txtName.TabIndex = 11;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(606, 561);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(246, 26);
            this.txtEmail.TabIndex = 12;
            // 
            // txtContact
            // 
            this.txtContact.Location = new System.Drawing.Point(904, 561);
            this.txtContact.Name = "txtContact";
            this.txtContact.Size = new System.Drawing.Size(214, 26);
            this.txtContact.TabIndex = 13;
            // 
            // linkLabellogout
            // 
            this.linkLabellogout.AutoSize = true;
            this.linkLabellogout.LinkColor = System.Drawing.Color.White;
            this.linkLabellogout.Location = new System.Drawing.Point(1053, 668);
            this.linkLabellogout.Name = "linkLabellogout";
            this.linkLabellogout.Size = new System.Drawing.Size(68, 20);
            this.linkLabellogout.TabIndex = 14;
            this.linkLabellogout.TabStop = true;
            this.linkLabellogout.Text = "LogOut";
            this.linkLabellogout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabellogout_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(559, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 52);
            this.label1.TabIndex = 15;
            this.label1.Text = "My History";
            // 
            // MyHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkCyan;
            this.ClientSize = new System.Drawing.Size(1177, 716);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.linkLabellogout);
            this.Controls.Add(this.txtContact);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblContact);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblHistory);
            this.Controls.Add(this.lblUpcoming);
            this.Controls.Add(this.dgvJobHistory);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.dgvUpcomingJobs);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MyHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MyHistory";
            this.Load += new System.EventHandler(this.MyHistory_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUpcomingJobs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJobHistory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem createNewJobToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paymentsToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvUpcomingJobs;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView dgvJobHistory;
        private System.Windows.Forms.Label lblUpcoming;
        private System.Windows.Forms.Label lblHistory;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblContact;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtContact;
        private System.Windows.Forms.LinkLabel linkLabellogout;
        private System.Windows.Forms.ToolStripMenuItem myHistoryToolStripMenuItem;
        private System.Windows.Forms.Label label1;
    }
}