namespace BCP.View
{
    partial class BCPCuscodeandateselect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BCPCuscodeandateselect));
            this.cb_onlycode = new System.Windows.Forms.CheckBox();
            this.cb_fromcodetocode = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cb_customercode = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cb_onlycode
            // 
            this.cb_onlycode.AutoSize = true;
            this.cb_onlycode.Location = new System.Drawing.Point(2, 21);
            this.cb_onlycode.Name = "cb_onlycode";
            this.cb_onlycode.Size = new System.Drawing.Size(98, 17);
            this.cb_onlycode.TabIndex = 1;
            this.cb_onlycode.Text = "Customer Code";
            this.cb_onlycode.UseVisualStyleBackColor = true;
            // 
            // cb_fromcodetocode
            // 
            this.cb_fromcodetocode.AutoSize = true;
            this.cb_fromcodetocode.Location = new System.Drawing.Point(2, 62);
            this.cb_fromcodetocode.Name = "cb_fromcodetocode";
            this.cb_fromcodetocode.Size = new System.Drawing.Size(89, 17);
            this.cb_fromcodetocode.TabIndex = 2;
            this.cb_fromcodetocode.Text = "Price on date";
            this.cb_fromcodetocode.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(254, 115);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 25);
            this.button1.TabIndex = 4;
            this.button1.Text = "Thực hiện";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cb_customercode
            // 
            this.cb_customercode.DropDownWidth = 500;
            this.cb_customercode.FormattingEnabled = true;
            this.cb_customercode.Location = new System.Drawing.Point(101, 21);
            this.cb_customercode.Name = "cb_customercode";
            this.cb_customercode.Size = new System.Drawing.Size(279, 21);
            this.cb_customercode.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.cb_customercode);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.cb_fromcodetocode);
            this.groupBox1.Controls.Add(this.cb_onlycode);
            this.groupBox1.Location = new System.Drawing.Point(3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(388, 161);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " ";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(101, 62);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(128, 20);
            this.dateTimePicker1.TabIndex = 7;
            // 
            // BCPCuscodeandateselect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 165);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BCPCuscodeandateselect";
            this.Text = "Select Custcode and Date ";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.CheckBox cb_onlycode;
        private System.Windows.Forms.CheckBox cb_fromcodetocode;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cb_customercode;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}