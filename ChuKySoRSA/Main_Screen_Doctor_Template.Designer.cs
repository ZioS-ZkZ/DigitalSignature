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
//            mainPanel.Location = new System.Drawing.Point(10, 274);
//            mainPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
//            mainPanel.Name = "mainPanel";
//            mainPanel.Size = new System.Drawing.Size(764, 428);
//            mainPanel.TabIndex = 1;
//            // 
//            // btnCreateRecord
//            // 
//            btnCreateRecord.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
//            btnCreateRecord.Location = new System.Drawing.Point(659, 226);
//            btnCreateRecord.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
//            btnCreateRecord.Name = "btnCreateRecord";
//            btnCreateRecord.Size = new System.Drawing.Size(114, 42);
//            btnCreateRecord.TabIndex = 2;
//            btnCreateRecord.Text = "Tạo Hồ sơ";
//            btnCreateRecord.UseVisualStyleBackColor = true;
//            btnCreateRecord.Click += new System.EventHandler(this.createRecord_Click);
//            // 
//            // listRecord
//            // 
//            listRecord.AutoSize = true;
//            listRecord.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
//            listRecord.Location = new System.Drawing.Point(38, 258);
//            listRecord.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
//            listRecord.Name = "listRecord";
//            listRecord.Size = new System.Drawing.Size(159, 25);
//            listRecord.TabIndex = 3;
//            listRecord.Text = "Danh sách Hồ sơ";
//            // 
//            // detailDoctor
//            // 
//            detailDoctor.AutoSize = true;
//            detailDoctor.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
//            detailDoctor.Location = new System.Drawing.Point(38, 12);
//            detailDoctor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
//            detailDoctor.Name = "detailDoctor";
//            detailDoctor.Size = new System.Drawing.Size(153, 25);
//            detailDoctor.TabIndex = 0;
//            detailDoctor.Text = "Thông tin Bác sĩ";
//            // 
//            // headerPanel
//            // 
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
//            headerPanel.Location = new System.Drawing.Point(10, 26);
//            headerPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
//            headerPanel.Name = "headerPanel";
//            headerPanel.Size = new System.Drawing.Size(764, 158);
//            headerPanel.TabIndex = 2;
//            // 
//            // txtAddress
//            // 
//            txtAddress.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
//            txtAddress.Location = new System.Drawing.Point(122, 92);
//            txtAddress.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
//            txtAddress.Name = "txtAddress";
//            txtAddress.Size = new System.Drawing.Size(508, 34);
//            txtAddress.TabIndex = 9;
//            txtAddress.ReadOnly = true;
//            // 
//            // label6
//            // 
//            label6.AutoSize = true;
//            label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
//            label6.Location = new System.Drawing.Point(20, 92);
//            label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
//            label6.Name = "label6";
//            label6.Size = new System.Drawing.Size(71, 28);
//            label6.TabIndex = 8;
//            label6.Text = "Địa chỉ";
//            // 
//            // txtBirth
//            // 
//            txtBirth.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
//            txtBirth.Location = new System.Drawing.Point(629, 41);
//            txtBirth.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
//            txtBirth.Name = "txtBirth";
//            txtBirth.Size = new System.Drawing.Size(131, 34);
//            txtBirth.TabIndex = 7;
//            txtBirth.ReadOnly = true;
//            // 
//            // label5
//            // 
//            label5.AutoSize = true;
//            label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
//            label5.Location = new System.Drawing.Point(536, 41);
//            label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
//            label5.Name = "label5";
//            label5.Size = new System.Drawing.Size(94, 28);
//            label5.TabIndex = 6;
//            label5.Text = "Sinh nhật";
//            // 
//            // txtSex
//            // 
//            txtSex.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
//            txtSex.Location = new System.Drawing.Point(461, 41);
//            txtSex.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
//            txtSex.Name = "txtSex";
//            txtSex.Size = new System.Drawing.Size(71, 34);
//            txtSex.TabIndex = 5;
//            txtSex.ReadOnly = true;
//            // 
//            // label4
//            // 
//            label4.AutoSize = true;
//            label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
//            label4.Location = new System.Drawing.Point(372, 41);
//            label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
//            label4.Name = "label4";
//            label4.Size = new System.Drawing.Size(87, 28);
//            label4.TabIndex = 4;
//            label4.Text = "Giới tính";
//            // 
//            // txtName
//            // 
//            txtName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
//            txtName.Location = new System.Drawing.Point(122, 38);
//            txtName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
//            txtName.Name = "txtName";
//            txtName.Size = new System.Drawing.Size(234, 34);
//            txtName.TabIndex = 3;
//            txtName.ReadOnly = true;
//            // 
//            // label2
//            // 
//            label2.AutoSize = true;
//            label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
//            label2.Location = new System.Drawing.Point(20, 41);
//            label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
//            label2.Name = "label2";
//            label2.Size = new System.Drawing.Size(97, 28);
//            label2.TabIndex = 2;
//            label2.Text = "Họ và Tên";
//            // 
//            // txtID
//            // 
//            txtID.Enabled = false;
//            txtID.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
//            txtID.Location = new System.Drawing.Point(644, 2);
//            txtID.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
//            txtID.Name = "txtID";
//            txtID.Size = new System.Drawing.Size(116, 32);
//            txtID.TabIndex = 1;
//            txtID.ReadOnly = true;
//            // 
//            // label1
//            // 
//            label1.AutoSize = true;
//            label1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
//            label1.Location = new System.Drawing.Point(612, 5);
//            label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
//            label1.Name = "label1";
//            label1.Size = new System.Drawing.Size(30, 25);
//            label1.TabIndex = 0;
//            label1.Text = "ID";
//            // 
//            // Main_Sreen_Doctor
//            // 
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