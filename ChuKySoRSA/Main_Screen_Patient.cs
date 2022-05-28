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
	public partial class Main_Screen_Patient : Form
	{
		public static string PatientID = "";

		public Main_Screen_Patient()
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
		}

		public static void ShowListRecord()
		{
			mainPanel.Controls.Clear();
			listRecord.Text = "Danh sách hồ sơ";

			///Query danh sách hồ sơ có thể truy cập
			string query = "SELECT * FROM access_control WHERE id_account='" + PatientID + "'";
			string[,] result = CreateRecord.SelectData(query, "Không tìm thấy hồ sơ!");

			int widthView = 784, widthUdDl = 152, height = 48, margin = 5;
			Button oldBtnView = new() { Width = 0, Height = 0, Location = new Point(3, -28) };
			Button oldBtnDelete = new() { Width = 0, Height = 0, Location = new Point(792, -28) };


			if (result != null)
				for (int i = 0; i < result.GetLength(0); i++)
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

			//Xác nhận certificate
			byte[] CertInfo = Convert.FromBase64String(data[2]);
			string s_CertInfo = Encoding.UTF8.GetString(CertInfo);

			string[] CertData = s_CertInfo.Split('\n');
			string[] CertSignature = CertData[8].Split(' ');
			string[] SubjectPublicKey = CertData[3].Split(' ');
			string CertIndentity = "";
			for (int i = 0; i <= 7; i++)
			{
				CertIndentity += CertData[i];
				CertIndentity += '\n';
			}

			MessageBox.Show(s_CertInfo, "Thông tin certificate");
			//Xác thực certificate
			bool result1 = Certificate.VerifyWithCert(Encoding.UTF8.GetBytes(CertIndentity), Certificate.StringToByteArray((CertSignature[1])));

			if (result1)
			{
				MessageBox.Show("Public key đã được xác thực!");
				
				//Verify sign
				Edwards448 giaiMa = new Edwards448();
				var result = giaiMa.Verify(byteData, Certificate.StringToByteArray(SubjectPublicKey[3]), Convert.FromBase64String(data[1]));

				if (result)
				{
					MessageBox.Show("Hồ sơ đã được xác thực!");

					//Decrypt AES
					CreateRecord.DecryptStringFromBytes_Aes(byteData, keyaes, iv).Split('|').CopyTo(originalData, 0);

					//Show detail form
					ShowFormCreateRecord("Chi tiết hồ sơ");
					CreateRecord.btnCancel.Text = "Back";
					CreateRecord.btnSubmit.Visible = false;

					CreateRecord.checkAllergies.Enabled = CreateRecord.txtBloodGrp.Enabled = CreateRecord.checkDiabetes.Enabled = CreateRecord.checkListGender.Enabled = CreateRecord.txtBMI.Enabled = CreateRecord.txtHeight.Enabled = CreateRecord.txtIDPatient.Enabled = CreateRecord.txtNamePatient.Enabled = CreateRecord.txtTuoi.Enabled = CreateRecord.txtWeight.Enabled = false;
					CreateRecord.txtNameDoctor.Text = originalData[0];
					CreateRecord.txtIDDoctor.Text = originalData[1];
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
				else
				{
					MessageBox.Show("Hồ sơ đã bị chỉnh sửa!");
					return;
				}
			}
			else
			{
				MessageBox.Show("Publickey có khả năng đã bị chỉnh sửa!");
			}
		}

		private static void BtnDelete_Click(object sender, EventArgs e, string id)
		{
			//Delete access control
			string query = "DELETE FROM access_control WHERE id_record='" + id + "' AND id_account='" + PatientID + "'";
			CreateRecord.ImplementQuery(query, "Xoá thành công!");
			ShowListRecord();

			//Delete data if no one else have access rights
			query = "SELECT * FROM access_control WHERE id_record='" + id + "'";
			string[,] result = CreateRecord.SelectData(query, "");
			if (result[0, 0] == null)
			{
				query = "DELETE FROM data_record WHERE id_record='" + id + "'";
				CreateRecord.ImplementQuery(query, "");
			}
		}

		
	}
}
