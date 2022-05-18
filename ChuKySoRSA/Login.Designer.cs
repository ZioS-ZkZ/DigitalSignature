namespace ChuKySo
{
    partial class Login
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
            this.plDisplay2 = new System.Windows.Forms.Panel();
            this.btLogin = new System.Windows.Forms.Button();
            this.btRegis = new System.Windows.Forms.Button();
            this.plDisplay1 = new System.Windows.Forms.Panel();
            this.cbDone = new System.Windows.Forms.CheckBox();
            this.cbPos = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.birthDay = new System.Windows.Forms.DateTimePicker();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbNu = new System.Windows.Forms.CheckBox();
            this.cbNam = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbHienThiPass = new System.Windows.Forms.CheckBox();
            this.plDisplay2.SuspendLayout();
            this.plDisplay1.SuspendLayout();
            this.SuspendLayout();
            // 
            // plDisplay2
            // 
            this.plDisplay2.Controls.Add(this.btLogin);
            this.plDisplay2.Controls.Add(this.btRegis);
            this.plDisplay2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.plDisplay2.Location = new System.Drawing.Point(0, 458);
            this.plDisplay2.Name = "plDisplay2";
            this.plDisplay2.Size = new System.Drawing.Size(722, 121);
            this.plDisplay2.TabIndex = 0;
            // 
            // btLogin
            // 
            this.btLogin.Location = new System.Drawing.Point(435, 25);
            this.btLogin.Name = "btLogin";
            this.btLogin.Size = new System.Drawing.Size(151, 62);
            this.btLogin.TabIndex = 1;
            this.btLogin.Text = "Login";
            this.btLogin.UseVisualStyleBackColor = true;
            this.btLogin.Click += new System.EventHandler(this.btLogin_Click);
            // 
            // btRegis
            // 
            this.btRegis.Location = new System.Drawing.Point(172, 25);
            this.btRegis.Name = "btRegis";
            this.btRegis.Size = new System.Drawing.Size(151, 62);
            this.btRegis.TabIndex = 0;
            this.btRegis.Text = "Registration";
            this.btRegis.UseVisualStyleBackColor = true;
            this.btRegis.Click += new System.EventHandler(this.btRegis_Click);
            // 
            // plDisplay1
            // 
            this.plDisplay1.Controls.Add(this.cbHienThiPass);
            this.plDisplay1.Controls.Add(this.cbDone);
            this.plDisplay1.Controls.Add(this.cbPos);
            this.plDisplay1.Controls.Add(this.label7);
            this.plDisplay1.Controls.Add(this.label6);
            this.plDisplay1.Controls.Add(this.birthDay);
            this.plDisplay1.Controls.Add(this.txtAddress);
            this.plDisplay1.Controls.Add(this.label5);
            this.plDisplay1.Controls.Add(this.cbNu);
            this.plDisplay1.Controls.Add(this.cbNam);
            this.plDisplay1.Controls.Add(this.label4);
            this.plDisplay1.Controls.Add(this.txtName);
            this.plDisplay1.Controls.Add(this.label3);
            this.plDisplay1.Controls.Add(this.txtPassword);
            this.plDisplay1.Controls.Add(this.label2);
            this.plDisplay1.Controls.Add(this.txtUsername);
            this.plDisplay1.Controls.Add(this.label1);
            this.plDisplay1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plDisplay1.Location = new System.Drawing.Point(0, 0);
            this.plDisplay1.Name = "plDisplay1";
            this.plDisplay1.Size = new System.Drawing.Size(722, 458);
            this.plDisplay1.TabIndex = 1;
            // 
            // cbDone
            // 
            this.cbDone.AutoSize = true;
            this.cbDone.Location = new System.Drawing.Point(232, 428);
            this.cbDone.Name = "cbDone";
            this.cbDone.Size = new System.Drawing.Size(322, 24);
            this.cbDone.TabIndex = 15;
            this.cbDone.Text = "Tôi cam đoan thông tin trên là đúng sự thật ";
            this.cbDone.UseVisualStyleBackColor = true;
            // 
            // cbPos
            // 
            this.cbPos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPos.FormattingEnabled = true;
            this.cbPos.Items.AddRange(new object[] {
            "Doctor",
            "Patien"});
            this.cbPos.Location = new System.Drawing.Point(264, 380);
            this.cbPos.Name = "cbPos";
            this.cbPos.Size = new System.Drawing.Size(273, 28);
            this.cbPos.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(155, 380);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 20);
            this.label7.TabIndex = 13;
            this.label7.Text = "Position";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(155, 317);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "Birthday";
            // 
            // birthDay
            // 
            this.birthDay.Location = new System.Drawing.Point(264, 312);
            this.birthDay.Name = "birthDay";
            this.birthDay.Size = new System.Drawing.Size(273, 27);
            this.birthDay.TabIndex = 11;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(264, 251);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(273, 27);
            this.txtAddress.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(155, 258);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Address";
            // 
            // cbNu
            // 
            this.cbNu.AutoSize = true;
            this.cbNu.Location = new System.Drawing.Point(367, 196);
            this.cbNu.Name = "cbNu";
            this.cbNu.Size = new System.Drawing.Size(51, 24);
            this.cbNu.TabIndex = 8;
            this.cbNu.Text = "Nữ";
            this.cbNu.UseVisualStyleBackColor = true;
            // 
            // cbNam
            // 
            this.cbNam.AutoSize = true;
            this.cbNam.Location = new System.Drawing.Point(264, 196);
            this.cbNam.Name = "cbNam";
            this.cbNam.Size = new System.Drawing.Size(63, 24);
            this.cbNam.TabIndex = 7;
            this.cbNam.Text = "Nam";
            this.cbNam.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(155, 196);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Sex ";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(264, 130);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(273, 27);
            this.txtName.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(155, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Name";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(264, 76);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(273, 27);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(155, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(264, 25);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(273, 27);
            this.txtUsername.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(155, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username";
            // 
            // cbHienThiPass
            // 
            this.cbHienThiPass.AutoSize = true;
            this.cbHienThiPass.Location = new System.Drawing.Point(552, 79);
            this.cbHienThiPass.Name = "cbHienThiPass";
            this.cbHienThiPass.Size = new System.Drawing.Size(148, 24);
            this.cbHienThiPass.TabIndex = 16;
            this.cbHienThiPass.Text = "Hiển thị mật khẩu";
            this.cbHienThiPass.UseVisualStyleBackColor = true;
            this.cbHienThiPass.CheckedChanged += new System.EventHandler(this.cbHienThiPass_CheckedChanged);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 579);
            this.Controls.Add(this.plDisplay1);
            this.Controls.Add(this.plDisplay2);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.plDisplay2.ResumeLayout(false);
            this.plDisplay1.ResumeLayout(false);
            this.plDisplay1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel plDisplay2;
        private System.Windows.Forms.Button btLogin;
        private System.Windows.Forms.Button btRegis;
        private System.Windows.Forms.Panel plDisplay1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker birthDay;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cbNu;
        private System.Windows.Forms.CheckBox cbNam;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbPos;
        private System.Windows.Forms.CheckBox cbDone;
        private System.Windows.Forms.CheckBox cbHienThiPass;
    }
}