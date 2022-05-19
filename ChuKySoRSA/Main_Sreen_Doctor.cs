using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using Waher.Security.EllipticCurves;
using System.IO;


namespace ChuKySo
{
	public partial class Main_Sreen_Doctor : Form
	{
		public static string DoctorName = "";
		public static string DoctorID = "";

		public Main_Sreen_Doctor()
		{
			InitializeComponent();
			ShowListRecord();
		}

		private static void ShowFormCreateRecord(string text)
		{
			CreateRecord.res = new();
			CreateRecord.res.TopLevel = false;
			CreateRecord.res.FormBorderStyle = FormBorderStyle.None;
			CreateRecord.res.Dock = DockStyle.None;
			mainPanel.Controls.Add(CreateRecord.res);
			CreateRecord.res.Tag = CreateRecord.res;
			CreateRecord.res.BringToFront();
			CreateRecord.res.Show();
			listRecord.Text = text;
			btnCreateRecord.Enabled = false;
		}

		private void createRecord_Click(object sender, EventArgs e)
		{
			ShowFormCreateRecord("Tạo Hồ sơ");
		}

		public static void ShowListRecord()
		{
			mainPanel.Controls.Clear();
			btnCreateRecord.Enabled = true;
			listRecord.Text = "Danh sách hồ sơ";

			//Query danh sách hồ sơ có thể truy cập
			string query = "SELECT * FROM access_control WHERE id_account='" + DoctorID + "'";
			string[,] result = CreateRecord.SelectData(query, "Không tìm thấy hồ sơ!");

			int widthView = 632, widthUdDl = 152, height = 48, margin = 5;
			Button oldBtnView = new() { Width = 0, Height = 0, Location = new Point(3, -28) };
			Button oldBtnUpdate = new() { Width = 0, Height = 0, Location = new Point(640, -28) };
			Button oldBtnDelete = new() { Width = 0, Height = 0, Location = new Point(797, -28) };


			if (result != null)
				for(int i=0; i< result.GetLength(0); i++)
				{
					if (result[i, 0] == null)
						break;
					byte[] keyaes = Convert.FromBase64String(result[i, 2]);
					byte[] iv = Convert.FromBase64String(result[i, 3]);
					string id_record = result[i, 1];

					Button btnView = new() { Width = widthView, Height = height };
					btnView.Location = new Point(oldBtnView.Location.X, oldBtnView.Location.Y + height + margin);
					btnView.Text = $"ID: {result[i, 1]}";
					btnView.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
					btnView.Click += (sender1, e1) => BtnView_Click(sender1, e1, id_record, keyaes, iv);
					mainPanel.Controls.Add(btnView);
					oldBtnView = btnView;

					Button btnUpdate = new() { Width = widthUdDl, Height = height };
					btnUpdate.Location = new Point(oldBtnUpdate.Location.X, oldBtnUpdate.Location.Y + height + margin);
					btnUpdate.Text = $"Sửa";
					btnUpdate.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
					btnUpdate.Click += (sender1, e1) => BtnUpdate_Click(sender1, e1, id_record, keyaes, iv);
					mainPanel.Controls.Add(btnUpdate);
					oldBtnUpdate = btnUpdate;

					Button btnDelete = new() { Width = widthUdDl, Height = height };
					btnDelete.Location = new Point(oldBtnDelete.Location.X, oldBtnDelete.Location.Y + height + margin);
					btnDelete.Text = $"Xoá";
					btnDelete.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
					btnDelete.Click += (sender1, e1) => BtnDelete_Click(sender1, e1, id_record);
					mainPanel.Controls.Add(btnDelete);
					oldBtnDelete = btnDelete;
				}
		}

		private static void BtnView_Click(object sender, EventArgs e, string id, byte[] keyaes, byte[] iv)
		{
			string[] originalData = new string[12];

			//Query 
			string query = "SELECT data FROM data_record WHERE id_record='" + id + "'";
			string[,] resultQuery = CreateRecord.SelectData(query, "");

			//Get data, sign, pbkey
			string[] data = resultQuery[0, 0].Split('|');
			byte[] byteData = Convert.FromBase64String(data[0]);

			//Verify sign
			Edwards448 giaiMa = new Edwards448();
			var result = giaiMa.Verify(byteData, Convert.FromBase64String(data[2]), Convert.FromBase64String(data[1]));

			if (result)
			{
				MessageBox.Show("Hồ sơ đã được xác thực!");

				//Decrypt AES
				CreateRecord.DecryptStringFromBytes_Aes(byteData, keyaes, iv).Split('|').CopyTo(originalData, 0);
			}
			else
			{
				MessageBox.Show("Hồ sơ đã bị chỉnh sửa!");
				return;
			}

			//Show detail form
			ShowFormCreateRecord("Chi tiết hồ sơ");
			CreateRecord.btnCancel.Text = "Back";
			CreateRecord.btnSubmit.Visible = false;

			CreateRecord.checkAllergies.Enabled = CreateRecord.txtBloodGrp.Enabled = CreateRecord.checkDiabetes.Enabled = CreateRecord.checkListGender.Enabled = CreateRecord.txtBMI.Enabled = CreateRecord.txtHeight.Enabled = CreateRecord.txtIDPatient.Enabled = CreateRecord.txtNamePatient.Enabled = CreateRecord.txtTuoi.Enabled = CreateRecord.txtWeight.Enabled = false;
			CreateRecord.txtIDPatient.Text = originalData[2];
			CreateRecord.txtNamePatient.Text = originalData[3];
			if (originalData[4] != "")
				CreateRecord.checkListGender.SetItemChecked(CreateRecord.checkListGender.Items.IndexOf(originalData[4]), true);
			CreateRecord.txtTuoi.Text = originalData[5];
			CreateRecord.txtWeight.Text = originalData[6];
			CreateRecord.txtHeight.Text = originalData[7];
			CreateRecord.txtBMI.Text = originalData[8];
			CreateRecord.txtBloodGrp.Text = originalData[9];
			if (originalData[10] != "")
				CreateRecord.checkDiabetes.Checked = true;
			if (originalData[11] != "")
				CreateRecord.checkAllergies.Checked = true;
		}

		private static void BtnUpdate_Click(object sender, EventArgs e, string id, byte[] keyaes, byte[] iv)
		{
			BtnView_Click(sender, e, id, keyaes, iv);

			if (Application.OpenForms.OfType<CreateRecord>().Any())
			{
				listRecord.Text = "Chỉnh sửa hồ sơ";

				CreateRecord.checkAllergies.Enabled = CreateRecord.txtBloodGrp.Enabled = CreateRecord.checkDiabetes.Enabled = CreateRecord.checkListGender.Enabled = CreateRecord.txtHeight.Enabled = CreateRecord.txtIDPatient.Enabled = CreateRecord.txtNamePatient.Enabled = CreateRecord.txtTuoi.Enabled = CreateRecord.txtWeight.Enabled = true;

				Button btn = new();
				btn.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
				btn.Left = 8;
				btn.Top = 471;
				btn.Width = 124;
				btn.Height = 47;
				btn.Text = "Ok";
				btn.UseVisualStyleBackColor = true;
				btn.Click += (sender1, e1) => Btn_Click(sender1, e1, id);
				CreateRecord.res.Controls.Add(btn);
			}
		}

		private static void Btn_Click(object sender, EventArgs e, string id)
		{
			//Xử lý input
			string diabetes = "", allergies = "", gender = "";
			if (CreateRecord.checkDiabetes.Checked)
				diabetes = CreateRecord.checkDiabetes.Text;
			if (CreateRecord.checkAllergies.Checked)
				allergies = CreateRecord.checkAllergies.Text;
			if (CreateRecord.checkListGender.CheckedItems.Count > 0)
				gender = CreateRecord.checkListGender.CheckedItems[0].ToString();
			string input = $"{CreateRecord.txtNameDoctor.Text}|{CreateRecord.txtIDDoctor.Text}|{CreateRecord.txtIDPatient.Text}|{CreateRecord.txtNamePatient.Text}|{gender}|{CreateRecord.txtTuoi.Text}|{CreateRecord.txtWeight.Text}|{CreateRecord.txtHeight.Text}|{CreateRecord.txtBMI.Text}|{CreateRecord.txtBloodGrp.Text}|{diabetes}|{allergies}";

			//Mã hoá AES 
			Aes myAes = Aes.Create();
			myAes.KeySize = 256;
			myAes.BlockSize = 128;
			myAes.Mode = CipherMode.CBC;
			myAes.Padding = PaddingMode.PKCS7;
			myAes.GenerateIV();
			myAes.GenerateKey();
			byte[] encrypted = CreateRecord.EncryptStringToBytes_Aes(input, myAes.Key, myAes.IV);

			//Tạo chữ ký
			Edwards448 myEd448 = new Edwards448();
			byte[] sign = myEd448.Sign(encrypted);

			//Output
			string output = $"{Convert.ToBase64String(encrypted)}|{Convert.ToBase64String(sign)}|{Convert.ToBase64String(myEd448.PublicKey)}";

			//Update to database
			string query = "UPDATE data_record SET data='" + output + "' WHERE id_record='" + id +"'";
			CreateRecord.ImplementQuery(query, "Cập nhật thành công!");

			//Access Control
				//Update keyAES
			query = "UPDATE access_control SET keyAES='" + Convert.ToBase64String(myAes.Key) + "' WHERE id_record='" + id + "'";
			CreateRecord.ImplementQuery(query, "");
				//Update IV
			query = "UPDATE access_control SET IV='" + Convert.ToBase64String(myAes.IV) + "' WHERE id_record='" + id + "'";
			CreateRecord.ImplementQuery(query, "");

			//Xử lý giao diện
			CreateRecord.res.Close();
			ShowListRecord();
		}

		private static void BtnDelete_Click(object sender, EventArgs e, string id)
		{
			//Delete access control
			string query = "DELETE FROM access_control WHERE id_record='" + id + "' AND id_account='" + DoctorID + "'";
			CreateRecord.ImplementQuery(query, "Xoá thành công!");
			ShowListRecord();

			//Delete data if no one else have access rights
			query = "SELECT * FROM access_control WHERE id_record='" + id + "'";
			string[,] result = CreateRecord.SelectData(query, "");
			if(result[0, 0] == null)
			{
				query = "DELETE FROM data_record WHERE id_record='" + id + "'";
				CreateRecord.ImplementQuery(query, "");
			}
		}

		
	}
}
