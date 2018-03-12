namespace BCP.View
{
    partial class BCPshipmentcreateoption
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BCPshipmentcreateoption));
            this.cb_onlycode = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbTranpostername = new System.Windows.Forms.ComboBox();
            this.cbPalletcode = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.cbPalletQuantity = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbTruckno = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cb_onlycode
            // 
            this.cb_onlycode.AutoSize = true;
            this.cb_onlycode.Location = new System.Drawing.Point(9, 19);
            this.cb_onlycode.Name = "cb_onlycode";
            this.cb_onlycode.Size = new System.Drawing.Size(109, 17);
            this.cb_onlycode.TabIndex = 1;
            this.cb_onlycode.Text = "Transporter name";
            this.cb_onlycode.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(228, 200);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 25);
            this.button1.TabIndex = 4;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbTruckno);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbPalletQuantity);
            this.groupBox1.Controls.Add(this.cbPalletcode);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.cbTranpostername);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.cb_onlycode);
            this.groupBox1.Location = new System.Drawing.Point(3, -1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(358, 241);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " ";
            // 
            // cbTranpostername
            // 
            this.cbTranpostername.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTranpostername.FormattingEnabled = true;
            this.cbTranpostername.Location = new System.Drawing.Point(124, 19);
            this.cbTranpostername.Name = "cbTranpostername";
            this.cbTranpostername.Size = new System.Drawing.Size(205, 21);
            this.cbTranpostername.TabIndex = 16;
            // 
            // cbPalletcode
            // 
            this.cbPalletcode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPalletcode.FormattingEnabled = true;
            this.cbPalletcode.Location = new System.Drawing.Point(123, 111);
            this.cbPalletcode.Name = "cbPalletcode";
            this.cbPalletcode.Size = new System.Drawing.Size(205, 21);
            this.cbPalletcode.TabIndex = 18;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(6, 88);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(111, 17);
            this.checkBox1.TabIndex = 17;
            this.checkBox1.Text = "Pallet of Shipment";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // cbPalletQuantity
            // 
            this.cbPalletQuantity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.cbPalletQuantity.FormattingEnabled = true;
            this.cbPalletQuantity.Location = new System.Drawing.Point(123, 138);
            this.cbPalletQuantity.Name = "cbPalletQuantity";
            this.cbPalletQuantity.Size = new System.Drawing.Size(86, 21);
            this.cbPalletQuantity.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Pallet code";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Quantity of pallet";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Truck No.";
            // 
            // cbTruckno
            // 
            this.cbTruckno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.cbTruckno.FormattingEnabled = true;
            this.cbTruckno.Location = new System.Drawing.Point(123, 46);
            this.cbTruckno.Name = "cbTruckno";
            this.cbTruckno.Size = new System.Drawing.Size(145, 21);
            this.cbTruckno.TabIndex = 22;
            // 
            // BCPshipmentcreateoption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 246);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BCPshipmentcreateoption";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Shipment create option";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.CheckBox cb_onlycode;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbTranpostername;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbTruckno;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbPalletQuantity;
        private System.Windows.Forms.ComboBox cbPalletcode;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}