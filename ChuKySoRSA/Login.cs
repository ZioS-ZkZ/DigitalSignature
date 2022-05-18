using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using Waher.Security.EllipticCurves;
using System.IO;
using MySql.Data.MySqlClient;
namespace ChuKySo
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btRegis_Click(object sender, EventArgs e)
        {
            if (cbDone.Checked)
            {
                if (txtUsername.Text == string.Empty || txtPassword.Text == string.Empty 
                    || (cbNam.Checked == false&&cbNu.Checked==false) || txtAddress.Text ==string.Empty
                    ||cbPos.Text == string.Empty)
                {
                    cbDone.Checked = false;
                    MessageBox.Show("Bạn chưa điền đầy đủ thông tin !!!","Thông báo !!!",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                {
                    Aes myAes = Aes.Create();
                    myAes.KeySize = 256;
                    myAes.BlockSize = 128;
                    myAes.Mode = CipherMode.CBC;
                    myAes.Padding = PaddingMode.PKCS7;
                    myAes.GenerateIV();
                    myAes.GenerateKey();
                    byte[] encryptedPass =CreateRecord.EncryptStringToBytes_Aes(txtPassword.Text, myAes.Key, myAes.IV);
                    string inforSavePass = Convert.ToBase64String(encryptedPass);
                    byte[] encryptedName = CreateRecord.EncryptStringToBytes_Aes(txtName.Text, myAes.Key, myAes.IV);
                    string inforSaveName = Convert.ToBase64String(encryptedName);
                    byte[] encryptedAddress = CreateRecord.EncryptStringToBytes_Aes(txtAddress.Text, myAes.Key, myAes.IV);
                    string inforSaveAddress = Convert.ToBase64String(encryptedAddress);
                    byte[] encryptedSex = CreateRecord.EncryptStringToBytes_Aes((cbNam.Checked)? cbNam.Text: cbNu.Text, myAes.Key, myAes.IV);
                    string inforSaveSex = Convert.ToBase64String(encryptedSex);
                    byte[] encryptedBirth = CreateRecord.EncryptStringToBytes_Aes(birthDay.Text, myAes.Key, myAes.IV);
                    string inforSaveBirth = Convert.ToBase64String(encryptedBirth);
                    string stringKeyaes = Convert.ToBase64String(myAes.Key);
                    string stringIVaes = Convert.ToBase64String(myAes.IV);
                    string idAccount = "";
                    string query = "";
                    if (cbPos.Text == "Doctor")
                    {
                        query = "SELECT id_account FROM account WHERE position = 'Doctor' ORDER BY id_account DESC LIMIT 1";
                        if(Convert.ToString(CreateRecord.SelectData(query, "")[0,0]) == null)
                        {
                            idAccount = "DT1";
                        }
                        else
                        {
                            int numIdNext = Convert.ToInt16(Convert.ToString(CreateRecord.SelectData(query, "")[0, 0]).Substring(2)) + 1;
                            idAccount = "DT" + numIdNext.ToString();
                        }

                    }
                    else if(cbPos.Text == "Patien")
                    {
                        query = "SELECT id_account FROM account WHERE position = 'Patien' ORDER BY id_account DESC LIMIT 1";
                        if (Convert.ToString(CreateRecord.SelectData(query, "")[0, 0]) == null)
                        {
                            idAccount = "PT1";
                        }
                        else
                        {
                            int numIdNext = Convert.ToInt16(Convert.ToString(CreateRecord.SelectData(query, "")[0, 0]).Substring(2)) + 1;
                            idAccount = "PT" + numIdNext.ToString();
                        }

                    }
                    query = "SELECT username FROM account WHERE username = '" + txtUsername.Text + "'";
                    //Insert to database
                    if (txtUsername.Text != Convert.ToString(CreateRecord.SelectData(query, "")[0, 0]))
                    {
                         query = "INSERT INTO account (id_account, username, password, name, sex, address, birthday,position, keyAES, IV) VALUES ('" + idAccount + "', '" + txtUsername.Text + "', '" + inforSavePass + "','" + inforSaveName + "','" + inforSaveSex + "','" + inforSaveAddress + "','" + inforSaveBirth + "', '" + cbPos.Text + "','" + stringKeyaes + "','" + stringIVaes + "')";
                        CreateRecord.ImplementQuery(query, "Tạo tài khoản thành công");
                    }
                    else
                    {
                        MessageBox.Show("Username đã được chọn, Vui lòng chọn username khác !!!", "Thông báo !!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtUsername.Text = string.Empty;

                    }
                    cbPos.Text = txtAddress.Text = txtName.Text = txtPassword.Text = txtUsername.Text = string.Empty;
                    cbNam.Checked = cbNu.Checked =cbDone.Checked= false;

                }
            }
            else
            {
                this.plDisplay1.Controls.Clear();
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
                this.plDisplay2.Controls.Add(this.btLogin);
                cbPos.Text = txtAddress.Text=txtName.Text=txtPassword.Text=txtUsername.Text = string.Empty;
                cbNam.Checked = cbNu.Checked = false;
            }

        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            plDisplay1.Controls.Clear();
            
            Label lbUsername = new Label();
            Label lbPassword = new Label();
            TextBox txtUserLogin = new TextBox();
            TextBox txtPassLogin = new TextBox();
            CheckBox cbCheck = new CheckBox();
            // 
            // cbCheck
            // 
            cbCheck.Width = 322;
            cbCheck.Height = 24;
            cbCheck.Left = 250;
            cbCheck.Top = 280;
            cbCheck.Text = "Tôi không phải người máy";
            cbCheck.UseVisualStyleBackColor = true;

            txtPassLogin.Width = 273;
            txtPassLogin.Height = 27;
            txtPassLogin.Left = 332;
            txtPassLogin.Top = 220;
            txtPassLogin.TabIndex = 1;
            txtPassLogin.UseSystemPasswordChar = true;
            lbPassword.Width = 70;
            lbPassword.Height = 20;
            lbPassword.Left = 150;
            lbPassword.Top = 220;
            lbPassword.Text = "Password";
            // 
            // txtUsername
            // 
            txtUserLogin.Width = 273;
            txtUserLogin.Height = 27;
            txtUserLogin.Left = 332;
            txtUserLogin.Top = 180;
            txtUserLogin.TabIndex = 0;
            lbUsername.Width =75 ;
            lbUsername.Height = 20;
            lbUsername.Left = 150;
            lbUsername.Top = 180;
            lbUsername.Text = "Username";
            plDisplay1.Controls.Add(lbUsername);
            plDisplay1.Controls.Add(lbPassword);
            plDisplay1.Controls.Add(txtPassLogin);
            plDisplay1.Controls.Add(txtUserLogin);
            plDisplay1.Controls.Add(cbCheck);
            //
            //btLoginNew
            //
            plDisplay2.Controls.Remove(btLogin);
            Button btLoginNew = new Button();
            btLoginNew.Width = 151;
            btLoginNew.Height = 62;
            btLoginNew.Left = 432;
            btLoginNew.Top = 25;
            btLoginNew.Text = "Login";
            btLoginNew.UseVisualStyleBackColor = true;
            plDisplay2.Controls.Add(btLoginNew);
            btLoginNew.Click += (sender, e) =>
            {
                if (cbCheck.Checked)
                {
                    if (txtUserLogin.Text == string.Empty || txtPassLogin.Text == string.Empty)
                        MessageBox.Show("Vui lòng nhập đầy đủ thông tin !!!", "Thông báo !!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                    {
                        string querySelectID = "SELECT id_account FROM account WHERE username = '" + txtUserLogin.Text + "'";
                        string querySelectName = "SELECT name FROM account WHERE username = '" + txtUserLogin.Text + "'";
                        string querySelectUsername = "SELECT username FROM account WHERE username = '" + txtUserLogin.Text + "'";
                        string querySelectPassword = "SELECT password FROM account WHERE username = '" + txtUserLogin.Text + "'";
                        string querySelectSex = "SELECT sex FROM account WHERE username = '" + txtUserLogin.Text + "'";
                        string querySelectAddress = "SELECT address FROM account WHERE username = '" + txtUserLogin.Text + "'";
                        string querySelectBirth = "SELECT birthday FROM account WHERE username = '" + txtUserLogin.Text + "'";
                        string querySelectPos = "SELECT position FROM account WHERE username = '" + txtUserLogin.Text + "'";
                        string querySelectKeyAes = "SELECT keyAES FROM account WHERE username = '" + txtUserLogin.Text + "'";
                        string querySelectIVAes = "SELECT IV FROM account WHERE username = '" + txtUserLogin.Text + "'";
                        byte[] Key = Convert.FromBase64String(CreateRecord.SelectData(querySelectKeyAes, "")[0, 0]);
                        byte[] IV = Convert.FromBase64String(CreateRecord.SelectData(querySelectIVAes, "")[0, 0]);
                        string password = CreateRecord.DecryptStringFromBytes_Aes(Convert.FromBase64String(CreateRecord.SelectData(querySelectPassword, "")[0, 0]), Key, IV);
                        if (Convert.ToString(CreateRecord.SelectData(querySelectUsername, "Tài khoản không tồn tại")[0, 0]) != null
                            && txtUserLogin.Text == Convert.ToString(CreateRecord.SelectData(querySelectUsername, "Tài khoản không tồn tại")[0, 0])
                            && txtPassLogin.Text == password)
                        {
                           if(Convert.ToString(CreateRecord.SelectData(querySelectPos, "")[0, 0]) == "Doctor")
                           {
                                Main_Sreen_Doctor.DoctorName = CreateRecord.DecryptStringFromBytes_Aes(Convert.FromBase64String(CreateRecord.SelectData(querySelectName, "")[0, 0]), Key, IV);
                                Main_Sreen_Doctor.DoctorID = Convert.ToString(CreateRecord.SelectData(querySelectID, "")[0, 0]);
                                Main_Sreen_Doctor formDoctor = new Main_Sreen_Doctor();
                                Main_Sreen_Doctor.txtID.Text = CreateRecord.SelectData(querySelectID, "")[0, 0];
                                Main_Sreen_Doctor.txtName.Text = CreateRecord.DecryptStringFromBytes_Aes(Convert.FromBase64String(CreateRecord.SelectData(querySelectName, "")[0, 0]), Key, IV);
                                //Main_Sreen_Doctor.txtSex.Text = CreateRecord.DecryptStringFromBytes_Aes(Convert.FromBase64String(CreateRecord.SelectData(querySelectSex, "")[0, 0]), Key, IV);
                                //Main_Sreen_Doctor.txtBirth.Text = CreateRecord.DecryptStringFromBytes_Aes(Convert.FromBase64String(CreateRecord.SelectData(querySelectBirth, "")[0, 0]), Key, IV);
                                Main_Sreen_Doctor.txtAddress.Text = CreateRecord.DecryptStringFromBytes_Aes(Convert.FromBase64String(CreateRecord.SelectData(querySelectAddress, "")[0, 0]), Key, IV);

                                this.Hide();
                                formDoctor.ShowDialog();
                                this.Show();
                            }
                            else
                            {
                                Main_Screen_Patient.PatientID = Convert.ToString(CreateRecord.SelectData(querySelectID, "")[0, 0]);
                                Main_Screen_Patient formPatien = new Main_Screen_Patient();
                                Main_Screen_Patient.txtID.Text = CreateRecord.SelectData(querySelectID, "")[0, 0];
                                Main_Screen_Patient.txtName.Text = CreateRecord.DecryptStringFromBytes_Aes(Convert.FromBase64String(CreateRecord.SelectData(querySelectName, "")[0, 0]), Key, IV);
                                //Main_Screen_Patient.txtSex.Text = CreateRecord.DecryptStringFromBytes_Aes(Convert.FromBase64String(CreateRecord.SelectData(querySelectSex, "")[0, 0]), Key, IV);
                                //Main_Screen_Patient.txtBirth.Text = CreateRecord.DecryptStringFromBytes_Aes(Convert.FromBase64String(CreateRecord.SelectData(querySelectBirth, "")[0, 0]), Key, IV);
                                Main_Screen_Patient.txtAddress.Text = CreateRecord.DecryptStringFromBytes_Aes(Convert.FromBase64String(CreateRecord.SelectData(querySelectAddress, "")[0, 0]), Key, IV);

                                this.Hide();
                                formPatien.ShowDialog();
                                this.Show();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Bạn nhập sai hoặc tài khoản không tồn tại !!!", "Thông báo !!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng xác nhận bạn là con người !!!", "Thông báo !!!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            };
        }
        private void cbHienThiPass_CheckedChanged(object sender, EventArgs e)
        {
            if (cbHienThiPass.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }
    }
}
