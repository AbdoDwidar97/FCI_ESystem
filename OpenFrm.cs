using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FCI_Com
{
    public partial class OpenFrm : Form
    {
        public OpenFrm()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            LoginFrm Lgnfrm = new LoginFrm();

            Lgnfrm.Show();
            this.Hide();
            timer1.Enabled = false;
            
            
        }
    }
}
