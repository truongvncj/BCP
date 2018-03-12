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


    public partial class BCPPrintIvoiceLoad : Form
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
        public DataTable dtorderToshipment { get; set; }
        public DataTable dtsumshipment { get; set; }

        public DataTable ReloadInvoiceListtoPrint(string shipment)

        {
            #region //    DataTable dataset1 = ut.ToDataTable(dc, rs1); head shipment ticket
            string connection_string = Utils.getAccessConnectionstring();

            OleDbConnection conn = new OleDbConnection(connection_string);
            conn.Open();

            //First(tbl_list_Order.Document) AS Order,
            //   First(tbl_list_Order.Sold_to_pt)AS Cust_code,
            //First(tbl_list_Order.Name_pt) AS Cust_name

            string StringQuery = @"Select 

 First(  tbl_list_Order.ID) as ID, 
                                      tbl_list_Order.Document, 
 First( tbl_list_Order.Shipment  ) as  Shipment,
      First(   tbl_list_Order.Purchase_order_number) as Po_InFormation, 
   First(       tbl_list_Order.Sold_to_pt ) as Sold_to_Code, 
    First(      tbl_list_Order.Name_pt ) as Name_Sold_to,  
     
    First(     tbl_list_Order.Shipto ) as Shipto_Code, 
    First(     tbl_list_Order.ShiptoName ) as ShiptoName


from  tbl_list_Order where 
                                tbl_list_Order.Shipment = @Shipment 
 and  tbl_list_Order.TicketPrintby <> @TicketPrintby 
 and  tbl_list_Order.InvoicePrintby = @InvoicePrintby 
group by 
   tbl_list_Order.Document
                                               "; //head of ticket

            OleDbCommand comm = new OleDbCommand(StringQuery, conn);
            //ADD PARAMS
            comm.Parameters.AddWithValue("@Shipment", shipment);
            comm.Parameters.AddWithValue("@TicketPrintby", "0");
            comm.Parameters.AddWithValue("@InvoicePrintby", "0");
            DataSet ds = new DataSet();

            // create the adapter and fill the DataSet

            // 
            OleDbDataAdapter adapter =
             new OleDbDataAdapter(comm);
            adapter.Fill(ds);
            conn.Close();
            return ds.Tables[0];

            //   gripOrdertomakeload.DataSource = dataset1; // detail ??
            #endregion // heard shipment
        }


        //      public void ReloadordertoShipment(string forder, string fname, string fcode)
        //      {
        //          string connection_string = Utils.getAccessConnectionstring();

        //          OleDbConnection conn = new OleDbConnection(connection_string);
        //          conn.Open();

        //          ///???????????????????????
        //          // ll
        //          //   string StringQuery = @"Select First(tbl_list_Order.ID) as ID,   tbl_list_Order.Document ,  First( tbl_list_Order.Sold_to_pt) as Sold_to,  First( tbl_list_Order.Name_pt ) as Name, First(tbl_list_Order.totalAmount ) as TotalAmount from  tbl_list_Order where tbl_list_Order.AR_release = @AR_release and  tbl_list_Order.Document   like @Document and tbl_list_Order.Name_pt like @Name_pt and tbl_list_Order.Sold_to_pt like @Sold_to_pt GROUP BY    tbl_list_Order.Document ";

        //          //   OleDbCommand comm = new OleDbCommand(StringQuery, conn);
        //          string StringQuery = @"Select 

        // tbl_list_Order.ID, 
        //                              tbl_list_Order.Document,  
        // tbl_list_Order.Purchase_order_number, 
        // tbl_list_Order.Sold_to_pt,  
        // tbl_list_Order.Name_pt,  
        // tbl_list_Order.Order_qty,  
        // tbl_list_Order.Description,  
        //tbl_list_Order.Shipto, 
        //tbl_list_Order.ShiptoName

        // from  tbl_list_Order where 
        //                                          tbl_list_Order.AR_release = @AR_release 
        //                                        AND tbl_list_Order.Shipment = @Shipment 
        //                                           AND tbl_list_Order.ShippingPoint = @ShippingPoint 
        //                                        AND tbl_list_Order.Document like @Document 
        //                                      AND tbl_list_Order.Name_pt like @Name_pt 
        //                                        AND tbl_list_Order.Sold_to_pt like @Sold_to_pt 

        //                                                                                  "; //ShippingPoint

        //          OleDbCommand comm = new OleDbCommand(StringQuery, conn);
        //          //ADD PARAMS
        //          comm.Parameters.AddWithValue("@AR_release", true);
        //          comm.Parameters.AddWithValue("@Shipment", 0);
        //          comm.Parameters.AddWithValue("@ShippingPoint", (cb_shipingpoint.SelectedItem as ComboboxItem).Value.ToString());
        //          comm.Parameters.AddWithValue("@Document", "%" + forder + "%");// Name_pt
        //          comm.Parameters.AddWithValue("@Name_pt", "%" + fname + "%");// Name_pt
        //          comm.Parameters.AddWithValue("@Sold_to_pt", "%" + fcode + "%");// Name_pt

        //          DataSet ds = new DataSet();

        //          // create the adapter and fill the DataSet

        //          // 
        //          OleDbDataAdapter adapter =
        //           new OleDbDataAdapter(comm);
        //          adapter.Fill(ds);
        //          conn.Close();
        //          DataTable dt1 = ds.Tables[0];
        //          // close the connection



        //          gripOrdertomakeload.DataSource = dt1;



        //      }



        public BCPPrintIvoiceLoad()
        {
            InitializeComponent();

            #region  // Load shipping point
            string connection_string = Utils.getAccessConnectionstring();
            string userPlant = Model.UsernameInfor.getUserplant();
            OleDbConnection conn = new OleDbConnection(connection_string);


            conn.Open();

            string StringQuery = @"SELECT DISTINCT Shipingpoint FROM tbl_shipingointList
                                    WHERE 
                                        tbl_shipingointList.Plant = @Plant
                                                                        ";


            OleDbCommand comm = new OleDbCommand(StringQuery, conn);


            comm.Parameters.AddWithValue("@Plant", userPlant);
            //comm.Parameters.AddWithValue("@Plant", (cb_plant.SelectedItem as ComboboxItem).Text.ToString());
            //comm.Parameters.AddWithValue("@sales_region", lbsalesRegion.Text.ToString());
            //comm.Parameters.AddWithValue("@Purchase_order_number", Ponumber.Text.ToString().Trim() + " ;" + lb_address.Text.ToString().Trim());
            //comm.Parameters.AddWithValue("@Address", lb_address.Text.ToString().Trim());


            //OleDbParameter parm = new OleDbParameter("@DlvDate", OleDbType.Date);
            //parm.Value = dateTimePicker1.Value;
            //comm.Parameters.Add(parm);

            //comm.Parameters.AddWithValue("@Document", int.Parse(ordernumber));
            //comm.Parameters.AddWithValue("@Sold_to_pt", int.Parse(txtsoldto.Text.ToString())); // numbar
            //                                                                                   //  comm.Parameters.AddWithValue("@txtshipto", int.Parse(txtshipto.Text.ToString())); // numbar
            //comm.Parameters.AddWithValue("@Name_pt", lbsoltoname.Text.ToString());

            //comm.Parameters.AddWithValue("@Material", dataGridetailorder.Rows[idrow].Cells["Product_Code"].Value.ToString().Trim());
            //comm.Parameters.AddWithValue("@Description", dataGridetailorder.Rows[idrow].Cells["Product_Name"].Value.ToString());
            //comm.Parameters.AddWithValue("@Order_qty", int.Parse(dataGridetailorder.Rows[idrow].Cells["Amount"].Value.ToString()));// number
            //comm.Parameters.AddWithValue("@fRECASSE", dataGridetailorder.Rows[idrow].Cells["FreeCase"].Value);  //FreeCase
            //comm.Parameters.AddWithValue("@Shipto", int.Parse(txtshipto.Text.ToString())); // numbar

            //comm.Parameters.AddWithValue("@ShiptoName", lbshiptoname.Text.ToString()); // numbar ShippingPoint
            //comm.Parameters.AddWithValue("@ShippingPoint", (cb_shipingpoint.SelectedItem as ComboboxItem).Text.ToString()); // numbar ShippingPoint

            //OleDbParameter parm2 = new OleDbParameter("@CreateDate", OleDbType.Date);
            //parm2.Value = DateTime.Today;
            //comm.Parameters.Add(parm2);

            //   created dataset
            DataSet ds = new DataSet();


            // create the adapter and fill the DataSet
            OleDbDataAdapter adapter =
             new OleDbDataAdapter(comm);


            adapter.Fill(ds);

            // close the connection
            conn.Close();
            DataTable dt = ds.Tables[0];

            List<ComboboxItem> CombomCollection = new List<ComboboxItem>();
            foreach (DataRow dr in dt.Rows)
            {
                ComboboxItem cb = new ComboboxItem();
                //     ver = int.Parse(dr["ver"].ToString());
                cb.Value = dr["Shipingpoint"].ToString();
                cb.Text = dr["Shipingpoint"].ToString();
                CombomCollection.Add(cb);


            }

            cb_shipingpoint.DataSource = CombomCollection;
            #endregion   // load shipping point



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
        //    dataGridrelease.Columns.Add(cmbdgv);

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

        //    dataGridrelease.Columns.Add(cmbdgv);

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

        //    dataGridrelease.Columns.Add(cmbdgv);

        //}


        //  cmbdgv.Items.Add("Test");


        void cbm_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BeginInvoke(new MethodInvoker(EndEdit));

        }
        //    ComboBox cbm;
        //    DataGridViewCell currentCell;
        //  private DateTimePicker cellDateTimePicker = new DateTimePicker();
        // DateTimePicker[] sp = new DateTimePicker[100];
        void EndEdit()
        {




            //if (cbm != null)
            //{
            //    if (cbm.SelectedItem != null)
            //    {
            //        string SelectedItem = (cbm.SelectedItem as ComboboxItem).Value.ToString();// (cbm.SelectedItem as ComboboxItem).Value.ToString();

            //        // int i = dataGridProgramdetail.CurrentRow.Index;
            //        int i = currentCell.RowIndex;
            //        string colname = this.dataGridrelease.Columns[this.dataGridrelease.CurrentCell.ColumnIndex].Name;

            //        dataGridrelease.Rows[i].Cells[colname].Value = SelectedItem;
            //        //      MessageBox.Show(dataGridProgramdetail.Rows[i].Cells["Program"].Value.ToString());

            //    }





            //}


            //}
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //reloadARUNreleasesechac(txcodeunrelease.Text.ToString(), txtnameunrelease.Text.ToString(), txtcodef.Text.ToString());
        }



        private void txtnameunrelease_TextChanged(object sender, EventArgs e)
        {
            //reloadARUNreleasesechac(txcodeunrelease.Text.ToString(), txtnameunrelease.Text.ToString(), txtcodef.Text.ToString());
        }



        private void txtcodef_TextChanged(object sender, EventArgs e)
        {
            //reloadARUNreleasesechac(txcodeunrelease.Text.ToString(), txtnameunrelease.Text.ToString(), txtcodef.Text.ToString());

        }

        private void dataGridOrderUnrelease_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // this.dtorderToshipment = dt;

            //dr1["Amount"] = dr["Order_qty"].ToString();
            //dr1["Product_Name"] = dr["Description"].ToString();
            //dr1["FreeCase"] = (Boolean)dr["fRECASSE"];

        }

        private void dataGridOrderUnrelease_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {


            //if (this.gripOrdertomakeload.Rows[this.gripOrdertomakeload.CurrentCell.RowIndex].Cells["Document"].Value != DBNull.Value)
            //{
            //    string myuser = Model.UsernameInfor.getUsername();
            //    string keepingUser = Model.Orders.getUsermakeorderinShipmenttemp(int.Parse(this.gripOrdertomakeload.Rows[this.gripOrdertomakeload.CurrentCell.RowIndex].Cells["Document"].Value.ToString()));
            //    if (keepingUser == myuser)
            //    {
            //        MessageBox.Show("Order added !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);


            //    }

            //    if (keepingUser != myuser && keepingUser != "")
            //    {
            //        DialogResult dialogResult = MessageBox.Show("Order kept by :" + keepingUser + ", please contact user " + keepingUser, "Thông báo", MessageBoxButtons.YesNo);
            //        if (dialogResult == DialogResult.Yes)
            //        {
            //            //  MessageBox.Show("Order added !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            //DataRow dr1 = dtorderToshipment.Rows.Add();
            //            //dr1["Order"] = this.gripOrdertomakeload.Rows[this.gripOrdertomakeload.CurrentCell.RowIndex].Cells["Document"].Value.ToString();
            //            //dr1["Cust_code"] = this.gripOrdertomakeload.Rows[this.gripOrdertomakeload.CurrentCell.RowIndex].Cells["Sold_to_pt"].Value.ToString();
            //            //dr1["Cust_name"] = this.gripOrdertomakeload.Rows[this.gripOrdertomakeload.CurrentCell.RowIndex].Cells["Name_pt"].Value.ToString();

            //        }
            //        else if (dialogResult == DialogResult.No)
            //        {
            //            //do something else
            //        }

            //    }

            //    if (keepingUser == "")
            //    {
            //        DataRow dr1 = dtorderToshipment.Rows.Add();
            //        dr1["Order"] = this.gripOrdertomakeload.Rows[this.gripOrdertomakeload.CurrentCell.RowIndex].Cells["Document"].Value.ToString();
            //        dr1["Cust_code"] = this.gripOrdertomakeload.Rows[this.gripOrdertomakeload.CurrentCell.RowIndex].Cells["Sold_to_pt"].Value.ToString();
            //        dr1["Cust_name"] = this.gripOrdertomakeload.Rows[this.gripOrdertomakeload.CurrentCell.RowIndex].Cells["Name_pt"].Value.ToString();


            //    }


            //}

            //RecaculationProductsum();
        }

        private void dataGridunrelease_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //DataRow dr1 = this.dtordertoUNrelese.Rows.Add();
            //dr1["Order"] = this.dataGridunrelease.Rows[this.dataGridunrelease.CurrentCell.RowIndex].Cells["Document"].Value.ToString();

        }


        private void tab_Release_Click(object sender, EventArgs e)
        {

        }

        private void cb_shipingpoint_SelectedValueChanged(object sender, EventArgs e)
        {
            //  tabControl1.Enabled = true;
            //    loadNewviewShipment();

        }

        private void cb_shipingpoint_SelectedIndexChanged(object sender, EventArgs e)
        {
            //  tabControl1.Enabled = true;




        }

        private void txtcodefind_TextChanged(object sender, EventArgs e)
        {
            //     ReloadordertoShipment(txtcustcodefind.Text, txtnamefind.Text, txtcodefind.Text);
        }

        private void txtcustcodefind_TextChanged(object sender, EventArgs e)
        {
            //  ReloadordertoShipment(txtcustcodefind.Text, txtnamefind.Text, txtcodefind.Text);
        }

        private void txtnamefind_TextChanged(object sender, EventArgs e)
        {
            //  ReloadordertoShipment(txtcustcodefind.Text, txtnamefind.Text, txtcodefind.Text);
        }

        private void dataGRDetailshipment_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            //  sender.
            //foreach (DataRow dr in dtorderToshipment.Rows)
            //{
            //int orderNumber = int.Parse(dr["Order"].ToString());
            //if (orderNumber == int.Parse(dataGRDetailshipment.Rows[e.RowIndex].Cells["Order"].Value.ToString()))
            //{
            // DataRow dr = dtorderToshipment.Rows[e.RowIndex];
            //   dtorderToshipment.Rows.Remove(dr);

            //}

            //}



            //     RecaculationProductsum();


        }

        private void dataGRDetailshipment_AllowUserToOrderColumnsChanged(object sender, EventArgs e)
        {

        }

        private void dataGRDetailshipment_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            //    RecaculationProductsum();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //View.BCPvalueinput input = new BCPvalueinput("Input Order", lb_shipmentNo.Text);
            //input.ShowDialog();
            //string ValueText = input.valuetext;
            //bool kq = input.kq;

            //if (kq && Utils.IsValidnumber(ValueText))
            //{




            //}



        }

        private void tbnewshipment_Click(object sender, EventArgs e)
        {
            //   lb_shipmentNo.Text = "0";
            // loadNewviewShipment();

        }

        private void btprintPallet_Click(object sender, EventArgs e)
        {

            //  View.BCPvalueinput input = new BCPvalueinput("Input Shiment", lb_shipmentNo.Text);
            //   input.ShowDialog();
            string ValueText = lbshipmentNo.Text.ToString();
            //   bool kq = input.kq;

            if (Utils.IsValidnumber(ValueText) && ValueText != "0")
            {
                //select 
                #region //    DataTable dataset1 = ut.ToDataTable(dc, rs1); head shipment ticket
                string connection_string = Utils.getAccessConnectionstring();

                OleDbConnection conn = new OleDbConnection(connection_string);
                conn.Open();

                //First(tbl_list_Order.Document) AS Order,
                //   First(tbl_list_Order.Sold_to_pt)AS Cust_code,
                //First(tbl_list_Order.Name_pt) AS Cust_name

                string StringQuery = @"Select First( tbl_list_Ordershipment.Shipment) AS Shipment ,
                                First( tbl_list_Ordershipment.DescriptionPallet) AS Palletname ,
   First( tbl_list_Ordershipment.MaterialPallet) AS Palletcode ,
                                    First( tbl_list_Ordershipment.amountPallet) AS PalletQuantity ,
    First( tbl_list_Ordershipment.Transposterby) AS Tranpostername ,
                                        First( tbl_list_Ordershipment.TruckNumber) AS Truckno


from  tbl_list_Ordershipment where 
                                tbl_list_Ordershipment.Shipment = @Shipment 
                                
                                               "; //head of ticket

                OleDbCommand comm = new OleDbCommand(StringQuery, conn);
                //ADD PARAMS
                comm.Parameters.AddWithValue("@Shipment", ValueText);
                DataSet ds = new DataSet();

                // create the adapter and fill the DataSet

                // 
                OleDbDataAdapter adapter =
                 new OleDbDataAdapter(comm);
                adapter.Fill(ds);
                conn.Close();
                DataTable dataset1 = ds.Tables[0];
                //   gripOrdertomakeload.DataSource = dataset1; // detail ??
                #endregion // heard shipment


//                #region //    DataTable dataset1 = ut.ToDataTable(dc, rs1); head shipment ticket
//                string connection_string = Utils.getAccessConnectionstring();

//                OleDbConnection conn = new OleDbConnection(connection_string);
//                conn.Open();

//                //First(tbl_list_Order.Document) AS Order,
//                //   First(tbl_list_Order.Sold_to_pt)AS Cust_code,
//                //First(tbl_list_Order.Name_pt) AS Cust_name

//                string StringQuery = @"Select First( tbl_list_Order.Shipment) AS Shipment ,
//                                First( tbl_list_Order.Sold_to_pt) AS Cust_code ,
//                                    First( tbl_list_Order.Name_pt) AS Cust_name ,
//                                        First( tbl_list_Order.Document) AS OrderNumber


//from  tbl_list_Order where 
//                                tbl_list_Order.Shipment = @Shipment 
//                                    Group by 
//                                    tbl_list_Order.Document
//                                               "; //head of ticket

//                OleDbCommand comm = new OleDbCommand(StringQuery, conn);
//                //ADD PARAMS
//                comm.Parameters.AddWithValue("@Shipment", ValueText);
//                DataSet ds = new DataSet();

//                // create the adapter and fill the DataSet

//                // 
//                OleDbDataAdapter adapter =
//                 new OleDbDataAdapter(comm);
//                adapter.Fill(ds);
//                conn.Close();
//                DataTable dataset1 = ds.Tables[0];
//                //   gripOrdertomakeload.DataSource = dataset1; // detail ??
//                #endregion // heard shipment


                #region  //  DataTable dataset2 = ut.ToDataTable(dc, rs2); detail shipment ticket
                //  string connection_string = Utils.getAccessConnectionstring();

                //OleDbConnection conn = new OleDbConnection(connection_string);
                conn.Open();

                string StringQuery2 = @"Select First( tbl_list_Order.Material) AS Productcode, 
                               sum( tbl_list_Order.Order_qty ) AS OrderQuantity,  
                                First( tbl_list_Order.Description) AS ProductName,  
                             First(  tbl_list_Order.Unit) AS UnitCase

                                 from  tbl_list_Order where 
                                tbl_list_Order.Shipment = @Shipment 
                                    Group by 
                                    tbl_list_Order.Material
                                               "; //head of ticket

                OleDbCommand comm2 = new OleDbCommand(StringQuery2, conn);
                //ADD PARAMS
                comm2.Parameters.AddWithValue("@Shipment", ValueText);
                DataSet ds2 = new DataSet();

                // create the adapter and fill the DataSet

                // 
                OleDbDataAdapter adapter2 =
                 new OleDbDataAdapter(comm2);
                adapter2.Fill(ds2);
                conn.Close();
                DataTable dataset2 = ds2.Tables[0];  /// head

                // MessageBox.Show(dataset2.Rows.Count.ToString());
                #endregion  //  DataTable dataset2 = ut.ToDataTable(dc, rs2); detail shipment ticket

                Reportsview rpt = new Reportsview(dataset1, dataset2, "Load.rdlc", ValueText, "", "");
                rpt.ShowDialog();



            }




        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void bt_inputshipment_Click(object sender, EventArgs e)
        {
            View.BCPvalueinput input = new BCPvalueinput("Input Shiment", lb_shipmentNo.Text);
            input.ShowDialog();
            string ValueText = input.valuetext;// lbshipmentNo.Text.ToString();
            bool kq = input.kq;

            if (Utils.IsValidnumber(ValueText) && ValueText != "0")
            {
                //select 
                #region //    DataTable dataset1 = ut.ToDataTable(dc, rs1); head shipment ticket
                string connection_string = Utils.getAccessConnectionstring();

                OleDbConnection conn = new OleDbConnection(connection_string);
                conn.Open();

                //First(tbl_list_Order.Document) AS Order,
                //   First(tbl_list_Order.Sold_to_pt)AS Cust_code,
                //First(tbl_list_Order.Name_pt) AS Cust_name

                string StringQuery = @"Select * 
from  tbl_list_Order where 
                                tbl_list_Order.Shipment = @Shipment 
 and  tbl_list_Order.TicketPrintby <> "" 
 and  tbl_list_Order.InvoicePrintby = "" 
  and         tbl_list_Order.ShippingPoint = @ShippingPoint                         
                                               "; //head of ticket

                OleDbCommand comm = new OleDbCommand(StringQuery, conn);
                //ADD PARAMS
                comm.Parameters.AddWithValue("@Shipment", ValueText);
                comm.Parameters.AddWithValue("@ShippingPoint", (cb_shipingpoint.SelectedItem as ComboboxItem).Text.ToString());
                DataSet ds = new DataSet();

                // create the adapter and fill the DataSet

                // 
                OleDbDataAdapter adapter =
                 new OleDbDataAdapter(comm);
                adapter.Fill(ds);
                conn.Close();
                DataTable dataset1 = ds.Tables[0];
                //   gripOrdertomakeload.DataSource = dataset1; // detail ??
                #endregion // heard shipment

                if (dataset1.Rows.Count > 0)
                {
                    lbshipmentNo.Text = ValueText; // gắt ó shipment

                    dataGRdetailInvoiceOfSM.DataSource = ReloadInvoiceListtoPrint(ValueText);


                }



            }
            else
            {
                lbshipmentNo.Text = "0";
                MessageBox.Show("Please check shipment number again !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void dataGRdetailInvoiceOfSM_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {







        }

        private void dataGRdetailInvoiceOfSM_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // view va in hóa don 

            string myuser = Model.UsernameInfor.getUsername();
            string OrderNo = "";
            try
            {
                OrderNo = this.dataGRdetailInvoiceOfSM.Rows[this.dataGRdetailInvoiceOfSM.CurrentCell.RowIndex].Cells["Document"].Value.ToString();

            }
            catch (Exception)
            {

                //throw;
            }


            if (OrderNo != "")/// best regadrs
            {
                //select 
                #region //   invoice head data
                string connection_string = Utils.getAccessConnectionstring();

                OleDbConnection conn = new OleDbConnection(connection_string);
                conn.Open();

                //First(tbl_list_Order.Document) AS Order,
                //   First(tbl_list_Order.Sold_to_pt)AS Cust_code,
                //First(tbl_list_Order.Name_pt) AS Cust_name

                string StringQuery = @"Select First( tbl_list_Order.Document) AS Invoiceinfor ,
                                First( tbl_list_Order.Sold_to_pt) AS code ,
                                    First( tbl_list_Order.Name_pt) AS name ,
                                        First( tbl_list_Order.Address) AS Address,
   First( tbl_list_Order.Shipment) AS shipment,
  First( tbl_list_Order.Purchase_order_number) AS po


 


from  tbl_list_Order where 
                                tbl_list_Order.Document = @Document 
                                    Group by 
                                    tbl_list_Order.Document
                                               "; //head of invoice
                                                  //  '    ; First(tbl_list_Order.taxCode) AS taxcode,
                                                  //First(tbl_list_Order.taxRate) AS taxRate

                OleDbCommand comm = new OleDbCommand(StringQuery, conn);
                //ADD PARAMS
                comm.Parameters.AddWithValue("@Document", OrderNo);
                //  comm.Parameters.AddWithValue("@myuser", myuser);
                DataSet ds = new DataSet();

                // create the adapter and fill the DataSet

                // 
                OleDbDataAdapter adapter =
                 new OleDbDataAdapter(comm);
                adapter.Fill(ds);
                conn.Close();
                DataTable dataset1 = ds.Tables[0];
                //   dt.Columns.Add(new DataColumn("ExtNote", typeof(string)));


                DataColumn colmyname = new DataColumn();
                colmyname.DataType = typeof(string);
                colmyname.ColumnName = "prrintby";
                colmyname.DefaultValue = myuser;
                dataset1.Columns.Add(colmyname);

                DataColumn colinvoicedate = new DataColumn();
                colinvoicedate.DataType = typeof(DateTime);
                colinvoicedate.ColumnName = "invoicedate";
                colinvoicedate.DefaultValue = DateTime.Today;
                dataset1.Columns.Add(colinvoicedate);


                DataColumn coltaxcode = new DataColumn();
                coltaxcode.DataType = typeof(string);
                coltaxcode.ColumnName = "taxcode";
                coltaxcode.DefaultValue = Model.Orders.gettaxcode(Model.Orders.getSoldtocode(OrderNo));
                dataset1.Columns.Add(coltaxcode);


                DataColumn coltaxRate = new DataColumn();
                coltaxRate.DataType = typeof(string);
                coltaxRate.ColumnName = "taxRate";
                coltaxRate.DefaultValue = Model.Orders.gettaxRate(Model.Orders.getSoldtocode(OrderNo), Model.Orders.getSalesregion(OrderNo));
                dataset1.Columns.Add(coltaxRate);


                DataColumn colIDpage1 = new DataColumn();
                colIDpage1.DataType = typeof(int);
                colIDpage1.ColumnName = "IDpage";
                colIDpage1.DefaultValue = 1;// Model.Orders.gettaxRate(Model.Orders.getSoldtocode(OrderNo), Model.Orders.getSalesregion(OrderNo));
                dataset1.Columns.Add(colIDpage1);
                #endregion // heard shipment

                #region  //  DataTable dataset2 = ut.ToDataTable(dc, rs2); detail shipment ticket
                //  string connection_string = Utils.getAccessConnectionstring();

                //OleDbConnection conn = new OleDbConnection(connection_string);
                conn.Open();

                string StringQuery2 = @"Select  tbl_list_Order.Material AS product_code, 
                            tbl_list_Order.Order_qty AS quantity,  
                                tbl_list_Order.Description AS product_name,  
     tbl_list_Order.amount AS Netprice,  
tbl_list_Order.Order_qty*tbl_list_Order.amount as Total,
 tbl_list_Order.EmptyCode AS emptycode,  
 tbl_list_Order.Order_qty AS emptyquantity,  
tbl_list_Order.Emptyname AS emptyname,  
 


                               tbl_list_Order.Unit AS Unit



                                 from  tbl_list_Order where 
                                tbl_list_Order.Document = @Document 
                                
                                               "; //head of ticket

                OleDbCommand comm2 = new OleDbCommand(StringQuery2, conn);
                //ADD PARAMS
                comm2.Parameters.AddWithValue("@Document", OrderNo);
                DataSet ds2 = new DataSet();

                // create the adapter and fill the DataSet

                // 
                OleDbDataAdapter adapter2 =
                 new OleDbDataAdapter(comm2);
                adapter2.Fill(ds2);
                conn.Close();
                DataTable dataset2 = ds2.Tables[0];  /// head
                //  IDpage  them vao va chỉnh group nhóm page

                DataColumn colIDpage = new DataColumn();
                colIDpage.DataType = typeof(int);
                colIDpage.ColumnName = "IDpage";
                colIDpage.DefaultValue = 1;// Model.Orders.gettaxRate(Model.Orders.getSoldtocode(OrderNo), Model.Orders.getSalesregion(OrderNo));
                dataset2.Columns.Add(colIDpage);

                // IDrow

                DataColumn colIDrow = new DataColumn();
                colIDrow.DataType = typeof(int);
                colIDrow.ColumnName = "IDrow";
                //  'colIDpage.DefaultValue = Model.Orders.gettaxRate(Model.Orders.getSoldtocode(OrderNo), Model.Orders.getSalesregion(OrderNo));
                dataset2.Columns.Add(colIDrow);



                int pageid = 1;
                int rowscout = 0;
                //   string product_codecheck ="";
                foreach (DataRow dr in dataset2.Rows)
                {
                    //  MessageBox.Show((dr["username"].ToString()));
                    rowscout = rowscout + 1;
                    //  product_codecheck = dr["product_code"].ToString();

                    dr["IDrow"] = rowscout.ToString();
                    dr["IDpage"] = pageid.ToString();
                    if (rowscout == 10)
                    {
                        rowscout = 0;
                        pageid = pageid + 1;

                    }

                }

                for (int i = 0; i < 10 - rowscout; i++)
                {
                    DataRow dr = dataset2.Rows.Add();
                    //   dataset1.Rows.Add();
                    dr["product_code"] = "   ";
                    //   dr["IDrow"] = rowscout.ToString();
                    dr["IDpage"] = pageid.ToString();
                }
                //   dataset1
                if (pageid > 1)
                {
                    for (int i = 2; i <= pageid; i++)
                    {

                        //      DataRow dr = dataset1.Rows[1];

                        //   tab2.Rows.Add(tab1.Rows[0].ItemArray)

                        DataRow dr = dataset1.Rows.Add(dataset1.Rows[0].ItemArray);


                        dr["IDpage"] = i.ToString();
                    }
                }






                // MessageBox.Show(dataset2.Rows.Count.ToString());
                #endregion  //  DataTable dataset2 = ut.ToDataTable(dc, rs2); detail shipment ticket

                Reportsview rpt = new Reportsview(dataset1, dataset2, "Invoice.rdlc", "", OrderNo, "");
                rpt.ShowDialog();




            }




            // Reload lại data grid để in tiếp
            dataGRdetailInvoiceOfSM.DataSource = ReloadInvoiceListtoPrint(lbshipmentNo.Text);


        }


        //private void dataGridProgramdetail_EditingControlShowing_1(object sender, DataGridViewEditingControlShowingEventArgs e)
        //{
        //    if (e.Control is ComboBox)
        //    {

        //        cbm = (ComboBox)e.Control;

        //        if (cbm != null)
        //        {
        //            cbm.SelectedIndexChanged += new EventHandler(cbm_SelectedIndexChanged);
        //        }

        //        currentCell = this.dataGridrelease.CurrentCell;

        //    }
        //}

        //private void dataGridProgramdetail_CellClick(object sender, DataGridViewCellEventArgs e)
        //{


        //    //string colheadertext = this.dataGridProgramdetail.Columns[this.dataGridProgramdetail.CurrentCell.ColumnIndex].HeaderText;
        //    //if (colheadertext == "TargetUnit")
        //    //{

        //    //    if (this.dataGridProgramdetail.Rows[this.dataGridProgramdetail.CurrentCell.RowIndex].Cells["Payment_Control"].Value != null && this.dataGridProgramdetail.Rows[this.dataGridProgramdetail.CurrentCell.RowIndex].Cells["Program"].Value != null)
        //    //    {

        //    //        string paymentcontrol = this.dataGridProgramdetail.Rows[this.dataGridProgramdetail.CurrentCell.RowIndex].Cells["Payment_Control"].Value.ToString();
        //    //        string progarme = this.dataGridProgramdetail.Rows[this.dataGridProgramdetail.CurrentCell.RowIndex].Cells["Program"].Value.ToString();



        //    //        MessageBox.Show("ok done !" + paymentcontrol + ":" + progarme);
        //    //    }
        //    //}


        //}

        //private void dataGridProgramdetail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        //{

        //    string colname = this.dataGridrelease.Columns[this.dataGridrelease.CurrentCell.ColumnIndex].Name;

        //    //  MessageBox.Show(colname);
        //    if (colname == "Program")
        //    {
        //        if (this.dataGridrelease.Rows[this.dataGridrelease.CurrentCell.RowIndex].Cells["Program"].Value != null) // && this.dataGridProgramdetail.Rows[this.dataGridProgramdetail.CurrentCell.RowIndex].Cells["Program"].Value != null
        //        {
        //            string programe = this.dataGridrelease.Rows[this.dataGridrelease.CurrentCell.RowIndex].Cells["Program"].Value.ToString();



        //            if (programe.Trim() == "DIS")  //     discount on invocie
        //            {
        //                //   MessageBox.Show(programe);

        //                //    dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
        //                dataGridrelease.Rows[e.RowIndex].Cells["Payment_Control"].Style.BackColor = Color.White;
        //                dataGridrelease.Rows[e.RowIndex].Cells["Payment_Control"].Style.ForeColor = Color.Blue;

        //                if (dataGridrelease.Rows[e.RowIndex].Cells["Payment_Control"].Value == null || dataGridrelease.Rows[e.RowIndex].Cells["Payment_Control"].Value.ToString().Trim() != "DIS")
        //                {
        //                    dataGridrelease.Rows[e.RowIndex].Cells["Payment_Control"].Value = "DIS";
        //                }


        //            }





        //        }

        //    }



        //}


    }
}


