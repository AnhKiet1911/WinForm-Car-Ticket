using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTUDCSDL
{
    public partial class Main : MetroFramework.Forms.MetroForm
    {
        string IdNguoiDung = "";
      
        public Main()
        {
            InitializeComponent();
            ControlBox = false;



            /// <summary>
            /// transparent
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>

            //Label Tiêu Đề Trans
            var trans = this.TabNhanVien.PointToScreen(lblTieuDe.Location);
            trans = pictureBox2.PointToClient(trans);
            lblTieuDe.Parent = pictureBox2;
            lblTieuDe.Location = trans;
            lblTieuDe.BackColor = Color.Transparent;

            //TileNameNhanVien Trans
            var NameTile = this.TabNhanVien.PointToScreen(TileNameNhanVien.Location);
            NameTile = TileNhanVien.PointToClient(NameTile);
            TileNameNhanVien.Parent = TileNhanVien;
            TileNameNhanVien.Location = NameTile;
            TileNameNhanVien.BackColor = Color.Transparent;

            //TileNameQuanLy Trans
            var NameTile1 = this.TabQuanLy.PointToScreen(TileNameQuanLy.Location);
            NameTile1 = TileQuanLy.PointToClient(NameTile1);
            TileNameQuanLy.Parent = TileQuanLy;
            TileNameQuanLy.Location = NameTile1;
            TileNameQuanLy.BackColor = Color.Transparent;

            ////Label Tiêu Đề Trans
            var trans2 = this.TabQuanLy.PointToScreen(lblTieuTeTabQL.Location);
            trans2 = pictureBox1.PointToClient(trans2);
            lblTieuTeTabQL.Parent = pictureBox1;
            lblTieuTeTabQL.Location = trans2;
            lblTieuTeTabQL.BackColor = Color.Transparent;


            ////Label DanhSachMuaVe Trans
            var trans3 = this.TabNhanVien.PointToScreen(lblDSMuaVe.Location);
            trans3 = pictureBox2.PointToClient(trans3);
            lblDSMuaVe.Parent = pictureBox2;
            lblDSMuaVe.Location = trans3;
            lblDSMuaVe.BackColor = Color.Transparent;



            //lblDoanhThuTienVe
          
            var ThuTienVe = this.TabQuanLy.PointToScreen(lblThuVe.Location);
            ThuTienVe = pictureBox1.PointToClient(ThuTienVe);
            lblThuVe.Parent = pictureBox1;
            lblThuVe.Location = ThuTienVe;
            lblThuVe.BackColor = Color.Transparent;
            //lblDoanhThuGuiHang

            var ThuGuiHang = this.TabQuanLy.PointToScreen(lblDanhThuGuiHang.Location);
            ThuGuiHang = pictureBox1.PointToClient(ThuGuiHang);
            lblDanhThuGuiHang.Parent = pictureBox1;
            lblDanhThuGuiHang.Location = ThuGuiHang;
            lblDanhThuGuiHang.BackColor = Color.Transparent;

            //lblTong
            var Total1 = this.TabQuanLy.PointToScreen(lblTong1.Location);
            Total1 = pictureBox1.PointToClient(Total1);
            lblTong1.Parent = pictureBox1;
            lblTong1.Location = Total1;
            lblTong1.BackColor = Color.Transparent;

            var Total2 = this.TabQuanLy.PointToScreen(lblTong2.Location);
            Total2 = pictureBox1.PointToClient(Total2);
            lblTong2.Parent = pictureBox1;
            lblTong2.Location = Total2;
            lblTong2.BackColor = Color.Transparent;

            var Total = this.TabQuanLy.PointToScreen(lblTongDThu.Location);
            Total = pictureBox1.PointToClient(Total);
            lblTongDThu.Parent = pictureBox1;
            lblTongDThu.Location = Total;
            lblTongDThu.BackColor = Color.Transparent;



        }

        public delegate void PassDataDatVe(string IdNguoiDung);


        //Lây Dữ Liệu Form 1
        public void GetData_Form1(MetroFramework.Controls.MetroTextBox Txt_Login)
        {

            IdNguoiDung = Txt_Login.Text;
        }

  


        /// <summary>
        /// Animation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //about Show
        int HightAbout = 150, aAbout = 1;
        private void TimeAbout_Tick(object sender, EventArgs e)
        {
            try
            {
                HightAbout += aAbout;
                TileAbout.Size = new Size(427, HightAbout);
                if (HightAbout == 300)
                {
                    TileAbout.Size = new Size(427,150);
                    HightAbout = 150;
                    aAbout = 1;
                    TglAbout.Checked = false;
                }
                else if (HightAbout == 150)
                {
                    aClock = +1;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

      

        //Var Move ClockTime
        int HightClock = 75,aClock = 1;
        private void ClockTime_Tick(object sender, EventArgs e)
        {
            try
            {

                HightClock += aClock;
                metroLink1.Size = new Size(HightClock,29);
                if (HightClock == 2550)
                {
                    metroLink1.Location = new Point(205, 40);
                    metroLink1.Size = new Size(75, 29);
                    HightClock = 75;
                    aClock = 1;
                }
                else if (HightClock == 60)
                {
                    aClock = +1;
                }
            }
            catch (Exception)
            {
                throw;
            }
          
        }


        private void GetTime_Tick(object sender, EventArgs e)
        {
            try
            {
                metroLink1.Text = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + "\r\n" + DateTime.Now.DayOfWeek + "\r\n - Ngày " + DateTime.Now.Day.ToString() + "\r\n - Tháng " + DateTime.Now.Month.ToString() + "- Năm " + DateTime.Now.Year.ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }


        //Var Move MoveTitel
        int X = 23, Y = 11, point = 1;
        private void MoveTitel_Tick(object sender, EventArgs e)
        {
            try
            {

                X += point;
                lblTitel.Location = new Point(X, Y);
                if (X == 1095)
                {
                    point = -1;
                }
                else if (X == 206)
                {
                    point = +1;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        private void metroTrackBar1_Scroll(object sender, ScrollEventArgs e)
        {
            if (metroTrackBar1.Value < 100)
            {
                metroToggle1.Checked = false;
            }
            this.Opacity = metroTrackBar1.Value*0.01;
            if (this.Opacity <= 0.1)
            {
                this.Opacity = 0.1;
            }
         
        }

        private void TglAbout_CheckedChanged(object sender, EventArgs e)
        {
           

            if (TglAbout.Checked == true)
            {
                TimeAbout.Enabled = true;
                TileAbout.Visible = true;
                lblCTV.Visible = true;
             
            }
            else
            {
                TileAbout.Size = new Size(427, 150);
                HightAbout = 150;
                aAbout = 1;
                TimeAbout.Enabled = false;
                TileAbout.Visible = false;
                lblCTV.Visible = false;
               
            }
            

        }

        private void TileDatVe_Click(object sender, EventArgs e)
        {
            //reset
            lblTitel_Click(sender, e);
            //
            dataGridViewBanVe.Visible = true;
            lblDSMuaVe.Visible = true;
            lblDSMuaVe.Text = "Danh Sách Khách Hàng Mua Vé";
            LoadListView();
            //
            dataGridViewDatVeHuyDoiVe.Visible = true;
            dataGridViewDatVeHuyDoiVe.Size = new Size(802, 228);
            dataGridViewDatVeHuyDoiVe.Location = new Point(250, 163);
            PanelChiTietDatDoiHuyVe.Location = new Point(250, 400);
            PanelChiTietDatDoiHuyVe.Size = new Size(802, 200);
            btnDatVe.Location = new Point(1068, 566);
            btnDatVe.Size = new Size(88, 34);
            PanelChiTietDatDoiHuyVe.Visible = true;
            lblTieuDe.Visible = true;
            btnDatVe.Visible = true;
            lblTieuDe.Text = "Đặt Vé Xe";

            SqlConnection Con = KetNoiCSDL.KetNoiSQL();
            Con.Open();

            string add = string.Format("exec Source_GridViewDatVeHuyDoiVe");
            DataTable user = new DataTable();
            SqlCommand Com = new SqlCommand(add, Con);

            SqlDataAdapter adapt = new SqlDataAdapter(Com);

            adapt.Fill(user);
            dataGridViewDatVeHuyDoiVe.DataSource = user; //Đổ dữ liệu vào dataGridViewDatVe

            Con.Close();

         
        }

       

        private void btnEditInfoNhanVien_Click(object sender, EventArgs e)
        {
          

            string Str = IdNguoiDung;
            //this.Hide();
            EditNguoiDung DV = new EditNguoiDung();
            PassDataDatVe Share = new PassDataDatVe(DV.GetPassData_FormMain);
            Share(Str);
            DV.ShowDialog();
      

            if (GetLoaiNguoiDung() == "Nhân Viên")
            {
                Main_Load(sender, e);
                TileNhanVien_Click(sender, e);
                
            }

            else if (GetLoaiNguoiDung() == "Quản Lý")
            {
                Main_Load(sender, e);
                TileQuanLy_Click(sender, e);
            }
  
        }

        private void lblTitel_Click(object sender, EventArgs e)
        {
            if (GetLoaiNguoiDung() == "Nhân Viên")
            {
                this.TabMain.SelectedTab = TabNhanVien;
                //NhanVien
                dataGridViewDatVeHuyDoiVe.Visible = false;
                lblTieuDe.Visible = false;
                ImageNhanVien.Visible = false;
                PanelNhanVien.Visible = false;
                btnChonAnh.Visible = false;
                btnSuaAnhNguoiDung.Visible = false;
                PanelChiTietDatDoiHuyVe.Visible = false;
                btnDatVe.Visible = false;
                btnHuyDoiVe.Visible = false;
                btnGuiHang.Visible = false;
                btnNhanHang.Visible = false;
                metroGridGuiHang.Visible = false;
                btnXepLichChay.Visible = false;
                lblDSMuaVe.Visible = false;
                dataGridViewBanVe.Visible = false;
                dataGridViewNikki.Visible = false;
            }

            else if (GetLoaiNguoiDung() == "Quản Lý")
            {
                this.TabMain.SelectedTab = TabQuanLy;
                //QuanLy
                lblTieuTeTabQL.Visible = false;
                ImageQuanLy.Visible = false;
                btnChoose.Visible = false;
                btnEditImageQL.Visible = false;
                PannelQuanLy.Visible = false;

                //XepLichNhanVien
                dataGridViewDSNV.Visible = false;
                btnThemNV.Visible = false;

                //DoanhThu
                GridViewTienVe.Visible = false;
                GridViewTienHang.Visible = false;
                lblTong1.Visible = false;
                lblTong2.Visible = false;
                lblTongDThu.Visible = false;
                lblDanhThuGuiHang.Visible = false;
                lblThuVe.Visible = false;
                btnBaoCaoHang.Visible = false;
                btnBaoCaoVe.Visible = false;

                //NhanSu
                GridViewNhanSu.Visible = false;
                btnBaoCaoNhanSu.Visible = false;

                //Chi Phí
                GridViewChiPhi.Visible = false;
                btnBaoCaoChiPhi.Visible = false;
                btnThemChiPhi.Visible = false;

                //Vat Tư
                GridViewVatTu.Visible = false;
                btnInVatTu.Visible = false;
                btnThemVT.Visible = false;
            }
        }



        //Đường Dẫn Hình Ảnh
        string DuongDan;
        private void btnSuaAnhNguoiDung_Click(object sender, EventArgs e)
        {
            OpenFileDialog ChonTep = new OpenFileDialog();
            ChonTep.Filter = ChonTep.Filter = "JPG Files (*.jpg)|*.jpg| PNG Files (*.png)|*.png| Gif Files (*.gif)|*.gif";
            ChonTep.RestoreDirectory = true;
            if (ChonTep.ShowDialog()==DialogResult.OK)
            {
                if (GetLoaiNguoiDung() == "Nhân Viên")
                {
                    ImageNhanVien.ImageLocation = ChonTep.FileName;
                    DuongDan = ChonTep.FileName;
                }

                else if (GetLoaiNguoiDung() == "Quản Lý")
                {
                    ImageQuanLy.ImageLocation = ChonTep.FileName;
                    DuongDan = ChonTep.FileName;
                }
               
            }
        }



        private void btnEditAnhNhanVien_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection Con = KetNoiCSDL.KetNoiSQL();

                Con.Open();
                string AddImage = string.Format("exec EditAnhNhanVien @AnhNguoiDung , @IdNguoiDung");
                SqlCommand Com = new SqlCommand(AddImage, Con);
                Com.Parameters.Add(new SqlParameter("@IdNguoiDung", IdNguoiDung));
                Com.Parameters.Add(new SqlParameter("@AnhNguoiDung",ConvertImageToURL()));

                Com.ExecuteNonQuery();
                Con.Close();

                //
                if (GetLoaiNguoiDung() == "Nhân Viên")
                {
                    TileNhanVien.Image = Image.FromStream(GetImage());
                  //  IconTenNV.Image = Image.FromStream(GetImage());
                }

                else if (GetLoaiNguoiDung() == "Quản Lý")
                {
                    TileQuanLy.Image = Image.FromStream(GetImage());
                  //  IconTenQL.Image = Image.FromStream(GetImage());

                }
             
               MetroFramework.MetroMessageBox.Show(this,"OK");
            }
            catch (Exception EX)
            {
                MetroFramework.MetroMessageBox.Show(this, EX.Message);
            }
        }

        private byte[] ConvertImageToURL()
        {
            FileStream fs;
            fs = new FileStream(DuongDan,FileMode.Open,FileAccess.Read);
            byte[] picture = new byte[fs.Length];
            fs.Read(picture,0,System.Convert.ToInt32(fs.Length));
            fs.Close();
            return picture;
        }



        /// <summary>
        ///  LayThongTinNguoiDung
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        private NguoiDung GetInfoNguoiDung()
        {
            NguoiDung Info = new NguoiDung();
            try
            {
                SqlConnection Con = KetNoiCSDL.KetNoiSQL();
                Con.Open();

                //LayTen
                string Ten = string.Format("exec GetInfoNguoiDung_Ten @ID"); //Gọi Proc
                SqlCommand Com = new SqlCommand(Ten, Con);
                Com.Parameters.Add(new SqlParameter("@ID", IdNguoiDung));
                Info.Ten = Com.ExecuteScalar().ToString();

                //LayGioiTinh
                string GioiTinh = string.Format("exec GetInfoNguoiDung_Sex @ID"); //Gọi Proc
                Com = new SqlCommand(GioiTinh, Con);
                Com.Parameters.Add(new SqlParameter("@ID", IdNguoiDung));
                Info.GioiTinh = Com.ExecuteScalar().ToString();

                //LayNgaySinh
                string NgaySinh = string.Format("exec GetInfoNguoiDung_NgaySinh @ID"); //Gọi Proc
                Com = new SqlCommand(NgaySinh, Con);
                Com.Parameters.Add(new SqlParameter("@ID", IdNguoiDung));
                Info.NgaySinh = Com.ExecuteScalar().ToString();

                int index = Info.NgaySinh.IndexOf(" ");
                if (index != -1)
                {
                    Info.NgaySinh = Info.NgaySinh.Substring(0, index);
                }

                //LayDienThoai
                string SoDienThoai = string.Format("exec GetInfoNguoiDung_SDT @ID"); //Gọi Proc
                Com = new SqlCommand(SoDienThoai, Con);
                Com.Parameters.Add(new SqlParameter("@ID", IdNguoiDung));
                Info.SoDienThoai = Com.ExecuteScalar().ToString();

                //LayDiaChi
                string DiaChi = string.Format("exec GetInfoNguoiDung_DiaChi @ID"); //Gọi Proc
                Com = new SqlCommand(DiaChi, Con);
                Com.Parameters.Add(new SqlParameter("@ID", IdNguoiDung));
                Info.DiaChi = Com.ExecuteScalar().ToString();

                Con.Close();
            }
            catch (Exception EX)
            {
                MetroFramework.MetroMessageBox.Show(this, EX.Message);
            }
            return Info;
        }

        private MemoryStream GetImage()
        {
            MemoryStream str = null;
            try
            {
                SqlConnection Con = KetNoiCSDL.KetNoiSQL();
                Con.Open();


                DataTable dt = new DataTable();
                SqlDataAdapter adapt = new SqlDataAdapter("select * from Anh a where a.IdNguoiDung = '" + IdNguoiDung + "'", Con);
                adapt.Fill(dt);
                byte[] MyData = new byte[0];
                MyData = (byte[])dt.Rows[0][1];
                str = new MemoryStream(MyData);
                Con.Close();
                return str;
            }
            catch (Exception EX)
            {
                MetroFramework.MetroMessageBox.Show(this, EX.Message);
            }
            return str;

        }

        private void TileQuanLy_Click(object sender, EventArgs e)
        {
            ImageQuanLy.Image = Image.FromStream(GetImage());
            //Bảng Nhân Viên
            lblTenQuanLy.Text = GetInfoNguoiDung().Ten;
            lblDiaChiQuanLy.Text = GetInfoNguoiDung().DiaChi;
            lblGioiTinhQL.Text = GetInfoNguoiDung().GioiTinh;
            lblPhoneQuanLy.Text = GetInfoNguoiDung().SoDienThoai;
            lblNgaySinhQuanLy.Text = GetInfoNguoiDung().NgaySinh;
            lblQuyenHanQL.Text = GetLoaiNguoiDung();

            //reset
            lblTitel_Click(sender, e);
            ImageQuanLy.Visible = true;
            PannelQuanLy.Visible = true;
            btnChoose.Visible = true;
            btnEditImageQL.Visible = true;
            lblTieuTeTabQL.Visible = true;
            lblTieuTeTabQL.Text = "Thông Tin Người Dùng";
        }

        private void btnDatVe_Click(object sender, EventArgs e)
        {

            string Str = IdNguoiDung;
            //this.Hide();
            DatVe DV = new DatVe();
            PassDataDatVe Share = new PassDataDatVe(DV.GetPassData_FormMain);
            Share(Str);
            DV.ShowDialog();
            this.Main_Load(sender,e);
            TileDatVe_Click(sender, e);//reset dataview
            //this.Show();
        }

        private void dataGridViewDatVeHuyDoiVe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewDatVeHuyDoiVe.Rows.Count > 0 && dataGridViewDatVeHuyDoiVe.DataSource != null)
            {

                string dMaChuyen = dataGridViewDatVeHuyDoiVe.SelectedRows[0].Cells[0].Value.ToString();
                string dSoXe = dataGridViewDatVeHuyDoiVe.SelectedRows[0].Cells[1].Value.ToString();
                string dNgayDi = dataGridViewDatVeHuyDoiVe.SelectedRows[0].Cells[2].Value.ToString();
                string dKhoiHanh = dataGridViewDatVeHuyDoiVe.SelectedRows[0].Cells[3].Value.ToString();
                string dLoaiXe = dataGridViewDatVeHuyDoiVe.SelectedRows[0].Cells[4].Value.ToString();
                string DChoTrong = dataGridViewDatVeHuyDoiVe.SelectedRows[0].Cells[5].Value.ToString();
                string dDiTu = dataGridViewDatVeHuyDoiVe.SelectedRows[0].Cells[6].Value.ToString();
                string dDen = dataGridViewDatVeHuyDoiVe.SelectedRows[0].Cells[7].Value.ToString();

                lblLinkMaChuyen.Text = dMaChuyen;
                lblLinkSoXe.Text = dSoXe;

                //
                lblLinkNgayDi.Text = dNgayDi;
              
                
              
                //
                lblLinkGioDi.Text = dKhoiHanh;
                lblLinkHieuXe.Text = dLoaiXe;
                lblLinkChoNgoi.Text = DChoTrong;
                lblLinkDiemDi.Text = dDiTu;
                lblLinkDiemDen.Text = dDen;

             
            }

            else
            {
                MetroFramework.MetroMessageBox.Show(this,"Hiện Chưa Có Thông Tin Gì Để Chọn");
            }
        }



        //-----------------
        int Weight_Slide = 233;
        //Visible
        private void Visible_PanelNV(bool TorF)
        {
            if (TorF == true)
            {
                TileNhanVien.Visible = true;
                TileHuyDoiVe.Visible = true;
                TileDatVe.Visible = true;
                TileXepLichChay.Visible = true;
                TileNhanGui.Visible = true;
                SlideCloseNV.Visible = true;

                SlideDownNV.Visible = false;


                //Icon
                IconCaiDat.Location = new Point(45, 631);
                IconExit.Location = new Point(115, 631);
                IconLogOut.Location = new Point(180, 631);

                IconTenNV.Visible = false;
                IconDatVe.Visible = false;
                IconHoiVe.Visible = false;
                IconGuiHang.Visible = false;
                IconXepLichXe.Visible = false;
            }
            else
            {
                TileNhanVien.Visible = false ;
                TileHuyDoiVe.Visible = false;
                TileDatVe.Visible = false;
                TileXepLichChay.Visible = false;
                TileNhanGui.Visible = false;
                SlideCloseNV.Visible = false;

                SlideDownNV.Visible = true;
                //Icon
                IconCaiDat.Location = new Point(4, 631);
                IconExit.Location = new Point(4, 550);
                IconLogOut.Location = new Point(4, 470);
               

                IconTenNV.Visible = true;
                IconDatVe.Visible = true;
                IconHoiVe.Visible = true;
                IconGuiHang.Visible = true;
                IconXepLichXe.Visible = true;
            }
        }
        private void SlideCloseNV_Click(object sender, EventArgs e)
        {
            TimeSlideClose.Enabled = true;

        }
        private void SlideDownNV_Click(object sender, EventArgs e)
        {
            TimeSlideDown.Enabled = true;
        }
        private void SlideClose_Tick(object sender, EventArgs e)
        {

            PanelSlideNV.Size = new Size(Weight_Slide, 680);
            if (PanelSlideNV.Width <= 58) 
            {
                TimeSlideClose.Enabled = false;
                Visible_PanelNV(false);
                Line.Visible = true;
            }
            else
            {
                Weight_Slide -= 12;
            }
        }
        private void TimeSlideDown_Tick(object sender, EventArgs e)
        {
            Line.Visible = false;
            Visible_PanelNV(true);
            PanelSlideNV.Size = new Size(Weight_Slide, 680);
            if (PanelSlideNV.Width >= 233)
            {
                TimeSlideDown.Enabled = false;
            }
            else
            {
                Weight_Slide += 12;
            }
        }

       
        //---------------------------------------------------------><---------------//
        //Slide Panel Nhân Viên
        int Weight_SlideQL = 233;
        private void Visible_PanelQL(bool TorF)
        {
            if (TorF == true)
            {
                TileQuanLy.Visible = true;
                TileLNV.Visible = true;
                TileDT.Visible = true;
                TileCP.Visible = true;
                TileNS.Visible = true;
                TileVT.Visible = true;
                SlideCloseQL.Visible = true;
                
                slideDownQL.Visible = false;
                //
                IconCaiDatQL.Location = new Point(45, 631);
                IconTurnOffQL.Location = new Point(115, 631);
                IconLogOutQL.Location = new Point(180, 631);

                //Icon
                IconTenQL.Visible = false;
                IconLichNhanVien.Visible = false;
                IconDoanhThu.Visible = false;
                IconThongKeChiPhi.Visible = false;
                IConDanSu.Visible = false;
                IconVatTu.Visible = false;
            }
            else
            {
                TileQuanLy.Visible = false;
                TileLNV.Visible = false;
                TileDT.Visible = false;
                TileCP.Visible = false;
                TileNS.Visible = false;
                TileVT.Visible = false;
                SlideCloseQL.Visible = false;

                slideDownQL.Visible = true;
                //

                IconCaiDatQL.Location = new Point(4, 631);
                IconTurnOffQL.Location = new Point(4, 580);
                IconLogOutQL.Location = new Point(2, 530);
                //Icon
                IconTenQL.Visible = true;
                IconLichNhanVien.Visible = true;
                IconDoanhThu.Visible = true;
                IconThongKeChiPhi.Visible = true;
                IConDanSu.Visible = true;
                IconVatTu.Visible = true;
            }
        }
        private void SlideCloseQL_Click(object sender, EventArgs e)
        {
            TimeSlideCloseQL.Enabled = true;
        }

        private void slideDownQL_Click(object sender, EventArgs e)
        {
            TimeSlideDownQL.Enabled = true;
        }

        private void TimeSlideDownQL_Tick(object sender, EventArgs e)
        {
            Visible_PanelQL(true);
            PenalSlideQL.Size = new Size(Weight_SlideQL, 680);
            if (PenalSlideQL.Width >= 233)
            {
                TimeSlideDownQL.Enabled = false;
            }
            else
            {
                Weight_SlideQL += 12;
            }
        }

        private void TimeSlideCloseQL_Tick(object sender, EventArgs e)
        {
            PenalSlideQL.Size = new Size(Weight_SlideQL, 680);
            if (PenalSlideQL.Width <= 58)
            {
                TimeSlideCloseQL.Enabled = false;
                Visible_PanelQL(false);

            }
            else
            {
                Weight_SlideQL -= 12;
            }
        }

        private void IconHome_Click(object sender, EventArgs e)
        {
            lblTitel_Click(sender, e);
        }

 
        private void DangXuat_CheckedChanged(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Chắc Chắn Hay Không", "Bạn Muốn Đăng Xuất ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
           
        }

        private void btnHuyDoiVe_Click(object sender, EventArgs e)
        {

            string Str = IdNguoiDung;
            //this.Hide();
            HuyDoiVe DV = new HuyDoiVe();
            PassDataDatVe Share = new PassDataDatVe(DV.GetPassData_FormMain);
            Share(Str);
            DV.ShowDialog();
            this.Main_Load(sender, e);
            TileHuyDoiVe_Click(sender, e);//reset dataview
            
        }

        private void TileNhanGui_Click(object sender, EventArgs e)
        {
            //reset
           
            lblTitel_Click(sender, e);

            //
            dataGridViewNikki.Visible = true;
            lblDSMuaVe.Visible = true;
            lblDSMuaVe.Text = "Lịch Sử Giao Dịch Của Khách Hàng";
            LoadListNikki();
            //

            dataGridViewDatVeHuyDoiVe.Visible = true;
            dataGridViewDatVeHuyDoiVe.Size = new Size(802, 228);
            dataGridViewDatVeHuyDoiVe.Location = new Point(250, 163);
            metroGridGuiHang.Location = new Point(250, 400);
            metroGridGuiHang.Size = new Size(802, 200);
            btnGuiHang.Location = new Point(1068, 566);
            btnGuiHang.Size = new Size(94, 37);
            btnNhanHang.Location = new Point(1175, 566);
            btnNhanHang.Size = new Size(94, 37);
            metroGridGuiHang.Visible = true;
            lblTieuDe.Visible = true;
            btnGuiHang.Visible = true;
            btnNhanHang.Visible = true;
            lblTieuDe.Text = "Nhận - Gửi Hàng";


            //ChuyenXe
            try
            {
                SqlConnection Con = KetNoiCSDL.KetNoiSQL();
                Con.Open();

                string add = string.Format("exec Source_GridViewDatVeHuyDoiVe");
                DataTable user = new DataTable();
                SqlCommand Com = new SqlCommand(add, Con);

                SqlDataAdapter adapt = new SqlDataAdapter(Com);

                adapt.Fill(user);
                dataGridViewDatVeHuyDoiVe.DataSource = user; //Đổ dữ liệu vào dataGridViewDatVe

               //Bảng Gửi Hàng
                string add1 = string.Format("exec metroGridGuiHang");
                DataTable user1 = new DataTable();
                SqlCommand Com1 = new SqlCommand(add1, Con);

                SqlDataAdapter adapt1 = new SqlDataAdapter(Com1);

                adapt1.Fill(user1);
                metroGridGuiHang.DataSource = user1; //Đổ dữ liệu vào dataGridViewDatVe
                 Con.Close();
            }
            catch (Exception EX)
            {
                MetroFramework.MetroMessageBox.Show(this, EX.Message);
            }
  
        }

        private void btnGuiHang_Click(object sender, EventArgs e)
        {
            string Str = IdNguoiDung;
            //this.Hide();
            GuiHang DV = new GuiHang();
            PassDataDatVe Share = new PassDataDatVe(DV.GetPassData_FormMain);
            Share(Str);
            DV.ShowDialog();
            this.Main_Load(sender, e);
            TileNhanGui_Click(sender, e);//reset dataview
            //this.Show();
        }

        private void btnNhanHang_Click(object sender, EventArgs e)
        {
            NhanHang DV = new NhanHang();
            DV.ShowDialog();
            this.Main_Load(sender, e);
            TileNhanGui_Click(sender, e);//reset dataview
        }

        private void TileXepLichChay_Click(object sender, EventArgs e)
        {
            //reset
            lblTitel_Click(sender, e);

            TileDatVe_Click(sender, e);

            

            dataGridViewBanVe.Visible = false;
            lblDSMuaVe.Visible = false;
           

            btnDatVe.Visible = false;
            btnXepLichChay.Location = new Point(1068, 566);
            btnXepLichChay.Size = new Size(94, 37);

            btnXepLichChay.Visible = true;
            lblTieuDe.Text = "Xếp Lịch Chạy";
        }

        private void btnXepLichChay_Click(object sender, EventArgs e)
        {
            XepLich DV = new XepLich();
            DV.ShowDialog();
            this.Main_Load(sender, e);
            TileXepLichChay_Click(sender, e);//reset dataview
        }

        private void IconExit_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Chắc Chắn Hay Không", "Bạn Muốn Thoát ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
           
        }

        private void IconCaiDat_Click(object sender, EventArgs e)
        {
           this.TabMain.SelectedTab = TabCaiDat;
        }

        //------
        private string GetLoaiNguoiDung()
        {
            try
            {

                SqlConnection Con = KetNoiCSDL.KetNoiSQL();
                Con.Open();
                string QuyenHan = string.Format("exec GetLoaiNguoiDung @ID"); //Gọi Proc
                SqlCommand Com = new SqlCommand(QuyenHan, Con);
                Com.Parameters.Add(new SqlParameter("@ID", IdNguoiDung));
                string LoaiNguoiDung = "";
                LoaiNguoiDung = Com.ExecuteScalar().ToString();
                Con.Close();
                return LoaiNguoiDung;
            }
            catch (Exception EX)
            {
                MetroFramework.MetroMessageBox.Show(this, EX.Message);
            }
            return "";
        }

        private void TileNhanVien_Click(object sender, EventArgs e)
        {

            ImageNhanVien.Image = Image.FromStream(GetImage());
            //Bảng Nhân Viên
            lblTenNhanVien.Text = GetInfoNguoiDung().Ten;
            lblDiaChiNhanVien.Text = GetInfoNguoiDung().DiaChi;
            lblGioiTinhNhanVien.Text = GetInfoNguoiDung().GioiTinh;
            lblSDTNhanVien.Text = GetInfoNguoiDung().SoDienThoai;
            lblNgaySinhNhanVien.Text = GetInfoNguoiDung().NgaySinh;
            lblQuyenHanNhanVien.Text = GetLoaiNguoiDung();


            //reset
            lblTitel_Click(sender, e);
            ImageNhanVien.Visible = true;
            PanelNhanVien.Visible = true;
            btnChonAnh.Visible = true;
            btnSuaAnhNguoiDung.Visible = true;
            lblTieuDe.Visible = true;
            lblTieuDe.Text = "Thông Tin Người Dùng";

        }
        private void TileHuyDoiVe_Click(object sender, EventArgs e)
        {
            //reset




            lblTitel_Click(sender, e);

            TileDatVe_Click(sender, e);

            //
            dataGridViewBanVe.Visible = true;
            lblDSMuaVe.Visible = true;
            lblDSMuaVe.Text = "Danh Sách Khách Hàng Mua Vé";
            LoadListView();

            //

            btnDatVe.Visible = false;
            btnHuyDoiVe.Location = new Point(1068, 566);
            btnHuyDoiVe.Size = new Size(94, 37);

            btnHuyDoiVe.Visible = true;
            lblTieuDe.Text = "Huỷ - Đổi Vé Xe";
        }


        private void LoadListView()
        {
            try
            {


                SqlConnection Con = KetNoiCSDL.KetNoiSQL();
                Con.Open();
                string add = string.Format("exec dataGridViewBanVe");
                DataTable user = new DataTable();
                SqlCommand Com = new SqlCommand(add, Con);
                SqlDataAdapter adapt = new SqlDataAdapter(Com);
                adapt.Fill(user);
                dataGridViewBanVe.DataSource = user;
                Con.Close();
            }
            catch (Exception EX)
            {
                MetroFramework.MetroMessageBox.Show(this, EX.Message);
            }
        }


        private void LoadListNikki()
        {
            try
            {

                SqlConnection Con = KetNoiCSDL.KetNoiSQL();
                Con.Open();
                string add = string.Format("exec dataGridViewNikki");
                DataTable user = new DataTable();
                SqlCommand Com = new SqlCommand(add, Con);
                SqlDataAdapter adapt = new SqlDataAdapter(Com);
                adapt.Fill(user);
                dataGridViewNikki.DataSource = user;
                Con.Close();
            }
            catch (Exception EX)
            {
                MetroFramework.MetroMessageBox.Show(this, EX.Message);
            }
        }




        //------------------------Phần Quản Lý--------------------------------
        private void dataGridViewDSNV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            //btn Editor Thong tin Nhan Vien;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0 && senderGrid.Columns[e.ColumnIndex].Name == "btn" && senderGrid.DataSource != null) 
            {
                string MaNhanVien = dataGridViewDSNV.Rows[e.RowIndex].Cells["MaNhanVien"].Value.ToString();
                string TenNhanVien = dataGridViewDSNV.Rows[e.RowIndex].Cells["TenNhanVien"].Value.ToString();
                if (MaNhanVien == "" && TenNhanVien == "")
                {

                }
                else
                {
                    SuaNhanVien DV = new SuaNhanVien();
                    PassDataDatVe Share = new PassDataDatVe(DV.GetPassData_FormMain);
                    Share(MaNhanVien);
                    DV.ShowDialog();
                    TileLNV_Click(sender, e);
                }

            }

            //btn Delete Thong tin Nhan Vien;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0 && senderGrid.Columns[e.ColumnIndex].Name == "Delete" && senderGrid.DataSource != null) 
            {
                string MaNhanVien = dataGridViewDSNV.Rows[e.RowIndex].Cells["MaNhanVien"].Value.ToString();
                string TenNhanVien = dataGridViewDSNV.Rows[e.RowIndex].Cells["TenNhanVien"].Value.ToString();
                if (MaNhanVien == "" && TenNhanVien == "") 
                {

                }
                else if (MetroFramework.MetroMessageBox.Show(this, "Chắc Chắn Hay Không",string.Format("Bạn Muốn Xoá Nhân Viên {0}",TenNhanVien), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        SqlConnection Con = KetNoiCSDL.KetNoiSQL();
                        Con.Open();
                        string Delete = string.Format("delete from NhanVien where MaNhanVien = @MaNhanVien");
                        string Delete2 = string.Format("delete from PhanCongViec where MaCongViec = @MaCV");
                        string Delete3 = string.Format("delete from DanhGiaNhanVien where MaNhanVien = @MaNhanVien");
                        DataTable user = new DataTable();
                        SqlCommand Com = new SqlCommand(Delete, Con);
                        SqlCommand Com2 = new SqlCommand(Delete2, Con);
                        SqlCommand Com3 = new SqlCommand(Delete3, Con);
                        Com.Parameters.Add(new SqlParameter("@MaNhanVien", MaNhanVien));
                        Com2.Parameters.Add(new SqlParameter("@MaCV", MaNhanVien));
                        Com3.Parameters.Add(new SqlParameter("@MaNhanVien", MaNhanVien));
                        SqlDataAdapter adapt2 = new SqlDataAdapter(Com3);
                        SqlDataAdapter adapt = new SqlDataAdapter(Com);
                        SqlDataAdapter adapt1 = new SqlDataAdapter(Com2);
                       
                        adapt2.Fill(user);
                        adapt.Fill(user);
                        adapt1.Fill(user);
                       
                        Con.Close();
                        MetroFramework.MetroMessageBox.Show(this, string.Format("Đã Xoá Nhân Viên {0}!", TenNhanVien));
                        TileLNV_Click(sender, e);
                    }
                    catch (Exception EX)
                    {
                        MessageBox.Show(EX.Message);
                      
                    }
                }
            }


            //btn Lich Làm Việc của Nhan Vien;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0 && senderGrid.Columns[e.ColumnIndex].Name == "XepLich" && senderGrid.DataSource != null) 
            {
                string MaNhanVien = dataGridViewDSNV.Rows[e.RowIndex].Cells["MaNhanVien"].Value.ToString();
                string TenNhanVien = dataGridViewDSNV.Rows[e.RowIndex].Cells["TenNhanVien"].Value.ToString();
                if (MaNhanVien == "" && TenNhanVien == "")
                {

                }
                else
                {
                    XepLichNhanVien DV = new XepLichNhanVien();
                    PassDataDatVe Share = new PassDataDatVe(DV.GetPassData_FormMain);
                    Share(MaNhanVien);
                    DV.ShowDialog();
                    TileLNV_Click(sender, e);
                }
            }
        }


        //Báo Cáo Doanh Thu 
        private void DataGridViewDoanhThuBanVe()
        {
            try
            {

                SqlConnection Con = KetNoiCSDL.KetNoiSQL();
                Con.Open();
                string add = string.Format("select bv.IdVe , bv.IdChuyen ,bv.TenHanhKhach ,bv.GiaTien from BanVe bv ");
                DataTable user = new DataTable();
                SqlCommand Com = new SqlCommand(add, Con);
                SqlDataAdapter adapt = new SqlDataAdapter(Com);
                adapt.Fill(user);
                GridViewTienVe.DataSource = user;
                Con.Close();
            }
            catch (Exception EX)
            {
                MetroFramework.MetroMessageBox.Show(this, EX.Message);
            }
        }

        private void DataGridViewDoanhThuGuiHang()
        {
            try
            {

                SqlConnection Con = KetNoiCSDL.KetNoiSQL();
                Con.Open();
                string add = string.Format("select kghh.IdHangHoa,kghh.IdChuyen,kghh.TenNguoiGui,kghh.ChiPhiGui from KiGuiHangHoa kghh");
                DataTable user = new DataTable();
                SqlCommand Com = new SqlCommand(add, Con);
                SqlDataAdapter adapt = new SqlDataAdapter(Com);
                adapt.Fill(user);
                GridViewTienHang.DataSource = user;
                Con.Close();
            }
            catch (Exception EX)
            {
                MetroFramework.MetroMessageBox.Show(this, EX.Message);
            }
        }

        private void GridViewTienVe_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0 && senderGrid.Columns[e.ColumnIndex].Name == "ChiTiet" && senderGrid.DataSource != null)
            {
                string IDve = GridViewTienVe.Rows[e.RowIndex].Cells["IDVE"].Value.ToString();
                string IdChuyen = GridViewTienVe.Rows[e.RowIndex].Cells["Machuyen"].Value.ToString();
                
                if (IDve == "" && IdChuyen == "")
                {

                }
                else
                {
                    Quản_Lý.frmChiTietTienVe DV = new Quản_Lý.frmChiTietTienVe();
                    PassDataDatVe Share = new PassDataDatVe(DV.GetPassData_FormMain);
                    PassDataDatVe Share1 = new PassDataDatVe(DV.GetPassData_FormMain1);
                    Share(IDve);
                    Share1(IdChuyen);
                    DV.ShowDialog();
                   
                }

            }
        }

        private void GridViewTienHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0 && senderGrid.Columns[e.ColumnIndex].Name == "ChiTietHangHoa" && senderGrid.DataSource != null)
            {
                string IDHangHoa = GridViewTienHang.Rows[e.RowIndex].Cells["STTHangHoa"].Value.ToString();
                string IdChuyen = GridViewTienHang.Rows[e.RowIndex].Cells["MaChuyenGuiHang"].Value.ToString();
                if (IDHangHoa == "" && IdChuyen == "")
                {

                }
                else
                {

                    Quản_Lý.frmChiTietGuiHang DV = new Quản_Lý.frmChiTietGuiHang();
                    PassDataDatVe Share = new PassDataDatVe(DV.GetPassData_FormMain);
                    PassDataDatVe Share1 = new PassDataDatVe(DV.GetPassData_FormMain1);
                    Share(IDHangHoa);
                    Share1(IdChuyen);
                    DV.ShowDialog();
                    
                }

            }
        }

        //TongDoanhThu
        private void TongTien()
        {
            int TienBanVe = 0;
            int TienGuiHang = 0;
            try
            {

                SqlConnection Con = KetNoiCSDL.KetNoiSQL();
                Con.Open();
                string Ve  = string.Format("select SUM(bv.GiaTien) as Tien from BanVe bv "); //Gọi Proc
                SqlCommand Com = new SqlCommand(Ve, Con);

                TienBanVe = Convert.ToInt32(Com.ExecuteScalar());
                lblTong1.Text = "Tổng = "+TienBanVe.ToString();

                string Hang = string.Format("select SUM(hh.ChiPhiGui) as Tien from KiGuiHangHoa hh "); //Gọi Proc
                SqlCommand Com1 = new SqlCommand(Hang, Con);

                TienGuiHang = Convert.ToInt32(Com1.ExecuteScalar());
                lblTong2.Text = "Tổng = " + TienGuiHang.ToString();


                lblTongDThu.Text = "Tổng Cộng Doanh Thu: " + (TienBanVe + TienGuiHang).ToString();

                Con.Close();
                
            }
            catch (Exception EX)
            {
                MetroFramework.MetroMessageBox.Show(this, EX.Message);
            }
        }

        private void TileDT_Click(object sender, EventArgs e)
        {
            lblTitel_Click(sender, e);

            lblThuVe.Location = new Point(392, 120);
            lblDanhThuGuiHang.Location = new Point(961, 120);
            GridViewTienVe.Location = new Point(293, 160);
            GridViewTienVe.Size = new Size(478, 199);
            GridViewTienHang.Location = new Point(795, 160);
            GridViewTienHang.Size = new Size(478, 199);
            lblTong2.Location = new Point(1040, 372);
            btnBaoCaoHang.Location = new Point(945, 371);

            GridViewTienVe.Visible = true;
            GridViewTienHang.Visible = true;
            lblTong1.Visible = true;
            lblTong2.Visible = true;
            lblTongDThu.Visible = true;
            lblDanhThuGuiHang.Visible = true;
            lblThuVe.Visible = true;
            btnBaoCaoHang.Visible = true;
            btnBaoCaoVe.Visible = true;

            lblTieuTeTabQL.Visible = true;
            lblTieuTeTabQL.Text = "Báo Cáo Thống Kê Doanh Thu";

            DataGridViewDoanhThuBanVe();
            DataGridViewDoanhThuGuiHang();
            TongTien();
        }

        private void btnBaoCaoVe_Click(object sender, EventArgs e)
        {
            ThongKeDoanhThuTienHang DV = new ThongKeDoanhThuTienHang();
            DV.ShowDialog();
        }

        private void btnBaoCaoHang_Click(object sender, EventArgs e)
        {
            ThongKeDoanhThuTienVe DV = new ThongKeDoanhThuTienVe();
            DV.ShowDialog();
        }






        //-----------------------Báo Cáo Chi Phí------------------------------//
        private void DrgChiPhi()
        {
            try
            {
                SqlConnection Con = KetNoiCSDL.KetNoiSQL();
                Con.Open();
                string add = string.Format("select cp.STT , cp.TenChiPhi,cp.TongPhi from ChiPhi cp");
                DataTable user = new DataTable();
                SqlCommand Com = new SqlCommand(add, Con);
                SqlDataAdapter adapt = new SqlDataAdapter(Com);
                adapt.Fill(user);
                GridViewChiPhi.DataSource = user;
                Con.Close();
            }
            catch (Exception EX)
            {
                MetroFramework.MetroMessageBox.Show(this, EX.Message);
            }
        }

        private int TongDoanhThu()
        {
            int temp = 0;
            try
            {
                SqlConnection Con = KetNoiCSDL.KetNoiSQL();
                Con.Open();
                string add = string.Format("select Sum(cp.TongPhi) from ChiPhi cp");
                SqlCommand Com = new SqlCommand(add, Con);
                temp  =Convert.ToInt32(Com.ExecuteScalar().ToString());
                Con.Close();
                return temp;
             
            }
            catch (Exception EX)
            {
                MetroFramework.MetroMessageBox.Show(this, EX.Message);
                return temp;
            }
        }
        private void TileCP_Click(object sender, EventArgs e)
        {
            lblTitel_Click(sender, e);
            lblTieuTeTabQL.Visible = true;
            lblTieuTeTabQL.Text = "Báo Cáo Thống Kê Chi Phí";

            GridViewChiPhi.Visible = true;
            GridViewChiPhi.Location = new Point(423, 185);
            GridViewChiPhi.Size = new Size(496, 227);
            btnBaoCaoChiPhi.Visible = true;
            btnBaoCaoChiPhi.Location = new Point(940, 389);
            btnThemChiPhi.Visible = true;
            btnThemChiPhi.Location = new Point(940,365);
            lblTongDThu.Visible = true;
            lblTongDThu.Text = "Tổng Chi Phí : "+TongDoanhThu().ToString();
            DrgChiPhi();

        }
        private void btnThemChiPhi_Click(object sender, EventArgs e)
        {
            Quản_Lý.ThemChiPhi DV = new Quản_Lý.ThemChiPhi();
            DV.ShowDialog();
            TileCP_Click(sender, e);
        }
        private void btnBaoCaoChiPhi_Click(object sender, EventArgs e)
        {
           frmThongKeChiPhi DV = new frmThongKeChiPhi();
           DV.ShowDialog();
        }
        private void GridViewChiPhi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0 && senderGrid.Columns[e.ColumnIndex].Name == "btnChiPhi" && senderGrid.DataSource != null)
            {
                string STT = GridViewChiPhi.Rows[e.RowIndex].Cells["IdChiPhi"].Value.ToString();

                if (STT == "")
                {

                }
                else
                {
                   
                    Quản_Lý.ChiTietChiPhi DV = new Quản_Lý.ChiTietChiPhi();
                    PassDataDatVe Share = new PassDataDatVe(DV.GetPassData_FormMain);
                    Share(STT);
                    DV.ShowDialog();

                }
            }

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0 && senderGrid.Columns[e.ColumnIndex].Name == "btnXoa" && senderGrid.DataSource != null)
            {
                string STT = GridViewChiPhi.Rows[e.RowIndex].Cells["IdChiPhi"].Value.ToString();
                string TenChiPhi = GridViewChiPhi.Rows[e.RowIndex].Cells["TenChiPhi"].Value.ToString();
                if (STT == "")
                {

                }
                else if (MetroFramework.MetroMessageBox.Show(this, "Chắc Chắn Hay Không", string.Format("Bạn Muốn Xoá Thống Kê Chi Phí {0}", TenChiPhi), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        SqlConnection Con = KetNoiCSDL.KetNoiSQL();
                        Con.Open();
                        string Delete = string.Format("delete from ChiPhi where STT = @STT");
                       
                        DataTable user = new DataTable();
                        SqlCommand Com = new SqlCommand(Delete, Con);
                        
                        Com.Parameters.Add(new SqlParameter("@STT", STT));
                        SqlDataAdapter adapt = new SqlDataAdapter(Com);

                        adapt.Fill(user);
                   

                        Con.Close();
                        MetroFramework.MetroMessageBox.Show(this, string.Format("Đã Xoá Thống Kê Chi Phí {0}!", TenChiPhi));
                        TileCP_Click(sender, e);
                    }
                    catch (Exception EX)
                    {
                        MessageBox.Show(EX.Message);
                        
                    }

                }
            }
        }






        //-----------------------Báo Cáo Nhân Sự------------------------------//
        private void DrgNhanSu()
        {
            try
            {
                SqlConnection Con = KetNoiCSDL.KetNoiSQL();
                Con.Open();
                string add = string.Format("select nv.MaNhanVien,nv.TenNhanVien,lnv.TenLoaiNV from NhanVien nv ,LoaiNhanVien lnv where lnv.IdLoaiNV=nv.LoaiNV");
                DataTable user = new DataTable();
                SqlCommand Com = new SqlCommand(add, Con);
                SqlDataAdapter adapt = new SqlDataAdapter(Com);
                adapt.Fill(user);
                GridViewNhanSu.DataSource = user;
                Con.Close();
            }
            catch (Exception EX)
            {
                MetroFramework.MetroMessageBox.Show(this, EX.Message);
            }
        }

        private void TileNS_Click(object sender, EventArgs e)
        {
            lblTitel_Click(sender, e);
            lblTieuTeTabQL.Visible = true;
            lblTieuTeTabQL.Text = "Báo Cáo Thống Kê Nhân Sự";

            GridViewNhanSu.Visible = true;
            GridViewNhanSu.Location = new Point(423, 185);
            GridViewNhanSu.Size = new Size(481, 227);
            btnBaoCaoNhanSu.Visible = true;
            btnBaoCaoNhanSu.Location = new Point(940,389);
            DrgNhanSu();
        }

        private void GridViewNhanSu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0 && senderGrid.Columns[e.ColumnIndex].Name == "btnChiTietNV" && senderGrid.DataSource != null)
            {
                string MaNV = GridViewNhanSu.Rows[e.RowIndex].Cells["STTNV"].Value.ToString();
                
                if (MaNV == "")
                {

                }
                else
                {

                    Quản_Lý.ChiTietNhanVien DV = new Quản_Lý.ChiTietNhanVien();
                    PassDataDatVe Share = new PassDataDatVe(DV.GetPassData_FormMain);
                    Share(MaNV);
                    DV.ShowDialog();

                }

            }
        }




        private void btnBaoCaoNhanSu_Click(object sender, EventArgs e)
        {
            frmBaoCaoNhanSu DV = new frmBaoCaoNhanSu();
            DV.ShowDialog();
        }


        //----------------------BaoCaoVatTu------------------------------//

        private void DrgVatTu()
        {
            try
            {
                SqlConnection Con = KetNoiCSDL.KetNoiSQL();
                Con.Open();
                string add = string.Format("select *from VatTu");
                DataTable user = new DataTable();
                SqlCommand Com = new SqlCommand(add, Con);
                SqlDataAdapter adapt = new SqlDataAdapter(Com);
                adapt.Fill(user);
                GridViewVatTu.DataSource = user;
                Con.Close();
            }
            catch (Exception EX)
            {
                MetroFramework.MetroMessageBox.Show(this, EX.Message);
            }
        }


        private void TileVT_Click(object sender, EventArgs e)
        {
            lblTitel_Click(sender, e);
            lblTieuTeTabQL.Visible = true;
            lblTieuTeTabQL.Text = "Báo Cáo Thống Kê Vật Tư";

            GridViewVatTu.Visible = true;
            GridViewVatTu.Location = new Point(423, 185);
            GridViewVatTu.Size = new Size(481, 227);
            btnInVatTu.Visible = true;
            btnInVatTu.Location = new Point(940, 389);

            btnThemVT.Visible = true;
            btnThemVT.Location = new Point(940, 365);

            DrgVatTu();


        }

        private void GridViewVatTu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0 && senderGrid.Columns[e.ColumnIndex].Name == "btnXoaVT" && senderGrid.DataSource != null)
            {
                string MaVT = GridViewVatTu.Rows[e.RowIndex].Cells["STTVT"].Value.ToString();
                string TenVT = GridViewVatTu.Rows[e.RowIndex].Cells["TenVT"].Value.ToString();
                if (MaVT == "")
                {

                }
                else if (MetroFramework.MetroMessageBox.Show(this, "Chắc Chắn Hay Không", string.Format("Bạn Muốn Xoá {0}", TenVT), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        SqlConnection Con = KetNoiCSDL.KetNoiSQL();
                        Con.Open();
                        string Delete = string.Format("delete from VatTu where STT = @STT");
                        DataTable user = new DataTable();
                        SqlCommand Com = new SqlCommand(Delete, Con);
                        Com.Parameters.Add(new SqlParameter("@STT", MaVT));
                        SqlDataAdapter adapt = new SqlDataAdapter(Com);
                        adapt.Fill(user);

                        Con.Close();
                        MetroFramework.MetroMessageBox.Show(this, string.Format("Đã Xoá {0}!", TenVT));
                        TileVT_Click(sender, e);
                    }
                    catch (Exception EX)
                    {
                        MessageBox.Show(EX.Message);

                    }

                }
            }
        }

        private void btnThemVT_Click(object sender, EventArgs e)
        {
            Quản_Lý.ThemVatTu DV = new Quản_Lý.ThemVatTu();
            DV.ShowDialog();
            TileVT_Click(sender, e);
        }

        private void btnInVatTu_Click(object sender, EventArgs e)
        {
            frmBaoCaoVatTu DV = new frmBaoCaoVatTu();
            DV.ShowDialog();
        }


        //----------------------XepLichNhanVien------------------------------//
        private void TileLNV_Click(object sender, EventArgs e)
        {
            lblTitel_Click(sender, e);

            dataGridViewDSNV.Visible = true;
            dataGridViewDSNV.Location = new Point(235, 140);
            dataGridViewDSNV.Size = new Size(1055, 194);
            btnThemNV.Visible = true;
            btnThemNV.Location = new Point(1178, 340);
           
            lblTieuTeTabQL.Visible = true;
            lblTieuTeTabQL.Text = "Lịch Làm Việc Nhân Viên";


            SqlConnection Con = KetNoiCSDL.KetNoiSQL();
            Con.Open();

            string add = string.Format("select nv.ID,nv.MaNhanVien,nv.TenNhanVien,nv.SDT,nv.NgaySinh,nv.GioiTinh,nv.DiaChi,nv.NgayVaoLamViec,nv.KinhNghiem,nv.SoGioDaChay,lnv.IdLoaiNV,lnv.TenLoaiNV from NhanVien nv,LoaiNhanVien lnv where nv.LoaiNV=lnv.IdLoaiNV");
            DataTable user = new DataTable();
            SqlCommand Com = new SqlCommand(add, Con);

            SqlDataAdapter adapt = new SqlDataAdapter(Com);

            adapt.Fill(user);
            dataGridViewDSNV.DataSource = user; //Đổ dữ liệu vào dataGridViewDatVe

            Con.Close();

        }

        private void btnThemNV_Click(object sender, EventArgs e)
        {
            ThemNhanVienLamViec DV = new ThemNhanVienLamViec();
            DV.ShowDialog();
            this.Main_Load(sender, e);
            TileLNV_Click(sender, e);//reset dataview
        }

      
        private void Main_Load(object sender, EventArgs e)
        {
            TileDT.Text = "Thống Kê\r\n&Doanh Thu";
            TileCP.Text = "Thống Kê\r\n&Chi Phí";
            TileNS.Text = "Thống Kê\r\n&Nhân Sự";
            TileVT.Text = "Thống Kê\r\n&Vật Tư";

          

            //TileAbout.text
            TileAbout.Text = "Tên:Nguyễn Anh Kiệt   MSSV:1461426 \r\nNguyễn Quốc Việt MSSV:1461141\r\nLê Minh Tiến MSSV:1460986  \r\nPhạm Hữu Trí  MSSV:1461038\r\n Thanks For Watching !";


            //Phân Quyền
            if (GetLoaiNguoiDung() == "Nhân Viên")
            {
                this.TabMain.TabPages.Remove(this.TabQuanLy);
                //Select Tab    
                this.TabMain.SelectedTab=TabNhanVien;

                //TileNhan Viên
                TileNameNhanVien.Text = GetInfoNguoiDung().Ten;
                TileNhanVien.Image = Image.FromStream(GetImage());
                //  IconTenNV.Image = Image.FromStream(GetImage());

            }
            
            else if (GetLoaiNguoiDung() == "Quản Lý")
            {
                this.TabMain.TabPages.Remove(this.TabNhanVien);
                //Select Tab    
               this.TabMain.SelectedTab = TabQuanLy;

                //TileQuanLy

                TileNameQuanLy.Text = GetInfoNguoiDung().Ten;
                TileQuanLy.Image = Image.FromStream(GetImage());
                // IconTenQL.Image = Image.FromStream(GetImage());

            }
     

        }
        private void metroToggle1_CheckedChanged(object sender, EventArgs e)
        {
            if (metroToggle1.Checked == true)
            {
                metroTrackBar1.Value = 100;
                this.Opacity = metroTrackBar1.Value * 0.01;
            }

        }
    }
}
