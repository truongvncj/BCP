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


    public partial class BCPArrelease : Form
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
        public DataTable dtordertorelese { get; set; }
        public DataTable dtordertoUNrelese { get; set; }
        public void reloadARreleasesechac(string forder, string fname, string fcode)
        {
            string connection_string = Utils.getAccessConnectionstring();

            OleDbConnection conn = new OleDbConnection(connection_string);
            conn.Open();

            ///???????????????????????

            string StringQuery = @"Select First(tbl_list_Order.ID) as ID,   tbl_list_Order.Document ,  First( tbl_list_Order.Sold_to_pt) as Sold_to,  First( tbl_list_Order.Name_pt ) as Name, sum(tbl_list_Order.totalAmount ) as TotalAmount from  tbl_list_Order where tbl_list_Order.AR_release = @AR_release and  tbl_list_Order.Document   like @Document and tbl_list_Order.Name_pt like @Name_pt and tbl_list_Order.Sold_to_pt like @Sold_to_pt GROUP BY    tbl_list_Order.Document ";

            OleDbCommand comm = new OleDbCommand(StringQuery, conn);


            //ADD PARAMS
            //         (, product_group, percent_amount, fromdate, todate, customerid, keyaccount, saledistrict, programId, Username, sales_region, amount)
            comm.Parameters.AddWithValue("@AR_release", false);
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



            dataGridOrderUnrelease.DataSource = dt1;



        }


        public void reloadARUNreleasesechac(string forder, string fname, string fcode)
        {
            string connection_string = Utils.getAccessConnectionstring();

            OleDbConnection conn = new OleDbConnection(connection_string);
            conn.Open();


            string StringQuery = @"Select First(tbl_list_Order.ID) as ID,   tbl_list_Order.Document ,  First( tbl_list_Order.Sold_to_pt) as Sold_to,  First( tbl_list_Order.Name_pt ) as Name, sum(tbl_list_Order.totalAmount ) as TotalAmount from  tbl_list_Order where tbl_list_Order.AR_release = @AR_release and  tbl_list_Order.Document   like @Document and tbl_list_Order.Name_pt like @Name_pt and tbl_list_Order.Sold_to_pt like @Sold_to_pt GROUP BY    tbl_list_Order.Document ";

            OleDbCommand comm = new OleDbCommand(StringQuery, conn);


            //ADD PARAMS
            //         (, product_group, percent_amount, fromdate, todate, customerid, keyaccount, saledistrict, programId, Username, sales_region, amount)
            comm.Parameters.AddWithValue("@AR_release", true);
            comm.Parameters.AddWithValue("@Document", "%" + forder + "%");// Name_pt
            comm.Parameters.AddWithValue("@Name_pt", "%" + fname + "%");// Name_pt
            comm.Parameters.AddWithValue("@Sold_to_pt", "%" + fcode + "%");// Name_pt

            DataSet ds = new DataSet(); //Sold_to_pt

            // create the adapter and fill the DataSet

            // 
            OleDbDataAdapter adapter =
             new OleDbDataAdapter(comm);
            adapter.Fill(ds);
            conn.Close();
            DataTable dt1 = ds.Tables[0];
            // close the connection



            dataGridunrelease.DataSource = dt1;



        }

        public void loadARreleasenew()
        {

            #region load loadARrelease detail new
            DataTable dt = new DataTable();

            dt.Columns.Add(new DataColumn("Order", typeof(int)));

            datagrlisttoRelease.DataSource = dt;
            this.dtordertorelese = dt;

            //===================
            string connection_string = Utils.getAccessConnectionstring();

            OleDbConnection conn = new OleDbConnection(connection_string);
            conn.Open();


            string StringQuery = @"Select First(tbl_list_Order.ID) as ID,   tbl_list_Order.Document ,  First( tbl_list_Order.Sold_to_pt) as Sold_to,  First( tbl_list_Order.Name_pt ) as Name, First(tbl_list_Order.totalAmount ) as TotalAmount  from  tbl_list_Order where tbl_list_Order.AR_release = @AR_release  GROUP BY    tbl_list_Order.Document ";

            OleDbCommand comm = new OleDbCommand(StringQuery, conn);



            //ADD PARAMS
            //         (, product_group, percent_amount, fromdate, todate, customerid, keyaccount, saledistrict, programId, Username, sales_region, amount)
            comm.Parameters.AddWithValue("@AR_release", false);

            //OleDbParameter parm = new OleDbParameter("@fromdate", OleDbType.Date);
            //parm.Value = fromdate;
            //comm.Parameters.Add(parm);

            //OleDbParameter parm2 = new OleDbParameter("@todate", OleDbType.Date);
            //parm2.Value = todate;
            //comm.Parameters.Add(parm2);



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
            DataTable dt1 = ds.Tables[0];
            // close the connection



            dataGridOrderUnrelease.DataSource = dt1;

            #endregion

            #region load loadARUnrelease detail new
            DataTable dt3 = new DataTable();

            dt3.Columns.Add(new DataColumn("Order", typeof(int)));
            //dt.Columns.Add(new DataColumn("Amount", typeof(double)));
            //dt.Columns.Add(new DataColumn("Product_Name", typeof(string)));
            //dt.Columns.Add(new DataColumn("FreeCase", typeof(Boolean)));

            datagrlisttoUNRelease.DataSource = dt3;
            this.dtordertoUNrelese = dt3;

            //=================


            //===================
            //  string connection_string = Utils.getAccessConnectionstring();

            // OleDbConnection conn = new OleDbConnection(connection_string);
            conn.Open();


            string StringQuery2 = @"Select First(tbl_list_Order.ID) as ID,   tbl_list_Order.Document ,  First( tbl_list_Order.Sold_to_pt) as Sold_to,  First( tbl_list_Order.Name_pt ) as Name, First(tbl_list_Order.totalAmount ) as TotalAmount  from  tbl_list_Order where tbl_list_Order.AR_release = @AR_release  GROUP BY    tbl_list_Order.Document ";


            OleDbCommand comm2 = new OleDbCommand(StringQuery2, conn);


            //ADD PARAMS
            //         (, product_group, percent_amount, fromdate, todate, customerid, keyaccount, saledistrict, programId, Username, sales_region, amount)
            comm2.Parameters.AddWithValue("@AR_release", true);

            //OleDbParameter parm = new OleDbParameter("@fromdate", OleDbType.Date);
            //parm.Value = fromdate;
            //comm.Parameters.Add(parm);

            //OleDbParameter parm2 = new OleDbParameter("@todate", OleDbType.Date);
            //parm2.Value = todate;
            //comm.Parameters.Add(parm2);



            //   OleDbDataAdapter1.SelectCommand.CommandText = "SELECT * FROM tbl_Temp WHERE username = @Username AND password = @Password";
            // string Query1 = "SELECT * FROM tbl_Temp WHERE username = '" + textBox1.Text + "' AND password = '" + textBox2.Text+"'";
            // create the DataSet
            DataSet ds2 = new DataSet();

            // create the adapter and fill the DataSet

            // 
            OleDbDataAdapter adapter2 =
             new OleDbDataAdapter(comm2);
            adapter2.Fill(ds2);
            conn.Close();
            DataTable dt4 = ds2.Tables[0];
            // close the connection



            dataGridunrelease.DataSource = dt4;
            #endregion 







        }

        public BCPArrelease()
        {
            InitializeComponent();

            loadARreleasenew();

            ////    btupdatecontract.Visible = false;
            //Model.Username used = new Model.Username();
            //string connection_string = Utils.getConnectionstr();
            //LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            //string username = Utils.getUsername();




            //AutoCompleteStringCollection contractdata = new AutoCompleteStringCollection();

            //var contractautolist = (from tbl_autodataContract in dc.tbl_autodataContracts
            //                        where tbl_autodataContract.Username == username
            //                        orderby tbl_autodataContract.id descending
            //                        select tbl_autodataContract.ContractNo).Take(10);

            //if (contractautolist.Count() > 0)
            //{
            //    foreach (var item in contractautolist)
            //    {
            //        if (item != null)
            //        {
            //            contractdata.Add(item);
            //        }

            //    }


            //    var deletelist = from tbl_autodataContract in dc.tbl_autodataContracts
            //                     where !contractautolist.Contains(tbl_autodataContract.ContractNo)
            //                     select tbl_autodataContract;

            //    dc.tbl_autodataContracts.DeleteAllOnSubmit(deletelist);
            //    dc.SubmitChanges();

            //}


            //this.contractdata = contractdata;
            //tb_contractno.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //tb_contractno.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //tb_contractno.AutoCompleteCustomSource = contractdata;

            ////            tb_contractno.AutoCompleteSource = contractdata;



            // 



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
            reloadARUNreleasesechac(txcodeunrelease.Text.ToString(), txtnameunrelease.Text.ToString(), txtcodef.Text.ToString());
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            reloadARreleasesechac(txtcodefind.Text.ToString(), txtnamefind.Text.ToString(), txtcustcode.Text.ToString());
        }

        private void txtnamefind_TextChanged(object sender, EventArgs e)
        {
            reloadARreleasesechac(txtcodefind.Text.ToString(), txtnamefind.Text.ToString(), txtcustcode.Text.ToString());
        }

        private void txtnameunrelease_TextChanged(object sender, EventArgs e)
        {
            reloadARUNreleasesechac(txcodeunrelease.Text.ToString(), txtnameunrelease.Text.ToString(), txtcodef.Text.ToString());
        }

        private void txtcustcode_TextChanged(object sender, EventArgs e)
        {
            reloadARreleasesechac(txtcodefind.Text.ToString(), txtnamefind.Text.ToString(), txtcustcode.Text.ToString());

        }

        private void txtcodef_TextChanged(object sender, EventArgs e)
        {
            reloadARUNreleasesechac(txcodeunrelease.Text.ToString(), txtnameunrelease.Text.ToString(), txtcodef.Text.ToString());

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
            DataRow dr1 = dtordertorelese.Rows.Add();
            try
            {
                dr1["Order"] = this.dataGridOrderUnrelease.Rows[this.dataGridOrderUnrelease.CurrentCell.RowIndex].Cells["Document"].Value.ToString();

            }
            catch (Exception)
            {

                //throw;
            }

        }

        private void dataGridunrelease_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataRow dr1 = this.dtordertoUNrelese.Rows.Add();

            try
            {
                dr1["Order"] = this.dataGridunrelease.Rows[this.dataGridunrelease.CurrentCell.RowIndex].Cells["Document"].Value.ToString();

            }
            catch (Exception)
            {

                // throw;
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {

            foreach (DataRow dr in this.dtordertorelese.Rows)
            {

                string connection_string = Utils.getAccessConnectionstring();
                OleDbConnection conn = new OleDbConnection(connection_string);
                string username = Utils.getUsername();
                //   string StringQuery = "Delete from tbl_list_Order where tbl_list_Order.Document = @Ordernumber";
                conn.Open();


                string StringQuery = @"UPDATE tbl_list_Order 
                                       SET
                                        tbl_list_Order.AR_release = @AR_release,
                                        tbl_list_Order.Release_by = @Release_by
                                        WHERE
                                        tbl_list_Order.Document = @Document
                                                                ";
                OleDbCommand comm = new OleDbCommand(StringQuery, conn);

                comm.Parameters.AddWithValue("@AR_release", true);
                comm.Parameters.AddWithValue("@Release_by", username);
                comm.Parameters.AddWithValue("@Document", dr["Order"].ToString());


                try
                {
                    int temp = comm.ExecuteNonQuery();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    //  throw;
                }
                //    dtordertorelese.Rows.Remove(dr);
                conn.Close();
            }







            MessageBox.Show("Done Successfully !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.txtcodefind.Text = "";
            this.txtcustcode.Text = "";
            this.txtnamefind.Text = "";


            loadARreleasenew();


        }

        private void btUnrelease_Click(object sender, EventArgs e)
        {
            foreach (DataRow dr in this.dtordertoUNrelese.Rows)
            {
                string shipment = Model.Shipment.getShipmentofOrders(dr["Order"].ToString());
                if (shipment != "") // // nếu đã có số shipment roi thì không ủneleduoc
                {
                    MessageBox.Show("Order :" + dr["Order"].ToString() + " đã tạo shipment không Unrelease được ! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {

                    string connection_string = Utils.getAccessConnectionstring();
                    OleDbConnection conn = new OleDbConnection(connection_string);
                    string username = Utils.getUsername();
                    //   string StringQuery = "Delete from tbl_list_Order where tbl_list_Order.Document = @Ordernumber";
                    conn.Open();


                    string StringQuery = @"UPDATE tbl_list_Order 
                                       SET
                                        tbl_list_Order.AR_release = @AR_release,
                                        tbl_list_Order.Release_by = @Release_by
                                        WHERE
                                        tbl_list_Order.Document = @Document
                                                                ";
                    OleDbCommand comm = new OleDbCommand(StringQuery, conn);

                    comm.Parameters.AddWithValue("@AR_release", false);
                    comm.Parameters.AddWithValue("@Release_by", username);
                    comm.Parameters.AddWithValue("@Document", dr["Order"].ToString());
                    //comm.Parameters.AddWithValue("@sales_region", lbsalesRegion.Text.ToString());
                    //comm.Parameters.AddWithValue("@Purchase_order_number", Ponumber.Text.ToString().Trim() + " ;" + lb_address.Text.ToString().Trim());


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


                    try
                    {
                        int temp = comm.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        //  throw;
                    }
                    //     dtordertoUNrelese.Rows.Remove(dr);
                    conn.Close();
                }





            }

            MessageBox.Show("Done Successfully !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.txcodeunrelease.Text = "";
            this.txtcodef.Text = "";
            this.txtnameunrelease.Text = "";


            loadARreleasenew();



        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadARreleasenew();

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


