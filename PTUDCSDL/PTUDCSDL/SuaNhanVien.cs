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
    public partial class SuaNhanVien : MetroFramework.Forms.MetroForm
    {
        public SuaNhanVien()
        {
            InitializeComponent();
            ControlBox = false;
        }

        string MaNhanVien_FormMain;

        public void GetPassData_FormMain(string str)
        {
           MaNhanVien_FormMain = str;
        }

        private void Visible_Sao()
        {
            Sao1.Visible = false;
            Sao4.Visible = false;
            Sao2.Visible = false;
            Sao3.Visible = false;

        }

        private bool Compelete()
        {
            if (txtTen.Text == "")
            {
                Sao1.Visible = true;
                return false;
            }
            if (txtSDT.Text == "")
            {
                Sao2.Visible = true;
                return false;
            }
            if (txtDiaChi.Text == "")
            {
                Sao3.Visible = true;
                return false;
            }

            return true;
        }

        private void LayThongTin(string MaNV)
        {
            try
            {
                SqlConnection Con = KetNoiCSDL.KetNoiSQL();
                Con.Open();

                //Lấy Tên
                string Ten = string.Format("select nv.TenNhanVien from NhanVien nv where nv.MaNhanVien=@MaNV"); //Gọi Proc
                SqlCommand Com = new SqlCommand(Ten, Con);
                Com.Parameters.Add(new SqlParameter("@MaNV", MaNV));     
                txtTen.Text = Com.ExecuteScalar().ToString();

                //LayKinhNghiem
                string KinhNghiem = string.Format("select nv.KinhNghiem from NhanVien nv where nv.MaNhanVien=@MaNV"); //Gọi Proc
                Com = new SqlCommand(KinhNghiem, Con);
                Com.Parameters.Add(new SqlParameter("@MaNV", MaNV));
                txtKinhNghiem.Text = Com.ExecuteScalar().ToString();

                //LayNgaySinh
                string NgaySinh = string.Format("select nv.NgaySinh from NhanVien nv where nv.MaNhanVien=@MaNV"); //Gọi Proc
                Com = new SqlCommand(NgaySinh, Con);
                Com.Parameters.Add(new SqlParameter("@MaNV", MaNV));
                txtNgaySinh.Value = Convert.ToDateTime(Com.ExecuteScalar());
                

                //LayGioiTinh
                string sex = string.Format("select nv.GioiTinh from NhanVien nv where nv.MaNhanVien=@MaNV"); //Gọi Proc
                Com = new SqlCommand(sex, Con);
                Com.Parameters.Add(new SqlParameter("@MaNV", MaNV));
                if (Com.ExecuteScalar().ToString() == "Nam") 
                {
                    rdNam.Checked = true;
                }
                else
                {
                    rdNu.Checked = true;
                }

                //LaySDT
                string SDT = string.Format("select nv.SDT from NhanVien nv where nv.MaNhanVien=@MaNV"); //Gọi Proc
                Com = new SqlCommand(SDT, Con);
                Com.Parameters.Add(new SqlParameter("@MaNV", MaNV));
                txtSDT.Text = Com.ExecuteScalar().ToString();

                //LayDiaChi
                string DiaChi = string.Format("select nv.DiaChi from NhanVien nv where nv.MaNhanVien=@MaNV"); //Gọi Proc
                Com = new SqlCommand(DiaChi, Con);
                Com.Parameters.Add(new SqlParameter("@MaNV", MaNV));
                txtDiaChi.Text = Com.ExecuteScalar().ToString();


                //LayhrsChay
                string h_Chay = string.Format("select nv.SoGioDaChay from NhanVien nv where nv.MaNhanVien=@MaNV"); //Gọi Proc
                Com = new SqlCommand(h_Chay, Con);
                Com.Parameters.Add(new SqlParameter("@MaNV", MaNV));
                txtSohChay.Text = Com.ExecuteScalar().ToString();

                //LayLoaiNV
                string LoaiNV = string.Format("select nv.LoaiNV from NhanVien nv where nv.MaNhanVien=@MaNV"); //Gọi Proc
                Com = new SqlCommand(LoaiNV, Con);
                Com.Parameters.Add(new SqlParameter("@MaNV", MaNV));
                txtLoaiNhanVien.Text = TenLoaiNV(Com.ExecuteScalar().ToString());
                Con.Close();


            }
            catch (Exception EX)
            {
                MetroFramework.MetroMessageBox.Show(this, EX.Message);
            }


        }

        private string TenLoaiNV(string LoaiNV)
        {
            string temp = "";
            try
            {
                SqlConnection Con = KetNoiCSDL.KetNoiSQL();
                Con.Open();

                //Lấy Tên
                string Ten = string.Format("select lnv.TenLoaiNV from LoaiNhanVien lnv where lnv.IdLoaiNV=@LoaiNV"); //Gọi Proc
                SqlCommand Com = new SqlCommand(Ten, Con);
                Com.Parameters.Add(new SqlParameter("@LoaiNV", LoaiNV));
                temp = Com.ExecuteScalar().ToString();

                Con.Close();
            }
            catch (Exception EX)
            {
                MetroFramework.MetroMessageBox.Show(this, EX.Message);
            }
            return temp;

        }

        private Class.ThemNV LayDuLieuNhap()
        {
            Class.ThemNV Temp = new Class.ThemNV();
            Temp.TenNhanVien = txtTen.Text;
            Temp.MaNhanVien = Convert.ToInt32(lblMaNhanVien.Text);
            Temp.SDT = txtSDT.Text;
            Temp.NgaySinh = txtNgaySinh.Value.ToShortDateString();
            if (rdNam.Checked == true)
            {
                Temp.GioiTinh = "Nam";
            }
            else
            {
                Temp.GioiTinh = "Nữ";
            }
            Temp.DiaChi = txtDiaChi.Text;
            Temp.KinhNghiem = txtKinhNghiem.Text;
            Temp.SoGioDaChay = txtSohChay.Text;
            Temp.LoaiNV = txtLoaiNhanVien.SelectedValue.ToString();
            Temp.MaCV = lblMaNhanVien.Text;

            return Temp;
        }
        private void Lay_LoaiNhanVien()
        {
            try
            {
                SqlConnection Con = KetNoiCSDL.KetNoiSQL();
                Con.Open();

                String Soure = String.Format("select * from LoaiNhanVien ");
                DataTable user = new DataTable();
                SqlCommand cmd = new SqlCommand(Soure, Con);
                SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                DataSet LNV = new DataSet();
                adapt.Fill(LNV);
                txtLoaiNhanVien.DataSource = LNV.Tables[0]; //Đổ dữ liệu vào Combobox 
                txtLoaiNhanVien.DisplayMember = "TenLoaiNV";
                txtLoaiNhanVien.ValueMember = "IdLoaiNV";
                Con.Close();
            }
            catch (Exception EX)
            {
                MetroFramework.MetroMessageBox.Show(this, EX.Message);
            }
        }
        private void txtLoaiNhanVien_SelectedValueChanged(object sender, EventArgs e)
        {

            if (txtLoaiNhanVien.SelectedValue.ToString() == "1" || txtLoaiNhanVien.SelectedValue.ToString() == "2")
            {
                txtSohChay.Visible = true;
                lbhhrs.Visible = true;
                lblShChay.Visible = true;
            }
            else
            {
                txtSohChay.Visible = false;
                lbhhrs.Visible = false;
                lblShChay.Visible = false;
                txtSohChay.Clear();
            }
        }

        private void SuaNhanVien_Load(object sender, EventArgs e)
        {
            Lay_LoaiNhanVien();
            LayThongTin(MaNhanVien_FormMain);

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Chắc Chắn Hay Không", "Bạn Muốn Thoát ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void EditNhanVien(Class.ThemNV NV)
        {
            try
            {
                SqlConnection Con = KetNoiCSDL.KetNoiSQL();
                Con.Open();
                string ThemNV = string.Format("update NhanVien set TenNhanVien= @Ten,SDT = @SDT,NgaySinh= @NgaySinh,GioiTinh=@GioiTinh,DiaChi=@DiaChi,KinhNghiem=@KinhNghiem,SoGioDaChay=@SoGioLam,LoaiNV = @LoaiNV where MaNhanVien=@MaNhanVien");
              
                DataTable user = new DataTable();

                SqlCommand Com = new SqlCommand(ThemNV, Con);
              
                DateTime NS;
                DateTime.TryParse(NV.NgaySinh, out NS);
               

                //ThemNV
                Com.Parameters.Add(new SqlParameter("@Ten", NV.TenNhanVien));
                Com.Parameters.Add(new SqlParameter("@SDT", NV.SDT));
                Com.Parameters.Add(new SqlParameter("@NgaySinh", NS));
                Com.Parameters.Add(new SqlParameter("@GioiTinh", NV.GioiTinh));
                Com.Parameters.Add(new SqlParameter("@DiaChi", NV.DiaChi));
                Com.Parameters.Add(new SqlParameter("@KinhNghiem", NV.KinhNghiem));
                Com.Parameters.Add(new SqlParameter("@SoGioLam", NV.SoGioDaChay));
                Com.Parameters.Add(new SqlParameter("@LoaiNV", NV.LoaiNV));
                Com.Parameters.Add(new SqlParameter("@MaNhanVien", MaNhanVien_FormMain));

                SqlDataAdapter adapt = new SqlDataAdapter(Com);

               
                adapt.Fill(user);

                Con.Close();
                MetroFramework.MetroMessageBox.Show(this, string.Format("Đã Edit Nhân Viên {0}!", NV.TenNhanVien),"Compelete",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
            }
            catch (Exception EX)
            {
                MetroFramework.MetroMessageBox.Show(this, EX.Message);
            }
        }
        private void btnCaapNhat_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Chắc Chắn Hay Không", "Bạn Muốn Cập Nhật ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                EditNhanVien(LayDuLieuNhap());
                this.Close();
            }
        }
    }
}
