using BCP.Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace BCP.View
{
    public partial class BCPViewdatatable : Form
    {

        public string fornname { get; set; }
        public string region { get; set; }
        public bool chon { get; set; }
        public DataTable tbl { get; set; }

        public BCPViewdatatable(DataTable tbl, string fornname)
        {
            InitializeComponent();

            label7.Text = fornname;
            this.fornname = fornname;
            this.tbl = tbl;
            //System.Data.DataTable dt = new System.Data.DataTable();
            //dt = tbl;

            this.dataGridView1.DataSource = tbl;
            this.lbcount.Text = tbl.Rows.Count.ToString();
            //   valuecode = "0";
            chon = false;



        }

        private void button2_Click(object sender, EventArgs e)
        {

            //if (dataGridView1.RowCount>0)
            //{




            //        //if (this.dataGridView1.CurrentCell.RowIndex >= 0)
            //        //{
            //        // valuecode = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["Customer"].Value.ToString();


            //        //region = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["Region"].Value.ToString();

            //        //chon = true;

            //        //this.Close();
            //        //}



            //}
            //else
            //{
            //    this.Close();
            //}
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bt_exporttoex_Click(object sender, EventArgs e)
        {

            Control_ac ctrex = new Control_ac();


            ctrex.exportdatagriddatatabletofile(this.tbl, this.fornname);

        }
    }
}
