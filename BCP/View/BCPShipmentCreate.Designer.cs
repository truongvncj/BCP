using System;
using System.Linq;

namespace BCP.View
{
    partial class BCPShipmentCreate
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BCPShipmentCreate));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lb_shipmentNo = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_shipingpoint = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tab_Release = new System.Windows.Forms.TabPage();
            this.tbnewshipment = new System.Windows.Forms.Button();
            this.btdeleteshipment = new System.Windows.Forms.Button();
            this.btprintPallet = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGRProductshipment = new System.Windows.Forms.DataGridView();
            this.txtcustcodefind = new System.Windows.Forms.TextBox();
            this.txtnamefind = new System.Windows.Forms.TextBox();
            this.txtcodefind = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGRDetailshipment = new System.Windows.Forms.DataGridView();
            this.gripOrdertomakeload = new System.Windows.Forms.DataGridView();
            this.btcreateshipment = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tab_Release.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGRProductshipment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGRDetailshipment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gripOrdertomakeload)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.lb_shipmentNo);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cb_shipingpoint);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(8, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1334, 699);
            this.panel1.TabIndex = 0;
            // 
            // lb_shipmentNo
            // 
            this.lb_shipmentNo.AutoSize = true;
            this.lb_shipmentNo.Font = new System.Drawing.Font("VNI-Helve-Condense", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_shipmentNo.ForeColor = System.Drawing.Color.Red;
            this.lb_shipmentNo.Location = new System.Drawing.Point(976, 19);
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
            this.label3.Location = new System.Drawing.Point(882, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 19);
            this.label3.TabIndex = 100;
            this.label3.Text = "Shipment No.";
            // 
            // cb_shipingpoint
            // 
            this.cb_shipingpoint.FormattingEnabled = true;
            this.cb_shipingpoint.Location = new System.Drawing.Point(519, 14);
            this.cb_shipingpoint.Name = "cb_shipingpoint";
            this.cb_shipingpoint.Size = new System.Drawing.Size(103, 24);
            this.cb_shipingpoint.TabIndex = 96;
            this.cb_shipingpoint.SelectedIndexChanged += new System.EventHandler(this.cb_shipingpoint_SelectedIndexChanged);
            this.cb_shipingpoint.SelectedValueChanged += new System.EventHandler(this.cb_shipingpoint_SelectedValueChanged);
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(430, 17);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(83, 20);
            this.label11.TabIndex = 95;
            this.label11.Text = "Shipping Point";
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
            this.tab_Release.Controls.Add(this.tbnewshipment);
            this.tab_Release.Controls.Add(this.btdeleteshipment);
            this.tab_Release.Controls.Add(this.btprintPallet);
            this.tab_Release.Controls.Add(this.label1);
            this.tab_Release.Controls.Add(this.dataGRProductshipment);
            this.tab_Release.Controls.Add(this.txtcustcodefind);
            this.tab_Release.Controls.Add(this.txtnamefind);
            this.tab_Release.Controls.Add(this.txtcodefind);
            this.tab_Release.Controls.Add(this.label10);
            this.tab_Release.Controls.Add(this.label8);
            this.tab_Release.Controls.Add(this.label2);
            this.tab_Release.Controls.Add(this.label7);
            this.tab_Release.Controls.Add(this.label5);
            this.tab_Release.Controls.Add(this.dataGRDetailshipment);
            this.tab_Release.Controls.Add(this.gripOrdertomakeload);
            this.tab_Release.Controls.Add(this.btcreateshipment);
            this.tab_Release.Location = new System.Drawing.Point(4, 25);
            this.tab_Release.Name = "tab_Release";
            this.tab_Release.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Release.Size = new System.Drawing.Size(1315, 633);
            this.tab_Release.TabIndex = 0;
            this.tab_Release.Text = "Shipment";
            this.tab_Release.UseVisualStyleBackColor = true;
            this.tab_Release.Click += new System.EventHandler(this.tab_Release_Click);
            // 
            // tbnewshipment
            // 
            this.tbnewshipment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbnewshipment.ForeColor = System.Drawing.Color.Red;
            this.tbnewshipment.Location = new System.Drawing.Point(749, 21);
            this.tbnewshipment.Name = "tbnewshipment";
            this.tbnewshipment.Size = new System.Drawing.Size(106, 22);
            this.tbnewshipment.TabIndex = 100;
            this.tbnewshipment.Text = "New Shipment";
            this.tbnewshipment.UseVisualStyleBackColor = true;
            this.tbnewshipment.Click += new System.EventHandler(this.tbnewshipment_Click);
            // 
            // btdeleteshipment
            // 
            this.btdeleteshipment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btdeleteshipment.ForeColor = System.Drawing.Color.Red;
            this.btdeleteshipment.Location = new System.Drawing.Point(861, 21);
            this.btdeleteshipment.Name = "btdeleteshipment";
            this.btdeleteshipment.Size = new System.Drawing.Size(106, 22);
            this.btdeleteshipment.TabIndex = 99;
            this.btdeleteshipment.Text = "Reject Shipment ";
            this.btdeleteshipment.UseVisualStyleBackColor = true;
            this.btdeleteshipment.Click += new System.EventHandler(this.button3_Click);
            // 
            // btprintPallet
            // 
            this.btprintPallet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btprintPallet.ForeColor = System.Drawing.Color.Green;
            this.btprintPallet.Location = new System.Drawing.Point(1011, 21);
            this.btprintPallet.Name = "btprintPallet";
            this.btprintPallet.Size = new System.Drawing.Size(180, 22);
            this.btprintPallet.TabIndex = 98;
            this.btprintPallet.Text = "View Shipment/ Print Pallet Ticket";
            this.btprintPallet.UseVisualStyleBackColor = true;
            this.btprintPallet.Click += new System.EventHandler(this.btprintPallet_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("VNI-Helve-Condense", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(755, 308);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 19);
            this.label1.TabIndex = 96;
            this.label1.Text = "Total product of Shipment";
            // 
            // dataGRProductshipment
            // 
            this.dataGRProductshipment.AllowUserToAddRows = false;
            this.dataGRProductshipment.AllowUserToDeleteRows = false;
            this.dataGRProductshipment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGRProductshipment.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGRProductshipment.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGRProductshipment.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGRProductshipment.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dataGRProductshipment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGRProductshipment.EnableHeadersVisualStyles = false;
            this.dataGRProductshipment.Location = new System.Drawing.Point(759, 330);
            this.dataGRProductshipment.Name = "dataGRProductshipment";
            this.dataGRProductshipment.ReadOnly = true;
            this.dataGRProductshipment.Size = new System.Drawing.Size(546, 293);
            this.dataGRProductshipment.TabIndex = 95;
            // 
            // txtcustcodefind
            // 
            this.txtcustcodefind.Location = new System.Drawing.Point(280, 33);
            this.txtcustcodefind.Name = "txtcustcodefind";
            this.txtcustcodefind.Size = new System.Drawing.Size(139, 23);
            this.txtcustcodefind.TabIndex = 94;
            this.txtcustcodefind.TextChanged += new System.EventHandler(this.txtcustcodefind_TextChanged);
            // 
            // txtnamefind
            // 
            this.txtnamefind.Location = new System.Drawing.Point(507, 33);
            this.txtnamefind.Name = "txtnamefind";
            this.txtnamefind.Size = new System.Drawing.Size(155, 23);
            this.txtnamefind.TabIndex = 88;
            this.txtnamefind.TextChanged += new System.EventHandler(this.txtnamefind_TextChanged);
            // 
            // txtcodefind
            // 
            this.txtcodefind.Location = new System.Drawing.Point(51, 33);
            this.txtcodefind.Name = "txtcodefind";
            this.txtcodefind.Size = new System.Drawing.Size(115, 23);
            this.txtcodefind.TabIndex = 86;
            this.txtcodefind.TextChanged += new System.EventHandler(this.txtcodefind_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("VNI-Helve-Condense", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(209, 37);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 19);
            this.label10.TabIndex = 93;
            this.label10.Text = "Cust Code";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("VNI-Helve-Condense", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(6, 3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(208, 19);
            this.label8.TabIndex = 89;
            this.label8.Text = "Search then Double Click To Sellect";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("VNI-Helve-Condense", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(460, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 19);
            this.label2.TabIndex = 87;
            this.label2.Text = "Name";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("VNI-Helve-Condense", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(5, 37);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 19);
            this.label7.TabIndex = 85;
            this.label7.Text = "Order";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("VNI-Helve-Condense", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(758, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 19);
            this.label5.TabIndex = 82;
            this.label5.Text = "Shipment detail";
            // 
            // dataGRDetailshipment
            // 
            this.dataGRDetailshipment.AllowUserToAddRows = false;
            this.dataGRDetailshipment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGRDetailshipment.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGRDetailshipment.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGRDetailshipment.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGRDetailshipment.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dataGRDetailshipment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGRDetailshipment.EnableHeadersVisualStyles = false;
            this.dataGRDetailshipment.Location = new System.Drawing.Point(749, 68);
            this.dataGRDetailshipment.Name = "dataGRDetailshipment";
            this.dataGRDetailshipment.ReadOnly = true;
            this.dataGRDetailshipment.Size = new System.Drawing.Size(556, 227);
            this.dataGRDetailshipment.TabIndex = 81;
            this.dataGRDetailshipment.AllowUserToOrderColumnsChanged += new System.EventHandler(this.dataGRDetailshipment_AllowUserToOrderColumnsChanged);
            this.dataGRDetailshipment.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dataGRDetailshipment_RowsRemoved);
            this.dataGRDetailshipment.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGRDetailshipment_UserDeletedRow);
            // 
            // gripOrdertomakeload
            // 
            this.gripOrdertomakeload.AllowUserToResizeColumns = false;
            this.gripOrdertomakeload.AllowUserToResizeRows = false;
            this.gripOrdertomakeload.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gripOrdertomakeload.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gripOrdertomakeload.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gripOrdertomakeload.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.gripOrdertomakeload.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gripOrdertomakeload.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gripOrdertomakeload.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gripOrdertomakeload.DefaultCellStyle = dataGridViewCellStyle2;
            this.gripOrdertomakeload.EnableHeadersVisualStyles = false;
            this.gripOrdertomakeload.GridColor = System.Drawing.Color.Black;
            this.gripOrdertomakeload.Location = new System.Drawing.Point(11, 70);
            this.gripOrdertomakeload.Name = "gripOrdertomakeload";
            this.gripOrdertomakeload.ReadOnly = true;
            this.gripOrdertomakeload.Size = new System.Drawing.Size(696, 555);
            this.gripOrdertomakeload.TabIndex = 13;
            this.gripOrdertomakeload.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridOrderUnrelease_CellContentClick);
            this.gripOrdertomakeload.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridOrderUnrelease_CellDoubleClick);
            // 
            // btcreateshipment
            // 
            this.btcreateshipment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btcreateshipment.ForeColor = System.Drawing.Color.Red;
            this.btcreateshipment.Location = new System.Drawing.Point(1197, 21);
            this.btcreateshipment.Name = "btcreateshipment";
            this.btcreateshipment.Size = new System.Drawing.Size(106, 22);
            this.btcreateshipment.TabIndex = 76;
            this.btcreateshipment.Text = "Create Shipment";
            this.btcreateshipment.UseVisualStyleBackColor = true;
            this.btcreateshipment.Click += new System.EventHandler(this.button6_Click);
            // 
            // BCPShipmentCreate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1354, 712);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BCPShipmentCreate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create Shipment ";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tab_Release.ResumeLayout(false);
            this.tab_Release.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGRProductshipment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGRDetailshipment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gripOrdertomakeload)).EndInit();
            this.ResumeLayout(false);

        }

    

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cb_shipingpoint;
        private System.Windows.Forms.Label label11;
        public System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tab_Release;
        private System.Windows.Forms.TextBox txtcustcodefind;
        private System.Windows.Forms.TextBox txtnamefind;
        private System.Windows.Forms.TextBox txtcodefind;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.DataGridView dataGRDetailshipment;
        public System.Windows.Forms.DataGridView gripOrdertomakeload;
        private System.Windows.Forms.Button btcreateshipment;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.DataGridView dataGRProductshipment;
        private System.Windows.Forms.Button btdeleteshipment;
        private System.Windows.Forms.Button btprintPallet;
        private System.Windows.Forms.Label lb_shipmentNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button tbnewshipment;
    }
}