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
    public partial class XepLichNhanVien : MetroFramework.Forms.MetroForm
    {
        public XepLichNhanVien()
        {
            InitializeComponent();
            ControlBox = false;
        }
        string MaNhanVien_FormMain;
        string LoaiNhanVien;
       

        public void GetPassData_FormMain(string str)
        {
            MaNhanVien_FormMain = str;
        }



        private void Begin()
        {
            if (LoaiNhanVien == "1" || LoaiNhanVien == "2")
            {
                try
                {
                    SqlConnection Con = KetNoiCSDL.KetNoiSQL();
                    Con.Open();

                    String Soure = String.Format("select p.LoTrinh from PhanCongViec p where p.MaCongViec=@MaCV");
                    SqlCommand Com = new SqlCommand(Soure, Con);
                    Com.Parameters.Add(new SqlParameter("@MaCV", MaNhanVien_FormMain));
                    if (Com.ExecuteScalar() == null)
                    {
                        lblLoTrinh.Text = "";
                    }
                    else
                    {
                        lblLoTrinh.Text = Com.ExecuteScalar().ToString();
                        lblLoTrinh.SelectedValue = Com.ExecuteScalar().ToString();
                    }
                    Con.Close();
                }
                catch (Exception EX)
                {
                    MetroFramework.MetroMessageBox.Show(this, EX.Message);
                }
            }
            else
            {
                try
                {
                    SqlConnection Con = KetNoiCSDL.KetNoiSQL();
                    Con.Open();

                    String Soure = String.Format("select p.CaTruc from PhanCongViec p where p.MaCongViec=@MaCV");
                    SqlCommand Com = new SqlCommand(Soure, Con);
                    Com.Parameters.Add(new SqlParameter("@MaCV", MaNhanVien_FormMain));
                    if (Com.ExecuteScalar() == null)
                    {
                        comboBox1.Text = "";
                    }
                    else
                    {
                        comboBox1.Text = Com.ExecuteScalar().ToString();
                        comboBox1.SelectedValue = Com.ExecuteScalar().ToString();
                    }
                    Con.Close();
                }
                catch (Exception EX)
                {
                    MetroFramework.MetroMessageBox.Show(this, EX.Message);
                }
            }
        }
        private void XepLichNhanVien_Load(object sender, EventArgs e)
        {
            btnThemNV.Select();

            GetLoTrinhVe();
            GetInfoVe();
            Begin();

            
           
            if (LoaiNhanVien == "1" || LoaiNhanVien == "2")
            {
                metroLabel8.Visible = false;
                comboBox1.Visible = false;
               

            }
            else
            {
                metroLabel7.Visible = false;
                metroLabel3.Visible = false;
                metroLabel2.Visible = false;
                lblLoTrinh.Visible = false;
                lblMaChuyen.Visible = false;
                lblNgayDi.Visible = false;
                this.Height = 174;
                metroPanel1.Location = new Point(208, 151);
               
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
                lblLoTrinh.DataSource = ChuyenDi.Tables[0]; //Đổ dữ liệu vào Combobox 
                lblLoTrinh.DisplayMember = "LoTrinh";
                lblLoTrinh.ValueMember = "LoTrinh";
                Con.Close();
            }
            catch (Exception EX)
            {
                MetroFramework.MetroMessageBox.Show(this, EX.Message);
            }
        }


        private void GetInfoVe()
        {
            try
            {
                SqlConnection Con = KetNoiCSDL.KetNoiSQL();
                Con.Open();
                SqlCommand Com;
                int index = lblLoTrinh.Text.LastIndexOf("-");
                if (index == -1)
                {
                    lblNgayDi.Text="";
                    lblMaChuyen.Text="";
                    lblLoTrinh.Text = "";


                }
                else
                {
                    string DiemDen = lblLoTrinh.Text.Substring(index + 2);
                    string DiemDi = lblLoTrinh.Text.Substring(0, index - 1);
                    //LayNgayDi
                    string NgayDi = string.Format("exec GetInfoVe_NgayDi @DiemXuatPhat , @DiemDich"); //Gọi Proc
                    Com = new SqlCommand(NgayDi, Con);
                    Com.Parameters.Add(new SqlParameter("@DiemXuatPhat", DiemDi));
                    Com.Parameters.Add(new SqlParameter("@DiemDich", DiemDen));
                    lblNgayDi.Text = Com.ExecuteScalar().ToString();



                    //LấyIdVe
                    string IdVe = string.Format("exec GetInfoVe_ID"); //Gọi Proc
                    Com = new SqlCommand(IdVe, Con);
                    lblMaChuyen.Text = Com.ExecuteScalar().ToString() + " - ";

                    string IDChuyen = string.Format("exec GetInfoVe_IdChuyen @DiemXuatPhat , @DiemDich"); //Gọi Proc
                    Com = new SqlCommand(IDChuyen, Con);
                    Com.Parameters.Add(new SqlParameter("@DiemXuatPhat", DiemDi));
                    Com.Parameters.Add(new SqlParameter("@DiemDich", DiemDen));
                    lblMaChuyen.Text += Com.ExecuteScalar().ToString();
                }

                //LayLoaiNV
                string LoaiNV = string.Format("select nv.LoaiNV from NhanVien nv where nv.MaNhanVien=@MaNV"); //Gọi Proc
                Com = new SqlCommand(LoaiNV, Con);
                Com.Parameters.Add(new SqlParameter("@MaNV", MaNhanVien_FormMain));
                LoaiNhanVien = Com.ExecuteScalar().ToString();
                lblLNV.Text = TenLoaiNV(Com.ExecuteScalar().ToString());


                //LayTenNV
                string namae = string.Format("select nv.TenNhanVien from NhanVien nv where nv.MaNhanVien=@MaNV"); //Gọi Proc
                Com = new SqlCommand(namae, Con);
                Com.Parameters.Add(new SqlParameter("@MaNV", MaNhanVien_FormMain));
                lblTenNhanVien.Text = Com.ExecuteScalar().ToString();
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
        private void lblLoTrinh_SelectedValueChanged(object sender, EventArgs e)
        {
            GetInfoVe();
           

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Chắc Chắn Hay Không", "Bạn Muốn Thoát ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }



        private void UpdateCongViec()
        {
            try
            {
                SqlConnection Con = KetNoiCSDL.KetNoiSQL();
                Con.Open();
                string ThemNV;
                if (LoaiNhanVien == "1" || LoaiNhanVien == "2")
                {
                      ThemNV = string.Format("update PhanCongViec set MaChuyenXe = @MaChuyenXe,NgayDi =@NgayDi,LoTrinh=@LoTrinh where MaCongViec=@MaCongViec");
                }
                else
                {
                      ThemNV = string.Format("update PhanCongViec set CaTruc=@CaTruc where MaCongViec=@MaCongViec");
                }
               

                DataTable user = new DataTable();

                SqlCommand Com = new SqlCommand(ThemNV, Con);

                DateTime NS;


                if (LoaiNhanVien == "1" || LoaiNhanVien == "2")
                {
                    string temp = lblNgayDi.Text.Replace("Ngày ", "");
                    NS = Convert.ToDateTime(temp);

                    Com.Parameters.Add(new SqlParameter("@NgayDi", NS));
                    Com.Parameters.Add(new SqlParameter("@MaChuyenXe", lblMaChuyen.Text));
                    Com.Parameters.Add(new SqlParameter("@LoTrinh", lblLoTrinh.Text));         
                }
                else
                {
                    Com.Parameters.Add(new SqlParameter("@CaTruc", comboBox1.Text));
                }

                //ThemNV
            
                Com.Parameters.Add(new SqlParameter("@MaCongViec",MaNhanVien_FormMain));
          

                SqlDataAdapter adapt = new SqlDataAdapter(Com);
                adapt.Fill(user);

                Con.Close();
                MetroFramework.MetroMessageBox.Show(this, string.Format("Đã Cập Nhật Công Việc Cho Nhân Viên {0}!", lblTenNhanVien.Text), "Compelete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception EX)
            {
                MetroFramework.MetroMessageBox.Show(this, EX.Message);
            }
        }
        private void btnThemNV_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Chắc Chắn Hay Không", "Xác Nhận Thay Đổi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                UpdateCongViec();
                this.Close();
            }
        }

      
    }
}
