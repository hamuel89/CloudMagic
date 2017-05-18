namespace CloudMagic.GUI
{
    partial class SetupSpellBook
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetupSpellBook));
            this.dgSpells = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbKeyBinds = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.InternalNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbKeyBind = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmdRemoveSpell = new System.Windows.Forms.Button();
            this.cmdAddSpell = new System.Windows.Forms.Button();
            this.nudSpellId = new System.Windows.Forms.NumericUpDown();
            this.txtSpellName = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbWowVersion = new System.Windows.Forms.ComboBox();
            this.txtAddonName = new System.Windows.Forms.TextBox();
            this.txtAddonAuthor = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdSave = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmdRemoveAura = new System.Windows.Forms.Button();
            this.cmdAddAura = new System.Windows.Forms.Button();
            this.nudAuraId = new System.Windows.Forms.NumericUpDown();
            this.txtAuraName = new System.Windows.Forms.TextBox();
            this.dgAuras = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cmdRemoveItem = new System.Windows.Forms.Button();
            this.cmdAddItem = new System.Windows.Forms.Button();
            this.nudItemId = new System.Windows.Forms.NumericUpDown();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.dgItems = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgSpells)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpellId)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAuraId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgAuras)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudItemId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).BeginInit();
            this.SuspendLayout();
            // 
            // dgSpells
            // 
            this.dgSpells.AllowUserToDeleteRows = false;
            this.dgSpells.AllowUserToResizeColumns = false;
            this.dgSpells.AllowUserToResizeRows = false;
            this.dgSpells.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgSpells.BackgroundColor = System.Drawing.Color.White;
            this.dgSpells.ColumnHeadersVisible = false;
            this.dgSpells.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.cmbKeyBinds,
            this.InternalNo});
            this.dgSpells.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgSpells.Location = new System.Drawing.Point(6, 65);
            this.dgSpells.Name = "dgSpells";
            this.dgSpells.RowHeadersVisible = false;
            this.dgSpells.RowHeadersWidth = 21;
            this.dgSpells.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgSpells.Size = new System.Drawing.Size(346, 533);
            this.dgSpells.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Spell Id";
            this.Column1.HeaderText = "Spell Id";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Spell Name";
            this.Column2.HeaderText = "Spell Name";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column2.Width = 155;
            // 
            // cmbKeyBinds
            // 
            this.cmbKeyBinds.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmbKeyBinds.DataPropertyName = "Key Bind";
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.cmbKeyBinds.DefaultCellStyle = dataGridViewCellStyle1;
            this.cmbKeyBinds.HeaderText = "Key Bind";
            this.cmbKeyBinds.Name = "cmbKeyBinds";
            this.cmbKeyBinds.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cmbKeyBinds.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // InternalNo
            // 
            this.InternalNo.DataPropertyName = "InternalNo";
            this.InternalNo.HeaderText = "Column4";
            this.InternalNo.Name = "InternalNo";
            this.InternalNo.ReadOnly = true;
            this.InternalNo.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbKeyBind);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmdRemoveSpell);
            this.groupBox1.Controls.Add(this.cmdAddSpell);
            this.groupBox1.Controls.Add(this.nudSpellId);
            this.groupBox1.Controls.Add(this.txtSpellName);
            this.groupBox1.Controls.Add(this.dgSpells);
            this.groupBox1.Location = new System.Drawing.Point(12, 118);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(404, 604);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Spells you care about (the addon will ignore spells not in this list)";
            // 
            // cmbKeyBind
            // 
            this.cmbKeyBind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKeyBind.FormattingEnabled = true;
            this.cmbKeyBind.Location = new System.Drawing.Point(261, 42);
            this.cmbKeyBind.Name = "cmbKeyBind";
            this.cmbKeyBind.Size = new System.Drawing.Size(91, 21);
            this.cmbKeyBind.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(260, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Key Bind";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(112, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Spell Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Spell Id";
            // 
            // cmdRemoveSpell
            // 
            this.cmdRemoveSpell.Location = new System.Drawing.Point(375, 42);
            this.cmdRemoveSpell.Name = "cmdRemoveSpell";
            this.cmdRemoveSpell.Size = new System.Drawing.Size(23, 23);
            this.cmdRemoveSpell.TabIndex = 5;
            this.cmdRemoveSpell.Text = "-";
            this.cmdRemoveSpell.UseVisualStyleBackColor = true;
            this.cmdRemoveSpell.Click += new System.EventHandler(this.cmdRemoveSpell_Click);
            // 
            // cmdAddSpell
            // 
            this.cmdAddSpell.Location = new System.Drawing.Point(353, 42);
            this.cmdAddSpell.Name = "cmdAddSpell";
            this.cmdAddSpell.Size = new System.Drawing.Size(23, 23);
            this.cmdAddSpell.TabIndex = 4;
            this.cmdAddSpell.Text = "+";
            this.cmdAddSpell.UseVisualStyleBackColor = true;
            this.cmdAddSpell.Click += new System.EventHandler(this.cmdAddSpell_Click);
            // 
            // nudSpellId
            // 
            this.nudSpellId.Location = new System.Drawing.Point(6, 42);
            this.nudSpellId.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nudSpellId.Name = "nudSpellId";
            this.nudSpellId.Size = new System.Drawing.Size(102, 20);
            this.nudSpellId.TabIndex = 9;
            this.nudSpellId.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtSpellName
            // 
            this.txtSpellName.Location = new System.Drawing.Point(110, 42);
            this.txtSpellName.Name = "txtSpellName";
            this.txtSpellName.Size = new System.Drawing.Size(150, 20);
            this.txtSpellName.TabIndex = 8;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.cmbWowVersion);
            this.groupBox3.Controls.Add(this.txtAddonName);
            this.groupBox3.Controls.Add(this.txtAddonAuthor);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(722, 100);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Rotation Info";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Gray;
            this.label10.Location = new System.Drawing.Point(311, 68);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(256, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "[Note: currently only WoD and Legion are supported]";
            // 
            // cmbWowVersion
            // 
            this.cmbWowVersion.FormattingEnabled = true;
            this.cmbWowVersion.Items.AddRange(new object[] {
            "Vanilla - 11200",
            "TBC - 20400",
            "WOTLK - 30300",
            "Cataclysm - 40300",
            "MoP - 50400",
            "WoD - 60200",
            "Legion - 70000",
            "Legion - 70100"});
            this.cmbWowVersion.Location = new System.Drawing.Point(108, 65);
            this.cmbWowVersion.Name = "cmbWowVersion";
            this.cmbWowVersion.Size = new System.Drawing.Size(197, 21);
            this.cmbWowVersion.TabIndex = 9;
            // 
            // txtAddonName
            // 
            this.txtAddonName.Location = new System.Drawing.Point(108, 41);
            this.txtAddonName.Name = "txtAddonName";
            this.txtAddonName.ReadOnly = true;
            this.txtAddonName.Size = new System.Drawing.Size(197, 20);
            this.txtAddonName.TabIndex = 8;
            // 
            // txtAddonAuthor
            // 
            this.txtAddonAuthor.Location = new System.Drawing.Point(108, 19);
            this.txtAddonAuthor.Name = "txtAddonAuthor";
            this.txtAddonAuthor.Size = new System.Drawing.Size(197, 20);
            this.txtAddonAuthor.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Author";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "WoW Version";
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(977, 726);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(75, 23);
            this.cmdSave.TabIndex = 5;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.cmdRemoveAura);
            this.groupBox2.Controls.Add(this.cmdAddAura);
            this.groupBox2.Controls.Add(this.nudAuraId);
            this.groupBox2.Controls.Add(this.txtAuraName);
            this.groupBox2.Controls.Add(this.dgAuras);
            this.groupBox2.Location = new System.Drawing.Point(422, 118);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(312, 604);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Auras you care about (the addon will ignore auras not in this list)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(112, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Aura Name";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Aura Id";
            // 
            // cmdRemoveAura
            // 
            this.cmdRemoveAura.Location = new System.Drawing.Point(284, 41);
            this.cmdRemoveAura.Name = "cmdRemoveAura";
            this.cmdRemoveAura.Size = new System.Drawing.Size(23, 23);
            this.cmdRemoveAura.TabIndex = 5;
            this.cmdRemoveAura.Text = "-";
            this.cmdRemoveAura.UseVisualStyleBackColor = true;
            this.cmdRemoveAura.Click += new System.EventHandler(this.cmdRemoveAura_Click);
            // 
            // cmdAddAura
            // 
            this.cmdAddAura.Location = new System.Drawing.Point(262, 41);
            this.cmdAddAura.Name = "cmdAddAura";
            this.cmdAddAura.Size = new System.Drawing.Size(23, 23);
            this.cmdAddAura.TabIndex = 4;
            this.cmdAddAura.Text = "+";
            this.cmdAddAura.UseVisualStyleBackColor = true;
            this.cmdAddAura.Click += new System.EventHandler(this.cmdAddAura_Click);
            // 
            // nudAuraId
            // 
            this.nudAuraId.Location = new System.Drawing.Point(6, 42);
            this.nudAuraId.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nudAuraId.Name = "nudAuraId";
            this.nudAuraId.Size = new System.Drawing.Size(102, 20);
            this.nudAuraId.TabIndex = 9;
            this.nudAuraId.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtAuraName
            // 
            this.txtAuraName.Location = new System.Drawing.Point(110, 42);
            this.txtAuraName.Name = "txtAuraName";
            this.txtAuraName.Size = new System.Drawing.Size(150, 20);
            this.txtAuraName.TabIndex = 8;
            // 
            // dgAuras
            // 
            this.dgAuras.AllowUserToAddRows = false;
            this.dgAuras.AllowUserToDeleteRows = false;
            this.dgAuras.AllowUserToResizeColumns = false;
            this.dgAuras.AllowUserToResizeRows = false;
            this.dgAuras.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgAuras.BackgroundColor = System.Drawing.Color.White;
            this.dgAuras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAuras.ColumnHeadersVisible = false;
            this.dgAuras.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dgAuras.Location = new System.Drawing.Point(6, 65);
            this.dgAuras.Name = "dgAuras";
            this.dgAuras.RowHeadersVisible = false;
            this.dgAuras.RowHeadersWidth = 21;
            this.dgAuras.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgAuras.Size = new System.Drawing.Size(301, 533);
            this.dgAuras.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Aura Id";
            this.dataGridViewTextBoxColumn1.HeaderText = "Aura Id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Aura Name";
            this.dataGridViewTextBoxColumn2.HeaderText = "Aura Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn2.Width = 200;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(15, 731);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(610, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "NB: If you add spells / auras your class does not support then addon could (and m" +
    "ost likely will) lag/break";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.cmdRemoveItem);
            this.groupBox4.Controls.Add(this.cmdAddItem);
            this.groupBox4.Controls.Add(this.nudItemId);
            this.groupBox4.Controls.Add(this.txtItemName);
            this.groupBox4.Controls.Add(this.dgItems);
            this.groupBox4.Location = new System.Drawing.Point(740, 118);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(312, 604);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Items you care about (the addon will ignore items not in this list)";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(112, 24);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "Item Name";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 24);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(39, 13);
            this.label12.TabIndex = 5;
            this.label12.Text = "Item Id";
            // 
            // cmdRemoveItem
            // 
            this.cmdRemoveItem.Location = new System.Drawing.Point(284, 41);
            this.cmdRemoveItem.Name = "cmdRemoveItem";
            this.cmdRemoveItem.Size = new System.Drawing.Size(23, 23);
            this.cmdRemoveItem.TabIndex = 5;
            this.cmdRemoveItem.Text = "-";
            this.cmdRemoveItem.UseVisualStyleBackColor = true;
            this.cmdRemoveItem.Click += new System.EventHandler(this.cmdRemoveItem_Click);
            // 
            // cmdAddItem
            // 
            this.cmdAddItem.Location = new System.Drawing.Point(262, 41);
            this.cmdAddItem.Name = "cmdAddItem";
            this.cmdAddItem.Size = new System.Drawing.Size(23, 23);
            this.cmdAddItem.TabIndex = 4;
            this.cmdAddItem.Text = "+";
            this.cmdAddItem.UseVisualStyleBackColor = true;
            this.cmdAddItem.Click += new System.EventHandler(this.cmdAddItem_Click);
            // 
            // nudItemId
            // 
            this.nudItemId.Location = new System.Drawing.Point(6, 42);
            this.nudItemId.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nudItemId.Name = "nudItemId";
            this.nudItemId.Size = new System.Drawing.Size(102, 20);
            this.nudItemId.TabIndex = 9;
            this.nudItemId.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtItemName
            // 
            this.txtItemName.Location = new System.Drawing.Point(110, 42);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(150, 20);
            this.txtItemName.TabIndex = 8;
            // 
            // dgItems
            // 
            this.dgItems.AllowUserToAddRows = false;
            this.dgItems.AllowUserToDeleteRows = false;
            this.dgItems.AllowUserToResizeColumns = false;
            this.dgItems.AllowUserToResizeRows = false;
            this.dgItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgItems.BackgroundColor = System.Drawing.Color.White;
            this.dgItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgItems.ColumnHeadersVisible = false;
            this.dgItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.dgItems.Location = new System.Drawing.Point(6, 65);
            this.dgItems.Name = "dgItems";
            this.dgItems.RowHeadersVisible = false;
            this.dgItems.RowHeadersWidth = 21;
            this.dgItems.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgItems.Size = new System.Drawing.Size(301, 533);
            this.dgItems.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Item Id";
            this.dataGridViewTextBoxColumn3.HeaderText = "Item Id";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Item Name";
            this.dataGridViewTextBoxColumn4.HeaderText = "Item Name";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn4.Width = 200;
            // 
            // SetupSpellBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1063, 761);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SetupSpellBook";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Setup Spell Book";
            this.Load += new System.EventHandler(this.SetupSpellBook_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgSpells)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpellId)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAuraId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgAuras)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudItemId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgSpells;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button cmdRemoveSpell;
        private System.Windows.Forms.Button cmdAddSpell;
        private System.Windows.Forms.NumericUpDown nudSpellId;
        private System.Windows.Forms.TextBox txtSpellName;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtAddonName;
        private System.Windows.Forms.TextBox txtAddonAuthor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button cmdRemoveAura;
        private System.Windows.Forms.Button cmdAddAura;
        private System.Windows.Forms.NumericUpDown nudAuraId;
        private System.Windows.Forms.TextBox txtAuraName;
        private System.Windows.Forms.DataGridView dgAuras;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbWowVersion;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbKeyBind;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button cmdRemoveItem;
        private System.Windows.Forms.Button cmdAddItem;
        private System.Windows.Forms.NumericUpDown nudItemId;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.DataGridView dgItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewComboBoxColumn cmbKeyBinds;
        private System.Windows.Forms.DataGridViewTextBoxColumn InternalNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    }
}