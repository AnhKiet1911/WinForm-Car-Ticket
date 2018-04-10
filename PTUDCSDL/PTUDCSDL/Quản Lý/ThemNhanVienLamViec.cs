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
    public partial class ThemNhanVienLamViec : MetroFramework.Forms.MetroForm
    {
        public ThemNhanVienLamViec()
        {
            InitializeComponent();
            ControlBox = false;
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
            Temp.NgayLamViec = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
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

        private int GetMaNV()
        {

            try
            {
                SqlConnection Con = KetNoiCSDL.KetNoiSQL();
                Con.Open();

              
                string MNV = string.Format("select MAX(nv.MaNhanVien) from NhanVien nv"); //Gọi Proc
                SqlCommand Com = new SqlCommand(MNV, Con);
                if (Com.ExecuteScalar()== null)
                {
                    return 0;
                }
                else
                {
                    int a = Convert.ToInt32(Com.ExecuteScalar());

                    return a;
                }
              
            }
            catch (Exception )
            {
                return 0;
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

        private void ThemNhanVien(Class.ThemNV NV)
        {
            try
            {
                SqlConnection Con = KetNoiCSDL.KetNoiSQL();
                Con.Open();
                string ThemNV = string.Format("insert into NhanVien(MaNhanVien, TenNhanVien, SDT, NgaySinh, GioiTinh, DiaChi, NgayVaoLamViec,KinhNghiem,SoGioDaChay, LoaiNV, MaCV)  values(@MaNV, @Ten, @SDT, @NgaySinh, @GioiTinh, @DiaChi, @NgayLam, @KinhNghiem, @SoGioLam, @LoaiNV, @MaCV)");
                string InsertCVNV = string.Format("insert into PhanCongViec(MaCongViec) values(@MaCV)");
                string InsertDanhGia = string.Format("insert into DanhGiaNhanVien(MaNhanVien) values(@MaNhanVien)");
                DataTable user = new DataTable();

                SqlCommand Com = new SqlCommand(ThemNV, Con);
                SqlCommand ComCV = new SqlCommand(InsertCVNV, Con);
                SqlCommand ComDG = new SqlCommand(InsertDanhGia, Con);
                DateTime NS;
                DateTime.TryParse(NV.NgaySinh, out NS);
                DateTime NL;
                DateTime.TryParse(NV.NgayLamViec, out NL);

                //ThemNV
                Com.Parameters.Add(new SqlParameter("@MaNV", NV.MaNhanVien));
                Com.Parameters.Add(new SqlParameter("@Ten", NV.TenNhanVien));
                Com.Parameters.Add(new SqlParameter("@SDT", NV.SDT));
                Com.Parameters.Add(new SqlParameter("@NgaySinh", NS));
                Com.Parameters.Add(new SqlParameter("@GioiTinh", NV.GioiTinh));
                Com.Parameters.Add(new SqlParameter("@DiaChi", NV.DiaChi));
                Com.Parameters.Add(new SqlParameter("@NgayLam", NL));
                Com.Parameters.Add(new SqlParameter("@KinhNghiem", NV.KinhNghiem));
                Com.Parameters.Add(new SqlParameter("@SoGioLam", NV.SoGioDaChay));
                Com.Parameters.Add(new SqlParameter("@LoaiNV", NV.LoaiNV));
                Com.Parameters.Add(new SqlParameter("@MaCV", NV.MaCV));

                //InsertCVNV
                ComCV.Parameters.Add(new SqlParameter("@MaCV", NV.MaCV));

                //InsertDGNV
                ComDG.Parameters.Add(new SqlParameter("@MaNhanVien", NV.MaNhanVien));

                SqlDataAdapter adapt1 = new SqlDataAdapter(ComCV);
                SqlDataAdapter adapt = new SqlDataAdapter(Com);
                SqlDataAdapter adapt2 = new SqlDataAdapter(ComDG);

                adapt1.Fill(user);
                adapt.Fill(user);
                adapt2.Fill(user);
               
                Con.Close();
                MetroFramework.MetroMessageBox.Show(this, string.Format("Đã Thêm Nhân Viên {0}!", NV.TenNhanVien), "Compelete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception EX)
            {
                MetroFramework.MetroMessageBox.Show(this, EX.Message);
            }
        }
        private void LoadInfo()
        {
            lblMaNhanVien.Text = (GetMaNV() + 1).ToString();
        }
        private void ThemNhanVienLamViec_Load(object sender, EventArgs e)
        {
            Lay_LoaiNhanVien();
            LoadInfo();
            //reset

            txtTen.Clear();

            txtSDT.Clear();
            txtNgaySinh.ResetText();
            rdNam.Checked = true;
            
            txtDiaChi.Clear();
            txtKinhNghiem.ResetText();
            txtSohChay.Clear();
            txtLoaiNhanVien.ResetText();
            

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Chắc Chắn Hay Không", "Bạn Muốn Thoát ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnDatVe_Click(object sender, EventArgs e)
        {
            Visible_Sao();
            if (Compelete() == false)
            {

            }
            else 
            {
                if (MetroFramework.MetroMessageBox.Show(this, "Chắc Chắn Hay Không", "Bạn Muốn Thêm Nhân Viên Làm Việc ", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                {
                    ThemNhanVien(LayDuLieuNhap());
                    ThemNhanVienLamViec_Load(sender, e);
                }
            }
        }
    }
}
