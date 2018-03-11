using System;
using System.Linq;

namespace BCP.View
{
    partial class BCPPrintIvoiceLoad
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BCPPrintIvoiceLoad));
            this.panel1 = new System.Windows.Forms.Panel();
            this.cb_shipingpoint = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tab_Release = new System.Windows.Forms.TabPage();
            this.bt_inputshipment = new System.Windows.Forms.Button();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.lbshipmentNo = new System.Windows.Forms.Label();
            this.lb_shipmentNo = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btprintLoad = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGRdetailInvoiceOfSM = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tab_Release.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGRdetailInvoiceOfSM)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.cb_shipingpoint);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(8, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1334, 699);
            this.panel1.TabIndex = 0;
            // 
            // cb_shipingpoint
            // 
            this.cb_shipingpoint.FormattingEnabled = true;
            this.cb_shipingpoint.Location = new System.Drawing.Point(1113, 18);
            this.cb_shipingpoint.Name = "cb_shipingpoint";
            this.cb_shipingpoint.Size = new System.Drawing.Size(115, 24);
            this.cb_shipingpoint.TabIndex = 96;
            this.cb_shipingpoint.SelectedIndexChanged += new System.EventHandler(this.cb_shipingpoint_SelectedIndexChanged);
            this.cb_shipingpoint.SelectedValueChanged += new System.EventHandler(this.cb_shipingpoint_SelectedValueChanged);
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(1003, 21);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(104, 20);
            this.label11.TabIndex = 95;
            this.label11.Text = "Shipping Point";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tab_Release);
            this.tabControl1.Location = new System.Drawing.Point(8, 34);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1323, 662);
            this.tabControl1.TabIndex = 11;
            this.tabControl1.TabStop = false;
            // 
            // tab_Release
            // 
            this.tab_Release.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tab_Release.Controls.Add(this.bt_inputshipment);
            this.tab_Release.Controls.Add(this.pictureBox7);
            this.tab_Release.Controls.Add(this.lbshipmentNo);
            this.tab_Release.Controls.Add(this.lb_shipmentNo);
            this.tab_Release.Controls.Add(this.label3);
            this.tab_Release.Controls.Add(this.btprintLoad);
            this.tab_Release.Controls.Add(this.label8);
            this.tab_Release.Controls.Add(this.label5);
            this.tab_Release.Controls.Add(this.dataGRdetailInvoiceOfSM);
            this.tab_Release.Location = new System.Drawing.Point(4, 25);
            this.tab_Release.Name = "tab_Release";
            this.tab_Release.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Release.Size = new System.Drawing.Size(1315, 633);
            this.tab_Release.TabIndex = 0;
            this.tab_Release.Text = "Shipment";
            this.tab_Release.UseVisualStyleBackColor = true;
            this.tab_Release.Click += new System.EventHandler(this.tab_Release_Click);
            // 
            // bt_inputshipment
            // 
            this.bt_inputshipment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_inputshipment.ForeColor = System.Drawing.Color.Red;
            this.bt_inputshipment.Location = new System.Drawing.Point(621, 28);
            this.bt_inputshipment.Name = "bt_inputshipment";
            this.bt_inputshipment.Size = new System.Drawing.Size(24, 22);
            this.bt_inputshipment.TabIndex = 106;
            this.bt_inputshipment.Text = ">>";
            this.bt_inputshipment.UseVisualStyleBackColor = true;
            this.bt_inputshipment.Click += new System.EventHandler(this.bt_inputshipment_Click);
            // 
            // pictureBox7
            // 
            this.pictureBox7.ErrorImage = global::BCP.Properties.Resources.giphy__1_;
            this.pictureBox7.Image = global::BCP.Properties.Resources.giphy__1_;
            this.pictureBox7.InitialImage = global::BCP.Properties.Resources.giphy__1_;
            this.pictureBox7.Location = new System.Drawing.Point(10, 17);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(68, 63);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 105;
            this.pictureBox7.TabStop = false;
            // 
            // lbshipmentNo
            // 
            this.lbshipmentNo.AutoSize = true;
            this.lbshipmentNo.Font = new System.Drawing.Font("VNI-Helve-Condense", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbshipmentNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lbshipmentNo.Location = new System.Drawing.Point(651, 25);
            this.lbshipmentNo.Name = "lbshipmentNo";
            this.lbshipmentNo.Size = new System.Drawing.Size(22, 26);
            this.lbshipmentNo.TabIndex = 2;
            this.lbshipmentNo.Text = "0";
            // 
            // lb_shipmentNo
            // 
            this.lb_shipmentNo.AutoSize = true;
            this.lb_shipmentNo.Font = new System.Drawing.Font("VNI-Helve-Condense", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_shipmentNo.ForeColor = System.Drawing.Color.Red;
            this.lb_shipmentNo.Location = new System.Drawing.Point(-556, 36);
            this.lb_shipmentNo.Name = "lb_shipmentNo";
            this.lb_shipmentNo.Size = new System.Drawing.Size(16, 19);
            this.lb_shipmentNo.TabIndex = 101;
            this.lb_shipmentNo.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("VNI-Helve-Condense", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(-650, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 19);
            this.label3.TabIndex = 100;
            this.label3.Text = "Shipment No.";
            // 
            // btprintLoad
            // 
            this.btprintLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btprintLoad.ForeColor = System.Drawing.Color.Green;
            this.btprintLoad.Location = new System.Drawing.Point(813, 62);
            this.btprintLoad.Name = "btprintLoad";
            this.btprintLoad.Size = new System.Drawing.Size(128, 22);
            this.btprintLoad.TabIndex = 5;
            this.btprintLoad.Text = "Print Load";
            this.btprintLoad.UseVisualStyleBackColor = true;
            this.btprintLoad.Click += new System.EventHandler(this.btprintPallet_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("VNI-Helve-Condense", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(84, 52);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(308, 19);
            this.label8.TabIndex = 3;
            this.label8.Text = "Search then Double Click To Sellect and Print Invoice";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("VNI-Helve-Condense", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(496, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 19);
            this.label5.TabIndex = 82;
            this.label5.Text = "Input Shipment No.";
            // 
            // dataGRdetailInvoiceOfSM
            // 
            this.dataGRdetailInvoiceOfSM.AllowUserToAddRows = false;
            this.dataGRdetailInvoiceOfSM.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGRdetailInvoiceOfSM.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGRdetailInvoiceOfSM.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGRdetailInvoiceOfSM.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGRdetailInvoiceOfSM.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dataGRdetailInvoiceOfSM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGRdetailInvoiceOfSM.EnableHeadersVisualStyles = false;
            this.dataGRdetailInvoiceOfSM.Location = new System.Drawing.Point(10, 90);
            this.dataGRdetailInvoiceOfSM.Name = "dataGRdetailInvoiceOfSM";
            this.dataGRdetailInvoiceOfSM.ReadOnly = true;
            this.dataGRdetailInvoiceOfSM.Size = new System.Drawing.Size(1303, 533);
            this.dataGRdetailInvoiceOfSM.TabIndex = 81;
            this.dataGRdetailInvoiceOfSM.AllowUserToOrderColumnsChanged += new System.EventHandler(this.dataGRDetailshipment_AllowUserToOrderColumnsChanged);
            this.dataGRdetailInvoiceOfSM.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGRdetailInvoiceOfSM_CellContentClick);
            this.dataGRdetailInvoiceOfSM.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGRdetailInvoiceOfSM_CellDoubleClick);
            this.dataGRdetailInvoiceOfSM.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dataGRDetailshipment_RowsRemoved);
            this.dataGRdetailInvoiceOfSM.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGRDetailshipment_UserDeletedRow);
            // 
            // BCPPrintIvoiceLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1354, 712);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BCPPrintIvoiceLoad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DataCapture";
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tab_Release.ResumeLayout(false);
            this.tab_Release.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGRdetailInvoiceOfSM)).EndInit();
            this.ResumeLayout(false);

        }

    

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cb_shipingpoint;
        private System.Windows.Forms.Label label11;
        public System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tab_Release;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.DataGridView dataGRdetailInvoiceOfSM;
        private System.Windows.Forms.Button btprintLoad;
        private System.Windows.Forms.Label lb_shipmentNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbshipmentNo;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Button bt_inputshipment;
    }
}