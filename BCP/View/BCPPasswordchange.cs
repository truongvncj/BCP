using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BCP.View
{
    public partial class BCPPasswordchange : Form
    {
        public BCPPasswordchange()
        {
            InitializeComponent();

            txtusername.Text = Utils.getUsername();
            txtusername.Enabled = false;
        }

        private void tbchangepass_Click(object sender, EventArgs e)
        {

            if (txtnewpass.Text != txtnewconfpass.Text)
            {
                MessageBox.Show("Please check new Password !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            string connection_string = Utils.getAccessConnectionstring();
         
            OleDbConnection conn = new OleDbConnection(connection_string);
            conn.Open();
            string StringQuery = @"UPDATE tbl_Temp 
                                       SET
                                        tbl_Temp.username = @username,
                                        tbl_Temp.password = @password
                                        WHERE
                                        tbl_Temp.username = @usernamerpt
                                   AND  tbl_Temp.password = @oldpassword
                                                                ";
            OleDbCommand comm = new OleDbCommand(StringQuery, conn);

            comm.Parameters.AddWithValue("@username", txtusername.Text.ToString());
            comm.Parameters.AddWithValue("@password", txtnewconfpass.Text.ToString());
            comm.Parameters.AddWithValue("@usernamerpt", txtusername.Text.ToString());
            comm.Parameters.AddWithValue("@oldpassword", txtoldpass.Text.ToString());



            int temp = comm.ExecuteNonQuery();

            if (temp > 0)

            {
                MessageBox.Show("Password Change !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //then the data saved successfully

            }

            else

            {
                MessageBox.Show("Please check old password !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //it did not save

            }
            //

            conn.Close();

        }


    }
}
