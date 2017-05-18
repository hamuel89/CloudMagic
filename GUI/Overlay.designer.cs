namespace CloudMagic.GUI
{
    partial class Overlay
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
            this.RotationMode = new CloudMagic.GUI.ChromeLabel();
            this.Cooldowns = new CloudMagic.GUI.ChromeLabel();
            this.Status = new CloudMagic.GUI.ChromeLabel();
            this.SuspendLayout();
            // 
            // RotationMode
            // 
            this.RotationMode.BackColor = System.Drawing.Color.WhiteSmoke;
            this.RotationMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.RotationMode.ForeColor = System.Drawing.Color.DarkGreen;
            this.RotationMode.Location = new System.Drawing.Point(215, 9);
            this.RotationMode.Name = "RotationMode";
            this.RotationMode.Size = new System.Drawing.Size(128, 24);
            this.RotationMode.TabIndex = 2;
            this.RotationMode.Text = "Single-Target";
            this.RotationMode.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            // 
            // Cooldowns
            // 
            this.Cooldowns.BackColor = System.Drawing.Color.Black;
            this.Cooldowns.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.Cooldowns.ForeColor = System.Drawing.Color.GreenYellow;
            this.Cooldowns.Location = new System.Drawing.Point(67, 9);
            this.Cooldowns.Name = "Cooldowns";
            this.Cooldowns.Size = new System.Drawing.Size(167, 24);
            this.Cooldowns.TabIndex = 1;
            this.Cooldowns.Text = "Cooldowns [Off]";
            this.Cooldowns.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            // 
            // Status
            // 
            this.Status.BackColor = System.Drawing.Color.Red;
            this.Status.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.Status.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Status.Location = new System.Drawing.Point(12, 9);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(49, 24);
            this.Status.TabIndex = 0;
            this.Status.Text = "OFF";
            this.Status.Click += new System.EventHandler(this.chromeLabel1_Click);
            this.Status.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            // 
            // Overlay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(354, 43);
            this.Controls.Add(this.RotationMode);
            this.Controls.Add(this.Cooldowns);
            this.Controls.Add(this.Status);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Overlay";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Overlay";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Black;
            this.Load += new System.EventHandler(this.Overlay_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ChromeLabel Status;
        private ChromeLabel Cooldowns;
        private ChromeLabel RotationMode;
    }
}