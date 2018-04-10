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
    public partial class NhanHang : MetroFramework.Forms.MetroForm
    {
        public NhanHang()
        {
            InitializeComponent();
            ControlBox = false;
        }
        string IdHangCanDoi;
        string IdChuyenCanDoi;
        
        private int KiemTraTonTai(string MaVe)
        {
            int index = txtKiemTra.Text.IndexOf(" "); //Định Dạng String MaVe Là IDVe - IdChuyen (Exam '1 - CX0001')
            if (index == -1)
            {
                return -1;
            }

            if (index + 3 >= txtKiemTra.Text.Length) //ràng buộc IdChuyen Phải Tồn Tại
            {
                return -1;
            }

            string IdHangHoa = txtKiemTra.Text.Substring(0, index);
            int IdTemp = 0;
            if (!int.TryParse(IdHangHoa, out IdTemp)) //Đảm bảo ID vé Phải Là Số If not number error
            {
                return -1;
            }
            string IdChuyen = txtKiemTra.Text.Substring(index + 3);
            IdChuyenCanDoi = txtKiemTra.Text.Substring(index + 3);
            IdHangCanDoi = txtKiemTra.Text.Substring(0, index);
            try
            {
                SqlConnection Con = KetNoiCSDL.KetNoiSQL();
                Con.Open();
                string Dem = string.Format("exec KiemTraTonTai_Hang  @IdHangHoa ,@IdChuyen"); //Gọi Proc
                SqlCommand Com = new SqlCommand(Dem, Con);
                Com.Parameters.Add(new SqlParameter("@IdHangHoa", IdHangHoa));
                Com.Parameters.Add(new SqlParameter("@IdChuyen", IdChuyen));
                int check = Convert.ToInt32(Com.ExecuteScalar());

                Con.Close();

                return check;
            }
            catch (Exception EX)
            {
                MetroFramework.MetroMessageBox.Show(this, EX.Message);
            }
            return 0;
        }


        private void ShowInfoKhachHang(string MaVe)
        {
            int index = MaVe.IndexOf(" ");
            string IdHangHoa = MaVe.Substring(0, index);
            string IdChuyen = MaVe.Substring(index + 3);
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



        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtKiemTra.Text == "")
            {
                MetroFramework.MetroMessageBox.Show(this, "Chưa Nhập Mã Vé");
            }
            else
            {
                if (KiemTraTonTai(txtKiemTra.Text) == 1)
                {

                    lblMaVe.Text = txtKiemTra.Text;
                    metroPanel1.Visible = true;
                    btnNhanHang.Visible = true;


                    //
                    ShowInfoKhachHang(txtKiemTra.Text);

                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, "Tấm Vé Này Không Tồn Tại");
                }
            }
        }

        private void txtKiemTra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTimKiem_Click(sender, e);
            }
        }

        private void btnNhanHang_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Chắc Chắn Hay Không", "Bạn Có Chắc Huỷ Vé Này", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                Class.KiGuiHangHoa HangHoa = new Class.KiGuiHangHoa();


              

                //Ten 
               
                HangHoa.TenNguoiNhan = txtTenNguoiNhan.Text.ToString();

                //CMND
                HangHoa.CMNDNguoiNhan = ntxtCMNDNguoiNhan.Text.ToString();

                //SDT

                HangHoa.SDTNguoiNhan = ntxtSDTNguoiNhan.Text.ToString();

                //Hàng Hoá
                HangHoa.TenMonHang = txtTenHang.Text.ToString();
               

                string IdHangHoa = IdHangCanDoi;
                string IdChuyen = IdChuyenCanDoi;

                try
                {
                    SqlConnection Con = KetNoiCSDL.KetNoiSQL();
                    Con.Open();
                    DataTable user = new DataTable();
                    string NhanHang = string.Format("exec  NhanHang   @IdChuyen ,@IdHangHoa");
                    string InsertNikki = string.Format("exec InsertNikki @TenNguoiNhan,@SDTNguoiNhan,@CMNDNguoiNhan,@LoaiGiaoDichNhan");

                   //Insert NhatKyNguoiDung
                    SqlCommand ComUuDai = new SqlCommand(InsertNikki, Con);
                    //dat hang
                    SqlCommand Com = new SqlCommand(NhanHang, Con);

                    Com.Parameters.Add(new SqlParameter("@IdChuyen", IdChuyen));
                    Com.Parameters.Add(new SqlParameter("@IdHangHoa", IdHangHoa));


                    //InsertUuDaiKhachHang

                    //InsertNhatKiKhachHangNhan
                    ComUuDai.Parameters.Add(new SqlParameter("@TenNguoiNhan", HangHoa.TenNguoiNhan));
                    ComUuDai.Parameters.Add(new SqlParameter("@SDTNguoiNhan", HangHoa.SDTNguoiNhan));
                    ComUuDai.Parameters.Add(new SqlParameter("@CMNDNguoiNhan", HangHoa.CMNDNguoiNhan));
                    ComUuDai.Parameters.Add(new SqlParameter("@LoaiGiaoDichNhan", "Nhận Hàng" + " - " + HangHoa.TenMonHang));

                    //
                    SqlDataAdapter adapt1 = new SqlDataAdapter(ComUuDai);
                    SqlDataAdapter adapt = new SqlDataAdapter(Com);
                    adapt.Fill(user);
                    adapt1.Fill(user);
                   
                    Con.Close();

                    MetroFramework.MetroMessageBox.Show(this, string.Format("Đã Trao Hàng  Mã Số:{0}", IdHangCanDoi + " - " + IdChuyenCanDoi));
                    NhanHang_Load(sender, e);
                    metroPanel1.Visible = false;
                    btnNhanHang.Visible = false;
                }
                catch (Exception EX)
                {
                    MetroFramework.MetroMessageBox.Show(this, EX.Message);
                }
            }
        }

        private void NhanHang_Load(object sender, EventArgs e)
        {
            //reset form
            txtChoGui.Clear();
            txtChoNhan.Clear();
            txtTenHang.Clear();
            txtTenNguoiGui.Clear();
            txtTenNguoiNhan.Clear();
            txtGioDi.Clear();
            txtKichThuoc.Clear();
            ntxtCMNDNguoiGui.Clear();
            ntxtCMNDNguoiNhan.Clear();
            ntxtSDTNguoiGui.Clear();
            ntxtSDTNguoiNhan.Clear();
            ntxtTrongLuong.Clear();
            CBChuyenTu_Den.Clear();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Chắc Chắn Hay Không", "Bạn Muốn Thoát ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
