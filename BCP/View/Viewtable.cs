﻿using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BCP.Control;
using BCP.shared;
using System.Globalization;
using System.Threading;
using BCP.Model;
using System.Data.SqlClient;

namespace BCP.View
{

    //   public static DataGridView dataGridView2;// = new DataGridView();

    public partial class Viewtable : Form
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

        public int viewcode;
        public IQueryable rs;
        LinqtoSQLDataContext db;
        public DataGridView Dtgridview;


        public static string connection_string = Utils.getConnectionstr();

        LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
      //  dc.CommandTimeout = 0;

        //   public List<ComboboxItem> dataCollectionaccount;

        //  public List<ComboboxItem> dataCollectiongroup;//{ get; private set; }
        //1. Định nghĩa 1 delegate


        class datatoExport
        {
            //public DataGridView dataGrid1 { get; set; }
            public System.Data.DataTable datatble { get; set; } // = new System.Data.DataTable();
        }


        public void sumtitleGrid(object inptgridobjiec)
        {

            datatoExport dat = (datatoExport)inptgridobjiec;
            System.Data.DataTable datatble = dat.datatble;
            //    DataGridView dataGrid1 = new DataGridView();
            //   dataGrid1.DataSource = datatble;
            //      double k = dataGrid1.Rows.Count;
            int k = datatble.Rows.Count;
            double Billed_Qty = 0;
            double GSR = 0;
            double UC = 0;
            double PC = 0;
            double NSR = 0;

            try
            {

                for (int i = 0; i < k; i++)
                {
                    #region forr

                    //  datatble.Columns["Billed_Qty"].v


                    if (datatble.Rows[i]["PCs"] != null && Utils.IsValidnumber(datatble.Rows[i]["PCs"].ToString()))
                    {

                        Billed_Qty += double.Parse(datatble.Rows[i]["PCs"].ToString());
                    }

                    if (datatble.Rows[i]["NSR"] != null && Utils.IsValidnumber(datatble.Rows[i]["NSR"].ToString()))
                    {

                        NSR += double.Parse(datatble.Rows[i]["NSR"].ToString());
                    }
                    if (datatble.Rows[i]["UC"] != null && Utils.IsValidnumber(datatble.Rows[i]["UC"].ToString()))
                    {

                        UC += double.Parse(datatble.Rows[i]["UC"].ToString());
                    }
                    if (datatble.Rows[i]["EC"] != null && Utils.IsValidnumber(datatble.Rows[i]["EC"].ToString()))
                    {

                        PC += double.Parse(datatble.Rows[i]["EC"].ToString());
                    }
                    if (datatble.Rows[i]["GSR"] != null && Utils.IsValidnumber(datatble.Rows[i]["GSR"].ToString()))
                    {

                        GSR += double.Parse(datatble.Rows[i]["GSR"].ToString());
                    }

                    //======



                    #endregion forr
                }



                //     Billed_Qty = 100;
                this.lb_bilingqtt.Invoke(new UpdateTextCallback(this.UpdateText),
                                             new object[] { Billed_Qty.ToString(), NSR.ToString(), UC.ToString(), PC.ToString(), GSR.ToString() });


                this.lb_netvalue.Invoke(new UpdateTextCallback(this.UpdateText),
                                            new object[] { Billed_Qty.ToString(), NSR.ToString(), UC.ToString(), PC.ToString(), GSR.ToString() });



                this.lb_countvalue.Invoke(new UpdateTextCallback(this.UpdateText),
                                            new object[] { Billed_Qty.ToString(), NSR.ToString(), UC.ToString(), PC.ToString(), GSR.ToString() });


                this.lb_pc.Invoke(new UpdateTextCallback(this.UpdateText),
                                            new object[] { Billed_Qty.ToString(), NSR.ToString(), UC.ToString(), PC.ToString(), GSR.ToString() });


                this.lb_uc.Invoke(new UpdateTextCallback(this.UpdateText),
                                                 new object[] { Billed_Qty.ToString(), NSR.ToString(), UC.ToString(), PC.ToString(), GSR.ToString() });

                //   MyGetData( tongamount,  tongdeposit,  fullGoodamount,  sumempty);
            }
            catch (Exception)
            {
                Thread.CurrentThread.Abort();
                //       MessageBox.Show(ex.ToString());

                // MessageBox.Show(hh44.ToString());


            }




        }



        private void UpdateText(string Billed_Qty, string NSR, string UC, string PC, string GSR)
        {


            this.lb_bilingqtt.Text = double.Parse(Billed_Qty).ToString("#,#", CultureInfo.InvariantCulture);
            this.lb_netvalue.Text = double.Parse(GSR).ToString("#,#", CultureInfo.InvariantCulture);
            this.lb_countvalue.Text = double.Parse(NSR).ToString("#,#", CultureInfo.InvariantCulture);
            this.lb_pc.Text = double.Parse(PC).ToString("#,#", CultureInfo.InvariantCulture);
            this.lb_uc.Text = double.Parse(UC).ToString("#,#", CultureInfo.InvariantCulture);

            this.Status.Text = "DONE";
            //  this.dataGridView1.Refresh();
        }

        public delegate void UpdateTextCallback(string Billed_Qty, string NSR, string UC, string PC, string GSR);
        //    In your thread, you can call the Invoke method on m_TextBox, passing the delegate to call, as well as the parameters.



        public void Reloadcustomer(String inutstring)

        {
            string connection_string = Utils.getConnectionstr();
            //      UpdateDatagridview
            System.Data.DataTable dt = new System.Data.DataTable();
            //   LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            var rsthisperiod = from tbl_KaCustomer in dc.tbl_KaCustomers
                               where ((int)tbl_KaCustomer.Customer).ToString().Contains(inutstring)
                               select tbl_KaCustomer;
            dc.CommandTimeout = 0;
            Utils ut = new Utils();
            dt = ut.ToDataTable(dc, rsthisperiod);

            this.dataGridView1.DataSource = dt;


        }


        public void Reloadsales(String inutstring)

        {
            string connection_string = Utils.getConnectionstr();
            //      UpdateDatagridview
            System.Data.DataTable dt = new System.Data.DataTable();
            //        LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            dc.CommandTimeout = 0;

            try
            {
                //    string Priod = this.dataGridView1.CurrentRow.Cells["Priod"].Value.ToString();
                var rs = from tbl_kasale in dc.tbl_kasales
                         where /*tbl_kasale.Priod == Priod &&*/ ((int)tbl_kasale.Sold_to).ToString().Contains(inutstring)
                         group tbl_kasale by new
                         {
                             tbl_kasale.Sold_to,
                             tbl_kasale.Sales_Org

                         }
                       into g
                         select new
                         {


                             Priod = g.Select(gg => gg.Priod).FirstOrDefault(),
                             Region = g.Key.Sales_Org,
                             Sold_to = g.Key.Sold_to,
                             Name = g.Select(gg => gg.Cust_Name).FirstOrDefault(),
                             PCs = g.Sum(gg => gg.EC).GetValueOrDefault(0),
                             EC = Math.Ceiling(g.Sum(gg => gg.PC).GetValueOrDefault(0)),
                             UC = Math.Ceiling(g.Sum(gg => gg.UC).GetValueOrDefault(0)),
                             Litter = Math.Ceiling(g.Sum(gg => gg.Litter).GetValueOrDefault(0)),
                             NSR = Math.Ceiling(g.Sum(gg => gg.NSR).GetValueOrDefault(0)),
                             GSR = Math.Ceiling(g.Sum(gg => gg.GSR).GetValueOrDefault(0)),



                         };
                //this.dataGridView1.DataSource = rs;
                //this.Dtgridview = dataGridView1;

                //   this.db = db;
                //    this.viewcode = viewcode;
                this.rs = rs;
                //    Viewtable viewtbl = new Viewtable(rs, dc, "SALES DATA PRIOD: " + Priod, 2);// view code 1 la can viet them lenh

                //  viewtbl.Show();

                //--
                Utils ut = new Utils();
                dt = ut.ToDataTable(dc, rs);

                this.dataGridView1.DataSource = dt;

                this.Status.Text = "Caculating ...";

                //   System.Data.DataTable dt = new System.Data.DataTable();
                //     Utils ut = new Utils();
                //     dt = ut.ToDataTable(db, rs);


                this.dataGridView1.Columns["PCs"].DefaultCellStyle.Format = "N0";
                this.dataGridView1.Columns["GSR"].DefaultCellStyle.Format = "N0";

                this.dataGridView1.Columns["Litter"].DefaultCellStyle.Format = "N0";
                this.dataGridView1.Columns["NSR"].DefaultCellStyle.Format = "N0";


                this.dataGridView1.Columns["EC"].DefaultCellStyle.Format = "N0";
                this.dataGridView1.Columns["UC"].DefaultCellStyle.Format = "N0";



                Thread tt1 = new Thread(sumtitleGrid);

                tt1.IsBackground = true;
                tt1.Start(new datatoExport() { datatble = dt });




            }
            catch (Exception)
            {

                return;
            }







        }
        void Control_KeyPress(object sender, KeyEventArgs e)
        {
            // if (viewcode == 2)// nuew la bàng salsetemp update

            if ((viewcode == 2) && e.KeyCode == Keys.F3)
            {





                FormCollection fc = System.Windows.Forms.Application.OpenForms;

                bool kq = false;
                foreach (Form frm in fc)
                {
                    if (frm.Text == "tblsales")


                    {
                        kq = true;
                        frm.Focus();

                    }
                }

                if (!kq)
                {
                    Seachcode sheaching = new Seachcode(this, "tblsales");
                    sheaching.Show();
                }




            }


        }


        public BindingSource source2;
        public Viewtable(IQueryable rs, LinqtoSQLDataContext dc, string fornname, int viewcode)
        {
            //    this.dataGridView1.DataSource = rs;
            InitializeComponent();


            dc.CommandTimeout = 0;
            this.KeyPreview = true;
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(Control_KeyPress);

            this.dataGridView1.DataSource = rs;
            this.Dtgridview = dataGridView1;

            this.db = dc;
            this.viewcode = viewcode;
            this.rs = rs;
            this.lb_seach.Text = "F3 TÌM KIẾM";
            //      this.bt_sendinggroup.Visible = false;
            this.lb_seach.Visible = false;
            this.Pl_endview.Visible = false;
            gboxUnpaid.Visible = false; // an nhom field upaid

            this.formlabel.Text = fornname;


            bt_addtomaster.Visible = false;
            this.bt_addtomaster.Visible = false;

            this.lb_totalrecord.Text = dataGridView1.RowCount.ToString("#,#", CultureInfo.InvariantCulture);// ;//String.Format("{0:0,0}", k33q); 
                                                                                                            //  this.lb_totalrecord.ForeColor = Color.Chocolate;
                                                                                                            //   this.Show();
            this.KeyPreview = true;

            if (viewcode == 100)//nếu là massconffimr
            {
                this.lb_seach.Text = "";
            }

            if (viewcode == 11)//nếu là massconffimr
            {
                this.btmassconfirm.Visible = true;
            }
            else
            {
                this.btmassconfirm.Visible = false;
            }
            //  btmasschangecontract

            if (viewcode == 12)//nếu là masschange contract
            {
                this.btmasschangecontract.Visible = true;
            }
            else
            {
                this.btmasschangecontract.Visible = false;
            }


            if (viewcode == 5)// tuwc la view mastercontract
            {
                #region viewcode = 5 tuwc la view mastercontract
                #region  format lsstmatercontracts
                //                  tbl_kacontractdata.ContractNo,
                //                           tbl_kacontractdata.SalesOrg,
                //                           tbl_kacontractdata.ConType,//contract type
                //                           tbl_kacontractdata.Consts, //contract status
                //                           tbl_kacontractdata.Currency,
                //                           Validfrom = tbl_kacontractdata.EffDate,
                //                           Validto = tbl_kacontractdata.EftDate,

                //                           tbl_kacontractdata.Customer,
                //                           tbl_kacontractdata.Fullname,
                //                           tbl_kacontractdata.Channel,
                //                           FullCommitment = tbl_kacontractdata.TotSponsoredcommit,
                this.dataGridView1.Columns["FullCommitment"].DefaultCellStyle.Format = "N0";
                this.dataGridView1.Columns["FullCommitment"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

                //                           AchivedCommitment = tbl_kacontractdata.TotDeal,
                this.dataGridView1.Columns["AchivedCommitment"].DefaultCellStyle.Format = "N0";
                this.dataGridView1.Columns["AchivedCommitment"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
                this.dataGridView1.Columns["AchivedCommitment"].HeaderText = "Achived Commitment";

                //                           tbl_kacontractdata.Tot_paid,
                this.dataGridView1.Columns["Tot_paid"].DefaultCellStyle.Format = "N0";
                this.dataGridView1.Columns["Tot_paid"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
                this.dataGridView1.Columns["Tot_paid"].HeaderText = "Total Paid";

                //                           Balance = tbl_kacontractdata.TotDeal - tbl_kacontractdata.Tot_paid,
                this.dataGridView1.Columns["Balance"].DefaultCellStyle.Format = "N0";
                this.dataGridView1.Columns["Balance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
                                                                                                                            //       this.dataGridView1.Columns["Balance"].HeaderText = "Total Paid";
                                                                                                                            //                           VolumeCommit = tbl_kacontractdata.VolComm,
                this.dataGridView1.Columns["VolumeCommit"].DefaultCellStyle.Format = "N0";
                this.dataGridView1.Columns["VolumeCommit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
                this.dataGridView1.Columns["VolumeCommit"].HeaderText = "Volume Commit";

                //                           tbl_kacontractdata.PCVolAched,
                this.dataGridView1.Columns["PCVolAched"].DefaultCellStyle.Format = "N0";
                this.dataGridView1.Columns["PCVolAched"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
                this.dataGridView1.Columns["PCVolAched"].HeaderText = "PC VolAched";

                //                           tbl_kacontractdata.NSRAched,
                this.dataGridView1.Columns["NSRAched"].DefaultCellStyle.Format = "N0";
                this.dataGridView1.Columns["NSRAched"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
                this.dataGridView1.Columns["NSRAched"].HeaderText = "NSR Ached";


                //                           tbl_kacontractdata.UCVolAched,
                this.dataGridView1.Columns["UCVolAched"].DefaultCellStyle.Format = "N0";
                this.dataGridView1.Columns["UCVolAched"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
                this.dataGridView1.Columns["UCVolAched"].HeaderText = "UC VolAched";

                //                           tbl_kacontractdata.CRDDAT,
                //                           tbl_kacontractdata.CRDUSR,



                #endregion


                #endregion viewcpde = 5
            }


            if (viewcode == 4)// tuwc la view detailcontract
            {

                #region format





                //ContractNo = tbl_kacontractsdatadetail.ContractNo,
                //Region = tbl_kacontractsdatadetail.SalesOrg,

                //Constatus = tbl_kacontractsdatadetail.Constatus,
                //Contracttype = tbl_kacontractsdatadetail.ConType,
                //EffFrm = tbl_kacontractsdatadetail.EffFrm,

                //EffTo = tbl_kacontractsdatadetail.EffTo,
                //CustomerCode = tbl_kacontractsdatadetail.Customercode,
                //EftNoOfMonth = tbl_kacontractsdatadetail.EftNoOfMonth,
                //CurrentMonth = tbl_kacontractsdatadetail.CurrentMonth,

                //PCVolAched = tbl_kacontractsdatadetail.PCVolAched,
                this.dataGridView1.Columns["PCVolAched"].DefaultCellStyle.Format = "N0";
                this.dataGridView1.Columns["PCVolAched"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
                                                                                                                               //UCVolAched = tbl_kacontractsdatadetail.UCVolAched,
                this.dataGridView1.Columns["UCVolAched"].DefaultCellStyle.Format = "N0";
                this.dataGridView1.Columns["UCVolAched"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

                //LitAched = tbl_kacontractsdatadetail.LitAched,
                this.dataGridView1.Columns["LitAched"].DefaultCellStyle.Format = "N0";
                this.dataGridView1.Columns["LitAched"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

                //FTNAched = tbl_kacontractsdatadetail.ECAched,
                this.dataGridView1.Columns["FTNAched"].DefaultCellStyle.Format = "N0";
                this.dataGridView1.Columns["FTNAched"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

                //NSRAched = tbl_kacontractsdatadetail.NSRAched,
                this.dataGridView1.Columns["NSRAched"].DefaultCellStyle.Format = "N0";
                this.dataGridView1.Columns["NSRAched"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
                                                                                                                             //AccruedAmt = tbl_kacontractsdatadetail.AccruedAmt,
                this.dataGridView1.Columns["AccruedAmt"].DefaultCellStyle.Format = "N0";
                this.dataGridView1.Columns["AccruedAmt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

                //PayControl = tbl_kacontractsdatadetail.PayControl,


                //Description = tbl_kacontractsdatadetail.Description,
                //PrdGrp = tbl_kacontractsdatadetail.PrdGrp,
                //FundPercentage = tbl_kacontractsdatadetail.FundPercentage,
                //SponsoredAmtperPC = tbl_kacontractsdatadetail.SponsoredAmtperPC,
                this.dataGridView1.Columns["SponsoredAmtperPC"].DefaultCellStyle.Format = "N0";
                this.dataGridView1.Columns["SponsoredAmtperPC"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

                //AccruedDate = tbl_kacontractsdatadetail.AccruedDate,
                //FullCommitment = tbl_kacontractsdatadetail.SponsoredAmt,

                this.dataGridView1.Columns["FullCommitment"].DefaultCellStyle.Format = "N0";
                this.dataGridView1.Columns["FullCommitment"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

                //CommitmentCurrent = tbl_kacontractsdatadetail.SponsoredTotal,
                this.dataGridView1.Columns["CommitmentCurrent"].DefaultCellStyle.Format = "N0";
                this.dataGridView1.Columns["CommitmentCurrent"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
                                                                                                                                      //TotalPaid = tbl_kacontractsdatadetail.PaidAmt,
                this.dataGridView1.Columns["TotalPaid"].DefaultCellStyle.Format = "N0";
                this.dataGridView1.Columns["TotalPaid"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
                                                                                                                              //Balance = tbl_kacontractsdatadetail.Balance, //(to be accrual)


                this.dataGridView1.Columns["Balance"].DefaultCellStyle.Format = "N0";
                this.dataGridView1.Columns["Balance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";



                #endregion


            }

            if (viewcode == 1 || viewcode == 2|| viewcode == 100)// nếu là hiện salevolum ta cộng salesvolume
            {
                #region view code = 1 hoac 2


                Pl_endview.Visible = true;
                bt_addtomaster.Visible = true;

                if (viewcode == 2|| viewcode == 100)
                {
                    bt_addtomaster.Visible = false;
                    lb_seach.Visible = true;




                    this.dataGridView1.Columns["PCs"].DefaultCellStyle.Format = "N0";
                    this.dataGridView1.Columns["GSR"].DefaultCellStyle.Format = "N0";

                    this.dataGridView1.Columns["Litter"].DefaultCellStyle.Format = "N0";
                    this.dataGridView1.Columns["NSR"].DefaultCellStyle.Format = "N0";


                    this.dataGridView1.Columns["EC"].DefaultCellStyle.Format = "N0";
                    this.dataGridView1.Columns["UC"].DefaultCellStyle.Format = "N0";


                }

                #region// tính sum of biliing q ty, ....




                #endregion

                System.Data.DataTable dt = new System.Data.DataTable();



                Utils ut = new Utils();
                dt = ut.ToDataTable(db, rs);



                this.dataGridView1.DataSource = dt;


                this.Status.Text = "Caculating ...";

                Thread tt1 = new Thread(sumtitleGrid);

                tt1.IsBackground = true;
                tt1.Start(new datatoExport() { datatble = dt });

                #endregion




            }


            if (viewcode == 33)// neu la updaie reports
            {
                gboxUnpaid.Visible = true; // an nhom field upaid
                                           // add detai field


                string username = Utils.getUsername();

                var typecontract = from Tka_RightContracttypeview in db.Tka_RightContracttypeviews
                                   where Tka_RightContracttypeview.UserName == username
                                   select Tka_RightContracttypeview.Contracttype;


                this.cbocntracttype.Items.Clear();
                // cbocntracttype.Items.Add("");

                foreach (var item in typecontract)
                {
                    cbocntracttype.Items.Add(item);
                }

                //    //
                //    tbl_kacontractsdatadetail.SalesOrg,
                //                     tbl_kacontractsdatadetail.CommittedDate,
                //                     tbl_kacontractsdatadetail.ContractNo,
                //                     tbl_kacontractsdatadetail.ConType,
                //                     tbl_kacontractsdatadetail.Constatus,
                //                     tbl_kacontractsdatadetail.Customercode,
                //                     tbl_kacontractsdatadetail.Fullname,
                //                     tbl_kacontractsdatadetail.Address,

                //                     tbl_kacontractsdatadetail.PayType,
                //                     tbl_kacontractsdatadetail.PayControl,
                //                     tbl_kacontractsdatadetail.Description,

                //                     Achived = tbl_kacontractsdatadetail.SponsoredTotal,
                //                     Paid = tbl_kacontractsdatadetail.PaidAmt,
                //                     Unpaid = tbl_kacontractsdatadetail.SponsoredTotal - tbl_kacontractsdatadetail.PaidAmt,

                //                     tbl_kacontractsdatadetail.EffFrm,
                //                     tbl_kacontractsdatadetail.EffTo,
                //                     tbl_kacontractsdatadetail.Remark,
                ////


                this.dataGridView1.Columns["Achived"].DefaultCellStyle.Format = "N0";
                this.dataGridView1.Columns["Paid"].DefaultCellStyle.Format = "N0";

                this.dataGridView1.Columns["Unpaid"].DefaultCellStyle.Format = "N0";




            }



        }


        private void bt_exporttoex_Click(object sender, EventArgs e)
        {


            Control_ac ctrex = new Control_ac();


            ctrex.exportExceldatagridtofile(this.rs, this.db, this.Text);

        }

        private void Viewtable_Load(object sender, EventArgs e)
        {

        }





        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (viewcode == 2)// nuew la bàng salsetemp update
            {

                // string connection_string = Utils.getConnectionstr();

                //LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


                //  this.Text = "iNPUT DEPOSIT AMOUNTT !";
                string colheadertext = "";
                try
                {
                     colheadertext = this.dataGridView1.Columns[this.dataGridView1.CurrentCell.ColumnIndex].HeaderText;

                }
                catch (Exception)
                {

                     colheadertext = "";
                }
          


                dc.CommandTimeout = 0;
                if (colheadertext == "Sold_to")
                {

                    double customer = (double)this.dataGridView1.CurrentRow.Cells["Sold_to"].Value;
                    string Priod = this.dataGridView1.CurrentRow.Cells["Priod"].Value.ToString();
                    var rs = from tbl_kasale in dc.tbl_kasales
                             where tbl_kasale.Priod == Priod && tbl_kasale.Sold_to == customer
                             select new
                             {


                                 tbl_kasale.Priod,
                                 tbl_kasale.Sales_District,
                                 tbl_kasale.Sales_District_desc,
                                 tbl_kasale.Sales_Org,
                                 tbl_kasale.Sold_to,
                                 tbl_kasale.Cust_Name,
                                 tbl_kasale.Outbound_Delivery,
                                 tbl_kasale.Key_Acc_Nr,
                                 tbl_kasale.Delivery_Date,
                                 tbl_kasale.Invoice_Doc_Nr,
                                 tbl_kasale.Invoice_Date,
                                 tbl_kasale.Currency,
                                 tbl_kasale.Mat_Group,
                                 tbl_kasale.Mat_Group_Text,
                                 tbl_kasale.Mat_Number,
                                 tbl_kasale.Mat_Text,

                                 PCs = tbl_kasale.EC,
                                 tbl_kasale.UoM,
                                 EC = tbl_kasale.PC,

                                 tbl_kasale.UC,
                                 tbl_kasale.Litter,
                                 tbl_kasale.GSR,

                                 tbl_kasale.NSR,





                                 tbl_kasale.Username,
                                 tbl_kasale.id



                             };


                    this.dataGridView1.DataSource = rs;
                    this.Dtgridview = dataGridView1;

                    this.db = dc;
                    //    this.viewcode = viewcode;
                    this.rs = rs;
                    this.dataGridView1.Columns["PCs"].DefaultCellStyle.Format = "N0";
                    this.dataGridView1.Columns["GSR"].DefaultCellStyle.Format = "N0";

                    this.dataGridView1.Columns["Litter"].DefaultCellStyle.Format = "N0";
                    this.dataGridView1.Columns["NSR"].DefaultCellStyle.Format = "N0";


                    this.dataGridView1.Columns["EC"].DefaultCellStyle.Format = "N0";
                    this.dataGridView1.Columns["UC"].DefaultCellStyle.Format = "N0";


                    this.Status.Text = "Caculating ...";

                    System.Data.DataTable dt = new System.Data.DataTable();
                    Utils ut = new Utils();
                    dt = ut.ToDataTable(db, rs);


                    Thread tt1 = new Thread(sumtitleGrid);

                    tt1.IsBackground = true;
                    tt1.Start(new datatoExport() { datatble = dt });


                }

                if (colheadertext == "Priod")
                {

                    //  double customer = (double)this.dataGridView1.CurrentRow.Cells["Sold_to"].Value;
                    string Priod = this.dataGridView1.CurrentRow.Cells["Priod"].Value.ToString();
                    dc.CommandTimeout = 0;

                    var rs = from tbl_kasale in dc.tbl_kasales
                             where tbl_kasale.Priod == Priod
                             group tbl_kasale by new
                             {
                                 tbl_kasale.Sold_to,
                                 tbl_kasale.Sales_Org

                             }
                              into g
                             select new
                             {
                                 Priod = g.Select(gg => gg.Priod).FirstOrDefault(),
                                 Region = g.Key.Sales_Org,
                                 Sold_to = g.Key.Sold_to,
                                 Name = g.Select(gg => gg.Cust_Name).FirstOrDefault(),
                                 PCs = g.Sum(gg => gg.EC).GetValueOrDefault(0),
                                 EC = Math.Ceiling(g.Sum(gg => gg.PC).GetValueOrDefault(0)),
                                 UC = Math.Ceiling(g.Sum(gg => gg.UC).GetValueOrDefault(0)),
                                 Litter = Math.Ceiling(g.Sum(gg => gg.Litter).GetValueOrDefault(0)),
                                 NSR = Math.Ceiling(g.Sum(gg => gg.NSR).GetValueOrDefault(0)),
                                 GSR = Math.Ceiling(g.Sum(gg => gg.GSR).GetValueOrDefault(0)),



                             };
                    this.dataGridView1.DataSource = rs;
                    this.Dtgridview = dataGridView1;

                    this.db = dc;
                    //    this.viewcode = viewcode;
                    this.rs = rs;

                    this.dataGridView1.Columns["PCs"].DefaultCellStyle.Format = "N0";
                    this.dataGridView1.Columns["GSR"].DefaultCellStyle.Format = "N0";

                    this.dataGridView1.Columns["Litter"].DefaultCellStyle.Format = "N0";
                    this.dataGridView1.Columns["NSR"].DefaultCellStyle.Format = "N0";


                    this.dataGridView1.Columns["EC"].DefaultCellStyle.Format = "N0";
                    this.dataGridView1.Columns["UC"].DefaultCellStyle.Format = "N0";

                    this.Status.Text = "Caculating ...";

                    System.Data.DataTable dt = new System.Data.DataTable();
                    Utils ut = new Utils();
                    dt = ut.ToDataTable(db, rs);


                    Thread tt1 = new Thread(sumtitleGrid);

                    tt1.IsBackground = true;
                    tt1.Start(new datatoExport() { datatble = dt });

                }







            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }




        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void bt_addtomaster_Click(object sender, EventArgs e)
        {
            if (viewcode == 1)// nuew la bàng salsetemp update
            {

                string connection_string = Utils.getConnectionstr();

                LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


                #region// load sales data

                SqlConnection conn2 = null;
                SqlDataReader rdr1 = null;
                string username = Utils.getUsername();

                string destConnString = Utils.getConnectionstr();
                try
                {

                    conn2 = new SqlConnection(destConnString);
                    conn2.Open();
                    SqlCommand cmd1 = new SqlCommand("KAuploadtoSaledata", conn2);
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.Add("@username", SqlDbType.VarChar).Value = username;

                    rdr1 = cmd1.ExecuteReader();



                    //       rdr1 = cmd1.ExecuteReader();

                }
                finally
                {
                    if (conn2 != null)
                    {
                        conn2.Close();
                    }
                    if (rdr1 != null)
                    {
                        rdr1.Close();
                    }
                }

                //     this.Dtgridview.DataSource = null;
                MessageBox.Show("Upload Done !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);



                #endregion update pc, uc    





            }






        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //     "List Detail Payment Request"

            // public Viewtable(IQueryable rs, LinqtoSQLDataContext dc, string fornname, int viewcode)
            //   tbl_Temp



            if (this.formlabel.Text == "List Detail Payment Request" && viewcode == 3)
            {

          //      Model.Username used = new Model.Username();

              
            }



            if (viewcode == 33)
            {

              //  Model.Username used = new Model.Username();

                
            }





        }

        private void comboucontractstst_SelectedValueChanged(object sender, EventArgs e)
        {
            string contractstatus = comboucontractstst.Text.Trim();
            string contractype = cbocntracttype.Text.Trim();
            //   ReloadKASeachcontractype("", "", "", contractype);

            string connection_string = Utils.getConnectionstr();
            string username = Utils.getUsername();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            var regioncode = (from tbl_Temp in dc.tbl_Temps
                              where tbl_Temp.username == username
                              select tbl_Temp.RegionCode).FirstOrDefault();




            var rscustemp2 = from tbl_kacontractsdatadetail in dc.tbl_kacontractsdatadetails
                             where tbl_kacontractsdatadetail.SponsoredTotal > tbl_kacontractsdatadetail.PaidAmt
                              && (from Tka_RegionRight in dc.Tka_RegionRights
                                  where Tka_RegionRight.RegionCode == regioncode
                                  select Tka_RegionRight.Region
                              ).Contains(tbl_kacontractsdatadetail.SALORG_CTR)
                              && tbl_kacontractsdatadetail.ConType.Contains(contractype)
                              && tbl_kacontractsdatadetail.Constatus.Contains(contractstatus)

                             select new
                             {
                                 tbl_kacontractsdatadetail.SalesOrg,
                                 tbl_kacontractsdatadetail.CommittedDate,
                                 tbl_kacontractsdatadetail.ContractNo,
                                 tbl_kacontractsdatadetail.ConType,
                                 tbl_kacontractsdatadetail.Constatus,
                                 tbl_kacontractsdatadetail.Customercode,
                                 tbl_kacontractsdatadetail.Fullname,
                                 tbl_kacontractsdatadetail.Address,
                                 tbl_kacontractsdatadetail.PayType,
                                 tbl_kacontractsdatadetail.PayControl,
                                 tbl_kacontractsdatadetail.Description,

                                 Achived = tbl_kacontractsdatadetail.SponsoredTotal,
                                 Paid = tbl_kacontractsdatadetail.PaidAmt,
                                 Unpaid = tbl_kacontractsdatadetail.SponsoredTotal - tbl_kacontractsdatadetail.PaidAmt,

                                 tbl_kacontractsdatadetail.EffFrm,
                                 tbl_kacontractsdatadetail.EffTo,
                                 tbl_kacontractsdatadetail.Remark,


                             };


            this.dataGridView1.DataSource = rscustemp2;
            this.Dtgridview = dataGridView1;

            this.db = dc;
            //    this.viewcode = viewcode;
            this.rs = rscustemp2;



        }

        private void cbocntracttype_SelectedValueChanged(object sender, EventArgs e)
        {
            string contractstatus = comboucontractstst.Text.Trim();
            string contractype = cbocntracttype.Text.Trim();
            //   ReloadKASeachcontractype("", "", "", contractype);

            string connection_string = Utils.getConnectionstr();
            string username = Utils.getUsername();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            var regioncode = (from tbl_Temp in dc.tbl_Temps
                              where tbl_Temp.username == username
                              select tbl_Temp.RegionCode).FirstOrDefault();




            var rscustemp2 = from tbl_kacontractsdatadetail in dc.tbl_kacontractsdatadetails
                             where tbl_kacontractsdatadetail.SponsoredTotal > tbl_kacontractsdatadetail.PaidAmt
                              && (from Tka_RegionRight in dc.Tka_RegionRights
                                  where Tka_RegionRight.RegionCode == regioncode
                                  select Tka_RegionRight.Region
                              ).Contains(tbl_kacontractsdatadetail.SALORG_CTR)
                              && tbl_kacontractsdatadetail.ConType.Contains(contractype)
                              && tbl_kacontractsdatadetail.Constatus.Contains(contractstatus)

                             select new
                             {
                                 tbl_kacontractsdatadetail.SalesOrg,
                                 tbl_kacontractsdatadetail.CommittedDate,
                                 tbl_kacontractsdatadetail.ContractNo,
                                 tbl_kacontractsdatadetail.ConType,
                                 tbl_kacontractsdatadetail.Constatus,
                                 tbl_kacontractsdatadetail.Customercode,
                                 tbl_kacontractsdatadetail.Fullname,
                                 tbl_kacontractsdatadetail.Address,
                                 tbl_kacontractsdatadetail.PayType,
                                 tbl_kacontractsdatadetail.PayControl,
                                 tbl_kacontractsdatadetail.Description,

                                 Achived = tbl_kacontractsdatadetail.SponsoredTotal,
                                 Paid = tbl_kacontractsdatadetail.PaidAmt,
                                 Unpaid = tbl_kacontractsdatadetail.SponsoredTotal - tbl_kacontractsdatadetail.PaidAmt,

                                 tbl_kacontractsdatadetail.EffFrm,
                                 tbl_kacontractsdatadetail.EffTo,
                                 tbl_kacontractsdatadetail.Remark,


                             };


            this.dataGridView1.DataSource = rscustemp2;
            this.Dtgridview = dataGridView1;

            this.db = dc;
            //    this.viewcode = viewcode;
            this.rs = rscustemp2;


        }

        private void btmassconfirm_Click(object sender, EventArgs e)
        {
            string connection_string = Utils.getConnectionstr();


            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            //   string connection_string = Utils.getConnectionstr();
            string username = Utils.getUsername();

            #region  update vào detai contact

            Thread t2 = new Thread(showwait);
            t2.Start();
            //   autoEvent.WaitOne(); //join



            var excelist = from tbl_MassConfirmTemp in dc.tbl_MassConfirmTemps
                           where tbl_MassConfirmTemp.Username == username && tbl_MassConfirmTemp.status == false
                           select tbl_MassConfirmTemp;
            if (excelist.Count() > 0)
            {


                foreach (var item in excelist)
                {
                    // listkeyaccount.Add(((int)item).ToString());

                    var paymentdetail = from tbl_kacontractsdetailpayment in dc.tbl_kacontractsdetailpayments
                                        where tbl_kacontractsdetailpayment.ContractNo.Equals(item.ContractNo) &&
                                        tbl_kacontractsdetailpayment.PayType.Equals(item.PayType) &&
                                        tbl_kacontractsdetailpayment.BatchNo == item.BatchNo
                                        select tbl_kacontractsdetailpayment;

                    //    MessageBox.Show("check "+ paymentdetail.Count(), "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (paymentdetail.Count() > 0)
                    {



                        foreach (var item2 in paymentdetail)
                        {
                            if (item2.PaidRequestAmt == item.PaidRequestAmt)
                            {
                                item2.PaidOn = DateTime.Today;
                                item2.PayControl = "PAY";


                                item2.PaidAmt = item.PaidRequestAmt;


                                item2.PaidNote = item.PaidNote;
                                item2.PaymentDoc = item.PaymentDoc;

                                item2.UPDDAT = DateTime.Today;
                                item2.UPDUSR = username;
                                item.status = true;

                                dc.SubmitChanges();
                            }
                        }

                    }



                }
            }

            #endregion


            #region  viewlaij table
            Thread.Sleep(100);
            t2.Abort();

            var rs222 = from tbl_MassConfirmTemp in dc.tbl_MassConfirmTemps
                        where tbl_MassConfirmTemp.Username == username && tbl_MassConfirmTemp.status == false
                        select tbl_MassConfirmTemp;

            this.dataGridView1.DataSource = rs222;
            //    this.Dtgridview = dataGridView1;
            //this.dataGridView1.

            //    this.Dtgridview = dataGridView1;

            if (rs222.Count() > 0)
            {
                MessageBox.Show("There are the list doc can not MassConfirm ", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("MassConfrim Done, it is ok ! ", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            #endregion



        }


        public static void showwait()
        {
            View.Caculating wat = new View.Caculating();
            wat.ShowDialog();


        }



        private void btmasschangecontract_Click(object sender, EventArgs e)
        {



            #region


            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);





            DialogResult kq = MessageBox.Show(" Are you sure  masschange status of there contracts ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            string username = Utils.getUsername();


            //string connection_string = Utils.getConnectionstr();


            //LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            ////   string connection_string = Utils.getConnectionstr();
            //string username = Utils.getUsername();

            //#region  update vào detai contact


            switch (kq)
            {

                case DialogResult.None:
                    break;
                case DialogResult.Yes:

                    Thread t2 = new Thread(showwait);
                    t2.Start();
                    //   autoEvent.WaitOne(); //join



                    //     }



                    var excelist = from tbl_MassContractChangeTemp in db.tbl_MassContractChangeTemps
                                   where tbl_MassContractChangeTemp.Username == username && tbl_MassContractChangeTemp.status == false
                                   select tbl_MassContractChangeTemp;
                    if (excelist.Count() >=0)
                    {




                        foreach (var item in excelist)
                        {


                            #region change contract


                            string contractno = item.ContractNo.Trim();
                            string status = item.Consts.Trim();

                            var statusrs = (from tbl_kacontractdata in db.tbl_kacontractdatas
                                            where tbl_kacontractdata.ContractNo.Equals(contractno)
                                            select tbl_kacontractdata).FirstOrDefault();

                            if (statusrs != null)
                            {
                                statusrs.Consts = status;
                                item.status = true;
                                db.SubmitChanges();



                                var detail = from tbl_kacontractsdatadetail in dc.tbl_kacontractsdatadetails
                                             where tbl_kacontractsdatadetail.ContractNo.Equals(contractno)
                                             select tbl_kacontractsdatadetail;

                                if (detail.Count() >= 0)
                                {
                                    foreach (var item2 in detail)
                                    {
                                        item2.Constatus = status;
                                        dc.SubmitChanges();
                                    }
                                }



                                //     Control.Control_ac.CaculationContract(contractno);
                                //   loadDetailContractView(contractno);
                                // loadtotaldContractView(contractno);
                            }

                            #endregion change contract










                        }

                        Thread.Sleep(100);
                        t2.Abort();


                        #region  viewlaij table

                        var rs222 = from tbl_MassContractChangeTemp in dc.tbl_MassContractChangeTemps
                                    where tbl_MassContractChangeTemp.Username == username && tbl_MassContractChangeTemp.status == false
                                    select tbl_MassContractChangeTemp;

                        this.dataGridView1.DataSource = rs222;
                        //    this.Dtgridview = dataGridView1;
                        //this.dataGridView1.

                        //    this.Dtgridview = dataGridView1;

                        if (rs222.Count() > 0)
                        {
                            MessageBox.Show("There are the list doc can not Masschange ", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            MessageBox.Show("MassChange Done, it is ok ! ", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }


                        #endregion


                    }

                    break;
                case DialogResult.Cancel:
                    break;
                case DialogResult.Abort:
                    break;
                case DialogResult.Retry:
                    break;
                case DialogResult.Ignore:
                    break;
                case DialogResult.OK:
                    break;
                case DialogResult.No:



                    break;
                default:
                    break;
            }
            #endregion











        }
    }
}
