using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BCP.View
{
    public partial class BCPorderviewotiom : Form
    {
        public string checkUsername { get; set; }
        public DateTime fromdate { get; set; }
        public DateTime todate { get; set; }
        public bool kq { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {

            this.kq = true;
            checkUsername = cb_createby.Text;
            fromdate = date_fromdate.Value;
            todate = date_toDate.Value;
            this.Close();
            //      public string checkUsername { get; set; }
            //public DateTime fromdate { get; set; }
            //public DateTime todate { get; set; }

        }


        public BCPorderviewotiom()
        {
            InitializeComponent();
            this.kq = false;
            string username = Utils.getUsername();

            this.checkUsername = username;
            cb_createby.Text = username;

            this.date_fromdate.Value = DateTime.Today;

            this.date_toDate.Value = DateTime.Today;




        }



    }
}
