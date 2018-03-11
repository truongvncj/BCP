namespace BCP.View
{
    partial class BCPViewdatatable
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BCPViewdatatable));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbcount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bt_exporttoex = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.btupdate = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btupdate);
            this.panel1.Controls.Add(this.lbcount);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.bt_exporttoex);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(3, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1216, 502);
            this.panel1.TabIndex = 0;
            // 
            // lbcount
            // 
            this.lbcount.AutoSize = true;
            this.lbcount.ForeColor = System.Drawing.Color.Red;
            this.lbcount.Location = new System.Drawing.Point(59, 478);
            this.lbcount.Name = "lbcount";
            this.lbcount.Size = new System.Drawing.Size(13, 13);
            this.lbcount.TabIndex = 20;
            this.lbcount.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 478);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Count:";
            // 
            // bt_exporttoex
            // 
            this.bt_exporttoex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_exporttoex.Location = new System.Drawing.Point(1119, 479);
            this.bt_exporttoex.Name = "bt_exporttoex";
            this.bt_exporttoex.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.bt_exporttoex.Size = new System.Drawing.Size(87, 20);
            this.bt_exporttoex.TabIndex = 18;
            this.bt_exporttoex.Text = "Export to Excel";
            this.bt_exporttoex.UseVisualStyleBackColor = true;
            this.bt_exporttoex.Click += new System.EventHandler(this.bt_exporttoex_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(4, 25);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1205, 448);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 1);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(1206, 21);
            this.label7.TabIndex = 17;
            this.label7.Text = "TABLEVIEW";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // btupdate
            // 
            this.btupdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btupdate.Location = new System.Drawing.Point(1012, 479);
            this.btupdate.Name = "btupdate";
            this.btupdate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btupdate.Size = new System.Drawing.Size(87, 20);
            this.btupdate.TabIndex = 21;
            this.btupdate.Text = "Update data";
            this.btupdate.UseVisualStyleBackColor = true;
            this.btupdate.Click += new System.EventHandler(this.btupdate_Click);
            // 
            // BCPViewdatatable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1221, 509);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BCPViewdatatable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BCP View Data";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button bt_exporttoex;
        private System.Windows.Forms.Label lbcount;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btupdate;
    }
}