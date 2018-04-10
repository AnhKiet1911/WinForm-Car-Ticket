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
    public partial class AutoCompeleteComboBox : ComboBox
    {
        public AutoCompeleteComboBox()
        {
            InitializeComponent();
        }
        private bool controlKey = false;


        protected override void OnKeyPress(KeyPressEventArgs e)
        {

            base.OnKeyPress(e);

            if (e.KeyChar == (int)Keys.Escape)
            {
                this.SelectedIndex = -1;
                this.Text = "";
                controlKey = true;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                controlKey = true;
            }
            else
            {
                controlKey = false;
            }
        }


        protected override void OnTextChanged(System.EventArgs e)
        {

            base.OnTextChanged(e);

            if (this.Text != "" && !controlKey)
            {
                string matchText = this.Text;
                int match = this.FindString(matchText);

                if (match != -1)
                {
                    this.SelectedIndex = match;
                    this.SelectionStart = matchText.Length;
                    this.SelectionLength = this.Text.Length - this.SelectionStart;
                }
            }
        }



    }
}
