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
    public partial class ChiTietChiPhi : MetroFramework.Forms.MetroForm
    {
        public ChiTietChiPhi()
        {
            InitializeComponent();
           
        }

        string STT_FormMain;

        public void GetPassData_FormMain(string str)
        {
            STT_FormMain = str;
        }


        private void Loading()
        {
            try
            {
                SqlConnection Con = KetNoiCSDL.KetNoiSQL();
                Con.Open();

            
                //LayTenChiPhi
                string TenChiPhi = string.Format("select cp.TenChiPhi  from ChiPhi cp where cp.STT=@STT"); //Gọi Proc
                SqlCommand Com = new SqlCommand(TenChiPhi, Con);
                Com.Parameters.Add(new SqlParameter("@STT", STT_FormMain));
                
                lblTen.Text = Com.ExecuteScalar().ToString();

                //LấyChiTiet
                string ChiTiet = string.Format("select cp.ChiTietChiPhi  from ChiPhi cp where cp.STT=@STT"); //Gọi Proc
                Com = new SqlCommand(ChiTiet, Con);
                Com.Parameters.Add(new SqlParameter("@STT", STT_FormMain));
                lblChiTiet.Text = Com.ExecuteScalar().ToString();

                //LấyTien
                string Tien = string.Format("select cp.TongPhi  from ChiPhi cp where cp.STT=@STT"); //Gọi Proc
                Com = new SqlCommand(Tien, Con);
                Com.Parameters.Add(new SqlParameter("@STT", STT_FormMain));
                lbltien.Text = Com.ExecuteScalar().ToString();
                Con.Close();
            }
            catch (Exception EX)
            {
                MetroFramework.MetroMessageBox.Show(this, EX.Message);
            }
        }

        private void ChiTietChiPhi_Load(object sender, EventArgs e)
        {
            Loading();
            lblMa.Text = STT_FormMain;
        }

       
    }
}
