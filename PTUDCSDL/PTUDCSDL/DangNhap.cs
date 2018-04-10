using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTUDCSDL
{
    public partial class DangNhap : MetroFramework.Forms.MetroForm
    {
        public DangNhap()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Code MD5 Mã Hoá Password
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private static byte[] encryptData(string data)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider md5Hasher = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] hashedBytes;
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            hashedBytes = md5Hasher.ComputeHash(encoder.GetBytes(data));
            return hashedBytes;
        }
        private static string md5(string data)
        {
            return BitConverter.ToString(encryptData(data)).Replace("-", "").ToLower();
        }




        public delegate void PassData(MetroFramework.Controls.MetroTextBox Box);


        /// <summary>
        /// Load Form Đăng Nhập
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DangNhap_Load(object sender, EventArgs e)
        {
            txtTaiKhoan.Select();
            txtTaiKhoan.Clear();
            txtMatKhau.Clear();
            ShowPass.Checked = false;
            lblThongBao.Visible = false;
            lblTBPass.Visible = false;
            lblTBTaiKhoan.Visible = false;
            this.ClientSize = new Size(406, 208);
        }



        /// <summary>
        /// Login 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {

                SqlConnection Con = KetNoiCSDL.KetNoiSQL();

                Con.Open();

                string PassWordMD5 = txtMatKhau.Text;
                PassWordMD5 = md5(PassWordMD5);


                string SelectDangNhap = string.Format("exec DangNhap @UseName, @MatKhau"); //Gọi Proc
                SqlCommand Com = new SqlCommand(SelectDangNhap, Con);
                Com.Parameters.Add(new SqlParameter("@UseName", txtTaiKhoan.Text));
                Com.Parameters.Add(new SqlParameter("@MatKhau", PassWordMD5));
                int check = Convert.ToInt32(Com.ExecuteScalar());

                Con.Close();


                if (txtTaiKhoan.Text == "" && txtMatKhau.Text == "")
                {
                    this.lblThongBao.Visible = true;
                    this.lblThongBao.Text = "Chưa Nhập Tài Khoản Và Mật Khẩu";
                    this.lblTBPass.Visible = true;
                    this.lblTBTaiKhoan.Visible = true;

                }
                else
                {
                    if (this.txtTaiKhoan.Text != "" && this.txtMatKhau.Text == "")
                    {
                        this.lblThongBao.Visible = true;
                        this.lblThongBao.Text = "Chưa Nhập Mật Khẩu";
                        this.lblTBPass.Visible = true;
                        this.lblTBTaiKhoan.Visible = false;
                    }

                    else if (this.txtTaiKhoan.Text != "" && this.txtMatKhau.Text != "")
                    {
                        if (check == 1)
                        {
                            this.lblTBPass.Visible = false;
                            this.lblTBTaiKhoan.Visible = false;
                            Main FrmMain = new Main();
                            PassData Share = new PassData(FrmMain.GetData_Form1);
                            Share(this.txtTaiKhoan);
                            this.Hide();
                            FrmMain.ShowDialog();
                            this.lblThongBao.Visible = false;
                            this.Show();

                        }
                        else
                        {
                            this.lblThongBao.Visible = true;
                            this.lblThongBao.Text = "Sai Tài Khoản Hoặc Mật Khẩu";
                            this.lblTBPass.Visible = false;
                            this.lblTBTaiKhoan.Visible = false;
                        }

                    }

                    else
                    {
                        this.lblThongBao.Visible = true;
                        this.lblThongBao.Text = "Chưa Nhập Tài Khoản";
                        this.lblTBPass.Visible = false;
                        this.lblTBTaiKhoan.Visible = true;

                    }
                }
            }
            catch (Exception EX)
            {
                MetroFramework.MetroMessageBox.Show(this, EX.Message);
            }
        }



        /// <summary>
        /// Short Key
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTaiKhoan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
            if (e.KeyCode == Keys.Escape)
            {
                DangNhap_Load(sender, e);
            }
        }


        /// <summary>
        /// Show Passwd/Hide Passwd
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (ShowPass.Checked)
            {
                txtMatKhau.PasswordChar = '\0';
            }
            else
            {
                txtMatKhau.PasswordChar = '*';
            }
        }

    }
}
