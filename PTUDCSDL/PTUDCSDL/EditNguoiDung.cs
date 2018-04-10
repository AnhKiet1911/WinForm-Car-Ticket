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
    public partial class EditNguoiDung : MetroFramework.Forms.MetroForm
    {
        public EditNguoiDung()
        {
            InitializeComponent();

        }


        string IdNguoiDung_FormMain;

        public void GetPassData_FormMain(string str)
        {
            IdNguoiDung_FormMain = str;
        }

        private void Visible_Sao()
        {

            Sao2.Visible = false;
            Sao3.Visible = false;
        }


        private bool Compelete()
        {

            if (txtDiaChiNguoiDung.Text == "")
            {
                Sao2.Visible = true;
                return false;
            }
            if (numberTextBoxDT.Text == "")
            {
                Sao3.Visible = true;
                return false;
            }


            return true;
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Visible_Sao();
            if (Compelete() == false)
            {

            }
            else
            {
                if (MetroFramework.MetroMessageBox.Show(this, "Chắc Chắn Hay Không", "Bạn Muốn Cập Nhật Thông Tin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    EditUser();
  
                    this.Close();

                }
            }
        }

        private void EditUser()
        {
            NguoiDung NguoiDung = new NguoiDung();

            NguoiDung.DiaChi = txtDiaChiNguoiDung.Text.ToString();
            NguoiDung.SoDienThoai = numberTextBoxDT.Text.ToString();

            try
            {
                
                SqlConnection Con = KetNoiCSDL.KetNoiSQL();
                Con.Open();

                string UpdateUser = string.Format("exec EditUser @DiaChi, @SDT, @IdNguoiDung");
                DataTable user = new DataTable();

                SqlCommand Com = new SqlCommand(UpdateUser, Con);
                Com.Parameters.Add(new SqlParameter("@DiaChi", NguoiDung.DiaChi));
                Com.Parameters.Add(new SqlParameter("@SDT", NguoiDung.SoDienThoai));
                Com.Parameters.Add(new SqlParameter("@IdNguoiDung", IdNguoiDung_FormMain));

                SqlDataAdapter adapt = new SqlDataAdapter(Com);
                adapt.Fill(user);

                Con.Close();
                MetroFramework.MetroMessageBox.Show(this, string.Format("Đã Cập Nhật Thành Công Cho {0}!", NguoiDung.Ten));
            }
            catch (Exception EX)
            {
                MetroFramework.MetroMessageBox.Show(this, EX.Message);
            }
        }

    }
}
