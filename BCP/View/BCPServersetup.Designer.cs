namespace BCP.View
{
    partial class BCPServersetup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BCPServersetup));
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtmdbfile = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtprovider = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.txtmdbfile);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtprovider);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(427, 141);
            this.panel1.TabIndex = 0;
            // 
            // txtmdbfile
            // 
            this.txtmdbfile.Location = new System.Drawing.Point(87, 59);
            this.txtmdbfile.Name = "txtmdbfile";
            this.txtmdbfile.Size = new System.Drawing.Size(251, 20);
            this.txtmdbfile.TabIndex = 6;
            this.txtmdbfile.Text = "C:\\Users\\mtruong\\Desktop\\BCP\\Sapprint2003.mdb";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Mdb File";
            // 
            // txtprovider
            // 
            this.txtprovider.Location = new System.Drawing.Point(87, 28);
            this.txtprovider.Name = "txtprovider";
            this.txtprovider.Size = new System.Drawing.Size(251, 20);
            this.txtprovider.TabIndex = 2;
            this.txtprovider.Text = "Microsoft.Jet.OLEDB.4.0";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(194, 103);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 25);
            this.button1.TabIndex = 1;
            this.button1.Text = "Thiết lập";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Provider";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(358, 28);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(44, 20);
            this.button2.TabIndex = 7;
            this.button2.Text = ">>";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(358, 58);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(44, 20);
            this.button3.TabIndex = 8;
            this.button3.Text = ">>";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Serversetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 148);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Serversetup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Server Setup";
            this.Deactivate += new System.EventHandler(this.Serversetup_Deactivate);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtmdbfile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtprovider;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}