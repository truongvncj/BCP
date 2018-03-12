using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace BCP.View
{
    public partial class BCPreportsform : Form
    {
        public BCPreportsform()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {

            FormCollection fc = System.Windows.Forms.Application.OpenForms;

            bool kq = false;
            foreach (Form frm in fc)
            {
                if (frm.Text == "kaPriodpicker")
                {
                    kq = true;
                    frm.Focus();

                }
            }

            if (!kq)
            {

                string connection_string = Utils.getConnectionstr();

                LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


                View.kaPriodpicker kaPriodpicker = new View.kaPriodpicker();


                kaPriodpicker.ShowDialog();
                string priod = kaPriodpicker.priod;

                var rs = from tbl_kasale in dc.tbl_kasales
                         where tbl_kasale.Priod == priod
                         group tbl_kasale by new
                         {
                             tbl_kasale.Sold_to,
                             tbl_kasale.Sales_Org

                         }
                          into g
                         select new
                         {
                             Priod = g.Select(gg => gg.Priod).FirstOrDefault(),
                             Region = g.Key.Sales_Org,
                             Sold_to = g.Key.Sold_to,
                             Name = g.Select(gg => gg.Cust_Name).FirstOrDefault(),
                             PCs = g.Sum(gg => gg.EC).GetValueOrDefault(0),
                             EC = Math.Ceiling(g.Sum(gg => gg.PC).GetValueOrDefault(0)),
                             UC = Math.Ceiling(g.Sum(gg => gg.UC).GetValueOrDefault(0)),
                             Litter = Math.Ceiling(g.Sum(gg => gg.Litter).GetValueOrDefault(0)),
                             NSR = Math.Ceiling(g.Sum(gg => gg.NSR).GetValueOrDefault(0)),
                             GSR = Math.Ceiling(g.Sum(gg => gg.GSR).GetValueOrDefault(0)),



                         };

                Viewtable viewtbl = new Viewtable(rs, dc, "SALES DATA PRIOD: " + priod, 2);// view code 1 la can viet them lenh

                viewtbl.Show();

            }


        }

        private void button2_Click(object sender, EventArgs e)
        {


        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
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
             new OleDbDataAdapter("SELECT * FROM tbl_list_customer", conn);
            adapter.Fill(ds);
            conn.Close();
            DataTable dt = ds.Tables[0];
            // close the connection



            View.BCPViewdatatable view = new BCPViewdatatable(dt, "DANH SÁCH KHÁCH HÀNG","ID", "tbl_list_customer");
            view.ShowDialog();



        }
        class dateacrrual
        {

            public DateTime Accrualdate { get; set; }

        }

        public void Accrualmake(object Objdateacrrual)
        {
            dateacrrual dat = (dateacrrual)Objdateacrrual;

            DateTime Accrualdate = dat.Accrualdate;




            Control.Control_ac.AccrualContractinSQL(Accrualdate);


        }



        private void button6_Click(object sender, EventArgs e)
        {

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
             new OleDbDataAdapter("SELECT * FROM tbl_list_Order", conn);
            adapter.Fill(ds);
            conn.Close();
            DataTable dt = ds.Tables[0];
            // close the connection



            View.BCPViewdatatable view = new BCPViewdatatable(dt, "LIST ORDER WITH STATUS","","");
            view.ShowDialog();







        }

        private void button5_Click(object sender, EventArgs e)
        {


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
             new OleDbDataAdapter("SELECT * FROM tbl_list_product", conn);
            adapter.Fill(ds);
            conn.Close();
            DataTable dt = ds.Tables[0];
            // close the connection



            View.BCPViewdatatable view = new BCPViewdatatable(dt, "DANH SÁCH SẢN PHẨM","ID", "tbl_list_product");
            view.ShowDialog();




        }
        class datainportFx2
        {

          
            public DateTime valuedate { get; set; }

        }

        // exportAll2sexcelprice
        public void exportAll2sexcelprice(object obj)
        {

         //   dateacrrual dat = (dateacrrual)Objdateacrrual;

        //    DateTime Accrualdate = dat.Accrualdate;

            datainportFx2 datetemp = (datainportFx2)obj;

               DateTime valuedate = (datetemp).valuedate;


            //    DateTime valuedate = (DateTime)(obj as datainportFx2).valuedate;



            #region    //code //productcode // productname  // baseprice  //  promotiondiscount// fuctiondiscount // surchare // netprice



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
             new OleDbDataAdapter("SELECT * FROM tbl_list_product where tbl_list_product.product_type = 1", conn);
            adapter.Fill(ds);
            conn.Close();
            DataTable dt = ds.Tables[0];
            // close the connection

            string Product_Code = "";
            string Product_Name = "";
            string Product_group = "";
            string Customer_Code = "";
            string Key_Account_No = "";

            string PriceList = "";
            string Sales_Region = "";
            string Sales_District = "";
            double Baseprice = 0;
            double Promotion_discount = 0;
            double Function_discount = 0;
            double Surcharge = 0;
            double Netprice = 0;

            #region  make table to add data
            DataTable reportdata = new DataTable();

            reportdata.Columns.Add(new DataColumn("Customer_Code", typeof(string)));
            reportdata.Columns.Add(new DataColumn("Product_Code", typeof(string)));
            reportdata.Columns.Add(new DataColumn("Product_Name", typeof(string)));
            reportdata.Columns.Add(new DataColumn("Baseprice", typeof(double)));
            reportdata.Columns.Add(new DataColumn("Promotion_discount", typeof(double)));
            reportdata.Columns.Add(new DataColumn("Function_discount", typeof(double)));
            reportdata.Columns.Add(new DataColumn("Surcharge", typeof(double)));
            reportdata.Columns.Add(new DataColumn("Netprice", typeof(double)));


            #endregion make table to add data
            foreach (DataRow dr in dt.Rows)
            {
                // dataGridetailorder.Rows[idrow].Cells["Product_Name"].Value 

                Product_Code = dr["product_code"].ToString();
                Product_Name = dr["product_Name"].ToString();
                Product_group = dr["product_group"].ToString();





                // OleDbConnection conn = new OleDbConnection(conString);
                conn.Open();

                DataSet ds1 = new DataSet();

                // create the adapter and fill the DataSet
                OleDbDataAdapter adapter1 =
                 new OleDbDataAdapter("SELECT * FROM tbl_list_customer where tbl_list_customer.Custype = 'V001'", conn);
                adapter1.Fill(ds1);
                conn.Close();
                DataTable dt1 = ds1.Tables[0];
                // close the connection


                foreach (DataRow dr1 in dt1.Rows)
                {

                    Customer_Code = dr1["Customer_Code"].ToString();
                    Key_Account_No = dr1["Key_Account_No"].ToString();
                    PriceList = dr1["PriceList"].ToString();
                    Sales_Region = dr1["sales_region"].ToString();
                    Sales_District = dr1["Sales_district"].ToString();

                    Baseprice = Model.Orders.getBasePrice(Product_Code, Customer_Code, Sales_Region, valuedate);

                    if (Baseprice > 0) // nếu có giá base thì mới tính
                    {


                        Promotion_discount = Model.Orders.getDiscount(1, Product_Code, Customer_Code, Sales_Region, Key_Account_No, Baseprice, valuedate);//1 là promotion 2 là fung tion / 3 là sỏ chacr
                        Function_discount = Model.Orders.getDiscount(2, Product_Code, Customer_Code, Sales_Region, Key_Account_No, Baseprice, valuedate);//1 là promotion 2 là fung tion / 3 là sỏ chacr
                        Surcharge = Model.Orders.getDiscount(3, Product_Code, Customer_Code, Sales_Region, Key_Account_No, Baseprice, valuedate);//1 là promotion 2 là fung tion / 3 là sỏ chacr
                        Netprice = Baseprice + Promotion_discount + Function_discount + Surcharge;

                        DataRow rnew = reportdata.Rows.Add();
                        rnew["Customer_Code"] = Customer_Code;
                        rnew["Product_Code"] = Product_Code;
                        rnew["Product_Name"] = Product_Name;
                        rnew["Baseprice"] = Baseprice;
                        rnew["Promotion_discount"] = Promotion_discount;
                        rnew["Function_discount"] = Function_discount;
                        rnew["Surcharge"] = Surcharge;
                        rnew["Netprice"] = Netprice;

                    }

                }



            }




            View.BCPViewdatatable view = new BCPViewdatatable(reportdata, "DANH SÁCH GIÁ CHI TIẾT THEO TỪNG CODE KHÁCH HÀNG !","","");
            view.ShowDialog();











            #endregion  //code //productcode // productname  // baseprice  //  promotiondiscount// fuctiondiscount // surchare // netprice



        }


        private void button7_Click(object sender, EventArgs e)
        {
            bttinhgiaallcode.Enabled = false;
            View.BCPDatepick pickdate = new BCPDatepick("Chọn ngày lấy giá: ");
            pickdate.ShowDialog();
            bool kq = pickdate.kq;
            DateTime valuedate = pickdate.valueDate;

            if (kq) // nếu chọn bắt đầu tính toán  giá
            {

                Thread t1 = new Thread(exportAll2sexcelprice);
                t1.IsBackground = true;
                t1.Start(new datainportFx2() { valuedate = valuedate });
                
            }


            //if (kq) // nếu chọn bắt đầu tính toán  giá
            //{
            //    Thread t1 = new Thread(exporxtPrice);
            //    t1.IsBackground = true;
            //    t1.Start(new datainportFx() { Customer_Code = Customer_Code, Sales_Region = Sales_Region, valuedate = valuedate });
            //}
        }


        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }




        private void button13_Click(object sender, EventArgs e)
        {


        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            // tbl_pricebase_list
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
             new OleDbDataAdapter("SELECT * FROM tbl_pricebase_list", conn);
            adapter.Fill(ds);
            conn.Close();
            DataTable dt = ds.Tables[0];
            // close the connection



            View.BCPViewdatatable view = new BCPViewdatatable(dt, "DANH SÁCH BASE PRICE","","");
            view.ShowDialog();
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            // tbl_pricebase_list
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
             new OleDbDataAdapter("SELECT * FROM tbl_price_discount Where tbl_price_discount.programId = 1", conn);
            adapter.Fill(ds);
            conn.Close();
            DataTable dt = ds.Tables[0];
            // close the connection



            View.BCPViewdatatable view = new BCPViewdatatable(dt, "DANH SÁCH PROMOTION PROGRAM","","");
            view.ShowDialog();

        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            // tbl_pricebase_list
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
             new OleDbDataAdapter("SELECT * FROM tbl_price_discount Where tbl_price_discount.programId = 2", conn);
            adapter.Fill(ds);
            conn.Close();
            DataTable dt = ds.Tables[0];
            // close the connection



            View.BCPViewdatatable view = new BCPViewdatatable(dt, "DANH SÁCH FUNCTION DISCOUNT","","");
            view.ShowDialog();
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            // tbl_pricebase_list
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
             new OleDbDataAdapter("SELECT * FROM tbl_price_discount Where tbl_price_discount.programId = 3", conn);
            adapter.Fill(ds);
            conn.Close();
            DataTable dt = ds.Tables[0];
            // close the connection



            View.BCPViewdatatable view = new BCPViewdatatable(dt, "DANH SÁCH SURCHARGE DISCOUNT","","");
            view.ShowDialog();
        }

        private void btshipmentstatus_Click(object sender, EventArgs e)
        {
            // tbl_pricebase_list
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
             new OleDbDataAdapter(@"SELECT    First (  tbl_list_Order.Plant ) as Plant , 
                                             First(    tbl_list_Order.ShippingPoint ) as ShippingPoint, 
                                                       tbl_list_Order.Shipment , 
                                              First(   tbl_list_Order.Closeshipment ) as Closeshipment, 
                                             First(    tbl_list_Order.ShipmentcreateBy ) as ShipmentcreateBy,
                                            First(     tbl_list_Order.TicketPrintby ) as TicketPrintby,
                                             First(    tbl_list_Order.LoadPrintby ) as LoadPrintby

                                                                                        FROM tbl_list_Order
                                            Where  tbl_list_Order.Shipment <> 0
                                                                                        GRoup by 
                                                                                    tbl_list_Order.Shipment
                                                                                                         ", conn);



            adapter.Fill(ds);
            conn.Close();
            DataTable dt = ds.Tables[0];
            // close the connection



            View.BCPViewdatatable view = new BCPViewdatatable(dt, "DANH SÁCH SHIPMENT WITH STATUS","","");
            view.ShowDialog();
        }

        class datainportFx
        {

            public string Customer_Code { get; set; }
            public string Sales_Region { get; set; }
            public DateTime valuedate { get; set; }

        }
        public void exporxtPrice(object obj)
        {
            datainportFx datetemp = (datainportFx)obj;

           // DateTime valuedate = (datetemp).valuedate;

            string Customer_Code = datetemp.Customer_Code;
            string Sales_Region = datetemp.Sales_Region;
            DateTime valuedate = datetemp.valuedate;




            string Key_Account_No = Model.Orders.getKeyaccount(Customer_Code, Sales_Region);
            string PriceList = Model.Orders.getPriceList(Customer_Code, Sales_Region);
            string Sales_District = Model.Orders.getsalesDistric(Customer_Code, Sales_Region);



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
             new OleDbDataAdapter("SELECT * FROM tbl_list_product where tbl_list_product.product_type = 1", conn);
            adapter.Fill(ds);
            conn.Close();
            DataTable dt = ds.Tables[0];
            // close the connection

            string Product_Code = "";
            string Product_Name = "";
            string Product_group = "";



            double Baseprice = 0;
            double Promotion_discount = 0;
            double Function_discount = 0;
            double Surcharge = 0;
            double Netprice = 0;

            #region  make table to add data
            DataTable reportdata = new DataTable();

            reportdata.Columns.Add(new DataColumn("Customer_Code", typeof(string)));
            reportdata.Columns.Add(new DataColumn("Sales_Region", typeof(string)));
            reportdata.Columns.Add(new DataColumn("Key_Account_No", typeof(string)));
            reportdata.Columns.Add(new DataColumn("Product_Code", typeof(string)));
            reportdata.Columns.Add(new DataColumn("Product_Name", typeof(string)));
            reportdata.Columns.Add(new DataColumn("Baseprice", typeof(double)));
            reportdata.Columns.Add(new DataColumn("Promotion_discount", typeof(double)));
            reportdata.Columns.Add(new DataColumn("Function_discount", typeof(double)));
            reportdata.Columns.Add(new DataColumn("Surcharge", typeof(double)));
            reportdata.Columns.Add(new DataColumn("Netprice", typeof(double)));
          //  reportdata.Columns["Netprice"].
                //DefaultCellStyle.Format = "N0";
            #endregion make table to add data
            foreach (DataRow dr in dt.Rows)
            {
                // dataGridetailorder.Rows[idrow].Cells["Product_Name"].Value 

                Product_Code = dr["product_code"].ToString();
                Product_Name = dr["product_Name"].ToString();
                Product_group = dr["product_group"].ToString();






                //    Customer_Code = dr1["Customer_Code"].ToString();



                Baseprice = Model.Orders.getBasePrice(Product_Code, Customer_Code, Sales_Region, valuedate);

                if (Baseprice > 0) // nếu có giá base thì mới tính
                {


                    Promotion_discount = Model.Orders.getDiscount(1, Product_Code, Customer_Code, Sales_Region, Key_Account_No, Baseprice, valuedate);//1 là promotion 2 là fung tion / 3 là sỏ chacr
                    Function_discount = Model.Orders.getDiscount(2, Product_Code, Customer_Code, Sales_Region, Key_Account_No, Baseprice, valuedate);//1 là promotion 2 là fung tion / 3 là sỏ chacr
                    Surcharge = Model.Orders.getDiscount(3, Product_Code, Customer_Code, Sales_Region, Key_Account_No, Baseprice, valuedate);//1 là promotion 2 là fung tion / 3 là sỏ chacr
                    Netprice = Baseprice + Promotion_discount + Function_discount + Surcharge;

                    DataRow rnew = reportdata.Rows.Add();
                    rnew["Customer_Code"] = Customer_Code;
                    rnew["Sales_Region"] = Sales_Region;
                    rnew["Key_Account_No"] = Key_Account_No;
                    rnew["Product_Code"] = Product_Code;
                    rnew["Product_Name"] = Product_Name;
                    rnew["Baseprice"] = Baseprice;
                    rnew["Promotion_discount"] = Promotion_discount;
                    rnew["Function_discount"] = Function_discount;
                    rnew["Surcharge"] = Surcharge;
                    rnew["Netprice"] = Netprice;



                }

                //   }



            }




            View.BCPViewdatatable view2 = new BCPViewdatatable(reportdata, "BẢNG GIÁ CỦA CODE :" + Customer_Code + " Ngày : " + valuedate.ToShortDateString(),"","");
            view2.ShowDialog();


        }










        private void button2_Click_1(object sender, EventArgs e)
        {
            btgetpriceoncode.Enabled = false;
            View.BCPCuscodeandateselect view = new BCPCuscodeandateselect();
            view.ShowDialog();

            bool kq = view.kq;
            string Customer_Code = view.CustomerCode;
            DateTime valuedate = view.Valuedate;
            string Sales_Region = view.sales_region;

            if (kq) // nếu chọn bắt đầu tính toán  giá
            {
                Thread t1 = new Thread(exporxtPrice);
                t1.IsBackground = true;
                t1.Start(new datainportFx() { Customer_Code = Customer_Code, Sales_Region = Sales_Region, valuedate = valuedate });
            }

            //       public string Customer_Code { get; set; }
            //public string Sales_Region { get; set; }
            //public DateTime valuedate { get; set; }







        }
    }
}
