using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BCP.Control;
using System.Globalization;
using System.Threading;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace BCP.View
{


    public partial class BCPOrderEntry : Form
    {
        public class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }



        public string Ordernumber { get; set; }


        public BCPOrderEntry(string formlabel, string Orderno)
        {
            InitializeComponent();
            this.Ordernumber = Orderno;
            this.lbOrdernumber.Text = Orderno;

            tabControl1.TabPages.RemoveAt(1);





            List<ComboboxItem> collectionPlan = new List<ComboboxItem>();
            string connection_string = Utils.getAccessConnectionstring();
            OleDbConnection conn = new OleDbConnection(connection_string);

            // create an open the connection     
            DataSet ds = new DataSet();


            // create the adapter and fill the DataSet
            OleDbDataAdapter adapter =
             new OleDbDataAdapter("SELECT DISTINCT Plant FROM tbl_shipingointList ", conn);
            adapter.Fill(ds);

            // close the connection
            conn.Close();
            DataTable dt = ds.Tables[0];

            List<ComboboxItem> CombomCollection = new List<ComboboxItem>();
            foreach (DataRow dr in dt.Rows)
            {
                ComboboxItem cb = new ComboboxItem();
                //     ver = int.Parse(dr["ver"].ToString());
                cb.Value = dr["Plant"].ToString();
                cb.Text = dr["Plant"].ToString();
                CombomCollection.Add(cb);


            }

            cb_plant.DataSource = CombomCollection;


            // create an open the connection     
            DataSet ds1 = new DataSet();


            // create the adapter and fill the DataSet
            OleDbDataAdapter adapter1 =
             new OleDbDataAdapter("SELECT DISTINCT Shipingpoint FROM tbl_shipingointList  ", conn);
            adapter1.Fill(ds1);

            // close the connection
            conn.Close();
            DataTable dt1 = ds1.Tables[0];

            List<ComboboxItem> CombomCollection1 = new List<ComboboxItem>();
            foreach (DataRow dr in dt1.Rows)
            {
                ComboboxItem cb = new ComboboxItem();
                //     ver = int.Parse(dr["ver"].ToString());
                cb.Value = dr["Shipingpoint"].ToString();
                cb.Text = dr["Shipingpoint"].ToString();
                CombomCollection1.Add(cb);


            }

            cb_shipingpoint.DataSource = CombomCollection1;


            // load order detail new

            #region load order detail new




            // tbl_kaProgramedetailTemp tb = new tbl_kaProgramedetailTemp();

            //  tb.

            DataTable dt3 = new DataTable();

            dt3.Columns.Add(new DataColumn("Product_Code", typeof(string)));
            dt3.Columns.Add(new DataColumn("Amount", typeof(double)));
            dt3.Columns.Add(new DataColumn("Product_Name", typeof(string)));
            dt3.Columns.Add(new DataColumn("FreeCase", typeof(Boolean)));





            this.dataGridetailorder.DataSource = dt3;



            dataGridetailorder.Columns["Product_Code"].DisplayIndex = 0;
            dataGridetailorder.Columns["Product_Code"].Width = 100;
            dataGridetailorder.Columns["Product_Code"].HeaderText = "Product Code";
            this.dataGridetailorder.Columns["Product_Code"].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridetailorder.Columns["Amount"].DisplayIndex = 1;
            dataGridetailorder.Columns["Amount"].Width = 100;
            this.dataGridetailorder.Columns["Amount"].DefaultCellStyle.Format = "N0";

            this.dataGridetailorder.Columns["Amount"].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridetailorder.Columns["FreeCase"].DisplayIndex = 2;
            dataGridetailorder.Columns["FreeCase"].Width = 100;
            dataGridetailorder.Columns["FreeCase"].HeaderText = "Free Case";
            dataGridetailorder.Columns["FreeCase"].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridetailorder.Columns["Product_Name"].DisplayIndex = 3;
            dataGridetailorder.Columns["Product_Name"].Width = 380;
            dataGridetailorder.Columns["Product_Name"].HeaderText = "Product Name";
            dataGridetailorder.Columns["Product_Name"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridetailorder.Columns["Product_Name"].ReadOnly = true;
            dataGridetailorder.Columns["Product_Name"].DefaultCellStyle.BackColor = Color.AntiqueWhite;




            #endregion



            // load order detail new 



        }




        //private void bindDataToDataGridViewComboPrograme()
        //{
        //    DataGridViewComboBoxColumn cmbdgv = new DataGridViewComboBoxColumn();

        //    //  dataGridProgramdetail.Columns["Program"].
        //    // List<String> itemCodeList = new List<String>();
        //    string connection_string = Utils.getConnectionstr();

        //    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
        //    //  CombomCollection = null;
        //    List<ComboboxItem> CombomCollection = new List<ComboboxItem>();
        //    var rs = from tbl_kaprogramlist in dc.tbl_kaprogramlists
        //             orderby tbl_kaprogramlist.Name
        //             select tbl_kaprogramlist;
        //    foreach (var item in rs)
        //    {
        //        ComboboxItem cb = new ComboboxItem();
        //        cb.Value = item.Code;
        //        cb.Text = item.Code.Trim() + ": " + item.Name;
        //        CombomCollection.Add(cb);
        //    }
        //    cmbdgv.DataSource = CombomCollection;
        //    cmbdgv.HeaderText = "Program";
        //    cmbdgv.Name = "Program";
        //    cmbdgv.ValueMember = "Value";
        //    cmbdgv.DisplayMember = "Text";
        //    cmbdgv.Width = 100;
        //    cmbdgv.DropDownWidth = 180;
        //    dataGridProgramdetail.Columns.Add(cmbdgv);

        //}


        //private void bindDataToDataGridViewComboPayment_Control()
        //{
        //    DataGridViewComboBoxColumn cmbdgv = new DataGridViewComboBoxColumn();

        //    //  dataGridProgramdetail.Columns["Program"].
        //    // List<String> itemCodeList = new List<String>();
        //    string connection_string = Utils.getConnectionstr();

        //    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
        //    //  CombomCollection = null;
        //    List<ComboboxItem> CombomCollection = new List<ComboboxItem>();
        //    var rs = from tbl_Kafuctionlist in dc.tbl_Kafuctionlists
        //             orderby tbl_Kafuctionlist.Code
        //             select tbl_Kafuctionlist;
        //    foreach (var item in rs)
        //    {
        //        ComboboxItem cb = new ComboboxItem();
        //        cb.Value = item.Code;
        //        cb.Text = item.Code + ": " + item.Description + "    || Example: " + item.Example;
        //        CombomCollection.Add(cb);
        //    }
        //    cmbdgv.DataSource = CombomCollection;
        //    cmbdgv.HeaderText = "Payment_Control";
        //    cmbdgv.Name = "Payment_Control";
        //    cmbdgv.ValueMember = "Value";
        //    cmbdgv.DisplayMember = "Text";
        //    cmbdgv.Width = 300;
        //    cmbdgv.DropDownWidth = 800;

        //    dataGridProgramdetail.Columns.Add(cmbdgv);

        //}

        //private void bindDataToDataGridViewComboproductgroup_Control()
        //{
        //    DataGridViewComboBoxColumn cmbdgv = new DataGridViewComboBoxColumn();

        //    //  dataGridProgramdetail.Columns["Program"].
        //    // List<String> itemCodeList = new List<String>();
        //    string connection_string = Utils.getConnectionstr();

        //    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
        //    //  CombomCollection = null;
        //    List<ComboboxItem> CombomCollection = new List<ComboboxItem>();
        //    var rs = from tbl_kaPrdgrp in dc.tbl_kaPrdgrps
        //             orderby tbl_kaPrdgrp.PrdGrp
        //             select tbl_kaPrdgrp;
        //    foreach (var item in rs)
        //    {
        //        ComboboxItem cb = new ComboboxItem();
        //        cb.Value = item.PrdGrp;
        //        cb.Text = item.PrdGrp + ": " + item.ProductGroup;// + "- Exp : " + item.Example;
        //        CombomCollection.Add(cb);
        //    }
        //    cmbdgv.DataSource = CombomCollection;
        //    cmbdgv.HeaderText = "Product Group";
        //    cmbdgv.Name = "Product_Group";
        //    cmbdgv.ValueMember = "Value";
        //    cmbdgv.DisplayMember = "Text";
        //    cmbdgv.Width = 70;
        //    cmbdgv.DropDownWidth = 200;

        //    dataGridProgramdetail.Columns.Add(cmbdgv);

        //}


        //  cmbdgv.Items.Add("Test");


        void cbm_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BeginInvoke(new MethodInvoker(EndEdit));

        }
        ComboBox cbm;
        DataGridViewCell currentCell;
        //  private DateTimePicker cellDateTimePicker = new DateTimePicker();
        // DateTimePicker[] sp = new DateTimePicker[100];
        void EndEdit()
        {




            if (cbm != null)
            {
                if (cbm.SelectedItem != null)
                {
                    string SelectedItem = (cbm.SelectedItem as ComboboxItem).Value.ToString();// (cbm.SelectedItem as ComboboxItem).Value.ToString();

                    // int i = dataGridProgramdetail.CurrentRow.Index;
                    int i = currentCell.RowIndex;
                    string colname = this.dataGridetailorder.Columns[this.dataGridetailorder.CurrentCell.ColumnIndex].Name;

                    dataGridetailorder.Rows[i].Cells[colname].Value = SelectedItem;
                    //      MessageBox.Show(dataGridProgramdetail.Rows[i].Cells["Program"].Value.ToString());

                }





            }


            //}
        }

        private void dataGridProgramdetail_EditingControlShowing_1(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is ComboBox)
            {

                cbm = (ComboBox)e.Control;

                if (cbm != null)
                {
                    cbm.SelectedIndexChanged += new EventHandler(cbm_SelectedIndexChanged);
                }

                currentCell = this.dataGridetailorder.CurrentCell;

            }
        }

        private void dataGridProgramdetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {


            //string colheadertext = this.dataGridProgramdetail.Columns[this.dataGridProgramdetail.CurrentCell.ColumnIndex].HeaderText;
            //if (colheadertext == "TargetUnit")
            //{

            //    if (this.dataGridProgramdetail.Rows[this.dataGridProgramdetail.CurrentCell.RowIndex].Cells["Payment_Control"].Value != null && this.dataGridProgramdetail.Rows[this.dataGridProgramdetail.CurrentCell.RowIndex].Cells["Program"].Value != null)
            //    {

            //        string paymentcontrol = this.dataGridProgramdetail.Rows[this.dataGridProgramdetail.CurrentCell.RowIndex].Cells["Payment_Control"].Value.ToString();
            //        string progarme = this.dataGridProgramdetail.Rows[this.dataGridProgramdetail.CurrentCell.RowIndex].Cells["Program"].Value.ToString();



            //        MessageBox.Show("ok done !" + paymentcontrol + ":" + progarme);
            //    }
            //}


        }

        private void dataGridProgramdetail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridetailorder.Columns[e.ColumnIndex].Name == "Product_Code")
            { // condition
                string codefind = "";
                try
                {
                    codefind = dataGridetailorder.Rows[e.RowIndex].Cells["Product_Code"].Value.ToString();

                }
                catch (Exception)
                {
                    return;
                    //throw;
                }
                // find product name 

                //  string codefind = dataGridetailorder.Rows[e.RowIndex].Cells["Product_Code"].Value.ToString();

                //find product name



                dataGridetailorder.Rows[e.RowIndex].Cells["Product_Name"].Value = Model.Product.productName(codefind);

                //e.CellStyle.BackColor = Color.LightSteelBlue;
                //e.CellStyle.ForeColor = Color.OrangeRed;


            }

            //string colname = this.dataGridProgramdetail.Columns[this.dataGridProgramdetail.CurrentCell.ColumnIndex].Name;

            ////  MessageBox.Show(colname);
            //if (colname == "Program")
            //{
            //    if (this.dataGridProgramdetail.Rows[this.dataGridProgramdetail.CurrentCell.RowIndex].Cells["Program"].Value != null) // && this.dataGridProgramdetail.Rows[this.dataGridProgramdetail.CurrentCell.RowIndex].Cells["Program"].Value != null
            //    {
            //        string programe = this.dataGridProgramdetail.Rows[this.dataGridProgramdetail.CurrentCell.RowIndex].Cells["Program"].Value.ToString();



            //        if (programe.Trim() == "DIS")  //     discount on invocie
            //        {
            //            //   MessageBox.Show(programe);

            //            //    dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Control"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Control"].Style.ForeColor = Color.Blue;

            //            if (dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Control"].Value == null || dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Control"].Value.ToString().Trim() != "DIS")
            //            {
            //                dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Control"].Value = "DIS";
            //            }


            //        }





            //    }

            //   }



        }

        private void button5_Click(object sender, EventArgs e)
        {

            View.BCPvalueinput input = new BCPvalueinput("Input Order Number", "");
            input.ShowDialog();
            string ValueText = input.valuetext;
            bool kq = input.kq;

            if (kq && Utils.IsValidnumber(ValueText))
            {

                string connection_string = Utils.getAccessConnectionstring();
                OleDbConnection conn = new OleDbConnection(connection_string);

                // create an open the connection     
                DataSet ds = new DataSet();
                string StringQuery = @"SELECT * FROM tbl_list_Order  where tbl_list_Order.Document = @Document";//, @Customer_Code )"; //'%test%'
                OleDbCommand comm = new OleDbCommand(StringQuery, conn);

                //ADD PARAMS
                comm.Parameters.AddWithValue("@Document", ValueText);
                //     comm.Parameters.AddWithValue("@Created_by", username);
                // comm.Parameters.AddWithValue("@Plant", this.shippingpoint);
                //    comm.Parameters.AddWithValue("@Customer_Code", this.Seachcode);


                //OleDbParameter parm = new OleDbParameter("@fromdate", OleDbType.Date);
                //parm.Value = fromdate;
                //comm.Parameters.Add(parm);

                //OleDbParameter parm2 = new OleDbParameter("@todate", OleDbType.Date);
                //parm2.Value = todate;
                //comm.Parameters.Add(parm2)/*;*/


                //  DataSet ds = new DataSet();
                // create the adapter and fill the DataSet
                OleDbDataAdapter adapter =
               new OleDbDataAdapter(comm);
                adapter.Fill(ds);

                // close the connection
                conn.Close();
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    bt_save.Visible = false;

                    #region load order detail new




                    // tbl_kaProgramedetailTemp tb = new tbl_kaProgramedetailTemp();

                    //  tb.

                    DataTable dt3 = new DataTable();

                    dt3.Columns.Add(new DataColumn("Product_Code", typeof(string)));
                    dt3.Columns.Add(new DataColumn("Amount", typeof(double)));
                    dt3.Columns.Add(new DataColumn("Product_Name", typeof(string)));
                    dt3.Columns.Add(new DataColumn("FreeCase", typeof(Boolean)));





                    #endregion



                    // load new data grid
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr == dt.Rows[0])
                        {
                            lbOrdernumber.Text = ValueText;

                            dateTimePicker1.Value = (DateTime)dr["DlvDate"];
                            lb_address.Text = dr["Address"].ToString();


                            txtshipto.Text = dr["Shipto"].ToString();
                            lbshiptoname.Text = dr["ShiptoName"].ToString();

                            txtsoldto.Text = dr["Sold_to_pt"].ToString();
                            lbsoltoname.Text = dr["Name_pt"].ToString();

                            Ponumber.Text = dr["Purchase_order_number"].ToString();
                            cb_plant.Text = dr["Plant"].ToString();
                            cb_shipingpoint.Text = dr["ShippingPoint"].ToString();
                            lbsalesRegion.Text = dr["sales_region"].ToString();

                        }
                        //   datagridview

                        // DataRow dr1 = new dt3.Rows;

                        DataRow dr1 = dt3.Rows.Add();
                        dr1["Product_Code"] = dr["Material"].ToString();
                        dr1["Amount"] = dr["Order_qty"].ToString();
                        dr1["Product_Name"] = dr["Description"].ToString();
                        dr1["FreeCase"] = (Boolean)dr["fRECASSE"];








                    }

                    this.dataGridetailorder.DataSource = dt3;



                    dataGridetailorder.Columns["Product_Code"].DisplayIndex = 0;
                    dataGridetailorder.Columns["Product_Code"].Width = 100;
                    dataGridetailorder.Columns["Product_Code"].HeaderText = "Product Code";
                    this.dataGridetailorder.Columns["Product_Code"].SortMode = DataGridViewColumnSortMode.NotSortable;

                    dataGridetailorder.Columns["Amount"].DisplayIndex = 1;
                    dataGridetailorder.Columns["Amount"].Width = 100;
                    this.dataGridetailorder.Columns["Amount"].DefaultCellStyle.Format = "N0";

                    this.dataGridetailorder.Columns["Amount"].SortMode = DataGridViewColumnSortMode.NotSortable;

                    dataGridetailorder.Columns["FreeCase"].DisplayIndex = 2;
                    dataGridetailorder.Columns["FreeCase"].Width = 100;
                    dataGridetailorder.Columns["FreeCase"].HeaderText = "Free Case";
                    dataGridetailorder.Columns["FreeCase"].SortMode = DataGridViewColumnSortMode.NotSortable;

                    dataGridetailorder.Columns["Product_Name"].DisplayIndex = 3;
                    dataGridetailorder.Columns["Product_Name"].Width = 380;
                    dataGridetailorder.Columns["Product_Name"].HeaderText = "Product Name";
                    dataGridetailorder.Columns["Product_Name"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    dataGridetailorder.Columns["Product_Name"].ReadOnly = true;
                    dataGridetailorder.Columns["Product_Name"].DefaultCellStyle.BackColor = Color.AntiqueWhite;




                }
                else
                {
                    MessageBox.Show("Không có số order : " + ValueText, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }



                //#region  load comboud sheck
                //// tabControl1.TabPages.RemoveAt(1);





                ////  List<ComboboxItem> collectionPlan = new List<ComboboxItem>();
                //string connection_string = Utils.getAccessConnectionstring();
                //OleDbConnection conn = new OleDbConnection(connection_string);

                //// create an open the connection     
                //DataSet ds = new DataSet();


                //// create the adapter and fill the DataSet
                //OleDbDataAdapter adapter =
                // new OleDbDataAdapter("SELECT DISTINCT Plant FROM tbl_shipingointList ", conn);
                //adapter.Fill(ds);

                //// close the connection
                //conn.Close();
                //DataTable dt = ds.Tables[0];

                //List<ComboboxItem> CombomCollection = new List<ComboboxItem>();
                //foreach (DataRow dr in dt.Rows)
                //{
                //    ComboboxItem cb = new ComboboxItem();
                //    //     ver = int.Parse(dr["ver"].ToString());
                //    cb.Value = dr["Plant"].ToString();
                //    cb.Text = dr["Plant"].ToString();
                //    CombomCollection.Add(cb);


                //}

                //cb_plant.DataSource = CombomCollection;


                //// create an open the connection     
                //DataSet ds1 = new DataSet();


                //// create the adapter and fill the DataSet
                //OleDbDataAdapter adapter1 =
                // new OleDbDataAdapter("SELECT DISTINCT Shipingpoint FROM tbl_shipingointList ", conn);
                //adapter1.Fill(ds1);

                //// close the connection
                //conn.Close();
                //DataTable dt1 = ds1.Tables[0];

                //List<ComboboxItem> CombomCollection1 = new List<ComboboxItem>();
                //foreach (DataRow dr in dt1.Rows)
                //{
                //    ComboboxItem cb = new ComboboxItem();
                //    //     ver = int.Parse(dr["ver"].ToString());
                //    cb.Value = dr["Shipingpoint"].ToString();
                //    cb.Text = dr["Shipingpoint"].ToString();
                //    CombomCollection1.Add(cb);


                //}

                //cb_shipingpoint.DataSource = CombomCollection1;


                //#endregion load combound sellect

                //// Load new datagread

                //#region load order detail new




                //// tbl_kaProgramedetailTemp tb = new tbl_kaProgramedetailTemp();

                ////  tb.

                //DataTable dt3 = new DataTable();

                //dt3.Columns.Add(new DataColumn("Product_Code", typeof(string)));
                //dt3.Columns.Add(new DataColumn("Amount", typeof(double)));
                //dt3.Columns.Add(new DataColumn("Product_Name", typeof(string)));
                //dt3.Columns.Add(new DataColumn("FreeCase", typeof(Boolean)));





                //this.dataGridetailorder.DataSource = dt3;



                //dataGridetailorder.Columns["Product_Code"].DisplayIndex = 0;
                //dataGridetailorder.Columns["Product_Code"].Width = 100;
                //dataGridetailorder.Columns["Product_Code"].HeaderText = "Product Code";
                //this.dataGridetailorder.Columns["Product_Code"].SortMode = DataGridViewColumnSortMode.NotSortable;

                //dataGridetailorder.Columns["Amount"].DisplayIndex = 1;
                //dataGridetailorder.Columns["Amount"].Width = 100;
                //this.dataGridetailorder.Columns["Amount"].DefaultCellStyle.Format = "N0";

                //this.dataGridetailorder.Columns["Amount"].SortMode = DataGridViewColumnSortMode.NotSortable;

                //dataGridetailorder.Columns["FreeCase"].DisplayIndex = 2;
                //dataGridetailorder.Columns["FreeCase"].Width = 100;
                //dataGridetailorder.Columns["FreeCase"].HeaderText = "Free Case";
                //dataGridetailorder.Columns["FreeCase"].SortMode = DataGridViewColumnSortMode.NotSortable;

                //dataGridetailorder.Columns["Product_Name"].DisplayIndex = 3;
                //dataGridetailorder.Columns["Product_Name"].Width = 380;
                //dataGridetailorder.Columns["Product_Name"].HeaderText = "Product Name";
                //dataGridetailorder.Columns["Product_Name"].SortMode = DataGridViewColumnSortMode.NotSortable;
                //dataGridetailorder.Columns["Product_Name"].ReadOnly = true;
                //dataGridetailorder.Columns["Product_Name"].DefaultCellStyle.BackColor = Color.AntiqueWhite;




                //#endregion



                // load new data grid





            }





            //        MessageBox.Show("Order: " + ValueText);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //  this.Ordernumber 
            string Ordernumberdele = lbOrdernumber.Text;
            if (Ordernumberdele != "0" && Ordernumberdele != "")
            {
                bool kq = Model.Orders.deleteOrderNumber(Ordernumberdele);

                if (kq)
                {
                    MessageBox.Show("Order: " + Ordernumberdele + " deleted successfully !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            bt_save.Visible = false;

        }

        private void button7_Click(object sender, EventArgs e)
        {
            // BCPorderviewotiom
            View.BCPorderviewotiom input = new BCPorderviewotiom();
            input.ShowDialog();
            DateTime fromdate = input.fromdate;
            DateTime todate = input.todate;
            string geturname = input.checkUsername;
            bool chon = input.kq;

            // select and view order

            string connection_string = Utils.getAccessConnectionstring();

            OleDbConnection conn = new OleDbConnection(connection_string);
            conn.Open();

            string StringQuery = @"Select * from  tbl_list_Order where tbl_list_Order.Created_by = @Created_by and tbl_list_Order.CreateDate >= @fromdate
                                    and tbl_list_Order.CreateDate <= @todate";

            OleDbCommand comm = new OleDbCommand(StringQuery, conn);


            //ADD PARAMS
            //         (, product_group, percent_amount, fromdate, todate, customerid, keyaccount, saledistrict, programId, Username, sales_region, amount)
            comm.Parameters.AddWithValue("@Created_by", geturname.ToString());

            OleDbParameter parm = new OleDbParameter("@fromdate", OleDbType.Date);
            parm.Value = fromdate;
            comm.Parameters.Add(parm);

            OleDbParameter parm2 = new OleDbParameter("@todate", OleDbType.Date);
            parm2.Value = todate;
            comm.Parameters.Add(parm2);



            //   OleDbDataAdapter1.SelectCommand.CommandText = "SELECT * FROM tbl_Temp WHERE username = @Username AND password = @Password";
            // string Query1 = "SELECT * FROM tbl_Temp WHERE username = '" + textBox1.Text + "' AND password = '" + textBox2.Text+"'";
            // create the DataSet
            DataSet ds = new DataSet();

            // create the adapter and fill the DataSet

            // 
            OleDbDataAdapter adapter =
             new OleDbDataAdapter(comm);
            adapter.Fill(ds);
            conn.Close();
            DataTable dt = ds.Tables[0];
            // close the connection



            View.BCPViewdatatable view = new BCPViewdatatable(dt, "DANH SÁCH ĐƠN ĐẶT HÀNG");
            view.ShowDialog();


            //  string ValueText = input.;
            //   bool kq = input.kq;


            // MessageBox.Show("Order: " + ValueText);


        }

        private void button2_Click(object sender, EventArgs e)
        {

            //   (cb_plant.SelectedItem as ComboboxItem).Value.ToString().Trim()
            View.BCPSeachaddcode input = new BCPSeachaddcode("", (cb_shipingpoint.SelectedItem as ComboboxItem).Value.ToString().Trim(), "V001");

            input.ShowDialog();

            if (input.kq)
            {
                txtsoldto.Text = input.Seachcode;
                lbsoltoname.Text = input.SeachName;
                lbsalesRegion.Text = input.salesRegion;

            }
            else
            {
                txtsoldto.Text = "";
                lbsoltoname.Text = "";

            }


        }

        private void dataGridProgramdetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //   (cb_plant.SelectedItem as ComboboxItem).Value.ToString().Trim()
            View.BCPSeachaddcode input = new BCPSeachaddcode("", (cb_shipingpoint.SelectedItem as ComboboxItem).Value.ToString().Trim(), "V002");

            input.ShowDialog();

            if (input.kq)
            {
                txtshipto.Text = input.Seachcode;
                lbshiptoname.Text = input.SeachName;
                lb_address.Text = input.Seachaddress;
            }
            else
            {
                txtshipto.Text = "";
                lbshiptoname.Text = "";
                lb_address.Text = "";
            }

        }

        private void cb_plant_SelectedValueChanged(object sender, EventArgs e)
        {
            txtshipto.Text = "";
            lbshiptoname.Text = "";
            lb_address.Text = "";
            txtsoldto.Text = "";
            lbsoltoname.Text = "";
        }

        private void cb_shipingpoint_SelectedValueChanged(object sender, EventArgs e)
        {
            txtshipto.Text = "";
            lbshiptoname.Text = "";
            lb_address.Text = "";
            txtsoldto.Text = "";
            lbsoltoname.Text = "";
        }

        private void dataGridProgramdetail_CellLeave(object sender, DataGridViewCellEventArgs e)
        {





        }

        private void dataGridProgramdetail_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void button4_Click(object sender, EventArgs e)
        {
            #region  // check master order 
            bool kqmaster = true;
            if (dateTimePicker1.Value < DateTime.Today)
            {
                kqmaster = false;

                MessageBox.Show("Ngày giao hàng phải từ ngày hiện tại trở đi !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateTimePicker1.Focus();
                return;
            }

            if (cb_plant.SelectedIndex < 0)
            {
                kqmaster = false;

                MessageBox.Show("Bạn chưa chọn plant, please check !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cb_plant.Focus();
                return;


            }
            if (cb_shipingpoint.SelectedIndex < 0)
            {
                kqmaster = false;

                MessageBox.Show("Bạn chưa chọn Shipping Point, please check !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cb_shipingpoint.Focus();
                return;


            }
            // txtsoldto

            if (txtsoldto.Text == "")
            {
                kqmaster = false;

                MessageBox.Show("Bạn chưa chọn Soldto Code, please check !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                button2.Focus();
                return;


            }

            if (txtshipto.Text == "")
            {
                kqmaster = false;

                MessageBox.Show("Bạn chưa chọn Shipto  Code, please check !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                button3.Focus();
                return;


            }
            // Ponumber
            if (Ponumber.Text == "")
            {
                kqmaster = false;

                MessageBox.Show("Mục PO không được để trống !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Ponumber.Focus();
                return;


            }
            #endregion check master

            #region   // check detail order
            bool kqdetail = true;
            for (int idrow = 0; idrow < dataGridetailorder.RowCount - 1; idrow++)
            {

                //   dataGridetailorder.Columns["Product_Name"].ReadOnly = true;
                //   dataGridetailorder.Columns["Product_Name"].DefaultCellStyle.BackColor = Color.AntiqueWhite;


                if (dataGridetailorder.Rows[idrow].Cells["Product_Name"].Value == DBNull.Value || (string)dataGridetailorder.Rows[idrow].Cells["Product_Name"].Value == "")
                {
                    kqdetail = false;
                    dataGridetailorder.Rows[idrow].Cells["Product_Code"].Style.BackColor = Color.Aqua;
                    //   dataGridProgramdetail.Rows[idrow].Cells["Product_Code"]. = true;
                    MessageBox.Show("Please check code sản phẩm !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;

                    //    newdetailContract.PayType = dataGridProgramdetail.Rows[idrow].Cells["Program"].Value.ToString().Trim(); // chính la program
                }
                else
                {
                    dataGridetailorder.Rows[idrow].Cells["Product_Code"].Style.BackColor = Color.GhostWhite;
                }


                if (dataGridetailorder.Rows[idrow].Cells["Product_Name"].Value == DBNull.Value)
                {
                    kqdetail = false;
                    dataGridetailorder.Rows[idrow].Cells["Product_Code"].Style.BackColor = Color.Aqua;
                    //   dataGridProgramdetail.Rows[idrow].Cells["Product_Code"]. = true;
                    MessageBox.Show("Please check code sản phẩm !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;

                    //    newdetailContract.PayType = dataGridProgramdetail.Rows[idrow].Cells["Program"].Value.ToString().Trim(); // chính la program
                }
                else
                {
                    dataGridetailorder.Rows[idrow].Cells["Product_Code"].Style.BackColor = Color.GhostWhite;
                }
                if (dataGridetailorder.Rows[idrow].Cells["Amount"].Value == DBNull.Value)
                {
                    kqdetail = false;
                    dataGridetailorder.Rows[idrow].Cells["Amount"].Style.BackColor = Color.Aqua;
                    //    dataGridProgramdetail.Rows[idrow].Cells["Amount"].Selected = true;
                    MessageBox.Show("Thiếu số lượng đặt hằng !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;

                    //    newdetailContract.PayType = dataGridProgramdetail.Rows[idrow].Cells["Program"].Value.ToString().Trim(); // chính la program
                }
                else
                {
                    dataGridetailorder.Rows[idrow].Cells["Product_Code"].Style.BackColor = Color.GhostWhite;
                }

            }

            #endregion

            #region  //tao order
            if (kqmaster && kqdetail)
            {
                string ordernumber = Model.Orders.getOrdernumbertemp();
                string connection_string = Utils.getAccessConnectionstring();
                string custCode = txtsoldto.Text.ToString();
                string salesRegion = lbsalesRegion.Text.ToString();
                string keyAccount = Model.Orders.getKeyaccount(custCode, salesRegion);
                string salesDistric = Model.Orders.getsalesDistric(custCode, salesRegion);

                DateTime dlvDate = dateTimePicker1.Value;

                for (int idrow = 0; idrow < dataGridetailorder.RowCount - 1; idrow++)
                {





                    OleDbConnection conn = new OleDbConnection(connection_string);
                    string username = Utils.getUsername();
                    //   string StringQuery = "Delete from tbl_list_Order where tbl_list_Order.Document = @Ordernumber";
                    conn.Open();

                    string StringQuery = @"INSERT INTO tbl_list_Order( Created_by,   Plant, sales_region , Purchase_order_number, Address , DlvDate ,Document , Sold_to_pt, Name_pt, Material ,Description ,Order_qty ,fRECASSE ,Shipto ,ShiptoName,ShippingPoint, CreateDate , Unit  , amount , EmptyCode , Emptyname , EmptyUnit , BasePrice , PromotionDiscount , FuntionDiscount , SurchargeDiscount, KeyAccount, ProducGroup, totalAmount) 
                                    VALUES ( @Created_by,   @Plant, @sales_region , @Purchase_order_number, @Address , @DlvDate ,@Document , @Sold_to_pt, @Name_pt, @Material ,@Description ,@Order_qty ,@fRECASSE ,@Shipto ,@ShiptoName,@ShippingPoint, @CreateDate, @Unit, @amount , @EmptyCode, @Emptyname, @EmptyUnit, @BasePrice , @PromotionDiscount, @FuntionDiscount, @SurchargeDiscount, @KeyAccount, @ProducGroup, @totalAmount ) ";
                    OleDbCommand comm = new OleDbCommand(StringQuery, conn);

                    string productCode = dataGridetailorder.Rows[idrow].Cells["Product_Code"].Value.ToString().Trim();


                    comm.Parameters.AddWithValue("@Created_by", username);
                    comm.Parameters.AddWithValue("@Plant", (cb_plant.SelectedItem as ComboboxItem).Text.ToString());
                    comm.Parameters.AddWithValue("@sales_region", salesRegion);
                    comm.Parameters.AddWithValue("@Purchase_order_number", Ponumber.Text.ToString().Trim() + " ;" + lb_address.Text.ToString().Trim());
                    comm.Parameters.AddWithValue("@Address", lb_address.Text.ToString().Trim());


                    OleDbParameter parm = new OleDbParameter("@DlvDate", OleDbType.Date);
                    parm.Value = dateTimePicker1.Value;
                    comm.Parameters.Add(parm);

                    comm.Parameters.AddWithValue("@Document", int.Parse(ordernumber));
                    comm.Parameters.AddWithValue("@Sold_to_pt", int.Parse(custCode)); // numbar
                                                                                      //  comm.Parameters.AddWithValue("@txtshipto", int.Parse(txtshipto.Text.ToString())); // numbar
                    comm.Parameters.AddWithValue("@Name_pt", lbsoltoname.Text.ToString());

                    comm.Parameters.AddWithValue("@Material", productCode);
                    comm.Parameters.AddWithValue("@Description", dataGridetailorder.Rows[idrow].Cells["Product_Name"].Value.ToString());
                    int QuantityPro = int.Parse(dataGridetailorder.Rows[idrow].Cells["Amount"].Value.ToString());
                    comm.Parameters.AddWithValue("@Order_qty", QuantityPro);// number
                    comm.Parameters.AddWithValue("@fRECASSE", dataGridetailorder.Rows[idrow].Cells["FreeCase"].Value);  //FreeCase
                    comm.Parameters.AddWithValue("@Shipto", int.Parse(txtshipto.Text.ToString())); // numbar

                    comm.Parameters.AddWithValue("@ShiptoName", lbshiptoname.Text.ToString()); // numbar ShippingPoint
                    comm.Parameters.AddWithValue("@ShippingPoint", (cb_shipingpoint.SelectedItem as ComboboxItem).Text.ToString()); // numbar ShippingPoint

                    OleDbParameter parm2 = new OleDbParameter("@CreateDate", OleDbType.Date);
                    parm2.Value = DateTime.Today;
                    comm.Parameters.Add(parm2);
                    comm.Parameters.AddWithValue("@Unit", Model.Product.productUnit(productCode));

                    //  public static double getBasePrice(string productcode, string custcode, string salesRegion, DateTime priceDate)
                    double basePrice = Model.Orders.getBasePrice(productCode, custCode, salesRegion, dlvDate);
                    int PromotionID = 1; //1 Promotiondiscount 2. Fungtion discount; 3 surcharge
                    int FunntionDiscountCode = 2;
                    int SurchargeDiscountID = 3;
                    double PromotionDiscountAmount = Model.Orders.getDiscount(PromotionID, productCode, custCode, salesRegion, keyAccount, basePrice, dlvDate);
                    double FunntionDiscountamount = Model.Orders.getDiscount(FunntionDiscountCode, productCode, custCode, salesRegion, keyAccount, basePrice, dlvDate);
                    double SurchargeDiscounamount = Model.Orders.getDiscount(SurchargeDiscountID, productCode, custCode, salesRegion, keyAccount, basePrice, dlvDate);
                    double netPrice = basePrice + PromotionDiscountAmount + FunntionDiscountamount + SurchargeDiscounamount;
                    double amounttotal = QuantityPro * netPrice * 1.1;

                    comm.Parameters.AddWithValue("@amount", netPrice); // numbar
                                                                       // EmptyCode
                    comm.Parameters.AddWithValue("@EmptyCode", Model.Product.productEmptycode(productCode)); // numbar
                    comm.Parameters.AddWithValue("@Emptyname", Model.Product.productEmptyName(productCode)); // numbar
                    // EmptyUnit  BasePrice KeyAccount
                    comm.Parameters.AddWithValue("@EmptyUnit", Model.Product.getemptyUnit(productCode)); // numbar
                    comm.Parameters.AddWithValue("@BasePrice", basePrice); // numbar
                    comm.Parameters.AddWithValue("@PromotionDiscount", PromotionDiscountAmount); // numbar
                    comm.Parameters.AddWithValue("@FuntionDiscount", FunntionDiscountamount); // numbar
                    comm.Parameters.AddWithValue("@SurchargeDiscount", SurchargeDiscounamount); // numbar
                    comm.Parameters.AddWithValue("@KeyAccount", keyAccount); // numbar

                    string ProducGroup = Model.Product.getProducgroupCode(productCode);
                    comm.Parameters.AddWithValue("@ProducGroup", ProducGroup); // numbar
                    comm.Parameters.AddWithValue("@totalAmount", amounttotal); // numbar



                    try
                    {
                        int temp = comm.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        //  throw;
                    }

                    conn.Close();




                }// for
                MessageBox.Show("Order: " + ordernumber + " Created Succsessfully !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lbOrdernumber.Text = ordernumber;
                dataGridetailorder.Enabled = false;
                bt_save.Visible = false;


            }
            #endregion tạo order




        }

        private void button6_Click(object sender, EventArgs e)
        {
            lbOrdernumber.Text = "0";
            dataGridetailorder.Enabled = true;
            bt_save.Visible = true;
            dateTimePicker1.Value = DateTime.Today.AddDays(-1);
            txtshipto.Text = "";
            lbshiptoname.Text = "";
            lb_address.Text = "";
            txtsoldto.Text = "";
            lbsoltoname.Text = "";
            Ponumber.Text = "";
            lbsalesRegion.Text = "";
            #region  load comboud sheck
            // tabControl1.TabPages.RemoveAt(1);





            List<ComboboxItem> collectionPlan = new List<ComboboxItem>();
            string connection_string = Utils.getAccessConnectionstring();
            OleDbConnection conn = new OleDbConnection(connection_string);

            // create an open the connection     
            DataSet ds = new DataSet();


            // create the adapter and fill the DataSet
            OleDbDataAdapter adapter =
             new OleDbDataAdapter("SELECT DISTINCT Plant FROM tbl_shipingointList ", conn);
            adapter.Fill(ds);

            // close the connection
            conn.Close();
            DataTable dt = ds.Tables[0];

            List<ComboboxItem> CombomCollection = new List<ComboboxItem>();
            foreach (DataRow dr in dt.Rows)
            {
                ComboboxItem cb = new ComboboxItem();
                //     ver = int.Parse(dr["ver"].ToString());
                cb.Value = dr["Plant"].ToString();
                cb.Text = dr["Plant"].ToString();
                CombomCollection.Add(cb);


            }

            cb_plant.DataSource = CombomCollection;


            // create an open the connection     
            DataSet ds1 = new DataSet();


            // create the adapter and fill the DataSet
            OleDbDataAdapter adapter1 =
             new OleDbDataAdapter("SELECT DISTINCT Shipingpoint FROM tbl_shipingointList ", conn);
            adapter1.Fill(ds1);

            // close the connection
            conn.Close();
            DataTable dt1 = ds1.Tables[0];

            List<ComboboxItem> CombomCollection1 = new List<ComboboxItem>();
            foreach (DataRow dr in dt1.Rows)
            {
                ComboboxItem cb = new ComboboxItem();
                //     ver = int.Parse(dr["ver"].ToString());
                cb.Value = dr["Shipingpoint"].ToString();
                cb.Text = dr["Shipingpoint"].ToString();
                CombomCollection1.Add(cb);


            }

            cb_shipingpoint.DataSource = CombomCollection1;


            #endregion load combound sellect

            // Load new datagread

            #region load order detail new




            // tbl_kaProgramedetailTemp tb = new tbl_kaProgramedetailTemp();

            //  tb.

            DataTable dt3 = new DataTable();

            dt3.Columns.Add(new DataColumn("Product_Code", typeof(string)));
            dt3.Columns.Add(new DataColumn("Amount", typeof(double)));
            dt3.Columns.Add(new DataColumn("Product_Name", typeof(string)));
            dt3.Columns.Add(new DataColumn("FreeCase", typeof(Boolean)));





            this.dataGridetailorder.DataSource = dt3;



            dataGridetailorder.Columns["Product_Code"].DisplayIndex = 0;
            dataGridetailorder.Columns["Product_Code"].Width = 100;
            dataGridetailorder.Columns["Product_Code"].HeaderText = "Product Code";
            this.dataGridetailorder.Columns["Product_Code"].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridetailorder.Columns["Amount"].DisplayIndex = 1;
            dataGridetailorder.Columns["Amount"].Width = 100;
            this.dataGridetailorder.Columns["Amount"].DefaultCellStyle.Format = "N0";

            this.dataGridetailorder.Columns["Amount"].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridetailorder.Columns["FreeCase"].DisplayIndex = 2;
            dataGridetailorder.Columns["FreeCase"].Width = 100;
            dataGridetailorder.Columns["FreeCase"].HeaderText = "Free Case";
            dataGridetailorder.Columns["FreeCase"].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridetailorder.Columns["Product_Name"].DisplayIndex = 3;
            dataGridetailorder.Columns["Product_Name"].Width = 380;
            dataGridetailorder.Columns["Product_Name"].HeaderText = "Product Name";
            dataGridetailorder.Columns["Product_Name"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridetailorder.Columns["Product_Name"].ReadOnly = true;
            dataGridetailorder.Columns["Product_Name"].DefaultCellStyle.BackColor = Color.AntiqueWhite;




            #endregion



            // load new data grid

        }
    }
}


