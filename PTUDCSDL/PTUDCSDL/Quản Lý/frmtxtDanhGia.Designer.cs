namespace PTUDCSDL.Quản_Lý
{
    partial class frmtxtDanhGia
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
            this.txtDanhGia = new MetroFramework.Controls.MetroTextBox();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // txtDanhGia
            // 
            this.txtDanhGia.Anchor = System.Windows.Forms.AnchorStyles.None;
            // 
            // 
            // 
            this.txtDanhGia.CustomButton.Image = null;
            this.txtDanhGia.CustomButton.Location = new System.Drawing.Point(339, 2);
            this.txtDanhGia.CustomButton.Name = "";
            this.txtDanhGia.CustomButton.Size = new System.Drawing.Size(85, 85);
            this.txtDanhGia.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtDanhGia.CustomButton.TabIndex = 1;
            this.txtDanhGia.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtDanhGia.CustomButton.UseSelectable = true;
            this.txtDanhGia.CustomButton.Visible = false;
            this.txtDanhGia.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtDanhGia.ForeColor = System.Drawing.Color.Snow;
            this.txtDanhGia.Lines = new string[] {
        "........."};
            this.txtDanhGia.Location = new System.Drawing.Point(8, 63);
            this.txtDanhGia.MaxLength = 32767;
            this.txtDanhGia.Name = "txtDanhGia";
            this.txtDanhGia.PasswordChar = '\0';
            this.txtDanhGia.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtDanhGia.SelectedText = "";
            this.txtDanhGia.SelectionLength = 0;
            this.txtDanhGia.SelectionStart = 0;
            this.txtDanhGia.ShortcutsEnabled = true;
            this.txtDanhGia.Size = new System.Drawing.Size(427, 90);
            this.txtDanhGia.TabIndex = 0;
            this.txtDanhGia.Text = ".........";
            this.txtDanhGia.UseCustomBackColor = true;
            this.txtDanhGia.UseCustomForeColor = true;
            this.txtDanhGia.UseSelectable = true;
            this.txtDanhGia.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtDanhGia.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtDanhGia.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDanhGia_KeyDown);
            // 
            // metroButton1
            // 
            this.metroButton1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.metroButton1.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.metroButton1.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.metroButton1.ForeColor = System.Drawing.Color.Red;
            this.metroButton1.Highlight = true;
            this.metroButton1.Location = new System.Drawing.Point(360, 159);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(75, 20);
            this.metroButton1.TabIndex = 1;
            this.metroButton1.Text = "Okey";
            this.metroButton1.UseCustomBackColor = true;
            this.metroButton1.UseCustomForeColor = true;
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // frmtxtDanhGia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 181);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.txtDanhGia);
            this.Name = "frmtxtDanhGia";
            this.Text = "Đánh Giá";
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Load += new System.EventHandler(this.frmtxtDanhGia_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox txtDanhGia;
        private MetroFramework.Controls.MetroButton metroButton1;
    }
}