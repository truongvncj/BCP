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

        public string idcolumName { get; set; }
        public string tblname { get; set; }




        public BCPViewdatatable(DataTable tbl, string fornname, string idcolumName, string tblname)
        {
            InitializeComponent();

            label7.Text = fornname;
            this.fornname = fornname;
            this.tbl = tbl;
            this.idcolumName = idcolumName;
            this.tblname = tblname;
            //dt = tbl;

            this.dataGridView1.DataSource = tbl;
            this.lbcount.Text = tbl.Rows.Count.ToString();
            //   valuecode = "0";
            chon = false;
            btupdate.Visible = false;

            if (fornname == "list pallet" || fornname == "Transpoter list" || fornname == "LIST SHIPPING POINT" || fornname == "DANH SÁCH KHÁCH HÀNG" || fornname == "USERNAME AND RIGHT SET UP"|| fornname == "LIST SALES REGION" || fornname == "DANH SÁCH SẢN PHẨM")
            {
                btupdate.Visible = true;
                dataGridView1.ReadOnly = false;
                dataGridView1.AllowUserToAddRows = true;


            }
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

        private void btupdate_Click(object sender, EventArgs e)
        {
            string tblnamesub = this.tblname;
            string IDsub = this.idcolumName; //lấy cot ID là cột id mốc

            #region // update datagridview to database    source1.EndEdit();



            foreach (DataGridViewRow r in dataGridView1.Rows)
            {

                if (r.Cells[IDsub].Value != null)
                {


                    var indexvalue = int.Parse(r.Cells[IDsub].Value.ToString());
                    //      var kq = source1.Find(IDsub, indexvalue);
                    #region     if (indexvalue != 0) //neewu co tron view khong co trong dataa == add vao dat ta

                    if (indexvalue != 0) //neewu co tron view khong co trong dataa == add vao dat ta
                    {
                        //var bk = new tblEDLP();

                        string stringfield = "";
                        //    string stringvalue = "";

                        int idculum = this.dataGridView1.ColumnCount;

                        for (int idculumid = 0; idculumid < idculum; idculumid++)
                        {
                            var colheadertext = this.dataGridView1.Columns[idculumid].HeaderText;
                            var colname = this.dataGridView1.Columns[idculumid].HeaderText;

                            var valueid = r.Cells[colheadertext].Value;

                            if (valueid != null && colheadertext != IDsub)
                            {

                                var IDType = r.Cells[colheadertext].ValueType;

                                if (colheadertext.Contains("_"))
                                {
                                    colheadertext = colheadertext.Replace("_", " ");
                                    string temp = "[" + colheadertext + "]";
                                    colheadertext = temp;
                                }

                                //Boolean || IDType.ToString().Contains("Bool")

                                if (IDType.ToString().Contains("String"))
                                {

                                    valueid = "'" + valueid + "'";
                                }



                                if (IDType.ToString().Contains("Date"))
                                {

                                    valueid = "#" + valueid + "#";
                                }

                                if (stringfield != "")
                                {

                                    stringfield = tblnamesub + "." + colname + " = " + valueid + "," + stringfield;

                                }
                                else
                                {
                                    stringfield = tblnamesub + "." + colname + " = " + valueid;


                                }



                            }

                        } // for
                        string StrQuery = "update " + tblnamesub +
                                 " set " + stringfield +
                                 " where " + tblnamesub + ".id =" + indexvalue; // + dataGridView1.Rows[r.Index].Cells["ColumnName"].Value + ", " + dataGridView1.Rows[r.Index].Cells["ColumnName"].Value + ");";



                        bool kqq1 = Utils.doQuerywithAcessdata(StrQuery);
                        //  db.ExecuteCommand(StrQuery);
                        // db.SubmitChanges();

                        if (kqq1 == false)
                        {
                            MessageBox.Show(StrQuery);
                            return;
                        }


                    }
                    #endregion
                }


            }



            #endregion//update datagridview to database



            #region        // insert cac dong  khong co trong gridview khong co cos tron data


            foreach (DataGridViewRow r in dataGridView1.Rows)
            {

                if (r.Cells[IDsub].Value != null)
                {


                    var indexvalue = int.Parse(r.Cells[IDsub].Value.ToString());
                    //      var kq = source1.Find(IDsub, indexvalue);

                    if (indexvalue == 0) //neewu co tron view khong co trong dataa == add vao dat ta
                    {
                        //var bk = new tblEDLP();

                        string stringfield = "";
                        string stringvalue = "";

                        int idculum = this.dataGridView1.ColumnCount;

                        for (int idculumid = 0; idculumid < idculum; idculumid++)
                        {
                            var colheadertext = this.dataGridView1.Columns[idculumid].HeaderText;
                            var colname = this.dataGridView1.Columns[idculumid].Name;

                            var valueid = r.Cells[colheadertext].Value;

                            if (valueid != null && colheadertext != IDsub)
                            {

                                var IDType = r.Cells[colheadertext].ValueType;

                                if (colheadertext.Contains("_"))
                                {
                                    colheadertext = colheadertext.Replace("_", " ");
                                    string temp = "[" + colheadertext + "]";
                                    colheadertext = temp;
                                }

                                // || IDType.ToString().Contains("Bool")
                                if (IDType.ToString().Contains("String"))
                                {

                                    valueid = "'" + valueid + "'";
                                }



                                if (IDType.ToString().Contains("Date"))
                                {

                                    valueid = "'" + valueid + "'";
                                }

                                if (stringvalue != "")
                                {

                                    stringvalue = stringvalue + "," + valueid;
                                    stringfield = stringfield + "," + colheadertext;

                                }
                                else
                                {
                                    stringvalue = stringvalue + valueid;

                                    stringfield = stringfield + colname;

                                }



                            }




                        }



                        string StrQuery = "INSERT INTO " + tblnamesub + " ( " + stringfield + " ) VALUES (" + stringvalue + ")"; // + dataGridView1.Rows[r.Index].Cells["ColumnName"].Value + ", " + dataGridView1.Rows[r.Index].Cells["ColumnName"].Value + ");";

                        bool kqq2 = Utils.doQuerywithAcessdata(StrQuery);
                        //  db.ExecuteCommand(StrQuery);
                        // db.SubmitChanges();

                        if (kqq2 == false)
                        {
                            MessageBox.Show(StrQuery);
                            return;
                        }




                    }





                }



            }
            #endregion foreach

            MessageBox.Show("Data update done !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);







        }
    }
}
