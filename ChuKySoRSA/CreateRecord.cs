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
	public partial class CreateRecord : Form
	{
#pragma warning disable CA2211 // Non-constant fields should not be visible
		public static CreateRecord res;
#pragma warning restore CA2211 // Non-constant fields should not be visible

		public CreateRecord()
		{
			InitializeComponent();
			txtNameDoctor.Text = Main_Sreen_Doctor.DoctorName;
			txtIDDoctor.Text = Main_Sreen_Doctor.DoctorID;
		}

		private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			for (int ix = 0; ix < checkListGender.Items.Count; ++ix)
				if (ix != e.Index) checkListGender.SetItemChecked(ix, false);
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			res.Close();
			if (Main_Sreen_Doctor.DoctorID != "" && Main_Screen_Patient.PatientID == "")
				Main_Sreen_Doctor.ShowListRecord();
			else if (Main_Sreen_Doctor.DoctorID == "" && Main_Screen_Patient.PatientID != "")
				Main_Screen_Patient.ShowListRecord();
		}

		private void btnSubmit_Click(object sender, EventArgs e)
		{
			//Xử lý input
			string diabetes = "", allergies = "", gender = "";
			if(checkDiabetes.Checked)
				diabetes = checkDiabetes.Text;
			if(checkAllergies.Checked)
				allergies = checkAllergies.Text;
			if (checkListGender.CheckedItems.Count > 0)
				gender = checkListGender.CheckedItems[0].ToString();
			string input = $"{txtNameDoctor.Text}|{txtIDDoctor.Text}|{txtIDPatient.Text}|{txtNamePatient.Text}|{gender}|{txtTuoi.Text}|{txtWeight.Text}|{txtHeight.Text}|{txtBMI.Text}|{txtBloodGrp.Text}|{diabetes}|{allergies}";

			//Mã hoá AES 
			Aes myAes = Aes.Create();
			myAes.KeySize = 256;
			myAes.BlockSize = 128;
			myAes.Mode = CipherMode.CBC;
			myAes.Padding = PaddingMode.PKCS7;
			myAes.GenerateIV();
			myAes.GenerateKey();
			byte[] encrypted = EncryptStringToBytes_Aes(input, myAes.Key, myAes.IV);

			//Tạo chữ ký
			Edwards448 myEd448 = new Edwards448();
			byte[] sign = myEd448.Sign(encrypted);

			//Output
			string output = $"{Convert.ToBase64String(encrypted)}|{Convert.ToBase64String(sign)}|{Convert.ToBase64String(myEd448.PublicKey)}";

			//Insert to database
			string query = "INSERT INTO data_record (`data`) VALUES ('" + output + "')";
			ImplementQuery(query, "Tạo hồ sơ thành công");

			//Acces Control
			query = "SELECT id_record FROM data_record ORDER BY id_record DESC LIMIT 1";
			int currentIdRecord = Convert.ToInt16(SelectData(query, "Không tìm thấy rows!")[0,0]);
			string stringKeyaes = Convert.ToBase64String(myAes.Key);
			string stringIVaes = Convert.ToBase64String(myAes.IV);

			if(currentIdRecord != 0)
			{
				//For Doctor
				query = "INSERT INTO access_control (id_account, id_record, keyAES, IV) VALUES ('" + txtIDDoctor.Text + "', '" + currentIdRecord + "', '" + stringKeyaes + "', '" + stringIVaes + "')";
				ImplementQuery(query, "");
				//For Patient
				query = "INSERT INTO access_control (id_account, id_record, keyAES, IV) VALUES ('" + txtIDPatient.Text + "', '" + currentIdRecord + "', '" + stringKeyaes + "', '" + stringIVaes + "')";
				ImplementQuery(query, "");
			}

			//Xử lý giao diện
			res.Close();
			Main_Sreen_Doctor.ShowListRecord();

		}

		//Calculate BMI
		private void txtWeight_TextChanged(object sender, EventArgs e)
		{
			if(txtHeight.Text != "" && txtWeight.Text != "")
			{
				int weight = Convert.ToInt16(txtWeight.Text);
				double height = Convert.ToDouble(txtHeight.Text) / 100;
				if(height != 0)
				{
					double BMI = weight / (height * height);
					txtBMI.Text = Math.Round(BMI, 2).ToString();
				}
			} else {
				txtBMI.Text = "";
			}
		}

		//Calculate BMI
		private void txtHeight_TextChanged(object sender, EventArgs e)
		{
			if (txtHeight.Text != "" && txtWeight.Text != "")
			{
				int weight = Convert.ToInt16(txtWeight.Text);
				double height = Convert.ToDouble(txtHeight.Text) / 100;
				if (height != 0)
				{
					double BMI = weight / (height * height);
					txtBMI.Text = Math.Round(BMI, 2).ToString();
				}
			} else {
				txtBMI.Text = "";
			}
		}

		public static byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV)
		{
			// Check arguments.
			if (plainText == null || plainText.Length <= 0)
				throw new ArgumentNullException("plainText");
			if (Key == null || Key.Length <= 0)
				throw new ArgumentNullException("Key");
			if (IV == null || IV.Length <= 0)
				throw new ArgumentNullException("IV");
			byte[] encrypted;

			// Create an Aes object
			// with the specified key and IV.
			using (Aes aesAlg = Aes.Create())
			{
				aesAlg.KeySize = 256;
				aesAlg.BlockSize = 128;
				aesAlg.Mode = CipherMode.CBC;
				aesAlg.Padding = PaddingMode.PKCS7;
				aesAlg.Key = Key;
				aesAlg.IV = IV;
				// Create an encryptor to perform the stream transform.
				ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

				// Create the streams used for encryption.
				using (MemoryStream msEncrypt = new MemoryStream())
				{
					using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
					{
						using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
						{
							//Write all data to the stream.
							swEncrypt.Write(plainText);
						}
						encrypted = msEncrypt.ToArray();
					}
				}
			}

			// Return the encrypted bytes from the memory stream.
			return encrypted;
		}

		public static void ImplementQuery(string query, string msgSuccess)
		{
			string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=mmh;";
			MySqlConnection databaseConnection = new(connectionString);
			MySqlCommand commandDatabase = new(query, databaseConnection);
			commandDatabase.CommandTimeout = 60;

			try
			{
				databaseConnection.Open();
				MySqlDataReader myReader = commandDatabase.ExecuteReader();

				if(msgSuccess != "")
					MessageBox.Show(msgSuccess);

				databaseConnection.Close();
			}
			catch (Exception ex)
			{
				// Hiển thị lỗi
				MessageBox.Show(ex.Message);
			}
			
		}

		public static string[,] SelectData(string query, string msgFail)
		{
			string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=mmh;";
			MySqlConnection databaseConnection = new(connectionString);
			MySqlCommand commandDatabase = new(query, databaseConnection);
			commandDatabase.CommandTimeout = 60;

			try
			{
				databaseConnection.Open();
				MySqlDataReader reader = commandDatabase.ExecuteReader();
				// Success, now list 
				string[,] result = new string[10, reader.FieldCount];
				int count = 0;
				// If there are available rows
				if (reader.HasRows)
				{
					while (reader.Read())
					{
						for (int i = 0; i < result.GetLength(1); i++)
							result[count, i] = reader.GetString(i);
						count++;
					}
				}
				else
				{
					if(msgFail != "")
						MessageBox.Show(msgFail);
				}

				databaseConnection.Close();
				return result;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return null;
			}
		}
	}
}
