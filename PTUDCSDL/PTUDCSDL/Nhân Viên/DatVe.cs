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
    public partial class DatVe : MetroFramework.Forms.MetroForm
    {
        public DatVe()
        {
            InitializeComponent();
            ControlBox = false;
        }

        string IdNguoiDung_FormMain;

        public delegate void PassDataInPhieuDatVe(string str);

        public void GetPassData_FormMain(string str)
        {
            IdNguoiDung_FormMain = str;
        }

        private int GetChoNgoi()
        {
            //idChuyen
            int index = lblMaVe.Text.IndexOf(" ");
            string IdChuyen = lblMaVe.Text.Substring(index + 3);
            try
            {
                SqlConnection Con = KetNoiCSDL.KetNoiSQL();
                Con.Open();

                //Cho Ngồi
                string GheTrong = string.Format("exec GetChoNgoi @IdChuyenDi"); //Gọi Proc
                SqlCommand Com = new SqlCommand(GheTrong, Con);
                Com.Parameters.Add(new SqlParameter("@IdChuyenDi", IdChuyen));
                int a = Convert.ToInt32(Com.ExecuteScalar());

                return a;
            }
            catch (Exception EX)
            {
                MetroFramework.MetroMessageBox.Show(this, EX.Message);
            }
            return 0;

        }



        private void Visible_Sao()
        {
            Sao1.Visible = false; 
            Sao4.Visible = false;
            Sao2.Visible = false;
            Sao3.Visible = false;
            Sao5.Visible = false;
        }


        private bool Compelete()
        {
            if (txtTen.Text == "") 
            {
                Sao1.Visible = true;
                return false;
            }
            if (ntxtCMND.Text == "") 
            {
                Sao2.Visible = true;
                return false;
            }
            if (DynamicCBOXQueQuan.Text == "") 
            {
                Sao3.Visible = true;
                return false;
            }
            if (ntxtSDT.Text == "") 
            {
                Sao4.Visible = true;
                return false;
            }
            if (TextBoxGiaTien.Text == "") 
            {
                Sao5.Visible = true;
                return false;
            }

            return true;
        }

        private void btnDatVe_Click(object sender, EventArgs e)
        {
            //Get idChuyen
            int index = lblMaVe.Text.IndexOf(" ");
            string IdChuyen = lblMaVe.Text.Substring(index + 3);
            string LoTrinh = "";
            try
            {
                //LayLoTrinh
                SqlConnection Con = KetNoiCSDL.KetNoiSQL();
                Con.Open();

                LoTrinh = string.Format("exec LoTrinh @IdChuyen"); //Gọi Proc
                SqlCommand Com = new SqlCommand(LoTrinh, Con);
                Com.Parameters.Add(new SqlParameter("@IdChuyen", IdChuyen));
                LoTrinh = Com.ExecuteScalar().ToString();
                Con.Close();
            }
            catch (Exception EX)
            {
                MetroFramework.MetroMessageBox.Show(this, EX.Message);
            }

            Visible_Sao();
            if (Compelete() == false)
            {

            }
            else if (GetChoNgoi() < 1)
            {
                MetroFramework.MetroMessageBox.Show(this, string.Format("Chuyến: {0} :Không Còn Chổ Trống !", LoTrinh));
            }
            else
            {
                if (MetroFramework.MetroMessageBox.Show(this, "Chắc Chắn Hay Không", "Bạn Muốn Đặt Vé ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string Str = lblMaVe.Text.Substring(0, index) + "&" + TextBoxGiaTien.Text + "&" + IdNguoiDung_FormMain;
                    DatVeXe();
                    frmInPhieu In = new frmInPhieu();
                    PassDataInPhieuDatVe Share = new PassDataInPhieuDatVe(In.GetPassData_FormDatVe);
                    Share(Str);
                    this.Hide();
                    In.ShowDialog();
                    DatVe_Load(sender, e);
                    this.Show();
                }
            }

            
        }

        private void  GetLoTrinhVe()
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

                //LayNgayDi
                string NgayDi = string.Format("exec GetInfoVe_NgayDi @DiemXuatPhat , @DiemDich"); //Gọi Proc
                SqlCommand Com = new SqlCommand(NgayDi, Con);
                Com.Parameters.Add(new SqlParameter("@DiemXuatPhat", DiemDi));
                Com.Parameters.Add(new SqlParameter("@DiemDich", DiemDen));
                txtNgayDi.Text = Com.ExecuteScalar().ToString();
              
                //LayGioDi
                string GioDi = string.Format("exec GetInfoVe_GioDi @DiemXuatPhat ,@DiemDich"); //Gọi Proc
                Com = new SqlCommand(GioDi, Con);
                Com.Parameters.Add(new SqlParameter("@DiemXuatPhat", DiemDi));
                Com.Parameters.Add(new SqlParameter("@DiemDich", DiemDen));
                txtGioDi.Text = Com.ExecuteScalar().ToString();

                //LấyIdVe
                string IdVe = string.Format("exec GetInfoVe_ID"); //Gọi Proc
                Com = new SqlCommand(IdVe, Con);
                Com.Parameters.Add(new SqlParameter("@DiemXuatPhat", DiemDi));
                Com.Parameters.Add(new SqlParameter("@DiemDich", DiemDen));
                lblMaVe.Text = Com.ExecuteScalar().ToString() + " - ";

                //LayIdChuyen
                string IDChuyen = string.Format("exec GetInfoVe_IdChuyen @DiemXuatPhat , @DiemDich"); //Gọi Proc
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



        private void DatVeXe()
        {
            try
            {
                SqlConnection Con = KetNoiCSDL.KetNoiSQL();
                Con.Open();

                CDatVe VXe = new CDatVe();
                //idChuyen
                int index = lblMaVe.Text.IndexOf(" ");

                VXe.IdChuyen = lblMaVe.Text.Substring(index + 3);

                //Ten
                VXe.TenKhachHang = txtTen.Text;
                //CMND
                VXe.CMND = ntxtCMND.Text;
                //QueQuan
                VXe.QueQuan = DynamicCBOXQueQuan.Text;

                //NgaySinh

                VXe.NgaySinh = dateTimePicker1.Value.ToString();
                int i = VXe.NgaySinh.IndexOf(" ");
                if (i != -1)
                {
                    VXe.NgaySinh = VXe.NgaySinh.Substring(0, i);
                }

                //SDT
                VXe.SDT = ntxtSDT.Text;
                //Tien
                string TempTien = TextBoxGiaTien.Text;
                int ixdexTien = TextBoxGiaTien.Text.IndexOf(".");
                if (ixdexTien==-1)
                {
                    VXe.TienVe = Convert.ToInt32(TempTien);
                }
                else
                {
                    TempTien =  TempTien.Replace(".", "");
                    VXe.TienVe = Convert.ToInt32(TempTien);
                }
             
              

                //Thoi Gian Mua Ve
                VXe.ThoiGianMuaVe = "Ngày " + DateTime.Now.Day.ToString() + " Tháng " + DateTime.Now.Month.ToString() + " Năm " + DateTime.Now.Year.ToString();




                string ThemVe = string.Format("exec ThemVe @IdChuyen, @TenHanhKhach, @NgaySinh, @SDTHanhKhach, @CMND, @QueQuan, @GiaTien, @ThoiGianMua");
                string UpdateChoNgoi = string.Format("exec UpdateChoNgoi @SoGheTrong, @IdChuyen");
                string InsertUuDaiKhachHang = string.Format("exec InsertUuDaiKhachHang @MaVeUuDai,@TenHangKhachUuDai,@SDTUuDai,@CMNDUuDai,@LoaiGiaoDich");
                DataTable user = new DataTable();

                SqlCommand Com = new SqlCommand(ThemVe, Con);
                SqlCommand ComUpdate = new SqlCommand(UpdateChoNgoi, Con);
                SqlCommand ComUuDai = new SqlCommand(InsertUuDaiKhachHang, Con);

                //ThemVe
                Com.Parameters.Add(new SqlParameter("@IdChuyen", VXe.IdChuyen));
                Com.Parameters.Add(new SqlParameter("@TenHanhKhach", VXe.TenKhachHang));
                Com.Parameters.Add(new SqlParameter("@NgaySinh", VXe.NgaySinh));
                Com.Parameters.Add(new SqlParameter("@SDTHanhKhach", VXe.SDT));
                Com.Parameters.Add(new SqlParameter("@CMND", VXe.CMND));
                Com.Parameters.Add(new SqlParameter("@QueQuan", VXe.QueQuan));
                Com.Parameters.Add(new SqlParameter("@GiaTien", VXe.TienVe));
                Com.Parameters.Add(new SqlParameter("@ThoiGianMua", VXe.ThoiGianMuaVe));

                //UpdateChoNgoi
                ComUpdate.Parameters.Add(new SqlParameter("@SoGheTrong", GetChoNgoi() - 1));
                ComUpdate.Parameters.Add(new SqlParameter("@IdChuyen", VXe.IdChuyen));

                //InsertUuDaiKhachHang
                ComUuDai.Parameters.Add(new SqlParameter("@MaVeUuDai", lblMaVe.Text));
                ComUuDai.Parameters.Add(new SqlParameter("@TenHangKhachUuDai", VXe.TenKhachHang));
                ComUuDai.Parameters.Add(new SqlParameter("@SDTUuDai", VXe.SDT));
                ComUuDai.Parameters.Add(new SqlParameter("@CMNDUuDai", VXe.CMND));
                ComUuDai.Parameters.Add(new SqlParameter("@LoaiGiaoDich", this.Text));


                SqlDataAdapter adapt = new SqlDataAdapter(Com);
                SqlDataAdapter adapt1 = new SqlDataAdapter(ComUpdate);
                SqlDataAdapter adapt2 = new SqlDataAdapter(ComUuDai);
                adapt.Fill(user);
                adapt1.Fill(user);
                adapt2.Fill(user);
                Con.Close();
                MetroFramework.MetroMessageBox.Show(this, string.Format("Đã Đặt Vé Cho Khách Hàng {0}!", VXe.TenKhachHang));
            }
            catch (Exception EX)
            {
                MetroFramework.MetroMessageBox.Show(this, EX.Message);
            }
        }

        private void DatVe_Load(object sender, EventArgs e)
        {
            GetLoTrinhVe(); //-----><-------
            GetInfoVe(); //-----><-------

            //reset form
            txtTen.Clear();
            ntxtCMND.Clear();
            DynamicCBOXQueQuan.ResetText();
            ntxtSDT.Clear();
            TextBoxGiaTien.Clear();
            
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


    }
}
