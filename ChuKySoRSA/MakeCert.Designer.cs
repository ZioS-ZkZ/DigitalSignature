namespace ChuKySo
{
    partial class MakeCert
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
            this.MakeStore = new System.Windows.Forms.Button();
            this.MakeSelfSignedCert = new System.Windows.Forms.Button();
            this.ImportCert = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MakeStore
            // 
            this.MakeStore.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MakeStore.Location = new System.Drawing.Point(60, 39);
            this.MakeStore.Name = "MakeStore";
            this.MakeStore.Size = new System.Drawing.Size(171, 67);
            this.MakeStore.TabIndex = 0;
            this.MakeStore.Text = "Tạo Store";
            this.MakeStore.UseVisualStyleBackColor = true;
            this.MakeStore.Click += new System.EventHandler(this.MakeStore_Click);
            // 
            // MakeSelfSignedCert
            // 
            this.MakeSelfSignedCert.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MakeSelfSignedCert.Location = new System.Drawing.Point(60, 166);
            this.MakeSelfSignedCert.Name = "MakeSelfSignedCert";
            this.MakeSelfSignedCert.Size = new System.Drawing.Size(171, 67);
            this.MakeSelfSignedCert.TabIndex = 1;
            this.MakeSelfSignedCert.Text = "Tạo Self-Signed Certificate";
            this.MakeSelfSignedCert.UseVisualStyleBackColor = true;
            this.MakeSelfSignedCert.Click += new System.EventHandler(this.MakeSelfSignedCert_Click);
            // 
            // ImportCert
            // 
            this.ImportCert.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ImportCert.Location = new System.Drawing.Point(60, 294);
            this.ImportCert.Name = "ImportCert";
            this.ImportCert.Size = new System.Drawing.Size(171, 67);
            this.ImportCert.TabIndex = 2;
            this.ImportCert.Text = "Import Certificate vào Store";
            this.ImportCert.UseVisualStyleBackColor = true;
            this.ImportCert.Click += new System.EventHandler(this.ImportCert_Click);
            // 
            // MakeCert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ImportCert);
            this.Controls.Add(this.MakeSelfSignedCert);
            this.Controls.Add(this.MakeStore);
            this.Name = "MakeCert";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button MakeStore;
        private System.Windows.Forms.Button MakeSelfSignedCert;
        private System.Windows.Forms.Button ImportCert;
    }
}