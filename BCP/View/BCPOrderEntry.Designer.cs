using System;
using System.Linq;

namespace BCP.View
{
    partial class BCPOrderEntry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BCPOrderEntry));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lb_address = new System.Windows.Forms.Label();
            this.cb_shipingpoint = new System.Windows.Forms.ComboBox();
            this.cb_plant = new System.Windows.Forms.ComboBox();
            this.lbOrdernumber = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbshiptoname = new System.Windows.Forms.Label();
            this.lbsoltoname = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Ponumber = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtshipto = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtsoldto = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.bt_save = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tab_Orderdetail = new System.Windows.Forms.TabPage();
            this.dataGridetailorder = new System.Windows.Forms.DataGridView();
            this.tab_orderInformation = new System.Windows.Forms.TabPage();
            this.dataGriddiscountoninvoice = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.lbsalesRegion = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tab_Orderdetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridetailorder)).BeginInit();
            this.tab_orderInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGriddiscountoninvoice)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lbsalesRegion);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lb_address);
            this.groupBox1.Controls.Add(this.cb_shipingpoint);
            this.groupBox1.Controls.Add(this.cb_plant);
            this.groupBox1.Controls.Add(this.lbOrdernumber);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.lbshiptoname);
            this.groupBox1.Controls.Add(this.lbsoltoname);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.Ponumber);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtshipto);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtsoldto);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Location = new System.Drawing.Point(4, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(744, 184);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // lb_address
            // 
            this.lb_address.AutoSize = true;
            this.lb_address.Location = new System.Drawing.Point(219, 125);
            this.lb_address.Name = "lb_address";
            this.lb_address.Size = new System.Drawing.Size(12, 17);
            this.lb_address.TabIndex = 84;
            this.lb_address.Text = " ";
            // 
            // cb_shipingpoint
            // 
            this.cb_shipingpoint.FormattingEnabled = true;
            this.cb_shipingpoint.Location = new System.Drawing.Point(480, 33);
            this.cb_shipingpoint.Name = "cb_shipingpoint";
            this.cb_shipingpoint.Size = new System.Drawing.Size(103, 24);
            this.cb_shipingpoint.TabIndex = 83;
            this.cb_shipingpoint.SelectedValueChanged += new System.EventHandler(this.cb_shipingpoint_SelectedValueChanged);
            // 
            // cb_plant
            // 
            this.cb_plant.FormattingEnabled = true;
            this.cb_plant.Location = new System.Drawing.Point(300, 33);
            this.cb_plant.Name = "cb_plant";
            this.cb_plant.Size = new System.Drawing.Size(85, 24);
            this.cb_plant.TabIndex = 82;
            this.cb_plant.SelectedValueChanged += new System.EventHandler(this.cb_plant_SelectedValueChanged);
            // 
            // lbOrdernumber
            // 
            this.lbOrdernumber.AutoSize = true;
            this.lbOrdernumber.ForeColor = System.Drawing.Color.Red;
            this.lbOrdernumber.Location = new System.Drawing.Point(44, 0);
            this.lbOrdernumber.Name = "lbOrdernumber";
            this.lbOrdernumber.Size = new System.Drawing.Size(16, 17);
            this.lbOrdernumber.TabIndex = 81;
            this.lbOrdernumber.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 17);
            this.label1.TabIndex = 80;
            this.label1.Text = "No.";
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(391, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 20);
            this.label7.TabIndex = 77;
            this.label7.Text = "Shipping Point";
            // 
            // lbshiptoname
            // 
            this.lbshiptoname.AutoSize = true;
            this.lbshiptoname.Location = new System.Drawing.Point(253, 105);
            this.lbshiptoname.Name = "lbshiptoname";
            this.lbshiptoname.Size = new System.Drawing.Size(12, 17);
            this.lbshiptoname.TabIndex = 75;
            this.lbshiptoname.Text = " ";
            // 
            // lbsoltoname
            // 
            this.lbsoltoname.AutoSize = true;
            this.lbsoltoname.Location = new System.Drawing.Point(253, 73);
            this.lbsoltoname.Name = "lbsoltoname";
            this.lbsoltoname.Size = new System.Drawing.Size(12, 17);
            this.lbsoltoname.TabIndex = 74;
            this.lbsoltoname.Text = " ";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(8, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 20);
            this.label3.TabIndex = 73;
            this.label3.Text = "PO";
            // 
            // Ponumber
            // 
            this.Ponumber.BackColor = System.Drawing.Color.White;
            this.Ponumber.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Ponumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ponumber.ForeColor = System.Drawing.Color.Black;
            this.Ponumber.Location = new System.Drawing.Point(109, 149);
            this.Ponumber.Name = "Ponumber";
            this.Ponumber.Size = new System.Drawing.Size(629, 23);
            this.Ponumber.TabIndex = 72;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.Red;
            this.button3.Location = new System.Drawing.Point(222, 100);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(24, 22);
            this.button3.TabIndex = 71;
            this.button3.Text = ">>";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Red;
            this.button2.Location = new System.Drawing.Point(222, 71);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(24, 22);
            this.button2.TabIndex = 70;
            this.button2.Text = ">>";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(9, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 19);
            this.label2.TabIndex = 40;
            this.label2.Text = "Ship To ";
            // 
            // txtshipto
            // 
            this.txtshipto.BackColor = System.Drawing.Color.White;
            this.txtshipto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtshipto.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtshipto.Enabled = false;
            this.txtshipto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtshipto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtshipto.Location = new System.Drawing.Point(109, 102);
            this.txtshipto.Name = "txtshipto";
            this.txtshipto.Size = new System.Drawing.Size(107, 20);
            this.txtshipto.TabIndex = 39;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.CalendarMonthBackground = System.Drawing.Color.White;
            this.dateTimePicker1.CalendarTitleBackColor = System.Drawing.Color.Blue;
            this.dateTimePicker1.CalendarTitleForeColor = System.Drawing.Color.Black;
            this.dateTimePicker1.CalendarTrailingForeColor = System.Drawing.Color.Black;
            this.dateTimePicker1.CustomFormat = "dd.MM.yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(112, 36);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(104, 23);
            this.dateTimePicker1.TabIndex = 4;
            this.dateTimePicker1.Value = new System.DateTime(2018, 3, 4, 0, 0, 0, 0);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(9, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 23);
            this.label5.TabIndex = 12;
            this.label5.Text = "Delivery date";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(9, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 19);
            this.label4.TabIndex = 8;
            this.label4.Text = "Sold To";
            // 
            // txtsoldto
            // 
            this.txtsoldto.BackColor = System.Drawing.Color.White;
            this.txtsoldto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtsoldto.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtsoldto.Enabled = false;
            this.txtsoldto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsoldto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtsoldto.Location = new System.Drawing.Point(109, 72);
            this.txtsoldto.Name = "txtsoldto";
            this.txtsoldto.Size = new System.Drawing.Size(107, 20);
            this.txtsoldto.TabIndex = 1;
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label17.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(222, 37);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(72, 20);
            this.label17.TabIndex = 30;
            this.label17.Text = "Plant";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.button7);
            this.panel1.Controls.Add(this.button6);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.bt_save);
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(8, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(762, 680);
            this.panel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(237, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 22);
            this.button1.TabIndex = 78;
            this.button1.Text = "Delete Orders";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.ForeColor = System.Drawing.Color.Red;
            this.button7.Location = new System.Drawing.Point(474, 15);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(96, 22);
            this.button7.TabIndex = 77;
            this.button7.Text = "Orders Reports";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.Color.Red;
            this.button6.Location = new System.Drawing.Point(11, 15);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(96, 22);
            this.button6.TabIndex = 76;
            this.button6.Text = "New Orders";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.Red;
            this.button5.Location = new System.Drawing.Point(353, 15);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(96, 22);
            this.button5.TabIndex = 75;
            this.button5.Text = "View Orders";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // bt_save
            // 
            this.bt_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_save.ForeColor = System.Drawing.Color.Red;
            this.bt_save.Location = new System.Drawing.Point(127, 15);
            this.bt_save.Name = "bt_save";
            this.bt_save.Size = new System.Drawing.Size(93, 22);
            this.bt_save.TabIndex = 74;
            this.bt_save.Text = "Save";
            this.bt_save.UseVisualStyleBackColor = true;
            this.bt_save.Click += new System.EventHandler(this.button4_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tab_Orderdetail);
            this.tabControl1.Controls.Add(this.tab_orderInformation);
            this.tabControl1.Location = new System.Drawing.Point(8, 257);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(751, 381);
            this.tabControl1.TabIndex = 11;
            this.tabControl1.TabStop = false;
            // 
            // tab_Orderdetail
            // 
            this.tab_Orderdetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tab_Orderdetail.Controls.Add(this.dataGridetailorder);
            this.tab_Orderdetail.Location = new System.Drawing.Point(4, 25);
            this.tab_Orderdetail.Name = "tab_Orderdetail";
            this.tab_Orderdetail.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Orderdetail.Size = new System.Drawing.Size(743, 352);
            this.tab_Orderdetail.TabIndex = 0;
            this.tab_Orderdetail.Text = "Orders Detail";
            this.tab_Orderdetail.UseVisualStyleBackColor = true;
            // 
            // dataGridetailorder
            // 
            this.dataGridetailorder.AllowUserToResizeColumns = false;
            this.dataGridetailorder.AllowUserToResizeRows = false;
            this.dataGridetailorder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridetailorder.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridetailorder.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridetailorder.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridetailorder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridetailorder.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridetailorder.EnableHeadersVisualStyles = false;
            this.dataGridetailorder.GridColor = System.Drawing.Color.Black;
            this.dataGridetailorder.Location = new System.Drawing.Point(1, 1);
            this.dataGridetailorder.Name = "dataGridetailorder";
            this.dataGridetailorder.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridetailorder.Size = new System.Drawing.Size(732, 346);
            this.dataGridetailorder.TabIndex = 13;
            this.dataGridetailorder.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridProgramdetail_CellClick);
            this.dataGridetailorder.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridProgramdetail_CellContentClick);
            this.dataGridetailorder.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridProgramdetail_CellEndEdit);
            this.dataGridetailorder.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridProgramdetail_CellLeave);
            this.dataGridetailorder.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridProgramdetail_CellValueChanged);
            this.dataGridetailorder.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridProgramdetail_EditingControlShowing_1);
            // 
            // tab_orderInformation
            // 
            this.tab_orderInformation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tab_orderInformation.Controls.Add(this.dataGriddiscountoninvoice);
            this.tab_orderInformation.Location = new System.Drawing.Point(4, 25);
            this.tab_orderInformation.Name = "tab_orderInformation";
            this.tab_orderInformation.Size = new System.Drawing.Size(743, 352);
            this.tab_orderInformation.TabIndex = 2;
            this.tab_orderInformation.Text = "Orders Information";
            this.tab_orderInformation.UseVisualStyleBackColor = true;
            // 
            // dataGriddiscountoninvoice
            // 
            this.dataGriddiscountoninvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGriddiscountoninvoice.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGriddiscountoninvoice.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGriddiscountoninvoice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGriddiscountoninvoice.EnableHeadersVisualStyles = false;
            this.dataGriddiscountoninvoice.GridColor = System.Drawing.Color.Black;
            this.dataGriddiscountoninvoice.Location = new System.Drawing.Point(1, 1);
            this.dataGriddiscountoninvoice.Name = "dataGriddiscountoninvoice";
            this.dataGriddiscountoninvoice.Size = new System.Drawing.Size(735, 344);
            this.dataGriddiscountoninvoice.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(589, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 20);
            this.label6.TabIndex = 85;
            this.label6.Text = "Sales Region";
            // 
            // lbsalesRegion
            // 
            this.lbsalesRegion.AutoSize = true;
            this.lbsalesRegion.Location = new System.Drawing.Point(668, 36);
            this.lbsalesRegion.Name = "lbsalesRegion";
            this.lbsalesRegion.Size = new System.Drawing.Size(12, 17);
            this.lbsalesRegion.TabIndex = 86;
            this.lbsalesRegion.Text = " ";
            // 
            // BCPOrderEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 712);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BCPOrderEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Orders Entry";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tab_Orderdetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridetailorder)).EndInit();
            this.tab_orderInformation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGriddiscountoninvoice)).EndInit();
            this.ResumeLayout(false);

        }

    

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtsoldto;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Ponumber;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtshipto;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button bt_save;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tab_Orderdetail;
        private System.Windows.Forms.DataGridView dataGridetailorder;
        private System.Windows.Forms.TabPage tab_orderInformation;
        private System.Windows.Forms.DataGridView dataGriddiscountoninvoice;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbshiptoname;
        private System.Windows.Forms.Label lbsoltoname;
        private System.Windows.Forms.Label lbOrdernumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_shipingpoint;
        private System.Windows.Forms.ComboBox cb_plant;
        private System.Windows.Forms.Label lb_address;
        private System.Windows.Forms.Label lbsalesRegion;
        private System.Windows.Forms.Label label6;
    }
}