namespace BCP.View
{
    partial class BCPDatepick
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BCPDatepick));
            this.fromdatePicker = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fromdatePicker
            // 
            this.fromdatePicker.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.fromdatePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fromdatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fromdatePicker.Location = new System.Drawing.Point(21, 23);
            this.fromdatePicker.Name = "fromdatePicker";
            this.fromdatePicker.Size = new System.Drawing.Size(103, 23);
            this.fromdatePicker.TabIndex = 0;
            this.fromdatePicker.Value = new System.DateTime(2016, 3, 6, 0, 0, 0, 0);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(164, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 21);
            this.button1.TabIndex = 1;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.fromdatePicker);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(269, 73);
            this.panel1.TabIndex = 5;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // BCPDatepick
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 87);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BCPDatepick";
            this.Text = "Picker Date";
            this.Load += new System.EventHandler(this.Datepick_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DateTimePicker fromdatePicker;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
    }
}