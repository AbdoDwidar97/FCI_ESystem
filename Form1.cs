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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                DialogResult Msg = MessageBox.Show("Do You want To Exit ? ","Exit", MessageBoxButtons.YesNo);

                if (Msg == DialogResult.Yes)
                {
                    Application.Exit();
                }
                else
                {
                    e.Cancel = true;
                }

            }
            catch { }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            LblName.Text = Settings.St_Name;
            LblID.Text = Settings.St_ID;


        }

        private void button8_Click(object sender, EventArgs e)
        {
            LoginFrm Lfrm = new LoginFrm();
            this.Dispose();
            Lfrm.Show();
            Settings.St_ID = "";
            Settings.St_Name = "";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ComposeFrm Cfrm = new ComposeFrm();
            Cfrm.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ProfileInfoFrm PIFrm = new ProfileInfoFrm();
            PIFrm.ShowDialog();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            RecievedFilesFrm Rfrm = new RecievedFilesFrm();
            Rfrm.ShowDialog();

        }
    }
}
