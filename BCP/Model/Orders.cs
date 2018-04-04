using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BCP.View;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using System.ComponentModel;
using System.Threading;
using System.Data.OleDb;
using System.Data;
using System.Data.SqlClient;

namespace BCP.Model
{
    class Orders
    {

        //  this.Ordernumber 

        public static string getUsermakeorderinShipmenttemp(int OrderNomber)
        {


            string Orderkq = "";
            string connection_string = Utils.getAccessConnectionstring();

            OleDbConnection conn = new OleDbConnection(connection_string);
            conn.Open();


            //   string StringQuery = @"Select * from  tbl_list_Order where tbl_list_Order.Custype = @Custype and tbl_list_Order.Plant = @Plant and tbl_list_Order.Code = @Code";
            //   CAST(totalBal as float)

            string StringQuery = @"Select tbl_shipment_temp.Createby from  tbl_shipment_temp where tbl_shipment_temp.OrderNumber = @OrderNumber ";//, @Customer_Code )"; //'%test%'


            OleDbCommand comm = new OleDbCommand(StringQuery, conn);

            //ADD PARAMS


            comm.Parameters.AddWithValue("@OrderNumber", OrderNomber);
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
        //    conn.Close();
            System.Data.DataTable dt = ds.Tables[0];


            foreach (DataRow dr in dt.Rows)
            {
                //  MessageBox.Show((dr["username"].ToString()));

                Orderkq = dr["Createby"].ToString();
            }

            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
                //      conn.Close();
                OleDbConnection.ReleaseObjectPool();
                GC.Collect();  // I know attation
                GC.WaitForPendingFinalizers();
            }
            return Orderkq;

        }

        public static bool deleteOrderNumber(string Ordernumber)
        {

            if (Utils.IsValidnumber(Ordernumber))
            {

                //  string st = "Delete from tbl_list_Order where tbl_list_Order.Document = @Ordernumber";
                string connection_string = Utils.getAccessConnectionstring();
                OleDbConnection conn = new OleDbConnection(connection_string);

                string StringQuery = "Delete from tbl_list_Order where tbl_list_Order.Document = @Ordernumber";
                conn.Open();
                OleDbCommand comm = new OleDbCommand(StringQuery, conn);

                comm.Parameters.AddWithValue("@Ordernumber", Ordernumber);

                //OleDbParameter parm = new OleDbParameter("@fromdate", OleDbType.Date);
                //parm.Value = fromdate;
                //comm.Parameters.Add(parm);

                //OleDbParameter parm2 = new OleDbParameter("@todate", OleDbType.Date);
                //parm2.Value = todate;
                //comm.Parameters.Add(parm2);

                int temp = comm.ExecuteNonQuery();
                conn.Close();

                if (temp > 0)

                {
                    //   MessageBox.Show("Password Change !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                    //then the data saved successfully

                }
                else
                {

                    return false;
                    //    MessageBox.Show("Please check old password !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    //it did not save

                }
                //


            }


            return false;



        }

        public static bool deleteOrdernumberCreateby(string Ordernumber, string createby)
        {

            if (Utils.IsValidnumber(Ordernumber))
            {

                //  string st = "Delete from tbl_list_Order where tbl_list_Order.Document = @Ordernumber";
                string connection_string = Utils.getAccessConnectionstring();
                OleDbConnection conn = new OleDbConnection(connection_string);

                string StringQuery = "Delete from tbl_list_Order where tbl_list_Order.Document = @Ordernumber and tbl_list_Order.Created_by = @Created_by";
                conn.Open();
                OleDbCommand comm = new OleDbCommand(StringQuery, conn);

                comm.Parameters.AddWithValue("@Ordernumber", Ordernumber);
                comm.Parameters.AddWithValue("@Created_by", createby);

                //OleDbParameter parm = new OleDbParameter("@fromdate", OleDbType.Date);
                //parm.Value = fromdate;
                //comm.Parameters.Add(parm);

                //OleDbParameter parm2 = new OleDbParameter("@todate", OleDbType.Date);
                //parm2.Value = todate;
                //comm.Parameters.Add(parm2);

                int temp = comm.ExecuteNonQuery();



                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    //      conn.Close();
                    OleDbConnection.ReleaseObjectPool();
                    GC.Collect();  // I know attation
                    GC.WaitForPendingFinalizers();
                }

                if (temp > 0)

                {
                    //   MessageBox.Show("Password Change !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                    //then the data saved successfully

                }
                else
                {

                    return false;
                    //    MessageBox.Show("Please check old password !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    //it did not save

                }
                //


            }


            return false;



        }

        public static bool makeOrdernumberTemp(string username)
        {
            // buoc 1 insert order tem với 


            bool dekq = Model.Orders.deleteOrdernumberCreateby("0", username);
            //  string st = "Delete from tbl_list_Order where tbl_list_Order.Document = @Ordernumber";
            string connection_string = Utils.getAccessConnectionstring();

            OleDbConnection conn = new OleDbConnection(connection_string);

            //   string StringQuery = "Delete from tbl_list_Order where tbl_list_Order.Document = @Ordernumber";
            conn.Open();
            string StringQuery = @"INSERT INTO tbl_list_Order( Document,   Created_by ) 
                                    VALUES ( @Document, @Created_by )";
            OleDbCommand comm = new OleDbCommand(StringQuery, conn);


            comm.Parameters.AddWithValue("@Document", "0");
            comm.Parameters.AddWithValue("@Created_by", username);

            //OleDbParameter parm = new OleDbParameter("@fromdate", OleDbType.Date);
            //parm.Value = fromdate;
            //comm.Parameters.Add(parm);

            //OleDbParameter parm2 = new OleDbParameter("@todate", OleDbType.Date);
            //parm2.Value = todate;
            //comm.Parameters.Add(parm2);

            int temp = comm.ExecuteNonQuery();

            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
                //      conn.Close();
                OleDbConnection.ReleaseObjectPool();
                GC.Collect();  // I know attation
                GC.WaitForPendingFinalizers();
            }

            if (temp > 0)

            {
                //   MessageBox.Show("Password Change !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
                //then the data saved successfully

            }
            else
            {

                return false;
                //    MessageBox.Show("Please check old password !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //it did not save

            }
            //



        }

        public static string getOrdernumbertemp()
        {
            string Ordernumbertemp = "";
            string username = Utils.getUsername();
            Model.Orders.makeOrdernumberTemp(username);


            string connection_string = Utils.getAccessConnectionstring();

            OleDbConnection conn = new OleDbConnection(connection_string);
            conn.Open();


            //   string StringQuery = @"Select * from  tbl_list_Order where tbl_list_Order.Custype = @Custype and tbl_list_Order.Plant = @Plant and tbl_list_Order.Code = @Code";
            //   CAST(totalBal as float)

            string StringQuery = @"Select tbl_list_Order.ID from  tbl_list_Order where tbl_list_Order.Document = @Document and  tbl_list_Order.Created_by = @Created_by ";//, @Customer_Code )"; //'%test%'


            OleDbCommand comm = new OleDbCommand(StringQuery, conn);

            //ADD PARAMS


            comm.Parameters.AddWithValue("@Document", "0");
            comm.Parameters.AddWithValue("@Created_by", username);
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
           // conn.Close();
            System.Data.DataTable dt = ds.Tables[0];


            foreach (DataRow dr in dt.Rows)
            {
                //  MessageBox.Show((dr["username"].ToString()));

                Ordernumbertemp = dr["ID"].ToString();
            }


            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
                //      conn.Close();
                OleDbConnection.ReleaseObjectPool();
                GC.Collect();  // I know attation
                GC.WaitForPendingFinalizers();
            }

            bool dekq = Model.Orders.deleteOrdernumberCreateby("0", username);

            return Ordernumbertemp;



        }



        //public bool deleteallprogramlist()
        //{
        //    string connection_string = Utils.getConnectionstr();
        //    var db = new LinqtoSQLDataContext(connection_string);
        //    //  var rs = from tblVat in db.tblVats
        //    //         select tblVat;

        //    db.ExecuteCommand("DELETE FROM tbl_kaprogramlist");
        //    //    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
        //    db.SubmitChanges();
        //    return true;
        //}


        //public IQueryable setlect_all(LinqtoSQLDataContext db)
        //{

        //    //var db = new LinqtoSQLDataContext(connection_string);
        //    var rs = from tbl_kaprogramlist in db.tbl_kaprogramlists
        //             select tbl_kaprogramlist;

        //    return rs;

        //}

        class datainportF
        {

            public string filename { get; set; }

        }


        private void showwait()
        {
            View.Caculating wat = new View.Caculating();
            wat.ShowDialog();


        }

        private string changevalueminus(string value)
        {

            if (value.Contains("-"))
            {
                if (value.IndexOf('-') == value.Length - 1)
                {
                    value = "-" + value.Substring(0, value.Length - 1);
                }

            }


            return value;


        }

        public static string gettaxcode(string custcode)
        {

            string taxCode = "";
            string connection_string = Utils.getAccessConnectionstring();

            OleDbConnection conn = new OleDbConnection(connection_string);
            conn.Open();


            string StringQuery = @"Select tbl_list_customer.VAT_Registration_No 
                        from  tbl_list_customer 
                        where tbl_list_customer.Customer_Code = @custcode 
                        and tbl_list_customer.Custype ='V001'
                                                        ";//, @Customer_Code )"; //'%test%'


            OleDbCommand comm = new OleDbCommand(StringQuery, conn);

            //ADD PARAMS


            comm.Parameters.AddWithValue("@custcode", custcode);


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

                taxCode = dr["VAT_Registration_No"].ToString();
            }

            return taxCode;




            // throw new NotImplementedException();
        }

        public static string getPriceList(string custcode, string salesRegion)
        {

            string PriceList = "";
            string connection_string = Utils.getAccessConnectionstring();

            OleDbConnection conn = new OleDbConnection(connection_string);
            conn.Open();


            string StringQuery = @"Select tbl_list_customer.PriceList 
                        from  tbl_list_customer 
                        where tbl_list_customer.Customer_Code = @custcode 
                        and tbl_list_customer.sales_region = @sales_region 
                        and tbl_list_customer.Custype ='V001'
                                                        ";//, @Customer_Code )"; //'%test%'


            OleDbCommand comm = new OleDbCommand(StringQuery, conn);

            //ADD PARAMS


            comm.Parameters.AddWithValue("@custcode", custcode);
            comm.Parameters.AddWithValue("@sales_region", salesRegion);


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

                PriceList = dr["PriceList"].ToString();
            }

            return PriceList;




            // throw new NotImplementedException();
        }

        public static double getBasePrice(string productcode, string custcode, string salesRegion, DateTime priceDate)
        {

            double basePice = 0;
            string pricelist = getPriceList(custcode, salesRegion);


            string connection_string = Utils.getAccessConnectionstring();

            OleDbConnection conn = new OleDbConnection(connection_string);
            conn.Open();


            string StringQuery = @"Select tbl_pricebase_list.pricebase 
                        from  tbl_pricebase_list 
                        where tbl_pricebase_list.product_code = @product_code 
                       and tbl_pricebase_list.PriceList =  @PriceList
                        and tbl_pricebase_list.fromdate <=  @priceDate1
                       and tbl_pricebase_list.todate >=  @priceDate2
                                                        ";//, @Customer_Code )"; //'%test%'


            OleDbCommand comm = new OleDbCommand(StringQuery, conn);

            //ADD PARAMS



            //OleDbParameter parm2 = new OleDbParameter("@todate", OleDbType.Date);
            //parm2.Value = todate;
            //comm.Parameters.Add(parm2);

            comm.Parameters.AddWithValue("@product_code", productcode);
            comm.Parameters.AddWithValue("@PriceList", pricelist);
            //  comm.Parameters.AddWithValue("@priceDate1", priceDate);
            OleDbParameter parm = new OleDbParameter("@priceDate1", OleDbType.Date);
            parm.Value = priceDate;
            comm.Parameters.Add(parm);
            // comm.Parameters.AddWithValue("@priceDate2", priceDate);
            OleDbParameter parm2 = new OleDbParameter("@priceDate2", OleDbType.Date);
            parm2.Value = priceDate;
            comm.Parameters.Add(parm2);

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

                basePice = double.Parse(dr["pricebase"].ToString());
            }

            return basePice;




            // throw new NotImplementedException();
        }


        public static string getSoldtocode(string orderNo)
        {
            string soldtoCode = "";
            string connection_string = Utils.getAccessConnectionstring();

            OleDbConnection conn = new OleDbConnection(connection_string);
            conn.Open();


            string StringQuery = @"Select First(tbl_list_Order.Sold_to_pt ) as Sold_to_pt
                        from  tbl_list_Order 
                        where tbl_list_Order.Document = @Document 
                      
                                                        ";//, @Customer_Code )"; //'%test%'


            OleDbCommand comm = new OleDbCommand(StringQuery, conn);

            //ADD PARAMS


            comm.Parameters.AddWithValue("@Document", orderNo);
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

                soldtoCode = dr["Sold_to_pt"].ToString().Trim();
            }

            return soldtoCode;


        }

        public static int gettaxRate(string custcode, string salesRegion)
        {


            int taxRate = 0;
            string connection_string = Utils.getAccessConnectionstring();

            OleDbConnection conn = new OleDbConnection(connection_string);
            conn.Open();


            string StringQuery = @"Select tbl_list_customer.taxRate 
                        from  tbl_list_customer 
                        where tbl_list_customer.Customer_Code = @custcode 
     and tbl_list_customer.sales_region = @sales_region 
                        and tbl_list_customer.Custype ='V001'
                                                        ";//, @Customer_Code )"; //'%test%'


            OleDbCommand comm = new OleDbCommand(StringQuery, conn);

            //ADD PARAMS


            comm.Parameters.AddWithValue("@custcode", custcode);
            comm.Parameters.AddWithValue("@sales_region", salesRegion);


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
                try
                {
                    taxRate = int.Parse(dr["taxRate"].ToString());
                }
                catch (Exception)
                {

                    taxRate = 10;
                }

            }

            return taxRate;







            //throw new NotImplementedException();
        }

        public static string getsalesDistric(string custcode, string salesRegion)
        {

            string salesDictric = "";
            string connection_string = Utils.getAccessConnectionstring();

            OleDbConnection conn = new OleDbConnection(connection_string);
            conn.Open();


            string StringQuery = @"Select tbl_list_customer.Sales_district 
                        from  tbl_list_customer 
                        where tbl_list_customer.Customer_Code = @custcode 
     and tbl_list_customer.sales_region = @sales_region 
                        and tbl_list_customer.Custype ='V001'
                                                        ";//, @Customer_Code )"; //'%test%'


            OleDbCommand comm = new OleDbCommand(StringQuery, conn);

            //ADD PARAMS


            comm.Parameters.AddWithValue("@custcode", custcode);
            comm.Parameters.AddWithValue("@sales_region", salesRegion);


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

                salesDictric = dr["Sales_district"].ToString().Trim();

            }

            return salesDictric;




        }

        public static string getKeyaccount(string custcode, string salesRegion)
        {


            string keyAccount = "";
            string connection_string = Utils.getAccessConnectionstring();

            OleDbConnection conn = new OleDbConnection(connection_string);
            conn.Open();


            string StringQuery = @"Select tbl_list_customer.Key_Account_No 
                        from  tbl_list_customer 
                        where tbl_list_customer.Customer_Code = @custcode 
     and tbl_list_customer.sales_region = @sales_region 
                        and tbl_list_customer.Custype ='V001'
                                                        ";//, @Customer_Code )"; //'%test%'


            OleDbCommand comm = new OleDbCommand(StringQuery, conn);

            //ADD PARAMS


            comm.Parameters.AddWithValue("@custcode", custcode);
            comm.Parameters.AddWithValue("@sales_region", salesRegion);


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

                keyAccount = dr["Key_Account_No"].ToString().Trim();

            }

            return keyAccount;







            // throw new NotImplementedException();
        }

        public static string getSalesregion(string orderNo)
        {

            string kqsales_region = "";
            string connection_string = Utils.getAccessConnectionstring();

            OleDbConnection conn = new OleDbConnection(connection_string);
            conn.Open();


            string StringQuery = @"Select First(tbl_list_Order.sales_region ) as sales_region
                        from  tbl_list_Order 
                        where tbl_list_Order.Document = @Document 
                      
                                                        ";//, @Customer_Code )"; //'%test%'


            OleDbCommand comm = new OleDbCommand(StringQuery, conn);

            //ADD PARAMS


            comm.Parameters.AddWithValue("@Document", orderNo);

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

                kqsales_region = dr["sales_region"].ToString().Trim();
            }

            return kqsales_region;




            //   throw new NotImplementedException();
        }

        public static double getDiscount(int discountProgramCode, string productCode, string custCode, string salesRegion, string keyAccount, double basePrice, DateTime priceDate)
        {
            // string pricelist = getPriceList(custcode, salesRegion);
            string ProductGroupcode = Model.Product.getProducgroupCode(productCode);
            string salesDictric = Model.Orders.getsalesDistric(custCode, salesRegion);

            double discountamount = 0;
            //fill theo 5 trường hop như sau

            #region       //1. get nếu code Cust_code = Cust_code ; chung trinh = truong trinh thì ok cộng các discount đó trước, ok kết thúc

            string connection_string = Utils.getAccessConnectionstring();

            OleDbConnection conn = new OleDbConnection(connection_string);
            conn.Open();

            string StringQuery = @"Select tbl_price_discount.percent_amount , 
                                tbl_price_discount.amount

                        from  tbl_price_discount 
                        where (tbl_price_discount.product_code = @product_code 
                            or tbl_price_discount.product_group = @product_group )

                        and tbl_price_discount.programId = @programId 

                       and tbl_price_discount.customerid =  @custCode

                        and tbl_price_discount.fromdate <=  @priceDate1
                       and tbl_price_discount.todate >=  @priceDate2
                                                        ";//, @Customer_Code )"; //'%test%'


            OleDbCommand comm = new OleDbCommand(StringQuery, conn);

            //ADD PARAMS


            comm.Parameters.AddWithValue("@product_code", productCode);
            comm.Parameters.AddWithValue("@product_group", ProductGroupcode);
            comm.Parameters.AddWithValue("@programId", discountProgramCode);
         
            comm.Parameters.AddWithValue("@custCode", ProductGroupcode);

 

            OleDbParameter parm = new OleDbParameter("@priceDate1", OleDbType.Date);
            parm.Value = priceDate;
            comm.Parameters.Add(parm);
            // comm.Parameters.AddWithValue("@priceDate2", priceDate);
            OleDbParameter parm2 = new OleDbParameter("@priceDate2", OleDbType.Date);
            parm2.Value = priceDate;
            comm.Parameters.Add(parm2);

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

            if (dt.Rows.Count >0 )
            {
                foreach (DataRow dr in dt.Rows)
                {
                    //  MessageBox.Show((dr["username"].ToString()));

                    discountamount = discountamount + double.Parse(dr["percent_amount"].ToString()) * basePrice / 100 + double.Parse(dr["amount"].ToString());
                }

                if (discountamount != 0)
                {
                    return discountamount;
                }
            }




            #endregion       //1. get nếu code Cust_code = Cust_code ; chung trinh = truong trinh thì ok cộng các discount đó trước, ok kết thúc

            #region        //2.1 khi 1 khong có get nếu code sales distric    trinh = truong trinh thì ok cộng các discount đó trước, ok kết thúc


            //     string connection_string = Utils.getAccessConnectionstring();

            //   OleDbConnection conn = new OleDbConnection(connection_string);
            conn.Open();

            string StringQuery5 = @"Select  tbl_price_discount.percent_amount, 
                                tbl_price_discount.amount

                        from  tbl_price_discount 
                        where (tbl_price_discount.product_code = @product_code 
                            or tbl_price_discount.product_group = @product_group )

                        and tbl_price_discount.programId = @programId 
                      
                          and tbl_price_discount.saledistrict =  @saledistrict


                        and tbl_price_discount.fromdate <=  @priceDate1
                       and tbl_price_discount.todate >=  @priceDate2
                                                        ";//, @Customer_Code )"; //'%test%'

            //   and tbl_price_discount.keyaccount =  @keyaccount
            //            comm5.Parameters.AddWithValue("@keyaccount", keyAccount);

            OleDbCommand comm5 = new OleDbCommand(StringQuery5, conn);

            //ADD PARAMS



            comm5.Parameters.AddWithValue("@product_code", productCode);
            comm5.Parameters.AddWithValue("@product_group", ProductGroupcode);
            comm5.Parameters.AddWithValue("@programId", discountProgramCode);

            comm5.Parameters.AddWithValue("@saledistrict", salesDictric);


            // public static double getDiscount(int discountProgramCode, string productCode, string custCode, string salesRegion, string keyAccount, double basePrice, DateTime priceDate)


            OleDbParameter parm51 = new OleDbParameter("@priceDate1", OleDbType.Date);
            parm51.Value = priceDate;
            comm5.Parameters.Add(parm51);
            // comm.Parameters.AddWithValue("@priceDate2", priceDate);
            OleDbParameter parm52 = new OleDbParameter("@priceDate2", OleDbType.Date);
            parm52.Value = priceDate;
            comm5.Parameters.Add(parm52);

            DataSet ds5 = new DataSet();

            // create the adapter and fill the DataSet

            // 
            OleDbDataAdapter adapter5 =
             new OleDbDataAdapter(comm5);
            adapter5.Fill(ds5);
            conn.Close();
            System.Data.DataTable dt5 = ds5.Tables[0];


            if (dt5.Rows.Count > 0)
            {
                foreach (DataRow dr in dt5.Rows)
                {
                    //  MessageBox.Show((dr["username"].ToString()));

                    discountamount = discountamount + double.Parse(dr["percent_amount"].ToString()) * basePrice / 100 + double.Parse(dr["amount"].ToString());
                }

                if (discountamount != 0)
                {
                    return discountamount;
                }

            }

            #endregion       //5. khi 1 khong có get nếu code salese region = 'VN" ;   trinh = truong trinh thì ok cộng các discount đó trước, ok kết thúc



            #region     //3. khi 1 khong có get nếu code Cust_keyaccont = Cust_keyaccont ; sales_region sales_region;  trinh = truong trinh thì ok cộng các discount đó trước, ok kết thúc

            //     string connection_string = Utils.getAccessConnectionstring();

            //   OleDbConnection conn = new OleDbConnection(connection_string);
            conn.Open();

            string StringQuery2 = @"Select tbl_price_discount.percent_amount , 
                                tbl_price_discount.amount

                        from  tbl_price_discount 
                        where (tbl_price_discount.product_code = @product_code 
                            or tbl_price_discount.product_group = @product_group )

                        and tbl_price_discount.programId = @programId 

                       and tbl_price_discount.keyaccount =  @keyaccount
                         and tbl_price_discount.sales_region =  @sales_region


                        and tbl_price_discount.fromdate <=  @priceDate1
                       and tbl_price_discount.todate >=  @priceDate2
                                                        ";//, @Customer_Code )"; //'%test%'


            OleDbCommand comm2 = new OleDbCommand(StringQuery2, conn);

            //ADD PARAMS



            comm2.Parameters.AddWithValue("@product_code", productCode);
            comm2.Parameters.AddWithValue("@product_group", ProductGroupcode);
            comm2.Parameters.AddWithValue("@programId", discountProgramCode);

            comm2.Parameters.AddWithValue("@keyaccount", keyAccount);

            comm2.Parameters.AddWithValue("@sales_region", salesRegion);

            // public static double getDiscount(int discountProgramCode, string productCode, string custCode, string salesRegion, string keyAccount, double basePrice, DateTime priceDate)


            OleDbParameter parm21 = new OleDbParameter("@priceDate1", OleDbType.Date);
            parm21.Value = priceDate;
            comm2.Parameters.Add(parm21);
            // comm.Parameters.AddWithValue("@priceDate2", priceDate);
            OleDbParameter parm22 = new OleDbParameter("@priceDate2", OleDbType.Date);
            parm22.Value = priceDate;
            comm2.Parameters.Add(parm22);

            DataSet ds2 = new DataSet();

            // create the adapter and fill the DataSet

            // 
            OleDbDataAdapter adapter2 =
             new OleDbDataAdapter(comm2);
            adapter2.Fill(ds2);
            conn.Close();
            System.Data.DataTable dt2 = ds2.Tables[0];

            if (dt2.Rows.Count > 0)
            {

                foreach (DataRow dr in dt2.Rows)
                {
                    //  MessageBox.Show((dr["username"].ToString()));

                    discountamount = discountamount + double.Parse(dr["percent_amount"].ToString()) * basePrice / 100 + double.Parse(dr["amount"].ToString());
                }

                if (discountamount != 0)
                {
                    return discountamount;
                }

            }

            #endregion    //2. khi 1 khong có get nếu code Cust_keyaccont = Cust_keyaccont ; Cust_salesdistrict Cust_salesdistrict;  trinh = truong trinh thì ok cộng các discount đó trước, ok kết thúc

            

            #region     //4. khi 1 khong có get nếu code Cust_keyaccont = Cust_keyaccont ;  sale region = vn trinh = truong trinh thì ok cộng các discount đó trước, ok kết thúc

            //     string connection_string = Utils.getAccessConnectionstring();

            //   OleDbConnection conn = new OleDbConnection(connection_string);
            conn.Open();

            string StringQuery3 = @"Select tbl_price_discount.percent_amount , 
                                tbl_price_discount.amount

                        from  tbl_price_discount 
                        where (tbl_price_discount.product_code = @product_code 
                            or tbl_price_discount.product_group = @product_group )

                        and tbl_price_discount.programId = @programId 

                       and tbl_price_discount.keyaccount =  @keyaccount
                       and tbl_price_discount.sales_region =  @sales_region


                        and tbl_price_discount.fromdate <=  @priceDate1
                       and tbl_price_discount.todate >=  @priceDate2
                                                        ";//, @Customer_Code )"; //'%test%'


            OleDbCommand comm3 = new OleDbCommand(StringQuery3, conn);

            //ADD PARAMS



            comm3.Parameters.AddWithValue("@product_code", productCode);
            comm3.Parameters.AddWithValue("@product_group", ProductGroupcode);
            comm3.Parameters.AddWithValue("@programId", discountProgramCode);

            comm3.Parameters.AddWithValue("@keyaccount", keyAccount);
            comm3.Parameters.AddWithValue("@sales_region", "VN");


            // public static double getDiscount(int discountProgramCode, string productCode, string custCode, string salesRegion, string keyAccount, double basePrice, DateTime priceDate)


            OleDbParameter parm31 = new OleDbParameter("@priceDate1", OleDbType.Date);
                parm31.Value = priceDate;
            comm3.Parameters.Add(parm31);
            // comm.Parameters.AddWithValue("@priceDate2", priceDate);
             OleDbParameter parm32 = new OleDbParameter("@priceDate2", OleDbType.Date);
              parm32.Value = priceDate;
            comm3.Parameters.Add(parm32);

            DataSet ds3 = new DataSet();

            // create the adapter and fill the DataSet

            // 
            OleDbDataAdapter adapter3 =
             new OleDbDataAdapter(comm3);
            adapter3.Fill(ds3);
            conn.Close();
            System.Data.DataTable dt3 = ds3.Tables[0];


            if (dt3.Rows.Count > 0)
            {
                foreach (DataRow dr in dt3.Rows)
                {
                    //  MessageBox.Show((dr["username"].ToString()));

                    discountamount = discountamount + double.Parse(dr["percent_amount"].ToString()) * basePrice / 100 + double.Parse(dr["amount"].ToString());
                }

                if (discountamount != 0)
                {
                    return discountamount;
                }

            }

            #endregion     //3. khi 1 khong có get nếu code Cust_keyaccont = Cust_keyaccont ;   trinh = truong trinh thì ok cộng các discount đó trước, ok kết thúc

            //salesRegion

      
            return discountamount;



        }
    }// LASS




}// NAMSPACE



