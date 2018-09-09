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
    public partial class ProfileInfoFrm : Form
    {
        SqlConnection Conn = new SqlConnection("Data Source=.;Initial Catalog=FCIDB;Integrated Security=True");
        SqlCommand Comm = new SqlCommand();

        public ProfileInfoFrm()
        {
            InitializeComponent();
        }

        private void ProfileInfoFrm_Load(object sender, EventArgs e)
        {

            Protection Pro = new Protection();

            Comm.Connection = Conn;

            Comm.CommandType = CommandType.StoredProcedure;

            Comm.CommandText = "Sp_SelectProfileDataByID";

            Comm.Parameters.AddWithValue("@St_ID", Settings.St_ID);
            Conn.Open();

            SqlDataReader Rd = Comm.ExecuteReader();
            Rd.Read();

            if (Rd.HasRows)
            {
                Txt_St_ID.Text = Rd["St_ID"].ToString();
                Txt_St_Name.Text = Rd["St_Name"].ToString();
                Cmb_St_Level.SelectedItem = Rd["St_Level"].ToString();
                DTP_BirthDate.Text = Rd["BirthDate"].ToString();
                Txt_Address.Text = Rd["Address"].ToString();
                Txt_Nationality.Text = Rd["Nationality"].ToString();
                Txt_Nation_Id.Text = Rd["Nation_Id"].ToString();
                Txt_Email.Text = Rd["Email"].ToString();
                Txt_HighSchool.Text = Rd["HighSchool"].ToString();
                Cmb_Gender.SelectedIndex = Convert.ToInt32(Rd["Gender"]);
                Txt_Pwd.Text = Pro.Decrypt(Rd["Pwd"].ToString() , Settings.St_ID + "FCI");
            }

            Comm.Parameters.Clear();
            Conn.Close();

        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {


            Protection Pro = new Protection();

            Comm.Connection = Conn;
            Comm.CommandType = CommandType.StoredProcedure;
            Comm.CommandText = "Sp_UpdateProfileInfo";
            Conn.Open();

            Comm.Parameters.AddWithValue("@St_ID",Txt_St_ID.Text);
            
            Comm.Parameters.AddWithValue("@BirthDate", DTP_BirthDate.Text);
            Comm.Parameters.AddWithValue("@Nationality", Txt_Nationality.Text);
            Comm.Parameters.AddWithValue("@Address", Txt_Address.Text);
            Comm.Parameters.AddWithValue("@Nation_Id", Txt_Nation_Id.Text);
            Comm.Parameters.AddWithValue("@Email", Txt_Email.Text);
            Comm.Parameters.AddWithValue("@HighSchool", Txt_HighSchool.Text);
            Comm.Parameters.AddWithValue("@Gender", Cmb_Gender.SelectedIndex);
            Comm.Parameters.AddWithValue("@Pwd",Pro.Encrypt(Txt_Pwd.Text,Txt_St_ID.Text + "FCI"));

            int Es =  Comm.ExecuteNonQuery();

            if (Es > 0)
            {
                MessageBox.Show("Your Profile Data Updated Successfully", "Done");
            }
            else
            {
                MessageBox.Show("Some Error Occured , Try Again","Error");
            }

            Comm.Parameters.Clear();
            Conn.Close();
            this.Close();


        }
    }
}
