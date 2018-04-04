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


            string StringQuery = @"Select tbl_Temp.Plant from  tbl_Temp where tbl_Temp.username = @userName";//, @Customer_Code )"; //'%test%'


            OleDbCommand comm = new OleDbCommand(StringQuery, conn);

            //ADD PARAMS


            comm.Parameters.AddWithValue("@userName", userName);


            DataSet ds = new DataSet();

            // create the adapter and fill the DataSet

            // 
            OleDbDataAdapter adapter =
             new OleDbDataAdapter(comm);
            adapter.Fill(ds);

            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
                //      conn.Close();
                OleDbConnection.ReleaseObjectPool();
                GC.Collect();  // I know attation
                GC.WaitForPendingFinalizers();
            }
            System.Data.DataTable dt = ds.Tables[0];


            foreach (DataRow dr in dt.Rows)
            {
                //  MessageBox.Show((dr["username"].ToString()));

                Userplant = dr["Plant"].ToString();
            }

            return Userplant;








        }
        // OrderEntry

        public static bool getOrderEntryRight()
        {


            bool Userright = false;
            string connection_string = Utils.getAccessConnectionstring();
            string userName = Utils.getUsername();

            OleDbConnection conn = new OleDbConnection(connection_string);
            conn.Open();


            string StringQuery = @"Select tbl_Temp.OrderEntry from  tbl_Temp where tbl_Temp.username = @userName";//, @Customer_Code )"; //'%test%'


            OleDbCommand comm = new OleDbCommand(StringQuery, conn);

            //ADD PARAMS


            comm.Parameters.AddWithValue("@userName", userName);


            DataSet ds = new DataSet();

            // create the adapter and fill the DataSet

            // 
            OleDbDataAdapter adapter =
             new OleDbDataAdapter(comm);
            adapter.Fill(ds);
            conn.Close();
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
                //      conn.Close();
                OleDbConnection.ReleaseObjectPool();
                GC.Collect();  // I know attation
                GC.WaitForPendingFinalizers();
            }
            System.Data.DataTable dt = ds.Tables[0];


            foreach (DataRow dr in dt.Rows)
            {
                //  MessageBox.Show((dr["username"].ToString()));

                Userright = (bool)dr["OrderEntry"];
            }

            return Userright;








        }

        public static bool getARreleaseRight()
        {


            bool Userright = false;
            string connection_string = Utils.getAccessConnectionstring();
            string userName = Utils.getUsername();

            OleDbConnection conn = new OleDbConnection(connection_string);
            conn.Open();


            string StringQuery = @"Select tbl_Temp.ARrelease from  tbl_Temp where tbl_Temp.username = @userName";//, @Customer_Code )"; //'%test%'


            OleDbCommand comm = new OleDbCommand(StringQuery, conn);

            //ADD PARAMS


            comm.Parameters.AddWithValue("@userName", userName);


            DataSet ds = new DataSet();

            // create the adapter and fill the DataSet

            // 
            OleDbDataAdapter adapter =
             new OleDbDataAdapter(comm);
            adapter.Fill(ds);

            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
                //      conn.Close();
                OleDbConnection.ReleaseObjectPool();
                GC.Collect();  // I know attation
                GC.WaitForPendingFinalizers();
            }
            System.Data.DataTable dt = ds.Tables[0];


            foreach (DataRow dr in dt.Rows)
            {
                //  MessageBox.Show((dr["username"].ToString()));

                Userright = (bool)dr["ARrelease"];
            }

            return Userright;








        }

        public static bool getLoadmakepalletickRight()
        {


            bool Userright = false;
            string connection_string = Utils.getAccessConnectionstring();
            string userName = Utils.getUsername();

            OleDbConnection conn = new OleDbConnection(connection_string);
            conn.Open();


            string StringQuery = @"Select tbl_Temp.Loadmakepalletick from  tbl_Temp where tbl_Temp.username = @userName";//, @Customer_Code )"; //'%test%'


            OleDbCommand comm = new OleDbCommand(StringQuery, conn);

            //ADD PARAMS


            comm.Parameters.AddWithValue("@userName", userName);


            DataSet ds = new DataSet();

            // create the adapter and fill the DataSet

            // 
            OleDbDataAdapter adapter =
             new OleDbDataAdapter(comm);
            adapter.Fill(ds);

            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
                //      conn.Close();
                OleDbConnection.ReleaseObjectPool();
                GC.Collect();  // I know attation
                GC.WaitForPendingFinalizers();
            }
            System.Data.DataTable dt = ds.Tables[0];


            foreach (DataRow dr in dt.Rows)
            {
                //  MessageBox.Show((dr["username"].ToString()));

                Userright = (bool)dr["Loadmakepalletick"];
            }

            return Userright;








        }

        public static bool getPrintLoadinvoiceRight()
        {


            bool Userright = false;
            string connection_string = Utils.getAccessConnectionstring();
            string userName = Utils.getUsername();

            OleDbConnection conn = new OleDbConnection(connection_string);
            conn.Open();


            string StringQuery = @"Select tbl_Temp.PrintLoadinvoice from  tbl_Temp where tbl_Temp.username = @userName";//, @Customer_Code )"; //'%test%'


            OleDbCommand comm = new OleDbCommand(StringQuery, conn);

            //ADD PARAMS


            comm.Parameters.AddWithValue("@userName", userName);


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

                Userright = (bool)dr["PrintLoadinvoice"];
            }

            return Userright;








        }


        public static bool getSettlementRight()
        {


            bool Userright = false;
            string connection_string = Utils.getAccessConnectionstring();
            string userName = Utils.getUsername();

            OleDbConnection conn = new OleDbConnection(connection_string);
            conn.Open();


            string StringQuery = @"Select tbl_Temp.Settlement from  tbl_Temp where tbl_Temp.username = @userName";//, @Customer_Code )"; //'%test%'


            OleDbCommand comm = new OleDbCommand(StringQuery, conn);

            //ADD PARAMS


            comm.Parameters.AddWithValue("@userName", userName);


            DataSet ds = new DataSet();

            // create the adapter and fill the DataSet

            // 
            OleDbDataAdapter adapter =
             new OleDbDataAdapter(comm);
            adapter.Fill(ds);
            //    conn.Close()
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
                //      conn.Close();
                OleDbConnection.ReleaseObjectPool();
                GC.Collect();  // I know attation
                GC.WaitForPendingFinalizers();
            }
            System.Data.DataTable dt = ds.Tables[0];


            foreach (DataRow dr in dt.Rows)
            {
                //  MessageBox.Show((dr["username"].ToString()));

                Userright = (bool)dr["Settlement"];
            }

            return Userright;








        }

        public static bool getMasterDataRight()
        {


            bool Userright = false;
            string connection_string = Utils.getAccessConnectionstring();
            string userName = Utils.getUsername();

            OleDbConnection conn = new OleDbConnection(connection_string);
            conn.Open();


            string StringQuery = @"Select tbl_Temp.MasterData from  tbl_Temp where tbl_Temp.username = @userName";//, @Customer_Code )"; //'%test%'


            OleDbCommand comm = new OleDbCommand(StringQuery, conn);

            //ADD PARAMS


            comm.Parameters.AddWithValue("@userName", userName);


            DataSet ds = new DataSet();

            // create the adapter and fill the DataSet

            // 
            OleDbDataAdapter adapter =
             new OleDbDataAdapter(comm);
            adapter.Fill(ds);

            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
                //      conn.Close();
                OleDbConnection.ReleaseObjectPool();
                GC.Collect();  // I know attation
                GC.WaitForPendingFinalizers();
            }
            System.Data.DataTable dt = ds.Tables[0];


            foreach (DataRow dr in dt.Rows)
            {
                //  MessageBox.Show((dr["username"].ToString()));

                Userright = (bool)dr["MasterData"];
            }

            return Userright;








        }

        public static bool getUsersetupRight()
        {


            bool Userright = false;
            string connection_string = Utils.getAccessConnectionstring();
            string userName = Utils.getUsername();

            OleDbConnection conn = new OleDbConnection(connection_string);
            conn.Open();


            string StringQuery = @"Select tbl_Temp.Usersetup from  tbl_Temp where tbl_Temp.username = @userName";//, @Customer_Code )"; //'%test%'


            OleDbCommand comm = new OleDbCommand(StringQuery, conn);

            //ADD PARAMS


            comm.Parameters.AddWithValue("@userName", userName);


            DataSet ds = new DataSet();

            // create the adapter and fill the DataSet

            // 
            OleDbDataAdapter adapter =
             new OleDbDataAdapter(comm);
            adapter.Fill(ds);

            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
                //      conn.Close();
                OleDbConnection.ReleaseObjectPool();
                GC.Collect();  // I know attation
                GC.WaitForPendingFinalizers();
            }
            System.Data.DataTable dt = ds.Tables[0];


            foreach (DataRow dr in dt.Rows)
            {
                //  MessageBox.Show((dr["username"].ToString()));

                Userright = (bool)dr["Usersetup"];
            }

            return Userright;








        }

        //DeleteAllOrder
        public static bool getDeleteAllOrderRight()
        {


            bool Userright = false;
            string connection_string = Utils.getAccessConnectionstring();
            string userName = Utils.getUsername();

            OleDbConnection conn = new OleDbConnection(connection_string);
            conn.Open();


            string StringQuery = @"Select tbl_Temp.DeleteAllOrder from  tbl_Temp where tbl_Temp.username = @userName";//, @Customer_Code )"; //'%test%'


            OleDbCommand comm = new OleDbCommand(StringQuery, conn);

            //ADD PARAMS


            comm.Parameters.AddWithValue("@userName", userName);


            DataSet ds = new DataSet();

            // create the adapter and fill the DataSet

            // 
            OleDbDataAdapter adapter =
             new OleDbDataAdapter(comm);
            adapter.Fill(ds);

            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
                //      conn.Close();
                OleDbConnection.ReleaseObjectPool();
                GC.Collect();  // I know attation
                GC.WaitForPendingFinalizers();
            }
            System.Data.DataTable dt = ds.Tables[0];


            foreach (DataRow dr in dt.Rows)
            {
                //  MessageBox.Show((dr["username"].ToString()));

                Userright = (bool)dr["DeleteAllOrder"];
            }

            return Userright;








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
