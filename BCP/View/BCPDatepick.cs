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
    public partial class BCPDatepick : Form
    {

        public DateTime valueDate { get; set; }

        public bool kq { get; set; }
        public BCPDatepick(string label)
        {
            InitializeComponent();
            fromdatePicker.Value = DateTime.Today;
            valueDate = fromdatePicker.Value;
            kq = false;
            this.Text = label;
        }
    
        private void button1_Click(object sender, EventArgs e)
        {


            valueDate = fromdatePicker.Value;


            //  if (accrualdate >= DateTime.Today)
            // {
            kq = true;
                this.Hide();
            //}


        }

        private void Datepick_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
          
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
