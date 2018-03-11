namespace BCP.View
{
    using BCP;
    using System.Windows.Forms;

    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        /// 
       
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pic_report = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.inputusser = new System.Windows.Forms.PictureBox();
            this.pic_arrelease = new System.Windows.Forms.PictureBox();
            this.pic_shipmentcreate = new System.Windows.Forms.PictureBox();
            this.pic_printinvoice = new System.Windows.Forms.PictureBox();
            this.pic_ordercreate = new System.Windows.Forms.PictureBox();
            this.inputmarterdata = new System.Windows.Forms.PictureBox();
            this.webBrowser2 = new System.Windows.Forms.WebBrowser();
            this.lb_user = new System.Windows.Forms.Label();
            this.lbusername = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_report)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputusser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_arrelease)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_shipmentcreate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_printinvoice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_ordercreate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputmarterdata)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.webBrowser2);
            this.panel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel1.Location = new System.Drawing.Point(1, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1046, 1110);
            this.panel1.TabIndex = 20;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.pic_report);
            this.groupBox1.Controls.Add(this.pictureBox7);
            this.groupBox1.Controls.Add(this.inputusser);
            this.groupBox1.Controls.Add(this.pic_arrelease);
            this.groupBox1.Controls.Add(this.pic_shipmentcreate);
            this.groupBox1.Controls.Add(this.pic_printinvoice);
            this.groupBox1.Controls.Add(this.pic_ordercreate);
            this.groupBox1.Controls.Add(this.inputmarterdata);
            this.groupBox1.Location = new System.Drawing.Point(3, -5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(820, 638);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.ErrorImage = global::BCP.Properties.Resources.Settle;
            this.pictureBox1.Image = global::BCP.Properties.Resources.Settle;
            this.pictureBox1.InitialImage = global::BCP.Properties.Resources.Settle;
            this.pictureBox1.Location = new System.Drawing.Point(301, 490);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(110, 114);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click_2);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave_1);
            this.pictureBox1.MouseHover += new System.EventHandler(this.pictureBox1_MouseHover_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(10, 162);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Business Continuity Plan";
            // 
            // pic_report
            // 
            this.pic_report.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pic_report.ErrorImage = global::BCP.Properties.Resources.Reports1;
            this.pic_report.Image = global::BCP.Properties.Resources.Reports1;
            this.pic_report.InitialImage = global::BCP.Properties.Resources.Reports1;
            this.pic_report.Location = new System.Drawing.Point(588, 115);
            this.pic_report.Name = "pic_report";
            this.pic_report.Size = new System.Drawing.Size(107, 121);
            this.pic_report.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_report.TabIndex = 9;
            this.pic_report.TabStop = false;
            this.pic_report.Click += new System.EventHandler(this.pic_report_Click);
            this.pic_report.MouseLeave += new System.EventHandler(this.pic_report_MouseLeave);
            this.pic_report.MouseHover += new System.EventHandler(this.pic_report_MouseHover);
            // 
            // pictureBox7
            // 
            this.pictureBox7.ErrorImage = global::BCP.Properties.Resources.giphy__1_;
            this.pictureBox7.Image = global::BCP.Properties.Resources.giphy__1_;
            this.pictureBox7.InitialImage = global::BCP.Properties.Resources.giphy__1_;
            this.pictureBox7.Location = new System.Drawing.Point(13, 54);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(119, 105);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 6;
            this.pictureBox7.TabStop = false;
            this.pictureBox7.Click += new System.EventHandler(this.pictureBox7_Click);
            this.pictureBox7.MouseLeave += new System.EventHandler(this.pictureBox7_MouseLeave);
            this.pictureBox7.MouseHover += new System.EventHandler(this.pictureBox7_MouseHover);
            // 
            // inputusser
            // 
            this.inputusser.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.inputusser.ErrorImage = global::BCP.Properties.Resources.USERSETUP1;
            this.inputusser.Image = global::BCP.Properties.Resources.USERSETUP1;
            this.inputusser.InitialImage = global::BCP.Properties.Resources.USERSETUP1;
            this.inputusser.Location = new System.Drawing.Point(28, 366);
            this.inputusser.Name = "inputusser";
            this.inputusser.Size = new System.Drawing.Size(104, 121);
            this.inputusser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.inputusser.TabIndex = 2;
            this.inputusser.TabStop = false;
            this.inputusser.Click += new System.EventHandler(this.pictureBox3_Click);
            this.inputusser.MouseLeave += new System.EventHandler(this.pictureBox3_MouseLeave);
            this.inputusser.MouseHover += new System.EventHandler(this.pictureBox3_MouseHover);
            // 
            // pic_arrelease
            // 
            this.pic_arrelease.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pic_arrelease.ErrorImage = global::BCP.Properties.Resources.images;
            this.pic_arrelease.Image = global::BCP.Properties.Resources.images;
            this.pic_arrelease.InitialImage = global::BCP.Properties.Resources.images;
            this.pic_arrelease.Location = new System.Drawing.Point(301, 153);
            this.pic_arrelease.Name = "pic_arrelease";
            this.pic_arrelease.Size = new System.Drawing.Size(127, 79);
            this.pic_arrelease.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_arrelease.TabIndex = 0;
            this.pic_arrelease.TabStop = false;
            this.pic_arrelease.Click += new System.EventHandler(this.pic_arrelease_Click);
            this.pic_arrelease.MouseLeave += new System.EventHandler(this.pic_arrelease_MouseLeave);
            this.pic_arrelease.MouseHover += new System.EventHandler(this.pic_arrelease_MouseHover);
            // 
            // pic_shipmentcreate
            // 
            this.pic_shipmentcreate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pic_shipmentcreate.ErrorImage = global::BCP.Properties.Resources.delivery;
            this.pic_shipmentcreate.Image = global::BCP.Properties.Resources.delivery;
            this.pic_shipmentcreate.InitialImage = global::BCP.Properties.Resources.delivery;
            this.pic_shipmentcreate.Location = new System.Drawing.Point(268, 247);
            this.pic_shipmentcreate.Name = "pic_shipmentcreate";
            this.pic_shipmentcreate.Size = new System.Drawing.Size(187, 96);
            this.pic_shipmentcreate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_shipmentcreate.TabIndex = 4;
            this.pic_shipmentcreate.TabStop = false;
            this.pic_shipmentcreate.Click += new System.EventHandler(this.pic_shipmentcreate_Click);
            this.pic_shipmentcreate.MouseLeave += new System.EventHandler(this.pic_shipmentcreate_MouseLeave);
            this.pic_shipmentcreate.MouseHover += new System.EventHandler(this.pic_shipmentcreate_MouseHover);
            // 
            // pic_printinvoice
            // 
            this.pic_printinvoice.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pic_printinvoice.ErrorImage = global::BCP.Properties.Resources.Varig_Log_svg;
            this.pic_printinvoice.Image = global::BCP.Properties.Resources.Varig_Log_svg;
            this.pic_printinvoice.InitialImage = global::BCP.Properties.Resources.Varig_Log_svg;
            this.pic_printinvoice.Location = new System.Drawing.Point(233, 366);
            this.pic_printinvoice.Name = "pic_printinvoice";
            this.pic_printinvoice.Size = new System.Drawing.Size(265, 106);
            this.pic_printinvoice.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_printinvoice.TabIndex = 3;
            this.pic_printinvoice.TabStop = false;
            this.pic_printinvoice.Click += new System.EventHandler(this.pic_printinvoice_Click);
            this.pic_printinvoice.MouseLeave += new System.EventHandler(this.pic_printinvoice_MouseLeave);
            this.pic_printinvoice.MouseHover += new System.EventHandler(this.pic_printinvoice_MouseHover);
            // 
            // pic_ordercreate
            // 
            this.pic_ordercreate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pic_ordercreate.ErrorImage = global::BCP.Properties.Resources.fastorder2;
            this.pic_ordercreate.Image = global::BCP.Properties.Resources.fastorder2;
            this.pic_ordercreate.InitialImage = global::BCP.Properties.Resources.fastorder2;
            this.pic_ordercreate.Location = new System.Drawing.Point(301, 15);
            this.pic_ordercreate.Name = "pic_ordercreate";
            this.pic_ordercreate.Size = new System.Drawing.Size(127, 121);
            this.pic_ordercreate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_ordercreate.TabIndex = 1;
            this.pic_ordercreate.TabStop = false;
            this.pic_ordercreate.Click += new System.EventHandler(this.pic_ordercreate_Click);
            this.pic_ordercreate.MouseLeave += new System.EventHandler(this.pic_ordercreate_MouseLeave);
            this.pic_ordercreate.MouseHover += new System.EventHandler(this.pic_ordercreate_MouseHover);
            // 
            // inputmarterdata
            // 
            this.inputmarterdata.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.inputmarterdata.ErrorImage = global::BCP.Properties.Resources.master1;
            this.inputmarterdata.Image = global::BCP.Properties.Resources.master1;
            this.inputmarterdata.InitialImage = global::BCP.Properties.Resources.master2;
            this.inputmarterdata.Location = new System.Drawing.Point(13, 257);
            this.inputmarterdata.Name = "inputmarterdata";
            this.inputmarterdata.Size = new System.Drawing.Size(160, 86);
            this.inputmarterdata.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.inputmarterdata.TabIndex = 5;
            this.inputmarterdata.TabStop = false;
            this.inputmarterdata.Click += new System.EventHandler(this.pictureBox6_Click);
            this.inputmarterdata.MouseLeave += new System.EventHandler(this.pictureBox6_MouseLeave);
            this.inputmarterdata.MouseHover += new System.EventHandler(this.pictureBox6_MouseHover);
            // 
            // webBrowser2
            // 
            this.webBrowser2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser2.Location = new System.Drawing.Point(829, 3);
            this.webBrowser2.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser2.Name = "webBrowser2";
            this.webBrowser2.ScriptErrorsSuppressed = true;
            this.webBrowser2.ScrollBarsEnabled = false;
            this.webBrowser2.Size = new System.Drawing.Size(197, 630);
            this.webBrowser2.TabIndex = 10;
            this.webBrowser2.Tag = "";
            this.webBrowser2.Url = new System.Uri("https://sites.google.com/site/advcocacolagogle", System.UriKind.Absolute);
            // 
            // lb_user
            // 
            this.lb_user.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lb_user.AutoSize = true;
            this.lb_user.Location = new System.Drawing.Point(14, 648);
            this.lb_user.Name = "lb_user";
            this.lb_user.Size = new System.Drawing.Size(58, 13);
            this.lb_user.TabIndex = 23;
            this.lb_user.Text = "User name";
            // 
            // lbusername
            // 
            this.lbusername.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbusername.AutoSize = true;
            this.lbusername.ForeColor = System.Drawing.Color.Red;
            this.lbusername.Location = new System.Drawing.Point(78, 648);
            this.lbusername.Name = "lbusername";
            this.lbusername.Size = new System.Drawing.Size(35, 13);
            this.lbusername.TabIndex = 24;
            this.lbusername.Text = "label1";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 669);
            this.Controls.Add(this.lbusername);
            this.Controls.Add(this.lb_user);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "BCP ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Main_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_report)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputusser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_arrelease)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_shipmentcreate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_printinvoice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_ordercreate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputmarterdata)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lb_user;
        private Label lbusername;
        private PictureBox pictureBox7;
        private PictureBox inputmarterdata;
        private PictureBox pic_shipmentcreate;
        private PictureBox pic_printinvoice;
        private PictureBox inputusser;
        private PictureBox pic_ordercreate;
        private PictureBox pic_arrelease;
        private GroupBox groupBox1;
        private WebBrowser webBrowser2;
        private PictureBox pic_report;
        private Label label1;
        private PictureBox pictureBox1;
    }
}

