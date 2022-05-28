namespace ChuKySo
{
	partial class Main_Sreen_Doctor
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
			btnCreateRecord = new System.Windows.Forms.Button();
			detailDoctor = new System.Windows.Forms.Label();
			headerPanel = new System.Windows.Forms.Panel();
			txtAddress = new System.Windows.Forms.TextBox();
			label6 = new System.Windows.Forms.Label();
			txtBirth = new System.Windows.Forms.TextBox();
			label5 = new System.Windows.Forms.Label();
			txtSex = new System.Windows.Forms.TextBox();
			label4 = new System.Windows.Forms.Label();
			txtName = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			txtID = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			listRecord = new System.Windows.Forms.Label();
			mainPanel = new System.Windows.Forms.Panel();
			headerPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnCreateRecord
			// 
			btnCreateRecord.Left = 807;
			btnCreateRecord.Top = 279;
			btnCreateRecord.Width = 155;
			btnCreateRecord.Height = 48;
			btnCreateRecord.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			btnCreateRecord.Margin = new System.Windows.Forms.Padding(2);
			btnCreateRecord.Name = "btnCreateRecord";
			btnCreateRecord.TabIndex = 2;
			btnCreateRecord.Text = "Tạo Hồ Sơ";
			btnCreateRecord.UseVisualStyleBackColor = true;
			btnCreateRecord.Click += new System.EventHandler(this.createRecord_Click);
			// 
			// detailDoctor
			// 
			detailDoctor.AutoSize = true;
			detailDoctor.Left = 38;
			detailDoctor.Top = 10;
			detailDoctor.Width = 199;
			detailDoctor.Height = 25;
			detailDoctor.AutoSize = true;
			detailDoctor.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			detailDoctor.Name = "detailDoctor";
			detailDoctor.TabIndex = 7;
			detailDoctor.Text = "Thông tin Bác sĩ";
			// 
			// headerPanel
			// 
			headerPanel.AutoScroll = true;
			headerPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			headerPanel.Controls.Add(txtAddress);
			headerPanel.Controls.Add(label6);
			headerPanel.Controls.Add(txtBirth);
			headerPanel.Controls.Add(label5);
			headerPanel.Controls.Add(txtSex);
			headerPanel.Controls.Add(label4);
			headerPanel.Controls.Add(txtName);
			headerPanel.Controls.Add(label2);
			headerPanel.Controls.Add(txtID);
			headerPanel.Controls.Add(label1);
			headerPanel.Location = new System.Drawing.Point(12, 30);
			headerPanel.Name = "headerPanel";
			headerPanel.Size = new System.Drawing.Size(954, 197);
			headerPanel.TabIndex = 8;
			// 
			// txtAddress
			// 
			txtAddress.Left = 152;
			txtAddress.Top = 149;
			txtAddress.Width = 528;
			txtAddress.Height = 39;
			txtAddress.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			txtAddress.Name = "txtAddress";
			txtAddress.TabIndex = 9;
			txtAddress.ReadOnly = true;
			// 
			// label6
			// 
			label6.Left = 25;
			label6.Top = 152;
			label6.Width = 87;
			label6.Height = 32;
			label6.AutoSize = true;
			label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			label6.Name = "label6";
			label6.TabIndex = 8;
			label6.Text = "Địa chỉ";
			// 
			// txtBirth
			// 
			txtBirth.Left = 152;
			txtBirth.Top = 98;
			txtBirth.Width = 256;
			txtBirth.Height = 39;
			txtBirth.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			txtBirth.Name = "txtBirth";
			txtBirth.TabIndex = 7;
			txtBirth.ReadOnly = true;
			// 
			// label5
			// 
			label5.Left = 25;
			label5.Top = 101;
			label5.Width = 116;
			label5.Height = 32;
			label5.AutoSize = true;
			label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			label5.Name = "label5";
			label5.TabIndex = 6;
			label5.Text = "Ngày sinh";
			// 
			// txtSex
			// 
			txtSex.Left = 693;
			txtSex.Top = 46;
			txtSex.Width = 88;
			txtSex.Height = 39;
			txtSex.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			txtSex.Name = "txtSex";
			txtSex.TabIndex = 5;
			txtSex.ReadOnly = true;
			// 
			// label4
			// 
			label4.Left = 582;
			label4.Top = 49;
			label4.Width = 105;
			label4.Height = 32;
			label4.AutoSize = true;
			label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			label4.Name = "label4";
			label4.TabIndex = 4;
			label4.Text = "Giới tính";
			// 
			// txtName
			//
			txtName.Left = 152;
			txtName.Top = 46;
			txtName.Width = 292;
			txtName.Height = 39;
			txtName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			txtName.Name = "txtName";
			txtName.TabIndex = 3;
			txtName.ReadOnly = true;
			// 
			// label2
			// 
			label2.Left = 25;
			label2.Top = 51;
			label2.Width = 121;
			label2.Height = 32;
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			label2.Name = "label2";
			label2.TabIndex = 2;
			label2.Text = "Họ và Tên";
			// 
			// txtID
			// 
			txtID.Left = 862;
			txtID.Top = 3;
			txtID.Width = 87;
			txtID.Height = 37;
			txtID.Enabled = false;
			txtID.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			txtID.Name = "txtID";
			txtID.TabIndex = 1;
			txtID.ReadOnly = true;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			label1.Name = "label1";
			label1.Left = 822;
			label1.Top = 6;
			label1.Width = 34;
			label1.Height = 30;
			label1.TabIndex = 0;
			label1.Text = "ID";
			// 
			// listRecord
			// 
			listRecord.Left = 47;
			listRecord.Top = 321;
			listRecord.Width = 185;
			listRecord.Height = 30;
			listRecord.AutoSize = true;
			listRecord.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			listRecord.Name = "listRecord";
			listRecord.TabIndex = 8;
			listRecord.Text = "Danh sách Hồ sơ";
			// 
			// mainPanel
			// 
			mainPanel.AutoScroll = true;
			mainPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			mainPanel.Left = 12;
			mainPanel.Top = 340;
			mainPanel.Width = 954;
			mainPanel.Height = 535;
			mainPanel.Name = "mainPanel";
			mainPanel.TabIndex = 5;
			// 
			// Main_Sreen_Doctor
			// 
			this.Width = 1000;
			this.Height = 945;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(listRecord);
			this.Controls.Add(mainPanel);
			this.Controls.Add(detailDoctor);
			this.Controls.Add(headerPanel);
			this.Controls.Add(btnCreateRecord);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "Main_Sreen_Doctor";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Quản lý Hồ sơ y tế số";
			headerPanel.ResumeLayout(false);
			headerPanel.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		public static System.Windows.Forms.Button btnCreateRecord;
		public static System.Windows.Forms.Label detailDoctor;
		public static System.Windows.Forms.Panel headerPanel;
		public static System.Windows.Forms.TextBox txtAddress;
		public static System.Windows.Forms.Label label6;
		public static System.Windows.Forms.TextBox txtBirth;
		public static System.Windows.Forms.Label label5;
		public static System.Windows.Forms.TextBox txtSex;
		public static System.Windows.Forms.Label label4;
		public static System.Windows.Forms.TextBox txtName;
		public static System.Windows.Forms.Label label2;
		public static System.Windows.Forms.TextBox txtID;
		public static System.Windows.Forms.Label label1;
		public static System.Windows.Forms.Label listRecord;
		public static System.Windows.Forms.Panel mainPanel;
	}
}