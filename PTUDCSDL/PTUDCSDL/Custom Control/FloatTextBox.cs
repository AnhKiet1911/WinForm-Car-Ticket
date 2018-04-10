using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTUDCSDL
{
    public partial class FloatTextBox : TextBox
    {
        public FloatTextBox()
        {
            InitializeComponent();
        }


        bool XuLyChuoi(string t)
        {
            string sub = "-";
            string plus = "+";


            if (t.LastIndexOf(sub) > 0)
            {
                return false;
            }
            if (t.LastIndexOf(plus) > 0)
            {
                return false;
            }

            char[] Arr = t.ToArray();
            int temp = 0;
            for (int i = 0; i < t.Length; i++)
            {
                if (Arr[i] == '.')
                {
                    temp++;
                }
            }
            if (temp == 2)
            {
                return false;
            }

            return true;
        }
        protected override void OnKeyPress(KeyPressEventArgs e)
        {

            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar) || e.KeyChar == '-' || e.KeyChar == '+' || e.KeyChar == '.')
            {
                if (XuLyChuoi(this.Text.Trim()) == true)
                {
                    this.ForeColor = Color.Black;
                    e.Handled = false;
                }
                else
                {
                    this.Text = this.Text.Remove(this.Text.Length - 1);
                    this.ForeColor = Color.Red;
                    this.SelectionStart = this.TextLength;
                    e.Handled = true;
                }

            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
