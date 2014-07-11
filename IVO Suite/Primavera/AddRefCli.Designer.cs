namespace IVO_Suite.Primavera
{
    partial class AddRefCli
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddRefCli));
            this.label1 = new System.Windows.Forms.Label();
            this.cmbClientes = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtReferenciaCli = new System.Windows.Forms.TextBox();
            this.txtDescricaoCli = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCodBarras = new System.Windows.Forms.TextBox();
            this.cmbGrupoEmbalagem = new System.Windows.Forms.ComboBox();
            this.btnAnexo = new System.Windows.Forms.Button();
            this.dgvAnexo = new System.Windows.Forms.DataGridView();
            this.rotnome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rotanexo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.eliminarAnexoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbTipoCodBarras = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtOutraLingua = new System.Windows.Forms.TextBox();
            this.rbtnOutraLingua = new System.Windows.Forms.RadioButton();
            this.rbtnIngles = new System.Windows.Forms.RadioButton();
            this.rbtnPortugues = new System.Windows.Forms.RadioButton();
            this.cmbTipoRotulo = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtPecasMaster = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPecasInner = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnexo)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cliente";
            // 
            // cmbClientes
            // 
            this.cmbClientes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbClientes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbClientes.FormattingEnabled = true;
            this.cmbClientes.Location = new System.Drawing.Point(17, 25);
            this.cmbClientes.Name = "cmbClientes";
            this.cmbClientes.Size = new System.Drawing.Size(84, 23);
            this.cmbClientes.TabIndex = 0;
            this.cmbClientes.Leave += new System.EventHandler(this.cmbClientes_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(106, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ref";
            // 
            // txtReferenciaCli
            // 
            this.txtReferenciaCli.BackColor = System.Drawing.SystemColors.Window;
            this.txtReferenciaCli.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReferenciaCli.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtReferenciaCli.Location = new System.Drawing.Point(107, 25);
            this.txtReferenciaCli.Name = "txtReferenciaCli";
            this.txtReferenciaCli.Size = new System.Drawing.Size(138, 23);
            this.txtReferenciaCli.TabIndex = 1;
            // 
            // txtDescricaoCli
            // 
            this.txtDescricaoCli.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescricaoCli.Location = new System.Drawing.Point(251, 25);
            this.txtDescricaoCli.Name = "txtDescricaoCli";
            this.txtDescricaoCli.Size = new System.Drawing.Size(296, 23);
            this.txtDescricaoCli.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(247, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Descrição";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Image = global::IVO_Suite.Properties.Resources.Cancel_16x16;
            this.btnClose.Location = new System.Drawing.Point(512, 400);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(35, 34);
            this.btnClose.TabIndex = 7;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Image = global::IVO_Suite.Properties.Resources.Check_16x16;
            this.btnAdd.Location = new System.Drawing.Point(470, 400);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(35, 34);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Grupo Embalagem";
            // 
            // txtCodBarras
            // 
            this.txtCodBarras.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodBarras.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCodBarras.Location = new System.Drawing.Point(6, 51);
            this.txtCodBarras.Name = "txtCodBarras";
            this.txtCodBarras.Size = new System.Drawing.Size(317, 23);
            this.txtCodBarras.TabIndex = 5;
            // 
            // cmbGrupoEmbalagem
            // 
            this.cmbGrupoEmbalagem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbGrupoEmbalagem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbGrupoEmbalagem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbGrupoEmbalagem.FormattingEnabled = true;
            this.cmbGrupoEmbalagem.Location = new System.Drawing.Point(17, 82);
            this.cmbGrupoEmbalagem.Name = "cmbGrupoEmbalagem";
            this.cmbGrupoEmbalagem.Size = new System.Drawing.Size(197, 23);
            this.cmbGrupoEmbalagem.TabIndex = 13;
            // 
            // btnAnexo
            // 
            this.btnAnexo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAnexo.Location = new System.Drawing.Point(17, 241);
            this.btnAnexo.Name = "btnAnexo";
            this.btnAnexo.Size = new System.Drawing.Size(86, 23);
            this.btnAnexo.TabIndex = 14;
            this.btnAnexo.Text = "Anexos";
            this.btnAnexo.UseVisualStyleBackColor = true;
            this.btnAnexo.Click += new System.EventHandler(this.btnAnexo_Click);
            // 
            // dgvAnexo
            // 
            this.dgvAnexo.AllowUserToAddRows = false;
            this.dgvAnexo.AllowUserToDeleteRows = false;
            this.dgvAnexo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.dgvAnexo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAnexo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rotnome,
            this.rotanexo,
            this.id});
            this.dgvAnexo.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvAnexo.Location = new System.Drawing.Point(17, 270);
            this.dgvAnexo.Name = "dgvAnexo";
            this.dgvAnexo.ReadOnly = true;
            this.dgvAnexo.RowHeadersVisible = false;
            this.dgvAnexo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAnexo.Size = new System.Drawing.Size(530, 124);
            this.dgvAnexo.TabIndex = 15;
            this.dgvAnexo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAnexo_CellClick);
            this.dgvAnexo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAnexoCell_Double_Click);
            // 
            // rotnome
            // 
            this.rotnome.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.rotnome.HeaderText = "Nome";
            this.rotnome.Name = "rotnome";
            this.rotnome.ReadOnly = true;
            // 
            // rotanexo
            // 
            this.rotanexo.HeaderText = "Data";
            this.rotanexo.Name = "rotanexo";
            this.rotanexo.ReadOnly = true;
            this.rotanexo.Visible = false;
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eliminarAnexoToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(156, 26);
            // 
            // eliminarAnexoToolStripMenuItem
            // 
            this.eliminarAnexoToolStripMenuItem.Name = "eliminarAnexoToolStripMenuItem";
            this.eliminarAnexoToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.eliminarAnexoToolStripMenuItem.Text = "Eliminar Anexo";
            this.eliminarAnexoToolStripMenuItem.Click += new System.EventHandler(this.eliminarAnexoToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbTipoCodBarras);
            this.groupBox1.Controls.Add(this.txtCodBarras);
            this.groupBox1.Location = new System.Drawing.Point(220, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(329, 84);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Código de Barras";
            // 
            // cmbTipoCodBarras
            // 
            this.cmbTipoCodBarras.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTipoCodBarras.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTipoCodBarras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbTipoCodBarras.FormattingEnabled = true;
            this.cmbTipoCodBarras.Items.AddRange(new object[] {
            "Não Aplicavel",
            "Ivo",
            "Cliente"});
            this.cmbTipoCodBarras.Location = new System.Drawing.Point(6, 22);
            this.cmbTipoCodBarras.Name = "cmbTipoCodBarras";
            this.cmbTipoCodBarras.Size = new System.Drawing.Size(172, 23);
            this.cmbTipoCodBarras.TabIndex = 14;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtOutraLingua);
            this.groupBox2.Controls.Add(this.rbtnOutraLingua);
            this.groupBox2.Controls.Add(this.rbtnIngles);
            this.groupBox2.Controls.Add(this.rbtnPortugues);
            this.groupBox2.Controls.Add(this.cmbTipoRotulo);
            this.groupBox2.Location = new System.Drawing.Point(220, 150);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(329, 85);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Rótulo";
            // 
            // txtOutraLingua
            // 
            this.txtOutraLingua.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOutraLingua.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtOutraLingua.Location = new System.Drawing.Point(193, 47);
            this.txtOutraLingua.Name = "txtOutraLingua";
            this.txtOutraLingua.Size = new System.Drawing.Size(130, 23);
            this.txtOutraLingua.TabIndex = 18;
            this.txtOutraLingua.Enter += new System.EventHandler(this.txtOutraLingua_Enter);
            // 
            // rbtnOutraLingua
            // 
            this.rbtnOutraLingua.AutoSize = true;
            this.rbtnOutraLingua.Location = new System.Drawing.Point(173, 54);
            this.rbtnOutraLingua.Name = "rbtnOutraLingua";
            this.rbtnOutraLingua.Size = new System.Drawing.Size(14, 13);
            this.rbtnOutraLingua.TabIndex = 17;
            this.rbtnOutraLingua.TabStop = true;
            this.rbtnOutraLingua.UseVisualStyleBackColor = true;
            // 
            // rbtnIngles
            // 
            this.rbtnIngles.AutoSize = true;
            this.rbtnIngles.Location = new System.Drawing.Point(97, 51);
            this.rbtnIngles.Name = "rbtnIngles";
            this.rbtnIngles.Size = new System.Drawing.Size(53, 17);
            this.rbtnIngles.TabIndex = 16;
            this.rbtnIngles.TabStop = true;
            this.rbtnIngles.Text = "Inglês";
            this.rbtnIngles.UseVisualStyleBackColor = true;
            // 
            // rbtnPortugues
            // 
            this.rbtnPortugues.AutoSize = true;
            this.rbtnPortugues.Location = new System.Drawing.Point(8, 51);
            this.rbtnPortugues.Name = "rbtnPortugues";
            this.rbtnPortugues.Size = new System.Drawing.Size(73, 17);
            this.rbtnPortugues.TabIndex = 15;
            this.rbtnPortugues.TabStop = true;
            this.rbtnPortugues.Text = "Português";
            this.rbtnPortugues.UseVisualStyleBackColor = true;
            // 
            // cmbTipoRotulo
            // 
            this.cmbTipoRotulo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTipoRotulo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTipoRotulo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbTipoRotulo.FormattingEnabled = true;
            this.cmbTipoRotulo.Items.AddRange(new object[] {
            "Standard Ivo",
            "Personalizado"});
            this.cmbTipoRotulo.Location = new System.Drawing.Point(6, 22);
            this.cmbTipoRotulo.Name = "cmbTipoRotulo";
            this.cmbTipoRotulo.Size = new System.Drawing.Size(139, 23);
            this.cmbTipoRotulo.TabIndex = 14;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtPecasMaster);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txtPecasInner);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(17, 111);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(197, 124);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Caixas";
            // 
            // txtPecasMaster
            // 
            this.txtPecasMaster.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPecasMaster.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPecasMaster.Location = new System.Drawing.Point(9, 93);
            this.txtPecasMaster.Name = "txtPecasMaster";
            this.txtPecasMaster.Size = new System.Drawing.Size(130, 23);
            this.txtPecasMaster.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 15);
            this.label6.TabIndex = 20;
            this.label6.Text = "Nº Peças Master";
            // 
            // txtPecasInner
            // 
            this.txtPecasInner.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPecasInner.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPecasInner.Location = new System.Drawing.Point(9, 47);
            this.txtPecasInner.Name = "txtPecasInner";
            this.txtPecasInner.Size = new System.Drawing.Size(130, 23);
            this.txtPecasInner.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Nº Peças Inner";
            // 
            // AddRefCli
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 447);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.txtReferenciaCli);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvAnexo);
            this.Controls.Add(this.cmbGrupoEmbalagem);
            this.Controls.Add(this.btnAnexo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDescricaoCli);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbClientes);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AddRefCli";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Referência de Cliente";
            this.Load += new System.EventHandler(this.AddRefCli_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnexo)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbClientes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtReferenciaCli;
        private System.Windows.Forms.TextBox txtDescricaoCli;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCodBarras;
        private System.Windows.Forms.ComboBox cmbGrupoEmbalagem;
        private System.Windows.Forms.Button btnAnexo;
        private System.Windows.Forms.DataGridView dgvAnexo;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem eliminarAnexoToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn rotnome;
        private System.Windows.Forms.DataGridViewTextBoxColumn rotanexo;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbTipoCodBarras;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtOutraLingua;
        private System.Windows.Forms.RadioButton rbtnOutraLingua;
        private System.Windows.Forms.RadioButton rbtnIngles;
        private System.Windows.Forms.RadioButton rbtnPortugues;
        private System.Windows.Forms.ComboBox cmbTipoRotulo;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtPecasMaster;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPecasInner;
        private System.Windows.Forms.Label label5;
    }
}