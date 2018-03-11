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



            View.BCPViewdatatable view = new BCPViewdatatable(dt, "DANH SÁCH KHÁCH HÀNG ");
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



            View.BCPViewdatatable view = new BCPViewdatatable(dt, "LIST ORDER WITH STATUS");
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



            View.BCPViewdatatable view = new BCPViewdatatable(dt, "DANH SÁCH SẢN PHẨM ");
            view.ShowDialog();




        }

        private void button7_Click(object sender, EventArgs e)
        {
            View.BCPDatepick pickdate = new BCPDatepick("Chọn ngày lấy giá: ");
            pickdate.ShowDialog();
            bool kq = pickdate.kq;
            DateTime valuedate = pickdate.valueDate;

            if (kq) // nếu chọn bắt đầu tính toán  giá
            {

                //code //productcode // productname  // baseprice  //  promotiondiscount// fuctiondiscount // surchare // netprice

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


                foreach (DataRow dr in dt.Rows)
                {
                    // dataGridetailorder.Rows[idrow].Cells["Product_Name"].Value 

                    string productCode = dr["product_code"].ToString();
                    string productname = dr["product_Name"].ToString();
                    string product_group = dr["product_group"].ToString();


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




                                        }


                                        
                }




                //  View.BCPViewdatatable view = new BCPViewdatatable(dt, "DANH SÁCH SẢN PHẨM ");
                //    view.ShowDialog();














            }

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



            View.BCPViewdatatable view = new BCPViewdatatable(dt, "DANH SÁCH BASE PRICE ");
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



            View.BCPViewdatatable view = new BCPViewdatatable(dt, "DANH SÁCH PROMOTION PROGRAM ");
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



            View.BCPViewdatatable view = new BCPViewdatatable(dt, "DANH SÁCH FUNCTION DISCOUNT ");
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



            View.BCPViewdatatable view = new BCPViewdatatable(dt, "DANH SÁCH SURCHARGE DISCOUNT ");
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



            View.BCPViewdatatable view = new BCPViewdatatable(dt, "DANH SÁCH SHIPMENT WITH STATUS");
            view.ShowDialog();
        }
    }
}
