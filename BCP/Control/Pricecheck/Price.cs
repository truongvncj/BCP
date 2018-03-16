using BCP.View;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace BCP.Control.PriceCheck
{
    class PriceRawUpload
    {

        class datainportF
        {

            public string filename { get; set; }

        }
        class datainportF2
        {

            public string filename { get; set; }
            public int programe { get; set; }

        }
        public static void showwait()
        {
            View.Caculating wat = new View.Caculating();
            wat.ShowDialog();


        }
        public void inputbasepricelist()
        {


            //      BackgroundWorker backgroundWorker1;
            //   CultureInfo provider = CultureInfo.InvariantCulture;
            //     backgroundWorker1 = new BackgroundWorker();


            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Excel File Base price excel";
            theDialog.Filter = "Excel files|*.xlsx; *.xls";
            theDialog.InitialDirectory = @"C:\";

            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                string filename = theDialog.FileName.ToString();
                //    string programe = "Y1";

                Thread t1 = new Thread(voidinputbasepricelistdetail);
                t1.IsBackground = true;
                t1.Start(new datainportF() { filename = filename });//, programe = programe});


                Thread t2 = new Thread(showwait);
                t2.Start();
                //   autoEvent.WaitOne(); //join
                t1.Join();
                if (t1.ThreadState != ThreadState.Running)
                {



                    Thread.Sleep(1996);
                    t2.Abort();
                }





            }


            // MessageBox.Show(theDialog.FileName.ToString());
            //    return true;

            //    


        }
        public void inputpromotionpricelist(int programe)
        {


            //      BackgroundWorker backgroundWorker1;
            //   CultureInfo provider = CultureInfo.InvariantCulture;
            //     backgroundWorker1 = new BackgroundWorker();
            string excelfung = "";
            if (programe == 1)
            {
                excelfung = "Proomotion Discount";
            }
            if (programe == 2)
            {
                excelfung = "Fuction Discount";
            }
            if (programe == 3)
            {
                excelfung = "Surchage Discount";
            }
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Excel File excel --- " + excelfung + " --- Progarme Code: " + programe;
            theDialog.Filter = "Excel files|*.xlsx; *.xls";
            theDialog.InitialDirectory = @"C:\";

            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                string filename = theDialog.FileName.ToString();
                //    string programe = "Y1";

                Thread t1 = new Thread(voidinputpromotionpricelistdetail);
                t1.IsBackground = true;
                t1.Start(new datainportF2() { filename = filename, programe = programe });//, programe = programe});


                Thread t2 = new Thread(showwait);
                t2.Start();
                //   autoEvent.WaitOne(); //join
                t1.Join();
                if (t1.ThreadState != ThreadState.Running)
                {



                    Thread.Sleep(1996);
                    t2.Abort();
                }





            }


            // MessageBox.Show(theDialog.FileName.ToString());
            //    return true;

            //    


        }


        public void voidinputbasepricelistdetail(object obj)
        {








            string connection_string = Utils.getAccessConnectionstring();
            string username = Utils.getUsername();
            datainportF inf = (datainportF)obj;

            string filename = inf.filename;



            bool kq = Utils.deleteAccesstable("tbl_pricebase_list");

            ExcelProvider ExcelProvide = new ExcelProvider();
            //#endregion
            System.Data.DataTable sourceData = ExcelProvide.GetDataFromExcel(filename);


            DataTable batable = new DataTable();
            batable.Columns.Add("PriceList", typeof(string));
            batable.Columns.Add("Material", typeof(string));
            batable.Columns.Add("MaterialNAme", typeof(string));
            batable.Columns.Add("Amount", typeof(double));

            batable.Columns.Add("Unit", typeof(string));
            batable.Columns.Add("UoM", typeof(string));

            batable.Columns.Add("Valid_From", typeof(DateTime));
            batable.Columns.Add("Valid_to", typeof(DateTime));




            string Pricelist = "";
            int columpricelist = 0;
            int columpmaterial = 0;
            int columname = 0;
            int columpamount = 0;
            int columunit = 0;
            int columUoM = 0;
            int columValid_From = 0;
            int columValid_to = 0;
            int headindex = 0;

            for (int rowid = 0; rowid < 20; rowid++) // basepriceValu kiem ta 20 dong dau de lấy colum
            {
                headindex = 1;
                for (int columid = 0; columid < sourceData.Columns.Count; columid++)
                {

                    string value = sourceData.Rows[rowid][columid].ToString();

                    if (value != null)
                    {

                        #region setcolum
                        if (value.Trim() == "CnTy")
                        {
                            columpricelist = columid;
                            headindex = 0;
                        }

                        if (value.Trim() == "Material")
                        {
                            if (columname == 0)
                            {
                                columpmaterial = columid;
                                headindex = 0;
                            }

                        }


                        if (value.Trim() == "Material")
                        {
                            if (columpmaterial != 0)
                            {
                                columname = columid;
                                headindex = 0;
                            }


                        }


                        if (value.Trim() == "Amount")
                        {
                            columpamount = columid;
                            headindex = 0;
                        }
                        if (value.Trim() == "Unit")
                        {
                            columunit = columid;
                            headindex = 0;
                        }

                        if (value.Trim() == "UoM")
                        {
                            columUoM = columid;
                            headindex = 0;
                        }

                        if (value.Trim() == "Valid From")
                        {
                            columValid_From = columid;
                            headindex = 0;
                        }

                        if (value.Trim() == "Valid to")
                        {
                            columValid_to = columid;
                            headindex = 0;
                        }

                        #endregion


                        // view basetable


                    }

                    //------------



                }// colum




            }// row

            for (int rowid = 0; rowid < sourceData.Rows.Count ; rowid++) // basepriceValu kiem ta 20 dong dau de lấy colum
            {

              
                #region setvalue of pricelist
                //   string valuepricelist = Utils.GetValueOfCellInExcel(worksheet, rowid, columpricelist);
                string valuepricelist = sourceData.Rows[rowid][columpricelist].ToString();
                if (headindex != 0 && valuepricelist != "" && valuepricelist != "YPR0")
                {
                    Pricelist = valuepricelist;


                }

                if (headindex != 0 && valuepricelist == "YPR0")
                {
                    double basepriceValue = double.Parse(sourceData.Rows[rowid][columpamount].ToString());
                    if (basepriceValue > 0) /// chi update các code >0
                    {

                        #region setvalue 
                        //   string valuepricelist = Utils.GetValueOfCellInExcel(worksheet, rowid, columpricelist);
                        string code = sourceData.Rows[rowid][columpmaterial].ToString();
                        if (code != "")
                        {
                            /// inser vao tbale access
                            OleDbConnection conn = new OleDbConnection(connection_string);
                            conn.Open();

                            string StringQuery = @"INSERT INTO tbl_pricebase_list( product_code,   pricebase, Unit,  Pack, fromdate, todate,  Username, MaterialName,   PriceList ) 

                                                                      VALUES ( @product_code, @pricebase, @Unit, @Pack, @fromdate, @todate, @Username, @MaterialName, @PriceList  )";
                            OleDbCommand comm = new OleDbCommand(StringQuery, conn);


                            //ADD PARAMS
                            comm.Parameters.AddWithValue("@product_code", sourceData.Rows[rowid][columpmaterial].ToString().Trim());
                            comm.Parameters.AddWithValue("@pricebase", double.Parse(sourceData.Rows[rowid][columpamount].ToString()));
                            comm.Parameters.AddWithValue("@Unit", sourceData.Rows[rowid][columunit].ToString().Trim());
                            comm.Parameters.AddWithValue("@Pack", sourceData.Rows[rowid][columUoM].ToString().Trim());

                            OleDbParameter parm = new OleDbParameter("@fromdate", OleDbType.Date);
                            parm.Value = Utils.ConvertStringSAPdotdatetoDatetime(sourceData.Rows[rowid][columValid_From].ToString());
                            comm.Parameters.Add(parm);

                            OleDbParameter parm2 = new OleDbParameter("@todate", OleDbType.Date);
                            parm2.Value = Utils.ConvertStringSAPdotdatetoDatetime(sourceData.Rows[rowid][columValid_to].ToString());
                            comm.Parameters.Add(parm2);

                            comm.Parameters.AddWithValue("@Username", username.Trim());
                            comm.Parameters.AddWithValue("@MaterialName", sourceData.Rows[rowid][columname].ToString().Trim());

                            comm.Parameters.AddWithValue("@PriceList", Pricelist.Trim());

                            try
                            {
                                //   MessageBox.Show(comm.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                int temp = comm.ExecuteNonQuery();

                                if (temp > 0)

                                {
                                    //  MessageBox.Show("Password Change !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    //then the data saved successfully

                                }

                                else

                                {
                                    MessageBox.Show("value row error :" + rowid.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    //      Thread.CurrentThread.Abort();
                                    return;
                                    //it did not save

                                }
                                //
                            }
                            catch (Exception ex)
                            {

                                MessageBox.Show("Error :" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                //    Thread.CurrentThread.Abort();
                                return;
                            }

                            /// inser vao table access


                            conn.Close();

                        }

                        #endregion

                    }

                }

                #endregion
             

            }
            //conpy to server

            //copy to server
            //   string connection_string = Utils.getConnectionstr();

            //    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            //    var typeffmain = typeof(tbl_KAbaseprice);
            //     var typeffsub = typeof(tbl_KAbaseprice);

            //    VInputchange inputcdata1 = new VInputchange("", "Base price list", dc, "tbl_KAbaseprice", "tbl_KAbaseprice", typeffmain, typeffsub, "id", "id", "");
            //    inputcdata1.ShowDialog();
            //  View.Viewdatatable TB = new View.Viewdatatable(batable, "lIST DATA");
            //  TB.ShowDialog();

            //  }
        }


        public void voidinputpromotionpricelistdetail(object obj)
        {
            datainportF2 inf = (datainportF2)obj;

            string filename = inf.filename;
            int programe = inf.programe;

            string username = Utils.getUsername();
            string connection_string = Utils.getAccessConnectionstring();




            OleDbConnection conn = new OleDbConnection(connection_string);
            //  string username = Utils.getUsername();
            //    UPDATE tbl_Temp SET tbl_Temp.username = "tr1", tbl_Temp.[password] = "124"
            //WHERE(((tbl_Temp.username) = "1"));


            string StringQuery = "DELETE FROM tbl_price_discount Where tbl_price_discount.programId = " + programe;

            //    OleDbCommand comm = new OleDbCommand("INSERT INTO databasetablename (columnname1 , columnname2 , . . .) VALUES (column1value , column2value ,  . . .)");
            conn.Open();
            OleDbCommand comm = new OleDbCommand(StringQuery, conn);

            try
            {



                int temp = comm.ExecuteNonQuery();

                if (temp > 0)

                {
                    // MessageBox.Show("Password Change !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //then the data saved successfully
                    //conn.Close();
                //    conn.Close();
                    //   return true;
                }

                else

                {
                    //MessageBox.Show("Please check old password !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 
                    //   return false;
                    //it did not save

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (conn.State==ConnectionState.Open)
            {
                conn.Close();
          //      conn.Close();
                OleDbConnection.ReleaseObjectPool();
                GC.Collect();  // I know attation

            }

            //list vn
            var listvn = new List<string>();
            // moqr connect get data

            //      string conString = Utils.getAccessConnectionstring();


            // create an open the connection     
            //     OleDbConnection conn = new OleDbConnection(conString);
            conn.Open();


            //   OleDbDataAdapter1.SelectCommand.CommandText = "SELECT * FROM tbl_Temp WHERE username = @Username AND password = @Password";
            // string Query1 = "SELECT * FROM tbl_Temp WHERE username = '" + textBox1.Text + "' AND password = '" + textBox2.Text+"'";
            // create the DataSet
            DataSet ds = new DataSet();


            // create the adapter and fill the DataSet
            OleDbDataAdapter adapter =
             new OleDbDataAdapter("SELECT  Regions FROM tbl_salesRegionList ", conn); //DISTINCT
            adapter.Fill(ds);

            // close the connection
            conn.Close();
            DataTable dt = ds.Tables[0];

            foreach (DataRow dr in dt.Rows)
            {
                //  MessageBox.Show((dr["username"].ToString()));

                listvn.Add(dr["Regions"].ToString());
            }
         

            //ds. = DBNull;
            //dt = DBNull;

            // keyaccount
            conn.Open();


            //   OleDbDataAdapter1.SelectCommand.CommandText = "SELECT * FROM tbl_Temp WHERE username = @Username AND password = @Password";
            // string Query1 = "SELECT * FROM tbl_Temp WHERE username = '" + textBox1.Text + "' AND password = '" + textBox2.Text+"'";
            // create the DataSet
            //     DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();
            var listkeyaccount = new List<string>();
            // create the adapter and fill the DataSet
            OleDbDataAdapter adapter1 =
             new OleDbDataAdapter("SELECT DISTINCT Key_Account_No FROM tbl_list_customer ", conn);
            adapter1.Fill(ds1);

            // close the connection
            conn.Close();
            DataTable dt1 = ds1.Tables[0];
            //  DataTable dt = ds.Tables[0];
            foreach (DataRow dr in dt1.Rows)
            {
                //  MessageBox.Show((dr["username"].ToString()));

                listkeyaccount.Add(dr["Key_Account_No"].ToString());
            }
            //   listvn.Add("VN");




            // listsaledistric


            conn.Open();


            //   OleDbDataAdapter1.SelectCommand.CommandText = "SELECT * FROM tbl_Temp WHERE username = @Username AND password = @Password";
            // string Query1 = "SELECT * FROM tbl_Temp WHERE username = '" + textBox1.Text + "' AND password = '" + textBox2.Text+"'";
            // create the DataSet
            //     DataSet ds = new DataSet();
            DataSet ds2 = new DataSet();
            var listsaledistric = new List<string>();
            // create the adapter and fill the DataSet
            OleDbDataAdapter adapter2 =
             new OleDbDataAdapter("SELECT DISTINCT Sales_district FROM tbl_list_customer ", conn);
            adapter2.Fill(ds2);

            // close the connection
            conn.Close();
            DataTable dt2 = ds2.Tables[0];
            //  DataTable dt = ds.Tables[0];
            foreach (DataRow dr in dt2.Rows)
            {
                //  MessageBox.Show((dr["username"].ToString()));

                listsaledistric.Add(dr["Sales_district"].ToString());
            }
            //    listvn.Add("VN");



            conn.Open();


            //   OleDbDataAdapter1.SelectCommand.CommandText = "SELECT * FROM tbl_Temp WHERE username = @Username AND password = @Password";
            // string Query1 = "SELECT * FROM tbl_Temp WHERE username = '" + textBox1.Text + "' AND password = '" + textBox2.Text+"'";
            // create the DataSet
            //     DataSet ds = new DataSet();
            var listfuction = new List<string>();
            DataSet ds3 = new DataSet();
            // create the adapter and fill the DataSet
            OleDbDataAdapter adapter3 =
             new OleDbDataAdapter("SELECT DISTINCT Sales_district FROM tbl_list_customer ", conn);
            adapter3.Fill(ds3);

            // close the connection
            conn.Close();
            DataTable dt3 = ds3.Tables[0];
            //  DataTable dt = ds.Tables[0];
            foreach (DataRow dr in dt3.Rows)
            {
                //  MessageBox.Show((dr["username"].ToString()));

                listfuction.Add(dr["Sales_district"].ToString());
            }
           



            ExcelProvider ExcelProvide = new ExcelProvider();
            //#endregion
            System.Data.DataTable sourceData = ExcelProvide.GetDataFromExcel(filename);

          


            string sales_region = "0";
            string keyaccount = "0";
            string saledistrict = "0";
            double customervalue = 0;


            string product_groupvalue = "0";
            string product_codevalue = "";

            //  double percent_amount = 0;
            double amount = 0;

            double penctamount = 0;
            //    double amount = 0;

            int product_codeid = 0;
            //     int product_nameid = 0;

            int product_groupid = 0;
            //    int product_groupnameid = 0;

            // int percent_amountid = 0;
            int amountid = 0;
            int unitid = 0;

            int UoMid = 0;

            //int customeridid = 0;
            //int keyaccountid = 0;
            int sales_regionid = 0;
            //int saledistrictid = 0;
            int colid = 0;

            int fromdateid = 0;
            int todateid = 0;

            //    int rowif = 0;

            int headindex = 0;
            bool grouproduct = false;
            bool inputtoacesss = false;

            for (int rowid = 0; rowid < sourceData.Rows.Count; rowid++)
            {
                //    headindex = 0;
                inputtoacesss = false;
                #region  // tìm headimdex
                for (int columid = 0; columid < sourceData.Columns.Count; columid++)
                {
                    string value = sourceData.Rows[rowid][columid].ToString();
                    if (value != null)
                    {

                        #region setcolum
                        if (value.Trim() == "CnTy")
                        {
                            sales_regionid = columid;
                            headindex = rowid;
                        }

                        if (value.Trim() == "Material")
                        {
                            //   product_nameid = columid;
                            colid = product_codeid;
                            product_codeid = columid;
                            grouproduct = false;
                            headindex = rowid;

                        }


                        if (value.Trim() == "Material")
                        {
                            if (colid < columid && colid != 0)
                            {
                                product_codeid = colid;
                                headindex = rowid;
                                grouproduct = false;
                            }


                        }


                        if (value.Trim() == "Matl Group")
                        {
                            colid = product_groupid;
                            product_groupid = columid;
                            //       product_groupnameid = columid;
                            grouproduct = true;
                            headindex = rowid;
                        }

                        if (value.Trim() == "Matl Group")
                        {
                            if (colid < columid && colid != 0)
                            {
                                product_groupid = colid;
                                headindex = rowid;
                                grouproduct = true;
                            }

                        }





                        if (value.Trim() == "Amount")
                        {
                            amountid = columid;
                            headindex = rowid;
                        }
                        if (value.Trim() == "Unit")
                        {
                            unitid = columid;
                            headindex = rowid;
                        }

                        if (value.Trim() == "UoM")
                        {
                            UoMid = columid;
                            headindex = rowid;
                        }

                        if (value.Trim() == "Valid From")
                        {
                            fromdateid = columid;
                            headindex = rowid;
                        }

                        if (value.Trim() == "Valid to")
                        {
                            todateid = columid;
                            headindex = rowid;
                        }

                        #endregion

                    }

                }// forcolum
                if (headindex != 0 && rowid == headindex)   // trong nhoms fuction nuew la headindex newgroup
                {


                    sales_region = "0";
                    keyaccount = "0";
                    saledistrict = "0";
                    customervalue = 0;

                }

                #endregion // tìm headimdex

                #region gắn keyaccount, sales region, dictric, 
                string sales_regionvalue = sourceData.Rows[rowid][sales_regionid].ToString();

                if (headindex != 0 && sales_regionvalue != "" && listvn.Contains(sales_regionvalue.Trim())) //|| (sales_regionvalue.Trim().Length ==8 && Utils.IsValidnumber(sales_regionvalue.Trim()))) )   // trong nhoms fuction
                {
                    sales_region = sales_regionvalue;

                }

                if (headindex != 0 && sales_regionvalue != "" && listkeyaccount.Contains(sales_regionvalue) || (sales_regionvalue.Trim().Length == 5 && Utils.IsValidnumber(sales_regionvalue.Trim())))    // trong nhoms fuction
                {

                    keyaccount = sales_regionvalue;

                }

                if (headindex != 0 && sales_regionvalue != "" && listsaledistric.Contains(sales_regionvalue.Trim()))   // trong nhoms fuction
                {
                    saledistrict = sales_regionvalue;

                }

                if (headindex != 0 && sales_regionvalue != "" && sales_regionvalue.Trim().Length >= 8 && Utils.IsValidnumber(sales_regionvalue))   // trong nhoms fuction
                {
                    customervalue = double.Parse(sales_regionvalue.ToString());

                }
                #endregion gắn keyaccount, sales region, dictric, 



                #region setvalue update vào khi ngày trong hạn và value toogr != 0
                string valuecotengaytodate = sourceData.Rows[rowid][todateid].ToString();
                if (headindex != 0 && sales_regionvalue != "" && rowid != headindex && valuecotengaytodate != "" && valuecotengaytodate != "Valid to")   // trong nhoms fuction
                {
                    #region kiem tra chi tiet và upda vào


                    DateTime ngaytodate = Utils.ConvertStringSAPdotdatetoDatetime(sourceData.Rows[rowid][todateid].ToString());
                    if (ngaytodate > DateTime.Today.AddMonths(-1)) //neu to date > = today - 1 tháng  tức là không upload các cái không dùng cho file nhỏ chạy nhanh
                    {

                        if (sourceData.Rows[rowid][product_codeid] != null && sourceData.Rows[rowid][product_codeid].ToString() != "" && grouproduct == false)
                        {
                            product_codevalue = sourceData.Rows[rowid][product_codeid].ToString().Trim();//dr["product_code"] = // Utils.GetValueOfCellInExcel(worksheet, rowid, columUoM);
                            product_groupvalue = "0";
                        }
                        else
                        {
                            product_codevalue = "0";// dr["product_code"] = "0";

                        }

                        if (sourceData.Rows[rowid][product_groupid] != null && sourceData.Rows[rowid][product_groupid].ToString() != "" && grouproduct == true)
                        {
                            product_groupvalue = sourceData.Rows[rowid][product_groupid].ToString().Trim();// Utils.GetValueOfCellInExcel(worksheet, rowid, columUoM);
                            product_codevalue = "0";
                        }
                        else
                        {
                            product_groupvalue = "0";
                        }

                        if (sourceData.Rows[rowid][unitid].ToString().Trim() == "%")
                        {

                            penctamount = double.Parse(sourceData.Rows[rowid][amountid].ToString());// Utils.GetValueOfCellInExcel(worksheet, rowid, columpamount);;
                            amount = 0;

                        }
                        else
                        {
                            penctamount = 0;
                            amount = double.Parse(sourceData.Rows[rowid][amountid].ToString());// Utils.GetValueOfCellInExcel(worksheet, rowid, columpamount);;
                        }


                        if (penctamount + amount != 0)
                        {

                            #region setvalue up vao data base

                            
                                conn.Open();
                           

                         
                           

                            string StringQuery2 = @"INSERT INTO tbl_price_discount( product_code,   product_group, percent_amount,  fromdate, todate, customerid,  keyaccount, saledistrict,   programId,   Username,   sales_region,   amount , rowExcel) 

                                                                      VALUES ( @product_code, @product_group, @percent_amount, @fromdate, @todate, @customerid, @keyaccount, @saledistrict, @programId , @Username, @sales_region, @amount , @rowExcel)";
                            OleDbCommand comm2 = new OleDbCommand(StringQuery2, conn);


                            //ADD PARAMS
                            //         (, product_group, percent_amount, fromdate, todate, customerid, keyaccount, saledistrict, programId, Username, sales_region, amount)
                            comm2.Parameters.AddWithValue("@product_code", product_codevalue.ToString());
                            comm2.Parameters.AddWithValue("@product_group", product_groupvalue); // number
                            comm2.Parameters.AddWithValue("@percent_amount", penctamount); // numbear

                            OleDbParameter parm = new OleDbParameter("@fromdate", OleDbType.Date);
                            parm.Value = Utils.ConvertStringSAPdotdatetoDatetime(sourceData.Rows[rowid][fromdateid].ToString());
                            comm2.Parameters.Add(parm);

                            OleDbParameter parm2 = new OleDbParameter("@todate", OleDbType.Date);
                            parm2.Value = Utils.ConvertStringSAPdotdatetoDatetime(sourceData.Rows[rowid][todateid].ToString());
                            comm2.Parameters.Add(parm2);
                            comm2.Parameters.AddWithValue("@customerid", customervalue.ToString());
                            comm2.Parameters.AddWithValue("@keyaccount", keyaccount);  // numbader
                            comm2.Parameters.AddWithValue("@saledistrict", saledistrict.ToString());
                            comm2.Parameters.AddWithValue("@programId", programe);  // numbear
                            comm2.Parameters.AddWithValue("@Username", username.Trim());


                            comm2.Parameters.AddWithValue("@sales_region", sales_region.Trim());


                            comm2.Parameters.AddWithValue("@amount", amount);  // numbear
                            comm2.Parameters.AddWithValue("@rowExcel", rowid);  // numbear


                            //rowExcel

                            //  comm2.Parameters.AddWithValue("@PriceList", Pricelist.Trim());

                            try
                            {
                                //   MessageBox.Show(comm.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                int temp = comm2.ExecuteNonQuery();

                                if (temp > 0)

                                {
                                    //  MessageBox.Show("Password Change !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    //then the data saved successfully

                                }

                                else

                                {
                                    MessageBox.Show("value row error :" + rowid.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    //      Thread.CurrentThread.Abort();
                                   // conn.Close();
                                    // return;
                                    //it did not save

                                }
                                //
                            }
                            catch (Exception ex)
                            {

                                MessageBox.Show("Error :" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                           //     conn.Close();
                                //    Thread.CurrentThread.Abort();
                                //    return;
                            }

                            /// inser vao table access

                           
                                
                                conn.Close();
                                OleDbConnection.ReleaseObjectPool();
                                GC.Collect();  // I know attation
                         
                            #endregion
                        }



                    }

                    #endregion kiem tra chi tiet và upda vào

                    inputtoacesss = true;
                }

                if (headindex != 0 && sales_regionvalue == "" && inputtoacesss)   // cot cuoit nhom thì refesh
                {

                    sales_region = "0";
                    keyaccount = "0";
                    saledistrict = "0";
                    customervalue = 0;
                    inputtoacesss = false;
                }





                #endregion



            } //fro row

        
        }


        public void voidimportProductexcel(object obj)
        {




            string connection_string = Utils.getAccessConnectionstring();
            string username = Utils.getUsername();
            datainportF inf = (datainportF)obj;

            string filename = inf.filename;



            bool kq = Utils.deleteAccesstable("tbl_list_product");

            ExcelProvider ExcelProvide = new ExcelProvider();
            //#endregion
            System.Data.DataTable sourceData = ExcelProvide.GetDataFromExcel(filename);

            int Codeid = -1;
            int product_typeid = -1;
            int product_groupid = -1;
            int product_Nameid = -1;
            int product_unitid = -1;
            int product_emptycodeid = -1;
            int product_emptynameid = -1;



            int headindex = -2;

            for (int rowid = 0; rowid < 5; rowid++)
            {
                // headindex = 1;
                for (int columid = 0; columid < sourceData.Columns.Count; columid++)
                {

                    string value = sourceData.Rows[rowid][columid].ToString();
                    //            MessageBox.Show(value +":"+ rowid);

                    if (value != null)
                    {

                        #region setcolum



                        if (value.Trim().Equals("product_code"))
                        {
                            Codeid = columid;
                            if (headindex < 0)
                            {
                                headindex = rowid;
                            }

                        }
                        if (value.Trim().Equals("product_type") && headindex == rowid)
                        {

                            product_typeid = columid;
                            //    headindex = 0;

                        }


                        if (value.Trim().Equals("product_group") && headindex == rowid)
                        {

                            product_groupid = columid;
                            //    headindex = 0;

                        }
                        if (value.Trim().Equals("product_Name") && headindex == rowid)
                        {

                            product_Nameid = columid;
                            //    headindex = 0;

                        }


                        if (value.Trim().Equals("product_unit") && headindex == rowid)
                        {

                            product_unitid = columid;
                            //   headindex = 0;



                        }


                        if (value.Trim().Equals("product_emptycode") && headindex == rowid)
                        {
                            product_emptycodeid = columid;

                        }
                        if (value.Trim().Equals("product_emptyname") && headindex == rowid)
                        {
                            product_emptynameid = columid;

                        }



                        #endregion

                    }


                }// colum

            } //find colum ok



            #region  nếu thiếu cột

            if (Codeid == -1)
            {
                MessageBox.Show("Thiếu cột : product_code", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            if (product_typeid == -1)
            {
                MessageBox.Show("Thiếu cột : product_type", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            if (product_groupid == -1)
            {
                MessageBox.Show("Thiếu cột : product_group", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            if (product_Nameid == -1)
            {
                MessageBox.Show("Thiếu cột : product_Name", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            if (product_unitid == -1)
            {
                MessageBox.Show("Thiếu cột : product_unit", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            if (product_emptycodeid == -1)
            {
                MessageBox.Show("Thiếu cột : product_emptycode", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (product_emptynameid == -1)
            {
                MessageBox.Show("Thiếu cột : product_emptyname", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }


            #endregion


            //     sd
            OleDbConnection conn = new OleDbConnection(connection_string);
            conn.Open();
            for (int rowixd = 0; rowixd < sourceData.Rows.Count; rowixd++)
            {

                #region setvalue 
                //   string valuepricelist = Utils.GetValueOfCellInExcel(worksheet, rowid, columpricelist);
                string code = sourceData.Rows[rowixd][Codeid].ToString();
                if (code != "" && Utils.IsValidnumber(code))
                {
                    /// inser vao tbale access


                    string StringQuery = @"INSERT INTO tbl_list_product(
                                                product_code,
                                                product_type,
                                                product_group,
                                                product_Name,
                                                product_unit,
                                                product_emptycode,
                                                product_emptyname
                                                    ) 

                                            VALUES(
                                                 @product_code,
                                                @product_type,
                                                @product_group,
                                                @product_Name,
                                                @product_unit,
                                                @product_emptycode,
                                                @product_emptyname
                                                    )";
                    OleDbCommand comm = new OleDbCommand(StringQuery, conn);


                    //ADD PARAMS
                    comm.Parameters.AddWithValue("@product_code", sourceData.Rows[rowixd][Codeid].ToString().Trim());
                    comm.Parameters.AddWithValue("@product_type", sourceData.Rows[rowixd][product_typeid].ToString().Trim());
                    comm.Parameters.AddWithValue("@product_group", sourceData.Rows[rowixd][product_groupid].ToString().Trim());
                    comm.Parameters.AddWithValue("@product_Name", sourceData.Rows[rowixd][product_Nameid].ToString().Trim());
                    comm.Parameters.AddWithValue("@product_unit", sourceData.Rows[rowixd][product_unitid].ToString().Trim());
                    comm.Parameters.AddWithValue("@product_emptycode", sourceData.Rows[rowixd][product_emptycodeid].ToString().Trim());
                    comm.Parameters.AddWithValue("@product_emptyname", sourceData.Rows[rowixd][product_emptynameid].ToString().Trim());

                    try
                    {


                        int temp = comm.ExecuteNonQuery();

                        if (temp > 0)

                        {
                            //  MessageBox.Show("Password Change !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            //then the data saved successfully

                        }

                        else

                        {
                            MessageBox.Show("value row error :" + rowixd.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                            //it did not save

                        }
                        //
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Error :" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    /// inser vao table access




                }

                #endregion

            }// row

            conn.Close();


        }


        public void inputProductlist()
        {


            //   CultureInfo provider = CultureInfo.InvariantCulture;


            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Excel File Product List of BCP format";
            theDialog.Filter = "Excel files|*.xlsx; *.xls";
            theDialog.InitialDirectory = @"C:\";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {

                //  AutoResetEvent autoEvent = new AutoResetEvent(false); //join



                string filename = theDialog.FileName.ToString();
                Thread t1 = new Thread(voidimportProductexcel);
                t1.IsBackground = true;
                t1.Start(new datainportF() { filename = filename });

                //      ThreadPool.QueueUserWorkItem(new WaitCallback(importsexcel)); //join

                // sina
                // dynamic_cast<AutoResetEvent*>(stateInfo)->Set();
                // ((AutoResetEvent)stateInfo).Set();
                Thread t2 = new Thread(showwait);
                t2.Start();
                //   autoEvent.WaitOne(); //join
                t1.Join();
                if (t1.ThreadState != ThreadState.Running)
                {





                    Thread.Sleep(1999);
                    t2.Abort();


                    //    MessageBox.Show("Upload Customer done !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }



            }





        }



    }
}





