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


    public partial class BCPShipmentCreate : Form
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

        public void ReloadordertoShipment(string forder, string fname, string fcode)
        {
            string connection_string = Utils.getAccessConnectionstring();

            OleDbConnection conn = new OleDbConnection(connection_string);
            conn.Open();

            ///???????????????????????
            // ll
            //   string StringQuery = @"Select First(tbl_list_Order.ID) as ID,   tbl_list_Order.Document ,  First( tbl_list_Order.Sold_to_pt) as Sold_to,  First( tbl_list_Order.Name_pt ) as Name, First(tbl_list_Order.totalAmount ) as TotalAmount from  tbl_list_Order where tbl_list_Order.AR_release = @AR_release and  tbl_list_Order.Document   like @Document and tbl_list_Order.Name_pt like @Name_pt and tbl_list_Order.Sold_to_pt like @Sold_to_pt GROUP BY    tbl_list_Order.Document ";

            //   OleDbCommand comm = new OleDbCommand(StringQuery, conn);
            string StringQuery = @"Select tbl_list_Order.ID, 
                                tbl_list_Order.Document,  
   tbl_list_Order.Purchase_order_number, 
   tbl_list_Order.Sold_to_pt,  
   tbl_list_Order.Name_pt,  
   tbl_list_Order.Order_qty,  
   tbl_list_Order.Description,  
  tbl_list_Order.Shipto, 
  tbl_list_Order.ShiptoName
   from  tbl_list_Order where 
                                            tbl_list_Order.AR_release = @AR_release 
                                          AND tbl_list_Order.Shipment = @Shipment 
                                             AND tbl_list_Order.ShippingPoint = @ShippingPoint 
                                          AND tbl_list_Order.Document like @Document 
                                        AND tbl_list_Order.Name_pt like @Name_pt 
                                          AND tbl_list_Order.Sold_to_pt like @Sold_to_pt 
  
                                                                                    "; //ShippingPoint

            OleDbCommand comm = new OleDbCommand(StringQuery, conn);
            //ADD PARAMS
            comm.Parameters.AddWithValue("@AR_release", true);
            comm.Parameters.AddWithValue("@Shipment", 0);
            comm.Parameters.AddWithValue("@ShippingPoint", (cb_shipingpoint.SelectedItem as ComboboxItem).Value.ToString());
            comm.Parameters.AddWithValue("@Document", "%" + forder + "%");// Name_pt
            comm.Parameters.AddWithValue("@Name_pt", "%" + fname + "%");// Name_pt
            comm.Parameters.AddWithValue("@Sold_to_pt", "%" + fcode + "%");// Name_pt

            DataSet ds = new DataSet();

            // create the adapter and fill the DataSet

            // 
            OleDbDataAdapter adapter =
             new OleDbDataAdapter(comm);
            adapter.Fill(ds);
            conn.Close();
            DataTable dt1 = ds.Tables[0];
            // close the connection



            gripOrdertomakeload.DataSource = dt1;



        }
        public void RecaculationProductsum()
        {
            // tbl_shipment_temp

            #region    // xóa tem shipment với o order và user name
            string username = Utils.getUsername();
            //  string st = "Delete from tbl_list_Order where tbl_list_Order.Document = @Ordernumber";
            string connection_string = Utils.getAccessConnectionstring();
            OleDbConnection conn = new OleDbConnection(connection_string);

            string StringQuery = @"Delete from tbl_shipment_temp where 
                                                 tbl_shipment_temp.Createby = @Createby
                                                                      ";
            conn.Open();
            OleDbCommand comm = new OleDbCommand(StringQuery, conn);

            comm.Parameters.AddWithValue("@Createby", username);

            int temp = comm.ExecuteNonQuery();
            conn.Close();

            #endregion    // xóa tem shipment với o order và user name

            #region // insertorder to temp
            //    dataGRDetailshipment
            if (dtorderToshipment.Rows.Count > 0)
            {
                foreach (DataRow dr in dtorderToshipment.Rows)
                {


                    int orderNumber = int.Parse(dr["Order"].ToString());

                    //  OleDbConnection conn = new OleDbConnection(connection_string);
                    conn.Open();

                    ///???????????????????????
                    // ll
                    //   string StringQuery = @"Select First(tbl_list_Order.ID) as ID,   tbl_list_Order.Document ,  First( tbl_list_Order.Sold_to_pt) as Sold_to,  First( tbl_list_Order.Name_pt ) as Name, First(tbl_list_Order.totalAmount ) as TotalAmount from  tbl_list_Order where tbl_list_Order.AR_release = @AR_release and  tbl_list_Order.Document   like @Document and tbl_list_Order.Name_pt like @Name_pt and tbl_list_Order.Sold_to_pt like @Sold_to_pt GROUP BY    tbl_list_Order.Document ";

                    //   OleDbCommand comm = new OleDbCommand(StringQuery, conn);
                    string StringQuery2 = @"Select     
                                           tbl_list_Order.Material,  
                                           tbl_list_Order.Order_qty,  
                                           tbl_list_Order.Description 
 
                                           from  tbl_list_Order where 
                                                   tbl_list_Order.Document = @Document   ";

                    OleDbCommand comm2 = new OleDbCommand(StringQuery2, conn);
                    //ADD PARAMS
                    comm2.Parameters.AddWithValue("@Document", orderNumber);


                    DataSet ds2 = new DataSet();
                    // 
                    OleDbDataAdapter adapter2 =
                     new OleDbDataAdapter(comm2);
                    adapter2.Fill(ds2);
                    conn.Close();
                    DataTable dt2 = ds2.Tables[0];
                    if (dt2.Rows.Count > 0)
                    {
                        foreach (DataRow dr1 in dt2.Rows)
                        {


                            #region  insert to shipment temp vói creating shipment = true


                            //    OleDbConnection conn = new OleDbConnection(connection_string);
                            //     string username = Utils.getUsername();
                            //   string StringQuery = "Delete from tbl_list_Order where tbl_list_Order.Document = @Ordernumber";
                            conn.Open();

                            string StringQuery3 = @"INSERT INTO tbl_shipment_temp(  Createby,   Product_code, Quantity , Product_Name , Unit ,OrderNumber  ) 
                                                                  VALUES (  @Createby,   @Product_code, @Quantity , @Product_Name , @Unit, @OrderNumber ) ";
                            OleDbCommand comm3 = new OleDbCommand(StringQuery3, conn);



                            comm3.Parameters.AddWithValue("@Createby", username);
                            comm3.Parameters.AddWithValue("@Product_code", dr1["Material"].ToString());
                            comm3.Parameters.AddWithValue("@Quantity", int.Parse(dr1["Order_qty"].ToString()));
                            comm3.Parameters.AddWithValue("@Product_Name", dr1["Description"].ToString());
                            comm3.Parameters.AddWithValue("@Unit", Model.Product.productUnit(dr1["Material"].ToString()));
                            comm3.Parameters.AddWithValue("@OrderNumber", orderNumber);
                            //comm3.Parameters.AddWithValue("@CreateShipment", true);


                            try
                            {
                                int temp2 = comm3.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                //  throw;
                            }

                            conn.Close();

                            #endregion  insert to shipment temp vói creating shipment = true

                        }

                    }





                } //forrchec
            }

            #endregion  insrt to temp


            #region   // sellect ra va update vao bang update status shipment = true
            // blank data trước
            DataTable dt5 = new DataTable();

            dt5.Columns.Add(new DataColumn("Product_code", typeof(string)));
            dt5.Columns.Add(new DataColumn("Quantity", typeof(int)));
            dt5.Columns.Add(new DataColumn("Product_Name", typeof(string)));
            dt5.Columns.Add(new DataColumn("Unit", typeof(string)));

            dataGRProductshipment.DataSource = dt5;
            this.dtsumshipment = dt5;

            // blank data trước
            conn.Open();

            ///???????????????????????
            // ll
            //   string StringQuery = @"Select First(tbl_list_Order.ID) as ID,   tbl_list_Order.Document ,  First( tbl_list_Order.Sold_to_pt) as Sold_to,  First( tbl_list_Order.Name_pt ) as Name, First(tbl_list_Order.totalAmount ) as TotalAmount from  tbl_list_Order where tbl_list_Order.AR_release = @AR_release and  tbl_list_Order.Document   like @Document and tbl_list_Order.Name_pt like @Name_pt and tbl_list_Order.Sold_to_pt like @Sold_to_pt GROUP BY    tbl_list_Order.Document ";

            //   OleDbCommand comm = new OleDbCommand(StringQuery, conn);
            string StringQuery4 = @"Select     
                                          Product_code,  
                                        sum(   tbl_shipment_temp.Quantity) as Quantity,  
                                         first(   tbl_shipment_temp.Product_Name) as Product_Name,  
                                           first(  tbl_shipment_temp.Unit)  as  Unit
 
                                           from  tbl_shipment_temp where 
                                                   tbl_shipment_temp.Createby = @Createby
                                                    Group by 

                                                        tbl_shipment_temp.Product_code

                                                    ";

            OleDbCommand comm4 = new OleDbCommand(StringQuery4, conn);
            //ADD PARAMS
            comm4.Parameters.AddWithValue("@Createby", username);


            DataSet ds = new DataSet();
            // 
            OleDbDataAdapter adapter =
             new OleDbDataAdapter(comm4);
            adapter.Fill(ds);
            conn.Close();
            DataTable dt1 = ds.Tables[0];
            if (dt1.Rows.Count > 0)
            {
                int total = 0;
                foreach (DataRow dr1 in dt1.Rows)
                {
                    //dt2.Columns.Add(new DataColumn("Product_code", typeof(string)));
                    //dt2.Columns.Add(new DataColumn("Quantity", typeof(int)));
                    //dt2.Columns.Add(new DataColumn("Product_Name", typeof(string)));
                    //dt2.Columns.Add(new DataColumn("Unit", typeof(string)));

                    DataRow dr2 = dtsumshipment.Rows.Add();
                    dr2["Product_code"] = dr1["Product_code"].ToString();
                    dr2["Quantity"] = dr1["Quantity"].ToString();
                    dr2["Product_Name"] = dr1["Product_Name"].ToString();
                    dr2["Unit"] = dr1["Unit"].ToString();

                    total = total + int.Parse(dr1["Quantity"].ToString());

                }
                DataRow dr6 = dtsumshipment.Rows.Add();
                dr6["Product_code"] = "---------- TOTAL ";
                dr6["Quantity"] = total;
                dr6["Product_Name"] = "-------------";
                dr6["Unit"] = "----";
            }







            #endregion //  dataGRDetailshipment



        }
        public void loadNewviewShipment()
        {

            #region    // xóa tem shipment với o order và user name
            string username = Utils.getUsername();
            //  string st = "Delete from tbl_list_Order where tbl_list_Order.Document = @Ordernumber";
            string connection_string = Utils.getAccessConnectionstring();
            OleDbConnection conn = new OleDbConnection(connection_string);

            string StringQuery = @"Delete from tbl_shipment_temp where 
                                                 tbl_shipment_temp.Createby = @Createby
                                                                      ";
            conn.Open();
            OleDbCommand comm = new OleDbCommand(StringQuery, conn);

            comm.Parameters.AddWithValue("@Createby", username);

            int temp = comm.ExecuteNonQuery();
            conn.Close();

            #endregion    // xóa tem shipment với o order và user name


            #region load order to make shipment detail new

            #region new table


            DataTable dt = new DataTable();

            dt.Columns.Add(new DataColumn("Order", typeof(int)));
            dt.Columns.Add(new DataColumn("Cust_code", typeof(string)));
            dt.Columns.Add(new DataColumn("Cust_name", typeof(string)));

            dataGRDetailshipment.DataSource = dt;
            this.dtorderToshipment = dt;

            foreach (DataGridViewColumn dgvc in dataGRDetailshipment.Columns)
            {
                dgvc.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            DataTable dt2 = new DataTable();

            dt2.Columns.Add(new DataColumn("Product_code", typeof(string)));
            dt2.Columns.Add(new DataColumn("Quantity", typeof(int)));
            dt2.Columns.Add(new DataColumn("Product_Name", typeof(string)));
            dt2.Columns.Add(new DataColumn("Unit", typeof(string)));

            dataGRProductshipment.DataSource = dt2;
            this.dtsumshipment = dt2;
            foreach (DataGridViewColumn dgvc in dataGRProductshipment.Columns)
            {
                dgvc.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            #endregion new table

            ReloadordertoShipment("", "", "");
      
            #endregion



            WindowState = FormWindowState.Maximized;


        }

        public BCPShipmentCreate()
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

            loadNewviewShipment();


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
            if (lb_shipmentNo.Text == "0")
            {



                if (this.gripOrdertomakeload.Rows[this.gripOrdertomakeload.CurrentCell.RowIndex].Cells["Document"].Value != DBNull.Value)
                {
                    string myuser = Model.UsernameInfor.getUsername();
                    string keepingUser = Model.Orders.getUsermakeorderinShipmenttemp(int.Parse(this.gripOrdertomakeload.Rows[this.gripOrdertomakeload.CurrentCell.RowIndex].Cells["Document"].Value.ToString()));
                    if (keepingUser == myuser)
                    {
                        MessageBox.Show("Order added !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);


                    }

                    if (keepingUser != myuser && keepingUser != "")
                    {
                        DialogResult dialogResult = MessageBox.Show("Order kept by :" + keepingUser + ", please contact user " + keepingUser, "Thông báo", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            //  MessageBox.Show("Order added !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //DataRow dr1 = dtorderToshipment.Rows.Add();
                            //dr1["Order"] = this.gripOrdertomakeload.Rows[this.gripOrdertomakeload.CurrentCell.RowIndex].Cells["Document"].Value.ToString();
                            //dr1["Cust_code"] = this.gripOrdertomakeload.Rows[this.gripOrdertomakeload.CurrentCell.RowIndex].Cells["Sold_to_pt"].Value.ToString();
                            //dr1["Cust_name"] = this.gripOrdertomakeload.Rows[this.gripOrdertomakeload.CurrentCell.RowIndex].Cells["Name_pt"].Value.ToString();

                        }
                        else if (dialogResult == DialogResult.No)
                        {
                            //do something else
                        }

                    }

                    if (keepingUser == "")
                    {
                        DataRow dr1 = dtorderToshipment.Rows.Add();
                        dr1["Order"] = this.gripOrdertomakeload.Rows[this.gripOrdertomakeload.CurrentCell.RowIndex].Cells["Document"].Value.ToString();
                        dr1["Cust_code"] = this.gripOrdertomakeload.Rows[this.gripOrdertomakeload.CurrentCell.RowIndex].Cells["Sold_to_pt"].Value.ToString();
                        dr1["Cust_name"] = this.gripOrdertomakeload.Rows[this.gripOrdertomakeload.CurrentCell.RowIndex].Cells["Name_pt"].Value.ToString();


                    }


                }

                RecaculationProductsum();
            }
        }

        private void dataGridunrelease_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //DataRow dr1 = this.dtordertoUNrelese.Rows.Add();
            //dr1["Order"] = this.dataGridunrelease.Rows[this.dataGridunrelease.CurrentCell.RowIndex].Cells["Document"].Value.ToString();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (int.Parse(lb_shipmentNo.Text.ToString()) == 0)// tạo shipment
            {


                #region  update tbl order
                if (dtorderToshipment.Rows.Count > 0)
                {
                    string ShipmenttempNo = Model.Shipment.getShipmentnumbertemp();
                    lb_shipmentNo.Text = ShipmenttempNo;

                    foreach (DataRow dr in this.dtorderToshipment.Rows)
                    {

                        string connection_string = Utils.getAccessConnectionstring();
                        OleDbConnection conn = new OleDbConnection(connection_string);
                        string username = Utils.getUsername();
                        //   string StringQuery = "Delete from tbl_list_Order where tbl_list_Order.Document = @Ordernumber";
                        conn.Open();


                        string StringQuery = @"UPDATE tbl_list_Order 
                                           SET
                                            tbl_list_Order.Shipment = @Shipment,
                                            tbl_list_Order.ShipmentcreateBy = @ShipmentcreateBy
                                            WHERE
                                            tbl_list_Order.Document = @Document
                                                                    ";
                        OleDbCommand comm = new OleDbCommand(StringQuery, conn);

                        comm.Parameters.AddWithValue("@Shipment", ShipmenttempNo);
                        comm.Parameters.AddWithValue("@ShipmentcreateBy", username);
                        comm.Parameters.AddWithValue("@Document", dr["Order"].ToString());


                        try
                        {
                            int temp = comm.ExecuteNonQuery();


                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                            //  throw;
                        }

                        conn.Close();
                    }
                    #endregion

                    #region  inser tbl shipment

                    #endregion

                    MessageBox.Show("Shipment : " + ShipmenttempNo + "  Create successfully !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }

            }





            ReloadordertoShipment("", "", "");



        }


        private void tab_Release_Click(object sender, EventArgs e)
        {

        }

        private void cb_shipingpoint_SelectedValueChanged(object sender, EventArgs e)
        {
            //  tabControl1.Enabled = true;
            loadNewviewShipment();

        }

        private void cb_shipingpoint_SelectedIndexChanged(object sender, EventArgs e)
        {
            //  tabControl1.Enabled = true;




        }

        private void txtcodefind_TextChanged(object sender, EventArgs e)
        {
            ReloadordertoShipment(txtcustcodefind.Text, txtnamefind.Text, txtcodefind.Text);
        }

        private void txtcustcodefind_TextChanged(object sender, EventArgs e)
        {
            ReloadordertoShipment(txtcustcodefind.Text, txtnamefind.Text, txtcodefind.Text);
        }

        private void txtnamefind_TextChanged(object sender, EventArgs e)
        {
            ReloadordertoShipment(txtcustcodefind.Text, txtnamefind.Text, txtcodefind.Text);
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
            RecaculationProductsum();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void tbnewshipment_Click(object sender, EventArgs e)
        {
            lb_shipmentNo.Text = "0";
            loadNewviewShipment();

        }

        private void btprintPallet_Click(object sender, EventArgs e)
        {

            View.BCPvalueinput input = new BCPvalueinput("Input Shiment", lb_shipmentNo.Text);
            input.ShowDialog();
            string ValueText = input.valuetext;
            bool kq = input.kq;

            if (kq && Utils.IsValidnumber(ValueText) && ValueText != "0")
            {
                //select 
                #region //    DataTable dataset1 = ut.ToDataTable(dc, rs1); head shipment ticket
                string connection_string = Utils.getAccessConnectionstring();

                OleDbConnection conn = new OleDbConnection(connection_string);
                conn.Open();

                //First(tbl_list_Order.Document) AS Order,
                //   First(tbl_list_Order.Sold_to_pt)AS Cust_code,
                //First(tbl_list_Order.Name_pt) AS Cust_name

                string StringQuery = @"Select First( tbl_list_Order.Shipment) AS Shipment ,
                                First( tbl_list_Order.Sold_to_pt) AS Cust_code ,
                                    First( tbl_list_Order.Name_pt) AS Cust_name ,
                                        First( tbl_list_Order.Document) AS OrderNumber


from  tbl_list_Order where 
                                tbl_list_Order.Shipment = @Shipment 
                                    Group by 
                                    tbl_list_Order.Document
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
                // MessageBox.Show("Please check shipment number !" + dataset1.Rows.Count.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (dataset1.Rows.Count > 0)
                {

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

                    Reportsview rpt = new Reportsview(dataset1, dataset2, "Palletticket.rdlc", "", "", ValueText);
                    rpt.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Please check shipment number !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }




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


