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
    public partial class ComposeFrm : Form
    {
        SqlConnection Conn = new SqlConnection("Data Source=.;Initial Catalog=FCIDB;Integrated Security=True");
        SqlCommand Comm = new SqlCommand();
        
        public ComposeFrm()
        {
            InitializeComponent();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ComposeFrm_Load(object sender, EventArgs e)
        {

            Comm.Connection = Conn;
            Conn.Open();

            Comm.CommandType = CommandType.StoredProcedure;
            Comm.CommandText = "Sp_SelectSupports";
            SqlDataReader Rd = Comm.ExecuteReader();

            while (Rd.Read())
            {
                CmbTo.Items.Add(Rd["Support_Name"]);
            }
           
            Conn.Close();
            Rd.Close();
            

        }

        private void BtnSend_Click(object sender, EventArgs e)
        {

            if (TxtSub.Text != "")
            {
                if (TxtMsg.Text != "")
                {


                    Comm.Connection = Conn;
                    Conn.Open();

                    Comm.CommandType = CommandType.StoredProcedure;
                    Comm.CommandText = "Sp_SendMsg";

                    Comm.Parameters.AddWithValue("@St_ID", Settings.St_ID.ToString());
                    Comm.Parameters.AddWithValue("@_To",CmbTo.SelectedItem.ToString());
                    Comm.Parameters.AddWithValue("@Subj",TxtSub.Text);
                    Comm.Parameters.AddWithValue("@Msg",TxtMsg.Text);
                    Comm.Parameters.AddWithValue("@MDate",Dtp.Text);

                    Comm.ExecuteNonQuery();
                    MessageBox.Show("Message Sent To " + CmbTo.SelectedItem.ToString(),"Done");

                    Conn.Close();
                    Comm.Parameters.Clear();
                    this.Close();


                }

                else
                {
                    MessageBox.Show("Please Enter Message !", "Warning");
                }
            }
            else
            {
                MessageBox.Show("Please Enter Subject of Message !", "Warning");
            }

            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
