
namespace ChuKySo
{
    partial class fMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BenGui_text = new System.Windows.Forms.TextBox();
            this.BenNhan_text = new System.Windows.Forms.TextBox();
            this.btTaoChuKy = new System.Windows.Forms.Button();
            this.btKiemTra = new System.Windows.Forms.Button();
            this.textDuongDanGui = new System.Windows.Forms.TextBox();
            this.btChonFileKy = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textDuongDanNhan = new System.Windows.Forms.TextBox();
            this.btChonFileKiemTra = new System.Windows.Forms.Button();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textTepKyGui = new System.Windows.Forms.TextBox();
            this.textHienThiPublicKey = new System.Windows.Forms.TextBox();
            this.pB_damMay = new System.Windows.Forms.PictureBox();
            this.pB_arrow = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pB_damMay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pB_arrow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // BenGui_text
            // 
            this.BenGui_text.BackColor = System.Drawing.Color.Turquoise;
            this.BenGui_text.Enabled = false;
            this.BenGui_text.Font = new System.Drawing.Font("Ravie", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BenGui_text.Location = new System.Drawing.Point(37, 48);
            this.BenGui_text.Name = "BenGui_text";
            this.BenGui_text.Size = new System.Drawing.Size(258, 30);
            this.BenGui_text.TabIndex = 16;
            this.BenGui_text.Text = "Bên Gửi";
            this.BenGui_text.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BenNhan_text
            // 
            this.BenNhan_text.BackColor = System.Drawing.Color.Turquoise;
            this.BenNhan_text.Enabled = false;
            this.BenNhan_text.Font = new System.Drawing.Font("Ravie", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BenNhan_text.Location = new System.Drawing.Point(893, 48);
            this.BenNhan_text.Name = "BenNhan_text";
            this.BenNhan_text.Size = new System.Drawing.Size(258, 30);
            this.BenNhan_text.TabIndex = 17;
            this.BenNhan_text.Text = "Bên Nhận";
            this.BenNhan_text.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btTaoChuKy
            // 
            this.btTaoChuKy.BackColor = System.Drawing.Color.DarkOrange;
            this.btTaoChuKy.Enabled = false;
            this.btTaoChuKy.Font = new System.Drawing.Font("Ravie", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btTaoChuKy.Location = new System.Drawing.Point(71, 612);
            this.btTaoChuKy.Name = "btTaoChuKy";
            this.btTaoChuKy.Size = new System.Drawing.Size(201, 40);
            this.btTaoChuKy.TabIndex = 18;
            this.btTaoChuKy.Text = "Tạo chữ ký";
            this.btTaoChuKy.UseVisualStyleBackColor = false;
            this.btTaoChuKy.Click += new System.EventHandler(this.btTaoChuKy_Click);
            // 
            // btKiemTra
            // 
            this.btKiemTra.BackColor = System.Drawing.Color.DarkOrange;
            this.btKiemTra.Enabled = false;
            this.btKiemTra.Font = new System.Drawing.Font("Ravie", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btKiemTra.Location = new System.Drawing.Point(928, 612);
            this.btKiemTra.Name = "btKiemTra";
            this.btKiemTra.Size = new System.Drawing.Size(201, 40);
            this.btKiemTra.TabIndex = 19;
            this.btKiemTra.Text = "Kiểm tra";
            this.btKiemTra.UseVisualStyleBackColor = false;
            this.btKiemTra.Click += new System.EventHandler(this.btKiemTra_Click);
            // 
            // textDuongDanGui
            // 
            this.textDuongDanGui.Location = new System.Drawing.Point(37, 98);
            this.textDuongDanGui.Name = "textDuongDanGui";
            this.textDuongDanGui.Size = new System.Drawing.Size(189, 27);
            this.textDuongDanGui.TabIndex = 20;
            // 
            // btChonFileKy
            // 
            this.btChonFileKy.Location = new System.Drawing.Point(249, 98);
            this.btChonFileKy.Name = "btChonFileKy";
            this.btChonFileKy.Size = new System.Drawing.Size(46, 27);
            this.btChonFileKy.TabIndex = 21;
            this.btChonFileKy.Text = "...";
            this.btChonFileKy.UseVisualStyleBackColor = true;
            this.btChonFileKy.Click += new System.EventHandler(this.btChonFileKy_Click);
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.textBox3.Enabled = false;
            this.textBox3.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBox3.Location = new System.Drawing.Point(37, 164);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(258, 31);
            this.textBox3.TabIndex = 26;
            this.textBox3.Text = "Chữ ký được tạo";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textDuongDanNhan
            // 
            this.textDuongDanNhan.Location = new System.Drawing.Point(893, 98);
            this.textDuongDanNhan.Name = "textDuongDanNhan";
            this.textDuongDanNhan.Size = new System.Drawing.Size(189, 27);
            this.textDuongDanNhan.TabIndex = 27;
            // 
            // btChonFileKiemTra
            // 
            this.btChonFileKiemTra.Location = new System.Drawing.Point(1105, 98);
            this.btChonFileKiemTra.Name = "btChonFileKiemTra";
            this.btChonFileKiemTra.Size = new System.Drawing.Size(46, 27);
            this.btChonFileKiemTra.TabIndex = 28;
            this.btChonFileKiemTra.Text = "...";
            this.btChonFileKiemTra.UseVisualStyleBackColor = true;
            this.btChonFileKiemTra.Click += new System.EventHandler(this.btChonFileKiemTra_Click);
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.textBox5.Enabled = false;
            this.textBox5.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBox5.Location = new System.Drawing.Point(893, 164);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(258, 31);
            this.textBox5.TabIndex = 29;
            this.textBox5.Text = "Khóa Public ";
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textTepKyGui
            // 
            this.textTepKyGui.Location = new System.Drawing.Point(37, 208);
            this.textTepKyGui.Multiline = true;
            this.textTepKyGui.Name = "textTepKyGui";
            this.textTepKyGui.ReadOnly = true;
            this.textTepKyGui.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textTepKyGui.Size = new System.Drawing.Size(258, 363);
            this.textTepKyGui.TabIndex = 33;
            // 
            // textHienThiPublicKey
            // 
            this.textHienThiPublicKey.Location = new System.Drawing.Point(893, 208);
            this.textHienThiPublicKey.Multiline = true;
            this.textHienThiPublicKey.Name = "textHienThiPublicKey";
            this.textHienThiPublicKey.ReadOnly = true;
            this.textHienThiPublicKey.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textHienThiPublicKey.Size = new System.Drawing.Size(258, 141);
            this.textHienThiPublicKey.TabIndex = 34;
            // 
            // pB_damMay
            // 
            this.pB_damMay.BackColor = System.Drawing.Color.Transparent;
            this.pB_damMay.BackgroundImage = global::ChuKySo.Properties.Resources.clound_removebg_preview;
            this.pB_damMay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pB_damMay.Location = new System.Drawing.Point(407, 164);
            this.pB_damMay.Name = "pB_damMay";
            this.pB_damMay.Size = new System.Drawing.Size(385, 301);
            this.pB_damMay.TabIndex = 36;
            this.pB_damMay.TabStop = false;
            // 
            // pB_arrow
            // 
            this.pB_arrow.BackgroundImage = global::ChuKySo.Properties.Resources.muiten_removebg_preview;
            this.pB_arrow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pB_arrow.Location = new System.Drawing.Point(310, 287);
            this.pB_arrow.Name = "pB_arrow";
            this.pB_arrow.Size = new System.Drawing.Size(91, 62);
            this.pB_arrow.TabIndex = 37;
            this.pB_arrow.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::ChuKySo.Properties.Resources.muiten_removebg_preview;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(796, 287);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(91, 62);
            this.pictureBox1.TabIndex = 38;
            this.pictureBox1.TabStop = false;
            // 
            // fMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1173, 753);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pB_arrow);
            this.Controls.Add(this.pB_damMay);
            this.Controls.Add(this.textHienThiPublicKey);
            this.Controls.Add(this.textTepKyGui);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.btChonFileKiemTra);
            this.Controls.Add(this.textDuongDanNhan);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.btChonFileKy);
            this.Controls.Add(this.textDuongDanGui);
            this.Controls.Add(this.btKiemTra);
            this.Controls.Add(this.btTaoChuKy);
            this.Controls.Add(this.BenNhan_text);
            this.Controls.Add(this.BenGui_text);
            this.MaximizeBox = false;
            this.Name = "fMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Digital  Sigture ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fMain_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pB_damMay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pB_arrow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox BenGui_text;
        private System.Windows.Forms.TextBox BenNhan_text;
        private System.Windows.Forms.Button btTaoChuKy;
        private System.Windows.Forms.Button btKiemTra;
        private System.Windows.Forms.TextBox textDuongDanGui;
        private System.Windows.Forms.Button btChonFileKy;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textDuongDanNhan;
        private System.Windows.Forms.Button btChonFileKiemTra;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textTepKyGui;
        private System.Windows.Forms.TextBox textHienThiPublicKey;
        private System.Windows.Forms.PictureBox pB_damMay;
        private System.Windows.Forms.PictureBox pB_arrow;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

