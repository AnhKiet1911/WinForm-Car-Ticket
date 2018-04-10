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
    public partial class frmChiTietGuiHang : MetroFramework.Forms.MetroForm
    {
        public frmChiTietGuiHang()
        {
            InitializeComponent();
        }


        string IdHangHoa_FormMain;
        string IdChuyen_FormMain;


        public void GetPassData_FormMain(string str)
        {
            IdHangHoa_FormMain = str;
        }
        public void GetPassData_FormMain1(string str)
        {
            IdChuyen_FormMain = str;
        }

        private void ShowInfoKhachHang()
        {
            
            string IdHangHoa = IdHangHoa_FormMain;
            string IdChuyen = IdChuyen_FormMain;
            try
            {
                SqlConnection Con = KetNoiCSDL.KetNoiSQL();
                Con.Open();

                //Lấy Tên Người Gửi
                string TenNG = string.Format("exec InfoNhanHang_TenNG  @IdHangHoa , @IdChuyen"); //Gọi Proc
                SqlCommand Com = new SqlCommand(TenNG, Con);
                Com.Parameters.Add(new SqlParameter("@IdHangHoa", IdHangHoa));
                Com.Parameters.Add(new SqlParameter("@IdChuyen", IdChuyen));
                txtTenNguoiGui.Text = Com.ExecuteScalar().ToString();

                //Lấy Tên Người Nhận
                string TenNN = string.Format("exec InfoNhanHang_TenNN  @IdHangHoa , @IdChuyen"); //Gọi Proc
                Com = new SqlCommand(TenNN, Con);
                Com.Parameters.Add(new SqlParameter("@IdHangHoa", IdHangHoa));
                Com.Parameters.Add(new SqlParameter("@IdChuyen", IdChuyen));
                txtTenNguoiNhan.Text = Com.ExecuteScalar().ToString();



                //LayCMNDNguoiGui
                string CMNDNG = string.Format("exec InfoNhanHang_CMNDNG  @IdHangHoa , @IdChuyen"); //Gọi Proc
                Com = new SqlCommand(CMNDNG, Con);
                Com.Parameters.Add(new SqlParameter("@IdHangHoa", IdHangHoa));
                Com.Parameters.Add(new SqlParameter("@IdChuyen", IdChuyen));
                ntxtCMNDNguoiGui.Text = Com.ExecuteScalar().ToString();


                //LayCMNDNguoiNhan
                string CMNDNN = string.Format("exec InfoNhanHang_CMNDNN  @IdHangHoa , @IdChuyen"); //Gọi Proc
                Com = new SqlCommand(CMNDNN, Con);
                Com.Parameters.Add(new SqlParameter("@IdHangHoa", IdHangHoa));
                Com.Parameters.Add(new SqlParameter("@IdChuyen", IdChuyen));
                ntxtCMNDNguoiNhan.Text = Com.ExecuteScalar().ToString();

                //LaySDTNguoiGui
                string SDTNG = string.Format("exec InfoNhanHang_SDTNG  @IdHangHoa , @IdChuyen"); //Gọi Proc
                Com = new SqlCommand(SDTNG, Con);
                Com.Parameters.Add(new SqlParameter("@IdHangHoa", IdHangHoa));
                Com.Parameters.Add(new SqlParameter("@IdChuyen", IdChuyen));
                ntxtSDTNguoiGui.Text = Com.ExecuteScalar().ToString();

                //LaySDTNguoiNhan
                string SDTNN = string.Format("exec InfoNhanHang_SDTNN  @IdHangHoa , @IdChuyen"); //Gọi Proc
                Com = new SqlCommand(SDTNN, Con);
                Com.Parameters.Add(new SqlParameter("@IdHangHoa", IdHangHoa));
                Com.Parameters.Add(new SqlParameter("@IdChuyen", IdChuyen));
                ntxtSDTNguoiNhan.Text = Com.ExecuteScalar().ToString();


                //LayTenHang
                string TenHang = string.Format("exec InfoNhanHang_TenHang  @IdHangHoa , @IdChuyen"); //Gọi Proc
                Com = new SqlCommand(TenHang, Con);
                Com.Parameters.Add(new SqlParameter("@IdHangHoa", IdHangHoa));
                Com.Parameters.Add(new SqlParameter("@IdChuyen", IdChuyen));
                txtTenHang.Text = Com.ExecuteScalar().ToString();

                //LayTrongLuong
                string trongluong = string.Format("exec InfoNhanHang_TrongLuong  @IdHangHoa , @IdChuyen"); //Gọi Proc
                Com = new SqlCommand(trongluong, Con);
                Com.Parameters.Add(new SqlParameter("@IdHangHoa", IdHangHoa));
                Com.Parameters.Add(new SqlParameter("@IdChuyen", IdChuyen));
                ntxtTrongLuong.Text = Com.ExecuteScalar().ToString();

                //LayKichThuoc
                string KichThuoc = string.Format("exec InfoNhanHang_KichThuoc  @IdHangHoa , @IdChuyen"); //Gọi Proc
                Com = new SqlCommand(KichThuoc, Con);
                Com.Parameters.Add(new SqlParameter("@IdHangHoa", IdHangHoa));
                Com.Parameters.Add(new SqlParameter("@IdChuyen", IdChuyen));
                txtKichThuoc.Text = Com.ExecuteScalar().ToString();

                //LayLoTrinh
                string LoTrinh = string.Format("exec InfoNhanHang_LoTrinh   @IdChuyen"); //Gọi Proc
                Com = new SqlCommand(LoTrinh, Con);
                Com.Parameters.Add(new SqlParameter("@IdChuyen", IdChuyen));
                CBChuyenTu_Den.Text = Com.ExecuteScalar().ToString();


                //LayDiemGui
                string DiemGui = string.Format("exec  InfoNhanHang_DiemGui   @IdChuyen"); //Gọi Proc
                Com = new SqlCommand(DiemGui, Con);
                Com.Parameters.Add(new SqlParameter("@IdChuyen", IdChuyen));
                txtChoGui.Text = Com.ExecuteScalar().ToString();

                //LayDiemNhan
                string DiemNhan = string.Format("exec InfoNhanHang_DiemNhan   @IdChuyen"); //Gọi Proc
                Com = new SqlCommand(DiemNhan, Con);
                Com.Parameters.Add(new SqlParameter("@IdChuyen", IdChuyen));
                txtChoNhan.Text = Com.ExecuteScalar().ToString();

                //LayNgayChay
                string NgayChay = string.Format("exec InfoNhanHang_NgayChay   @IdChuyen"); //Gọi Proc
                Com = new SqlCommand(NgayChay, Con);
                Com.Parameters.Add(new SqlParameter("@IdChuyen", IdChuyen));
                txtNgayDi.Text = Com.ExecuteScalar().ToString();

                //LayGioDi
                string GioDi = string.Format("exec InfoNhanHang_Gio   @IdChuyen "); //Gọi Proc
                Com = new SqlCommand(GioDi, Con);
                Com.Parameters.Add(new SqlParameter("@IdChuyen", IdChuyen));
                txtGioDi.Text = Com.ExecuteScalar().ToString();

                Con.Close();
            }
            catch (Exception EX)
            {
                MetroFramework.MetroMessageBox.Show(this, EX.Message);
            }
        }

        private void frmChiTietGuiHang_Load(object sender, EventArgs e)
        {
            ShowInfoKhachHang();
            lblMaVe.Text = IdHangHoa_FormMain + " - " + IdChuyen_FormMain;
        }
    }
}
