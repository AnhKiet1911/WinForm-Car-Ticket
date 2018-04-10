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
    public partial class ThemVatTu : MetroFramework.Forms.MetroForm
    {
        public ThemVatTu()
        {
            InitializeComponent();
        }


        private void Visible_Sao()
        {
            Sao1.Visible = false;
            Sao2.Visible = false;
            Sao3.Visible = false;
        }


        private bool Compelete()
        {
            if (cbSoXe.Text == "")
            {
                Sao1.Visible = true;
                return false;
            }
            if (txtVatTu.Text == "")
            {
                Sao2.Visible = true;
                return false;
            }
            if (txtTinhTrang.Text == "")
            {
                Sao3.Visible = true;
                return false;
            }
            return true;
        }


        private void SoXe()
        {
            try
            {
                SqlConnection Con = KetNoiCSDL.KetNoiSQL();
                Con.Open();

                String Soure = String.Format("select cx.So_Xe from ChuyenXe cx");
                DataTable user = new DataTable();
                SqlCommand cmd = new SqlCommand(Soure, Con);
                SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                DataSet ChuyenDi = new DataSet();
                adapt.Fill(ChuyenDi);
                cbSoXe.DataSource = ChuyenDi.Tables[0]; //Đổ dữ liệu vào Combobox 
                cbSoXe.DisplayMember = "So_Xe";
                cbSoXe.ValueMember = "So_Xe";
                Con.Close();
            }
            catch (Exception EX)
            {
                MetroFramework.MetroMessageBox.Show(this, EX.Message);
            }
        }

        private void Them(string SoXe, string Ten, string TinhTrang)
        {
            try
            {
                SqlConnection Con = KetNoiCSDL.KetNoiSQL();
                Con.Open();



                string ThemVT = string.Format("insert into VatTu(So_Xe,ThietBiVatTu,TinhTrang) values (@SoXe,@TBVT,@TinhTrang)");
                DataTable user = new DataTable();

                SqlCommand Com = new SqlCommand(ThemVT, Con);


                Com.Parameters.Add(new SqlParameter("@SoXe", SoXe));
                Com.Parameters.Add(new SqlParameter("@TBVT", Ten));
                Com.Parameters.Add(new SqlParameter("@TinhTrang", TinhTrang));

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


        private void TheVatTu_Load(object sender, EventArgs e)
        {
            SoXe();
            btnDatVe.Select();
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
                
                Them(cbSoXe.Text, txtVatTu.Text,txtTinhTrang.Text);
                this.Close();
            }
        }
    }
}
