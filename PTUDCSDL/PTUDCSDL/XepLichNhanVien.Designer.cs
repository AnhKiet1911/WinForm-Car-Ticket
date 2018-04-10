namespace PTUDCSDL
{
    partial class XepLichNhanVien
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
            this.lblTenNhanVien = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.lblLNV = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.lblMaChuyen = new MetroFramework.Controls.MetroLabel();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnThemNV = new MetroFramework.Controls.MetroLink();
            this.lblLoTrinh = new System.Windows.Forms.ComboBox();
            this.lblNgayDi = new MetroFramework.Controls.MetroLabel();
            this.btnCancel = new MetroFramework.Controls.MetroLink();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.metroPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTenNhanVien
            // 
            this.lblTenNhanVien.AutoSize = true;
            this.lblTenNhanVien.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblTenNhanVien.ForeColor = System.Drawing.Color.Red;
            this.lblTenNhanVien.Location = new System.Drawing.Point(225, 60);
            this.lblTenNhanVien.Name = "lblTenNhanVien";
            this.lblTenNhanVien.Size = new System.Drawing.Size(97, 19);
            this.lblTenNhanVien.TabIndex = 36;
            this.lblTenNhanVien.Text = "Nguyện Văn A";
            this.lblTenNhanVien.UseCustomForeColor = true;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(124, 60);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(95, 19);
            this.metroLabel1.TabIndex = 35;
            this.metroLabel1.Text = "Tên Nhân Viên:";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(49, 195);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(63, 19);
            this.metroLabel3.TabIndex = 38;
            this.metroLabel3.Text = "Ngày Đi: ";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(49, 164);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(71, 19);
            this.metroLabel2.TabIndex = 37;
            this.metroLabel2.Text = "Chuyến Xe";
            // 
            // lblLNV
            // 
            this.lblLNV.AutoSize = true;
            this.lblLNV.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblLNV.ForeColor = System.Drawing.Color.Red;
            this.lblLNV.Location = new System.Drawing.Point(153, 132);
            this.lblLNV.Name = "lblLNV";
            this.lblLNV.Size = new System.Drawing.Size(65, 19);
            this.lblLNV.TabIndex = 40;
            this.lblLNV.Text = "Tài Xế ......";
            this.lblLNV.UseCustomForeColor = true;
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(49, 132);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(97, 19);
            this.metroLabel5.TabIndex = 39;
            this.metroLabel5.Text = "Loại Nhân Viên";
            // 
            // lblMaChuyen
            // 
            this.lblMaChuyen.AutoSize = true;
            this.lblMaChuyen.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblMaChuyen.ForeColor = System.Drawing.Color.Red;
            this.lblMaChuyen.Location = new System.Drawing.Point(152, 164);
            this.lblMaChuyen.Name = "lblMaChuyen";
            this.lblMaChuyen.Size = new System.Drawing.Size(80, 19);
            this.lblMaChuyen.TabIndex = 41;
            this.lblMaChuyen.Text = "Mã Chuyến";
            this.lblMaChuyen.UseCustomForeColor = true;
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.Location = new System.Drawing.Point(49, 224);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(54, 19);
            this.metroLabel7.TabIndex = 42;
            this.metroLabel7.Text = "Lộ Trình";
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.Location = new System.Drawing.Point(124, 92);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(53, 19);
            this.metroLabel8.TabIndex = 44;
            this.metroLabel8.Text = "Ca Trực";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Ca Sáng",
            "Ca Chiều",
            "Ca Đêm"});
            this.comboBox1.Location = new System.Drawing.Point(192, 90);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(130, 21);
            this.comboBox1.TabIndex = 45;
            // 
            // btnThemNV
            // 
            this.btnThemNV.BackColor = System.Drawing.Color.DarkBlue;
            this.btnThemNV.FontSize = MetroFramework.MetroLinkSize.Medium;
            this.btnThemNV.FontWeight = MetroFramework.MetroLinkWeight.Regular;
            this.btnThemNV.ForeColor = System.Drawing.Color.White;
            this.btnThemNV.ImageSize = 36;
            this.btnThemNV.Location = new System.Drawing.Point(0, 1);
            this.btnThemNV.Name = "btnThemNV";
            this.btnThemNV.Size = new System.Drawing.Size(55, 22);
            this.btnThemNV.TabIndex = 47;
            this.btnThemNV.Text = "Okey";
            this.btnThemNV.UseCustomBackColor = true;
            this.btnThemNV.UseCustomForeColor = true;
            this.btnThemNV.UseSelectable = true;
            this.btnThemNV.Click += new System.EventHandler(this.btnThemNV_Click);
            // 
            // lblLoTrinh
            // 
            this.lblLoTrinh.FormattingEnabled = true;
            this.lblLoTrinh.Location = new System.Drawing.Point(152, 221);
            this.lblLoTrinh.Name = "lblLoTrinh";
            this.lblLoTrinh.Size = new System.Drawing.Size(151, 21);
            this.lblLoTrinh.TabIndex = 49;
            this.lblLoTrinh.SelectedValueChanged += new System.EventHandler(this.lblLoTrinh_SelectedValueChanged);
            // 
            // lblNgayDi
            // 
            this.lblNgayDi.AutoSize = true;
            this.lblNgayDi.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblNgayDi.ForeColor = System.Drawing.Color.Red;
            this.lblNgayDi.Location = new System.Drawing.Point(152, 195);
            this.lblNgayDi.Name = "lblNgayDi";
            this.lblNgayDi.Size = new System.Drawing.Size(85, 19);
            this.lblNgayDi.TabIndex = 50;
            this.lblNgayDi.Text = "19-12-2016";
            this.lblNgayDi.UseCustomForeColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancel.FontSize = MetroFramework.MetroLinkSize.Medium;
            this.btnCancel.FontWeight = MetroFramework.MetroLinkWeight.Regular;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.ImageSize = 36;
            this.btnCancel.Location = new System.Drawing.Point(82, 1);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(55, 22);
            this.btnCancel.TabIndex = 51;
            this.btnCancel.Text = "Thoát";
            this.btnCancel.UseCustomBackColor = true;
            this.btnCancel.UseCustomForeColor = true;
            this.btnCancel.UseSelectable = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.btnCancel);
            this.metroPanel1.Controls.Add(this.btnThemNV);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(317, 251);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(137, 22);
            this.metroPanel1.TabIndex = 52;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // XepLichNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 275);
            this.Controls.Add(this.metroPanel1);
            this.Controls.Add(this.lblNgayDi);
            this.Controls.Add(this.lblLoTrinh);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.metroLabel8);
            this.Controls.Add(this.metroLabel7);
            this.Controls.Add(this.lblMaChuyen);
            this.Controls.Add(this.lblLNV);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.lblTenNhanVien);
            this.Controls.Add(this.metroLabel1);
            this.Name = "XepLichNhanVien";
            this.Text = "Xếp Lịch Nhân Viên";
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.Load += new System.EventHandler(this.XepLichNhanVien_Load);
            this.metroPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel lblTenNhanVien;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel lblLNV;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroLabel lblMaChuyen;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private System.Windows.Forms.ComboBox comboBox1;
        private MetroFramework.Controls.MetroLink btnThemNV;
        private System.Windows.Forms.ComboBox lblLoTrinh;
        private MetroFramework.Controls.MetroLabel lblNgayDi;
        private MetroFramework.Controls.MetroLink btnCancel;
        private MetroFramework.Controls.MetroPanel metroPanel1;
    }
}