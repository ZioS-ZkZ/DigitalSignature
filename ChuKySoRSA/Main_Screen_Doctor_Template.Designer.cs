//namespace ChuKySo
//{
//    partial class Main_Sreen_Doctor
//    {
//        /// <summary>
//        /// Required designer variable.
//        /// </summary>
//        private System.ComponentModel.IContainer components = null;

//        /// <summary>
//        /// Clean up any resources being used.
//        /// </summary>
//        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
//        protected override void Dispose(bool disposing)
//        {
//            if (disposing && (components != null))
//            {
//                components.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        #region Windows Form Designer generated code

//        /// <summary>
//        /// Required method for Designer support - do not modify
//        /// the contents of this method with the code editor.
//        /// </summary>
//        private void InitializeComponent()
//        {
//            mainPanel = new System.Windows.Forms.Panel();
//            btnCreateRecord = new System.Windows.Forms.Button();
//            listRecord = new System.Windows.Forms.Label();
//            detailDoctor = new System.Windows.Forms.Label();
//            headerPanel = new System.Windows.Forms.Panel();
//            txtAddress = new System.Windows.Forms.TextBox();
//            label6 = new System.Windows.Forms.Label();
//            txtBirth = new System.Windows.Forms.TextBox();
//            label5 = new System.Windows.Forms.Label();
//            txtSex = new System.Windows.Forms.TextBox();
//            label4 = new System.Windows.Forms.Label();
//            txtName = new System.Windows.Forms.TextBox();
//            label2 = new System.Windows.Forms.Label();
//            txtID = new System.Windows.Forms.TextBox();
//            label1 = new System.Windows.Forms.Label();
//            headerPanel.SuspendLayout();
//            this.SuspendLayout();
//            // 
//            // mainPanel
//            // 
//            mainPanel.AutoScroll = true;
//            mainPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
//            mainPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
//            mainPanel.Name = "mainPanel";
//            mainPanel.TabIndex = 1;
//            mainPanel.Left = 10;
//            mainPanel.Top = 274;
//            mainPanel.Width = 764;
//            mainPanel.Height = 428;
//            // 
//            // btnCreateRecord
//            // 
//            btnCreateRecord.Left = 659;
//            btnCreateRecord.Top = 226;
//            btnCreateRecord.Width = 114;
//            btnCreateRecord.Height = 42;
//            btnCreateRecord.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
//            btnCreateRecord.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
//            btnCreateRecord.Name = "btnCreateRecord";
//            btnCreateRecord.TabIndex = 2;
//            btnCreateRecord.Text = "Tạo Hồ sơ";
//            btnCreateRecord.UseVisualStyleBackColor = true;
//            btnCreateRecord.Click += new System.EventHandler(this.createRecord_Click);
//            // 
//            // listRecord
//            // 
//            listRecord.Left = 38;
//            listRecord.Top = 258;
//            listRecord.Width = 159;
//            listRecord.Height = 25;
//            listRecord.AutoSize = true;
//            listRecord.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
//            listRecord.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
//            listRecord.Name = "listRecord";
//            listRecord.TabIndex = 3;
//            listRecord.Text = "Danh sách Hồ sơ";
//            // 
//            // detailDoctor
//            // 
//            detailDoctor.Left = 38;
//            detailDoctor.Top = 12;
//            detailDoctor.Width = 153;
//            detailDoctor.Height = 25;
//            detailDoctor.AutoSize = true;
//            detailDoctor.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
//            detailDoctor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
//            detailDoctor.Name = "detailDoctor";
//            detailDoctor.TabIndex = 0;
//            detailDoctor.Text = "Thông tin Bác sĩ";
//            // 
//            // headerPanel
//            // 
//            headerPanel.Left = 10;
//            headerPanel.Top = 26;
//            headerPanel.Width = 764;
//            headerPanel.Height = 158;
//            headerPanel.AutoScroll = true;
//            headerPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
//            headerPanel.Controls.Add(txtAddress);
//            headerPanel.Controls.Add(label6);
//            headerPanel.Controls.Add(txtBirth);
//            headerPanel.Controls.Add(label5);
//            headerPanel.Controls.Add(txtSex);
//            headerPanel.Controls.Add(label4);
//            headerPanel.Controls.Add(txtName);
//            headerPanel.Controls.Add(label2);
//            headerPanel.Controls.Add(txtID);
//            headerPanel.Controls.Add(label1);
//            headerPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
//            headerPanel.Name = "headerPanel";
//            headerPanel.TabIndex = 2;
//            // 
//            // txtAddress
//            // 
//            txtAddress.Left = 122;
//            txtAddress.Top = 92;
//            txtAddress.Width = 508;
//            txtAddress.Height = 34;
//            txtAddress.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
//            txtAddress.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
//            txtAddress.Name = "txtAddress";
//            txtAddress.TabIndex = 9;
//            txtAddress.ReadOnly = true;
//            // 
//            // label6
//            // 
//            label6.Left = 20;
//            label6.Top = 92;
//            label6.Width = 71;
//            label6.Height = 28;
//            label6.AutoSize = true;
//            label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
//            label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
//            label6.Name = "label6";
//            label6.TabIndex = 8;
//            label6.Text = "Địa chỉ";
//            // 
//            // txtBirth
//            // 
//            txtBirth.Left = 629;
//            txtBirth.Top = 41;
//            txtBirth.Width = 131;
//            txtBirth.Height = 34;
//            txtBirth.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
//            txtBirth.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
//            txtBirth.Name = "txtBirth";
//            txtBirth.TabIndex = 7;
//            txtBirth.ReadOnly = true;
//            // 
//            // label5
//            // 
//            label5.Left = 536;
//            label5.Top = 41;
//            label5.Width = 94;
//            label5.Height = 28;
//            label5.AutoSize = true;
//            label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
//            label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
//            label5.Name = "label5";
//            label5.TabIndex = 6;
//            label5.Text = "Sinh nhật";
//            // 
//            // txtSex
//            // 
//            txtSex.Left = 461;
//            txtSex.Top = 41;
//            txtSex.Width = 71;
//            txtSex.Height = 34;
//            txtSex.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
//            txtSex.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
//            txtSex.Name = "txtSex";
//            txtSex.TabIndex = 5;
//            txtSex.ReadOnly = true;
//            // 
//            // label4
//            // 
//            label4.Left = 372;
//            label4.Top = 41;
//            label4.Width = 87;
//            label4.Height = 28;
//            label4.AutoSize = true;
//            label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
//            label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
//            label4.Name = "label4";
//            label4.TabIndex = 4;
//            label4.Text = "Giới tính";
//            // 
//            // txtName
//            // 
//            txtName.Left = 122;
//            txtName.Top = 38;
//            txtName.Width = 234;
//            txtName.Height = 34;
//            txtName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
//            txtName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
//            txtName.Name = "txtName";
//            txtName.TabIndex = 3;
//            txtName.ReadOnly = true;
//            // 
//            // label2
//            // 
//            label2.Left = 20;
//            label2.Top = 41;
//            label2.Width = 97;
//            label2.Height = 28;
//            label2.AutoSize = true;
//            label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
//            label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
//            label2.Name = "label2";
//            label2.TabIndex = 2;
//            label2.Text = "Họ và Tên";
//            // 
//            // txtID
//            //
//            //
//            txtID.Left = 644;
//            txtID.Top = 2;
//            txtID.Width = 116;
//            txtID.Height = 32;
//            txtID.Enabled = false;
//            txtID.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
//            txtID.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
//            txtID.Name = "txtID";
//            txtID.TabIndex = 1;
//            txtID.ReadOnly = true;
//            // 
//            // label1
//            // 
//            label1.Left = 612;
//            label1.Top = 5;
//            label1.Width = 30;
//            label1.Height = 25;
//            label1.AutoSize = true;
//            label1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
//            label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
//            label1.Name = "label1";
//            label1.TabIndex = 0;
//            label1.Text = "ID";
//            // 
//            // Main_Sreen_Doctor
//            // 
//            this.Width = 805;
//            this.Height = 760;
//            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
//            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
//            this.ClientSize = new System.Drawing.Size(782, 711);
//            this.Controls.Add(detailDoctor);
//            this.Controls.Add(headerPanel);
//            this.Controls.Add(listRecord);
//            this.Controls.Add(btnCreateRecord);
//            this.Controls.Add(mainPanel);
//            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
//            this.Name = "Main_Sreen_Doctor";
//            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
//            this.Text = "Quản lý Hồ sơ y tế số";
//            headerPanel.ResumeLayout(false);
//            headerPanel.PerformLayout();
//            this.ResumeLayout(false);
//            this.PerformLayout();

//        }

//        #endregion
//        public static System.Windows.Forms.Label detailDoctor;
//        public static System.Windows.Forms.Panel headerPanel;
//        public static System.Windows.Forms.TextBox txtID;
//        public static System.Windows.Forms.Label label1;
//        public static System.Windows.Forms.TextBox txtAddress;
//        public static System.Windows.Forms.Label label6;
//        public static System.Windows.Forms.TextBox txtBirth;
//        public static System.Windows.Forms.Label label5;
//        public static System.Windows.Forms.TextBox txtSex;
//        public static System.Windows.Forms.Label label4;
//        public static System.Windows.Forms.TextBox txtName;
//        public static System.Windows.Forms.Label label2;
//        public static System.Windows.Forms.Panel mainPanel;
//        public static System.Windows.Forms.Button btnCreateRecord;
//        public static System.Windows.Forms.Label listRecord;
//    }
//}