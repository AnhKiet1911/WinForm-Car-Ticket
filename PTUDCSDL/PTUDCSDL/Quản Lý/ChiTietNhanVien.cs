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
    public partial class ChiTietNhanVien : MetroFramework.Forms.MetroForm
    {
        public ChiTietNhanVien()
        {
            InitializeComponent();
        }

        public delegate void PassDataDatVe(string MaNV);

        string MaNhanVien_FormMain;
        string LoaiNhanVien = "";

        public void GetPassData_FormMain(string str)
        {
            MaNhanVien_FormMain = str;
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
                LoaiNhanVien = Com.ExecuteScalar().ToString();
                txtLoaiNV.Text = TenLoaiNV(Com.ExecuteScalar().ToString());
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
                    lblNgayDi.Text = "";
                    lblMaChuyen.Text = "";
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

             
            }
            catch (Exception EX)
            {
                MetroFramework.MetroMessageBox.Show(this, EX.Message);
            }
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
                       
                    }
                    Con.Close();
                }
                catch (Exception EX)
                {
                    MetroFramework.MetroMessageBox.Show(this, EX.Message);
                }
            }
        }

        private void Loading()
        {
            try
            {
                SqlConnection Con = KetNoiCSDL.KetNoiSQL();
                Con.Open();

                String Soure = String.Format("select dg.DanhGia from DanhGiaNhanVien dg where dg.MaNhanVien=@MaNV");
                SqlCommand Com = new SqlCommand(Soure, Con);
                Com.Parameters.Add(new SqlParameter("@MaNV", MaNhanVien_FormMain));
                if (Com.ExecuteScalar() == null)
                {
                    lblDanhGia.Text = ".........................";
                }
                else
                {
                    lblDanhGia.Text = Com.ExecuteScalar().ToString();
                }
                Con.Close();
            }
            catch (Exception EX)
            {
                MetroFramework.MetroMessageBox.Show(this, EX.Message);
            }
        }


        private void ChiTietNhanVien_Load(object sender, EventArgs e)
        {
            LayThongTin(MaNhanVien_FormMain);
            lblMaNhanVien.Text = MaNhanVien_FormMain;
            Begin();
            GetInfoVe();
            Loading();

            if (LoaiNhanVien=="1"||LoaiNhanVien=="2")
            {
                comboBox1.Text = "Không Có";
            }
            else
            {
                lblLoTrinh.Text = "Không Có";
                lblMaChuyen.Text = "Không Có";
                lblNgayDi.Text = "Không Có";
                txtSohChay.Text = "Không Có";
            }
        }

        private void btnDanhGia_Click(object sender, EventArgs e)
        {
            Quản_Lý.frmtxtDanhGia DV = new Quản_Lý.frmtxtDanhGia();
            PassDataDatVe Share = new PassDataDatVe(DV.GetPassData_FormMain);
            Share(MaNhanVien_FormMain);
            DV.ShowDialog();
            ChiTietNhanVien_Load(sender, e);


        }
    }
}
