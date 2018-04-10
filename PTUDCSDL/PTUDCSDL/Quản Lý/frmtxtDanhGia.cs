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
    public partial class frmtxtDanhGia : MetroFramework.Forms.MetroForm
    {
        public frmtxtDanhGia()
        {
            InitializeComponent();
            ControlBox = false;
        }

      

        string MaNhanVien_FormMain;
        public void GetPassData_FormMain(string str)
        {
            MaNhanVien_FormMain = str;
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
                    txtDanhGia.Text = "........";
                }
                else
                {
                    txtDanhGia.Text = Com.ExecuteScalar().ToString(); 
                }
                Con.Close();
            }
            catch (Exception EX)
            {
                MetroFramework.MetroMessageBox.Show(this, EX.Message);
            }
        }

        private void  ThemDanhGia()
        {
            try
            {
                SqlConnection Con = KetNoiCSDL.KetNoiSQL();
                Con.Open();
                string DG = string.Format("update DanhGiaNhanVien set DanhGia= @DanhGia where MaNhanVien=@MaNhanVien");

                DataTable user = new DataTable();

                SqlCommand Com = new SqlCommand(DG, Con);

                Com.Parameters.Add(new SqlParameter("@DanhGia", txtDanhGia.Text));
               
                Com.Parameters.Add(new SqlParameter("@MaNhanVien", MaNhanVien_FormMain));

                SqlDataAdapter adapt = new SqlDataAdapter(Com);


                adapt.Fill(user);

                Con.Close();
                MetroFramework.MetroMessageBox.Show(this, string.Format("OKey"), "Compelete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception EX)
            {
                MetroFramework.MetroMessageBox.Show(this, EX.Message);
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            ThemDanhGia();

            this.Close();
        }

        private void frmtxtDanhGia_Load(object sender, EventArgs e)
        {
            Loading();
        }

        private void txtDanhGia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                metroButton1_Click(sender, e);
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
