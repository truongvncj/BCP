using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BCP.shared;
using System.Windows.Forms;
//using Microsoft.Office.Interop.Excel;
using System.Threading;
using System.Data.OleDb;
using System.Data;
using Microsoft.Office.Interop.Excel;
using System.Data.SqlClient;

namespace BCP.Model
{
    class customerinput_ctrl
    {


        public IQueryable customersetlect_all(LinqtoSQLDataContext db)
        {

            //  var db = new LinqtoSQLDataContext(connection_string);
            var rs = from tbl_KaCustomer in db.tbl_KaCustomers
                     orderby tbl_KaCustomer.Customer
                     select tbl_KaCustomer;

            return rs;

        }

        public bool customerdeleted()
        {
            #region // xóa data bảng tblCustomer
            string connection_string = Utils.getConnectionstr();
            var db = new LinqtoSQLDataContext(connection_string);

            db.ExecuteCommand("DELETE FROM tbl_KaCustomer");
            //    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
            db.SubmitChanges();



            return true;
            #endregion

        }


        class datainportF
        {

            public string filename { get; set; }

        }

        private void importsexcel2(object obj)
        {
            string connection_string = Utils.getConnectionstr();
            var db = new LinqtoSQLDataContext(connection_string);

            db.ExecuteCommand("DELETE FROM tbl_KaCustomer");
            //    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
            db.SubmitChanges();


            datainportF inf = (datainportF)obj;
            string filename = inf.filename;

            string connectionString = "";
            if (filename.Contains(".xlsx") || filename.Contains(".XLSX"))
            {
                connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filename + ";" + "Extended Properties=Excel 12.0;";
            }
            else
            {
                connectionString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source= " + filename + ";" + "Extended Properties=Excel 8.0;";
            }
            //---------------fill data

            System.Data.DataTable sourceData = new System.Data.DataTable();
            using (OleDbConnection conn =
                                   new OleDbConnection(connectionString))
            {
                try
                {

                    conn.Open();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString(), "Thông báo lỗi Fill", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                // Get the data from the source table as a SqlDataReader.

                //  Customer	Vendor	SalesOrg	FullName	TradingName	Street	District	City	Telephone1	Telephone2	FaxNumber	VATregistrationNo	Indirect	CustomerGroup	SALORG_CTR

                OleDbCommand command = new OleDbCommand(
                                        @"SELECT Customer, 
                                    SalesOrg, 
FullName, 
TradingName ,
  Street,
District,
City ,    Telephone1,  VATregistrationNo, Indirect, 
    SALORG_CTR  FROM [Sheet1$]

                                     WHERE  (Customer IS NOT NULL)", conn);


                OleDbDataAdapter adapter = new OleDbDataAdapter(command);
                try
                {
                    adapter.Fill(sourceData);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString(), "Thông báo lỗi Fill", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


                conn.Close();
            }

            ///     Utils util = new Utils();
            string destConnString = Utils.getConnectionstr();
            //      sourceData.Columns.Add("SapCode");
            //        sourceData.Columns["SapCode"].DefaultValue = true;
            //---------------fill data


            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(destConnString))
            {

                //            @"SELECT BU, CCDescription,
                //                                CConsumption, CentralOrBlk, CHN ,
                //                               City, CreatedOn, CTDescription ,
                //                               Customer, District, FullNameN ,
                //                               KAGROUP, KANAME, KeyAcc ,
                //                               OrBlk, PaymentTerms, PriceList ,
                //  ReconciliationAcct, Region, SalesDistrict ,
                //  SalesOrg, Street, Telephone1 ,
                //  UPDDAT, VATregistrationNo  FROM [Sheet1$]
                //  
                //  	Vendor			Telephone2	FaxNumber				
                bulkCopy.BulkCopyTimeout = 0;
                bulkCopy.DestinationTableName = "tbl_KaCustomer";
                // Write from the source to the destination.
                bulkCopy.ColumnMappings.Add("Customer", "Customer");
                bulkCopy.ColumnMappings.Add("SalesOrg", "Region");
                bulkCopy.ColumnMappings.Add("FullName", "FullNameN");
                bulkCopy.ColumnMappings.Add("TradingName", "KANAME");
                bulkCopy.ColumnMappings.Add("Street", "Street");
                bulkCopy.ColumnMappings.Add("District", "District");
                bulkCopy.ColumnMappings.Add("City", "City");
                bulkCopy.ColumnMappings.Add("Telephone1", "Telephone1");
                bulkCopy.ColumnMappings.Add("VATregistrationNo", "VATregistrationNo");

                //    bulkCopy.ColumnMappings.Add("CustomerGroup", "CustomerGroup");

                bulkCopy.ColumnMappings.Add("Indirect", "indirectCode");
                bulkCopy.ColumnMappings.Add("SALORG_CTR", "SALORG_CTR");




                //bulkCopy.ColumnMappings.Add("BU", "BU");
                //bulkCopy.ColumnMappings.Add("CCDescription", "CCDescription");
                //bulkCopy.ColumnMappings.Add("CConsumption", "CConsumption");
                //bulkCopy.ColumnMappings.Add("CentralOrBlk", "CentralOrBlk");
                //bulkCopy.ColumnMappings.Add("CHN", "CHN");


                //bulkCopy.ColumnMappings.Add("CreatedOn", "CreatedOn");
                //bulkCopy.ColumnMappings.Add("CTDescription", "CTDescription");



                //bulkCopy.ColumnMappings.Add("KAGROUP", "KAGROUP");

                //bulkCopy.ColumnMappings.Add("KeyAcc", "KeyAcc");
                //bulkCopy.ColumnMappings.Add("OrBlk", "OrBlk");
                //bulkCopy.ColumnMappings.Add("PaymentTerms", "PaymentTerms");
                //bulkCopy.ColumnMappings.Add("PriceList", "PriceList");

                //bulkCopy.ColumnMappings.Add("ReconciliationAcct", "ReconciliationAcct");

                //bulkCopy.ColumnMappings.Add("SalesDistrict", "SalesDistrict");



                //bulkCopy.ColumnMappings.Add("UPDDAT", "UPDDAT");




                try
                {
                    bulkCopy.WriteToServer(sourceData);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString(), "Thông báo lỗi !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Thread.CurrentThread.Abort();
                }

            }


            //   Thread.CurrentThread.Abort();

        }


        public void importsexceltoPricingcheck(object obj)
        {




            string connection_string = Utils.getAccessConnectionstring();
            string username = Utils.getUsername();
            datainportF inf = (datainportF)obj;

            string filename = inf.filename;



            bool kq = Utils.deleteAccesstable("tbl_list_customer");

            ExcelProvider ExcelProvide = new ExcelProvider();
            //#endregion

            System.Data.DataTable sourceData = ExcelProvide.GetDataFromExcel(filename);


            int Customerid = -1;
            int Salesogid = -1;
            int Nameid = -1;
            int Houseid = -1;
            int Streetid = -1;
            int Cityid = -1;
            int telephoneid = -1;
            int salesofficeid = -1;

            int Deliveringid = -1;

            int Accountgroupid = -1;

            int Priceid = -1;

            int Keyid = -1;
            int Salesdistid = -1;
      //      int Createdonid = -1;
     //       int Createdbyid = -1;
            int VATid = -1;
       //     int orderblockid = -1;
         //   int salesblockid = -1;


            //     View.Viewdatatable vi1 = new View.Viewdatatable(sourceData, "Test");

            //     vi1.ShowDialog();
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
                        if (value.Trim().Equals("Customer"))
                        {
                            Customerid = columid;
                            if (headindex <0)
                            {
                                headindex = rowid;
                            }

                        }

                        if (value.Trim().Equals("Account group") && headindex == rowid)
                        {

                            Accountgroupid = columid;
                            //    headindex = 0;

                        }
                        if (value.Trim().Equals("Sales Organization") && headindex == rowid)
                        {

                            Salesogid = columid;
                            //    headindex = 0;

                        }


                        if (value.Trim().Equals("Name 1") && headindex == rowid)
                        {

                            Nameid = columid;
                            //   headindex = 0;



                        }


                        if (value.Trim().Equals("House num & Street") && headindex == rowid)
                        {
                            Houseid = columid;

                        }
                        if (value.Trim().Equals("Street 4") && headindex == rowid)
                        {
                            Streetid = columid;

                        }

                        if (value.Trim().Equals("City") && headindex == rowid)
                        {
                            Cityid = columid;

                        }

                        if (value.Trim().Equals("Telephone 1") && headindex == rowid)
                        {
                            telephoneid = columid;
                            // headindex = 0;
                        }

                        if (value.Trim().Equals("Sales Office") && headindex == rowid)
                        {
                            salesofficeid = columid;

                        }

                        if (value.Trim().Equals("Delivering Plant") && headindex == rowid)
                        {
                            Deliveringid = columid;

                        }
                        //if (value.Trim().Contains("Terms of Payment") && headindex == 0)
                        //{
                        //    Termsid = columid;
                        //    headindex = 0;
                        //}
                        if (value.Trim().Equals("Price List") && headindex == rowid)
                        {
                            Priceid = columid;

                        }
                        if (value.Trim().Equals("Key Account No") && headindex == rowid)
                        {
                            Keyid = columid;

                        }
                        if (value.Trim().Equals("Sales district") && headindex == rowid)
                        {
                            Salesdistid = columid;

                        }
                        //if (value.Trim().Contains("Created on") && headindex == rowid)
                        //{
                        //    Createdonid = columid;

                        //}
                        //if (value.Trim().Contains("Created by") && headindex == rowid)
                        //{
                        //    Createdbyid = columid;

                        //}
                        if (value.Trim().Equals("VAT Registration No.") && headindex == rowid)
                        {
                            VATid = columid;

                        }
                        //if (value.Trim().Contains("Central order block") && headindex == rowid)
                        //{
                        //    orderblockid = columid;

                        //}

                        //if (value.Trim().Contains("Order block for sales area") && headindex == rowid)
                        //{
                        //    salesblockid = columid;

                        //}

                        #endregion

                    }


                }// colum

            } //find colum ok

            #region  nếu thiếu cột
            if (Customerid == -1)
            {
                MessageBox.Show("Thiếu cột : Customer", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            if (Salesogid == -1)
            {
                MessageBox.Show("Thiếu cột : Sales Organization", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            if (Nameid == -1)
            {
                MessageBox.Show("Thiếu cột : Name 1", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            if (Houseid == -1)
            {
                MessageBox.Show("Thiếu cột : House num & Street", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            if (Streetid == -1)
            {
                MessageBox.Show("Thiếu cột : Street 4", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (Cityid == -1)
            {
                MessageBox.Show("Thiếu cột : City", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            if (telephoneid == -1)
            {
                MessageBox.Show("Thiếu cột : Telephone 1", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            if (salesofficeid == -1)
            {
                MessageBox.Show("Thiếu cột : Sales Office", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            if (Deliveringid == -1)
            {
                MessageBox.Show("Thiếu cột : Delivering Plant", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            if (Accountgroupid == -1)
            {
                MessageBox.Show("Thiếu cột : Account group", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (Priceid == -1)
            {
                MessageBox.Show("Thiếu cột : Price List", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            if (Keyid == -1)
            {
                MessageBox.Show("Thiếu cột : Key Account No", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (Salesdistid == -1)
            {
                MessageBox.Show("Thiếu cột :Sales district", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (VATid == -1)
            {
                MessageBox.Show("Thiếu cột :VAT Registration No", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            //int  = -1;
            //int Createdonid = -1;
            //int Createdbyid = -1;
            //int  = -1;
            //int orderblockid = -1;
            //int salesblockid = -1;




            #endregion

            OleDbConnection conn = new OleDbConnection(connection_string);
            conn.Open();


            for (int rowixd = 0; rowixd < sourceData.Rows.Count; rowixd++)
            {

                #region setvalue 
                //   string valuepricelist = Utils.GetValueOfCellInExcel(worksheet, rowid, columpricelist);
                string customer = sourceData.Rows[rowixd][Customerid].ToString();
                if (customer != "" && Utils.IsValidnumber(customer))
                {
                    /// inser vao tbale access



                    string StringQuery = @"INSERT INTO tbl_list_customer(
                                                Customer_Code,
                                                Name,
                                                Address,
                                                Key_Account_No,
                                                Sales_district,
                                                VAT_Registration_No,
                                                Telephone,
                                                PriceList,
                                                sales_region,
                                                Plant,
                                                Custype) 

                                            VALUES(
                                                @Customer_Code,
                                                @Name,
                                                @Address,
                                                @Key_Account_No,
                                                @Sales_district,
                                                @VAT_Registration_No,
                                                @Telephone,
                                                @PriceList,
                                                @sales_region,
                                                @Plant,
                                                @Custype)";
                    OleDbCommand comm = new OleDbCommand(StringQuery, conn);


                    //ADD PARAMS
                    comm.Parameters.AddWithValue("@Customer_Code", sourceData.Rows[rowixd][Customerid].ToString().Trim());

                    comm.Parameters.AddWithValue("@Name", sourceData.Rows[rowixd][Nameid].ToString().Trim());
                    comm.Parameters.AddWithValue("@Address", sourceData.Rows[rowixd][Houseid].ToString().Trim() +" "+ sourceData.Rows[rowixd][Streetid].ToString().Trim()+" " + sourceData.Rows[rowixd][Cityid].ToString().Trim());
                    comm.Parameters.AddWithValue("@Key_Account_No", sourceData.Rows[rowixd][Keyid].ToString());
                    comm.Parameters.AddWithValue("@Sales_district", sourceData.Rows[rowixd][Salesdistid].ToString().Trim());
                    comm.Parameters.AddWithValue("@VAT_Registration_No", sourceData.Rows[rowixd][VATid].ToString().Trim());
                    comm.Parameters.AddWithValue("@Telephone", sourceData.Rows[rowixd][telephoneid].ToString().Trim());
                    comm.Parameters.AddWithValue("@PriceList", sourceData.Rows[rowixd][Priceid].ToString().Trim());
                    comm.Parameters.AddWithValue("@sales_region", sourceData.Rows[rowixd][Salesogid].ToString().Trim());
                    comm.Parameters.AddWithValue("@Plant", sourceData.Rows[rowixd][Deliveringid].ToString().Trim());
                    comm.Parameters.AddWithValue("@Custype", sourceData.Rows[rowixd][Accountgroupid].ToString().Trim());// 

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

                    }

                    /// inser vao table access




                }

                #endregion

            }// row


            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
                //      conn.Close();
                OleDbConnection.ReleaseObjectPool();
                GC.Collect();  // I know attation
                GC.WaitForPendingFinalizers();
            }


        }



        private void showwait()
        {
            View.Caculating wat = new View.Caculating();
            wat.ShowDialog();


        }
        public void customerinput()
        {


            //   CultureInfo provider = CultureInfo.InvariantCulture;


            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Excel File Customer excel data !";
            theDialog.Filter = "Excel files|*.xlsx; *.xls";
            theDialog.InitialDirectory = @"C:\";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {

                //  AutoResetEvent autoEvent = new AutoResetEvent(false); //join



                string filename = theDialog.FileName.ToString();
                Thread t1 = new Thread(importsexcel2);
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

                //#region updateCustgoupinListcust


                //LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

                //var qr = from tblCustomer in dc.tblCustomers
                //             //  where tblCustomer.Reportsend == true
                //         select tblCustomer;
                ////------------//
                //foreach (var tblCustomer in qr)
                //{

                //    var qr2 = (from tbl_CustomerGroup in dc.tbl_CustomerGroups
                //               where tbl_CustomerGroup.Customercode == tblCustomer.Customer && 
                //               select tbl_CustomerGroup).FirstOrDefault();


                //    if (qr2 != null)
                //    {
                //        tblCustomer.Cusromergroup = qr2.Customergropcode;


                //    }


                //    if (qr2 == null)
                //    {
                //        tblCustomer.Cusromergroup = tblCustomer.Customer;

                //    }



                //    dc.SubmitChanges();



                //}

                //#endregion updateCustgoupinListcust


            }





        }

        public void customerinputpriceingupdate()
        {


            //   CultureInfo provider = CultureInfo.InvariantCulture;


            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Excel File ZNKA1 Customer excel";
            theDialog.Filter = "Excel files|*.xlsx; *.xls";
            theDialog.InitialDirectory = @"C:\";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {

                //  AutoResetEvent autoEvent = new AutoResetEvent(false); //join



                string filename = theDialog.FileName.ToString();
                Thread t1 = new Thread(importsexceltoPricingcheck);
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
