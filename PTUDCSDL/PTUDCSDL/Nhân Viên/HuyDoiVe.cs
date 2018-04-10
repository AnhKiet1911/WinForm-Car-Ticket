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
    public partial class HuyDoiVe : MetroFramework.Forms.MetroForm
    {
        public HuyDoiVe()
        {
            InitializeComponent();
            ControlBox = false;
        }

        string IdCanDoi;
        string IdChuyenCanDoi;
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

        private void VisiblePanel()
        {
            metroPanel1.Visible = false;
        }


        private void btnDoiVe_Click(object sender, EventArgs e)
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
                if (MetroFramework.MetroMessageBox.Show(this, "Chắc Chắn Hay Không", "Bạn Có Chắc Đổi Vé Này", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    string Str = IdCanDoi + "&" + TextBoxGiaTien.Text + "&" + IdNguoiDung_FormMain;
                    DoiVeXe();
                    frmInPhieu In = new frmInPhieu();
                    PassDataInPhieuDatVe Share = new PassDataInPhieuDatVe(In.GetPassData_FormDatVe);
                    Share(Str);
                    this.Hide();
                    In.ShowDialog();
                    HuyDoiVe_Load(sender, e);
                    metroPanel1.Visible = false;
                    this.Show();
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



        private void DoiVeXe()
        {
            try
            {
                SqlConnection Con = KetNoiCSDL.KetNoiSQL();
                Con.Open();

                CDatVe VXe = new CDatVe();
                //idChuyen
                int index = lblMaVe.Text.IndexOf(" ");
                string IdVe = lblMaVe.Text.Substring(0, index);
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
                if (ixdexTien == -1)
                {
                    VXe.TienVe = Convert.ToInt32(TempTien);
                }
                else
                {
                    TempTien = TempTien.Replace(".", "");
                    VXe.TienVe = Convert.ToInt32(TempTien);
                }


                //Thoi Gian Mua Ve
                VXe.ThoiGianMuaVe = "Ngày " + DateTime.Now.Day.ToString() + " Tháng " + DateTime.Now.Month.ToString() + " Năm " + DateTime.Now.Year.ToString();




                string DoiVe = string.Format("exec DoiVe @IdChuyenNow,@TenHanhKhach,@NgaySinh,@SDTHanhKhach,@CMND,@QueQuan,@GiaTien,@ThoiGianMua,@IdChuyenCanDoi,@IdVe");

                string InsertUuDaiKhachHang = string.Format("exec InsertUuDaiKhachHang @MaVeUuDai,@TenHangKhachUuDai,@SDTUuDai,@CMNDUuDai,@LoaiGiaoDich");
                DataTable user = new DataTable();

                SqlCommand Com = new SqlCommand(DoiVe, Con);

                SqlCommand ComUuDai = new SqlCommand(InsertUuDaiKhachHang, Con);

                //DoiVe
                Com.Parameters.Add(new SqlParameter("@IdChuyenNow", VXe.IdChuyen));
                Com.Parameters.Add(new SqlParameter("@IdVe", IdCanDoi));
                Com.Parameters.Add(new SqlParameter("@IdChuyenCanDoi", IdChuyenCanDoi));
                Com.Parameters.Add(new SqlParameter("@TenHanhKhach", VXe.TenKhachHang));
                Com.Parameters.Add(new SqlParameter("@NgaySinh", VXe.NgaySinh));
                Com.Parameters.Add(new SqlParameter("@SDTHanhKhach", VXe.SDT));
                Com.Parameters.Add(new SqlParameter("@CMND", VXe.CMND));
                Com.Parameters.Add(new SqlParameter("@QueQuan", VXe.QueQuan));
                Com.Parameters.Add(new SqlParameter("@GiaTien", VXe.TienVe));
                Com.Parameters.Add(new SqlParameter("@ThoiGianMua", VXe.ThoiGianMuaVe));



                //InsertUuDaiKhachHang
                ComUuDai.Parameters.Add(new SqlParameter("@MaVeUuDai", lblMaVe.Text));
                ComUuDai.Parameters.Add(new SqlParameter("@TenHangKhachUuDai", VXe.TenKhachHang));
                ComUuDai.Parameters.Add(new SqlParameter("@SDTUuDai", VXe.SDT));
                ComUuDai.Parameters.Add(new SqlParameter("@CMNDUuDai", VXe.CMND));
                ComUuDai.Parameters.Add(new SqlParameter("@LoaiGiaoDich", "Đổi Vé"));

                SqlDataAdapter adapt = new SqlDataAdapter(Com);

                SqlDataAdapter adapt2 = new SqlDataAdapter(ComUuDai);
                adapt.Fill(user);
                adapt2.Fill(user);
                Con.Close();
                MetroFramework.MetroMessageBox.Show(this, string.Format("Đã Đổi Vé Cho Khách Hàng: {0}!", VXe.TenKhachHang));
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
            this.Close();
        }


        private void DatVe_ClientSizeChanged(object sender, EventArgs e)
        {
            //if (this.Width != 796 || this.Height != 435)
            //{
            //    this.ClientSize = new Size(796, 435);

            //}
        }

        private void btnHuyVe_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Chắc Chắn Hay Không", "Bạn Có Chắc Huỷ Vé Này", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                CDatVe VXe = new CDatVe();

                //Ten
                VXe.TenKhachHang = txtTen.Text;
                //CMND
                VXe.CMND = ntxtCMND.Text;


                //SDT
                VXe.SDT = ntxtSDT.Text;

                //

                // int index = lblMaVe.Text.IndexOf(" ");
                string IdVe = IdCanDoi;
                string IdChuyen = IdChuyenCanDoi;

                try
                {
                    SqlConnection Con = KetNoiCSDL.KetNoiSQL();
                    Con.Open();
                    DataTable user = new DataTable();
                    string HuyVe = string.Format("exec HuyVe @IdChuyen,@IdVe");
                    string InsertUuDaiKhachHang = string.Format("exec InsertUuDaiKhachHang @MaVeUuDai,@TenHangKhachUuDai,@SDTUuDai,@CMNDUuDai,@LoaiGiaoDich");
                    string UpdateChoNgoi = string.Format("exec UpdateChoNgoi @SoGheTrong, @IdChuyen");

                    SqlCommand ComUuDai = new SqlCommand(InsertUuDaiKhachHang, Con);

                    SqlCommand ComUpdate = new SqlCommand(UpdateChoNgoi, Con);
                    //HuyVe
                    SqlCommand Com = new SqlCommand(HuyVe, Con);
                    Com.Parameters.Add(new SqlParameter("@IdChuyen", IdChuyen));
                    Com.Parameters.Add(new SqlParameter("@IdVe", IdVe));

                    ComUpdate.Parameters.Add(new SqlParameter("@IdChuyen", IdChuyen));
                    ComUpdate.Parameters.Add(new SqlParameter("@SoGheTrong", GetChoNgoi() + 1));

                    //InsertUuDaiKhachHang
                    ComUuDai.Parameters.Add(new SqlParameter("@MaVeUuDai", lblMaVe.Text));
                    ComUuDai.Parameters.Add(new SqlParameter("@TenHangKhachUuDai", VXe.TenKhachHang));
                    ComUuDai.Parameters.Add(new SqlParameter("@SDTUuDai", VXe.SDT));
                    ComUuDai.Parameters.Add(new SqlParameter("@CMNDUuDai", VXe.CMND));
                    ComUuDai.Parameters.Add(new SqlParameter("@LoaiGiaoDich", "Huỷ Vé"));

                    //
                    SqlDataAdapter adapt1 = new SqlDataAdapter(ComUpdate);
                    SqlDataAdapter adapt2 = new SqlDataAdapter(ComUuDai);
                    SqlDataAdapter adapt = new SqlDataAdapter(Com);
                    adapt.Fill(user);
                    adapt1.Fill(user);
                    adapt2.Fill(user);
                    Con.Close();

                    MetroFramework.MetroMessageBox.Show(this, string.Format("Đã Delete Vé Mã Số:{0}", IdCanDoi + " - " + IdChuyenCanDoi));
                    HuyDoiVe_Load(sender, e);
                    metroPanel1.Visible = false;
                }
                catch (Exception EX)
                {
                    MetroFramework.MetroMessageBox.Show(this, EX.Message);
                }
            }

        }





        private void ShowInfoKhachHang(string MaVe)
        {
            int index = MaVe.IndexOf(" ");
            string IdVe = MaVe.Substring(0, index);
            string IdChuyen = MaVe.Substring(index + 3);
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

            string IdVe = txtKiemTra.Text.Substring(0, index);
            int IdTemp = 0;
            if (!int.TryParse(IdVe, out IdTemp)) //Đảm bảo ID vé Phải Là Số If not number error
            {
                return -1;
            }
            string IdChuyen = txtKiemTra.Text.Substring(index + 3);
            IdChuyenCanDoi = txtKiemTra.Text.Substring(index + 3);
            IdCanDoi = txtKiemTra.Text.Substring(0, index);
            try
            {
                SqlConnection Con = KetNoiCSDL.KetNoiSQL();
                Con.Open();
                string Dem = string.Format("exec KiemTraTonTaiVe @IdChuyen ,@IdVe"); //Gọi Proc
                SqlCommand Com = new SqlCommand(Dem, Con);
                Com.Parameters.Add(new SqlParameter("@IdVe", IdVe));
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
        private void metroLink3_Click(object sender, EventArgs e)
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
                    btnDoiVe.Visible = true;
                    btnHuyVe.Visible = true;


                    //
                    GetLoTrinhVe(); //-----><-------


                    //
                    ShowInfoKhachHang(txtKiemTra.Text);

                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, "Tấm Vé Này Không Tồn Tại");
                }
            }
        }

        private void HuyDoiVe_Load(object sender, EventArgs e)
        {

            //reset form
            txtTen.Clear();
            ntxtCMND.Clear();
            DynamicCBOXQueQuan.ResetText();
            ntxtSDT.Clear();
            TextBoxGiaTien.Clear();

        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Chắc Chắn Hay Không", "Bạn Muốn Thoát ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void txtKiemTra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                metroLink3_Click(sender, e);
            }
        }
    }
}

