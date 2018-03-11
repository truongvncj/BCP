namespace BCP.View
{
    partial class BCPorderviewotiom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BCPorderviewotiom));
            this.cb_onlycode = new System.Windows.Forms.CheckBox();
            this.cb_fromcodetocode = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cb_createby = new System.Windows.Forms.ComboBox();
            this.date_toDate = new System.Windows.Forms.DateTimePicker();
            this.date_fromdate = new System.Windows.Forms.DateTimePicker();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cb_onlycode
            // 
            this.cb_onlycode.AutoSize = true;
            this.cb_onlycode.Location = new System.Drawing.Point(7, 118);
            this.cb_onlycode.Name = "cb_onlycode";
            this.cb_onlycode.Size = new System.Drawing.Size(119, 17);
            this.cb_onlycode.TabIndex = 1;
            this.cb_onlycode.Text = "Createby Username";
            this.cb_onlycode.UseVisualStyleBackColor = true;
            // 
            // cb_fromcodetocode
            // 
            this.cb_fromcodetocode.AutoSize = true;
            this.cb_fromcodetocode.Location = new System.Drawing.Point(7, 24);
            this.cb_fromcodetocode.Name = "cb_fromcodetocode";
            this.cb_fromcodetocode.Size = new System.Drawing.Size(123, 17);
            this.cb_fromcodetocode.TabIndex = 2;
            this.cb_fromcodetocode.Text = "From Date - To Date";
            this.cb_fromcodetocode.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(129, 206);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 25);
            this.button1.TabIndex = 4;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "From date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "To Date";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cb_createby);
            this.groupBox1.Controls.Add(this.date_toDate);
            this.groupBox1.Controls.Add(this.date_fromdate);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.cb_fromcodetocode);
            this.groupBox1.Controls.Add(this.cb_onlycode);
            this.groupBox1.Location = new System.Drawing.Point(3, -1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(243, 258);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " ";
            // 
            // cb_createby
            // 
            this.cb_createby.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.cb_createby.FormattingEnabled = true;
            this.cb_createby.Location = new System.Drawing.Point(24, 143);
            this.cb_createby.Name = "cb_createby";
            this.cb_createby.Size = new System.Drawing.Size(205, 21);
            this.cb_createby.TabIndex = 16;
            // 
            // date_toDate
            // 
            this.date_toDate.CustomFormat = "dd.MM.yyyy";
            this.date_toDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date_toDate.Location = new System.Drawing.Point(109, 80);
            this.date_toDate.Name = "date_toDate";
            this.date_toDate.Size = new System.Drawing.Size(120, 20);
            this.date_toDate.TabIndex = 15;
  //          this.date_toDate.ValueChanged += new System.EventHandler(this.date_toDate_ValueChanged);
            // 
            // date_fromdate
            // 
            this.date_fromdate.CustomFormat = "dd.MM.yyyy";
            this.date_fromdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date_fromdate.Location = new System.Drawing.Point(109, 52);
            this.date_fromdate.Name = "date_fromdate";
            this.date_fromdate.Size = new System.Drawing.Size(120, 20);
            this.date_fromdate.TabIndex = 14;
            // 
            // BCPorderviewotiom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(249, 261);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BCPorderviewotiom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn Option";
      //      this.Load += new System.EventHandler(this.BCPorderviewotiom_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.CheckBox cb_onlycode;
        private System.Windows.Forms.CheckBox cb_fromcodetocode;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker date_toDate;
        private System.Windows.Forms.DateTimePicker date_fromdate;
        private System.Windows.Forms.ComboBox cb_createby;
    }
}