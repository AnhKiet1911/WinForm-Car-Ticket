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
    public partial class frmInPhieu : MetroFramework.Forms.MetroForm
    {
        public frmInPhieu()
        {
            InitializeComponent();
            ControlBox = false;
        }

        string IdVe;
        string TienVe;
        string IdNguoiDung_FormDatVe;

        public void GetPassData_FormDatVe(string str)
        {
            int index = str.IndexOf("&");
            int LastIndex = str.LastIndexOf("&");
            IdVe = str.Substring(0, index);
            TienVe = str.Substring(index, LastIndex);
            IdNguoiDung_FormDatVe = str.Substring(LastIndex + 1);
        }

        private CDatVe GetInfoKhachHang()
        {
            CDatVe Info = new CDatVe();
            try
            {

                SqlConnection Con = KetNoiCSDL.KetNoiSQL();
                Con.Open();

                //IdChuyen
                string IdChuyen = string.Format("exec  GetInfoKhachHang_IdChuyen @ID"); //Gọi Proc
                SqlCommand Com = new SqlCommand(IdChuyen, Con);
                Com.Parameters.Add(new SqlParameter("@ID", IdVe));
                Info.IdChuyen = Com.ExecuteScalar().ToString();

                //Ten
                string Ten = string.Format("exec  GetInfoKhachHang_Ten @ID"); //Gọi Proc
                Com = new SqlCommand(Ten, Con);
                Com.Parameters.Add(new SqlParameter("@ID", IdVe));
                Info.TenKhachHang = Com.ExecuteScalar().ToString();

                //CMND
                string CMND = string.Format("exec  GetInfoKhachHang_CMND @ID"); //Gọi Proc
                Com = new SqlCommand(CMND, Con);
                Com.Parameters.Add(new SqlParameter("@ID", IdVe));
                Info.CMND = Com.ExecuteScalar().ToString();


                //LayNgaySinh
                string NgaySinh = string.Format("exec  GetInfoKhachHang_NgaySinh @ID"); //Gọi Proc
                Com = new SqlCommand(NgaySinh, Con);
                Com.Parameters.Add(new SqlParameter("@ID", IdVe));
                Info.NgaySinh = Com.ExecuteScalar().ToString();

                int index = Info.NgaySinh.IndexOf(" ");
                if (index != -1)
                {
                    Info.NgaySinh = Info.NgaySinh.Substring(0, index);
                }

                //LayDienThoai
                string SoDienThoai = string.Format("exec  GetInfoKhachHang_SDT @ID"); //Gọi Proc
                Com = new SqlCommand(SoDienThoai, Con);
                Com.Parameters.Add(new SqlParameter("@ID", IdVe));
                Info.SDT = Com.ExecuteScalar().ToString();

                //LayDiaChi
                string DiaChi = string.Format("exec  GetInfoKhachHang_DiaChi @ID"); //Gọi Proc
                Com = new SqlCommand(DiaChi, Con);
                Com.Parameters.Add(new SqlParameter("@ID", IdVe));
                Info.QueQuan = Com.ExecuteScalar().ToString();

                //Giá Vé
                Info.TienVe = TienVe;

                //LaySoXe
                string SoXe = string.Format("exec GetInfoKhachHang_SoXe  @IdChuyen"); //Gọi Proc
                Com = new SqlCommand(SoXe, Con);
                Com.Parameters.Add(new SqlParameter("@IdChuyen", Info.IdChuyen));
                Info.SoXe = Com.ExecuteScalar().ToString();

                //NgayDi
                string NgayDi = string.Format("exec GetInfoKhachHang_NgayDi  @IdChuyen"); //Gọi Proc
                Com = new SqlCommand(NgayDi, Con);
                Com.Parameters.Add(new SqlParameter("@IdChuyen", Info.IdChuyen));
                Info.NgayDi = Com.ExecuteScalar().ToString();

                //GioDi
                string GioDi = string.Format("exec GetInfoKhachHang_GioDi  @IdChuyen "); //Gọi Proc
                Com = new SqlCommand(GioDi, Con);
                Com.Parameters.Add(new SqlParameter("@IdChuyen", Info.IdChuyen));
                Info.GioDi = Com.ExecuteScalar().ToString();

                //HieuXe
                string HieuXe = string.Format("exec  GetInfoKhachHang_HieuXe  @IdChuyen"); //Gọi Proc
                Com = new SqlCommand(HieuXe, Con);
                Com.Parameters.Add(new SqlParameter("@IdChuyen", Info.IdChuyen));
                Info.HieuXe = Com.ExecuteScalar().ToString();

                //LoTrinh
                string LoTrinh = string.Format("exec GetInfoKhachHang_LoTrinh  @IdChuyen"); //Gọi Proc
                Com = new SqlCommand(LoTrinh, Con);
                Com.Parameters.Add(new SqlParameter("@IdChuyen", Info.IdChuyen));
                Info.LoTrinh = Com.ExecuteScalar().ToString();



                //TenNhanVien
                string TenNhanVien = string.Format("exec GetInfoKhachHang_TenNhanVien @IdNguoiDung"); //Gọi Proc
                Com = new SqlCommand(TenNhanVien, Con);
                Com.Parameters.Add(new SqlParameter("@IdNguoiDung", IdNguoiDung_FormDatVe));
                lblTenBanVe.Text = Com.ExecuteScalar().ToString();

                Con.Close();

            }
            catch (Exception EX)
            {
                MetroFramework.MetroMessageBox.Show(this, EX.Message);
            }
            return Info;
        }

     
        private void metroLink1_Click(object sender, EventArgs e)
        {
            MetroFramework.MetroMessageBox.Show(this, "Compelete!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            this.Close();
        }



       

        private void frmInPhieu_Load(object sender, EventArgs e)
        {
            lblMaVe.Text = IdVe + " " + GetInfoKhachHang().IdChuyen;
            lblCMND.Text = GetInfoKhachHang().CMND;
            lblNgaySinh.Text = GetInfoKhachHang().NgaySinh;
            lblQueQuan.Text = GetInfoKhachHang().QueQuan;
            lblSDT.Text = GetInfoKhachHang().SDT;
            lblGioDi.Text = GetInfoKhachHang().GioDi;
            lblNgayDi.Text = GetInfoKhachHang().NgayDi;
            lblBienSo.Text = GetInfoKhachHang().SoXe;
            lblLoTrinh.Text = GetInfoKhachHang().LoTrinh;
            lblHieuXe.Text = GetInfoKhachHang().HieuXe;
            lblOkane.Text = GetInfoKhachHang().TienVe;
            lblTen.Text = GetInfoKhachHang().TenKhachHang;
            lblNgayThangNam.Text = "Nhân Viên Bán Vé    " + "Ngày " + DateTime.Now.Day.ToString() + " Tháng " + DateTime.Now.Month.ToString() + " Năm " + DateTime.Now.Year.ToString();

        }



        //No Chage Size form
        private void InPhieu_ClientSizeChanged(object sender, EventArgs e)
        {
            if (this.Width != 740 || this.Height != 542)
            {
                this.ClientSize = new Size(740, 542);

            }
        }
    }
}
