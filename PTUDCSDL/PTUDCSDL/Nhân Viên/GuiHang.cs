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
    public partial class GuiHang : MetroFramework.Forms.MetroForm
    {
        public GuiHang()
        {
            InitializeComponent();
            ControlBox = false;
        }


        string IdNguoiDung_FormMain;
        public void GetPassData_FormMain(string str)
        {
            IdNguoiDung_FormMain = str;
        }

        private void Visible_Sao()
        {
            Sao1.Visible = false;
            Sao4.Visible = false;
            Sao2.Visible = false;
            Sao3.Visible = false;
            Sao5.Visible = false;
            Sao6.Visible = false;
            Sao7.Visible = false;
            Sao8.Visible = false;
            Sao9.Visible = false;
            Sao10.Visible = false;
        }

        private bool Compelete()
        {
            if (txtTenNguoiGui.Text == "")
            {
                Sao1.Visible = true;
                return false;
            }
            if (ntxtCMNDNguoiGui.Text == "")
            {
                Sao2.Visible = true;
                return false;
            }
            if (ntxtSDTNguoiGui.Text == "")
            {
                Sao3.Visible = true;
                return false;
            }
            if (txtTenNguoiNhan.Text == "")
            {
                Sao4.Visible = true;
                return false;
            }
            if (ntxtCMNDNguoiNhan.Text == "")
            {
                Sao5.Visible = true;
                return false;
            }
            if (ntxtSDTNguoiNhan.Text == "")
            {
                Sao6.Visible = true;
                return false;
            }
            if (txtTenHang.Text == "")
            {
                Sao7.Visible = true;
                return false;
            }
            if (ntxtTrongLuong.Text == "")
            {
                Sao8.Visible = true;
                return false;
            }
            if (txtKichThuoc.Text == "")
            {
                Sao9.Visible = true;
                return false;
            }
            if (TextBoxGiaTien.Text == "")
            {
                Sao10.Visible = true;
                return false;
            }
                return true;
        }

        private void KiGui()
        {
            try
            {

            SqlConnection Con = KetNoiCSDL.KetNoiSQL();
            Con.Open();


            Class.KiGuiHangHoa HangHoa = new Class.KiGuiHangHoa();

            //idChuyen
            int index = lblMaVe.Text.IndexOf(" ");

            HangHoa.IdChuyen = lblMaVe.Text.Substring(index + 3);

            //Ten 
            HangHoa.TenNguoiGui = txtTenNguoiGui.Text.ToString();
            HangHoa.TenNguoiNhan = txtTenNguoiNhan.Text.ToString();

            //CMND
            HangHoa.CMNDNguoiGui = ntxtCMNDNguoiGui.Text.ToString();
            HangHoa.CMNDNguoiNhan = ntxtCMNDNguoiNhan.Text.ToString();

            //SDT

            HangHoa.SDTNguoiGui = ntxtSDTNguoiGui.Text.ToString();
            HangHoa.SDTNguoiNhan = ntxtSDTNguoiNhan.Text.ToString();

            //Hàng Hoá
            HangHoa.TenMonHang = txtTenHang.Text.ToString();
            HangHoa.KichThuoc = txtKichThuoc.Text.ToString();
            HangHoa.TrongLuong = ntxtTrongLuong.Text.ToString();

            //Tien


            string TempTien = TextBoxGiaTien.Text;
            int ixdexTien = TextBoxGiaTien.Text.IndexOf(".");
            if (ixdexTien == -1)
            {
                HangHoa.ChiPhiGui = Convert.ToInt32(TempTien);
            }
            else
            {
                TempTien = TempTien.Replace(".", "");
                HangHoa.ChiPhiGui = Convert.ToInt32(TempTien);
            }

            string KiGui = string.Format("exec KiGui @TenNguoiGui, @SDTNguoiGui, @CMNDNguoiGui, @TenNguoiNhan, @SDTNguoiNhan, @CMNDNguoiNhan, @TenMonHang, @TrongLuong, @KichThuoc, @ChiPhiGui, @IdChuyen");
           
            string InsertNhatKi = string.Format("exec InsertNhatKi @TenNguoiGui,@SDTNguoiGui,@CMNDNguoiGui,@LoaiGiaoDichGui");
            DataTable user = new DataTable();

            SqlCommand Com = new SqlCommand(KiGui, Con);
            SqlCommand ComUuDai = new SqlCommand(InsertNhatKi, Con);

            //KiGui
            Com.Parameters.Add(new SqlParameter("@TenNguoiGui", HangHoa.TenNguoiGui));
            Com.Parameters.Add(new SqlParameter("@SDTNguoiGui", HangHoa.SDTNguoiGui));
            Com.Parameters.Add(new SqlParameter("@CMNDNguoiGui", HangHoa.CMNDNguoiGui));
            Com.Parameters.Add(new SqlParameter("@TenNguoiNhan", HangHoa.TenNguoiNhan));
            Com.Parameters.Add(new SqlParameter("@SDTNguoiNhan", HangHoa.SDTNguoiNhan));
            Com.Parameters.Add(new SqlParameter("@CMNDNguoiNhan", HangHoa.CMNDNguoiNhan));
            Com.Parameters.Add(new SqlParameter("@TenMonHang", HangHoa.TenMonHang));
            Com.Parameters.Add(new SqlParameter("@TrongLuong", HangHoa.TrongLuong));
            Com.Parameters.Add(new SqlParameter("@KichThuoc", HangHoa.KichThuoc));
            Com.Parameters.Add(new SqlParameter("@ChiPhiGui", HangHoa.ChiPhiGui));
            Com.Parameters.Add(new SqlParameter("@IdChuyen", HangHoa.IdChuyen));



            //InsertNhatKiKhachHangGui
            ComUuDai.Parameters.Add(new SqlParameter("@TenNguoiGui", HangHoa.TenNguoiGui));
            ComUuDai.Parameters.Add(new SqlParameter("@SDTNguoiGui", HangHoa.SDTNguoiGui));
            ComUuDai.Parameters.Add(new SqlParameter("@CMNDNguoiGui", HangHoa.CMNDNguoiGui));
            ComUuDai.Parameters.Add(new SqlParameter("@LoaiGiaoDichGui", "Gửi Hàng" + " - " + HangHoa.TenMonHang));
           


            SqlDataAdapter adapt = new SqlDataAdapter(Com);
            SqlDataAdapter adapt1 = new SqlDataAdapter(ComUuDai);
            adapt.Fill(user);
            adapt1.Fill(user);
            Con.Close();
            MetroFramework.MetroMessageBox.Show(this, string.Format("Đã Đặt Hàng :{0}: Cho Khách Hàng: {1}!", HangHoa.TenMonHang, HangHoa.TenNguoiGui));
           

            }
            catch (Exception EX)
            {
                MetroFramework.MetroMessageBox.Show(this,EX.Message);
            }
        }


       


    private void btnGui_Click(object sender, EventArgs e)
        {
            //Get idChuyen
            int index = lblMaVe.Text.IndexOf(" ");
            string IdChuyen = lblMaVe.Text.Substring(index + 3);


            Visible_Sao();
            if (Compelete() == false)
            {

            }
            else
            {
                if (MetroFramework.MetroMessageBox.Show(this, "Chắc Chắn Hay Không", "Bạn Muốn Đặt Vé Gửi Hàng ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    KiGui();
                    GuiHang_Load(sender, e);
                }
            }
        }

        private void GetLoTrinhVe()
        {
            try
            {

        
            SqlConnection Con = KetNoiCSDL.KetNoiSQL();
            Con.Open();

            String Soure = String.Format("exec GetLoTrinhVe");
            DataTable user = new DataTable();
            SqlCommand cmd = new SqlCommand(Soure, Con);
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataSet ChuyenDi = new DataSet();
            adapt.Fill(ChuyenDi);
            CBChuyenTu_Den.DataSource = ChuyenDi.Tables[0]; //Đổ dữ liệu vào Combobox 
            CBChuyenTu_Den.DisplayMember = "LoTrinh";
            CBChuyenTu_Den.ValueMember = "LoTrinh";
            Con.Close();
            }
            catch (Exception EX)
            {
                MetroFramework.MetroMessageBox.Show(this, EX.Message);
            }
        }


        private void GetInfoVe()
        {
            int index = CBChuyenTu_Den.Text.LastIndexOf("-");
            string DiemDen = CBChuyenTu_Den.Text.Substring(index + 2);
            string DiemDi = CBChuyenTu_Den.Text.Substring(0, index - 1);

            try
            {


                SqlConnection Con = KetNoiCSDL.KetNoiSQL();
                Con.Open();
                txtChoGui.Text = DiemDi;
                txtChoNhan.Text = DiemDen;

                //LayNgayDi
                string NgayDi = string.Format("exec GetInfoVe_NgayDi  @DiemXuatPhat ,@DiemDich"); //Gọi Proc
                SqlCommand Com = new SqlCommand(NgayDi, Con);
                Com.Parameters.Add(new SqlParameter("@DiemXuatPhat", DiemDi));
                Com.Parameters.Add(new SqlParameter("@DiemDich", DiemDen));
                txtNgayDi.Text = Com.ExecuteScalar().ToString();
                //int i = txtNgayDi.Text.IndexOf(" ");
                //if (i != -1)
                //{
                //    txtNgayDi.Text = txtNgayDi.Text.Substring(0, i);
                //}

                //LayGioDi
                string GioDi = string.Format("exec GetInfoVe_GioDi  @DiemXuatPhat,@DiemDich"); //Gọi Proc
                Com = new SqlCommand(GioDi, Con);
                Com.Parameters.Add(new SqlParameter("@DiemXuatPhat", DiemDi));
                Com.Parameters.Add(new SqlParameter("@DiemDich", DiemDen));
                txtGioDi.Text = Com.ExecuteScalar().ToString();

                //LấyidHàng
                string Idhang = string.Format("exec GetInfoVe_IdHang"); //Gọi Proc
                Com = new SqlCommand(Idhang, Con);
                Com.Parameters.Add(new SqlParameter("@DiemXuatPhat", DiemDi));
                Com.Parameters.Add(new SqlParameter("@DiemDich", DiemDen));
                lblMaVe.Text = Com.ExecuteScalar().ToString() + " - ";

                //LayIdChuyen
                string IDChuyen = string.Format("exec GetInfoVe_IdChuyen @DiemXuatPhat, @DiemDich"); //Gọi Proc
                Com = new SqlCommand(IDChuyen, Con);
                Com.Parameters.Add(new SqlParameter("@DiemXuatPhat", DiemDi));
                Com.Parameters.Add(new SqlParameter("@DiemDich", DiemDen));
                lblMaVe.Text += Com.ExecuteScalar().ToString();

                Con.Close();
            }
            catch (Exception EX)
            {
                MetroFramework.MetroMessageBox.Show(this, EX.Message);
            }
        }

        private void CBChuyenTu_Den_SelectedValueChanged(object sender, EventArgs e)
        {
            GetInfoVe(); //-----><-------
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Chắc Chắn Hay Không", "Bạn Muốn Thoát ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void GuiHang_ClientSizeChanged(object sender, EventArgs e)
        {

            if (this.Width != 884 || this.Height != 593)
            {
                this.ClientSize = new Size(884, 593);
            }
        }

        private void GetTenNhanVien()
        {
            try
            {


                SqlConnection Con = KetNoiCSDL.KetNoiSQL();
                Con.Open();

                //TenNhanVien
                string TenNhanVien = string.Format("exec GetTenNhanVien  @IdNguoiDung "); //Gọi Proc
                SqlCommand Com = new SqlCommand(TenNhanVien, Con);
                Com.Parameters.Add(new SqlParameter("@IdNguoiDung", IdNguoiDung_FormMain));
                lblTenBanVe.Text = Com.ExecuteScalar().ToString();

                Con.Close();
            }
            catch (Exception EX)
            {
                MetroFramework.MetroMessageBox.Show(this, EX.Message);
            }


        }
        private void GuiHang_Load(object sender, EventArgs e)
        {
            GetLoTrinhVe(); //-----><-------
            GetInfoVe(); //-----><-------

            //reset form
            txtTenNguoiNhan.Clear();
            txtTenNguoiGui.Clear();
            ntxtCMNDNguoiGui.Clear();
            ntxtCMNDNguoiNhan.Clear();
            ntxtSDTNguoiGui.Clear();
            ntxtSDTNguoiNhan.Clear();
            txtTenHang.Clear();
            ntxtTrongLuong.Clear();
            txtKichThuoc.Clear();
            TextBoxGiaTien.Clear();
            //  lblTenBanVe.Text 
            GetTenNhanVien();
            lblNgayThangNam.Text = "Nhân Viên Bán Vé    " + "Ngày " + DateTime.Now.Day.ToString() + " Tháng " + DateTime.Now.Month.ToString() + " Năm " + DateTime.Now.Year.ToString();

        }

    }
}
