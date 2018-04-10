using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTUDCSDL
{
    public partial class Money : TextBox
    {
        public Money()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
        string FormatMoney(object money)
        {
            string str = money.ToString();
            string pattern = @"(?<a>\d*)(?<b>\d{3})*";
            Match m = Regex.Match(str, pattern, RegexOptions.RightToLeft);
            StringBuilder sb = new StringBuilder();
            foreach (Capture i in m.Groups["b"].Captures)
            {
                sb.Insert(0, "." + i.Value);
            }
            sb.Insert(0, m.Groups["a"].Value);
            return sb.ToString().Trim('.');
        }
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            string str = this.Text;
            int start = this.Text.Length - this.SelectionStart;
            str = str.Replace(".", "");
            this.Text = FormatMoney(str);
            this.SelectionStart = -start + this.Text.Length;
        }



    }
  
}
