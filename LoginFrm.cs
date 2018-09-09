using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FCI_Com
{
    public partial class LoginFrm : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=FCIDB;Integrated Security=True");
        SqlCommand Comm = new SqlCommand();


        public LoginFrm()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {

            try
            {


                Form1 Mfrm = new Form1();
                

                Protection Pro = new Protection();
                string EncrPwd = Pro.Encrypt(TxtPwd.Text, Convert.ToString(TxtID.Text) + "FCI");

                Comm.Connection = conn;
                Comm.CommandType = CommandType.StoredProcedure;

                Comm.CommandText = "Sp_Login";

                Comm.Parameters.AddWithValue("@St_ID", TxtID.Text);
                Comm.Parameters.AddWithValue("@Pwd",EncrPwd);

                conn.Open();

                SqlDataReader Rd = Comm.ExecuteReader();

                Rd.Read();

                if (Rd.HasRows)
                {
                    Settings.St_Name = Rd["St_Name"].ToString();
                    Settings.St_ID = TxtID.Text;

                    Mfrm.Show();
                    this.Close();

                }
                else
                {
                    MessageBox.Show(" Invalid ID Or Password ", "Error");
                    TxtID.Text = "";
                    TxtPwd.Text = "";

                }

                Comm.Parameters.Clear();
                conn.Close();



            }
            catch { MessageBox.Show("Please Enter Correct ID", "Error"); Application.Exit(); }
            

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignUpFrm SUfrm = new SignUpFrm();

            SUfrm.ShowDialog();

        }
    }
}
