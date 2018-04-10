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
    public partial class ThemChiPhi : MetroFramework.Forms.MetroForm
    {
        public ThemChiPhi()
        {
            InitializeComponent();
            ControlBox = false;
        }

        private void Visible_Sao()
        {
            Sao1.Visible = false;
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
            if (txtChiTiet.Text == "")
            {
                Sao2.Visible = true;
                return false;
            }
            if (txtTien.Text == "")
            {
                Sao3.Visible = true;
                return false;
            }
            return true;
        }


        private void Them(string Ten, string ChiTiet, int Tong)
        {



            try
            {
                SqlConnection Con = KetNoiCSDL.KetNoiSQL();
                Con.Open();



                string ThemCP = string.Format("insert into ChiPhi(TenChiPhi,ChiTietChiPhi,TongPhi) values (@Ten,@ChiTiet,@Tien)");
                DataTable user = new DataTable();

                SqlCommand Com = new SqlCommand(ThemCP, Con);


                Com.Parameters.Add(new SqlParameter("@Ten", Ten));
                Com.Parameters.Add(new SqlParameter("@ChiTiet", ChiTiet));
                Com.Parameters.Add(new SqlParameter("@Tien", Tong));

                SqlDataAdapter adapt = new SqlDataAdapter(Com);
                adapt.Fill(user);
                Con.Close();
                MetroFramework.MetroMessageBox.Show(this, string.Format("Okey Đã Thêm {0}!", Ten));

            }
            catch (Exception EX)
            {
                MetroFramework.MetroMessageBox.Show(this, EX.Message);
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
                string temp = txtTien.Text.Replace(".", "");
                Them(txtTen.Text, txtChiTiet.Text, Convert.ToInt32(temp));
                this.Close();
            }
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
