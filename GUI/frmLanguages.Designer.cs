namespace CloudMagic.GUI.GUI
{
    partial class frmLanguages
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLanguages));
            this.dgvLanguages = new System.Windows.Forms.DataGridView();
            this.dsLanguages = new CloudMagic.GUI.GUI.dsLanguages();
            this.dsLanguagesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.languagesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.englishDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.afrikaansDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLanguages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsLanguages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsLanguagesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.languagesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLanguages
            // 
            this.dgvLanguages.AutoGenerateColumns = false;
            this.dgvLanguages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLanguages.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.englishDataGridViewTextBoxColumn,
            this.afrikaansDataGridViewTextBoxColumn});
            this.dgvLanguages.DataSource = this.languagesBindingSource;
            this.dgvLanguages.Location = new System.Drawing.Point(8, 8);
            this.dgvLanguages.Name = "dgvLanguages";
            this.dgvLanguages.Size = new System.Drawing.Size(1019, 476);
            this.dgvLanguages.TabIndex = 0;
            // 
            // dsLanguages
            // 
            this.dsLanguages.DataSetName = "dsLanguages";
            this.dsLanguages.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dsLanguagesBindingSource
            // 
            this.dsLanguagesBindingSource.DataSource = this.dsLanguages;
            this.dsLanguagesBindingSource.Position = 0;
            // 
            // languagesBindingSource
            // 
            this.languagesBindingSource.DataMember = "Languages";
            this.languagesBindingSource.DataSource = this.dsLanguagesBindingSource;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            // 
            // englishDataGridViewTextBoxColumn
            // 
            this.englishDataGridViewTextBoxColumn.DataPropertyName = "English";
            this.englishDataGridViewTextBoxColumn.HeaderText = "English";
            this.englishDataGridViewTextBoxColumn.Name = "englishDataGridViewTextBoxColumn";
            // 
            // afrikaansDataGridViewTextBoxColumn
            // 
            this.afrikaansDataGridViewTextBoxColumn.DataPropertyName = "Afrikaans";
            this.afrikaansDataGridViewTextBoxColumn.HeaderText = "Afrikaans";
            this.afrikaansDataGridViewTextBoxColumn.Name = "afrikaansDataGridViewTextBoxColumn";
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(952, 490);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(75, 25);
            this.cmdSave.TabIndex = 1;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 501);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // frmLanguages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 523);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.dgvLanguages);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLanguages";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Setup Languages";
            this.Load += new System.EventHandler(this.frmLanguages_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLanguages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsLanguages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsLanguagesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.languagesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLanguages;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn englishDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn afrikaansDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource languagesBindingSource;
        private System.Windows.Forms.BindingSource dsLanguagesBindingSource;
        private dsLanguages dsLanguages;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Label label1;
    }
}