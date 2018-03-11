using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BCP.View
{
    public partial class BCPSeachaddcode : Form
    {
        //    public KAcontractlisting Fromviewable;
        ////    public DataGridView Dtgridview;

        //    public string tablename;

        //  public int icount { get; set; }
        public bool kq { get; set; }
        public string Seachcode { get; set; }
        public string SeachName { get; set; }
        public string Seachaddress { get; set; }
        public string salesRegion { get; set; }
        // Name salesRegion
        public string shippingpoint { get; set; }
        public string Custype { get; set; }



        public BCPSeachaddcode(string Seachcode, string shippingpoint, string Custype)
        {




            InitializeComponent();
            //this.Fromviewable = Fromviewable;
            this.Seachcode = Seachcode;
            this.shippingpoint = shippingpoint;
            this.Custype = Custype;
            this.kq = false;



        }



        private void Seachcode_Deactivate(object sender, EventArgs e)
        {
            //    this.Close();
        }


        public void sendingtext_KeyPress(object sender, KeyPressEventArgs e)
        {

            //if (e.KeyChar == (char)Keys.Enter)
            //{


            //    sendingcontract.Focus();

            //    if (tablename == "KASeachcontract")
            //    {
            //        Fromviewable.ReloadKASeachcontract(this.sendingcode.Text, this.sendingcontract.Text, this.sendingname.Text, this.txtvat.Text);
            //    }



            //}

        }

        private void sendingcontract_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == (char)Keys.Enter)
            //{


            //    sendingname.Focus();

            //    if (tablename == "KASeachcontract")
            //    {
            //        Fromviewable.ReloadKASeachcontract(this.sendingcode.Text, this.sendingcontract.Text, this.sendingname.Text, this.txtvat.Text);
            //    }



            //}
        }

        private void sendingname_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == (char)Keys.Enter)
            //{


            //    this.sendingcode.Focus();

            //    if (tablename == "KASeachcontract")
            //    {
            //        Fromviewable.ReloadKASeachcontract(this.sendingcode.Text, this.sendingcontract.Text, this.sendingname.Text, this.txtvat.Text);
            //    }



            //}
        }

        private void txtvat_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == (char)Keys.Enter)
            //{


            //    this.sendingcode.Focus();

            //    if (tablename == "KASeachcontract")
            //    {
            //        Fromviewable.ReloadKASeachcontract(this.sendingcode.Text, this.sendingcontract.Text, this.sendingname.Text, this.txtvat.Text);
            //    }



            //}
        }

        private void sendingcode_TextChanged(object sender, EventArgs e)
        {

            txtcode.Focus();

            this.Seachcode = txtcode.Text.ToString();

            //DateTime fromdate = input.fromdate;
            //DateTime todate = input.todate;
            //string geturname = input.checkUsername;
            //bool chon = input.kq;

            // select and view order

            string connection_string = Utils.getAccessConnectionstring();

            OleDbConnection conn = new OleDbConnection(connection_string);
            conn.Open();


            //   string StringQuery = @"Select * from  tbl_list_Order where tbl_list_Order.Custype = @Custype and tbl_list_Order.Plant = @Plant and tbl_list_Order.Code = @Code";
            //   CAST(totalBal as float)

            string StringQuery = @"Select * from  tbl_list_customer where tbl_list_customer.Custype = @Custype and tbl_list_customer.Plant = @Plant and  tbl_list_customer.Customer_Code like @Customer_Code";//, @Customer_Code )"; //'%test%'


            OleDbCommand comm = new OleDbCommand(StringQuery, conn);

            //ADD PARAMS


            comm.Parameters.AddWithValue("@Custype", this.Custype);
            comm.Parameters.AddWithValue("@Plant", this.shippingpoint);

            OleDbParameter parm = new OleDbParameter("@Customer_Code", OleDbType.VarChar);
            parm.Value = "%" + this.Seachcode + "%";
            comm.Parameters.Add(parm);
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
            DataTable dt = ds.Tables[0];

            dataGridView1.DataSource = dt;

        }

        private void KASeachaddcode_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtcode_KeyPress(object sender, KeyPressEventArgs e)
        {


        }

        private void txtname_KeyPress(object sender, KeyPressEventArgs e)
        {
           

        }

        private void button1_Click(object sender, EventArgs e)
        {






        }

        private void txtname_TextChanged(object sender, EventArgs e)
        {

            txtname.Focus();

            this.SeachName = txtname.Text.ToString();

            //DateTime fromdate = input.fromdate;
            //DateTime todate = input.todate;
            //string geturname = input.checkUsername;
            //bool chon = input.kq;

            // select and view order

            string connection_string = Utils.getAccessConnectionstring();

            OleDbConnection conn = new OleDbConnection(connection_string);
            conn.Open();


            //   string StringQuery = @"Select * from  tbl_list_Order where tbl_list_Order.Custype = @Custype and tbl_list_Order.Plant = @Plant and tbl_list_Order.Code = @Code";
            //   CAST(totalBal as float)

            string StringQuery = @"Select * from  tbl_list_customer where tbl_list_customer.Custype = @Custype and tbl_list_customer.Plant = @Plant and  tbl_list_customer.Name like @Customername";//, @Customer_Code )"; //'%test%'


            OleDbCommand comm = new OleDbCommand(StringQuery, conn);

            //ADD PARAMS


            comm.Parameters.AddWithValue("@Custype", this.Custype);
            comm.Parameters.AddWithValue("@Plant", this.shippingpoint);
            OleDbParameter parm = new OleDbParameter("@Customername", OleDbType.VarChar);
            parm.Value = "%" + this.SeachName + "%";
            comm.Parameters.Add(parm);

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
            DataTable dt = ds.Tables[0];

            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {



            //  string username = Utils.getUsername();
            //     Customer_Code
            try
            {
                this.Seachcode = (string)this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["Customer_Code"].Value;
                this.SeachName = (string)this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["Name"].Value;
                this.Seachaddress = (string)this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["Address"].Value;
                this.salesRegion = (string)this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["sales_region"].Value;

                this.kq = true;
            }
            catch (Exception)
            {

              //  throw;
            }

         
            //     double codetemp = (double)this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["Code"].Value;// (double)this.dataGridView1.Rows[0].Cells["Code"].Value;
            //      string codename = (string)this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["Name"].Value; //(string)this.dataGridView1.Rows[0].Cells["Name"].Value;

            this.Close();



        }
    }
}
