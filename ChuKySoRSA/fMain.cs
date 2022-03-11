using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;

namespace ChuKySoRSA
{
    public partial class fMain : Form
    {
        public fMain()
        {
            InitializeComponent();
            //ẩn hai nút chọn đường dẫn (chờ set key rồi hiện sau ) 
            btChonFileKiemTra.Enabled = btChonFileKy.Enabled = false;
        }
        int soP, soQ, soN, soE, soD, soPhi_n = 0; //khai báo p,q,n,e,d,phi(n)

        private bool isSNTCungNhau(int a, int b) // kiem tra 2 so nguyen to cung nhau 
        {
            if(a>0 && b > 0)
            {
                while (a != b)
                {
                    if (a > b)
                        a -= b;
                    else
                        b -= a;
                }
            }
            //UCLN = 1 thì là snt cùng nhau 
            if (a == 1) return true;
            else return false;
        }
        // "Hàm lấy mod" lát áp dụng cho mã hóa
        public int RSA_mod(int m, int e, int n)
        {

            //Sử dụng thuật toán "bình phương và nhân"
            //Chuyển e sang hệ nhị phân
            int[] a = new int[100];
            int k = 0;
            do
            {
                a[k] = e % 2;
                k++;
                e = e / 2;
            }
            while (e != 0);
            //Quá trình lấy dư
            int kq = 1;
            for (int i = k - 1; i >= 0; i--)
            {
                kq = (kq * kq) % n;
                if (a[i] == 1)
                    kq = (kq * m) % n;
            }
            return kq;
        }
        private void reset()
        {
            //chuyển các ô về trạng thái trống 
            SNTp.Text = SNTq.Text = Phi_n.Text = SoModule_n.Text = SoMu_e.Text = So_d.Text = string.Empty;
        }
        

        // code tạo khóa 
        private void taoKhoa()
        {
            // n =p*q
            soN = soQ * soP;
            // phi(n) = (p-1)*(q-1)
            soPhi_n = (soP - 1) * (soQ - 1);
            //Tính e là một số ngẫu nhiên có giá trị 0< e <phi(n) và là số nguyên tố cùng nhau với Phi(n)
            do
            {
                Random RSA_rd = new Random();
                soE = RSA_rd.Next(2, soPhi_n -1);
            }
            while (!isSNTCungNhau(soE, soPhi_n));
            // (d*e) mod phi(n) = 1
            //Tính d là nghịch đảo modulo của e
            int i = 1;
            bool flag = true;
            while (flag)
            {
                if (((soE * i) % soPhi_n == 1) && (i != soE))
                {
                    soD = i;
                    flag = false;
                }
                i++;
            }

        }

        

        // hàm mã hóa RSA
        public string maHoaRSA(string sInput)
        {
            //bước chuyển đổi văn bản rõ để tránh một số lỗi

            // chuyển thành byte 
            byte[] temp1 = Encoding.Unicode.GetBytes(sInput);
            //chuyển thành base64 
            string _base64 = Convert.ToBase64String(temp1);
            // Chuyen xau thanh ma Unicode (dạng số)
            int[] temp2 = new int[_base64.Length];
            for (int i = 0; i < _base64.Length; i++)
            {
                temp2[i] = (int)_base64[i];
            }
            //thực hiện mã hóa
            int[] temp3 = new int[temp2.Length];
            for (int i = 0; i < temp2.Length; i++)
            {
                temp3[i] = RSA_mod(temp2[i], soD, soN); // bước mã hóa ra c khi có m,e,n
            }
            //Chuyển sang kiểu kí tự trong bảng mã Unicode (dạng chữ )
            string mh_str = "";
            for (int i = 0; i < temp3.Length; i++)
            {
                mh_str = mh_str + (char)temp3[i];
            }
            //mã hóa thêm 1 lần nữa cho chắc
            byte[] mh_data = Encoding.Unicode.GetBytes(mh_str);
            string ChuoiVBkemChuky = string.Empty;
            ChuoiVBkemChuky = Convert.ToBase64String(mh_data);
            return ChuoiVBkemChuky;
        }

        

        //hàm giải mã 
        public string giaiMaRSA(string sInput)
        {
            //mã hóa ngược lại để trả về unicode (dạng chữ)
            byte[] temp1 = Convert.FromBase64String(sInput);
            string giaima = Encoding.Unicode.GetString(temp1);
            //chuyển về unicode (dạng số)
            int[] temp2 = new int[giaima.Length];
            for (int i = 0; i < giaima.Length; i++)
            {
                temp2[i] = (int)giaima[i];
            }
            //thực hiện Giải mã
            int[] temp3 = new int[temp2.Length];
            for (int i = 0; i < temp3.Length; i++)
            {
                temp3[i] = RSA_mod(temp2[i], soE, soN);// bước giải mã ra m khi có c, d, n 
            }
            //chuyển về unicode (dạng chữ tức là base64 ở bước mã hóa)
            string gm_str = "";
            for (int i = 0; i < temp3.Length; i++)
            {
                gm_str = gm_str + (char)temp3[i];
            }
            //chuyển về byte
            byte[] gm_data = Convert.FromBase64String(gm_str);
            //chuyển về chuỗi input ở bước mã hóa
            string GM_ChuoiVBkemChuky = string.Empty;
            GM_ChuoiVBkemChuky = Encoding.Unicode.GetString(gm_data);
            return GM_ChuoiVBkemChuky;
        }
        //hàm chọn ngẫu nhiên 
        private int RSA_ChonSoNgauNhien()
        {
            Random rd = new Random();
            return rd.Next(11, 101);// tốc độ chậm nên chọn số bé khỏi bị đơ máy
        }
        //hàm kiểm tra số nguyên tố
        private bool ktSNT(int a)
        {
            if (a < 2) return false;
            for(int i = 2; i <= Math.Sqrt(a); i++)
            {
                if (a % i == 0) return false;
            }
            return true;
        }

        
        //event khi nhấn vào nút RANDOM KEY 
        private void btRandomKey_Click(object sender, EventArgs e)
        {
            //hiện nút chọn path cho file (nút 3 chấm)
            btChonFileKiemTra.Enabled = btChonFileKy.Enabled = true;
            reset();
            // chọn SNT P Q ngẫu nhiên không trùng
            soQ = soP = 0;
            do
            {
                soP = RSA_ChonSoNgauNhien();
                soQ = RSA_ChonSoNgauNhien();
            }
            while (soP == soQ || !ktSNT(soP) || !ktSNT(soQ));
            // chọn xong rồi thì hiển thị ra cho ngta thấy
            SNTp.Text = soP.ToString();
            SNTq.Text = soQ.ToString();
            taoKhoa();
            //taokhoa tạo ra phi(n), n,e,d thì phải hiển thị ra
            Phi_n.Text = soPhi_n.ToString();
            SoModule_n.Text = soN.ToString();
            SoMu_e.Text = soE.ToString();
            So_d.Text = soD.ToString();
            btRandomKey.Enabled = false; // ẩn nút RandomKey đi
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
                FileStream fsFileDauVao = new FileStream(textDuongDanGui.Text, FileMode.Open);
                //Dùng hàm băm SHA512
                SHA512 mySHA512 = SHA512Managed.Create();
                byte[] FileVBKy_temp1 = mySHA512.ComputeHash(fsFileDauVao);
                string FileVBKy = Convert.ToBase64String(FileVBKy_temp1);
                textHienThiHashGui.Text = FileVBKy.ToString(); // hiện ra màn hình
                string VBKemChuKy = maHoaRSA(FileVBKy); // mã hóa file
                textTepKyGui.Text = VBKemChuKy; // hiện ra màn hình
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
                SHA512 mySHA512 = SHA512Managed.Create();
                byte[] FileVBKy_temp2 = mySHA512.ComputeHash(fsFileDauVao);
                string ChuoiVBdiKem_ShA = Convert.ToBase64String(FileVBKy_temp2);
                textHienThiHashNhan.Text = ChuoiVBdiKem_ShA.ToString();
                string VBKemChuKyGM = giaiMaRSA(textTepKyGui.Text); // thực hiện giải mã chữ ký
                textGiaiMaChuKy.Text = VBKemChuKyGM.ToString();
                // kiểm tra xem file giải mã bằng public key có trùng với văn bản đi kèm không
                int result = 0;
                if (VBKemChuKyGM == ChuoiVBdiKem_ShA)
                    result = 1;
                else
                    result = 0;
                if (result == 1)
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

        private void btTaoMoiKey_Click(object sender, EventArgs e)
        {
            textDuongDanGui.Text = textDuongDanNhan.Text = textGiaiMaChuKy.Text = textTepKyGui.Text = textHienThiHashGui.Text = textHienThiHashNhan.Text = string.Empty;
            reset();
            btRandomKey.Enabled = true;
        }

        private void fMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát khỏi ứng dụng ???", "THÔNG BÁO", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
                e.Cancel = true;
        }


    }
}
