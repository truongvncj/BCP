//using Microsoft.Office.Interop.Excel;
using Microsoft.Reporting.WinForms;
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
    public partial class Reportsview : Form
    {
        public DataTable tbl1 { get; set; }
        public DataTable tbl2 { get; set; }
        public string shipment { get; set; }
        public string orderNumber { get; set; }
        public string ticket { get; set; }

        public Reportsview(DataTable tbl1, DataTable tbl2, string rptname, string shipment , string orderNumber ,string ticket) //IQueryable rs
        {
            InitializeComponent();

            this.tbl1 = tbl1;
            this.tbl2 = tbl2;
            this.shipment = shipment;
            this.orderNumber = orderNumber;
            this.ticket = ticket;

            this.reportViewer1.LocalReport.ReportEmbeddedResource = "BCP.Reports." + rptname + "";
            // chọn báo cáo hiển thị

            // chọn data hiển thị

            ReportDataSource datasource = new ReportDataSource("DataSet1", tbl1);

            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(datasource);


            if (tbl2 != null)
            {
                ReportDataSource datasource2 = new ReportDataSource("DataSet2", tbl2);
                this.reportViewer1.LocalReport.DataSources.Add(datasource2);
            }


            this.reportViewer1.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(LocalReport_SubreportProcessing);

            // chọn data hiển thị

            // chọn kiểu hiển thị
            this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);

            // this.reportViewer1.ZoomMode = ZoomMode.Percent;
            // this.reportViewer1.ZoomPercent = 100;
            this.reportViewer1.ZoomMode = ZoomMode.PageWidth;
            this.reportViewer1.ShowExportButton = true;
            this.reportViewer1.ShowPageNavigationControls = true;


            #region kiểm tra printed  OK

            //string connection_string = Utils.getConnectionstr();

            //LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            //var rschangepritcheck = (from tbl_kacontractsdetailpayment in dc.tbl_kacontractsdetailpayments
            //                         where tbl_kacontractsdetailpayment.BatchNo == BatchNo// && tbl_kacontractsdatadetail.SubID == subid && tbl_kacontractsdatadetail.ContractNo == contractno
            //                         select tbl_kacontractsdetailpayment).FirstOrDefault();



            //if (rschangepritcheck != null && rschangepritcheck.PrintChk == true)
            //{

            //    this.reportViewer1.ShowPrintButton = false;

            //  ///  return;
            //}

            #endregion kiểm tra printed





            // this.reportViewer1.ShowPageNavigationControls
            //  this.reportViewer1.ShowExportButto = false;
            //if (rptname == "ARletter.rdlc")
            //{

            ////    tbl_ArletterRpt rptdata = new tbl_ArletterRpt();

            ////    ReportParameter rp0 = new ReportParameter("NO", rptdata.No.ToString());
            //////    ReportParameter rp1 = new ReportParameter("Title", Chart1.Title);
            ////    this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp0 });
            //////    this.reportViewer1.LocalReport.Refresh();




            //}
            ////ReportParameter rp0 = new ReportParameter("Report_Parameter_UserName", tbl_ArletterRpt.);
            //ReportParameter rp1 = new ReportParameter("Title", Chart1.Title);
            //ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp0, rp1 });
            //ReportViewer1.LocalReport.Refresh();

            // chọn kiểu hiển thị

              this.reportViewer1.RefreshReport();




        }

        private void LocalReport_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
        {

            //    var custGroupid = double.Parse(e.Parameters["custGroupid"].Values.First());
            //   var subSource = ((List<Cus>)mainSource.Value).Single(o => o.OrderID == orderId).Suppliers;
            if (tbl2 != null)
            {
                //   e.DataSources.Add(new ReportDataSource("DataSet2", tbl2));
                var IDpage = int.Parse(e.Parameters["IDpage"].Values.First());
                //   var subSource = ((List<Cus>)mainSource.Value).Single(o => o.OrderID == orderId).Suppliers;

                e.DataSources.Add(new ReportDataSource("DataSet2", tbl2));

            }


            //  throw new NotImplementedException();
        }

        private void reportViewer1_Print(object sender, ReportPrintEventArgs e)
        {




        }

        private void reportViewer1_PrintingBegin(object sender, ReportPrintEventArgs e)
        {
            string connection_string = Utils.getAccessConnectionstring();

            OleDbConnection conn = new OleDbConnection(connection_string);

            #region    // if print shipment  == shipment <> "0" and shipment <> ""
            if (this.shipment != "")
            {
                string username = Utils.getUsername();
                // update print ter
             
                conn.Open();
                string StringQuery = @"UPDATE tbl_list_Order 
                                       SET
                                        tbl_list_Order.LoadPrintby = @username
                                       
                                        WHERE
                                        tbl_list_Order.Shipment = @Shipment
                                  
                                                                ";
                OleDbCommand comm = new OleDbCommand(StringQuery, conn);

                comm.Parameters.AddWithValue("@username", username);
                comm.Parameters.AddWithValue("@Shipment", this.shipment);
             
                int temp = comm.ExecuteNonQuery();
                
                conn.Close();

                

            }



            #endregion     // if print shipment  == shipment <> "0" and shipment <> ""  ta update print statuts bang username

            #region    // if print ticket  == ticket <> "0" and ticket <> ""
            if (this.ticket != "")
            {
                string username = Utils.getUsername();
                // update print ter

                conn.Open();
                string StringQuery = @"UPDATE tbl_list_Order 
                                       SET
                                        tbl_list_Order.TicketPrintby = @username
                                       
                                        WHERE
                                        tbl_list_Order.Shipment = @ticket
                                  
                                                                ";
                OleDbCommand comm = new OleDbCommand(StringQuery, conn);

                comm.Parameters.AddWithValue("@username", username);
                comm.Parameters.AddWithValue("@ticket", this.ticket);
            //    MessageBox.Show(this.ticket, "xxx", MessageBoxButtons.OK, MessageBoxIcon.Error);
                try
                {
                    int temp = comm.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                    //  throw;

                    MessageBox.Show(ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            

                conn.Close();



            }



            #endregion     // if print shipment  == shipment <> "0" and shipment <> ""  ta update print statuts bang username

            #region    // if print shipment  == shipment <> "0" and shipment <> ""
            if (this.orderNumber != "")
            {
                string username = Utils.getUsername();
                // update print ter

                conn.Open();
                string StringQuery = @"UPDATE tbl_list_Order 
                                       SET
                                        tbl_list_Order.InvoicePrintby = @username
                                       
                                        WHERE
                                        tbl_list_Order.Document = @orderNumber
                                  
                                                                ";
                OleDbCommand comm = new OleDbCommand(StringQuery, conn);

                comm.Parameters.AddWithValue("@username", username);
                comm.Parameters.AddWithValue("@orderNumber", this.orderNumber);

                int temp = comm.ExecuteNonQuery();

                conn.Close();



            }



            #endregion     // if print shipment  == shipment <> "0" and shipment <> ""  ta update print statuts bang username



            this.Close();



        }
    }



}
