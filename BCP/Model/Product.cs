using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BCP.View;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using System.Data.OleDb;
using System.Threading;
using System.Data.SqlClient;
using System.Data;

namespace BCP.Model
{
    class Product
    {
        public static string productName(string productCode)
        {


            string productName = "";
            string connection_string = Utils.getAccessConnectionstring();

            OleDbConnection conn = new OleDbConnection(connection_string);
            conn.Open();


            //   string StringQuery = @"Select * from  tbl_list_Order where tbl_list_Order.Custype = @Custype and tbl_list_Order.Plant = @Plant and tbl_list_Order.Code = @Code";
            //   CAST(totalBal as float)

            string StringQuery = @"Select tbl_list_product.product_Name from  tbl_list_product where tbl_list_product.product_code = @product_code ";//, @Customer_Code )"; //'%test%'


            OleDbCommand comm = new OleDbCommand(StringQuery, conn);

            //ADD PARAMS


            comm.Parameters.AddWithValue("@product_code", productCode);
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

                productName = dr["product_Name"].ToString();
            }

            return productName;

        }

        public static string productEmptycode(string productCode)
        {


            string productEmptycode = "";
            string connection_string = Utils.getAccessConnectionstring();

            OleDbConnection conn = new OleDbConnection(connection_string);
            conn.Open();


            //   string StringQuery = @"Select * from  tbl_list_Order where tbl_list_Order.Custype = @Custype and tbl_list_Order.Plant = @Plant and tbl_list_Order.Code = @Code";
            //   CAST(totalBal as float)

            string StringQuery = @"Select tbl_list_product.product_emptycode from  tbl_list_product where tbl_list_product.product_code = @product_code ";//, @Customer_Code )"; //'%test%'


            OleDbCommand comm = new OleDbCommand(StringQuery, conn);

            //ADD PARAMS


            comm.Parameters.AddWithValue("@product_code", productCode);
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

                productEmptycode = dr["product_emptycode"].ToString();
            }

            return productEmptycode;

        }
        public static string productEmptyName(string productCode)
        {


            string productEmptyName = "";
            string connection_string = Utils.getAccessConnectionstring();

            OleDbConnection conn = new OleDbConnection(connection_string);
            conn.Open();


            //   string StringQuery = @"Select * from  tbl_list_Order where tbl_list_Order.Custype = @Custype and tbl_list_Order.Plant = @Plant and tbl_list_Order.Code = @Code";
            //   CAST(totalBal as float)

            string StringQuery = @"Select tbl_list_product.product_emptyname from  tbl_list_product where tbl_list_product.product_code = @product_code ";//, @Customer_Code )"; //'%test%'


            OleDbCommand comm = new OleDbCommand(StringQuery, conn);

            //ADD PARAMS


            comm.Parameters.AddWithValue("@product_code", productCode);
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

                productEmptyName = dr["product_emptyname"].ToString();
            }

            return productEmptyName;

        }
        public static string productUnit(string productCode)
        {


            string productUnit = "";
            string connection_string = Utils.getAccessConnectionstring();

            OleDbConnection conn = new OleDbConnection(connection_string);
            conn.Open();


            //   string StringQuery = @"Select * from  tbl_list_Order where tbl_list_Order.Custype = @Custype and tbl_list_Order.Plant = @Plant and tbl_list_Order.Code = @Code";
            //   CAST(totalBal as float)

            string StringQuery = @"Select tbl_list_product.product_unit from  tbl_list_product where tbl_list_product.product_code = @product_code ";//, @Customer_Code )"; //'%test%'


            OleDbCommand comm = new OleDbCommand(StringQuery, conn);

            //ADD PARAMS


            comm.Parameters.AddWithValue("@product_code", productCode);
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

                productUnit = dr["product_unit"].ToString();
            }

            return productUnit;

        }

        class datainportF
        {

            public string filename { get; set; }

        }

    


        private void showwait()
        {
            View.Caculating wat = new View.Caculating();
            wat.ShowDialog();


        }

        public static string getemptyUnit(string productCode)
        {


            string emptyUnit = "";
            string connection_string = Utils.getAccessConnectionstring();

            OleDbConnection conn = new OleDbConnection(connection_string);
            conn.Open();


            //   string StringQuery = @"Select * from  tbl_list_Order where tbl_list_Order.Custype = @Custype and tbl_list_Order.Plant = @Plant and tbl_list_Order.Code = @Code";
            //   CAST(totalBal as float)

            string StringQuery = @"Select tbl_list_product.product_unit from  tbl_list_product where tbl_list_product.product_code = @product_code ";//, @Customer_Code )"; //'%test%'


            OleDbCommand comm = new OleDbCommand(StringQuery, conn);

            //ADD PARAMS


            comm.Parameters.AddWithValue("@product_code", productCode);
         
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

                emptyUnit = dr["product_unit"].ToString();
            }

            return emptyUnit;
        }

        public static string getProducgroupCode(string productCode)
        {


            string ProducgroupCode = "";
            string connection_string = Utils.getAccessConnectionstring();

            OleDbConnection conn = new OleDbConnection(connection_string);
            conn.Open();

            
            string StringQuery = @"Select tbl_list_product.product_group from  tbl_list_product where tbl_list_product.product_code = @product_code ";//, @Customer_Code )"; //'%test%'


            OleDbCommand comm = new OleDbCommand(StringQuery, conn);

            //ADD PARAMS


            comm.Parameters.AddWithValue("@product_code", productCode);
          


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

                ProducgroupCode = dr["product_group"].ToString();
            }

            return ProducgroupCode;





            //throw new NotImplementedException();
        }
    } // en class
} // endname space
