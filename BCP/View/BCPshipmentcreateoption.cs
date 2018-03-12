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
    public partial class BCPshipmentcreateoption : Form
    {
        public string checkUsername { get; set; }
        public bool kq { get; set; }
        public string transportername { get; set; }
        public string truckno { get; set; }
        public string palletcode { get; set; }
        public string palletname { get; set; }
        public int palletQuantity { get; set; }
        public string shippingpoint { get; set; }
        public class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {


            if (cbTranpostername.SelectedIndex >= 0)
            {
                this.transportername = (cbTranpostername.SelectedItem as ComboboxItem).Value.ToString();
            }
            else
            {
                cbTranpostername.Focus();
                MessageBox.Show("Please sellect a Tranposter", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (cbPalletcode.SelectedIndex >= 0)
            {
                this.palletcode = (cbPalletcode.SelectedItem as ComboboxItem).Value.ToString();
                this.palletname = (cbPalletcode.SelectedItem as ComboboxItem).Text.ToString();
                this.truckno = cbTruckno.Text;
            }
            else
            {
                cbPalletcode.Focus();
                MessageBox.Show("Select a kind of Pallet", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Utils.IsValidnumber(cbPalletQuantity.Text.ToString()))
            {
                this.palletQuantity = int.Parse(cbPalletQuantity.Text.ToString());

            }
            else
            {
                cbPalletQuantity.Focus();
                MessageBox.Show("Please nhập số lượng pallet dùng cho shipment", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cbTruckno.Text.ToString()!="")
            {
                this.truckno = cbTruckno.Text.ToString();

            }
            else
            {
                cbTruckno.Focus();
                MessageBox.Show("Please nhập biển số xe", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            this.kq = true;
            this.Close();

            


        }


        public BCPshipmentcreateoption(string shippingpoint)
        {
            InitializeComponent();
            this.kq = false;
            string username = Utils.getUsername();

            this.shippingpoint = shippingpoint;


            #region  // load tranporter name
            string connection_string = Utils.getAccessConnectionstring();
            string userPlant = Model.UsernameInfor.getUserplant();
            OleDbConnection conn = new OleDbConnection(connection_string);


            conn.Open();

            string StringQuery = @"SELECT  tbl_Transpoterlist.TranposterName FROM tbl_Transpoterlist
                                    WHERE 
                                        tbl_Transpoterlist.Shipingpoint = @Shipingpoint
                                                                        ";


            OleDbCommand comm = new OleDbCommand(StringQuery, conn);


            comm.Parameters.AddWithValue("@Shipingpoint", shippingpoint);
          
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
                cb.Value = dr["TranposterName"].ToString();
                cb.Text = dr["TranposterName"].ToString();
                CombomCollection.Add(cb);


            }

            cbTranpostername.DataSource = CombomCollection;
            #endregion // load tranporter name


            #region  // load tranporter name
        //    string connection_string = Utils.getAccessConnectionstring();
          //  string userPlant = Model.UsernameInfor.getUserplant();
          //  OleDbConnection conn = new OleDbConnection(connection_string);


            conn.Open();

            string StringQuery2 = @"SELECT  tbl_list_product_Pallet.Pallet_code, tbl_list_product_Pallet.Pallet_Name FROM tbl_list_product_Pallet
                                   
                                                                        ";


            OleDbCommand comm2 = new OleDbCommand(StringQuery2, conn);


       //     comm2.Parameters.AddWithValue("@Shipingpoint", shippingpoint);

            //   created dataset
            DataSet ds2 = new DataSet();


            // create the adapter and fill the DataSet
            OleDbDataAdapter adapter2 =
             new OleDbDataAdapter(comm2);


            adapter2.Fill(ds2);

            // close the connection
            conn.Close();
            DataTable dt2 = ds2.Tables[0];

            List<ComboboxItem> CombomCollection2 = new List<ComboboxItem>();
            foreach (DataRow dr in dt2.Rows)
            {
                ComboboxItem cb = new ComboboxItem();
                //     ver = int.Parse(dr["ver"].ToString());
                cb.Value = dr["Pallet_code"].ToString();
                cb.Text =  dr["Pallet_Name"].ToString();
                CombomCollection2.Add(cb);


            }

            cbPalletcode.DataSource = CombomCollection2;
            #endregion // load tranporter name


        }
        
    }
}
