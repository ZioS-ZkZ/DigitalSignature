using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChuKySo
{
    public partial class MakeCert : Form
    {
        public MakeCert()
        {
            InitializeComponent();
        }
        //Tạo store
        public static bool CreateStore(string name, StoreLocation location)
        {
            bool success = false;
            X509Store store = new X509Store(name, location);
            try
            {
                store.Open(OpenFlags.ReadWrite);
                success = true;
                store.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return success;
        }

        //Đưa xertificate đến nơi mong muốn
        public static bool ImportCertificate(X509Certificate2 certificate, string name, StoreLocation location)
        {
            bool success = false;

            X509Store store = new X509Store(name, location);
            try
            {
                store.Open(OpenFlags.ReadWrite);
                store.Add(certificate);
                success = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                store.Close();
            }

            return success;
        }

        public static bool ImportCertificate(string path, string name, StoreLocation location)
        {
            bool success = false;

            try
            {
                X509Certificate2 certificate = new X509Certificate2(path);
                success = ImportCertificate(certificate, name, location);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return success;
        }
        //Tạo self-certificate
        public static void MakeSeftSignedCert()
        {
            var ecdsa = ECDsa.Create(); // generate asymmetric key pair
            var req = new CertificateRequest("cn=HospitalA", ecdsa, HashAlgorithmName.SHA512);
            var cert = req.CreateSelfSigned(DateTimeOffset.Now, DateTimeOffset.Now.AddYears(5));

            // Create PFX (PKCS #12) with private key
            File.WriteAllBytes("d:\\cert\\mycert.pfx", cert.Export(X509ContentType.Pfx, "P@55w0rd"));

            // Create Base 64 encoded CER (public key only)
            File.WriteAllText("d:\\cert\\mycert.cer",
                "-----BEGIN CERTIFICATE-----\r\n"
                + Convert.ToBase64String(cert.Export(X509ContentType.Cert), Base64FormattingOptions.InsertLineBreaks)
                + "\r\n-----END CERTIFICATE-----");
        }
        private void MakeStore_Click(object sender, EventArgs e)
        {
            
            bool result = CreateStore("Test", StoreLocation.CurrentUser);
            if (result)
                MessageBox.Show("Tạo Store thành công");
            else
                MessageBox.Show("Tạo Store không thành công");

           
        }

        private void MakeSelfSignedCert_Click(object sender, EventArgs e)
        {
            try
            {
                MakeSeftSignedCert();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ImportCert_Click(object sender, EventArgs e)
        {
            
            bool result = ImportCertificate("d:\\cert\\mycert.cer", "Test", StoreLocation.CurrentUser);
            if (result)
                MessageBox.Show("Import certificate thành công");
            else
                MessageBox.Show("Import certificate không thành công");
        }
    }
}
