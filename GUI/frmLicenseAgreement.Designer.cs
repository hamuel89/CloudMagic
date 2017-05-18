namespace CloudMagic.GUI
{
    partial class frmLicenseAgreement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLicenseAgreement));
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.cmdDecline = new System.Windows.Forms.Button();
            this.cmdAgree = new System.Windows.Forms.Button();
            this.cmdRead = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(5, 5);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(776, 380);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // cmdDecline
            // 
            this.cmdDecline.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdDecline.Location = new System.Drawing.Point(706, 391);
            this.cmdDecline.Name = "cmdDecline";
            this.cmdDecline.Size = new System.Drawing.Size(75, 25);
            this.cmdDecline.TabIndex = 1;
            this.cmdDecline.Text = "I &Decline";
            this.cmdDecline.UseVisualStyleBackColor = true;
            this.cmdDecline.Click += new System.EventHandler(this.cmdDecline_Click);
            // 
            // cmdAgree
            // 
            this.cmdAgree.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdAgree.Location = new System.Drawing.Point(625, 391);
            this.cmdAgree.Name = "cmdAgree";
            this.cmdAgree.Size = new System.Drawing.Size(75, 25);
            this.cmdAgree.TabIndex = 2;
            this.cmdAgree.Text = "I &Agree";
            this.cmdAgree.UseVisualStyleBackColor = true;
            this.cmdAgree.Click += new System.EventHandler(this.cmdAgree_Click);
            // 
            // cmdRead
            // 
            this.cmdRead.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdRead.Location = new System.Drawing.Point(544, 391);
            this.cmdRead.Name = "cmdRead";
            this.cmdRead.Size = new System.Drawing.Size(75, 25);
            this.cmdRead.TabIndex = 3;
            this.cmdRead.Text = "&Read";
            this.cmdRead.UseVisualStyleBackColor = true;
            this.cmdRead.Click += new System.EventHandler(this.cmdRead_Click);
            // 
            // frmLicenseAgreement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 421);
            this.Controls.Add(this.cmdRead);
            this.Controls.Add(this.cmdAgree);
            this.Controls.Add(this.cmdDecline);
            this.Controls.Add(this.richTextBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLicenseAgreement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "License Agreement";
            this.Load += new System.EventHandler(this.frmLicenseAgreement_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button cmdDecline;
        private System.Windows.Forms.Button cmdAgree;
        private System.Windows.Forms.Button cmdRead;
    }
}