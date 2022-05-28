using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChuKySo
{
    internal class Certificate
    {
		public string Issuer;
		public string Doctor;
		public string Doctor_ID;
		string Subject;
		string Version;
		string ValidFrom;
		string ValidUntil;
		string SerialNumber;
		string Algorithm;
		string Thumbprint;
		string PublicKey;
		public Certificate() { }
		public Certificate(X509Certificate2 certificate, string Doctor, string Doctor_ID, byte[] publickey)
		{
			Issuer = certificate.Issuer;
			this.Doctor = Doctor;
			this.Doctor_ID = Doctor_ID;
			Version = certificate.Version.ToString();
			PublicKey = ByteArrayToString(publickey);
		}
		public string PrintCertificateIdentity(X509Certificate2 certificate)
		{
			string CerIdentity = "";
			CerIdentity += "Issuer: " + certificate.IssuerName.Name + "\n";
			CerIdentity += "Issuer's public key: " + ByteArrayToString(certificate.GetPublicKey()) + "\n";
			CerIdentity += "Subject: " + Doctor + " - " + Doctor_ID + "\n";
			CerIdentity += "Subject's public key: " + PublicKey + "\n";
			CerIdentity += "Version: " + certificate.Version + "\n";
			CerIdentity += "Valid from: " + DateTimeOffset.Now + "\n";
			CerIdentity += "Valid until: " + DateTimeOffset.Now.AddYears(5) + "\n";
			Random random = new Random();
			byte[] data = new byte[20];
			random.NextBytes(data);
			CerIdentity += "Serial number: " + ByteArrayToString(data) + "\n";
			return CerIdentity;
		}
		public string PrintCertificateInfo(X509Certificate2 certificate)
		{
			string CerInfo = PrintCertificateIdentity(certificate);
			byte[] data = Encoding.UTF8.GetBytes(CerInfo);
			CerInfo += "Signature: " + ByteArrayToString(SignWithCert(data)) + "\n";
			CerInfo += "Signature Algorithm: sha512ECDSA\n";
			data = Encoding.UTF8.GetBytes(CerInfo);
			SHA1 sha1 = SHA1.Create();
			data = sha1.ComputeHash(data);
			CerInfo += "Thumbprint: " + ByteArrayToString(data) + "\n";
			return CerInfo;
		}
		public static X509Certificate2 GetCertFromStore()
		{
			//to access to store we need to specify store name and location    
			X509Store x509Store = new X509Store("Test", StoreLocation.CurrentUser);

			//obtain read only access to get cert    
			x509Store.Open(OpenFlags.ReadOnly);

			return x509Store.Certificates[0];
		}

		public byte[] SignWithCert(byte[] data)
		{
			//X509Certificate2 certificate = new X509Certificate2("d:\\cert\\mycert.cer");
			X509Certificate2 certificate = new X509Certificate2("d:\\cert\\mycert.pfx", "P@55w0rd");

			using (ECDsa ecdsa = certificate.GetECDsaPrivateKey())
			{
				if (ecdsa == null)
					throw new ArgumentException("Cert must have an ECDSA private key", nameof(certificate));

				return ecdsa.SignData(data, HashAlgorithmName.SHA512);
			}
		}

		public static bool VerifyWithCert(byte[] data, byte[] signature)
		{

			X509Certificate2 cert = GetCertFromStore();

			using (ECDsa ecdsa = cert.GetECDsaPublicKey())
			{
				if (ecdsa == null)
					MessageBox.Show("Cert must be an ECDSA cert");

				return ecdsa.VerifyData(data, signature, HashAlgorithmName.SHA512);
			}
		}
		
		public static string ByteArrayToString(byte[] ba)
		{
			StringBuilder hex = new StringBuilder(ba.Length * 2);
			foreach (byte b in ba)
				hex.AppendFormat("{0:x2}", b);
			return hex.ToString();
		}
		public static byte[] StringToByteArray(string hex)
		{
			return Enumerable.Range(0, hex.Length)
							 .Where(x => x % 2 == 0)
							 .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
							 .ToArray();
		}

	}
}
