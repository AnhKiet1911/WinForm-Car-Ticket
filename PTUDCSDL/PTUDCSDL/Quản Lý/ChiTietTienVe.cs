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

namespace PTUDCSDL.Quản_Lý
{
    public partial class frmChiTietTienVe : MetroFramework.Forms.MetroForm
    {
        public frmChiTietTienVe()
        {
            InitializeComponent();
        }


        string IdVe_FormMain;
        string IdChuyen_FormMain;


        public void GetPassData_FormMain(string str)
        {
            IdVe_FormMain = str;
        }
        public void GetPassData_FormMain1(string str)
        {
            IdChuyen_FormMain = str;
        }


        private void ShowInfoKhachHang()
        {

            string IdVe = IdVe_FormMain;
            string IdChuyen = IdChuyen_FormMain;
            try
            {
                SqlConnection Con = KetNoiCSDL.KetNoiSQL();
                Con.Open();

                //Lấy Tên
                string Ten = string.Format("exec ShowInfoKhachHang_Ten @IdChuyen, @IdVe"); //Gọi Proc
                SqlCommand Com = new SqlCommand(Ten, Con);
                Com.Parameters.Add(new SqlParameter("@IdVe", IdVe));
                Com.Parameters.Add(new SqlParameter("@IdChuyen", IdChuyen));
                txtTen.Text = Com.ExecuteScalar().ToString();

                //LayCMND
                string CMND = string.Format("exec ShowInfoKhachHang_CMND @IdChuyen,@IdVe"); //Gọi Proc
                Com = new SqlCommand(CMND, Con);
                Com.Parameters.Add(new SqlParameter("@IdVe", IdVe));
                Com.Parameters.Add(new SqlParameter("@IdChuyen", IdChuyen));
                ntxtCMND.Text = Com.ExecuteScalar().ToString();


                //QueQuan
                string Que = string.Format("exec ShowInfoKhachHang_Que @IdChuyen,@IdVe"); //Gọi Proc
                Com = new SqlCommand(Que, Con);
                Com.Parameters.Add(new SqlParameter("@IdVe", IdVe));
                Com.Parameters.Add(new SqlParameter("@IdChuyen", IdChuyen));
                DynamicCBOXQueQuan.Text = Com.ExecuteScalar().ToString();


                //LaySDT
                string SDT = string.Format("exec ShowInfoKhachHang_SDT @IdChuyen, @IdVe"); //Gọi Proc
                Com = new SqlCommand(SDT, Con);
                Com.Parameters.Add(new SqlParameter("@IdVe", IdVe));
                Com.Parameters.Add(new SqlParameter("@IdChuyen", IdChuyen));
                ntxtSDT.Text = Com.ExecuteScalar().ToString();

                //LayNgaySinh
                string NgaySinh = string.Format("exec ShowInfoKhachHang_NgaySinh @IdChuyen ,@IdVe"); //Gọi Proc
                Com = new SqlCommand(NgaySinh, Con);
                Com.Parameters.Add(new SqlParameter("@IdVe", IdVe));
                Com.Parameters.Add(new SqlParameter("@IdChuyen", IdChuyen));
                dateTimePicker1.Text = Com.ExecuteScalar().ToString();

                //LayGiaTien
                string Tien = string.Format("exec ShowInfoKhachHang_Tien @IdChuyen, @IdVe"); //Gọi Proc
                Com = new SqlCommand(Tien, Con);
                Com.Parameters.Add(new SqlParameter("@IdVe", IdVe));
                Com.Parameters.Add(new SqlParameter("@IdChuyen", IdChuyen));
                TextBoxGiaTien.Text = Com.ExecuteScalar().ToString();

                //LayNgay
                string Ngay = string.Format("exec ShowInfoKhachHang_NgayDi @IdChuyen, @IdVe"); //Gọi Proc
                Com = new SqlCommand(Ngay, Con);
                Com.Parameters.Add(new SqlParameter("@IdVe", IdVe));
                Com.Parameters.Add(new SqlParameter("@IdChuyen", IdChuyen));
                txtNgayDi.Text = Com.ExecuteScalar().ToString();

                //LayGio
                string Gio = string.Format("exec ShowInfoKhachHang_GioDi @IdChuyen , @IdVe"); //Gọi Proc
                Com = new SqlCommand(Gio, Con);
                Com.Parameters.Add(new SqlParameter("@IdVe", IdVe));
                Com.Parameters.Add(new SqlParameter("@IdChuyen", IdChuyen));
                txtGioDi.Text = Com.ExecuteScalar().ToString();

                //LayLoTrinh
                string LoTrinh = string.Format("exec ShowInfoKhachHang_LoTrinh @IdChuyen,@IdVe"); //Gọi Proc
                Com = new SqlCommand(LoTrinh, Con);
                Com.Parameters.Add(new SqlParameter("@IdVe", IdVe));
                Com.Parameters.Add(new SqlParameter("@IdChuyen", IdChuyen));
                CBChuyenTu_Den.Text = Com.ExecuteScalar().ToString();

                Con.Close();
            }
            catch (Exception EX)
            {
                MetroFramework.MetroMessageBox.Show(this, EX.Message);
            }
        }

        private void frmChiTietTienVe_Load(object sender, EventArgs e)
        {
            ShowInfoKhachHang();
            lblMaVe.Text = IdVe_FormMain + " - " + IdChuyen_FormMain;
        }
    }
}
