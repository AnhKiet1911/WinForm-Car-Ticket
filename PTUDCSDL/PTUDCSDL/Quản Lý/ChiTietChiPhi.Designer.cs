namespace PTUDCSDL.Quản_Lý
{
    partial class ChiTietChiPhi
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
            this.lblMa = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.lblTen = new MetroFramework.Controls.MetroLabel();
            this.lblChiTiet = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.lbltien = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // lblMa
            // 
            this.lblMa.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblMa.AutoSize = true;
            this.lblMa.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblMa.ForeColor = System.Drawing.Color.Red;
            this.lblMa.Location = new System.Drawing.Point(239, 70);
            this.lblMa.Name = "lblMa";
            this.lblMa.Size = new System.Drawing.Size(33, 19);
            this.lblMa.TabIndex = 14;
            this.lblMa.Text = "001";
            this.lblMa.UseCustomForeColor = true;
            // 
            // metroLabel1
            // 
            this.metroLabel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.ForeColor = System.Drawing.Color.Red;
            this.metroLabel1.Location = new System.Drawing.Point(34, 175);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(55, 19);
            this.metroLabel1.TabIndex = 15;
            this.metroLabel1.Text = "Chi Tiết";
            this.metroLabel1.UseCustomForeColor = true;
            // 
            // metroLabel2
            // 
            this.metroLabel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel2.ForeColor = System.Drawing.Color.Red;
            this.metroLabel2.Location = new System.Drawing.Point(33, 118);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(77, 19);
            this.metroLabel2.TabIndex = 16;
            this.metroLabel2.Text = "Tên Chi Phí";
            this.metroLabel2.UseCustomForeColor = true;
            // 
            // lblTen
            // 
            this.lblTen.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTen.AutoSize = true;
            this.lblTen.Location = new System.Drawing.Point(185, 117);
            this.lblTen.Name = "lblTen";
            this.lblTen.Size = new System.Drawing.Size(24, 19);
            this.lblTen.TabIndex = 17;
            this.lblTen.Text = ".....";
            // 
            // lblChiTiet
            // 
            this.lblChiTiet.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblChiTiet.AutoSize = true;
            this.lblChiTiet.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblChiTiet.Location = new System.Drawing.Point(185, 174);
            this.lblChiTiet.Name = "lblChiTiet";
            this.lblChiTiet.Size = new System.Drawing.Size(18, 19);
            this.lblChiTiet.TabIndex = 18;
            this.lblChiTiet.Text = "...";
            // 
            // metroLabel3
            // 
            this.metroLabel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel3.ForeColor = System.Drawing.Color.Red;
            this.metroLabel3.Location = new System.Drawing.Point(34, 221);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(53, 19);
            this.metroLabel3.TabIndex = 19;
            this.metroLabel3.Text = "Số Tiền";
            this.metroLabel3.UseCustomForeColor = true;
            // 
            // lbltien
            // 
            this.lbltien.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbltien.AutoSize = true;
            this.lbltien.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lbltien.Location = new System.Drawing.Point(185, 221);
            this.lbltien.Name = "lbltien";
            this.lbltien.Size = new System.Drawing.Size(18, 19);
            this.lbltien.TabIndex = 20;
            this.lbltien.Text = "...";
            // 
            // ChiTietChiPhi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 246);
            this.Controls.Add(this.lbltien);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.lblChiTiet);
            this.Controls.Add(this.lblTen);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.lblMa);
            this.Name = "ChiTietChiPhi";
            this.Style = MetroFramework.MetroColorStyle.Orange;
            this.Text = "Chi Tiết Chi Phí";
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.Load += new System.EventHandler(this.ChiTietChiPhi_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroLabel lblMa;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel lblTen;
        private MetroFramework.Controls.MetroLabel lblChiTiet;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel lbltien;
    }
}