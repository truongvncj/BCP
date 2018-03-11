using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static BCP.View.BCPArrelease;

namespace BCP.View
{
    public partial class BCPCuscodeandateselect : Form
    {
        public bool kq { get; set; }
        public string CustomerCode { get; set; }
        public string sales_region { get; set; }
        public DateTime Valuedate { get; set; }



        public BCPCuscodeandateselect()
        {
            InitializeComponent();
            this.kq = false;
            this.CustomerCode = "";

            // loda data to customer code

            List<BCPArrelease.ComboboxItem> collectionPlan = new List<ComboboxItem>();
            string connection_string = Utils.getAccessConnectionstring();
            OleDbConnection conn = new OleDbConnection(connection_string);

            // create an open the connection     
            DataSet ds = new DataSet();


            // create the adapter and fill the DataSet
            OleDbDataAdapter adapter =
             new OleDbDataAdapter("SELECT tbl_list_customer.Customer_Code, tbl_list_customer.Name, tbl_list_customer.sales_region   FROM tbl_list_customer where  tbl_list_customer.Custype ='V001' ", conn);
            adapter.Fill(ds);
            //
            // close the connection
            conn.Close();
            DataTable dt = ds.Tables[0];

            List<ComboboxItem> CombomCollection = new List<ComboboxItem>();
            foreach (DataRow dr in dt.Rows)
            {
                ComboboxItem cb = new ComboboxItem();
                //     ver = int.Parse(dr["ver"].ToString());
                cb.Value = dr["Customer_Code"].ToString().Trim() + ";" + dr["sales_region"].ToString().Trim();
                cb.Text = dr["Customer_Code"].ToString() +" "+ dr["sales_region"].ToString().Trim() + ": " + dr["Name"].ToString();
                CombomCollection.Add(cb);


            }

            cb_customercode.DataSource = CombomCollection;



            //

        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.kq = true;

            this.Valuedate = dateTimePicker1.Value;

            string[] parts = (cb_customercode.SelectedItem as ComboboxItem).Value.ToString().Split(';');

            this.CustomerCode = parts[0].Trim();
            this.sales_region = parts[1].Trim();





            this.Close();


        }
    }
}
