using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace BCP.Model
{


    class UsernameInfor
    {
        class datainportF
        {

            public string filename { get; set; }

        }

        class datainportFileContarcts
        {

            public string filename { get; set; }
            public string contracts { get; set; }
        }


        private void showwait()
        {
            View.Caculating wat = new View.Caculating();
            wat.ShowDialog();


        }

        public static string getUserplant()
        {


            string Userplant = "";
            string connection_string = Utils.getAccessConnectionstring();
            string userName = Utils.getUsername();

            OleDbConnection conn = new OleDbConnection(connection_string);
            conn.Open();


            //   string StringQuery = @"Select * from  tbl_list_Order where tbl_list_Order.Custype = @Custype and tbl_list_Order.Plant = @Plant and tbl_list_Order.Code = @Code";
            //   CAST(totalBal as float)

            string StringQuery = @"Select tbl_Temp.Plant from  tbl_Temp where tbl_Temp.username = @userName";//, @Customer_Code )"; //'%test%'


            OleDbCommand comm = new OleDbCommand(StringQuery, conn);

            //ADD PARAMS


            comm.Parameters.AddWithValue("@userName", userName);
            // comm.Parameters.AddWithValue("@Plant", this.shippingpoint);
            //    comm.Parameters.AddWithValue("@Customer_Code", this.Seachcode);


            //OleDbParameter parm = new OleDbParameter("@fromdate", OleDbType.Date);
            //parm.Value = fromdate;
            //comm.Parameters.Add(parm);

            //OleDbParameter parm2 = new OleDbParameter("@todate", OleDbType.Date);
            //parm2.Value = todate;
            //comm.Parameters.Add(parm2)/*;*/


            DataSet ds = new DataSet();

            // create the adapter and fill the DataSet

            // 
            OleDbDataAdapter adapter =
             new OleDbDataAdapter(comm);
            adapter.Fill(ds);
            conn.Close();
            System.Data.DataTable dt = ds.Tables[0];


            foreach (DataRow dr in dt.Rows)
            {
                //  MessageBox.Show((dr["username"].ToString()));

                Userplant = dr["Plant"].ToString();
            }

            return Userplant;








        }


        public static string getUsername()
        {
            String current = System.IO.Directory.GetCurrentDirectory();

            string fileName = current + "\\AcessConnectstring.txt";
            const Int32 BufferSize = 128;

            using (var fileStream = File.OpenRead(fileName))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
            {
                string line;
                string st3;
                while ((line = streamReader.ReadLine()) != null)

                {
                    string[] parts = line.Split(';');
                    if (parts.Count() >= 4)
                    {
                        st3 = parts[2].Trim();
                    }
                    else
                    {
                        st3 = "";
                    }
                    //       string st1 = parts[0].Trim();
                    //       string st2 = parts[1].Trim();
                    //  string st3 = parts[2].Trim();


                    string username = st3;
                    return username;



                }

                return "";

            }

        }





    }
}
