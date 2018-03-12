using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

using System.Data.OleDb;

namespace BCP.View
{
    public partial class Login : Form
    {



        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string connection_string = Utils.getAccessConnectionstring();
            int ver = 0;
            int result = 0;
            string st1 = "";
            string st2 = "";
      //      string st3 = "";
        //    string st4 = "";
            String current = System.IO.Directory.GetCurrentDirectory();
            DataSet dataSet11 = new DataSet();

            string fileName = current + "\\AcessConnectstring.txt";
            bool kqlogin = Utils.ConnectToAccess();

            if (kqlogin)
            {

                #region  lấy string trong file connecttion


                //  MessageBox.Show("Connection is OK !", "Connection !", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // string connection_string = "";
                const Int32 BufferSize = 128;

                using (var fileStream = File.OpenRead(fileName))
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
                {
                    string line;
                    while ((line = streamReader.ReadLine()) != null)

                    {
                        string[] parts = line.Split(';');

                        st1 = parts[0].Trim();
                        st2 = parts[1].Trim();
                      //  st3 = parts[2].Trim();
                    //    st4 = parts[3].Trim();
                    }
                }
                #endregion  lấy string trong file connecttion
                // return;
            }
            else
            {
                MessageBox.Show("Lỗi đường truyền dữ liệu !", "Connection !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtusername.Text != "" & txtpassword.Text != "")
            {

                //System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter1 = new System.Data.OleDb.OleDbDataAdapter();
                // System.Data.OleDb.OleDbCommand oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
                // System.Data.OleDb.OleDbConnection oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
                // System.Data.OleDb.OleDbCommand oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
                // System.Data.OleDb.OleDbCommand oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
                // System.Data.OleDb.OleDbCommand  oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();

                string conString = Utils.getAccessConnectionstring();


                // create an open the connection     
                OleDbConnection conn = new OleDbConnection(conString);
                conn.Open();


                //   OleDbDataAdapter1.SelectCommand.CommandText = "SELECT * FROM tbl_Temp WHERE username = @Username AND password = @Password";
                // string Query1 = "SELECT * FROM tbl_Temp WHERE username = '" + textBox1.Text + "' AND password = '" + textBox2.Text+"'";
                // create the DataSet
                DataSet ds = new DataSet();

                // create the adapter and fill the DataSet
                OleDbDataAdapter adapter =
                 new OleDbDataAdapter("SELECT * FROM tbl_Temp WHERE username = '" + txtusername.Text + "' AND password = '" + txtpassword.Text + "'", conn);
                adapter.Fill(ds);

                // close the connection
                conn.Close();

                DataTable dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    //  MessageBox.Show((dr["username"].ToString()));

                    ver = int.Parse(dr["ver"].ToString());
                }
                result = dt.Rows.Count;

                #region ghi vao data pass, user, connectstring

                if (result > 0)
                {

                    //        int Ver = user.Version;
                    if (ver == 62)
                    {

                        this.Hide();
                        View.Main main = new Main(); //
                        main.Closed += (s, args) => this.Close();
                        main.Show();
                    }
                    else
                    {

                        MessageBox.Show("You are using old version \n please use the new KA Version: " + ver.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        this.Close();

                        return;
                    }



                    string s1 = st1 + ";" + st2 + ";" + txtusername.Text + ";" + txtpassword.Text;

                    using (StreamWriter sw = new StreamWriter(fileName))
                    {

                        try
                        {
                            sw.WriteLine(s1);
                            //   MessageBox.Show("OK", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception)
                        {

                            MessageBox.Show("Không ghi được, file server lost !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }




                    }

                }
                else
                {
                    MessageBox.Show("User hoặc Password bị sai !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                #endregion



                //        Model.Username user = new Model.Username();
              

            }
        }




        //    }
        //    else
        //        MessageBox.Show("Wrong Username and Password !", "Connection !", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //}
        // }







        //   }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            View.BCPServersetup stup = new BCPServersetup();
            stup.Show();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            //   textBox2.
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            //    button1.Focus();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.button1.Focus();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtpassword.Focus();
            }
        }
    }

}
