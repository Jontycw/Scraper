namespace Scraper
{
    partial class Form1
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
            this.RunBtn = new System.Windows.Forms.Button();
            this.UrlTbx = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.OutputTa = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // RunBtn
            // 
            this.RunBtn.Location = new System.Drawing.Point(355, 183);
            this.RunBtn.Name = "RunBtn";
            this.RunBtn.Size = new System.Drawing.Size(75, 23);
            this.RunBtn.TabIndex = 0;
            this.RunBtn.Text = "Run";
            this.RunBtn.UseVisualStyleBackColor = true;
            this.RunBtn.Click += new System.EventHandler(this.RunBtn_Click);
            // 
            // UrlTbx
            // 
            this.UrlTbx.Location = new System.Drawing.Point(53, 15);
            this.UrlTbx.Name = "UrlTbx";
            this.UrlTbx.Size = new System.Drawing.Size(377, 20);
            this.UrlTbx.TabIndex = 1;

            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "URL";
            // 
            // OutputTa
            // 
            this.OutputTa.Location = new System.Drawing.Point(12, 50);
            this.OutputTa.Name = "OutputTa";
            this.OutputTa.Size = new System.Drawing.Size(418, 127);
            this.OutputTa.TabIndex = 3;
            this.OutputTa.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 218);
            this.Controls.Add(this.OutputTa);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UrlTbx);
            this.Controls.Add(this.RunBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button RunBtn;
        private System.Windows.Forms.TextBox UrlTbx;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox OutputTa;
    }
}

