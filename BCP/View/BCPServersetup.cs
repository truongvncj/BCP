using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BCP.View
{
    public partial class BCPServersetup : Form
    {
        public BCPServersetup()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            String current = System.IO.Directory.GetCurrentDirectory();

            string fileName = current + "\\AcessConnectstring.txt";

            if (txtprovider.Text != "" && txtmdbfile.Text != "" )
            {


                //   string[] names = new string[] { "Zara Ali", "Nuha Ali" };
              //  string user = Utils.getUsername();
            //    string pass = Utils.getpassword();
                string s = txtmdbfile.Text.Trim()  + ";" + txtprovider.Text.Trim() ;

                using (StreamWriter sw = new StreamWriter(fileName))
                {

                    try
                    {
                        sw.WriteLine(s);

                        MessageBox.Show("OK done !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Không ghi được, file server lost !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                this.Close();
                //  MessageBox.Show(s);
            }
        }

        private void Serversetup_Deactivate(object sender, EventArgs e)
        {
            //    this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Access Server File:";
            theDialog.Filter = "Access files|*.mdb; *.accdb";
            theDialog.InitialDirectory = @"C:\";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {

                //  AutoResetEvent autoEvent = new AutoResetEvent(false); //join



                string filename = theDialog.FileName.ToString();
                txtmdbfile.Text = filename;
            }




        }
    }
}
