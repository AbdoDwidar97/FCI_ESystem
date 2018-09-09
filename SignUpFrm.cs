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
    public partial class SignUpFrm : Form
    {
        public SignUpFrm()
        {
            InitializeComponent();
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void Btn_SignUp_Click(object sender, EventArgs e)
        {
            try
            {

                if (Txt_Address.Text == "" || Txt_Email.Text == "" || Txt_Nation_Id.Text == "" || Txt_Nationality.Text == "" || Txt_Pwd.Text == "" || Txt_St_ID.Text == "" || Txt_St_Name.Text == "" || Cmb_Gender.Text == "" || Cmb_St_Level.Text == "" || Cmb_Status.Text == "")
                {
                    MessageBox.Show("Please Complete Your Data", "Error");

                    throw new Exception();
                }

                SqlConnection Conn = new SqlConnection("Data Source=.;Initial Catalog=FCIDB;Integrated Security=True");
                SqlCommand Comm = new SqlCommand();

                Protection Pro = new Protection();

                Comm.Connection = Conn;

                Comm.CommandType = CommandType.StoredProcedure;

                Comm.CommandText = "Sp_NewAccount";
                Conn.Open();

                Comm.Parameters.AddWithValue("@St_ID", Txt_St_ID.Text);
                Comm.Parameters.AddWithValue("@St_Name", Txt_St_Name.Text);
                Comm.Parameters.AddWithValue("@Status", Cmb_Status.SelectedItem);
                Comm.Parameters.AddWithValue("@St_Level", Cmb_St_Level.SelectedItem);
                Comm.Parameters.AddWithValue("@BirthDate", DTP_BirthDate.Text);
                Comm.Parameters.AddWithValue("@Address", Txt_Address.Text);
                Comm.Parameters.AddWithValue("@Nationality", Txt_Nationality.Text);
                Comm.Parameters.AddWithValue("@Nation_Id", Txt_Nation_Id.Text);
                Comm.Parameters.AddWithValue("@Email", Txt_Email.Text);
                Comm.Parameters.AddWithValue("@HighSchool", Txt_HighSchool.Text);
                Comm.Parameters.AddWithValue("@Gender", Cmb_Gender.SelectedIndex);
                Comm.Parameters.AddWithValue("@Pwd", Pro.Encrypt(Txt_Pwd.Text,Convert.ToString(Txt_St_ID.Text) + "FCI"));

                int Es = Comm.ExecuteNonQuery();

                if (Es > 0)
                {
                    MessageBox.Show("Account Created Successfully", "Done");
                }
                else
                {
                    MessageBox.Show("Some Error Occured , Try Again");
                }

                Conn.Close();
                this.Close();

            }

            catch { }

        }
    }
}
