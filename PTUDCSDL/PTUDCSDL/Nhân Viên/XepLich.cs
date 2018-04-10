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
    public partial class XepLich : MetroFramework.Forms.MetroForm
    {
        public XepLich()
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
            Sao5.Visible = false;
            Sao6.Visible = false;
            Sao7.Visible = false;
        }


        private bool Compelete()
        {
            if (txtIdChuyen.Text == "")
            {
                Sao1.Visible = true;
                return false;
            }
            if (txtSoXe.Text == "")
            {
                Sao2.Visible = true;
                return false;
            }
            if (txtHangXe.Text == "")
            {
                Sao3.Visible = true;
                return false;
            }
            if (txtGioDi.Text == "")
            {
                Sao4.Visible = true;
                return false;
            }
            if (txtSoChoNgoi.Text == "")
            {
                Sao5.Visible = true;
                return false;
            }
            if (txtXuatPhat.Text == "")
            {
                Sao6.Visible = true;
                return false;
            }

            if (txtDichDen.Text == "")
            {
                Sao7.Visible = true;
                return false;
            }


            return true;
        }
        private void XepLichChayXe()
        {
            try
            {
                SqlConnection Con = KetNoiCSDL.KetNoiSQL();
                Con.Open();

                Class.ChuyenXe ChuyenXe = new Class.ChuyenXe();
                //idChuyen
                ChuyenXe.IdChuyen = txtIdChuyen.Text.ToString();
                //SoXe
                ChuyenXe.SoXe = txtSoXe.Text.ToString();
                //NgayDi
                ChuyenXe.NgayDi = dateTimePicker1.Text.ToString();
                //HangXe
                ChuyenXe.HieuXe = txtHangXe.Text.ToString();
                //GioDi
                ChuyenXe.GioDi = txtGioDi.Text.ToString();
                //XuatPhat
                ChuyenXe.XuatPhat = txtXuatPhat.Text.ToString();
                //DichDen
                ChuyenXe.DichDen = txtDichDen.Text.ToString();
                //SoChoNgoi 
                ChuyenXe.SoGheTrong = Convert.ToInt32(txtSoChoNgoi.Text);



              
              
                string XepLichChay = string.Format("exec XepLichChayXe @IdChuyen,@So_Xe,@NgayDi,@Gio,@HieuXe,@SoGhe,@XuatPhat,@DiemDich");
                DataTable user = new DataTable();

                SqlCommand Com = new SqlCommand(XepLichChay, Con);

                //ThemVe
                Com.Parameters.Add(new SqlParameter("@IdChuyen", ChuyenXe.IdChuyen));
                Com.Parameters.Add(new SqlParameter("@So_Xe", ChuyenXe.SoXe));
                Com.Parameters.Add(new SqlParameter("@NgayDi",ChuyenXe.NgayDi));
                Com.Parameters.Add(new SqlParameter("@Gio", ChuyenXe.GioDi));
                Com.Parameters.Add(new SqlParameter("@HieuXe", ChuyenXe.HieuXe));
                Com.Parameters.Add(new SqlParameter("@SoGhe", ChuyenXe.SoGheTrong));
                Com.Parameters.Add(new SqlParameter("@XuatPhat", ChuyenXe.XuatPhat));
                Com.Parameters.Add(new SqlParameter("@DiemDich", ChuyenXe.DichDen));


                SqlDataAdapter adapt = new SqlDataAdapter(Com);
                adapt.Fill(user);
                Con.Close();
                MetroFramework.MetroMessageBox.Show(this, string.Format("Đã Đặt Lịch Thành Công Cho Chuyến {0}!", ChuyenXe.XuatPhat+" - "+ChuyenXe.DichDen));
            }
            catch (Exception EX)
            {
                MetroFramework.MetroMessageBox.Show(this, EX.Message);
            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Chắc Chắn Hay Không", "Bạn Muốn Thoát ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnXepLich_Click(object sender, EventArgs e)
        {
            Visible_Sao();
            if (Compelete() == false)
            {

            }
            else
            {
                if (MetroFramework.MetroMessageBox.Show(this, "Chắc Chắn Hay Không", "Bạn Muốn Đặt Lịch Này", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    XepLichChayXe();
                    XepLich_Load(sender, e);
                }
            }
        }

        private void XepLich_Load(object sender, EventArgs e)
        {
            Visible_Sao();
            txtIdChuyen.Clear();
            txtSoChoNgoi.ResetText();
            txtSoXe.Clear();
            txtXuatPhat.ResetText();
            txtDichDen.ResetText();
            txtGioDi.Clear();
            txtHangXe.ResetText();
            dateTimePicker1.ResetText();
        }
    }
}
