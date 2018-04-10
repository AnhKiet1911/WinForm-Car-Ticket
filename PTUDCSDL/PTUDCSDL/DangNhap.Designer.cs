namespace PTUDCSDL
{
    partial class DangNhap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DangNhap));
            this.ImgLogin = new MetroFramework.Controls.MetroTile();
            this.lblTaiKhoan = new MetroFramework.Controls.MetroLabel();
            this.metroCheckBox1 = new MetroFramework.Controls.MetroCheckBox();
            this.txtTaiKhoan = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.txtMatKhau = new MetroFramework.Controls.MetroTextBox();
            this.lblMatKhau = new MetroFramework.Controls.MetroLabel();
            this.btnLogin = new MetroFramework.Controls.MetroButton();
            this.btnReset = new MetroFramework.Controls.MetroButton();
            this.lblTBTaiKhoan = new MetroFramework.Controls.MetroLabel();
            this.lblTBPass = new MetroFramework.Controls.MetroLabel();
            this.ShowPass = new MetroFramework.Controls.MetroCheckBox();
            this.lblThongBao = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ImgLogin
            // 
            this.ImgLogin.ActiveControl = null;
            this.ImgLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ImgLogin.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ImgLogin.BackColor = System.Drawing.Color.Blue;
            this.ImgLogin.Location = new System.Drawing.Point(35, 68);
            this.ImgLogin.Name = "ImgLogin";
            this.ImgLogin.Size = new System.Drawing.Size(100, 100);
            this.ImgLogin.TabIndex = 11;
            this.ImgLogin.TileImage = global::PTUDCSDL.Properties.Resources.Register_icon;
            this.ImgLogin.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ImgLogin.UseSelectable = true;
            this.ImgLogin.UseTileImage = true;
            this.ImgLogin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTaiKhoan_KeyDown);
            // 
            // lblTaiKhoan
            // 
            this.lblTaiKhoan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTaiKhoan.AutoSize = true;
            this.lblTaiKhoan.Location = new System.Drawing.Point(153, 90);
            this.lblTaiKhoan.Name = "lblTaiKhoan";
            this.lblTaiKhoan.Size = new System.Drawing.Size(64, 19);
            this.lblTaiKhoan.Style = MetroFramework.MetroColorStyle.Red;
            this.lblTaiKhoan.TabIndex = 8;
            this.lblTaiKhoan.Text = "Tài Khoản";
            // 
            // metroCheckBox1
            // 
            this.metroCheckBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.metroCheckBox1.AutoSize = true;
            this.metroCheckBox1.Location = new System.Drawing.Point(35, 174);
            this.metroCheckBox1.Name = "metroCheckBox1";
            this.metroCheckBox1.Size = new System.Drawing.Size(16, 0);
            this.metroCheckBox1.TabIndex = 6;
            this.metroCheckBox1.UseSelectable = true;
            // 
            // txtTaiKhoan
            // 
            this.txtTaiKhoan.Anchor = System.Windows.Forms.AnchorStyles.None;
            // 
            // 
            // 
            this.txtTaiKhoan.CustomButton.Image = null;
            this.txtTaiKhoan.CustomButton.Location = new System.Drawing.Point(123, 1);
            this.txtTaiKhoan.CustomButton.Name = "";
            this.txtTaiKhoan.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtTaiKhoan.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtTaiKhoan.CustomButton.TabIndex = 1;
            this.txtTaiKhoan.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtTaiKhoan.CustomButton.UseSelectable = true;
            this.txtTaiKhoan.CustomButton.Visible = false;
            this.txtTaiKhoan.Lines = new string[0];
            this.txtTaiKhoan.Location = new System.Drawing.Point(223, 86);
            this.txtTaiKhoan.MaxLength = 32767;
            this.txtTaiKhoan.Name = "txtTaiKhoan";
            this.txtTaiKhoan.PasswordChar = '\0';
            this.txtTaiKhoan.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtTaiKhoan.SelectedText = "";
            this.txtTaiKhoan.SelectionLength = 0;
            this.txtTaiKhoan.SelectionStart = 0;
            this.txtTaiKhoan.ShortcutsEnabled = true;
            this.txtTaiKhoan.Size = new System.Drawing.Size(145, 23);
            this.txtTaiKhoan.TabIndex = 1;
            this.txtTaiKhoan.UseSelectable = true;
            this.txtTaiKhoan.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtTaiKhoan.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtTaiKhoan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTaiKhoan_KeyDown);
            // 
            // metroLabel2
            // 
            this.metroLabel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(153, 127);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(0, 0);
            this.metroLabel2.TabIndex = 4;
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Anchor = System.Windows.Forms.AnchorStyles.None;
            // 
            // 
            // 
            this.txtMatKhau.CustomButton.Image = null;
            this.txtMatKhau.CustomButton.Location = new System.Drawing.Point(123, 1);
            this.txtMatKhau.CustomButton.Name = "";
            this.txtMatKhau.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtMatKhau.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtMatKhau.CustomButton.TabIndex = 1;
            this.txtMatKhau.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtMatKhau.CustomButton.UseSelectable = true;
            this.txtMatKhau.CustomButton.Visible = false;
            this.txtMatKhau.Lines = new string[0];
            this.txtMatKhau.Location = new System.Drawing.Point(223, 127);
            this.txtMatKhau.MaxLength = 32767;
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.PasswordChar = '*';
            this.txtMatKhau.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtMatKhau.SelectedText = "";
            this.txtMatKhau.SelectionLength = 0;
            this.txtMatKhau.SelectionStart = 0;
            this.txtMatKhau.ShortcutsEnabled = true;
            this.txtMatKhau.Size = new System.Drawing.Size(145, 23);
            this.txtMatKhau.TabIndex = 2;
            this.txtMatKhau.UseSelectable = true;
            this.txtMatKhau.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtMatKhau.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtMatKhau.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTaiKhoan_KeyDown);
            // 
            // lblMatKhau
            // 
            this.lblMatKhau.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblMatKhau.AutoSize = true;
            this.lblMatKhau.Location = new System.Drawing.Point(153, 127);
            this.lblMatKhau.Name = "lblMatKhau";
            this.lblMatKhau.Size = new System.Drawing.Size(64, 19);
            this.lblMatKhau.TabIndex = 6;
            this.lblMatKhau.Text = "Mật Khẩu";
            // 
            // btnLogin
            // 
            this.btnLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLogin.Location = new System.Drawing.Point(223, 177);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(64, 23);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseSelectable = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            this.btnLogin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTaiKhoan_KeyDown);
            // 
            // btnReset
            // 
            this.btnReset.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnReset.Location = new System.Drawing.Point(304, 177);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(64, 23);
            this.btnReset.TabIndex = 4;
            this.btnReset.Text = "Reset";
            this.btnReset.UseSelectable = true;
            this.btnReset.Click += new System.EventHandler(this.DangNhap_Load);
            this.btnReset.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTaiKhoan_KeyDown);
            // 
            // lblTBTaiKhoan
            // 
            this.lblTBTaiKhoan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTBTaiKhoan.AutoSize = true;
            this.lblTBTaiKhoan.BackColor = System.Drawing.Color.Red;
            this.lblTBTaiKhoan.ForeColor = System.Drawing.Color.Red;
            this.lblTBTaiKhoan.LabelMode = MetroFramework.Controls.MetroLabelMode.Selectable;
            this.lblTBTaiKhoan.Location = new System.Drawing.Point(375, 89);
            this.lblTBTaiKhoan.Name = "lblTBTaiKhoan";
            this.lblTBTaiKhoan.Size = new System.Drawing.Size(15, 19);
            this.lblTBTaiKhoan.TabIndex = 0;
            this.lblTBTaiKhoan.Text = "*";
            this.lblTBTaiKhoan.Visible = false;
            // 
            // lblTBPass
            // 
            this.lblTBPass.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTBPass.AutoSize = true;
            this.lblTBPass.BackColor = System.Drawing.Color.Red;
            this.lblTBPass.ForeColor = System.Drawing.Color.Red;
            this.lblTBPass.Location = new System.Drawing.Point(373, 131);
            this.lblTBPass.Name = "lblTBPass";
            this.lblTBPass.Size = new System.Drawing.Size(15, 19);
            this.lblTBPass.TabIndex = 0;
            this.lblTBPass.Text = "*";
            this.lblTBPass.Visible = false;
            // 
            // ShowPass
            // 
            this.ShowPass.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ShowPass.AutoSize = true;
            this.ShowPass.Location = new System.Drawing.Point(223, 153);
            this.ShowPass.Name = "ShowPass";
            this.ShowPass.Size = new System.Drawing.Size(122, 15);
            this.ShowPass.TabIndex = 5;
            this.ShowPass.Text = "Hiển Thị Mật Khẩu";
            this.ShowPass.UseSelectable = true;
            this.ShowPass.CheckedChanged += new System.EventHandler(this.ShowPass_CheckedChanged);
            // 
            // lblThongBao
            // 
            this.lblThongBao.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblThongBao.AutoSize = true;
            this.lblThongBao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThongBao.ForeColor = System.Drawing.Color.Red;
            this.lblThongBao.Location = new System.Drawing.Point(13, 187);
            this.lblThongBao.Name = "lblThongBao";
            this.lblThongBao.Size = new System.Drawing.Size(69, 13);
            this.lblThongBao.TabIndex = 12;
            this.lblThongBao.Text = "Thông Báo";
            this.lblThongBao.Visible = false;
            // 
            // DangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = global::PTUDCSDL.Properties.Resources.Register_icon;
            this.ClientSize = new System.Drawing.Size(406, 208);
            this.Controls.Add(this.lblThongBao);
            this.Controls.Add(this.ShowPass);
            this.Controls.Add(this.lblTBPass);
            this.Controls.Add(this.lblTBTaiKhoan);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.lblMatKhau);
            this.Controls.Add(this.txtMatKhau);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.txtTaiKhoan);
            this.Controls.Add(this.metroCheckBox1);
            this.Controls.Add(this.lblTaiKhoan);
            this.Controls.Add(this.ImgLogin);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DangNhap";
            this.Opacity = 0.9D;
            this.Text = "Đăng Nhập";
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.Load += new System.EventHandler(this.DangNhap_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTile ImgLogin;
        private MetroFramework.Controls.MetroLabel lblTaiKhoan;
        private MetroFramework.Controls.MetroCheckBox metroCheckBox1;
        private MetroFramework.Controls.MetroTextBox txtTaiKhoan;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox txtMatKhau;
        private MetroFramework.Controls.MetroLabel lblMatKhau;
        private MetroFramework.Controls.MetroButton btnLogin;
        private MetroFramework.Controls.MetroButton btnReset;
        private MetroFramework.Controls.MetroLabel lblTBTaiKhoan;
        private MetroFramework.Controls.MetroLabel lblTBPass;
        private MetroFramework.Controls.MetroCheckBox ShowPass;
        private System.Windows.Forms.Label lblThongBao;
    }
}

