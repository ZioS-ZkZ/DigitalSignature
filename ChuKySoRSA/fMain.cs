using System;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;
using Waher.Security.EllipticCurves;
using Waher.Security.SHA3;
namespace ChuKySoRSA
{
    public partial class fMain : Form
    {
        public fMain()
        {
            InitializeComponent();
        }
   
        //event mở file muốn ký và chọn thư mục
        private void btChonFileKy_Click(object sender, EventArgs e)
        {
            OpenFileDialog openLinkGui = new OpenFileDialog();
            if (openLinkGui.ShowDialog() == DialogResult.OK)
                textDuongDanGui.Text = openLinkGui.FileName;
            btTaoChuKy.Enabled = true; //chọn xong rồi thì hiện nút Tạo chư ký lên 
        }
        //tương tự nhưng là với file muốn kiểm tra
        private void btChonFileKiemTra_Click(object sender, EventArgs e)
        {
            OpenFileDialog openLinkNhan = new OpenFileDialog();
            if (openLinkNhan.ShowDialog() == DialogResult.OK)
                textDuongDanNhan.Text = openLinkNhan.FileName;
            btKiemTra.Enabled = true;// hiện nút kiểm tra
        }
        //event tạo chữ ký
        Aes myAes;
        byte[] encrypted;
        private void btTaoChuKy_Click(object sender, EventArgs e)
        {
            // kiểm tra tồn tại path không
            if (!File.Exists(textDuongDanGui.Text))
            {
                MessageBox.Show("Bạn chưa chọn file thực hiện ký!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (File.Exists(textDuongDanGui.Text))
            {
                //mở file ra
                
                StreamReader fileReader = new StreamReader($"{textDuongDanGui.Text}");
                string text = fileReader.ReadToEnd();
                fileReader.Close();
                fileReader.Dispose();
                FileStream fsFileDauVao = new FileStream(textDuongDanGui.Text, FileMode.Open);
                myAes = Aes.Create();
                encrypted = EncryptStringToBytes_Aes(text, myAes.Key, myAes.IV);
                SHAKE256 myShake256 = new SHAKE256(256);
                byte[] byteMaHoa = myShake256.ComputeVariable(fsFileDauVao);
                string FileVBKy = Convert.ToBase64String(byteMaHoa);
                
                Edwards448 myEd448 = new Edwards448();
                byte[] sign = myEd448.Sign(byteMaHoa);
                textHienThiPublicKey.Text = Convert.ToBase64String(myEd448.PublicKey);
                string tepKyGui = Convert.ToBase64String(sign);
                textTepKyGui.Text = tepKyGui;
                fsFileDauVao.Close();
                fsFileDauVao.Dispose();
                MessageBox.Show("Thực hiện ký thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btTaoChuKy.Enabled = false;// ẩn nút Tạo chữ ký 
            }
        }

        private void btKiemTra_Click(object sender, EventArgs e)
        {
            if (!File.Exists(textDuongDanNhan.Text))
            {
                MessageBox.Show("Bạn chưa chọn Tài liệu kiểm tra chữ ký", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (File.Exists(textDuongDanNhan.Text))
            {
                FileStream fsFileDauVao = new FileStream(textDuongDanNhan.Text, FileMode.Open);
                SHAKE256 myShake256 = new SHAKE256(256);
                byte[] byteGiaiMa = myShake256.ComputeVariable(fsFileDauVao);
                string roundtrip = DecryptStringFromBytes_Aes(encrypted, myAes.Key, myAes.IV);
                
                Edwards448 giaiMa = new Edwards448();
                var result = giaiMa.Verify(byteGiaiMa, Convert.FromBase64String(textHienThiPublicKey.Text), Convert.FromBase64String(textTepKyGui.Text));

                if (result)
                {
                   MessageBox.Show("Tài liệu gửi đến không bị chỉnh sửa gì", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   btKiemTra.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Tài liệu gửi đến đã bị thay đổi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btKiemTra.Enabled = false;
                }
                fsFileDauVao.Close();
                fsFileDauVao.Dispose();
                
            }
        }
        private void fMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát khỏi ứng dụng ???", "THÔNG BÁO", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
                e.Cancel = true;
        }
        static byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV)
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

        static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }

            return plaintext;
        }
        
    }
}
