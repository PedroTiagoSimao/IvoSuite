namespace IVO_Suite.Primavera
{
    partial class RefCli
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RefCli));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.txtRef = new System.Windows.Forms.ToolStripTextBox();
            this.btnSearch = new System.Windows.Forms.ToolStripButton();
            this.btnRefreshRefs = new System.Windows.Forms.ToolStripButton();
            this.btnAddRefCli = new System.Windows.Forms.ToolStripButton();
            this.cmbRefIvo = new System.Windows.Forms.ToolStripComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSubFamilia = new System.Windows.Forms.TextBox();
            this.txtFamilia = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDescrição = new System.Windows.Forms.TextBox();
            this.txtArtigo = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvRefCli = new System.Windows.Forms.DataGridView();
            this.cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.referencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grupoembalagem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descrgrupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipocod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codbarras = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tiporotulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lingua = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inner = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.master = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsDgvRefCli = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRefCli)).BeginInit();
            this.cmsDgvRefCli.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.txtRef,
            this.btnSearch,
            this.btnRefreshRefs,
            this.btnAddRefCli,
            this.cmbRefIvo});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1142, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(50, 22);
            this.toolStripLabel1.Text = "Ref. IVO";
            // 
            // txtRef
            // 
            this.txtRef.Name = "txtRef";
            this.txtRef.Size = new System.Drawing.Size(100, 25);
            this.txtRef.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRef_KeyDown);
            // 
            // btnSearch
            // 
            this.btnSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSearch.Image = global::IVO_Suite.Properties.Resources.Search_16x16;
            this.btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(23, 22);
            this.btnSearch.Text = "toolStripButton1";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnRefreshRefs
            // 
            this.btnRefreshRefs.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnRefreshRefs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRefreshRefs.Image = global::IVO_Suite.Properties.Resources.Refresh_16x16;
            this.btnRefreshRefs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefreshRefs.Name = "btnRefreshRefs";
            this.btnRefreshRefs.Size = new System.Drawing.Size(23, 22);
            this.btnRefreshRefs.Text = "toolStripButton1";
            this.btnRefreshRefs.ToolTipText = "Refrescar referências";
            this.btnRefreshRefs.Click += new System.EventHandler(this.btnRefreshRefs_Click);
            // 
            // btnAddRefCli
            // 
            this.btnAddRefCli.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnAddRefCli.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddRefCli.Image = global::IVO_Suite.Properties.Resources.Add_16x16;
            this.btnAddRefCli.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddRefCli.Name = "btnAddRefCli";
            this.btnAddRefCli.Size = new System.Drawing.Size(23, 22);
            this.btnAddRefCli.Text = "toolStripButton1";
            this.btnAddRefCli.ToolTipText = "Adicionar referência cliente";
            this.btnAddRefCli.Click += new System.EventHandler(this.btnAddRefCli_Click);
            // 
            // cmbRefIvo
            // 
            this.cmbRefIvo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbRefIvo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbRefIvo.Name = "cmbRefIvo";
            this.cmbRefIvo.Size = new System.Drawing.Size(121, 25);
            this.cmbRefIvo.Visible = false;
            this.cmbRefIvo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbRefIvo_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtSubFamilia);
            this.groupBox1.Controls.Add(this.txtFamilia);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtDescrição);
            this.groupBox1.Controls.Add(this.txtArtigo);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1115, 98);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Artigo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(91, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "SubFamilia";
            // 
            // txtSubFamilia
            // 
            this.txtSubFamilia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSubFamilia.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubFamilia.Location = new System.Drawing.Point(91, 64);
            this.txtSubFamilia.Name = "txtSubFamilia";
            this.txtSubFamilia.ReadOnly = true;
            this.txtSubFamilia.Size = new System.Drawing.Size(85, 21);
            this.txtSubFamilia.TabIndex = 4;
            // 
            // txtFamilia
            // 
            this.txtFamilia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFamilia.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFamilia.Location = new System.Drawing.Point(6, 64);
            this.txtFamilia.Name = "txtFamilia";
            this.txtFamilia.ReadOnly = true;
            this.txtFamilia.Size = new System.Drawing.Size(79, 21);
            this.txtFamilia.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Familia";
            // 
            // txtDescrição
            // 
            this.txtDescrição.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescrição.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescrição.Location = new System.Drawing.Point(182, 20);
            this.txtDescrição.Name = "txtDescrição";
            this.txtDescrição.ReadOnly = true;
            this.txtDescrição.Size = new System.Drawing.Size(630, 22);
            this.txtDescrição.TabIndex = 1;
            // 
            // txtArtigo
            // 
            this.txtArtigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtArtigo.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtArtigo.Location = new System.Drawing.Point(6, 20);
            this.txtArtigo.Name = "txtArtigo";
            this.txtArtigo.ReadOnly = true;
            this.txtArtigo.Size = new System.Drawing.Size(170, 21);
            this.txtArtigo.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dgvRefCli);
            this.groupBox2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 135);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1118, 282);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Referências de Cliente";
            // 
            // dgvRefCli
            // 
            this.dgvRefCli.AllowUserToAddRows = false;
            this.dgvRefCli.AllowUserToDeleteRows = false;
            this.dgvRefCli.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRefCli.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cliente,
            this.referencia,
            this.descricao,
            this.grupoembalagem,
            this.descrgrupo,
            this.tipocod,
            this.codbarras,
            this.tiporotulo,
            this.lingua,
            this.inner,
            this.master});
            this.dgvRefCli.ContextMenuStrip = this.cmsDgvRefCli;
            this.dgvRefCli.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRefCli.Location = new System.Drawing.Point(3, 19);
            this.dgvRefCli.Name = "dgvRefCli";
            this.dgvRefCli.ReadOnly = true;
            this.dgvRefCli.RowHeadersVisible = false;
            this.dgvRefCli.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRefCli.Size = new System.Drawing.Size(1112, 260);
            this.dgvRefCli.TabIndex = 0;
            this.dgvRefCli.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRefCli_CellClick);
            this.dgvRefCli.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRefCli_CellDoubleClick);
            // 
            // cliente
            // 
            this.cliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cliente.HeaderText = "Cliente";
            this.cliente.Name = "cliente";
            this.cliente.ReadOnly = true;
            this.cliente.Width = 70;
            // 
            // referencia
            // 
            this.referencia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.referencia.HeaderText = "Referencia";
            this.referencia.Name = "referencia";
            this.referencia.ReadOnly = true;
            this.referencia.Width = 90;
            // 
            // descricao
            // 
            this.descricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descricao.HeaderText = "Descrição";
            this.descricao.Name = "descricao";
            this.descricao.ReadOnly = true;
            // 
            // grupoembalagem
            // 
            this.grupoembalagem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.grupoembalagem.HeaderText = "GrupoEmbalagem";
            this.grupoembalagem.Name = "grupoembalagem";
            this.grupoembalagem.ReadOnly = true;
            this.grupoembalagem.Width = 129;
            // 
            // descrgrupo
            // 
            this.descrgrupo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descrgrupo.HeaderText = "Descrição";
            this.descrgrupo.Name = "descrgrupo";
            this.descrgrupo.ReadOnly = true;
            // 
            // tipocod
            // 
            this.tipocod.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.tipocod.HeaderText = "Tipo Cod.";
            this.tipocod.Name = "tipocod";
            this.tipocod.ReadOnly = true;
            this.tipocod.Width = 83;
            // 
            // codbarras
            // 
            this.codbarras.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.codbarras.HeaderText = "Cód. Barras";
            this.codbarras.Name = "codbarras";
            this.codbarras.ReadOnly = true;
            this.codbarras.Width = 96;
            // 
            // tiporotulo
            // 
            this.tiporotulo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.tiporotulo.HeaderText = "Tipo Rótulo";
            this.tiporotulo.Name = "tiporotulo";
            this.tiporotulo.ReadOnly = true;
            this.tiporotulo.Width = 95;
            // 
            // lingua
            // 
            this.lingua.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.lingua.HeaderText = "Lingua";
            this.lingua.Name = "lingua";
            this.lingua.ReadOnly = true;
            this.lingua.Width = 68;
            // 
            // inner
            // 
            this.inner.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.inner.HeaderText = "Inner";
            this.inner.Name = "inner";
            this.inner.ReadOnly = true;
            this.inner.Width = 61;
            // 
            // master
            // 
            this.master.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.master.HeaderText = "Master";
            this.master.Name = "master";
            this.master.ReadOnly = true;
            this.master.Width = 71;
            // 
            // cmsDgvRefCli
            // 
            this.cmsDgvRefCli.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdd,
            this.btnEdit,
            this.btnDelete});
            this.cmsDgvRefCli.Name = "cmsDgvRefCli";
            this.cmsDgvRefCli.Size = new System.Drawing.Size(130, 70);
            // 
            // btnAdd
            // 
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(129, 22);
            this.btnAdd.Text = "Adicionar";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(129, 22);
            this.btnEdit.Text = "Editar";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::IVO_Suite.Properties.Resources.Remove_16x16;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(129, 22);
            this.btnDelete.Text = "Apagar";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // RefCli
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1142, 430);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RefCli";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Referencias Cliente";
            this.Load += new System.EventHandler(this.RefCli_Load);
            this.Shown += new System.EventHandler(this.RefCli_Shown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRefCli)).EndInit();
            this.cmsDgvRefCli.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox cmbRefIvo;
        private System.Windows.Forms.ToolStripButton btnSearch;
        private System.Windows.Forms.ToolStripButton btnRefreshRefs;
        private System.Windows.Forms.ToolStripButton btnAddRefCli;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSubFamilia;
        private System.Windows.Forms.TextBox txtFamilia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDescrição;
        private System.Windows.Forms.TextBox txtArtigo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvRefCli;
        private System.Windows.Forms.ContextMenuStrip cmsDgvRefCli;
        private System.Windows.Forms.ToolStripMenuItem btnEdit;
        private System.Windows.Forms.ToolStripMenuItem btnDelete;
        private System.Windows.Forms.ToolStripMenuItem btnAdd;
        private System.Windows.Forms.ToolStripTextBox txtRef;
        private System.Windows.Forms.DataGridViewTextBoxColumn cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn referencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn grupoembalagem;
        private System.Windows.Forms.DataGridViewTextBoxColumn descrgrupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipocod;
        private System.Windows.Forms.DataGridViewTextBoxColumn codbarras;
        private System.Windows.Forms.DataGridViewTextBoxColumn tiporotulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn lingua;
        private System.Windows.Forms.DataGridViewTextBoxColumn inner;
        private System.Windows.Forms.DataGridViewTextBoxColumn master;
    }
}