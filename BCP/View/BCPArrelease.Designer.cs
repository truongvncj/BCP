using System;
using System.Linq;

namespace BCP.View
{
    partial class BCPArrelease
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BCPArrelease));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tab_Release = new System.Windows.Forms.TabPage();
            this.txtcustcode = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtnamefind = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtcodefind = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.datagrlisttoRelease = new System.Windows.Forms.DataGridView();
            this.dataGridOrderUnrelease = new System.Windows.Forms.DataGridView();
            this.button6 = new System.Windows.Forms.Button();
            this.tab_Unrelease = new System.Windows.Forms.TabPage();
            this.txtcodef = new System.Windows.Forms.TextBox();
            this.lbco = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtnameunrelease = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txcodeunrelease = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.datagrlisttoUNRelease = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.btUnrelease = new System.Windows.Forms.Button();
            this.dataGridunrelease = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tab_Release.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagrlisttoRelease)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridOrderUnrelease)).BeginInit();
            this.tab_Unrelease.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagrlisttoUNRelease)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridunrelease)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(8, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(980, 680);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("VNI-Helve-Condense", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(11, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 19);
            this.label1.TabIndex = 12;
            this.label1.Text = "Select odears and Release/ Unrelease";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tab_Release);
            this.tabControl1.Controls.Add(this.tab_Unrelease);
            this.tabControl1.Location = new System.Drawing.Point(8, 49);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(969, 589);
            this.tabControl1.TabIndex = 11;
            this.tabControl1.TabStop = false;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tab_Release
            // 
            this.tab_Release.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tab_Release.Controls.Add(this.txtcustcode);
            this.tab_Release.Controls.Add(this.label10);
            this.tab_Release.Controls.Add(this.label8);
            this.tab_Release.Controls.Add(this.txtnamefind);
            this.tab_Release.Controls.Add(this.label2);
            this.tab_Release.Controls.Add(this.txtcodefind);
            this.tab_Release.Controls.Add(this.label7);
            this.tab_Release.Controls.Add(this.label5);
            this.tab_Release.Controls.Add(this.datagrlisttoRelease);
            this.tab_Release.Controls.Add(this.dataGridOrderUnrelease);
            this.tab_Release.Controls.Add(this.button6);
            this.tab_Release.Location = new System.Drawing.Point(4, 25);
            this.tab_Release.Name = "tab_Release";
            this.tab_Release.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Release.Size = new System.Drawing.Size(961, 560);
            this.tab_Release.TabIndex = 0;
            this.tab_Release.Text = "Release";
            this.tab_Release.UseVisualStyleBackColor = true;
            // 
            // txtcustcode
            // 
            this.txtcustcode.Location = new System.Drawing.Point(493, 12);
            this.txtcustcode.Name = "txtcustcode";
            this.txtcustcode.Size = new System.Drawing.Size(115, 23);
            this.txtcustcode.TabIndex = 94;
            this.txtcustcode.TextChanged += new System.EventHandler(this.txtcustcode_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("VNI-Helve-Condense", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(422, 14);
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
            this.label8.Location = new System.Drawing.Point(815, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(136, 19);
            this.label8.TabIndex = 89;
            this.label8.Text = "Double Click To Sellect";
            // 
            // txtnamefind
            // 
            this.txtnamefind.Location = new System.Drawing.Point(659, 12);
            this.txtnamefind.Name = "txtnamefind";
            this.txtnamefind.Size = new System.Drawing.Size(115, 23);
            this.txtnamefind.TabIndex = 88;
            this.txtnamefind.TextChanged += new System.EventHandler(this.txtnamefind_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("VNI-Helve-Condense", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(614, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 19);
            this.label2.TabIndex = 87;
            this.label2.Text = "Name";
            // 
            // txtcodefind
            // 
            this.txtcodefind.Location = new System.Drawing.Point(301, 12);
            this.txtcodefind.Name = "txtcodefind";
            this.txtcodefind.Size = new System.Drawing.Size(115, 23);
            this.txtcodefind.TabIndex = 86;
            this.txtcodefind.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("VNI-Helve-Condense", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(201, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 19);
            this.label7.TabIndex = 85;
            this.label7.Text = "Search by Order";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("VNI-Helve-Condense", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(49, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 19);
            this.label5.TabIndex = 82;
            this.label5.Text = "List Order to Release";
            // 
            // datagrlisttoRelease
            // 
            this.datagrlisttoRelease.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.datagrlisttoRelease.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.datagrlisttoRelease.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.datagrlisttoRelease.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.datagrlisttoRelease.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagrlisttoRelease.EnableHeadersVisualStyles = false;
            this.datagrlisttoRelease.Location = new System.Drawing.Point(6, 81);
            this.datagrlisttoRelease.Name = "datagrlisttoRelease";
            this.datagrlisttoRelease.Size = new System.Drawing.Size(180, 432);
            this.datagrlisttoRelease.TabIndex = 81;
            // 
            // dataGridOrderUnrelease
            // 
            this.dataGridOrderUnrelease.AllowUserToResizeColumns = false;
            this.dataGridOrderUnrelease.AllowUserToResizeRows = false;
            this.dataGridOrderUnrelease.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridOrderUnrelease.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridOrderUnrelease.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridOrderUnrelease.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGridOrderUnrelease.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridOrderUnrelease.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridOrderUnrelease.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridOrderUnrelease.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridOrderUnrelease.EnableHeadersVisualStyles = false;
            this.dataGridOrderUnrelease.GridColor = System.Drawing.Color.Black;
            this.dataGridOrderUnrelease.Location = new System.Drawing.Point(205, 38);
            this.dataGridOrderUnrelease.Name = "dataGridOrderUnrelease";
            this.dataGridOrderUnrelease.ReadOnly = true;
            this.dataGridOrderUnrelease.Size = new System.Drawing.Size(751, 511);
            this.dataGridOrderUnrelease.TabIndex = 13;
            this.dataGridOrderUnrelease.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridOrderUnrelease_CellContentClick);
            this.dataGridOrderUnrelease.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridOrderUnrelease_CellDoubleClick);
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.Color.Red;
            this.button6.Location = new System.Drawing.Point(94, 14);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(82, 22);
            this.button6.TabIndex = 76;
            this.button6.Text = "Release";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // tab_Unrelease
            // 
            this.tab_Unrelease.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tab_Unrelease.Controls.Add(this.txtcodef);
            this.tab_Unrelease.Controls.Add(this.lbco);
            this.tab_Unrelease.Controls.Add(this.label9);
            this.tab_Unrelease.Controls.Add(this.txtnameunrelease);
            this.tab_Unrelease.Controls.Add(this.label6);
            this.tab_Unrelease.Controls.Add(this.txcodeunrelease);
            this.tab_Unrelease.Controls.Add(this.label4);
            this.tab_Unrelease.Controls.Add(this.datagrlisttoUNRelease);
            this.tab_Unrelease.Controls.Add(this.label3);
            this.tab_Unrelease.Controls.Add(this.btUnrelease);
            this.tab_Unrelease.Controls.Add(this.dataGridunrelease);
            this.tab_Unrelease.Location = new System.Drawing.Point(4, 25);
            this.tab_Unrelease.Name = "tab_Unrelease";
            this.tab_Unrelease.Size = new System.Drawing.Size(961, 560);
            this.tab_Unrelease.TabIndex = 2;
            this.tab_Unrelease.Text = "Unrelease";
            this.tab_Unrelease.UseVisualStyleBackColor = true;
            // 
            // txtcodef
            // 
            this.txtcodef.Location = new System.Drawing.Point(505, 13);
            this.txtcodef.Name = "txtcodef";
            this.txtcodef.Size = new System.Drawing.Size(115, 23);
            this.txtcodef.TabIndex = 92;
            this.txtcodef.TextChanged += new System.EventHandler(this.txtcodef_TextChanged);
            // 
            // lbco
            // 
            this.lbco.AutoSize = true;
            this.lbco.Font = new System.Drawing.Font("VNI-Helve-Condense", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbco.ForeColor = System.Drawing.Color.Red;
            this.lbco.Location = new System.Drawing.Point(434, 16);
            this.lbco.Name = "lbco";
            this.lbco.Size = new System.Drawing.Size(65, 19);
            this.lbco.TabIndex = 91;
            this.lbco.Text = "Cust Code";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("VNI-Helve-Condense", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(818, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(136, 19);
            this.label9.TabIndex = 90;
            this.label9.Text = "Double Click To Sellect";
            // 
            // txtnameunrelease
            // 
            this.txtnameunrelease.Location = new System.Drawing.Point(697, 13);
            this.txtnameunrelease.Name = "txtnameunrelease";
            this.txtnameunrelease.Size = new System.Drawing.Size(115, 23);
            this.txtnameunrelease.TabIndex = 84;
            this.txtnameunrelease.TextChanged += new System.EventHandler(this.txtnameunrelease_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("VNI-Helve-Condense", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(650, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 19);
            this.label6.TabIndex = 83;
            this.label6.Text = "Name";
            // 
            // txcodeunrelease
            // 
            this.txcodeunrelease.Location = new System.Drawing.Point(295, 12);
            this.txcodeunrelease.Name = "txcodeunrelease";
            this.txcodeunrelease.Size = new System.Drawing.Size(115, 23);
            this.txcodeunrelease.TabIndex = 81;
            this.txcodeunrelease.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("VNI-Helve-Condense", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(31, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 19);
            this.label4.TabIndex = 80;
            this.label4.Text = "List Order to Unrelease";
            // 
            // datagrlisttoUNRelease
            // 
            this.datagrlisttoUNRelease.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.datagrlisttoUNRelease.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.datagrlisttoUNRelease.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.datagrlisttoUNRelease.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.datagrlisttoUNRelease.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagrlisttoUNRelease.EnableHeadersVisualStyles = false;
            this.datagrlisttoUNRelease.Location = new System.Drawing.Point(5, 97);
            this.datagrlisttoUNRelease.Name = "datagrlisttoUNRelease";
            this.datagrlisttoUNRelease.Size = new System.Drawing.Size(177, 415);
            this.datagrlisttoUNRelease.TabIndex = 79;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("VNI-Helve-Condense", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(192, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 19);
            this.label3.TabIndex = 78;
            this.label3.Text = "Search by Order";
            // 
            // btUnrelease
            // 
            this.btUnrelease.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btUnrelease.ForeColor = System.Drawing.Color.Red;
            this.btUnrelease.Location = new System.Drawing.Point(86, 14);
            this.btUnrelease.Name = "btUnrelease";
            this.btUnrelease.Size = new System.Drawing.Size(82, 22);
            this.btUnrelease.TabIndex = 77;
            this.btUnrelease.Text = "UnRelease";
            this.btUnrelease.UseVisualStyleBackColor = true;
            this.btUnrelease.Click += new System.EventHandler(this.btUnrelease_Click);
            // 
            // dataGridunrelease
            // 
            this.dataGridunrelease.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridunrelease.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridunrelease.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridunrelease.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGridunrelease.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dataGridunrelease.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridunrelease.EnableHeadersVisualStyles = false;
            this.dataGridunrelease.Location = new System.Drawing.Point(196, 38);
            this.dataGridunrelease.Name = "dataGridunrelease";
            this.dataGridunrelease.ReadOnly = true;
            this.dataGridunrelease.Size = new System.Drawing.Size(758, 515);
            this.dataGridunrelease.TabIndex = 20;
            this.dataGridunrelease.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridunrelease_CellDoubleClick);
            // 
            // BCPArrelease
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 712);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BCPArrelease";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AR Release";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tab_Release.ResumeLayout(false);
            this.tab_Release.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagrlisttoRelease)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridOrderUnrelease)).EndInit();
            this.tab_Unrelease.ResumeLayout(false);
            this.tab_Unrelease.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagrlisttoUNRelease)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridunrelease)).EndInit();
            this.ResumeLayout(false);

        }

    

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TabPage tab_Release;
        private System.Windows.Forms.Button btUnrelease;
        private System.Windows.Forms.TabPage tab_Unrelease;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TabControl tabControl1;
        public System.Windows.Forms.DataGridView dataGridOrderUnrelease;
        public System.Windows.Forms.DataGridView dataGridunrelease;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.DataGridView datagrlisttoRelease;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.DataGridView datagrlisttoUNRelease;
        private System.Windows.Forms.TextBox txtnamefind;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtcodefind;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtnameunrelease;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txcodeunrelease;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtcodef;
        private System.Windows.Forms.Label lbco;
        private System.Windows.Forms.TextBox txtcustcode;
        private System.Windows.Forms.Label label10;
    }
}