namespace IVO_Suite.Embalagem
{
    partial class PesquisaFacas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PesquisaFacas));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.txtSearch = new System.Windows.Forms.ToolStripTextBox();
            this.btnSearch = new System.Windows.Forms.ToolStripButton();
            this.btnExport = new System.Windows.Forms.ToolStripButton();
            this.dgvPesquisaFacas = new System.Windows.Forms.DataGridView();
            this.artigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.upc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pecas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rotlingua = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipocodbarras = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tiporotulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPesquisaFacas)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.txtSearch,
            this.btnSearch,
            this.btnExport});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(944, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(69, 22);
            this.toolStripLabel1.Text = "Ref. Artigo";
            // 
            // txtSearch
            // 
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(139, 25);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
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
            // btnExport
            // 
            this.btnExport.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnExport.Image = global::IVO_Suite.Properties.Resources.Excel_icon;
            this.btnExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(23, 22);
            this.btnExport.Text = "Exportar para Excel";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // dgvPesquisaFacas
            // 
            this.dgvPesquisaFacas.AllowUserToAddRows = false;
            this.dgvPesquisaFacas.AllowUserToDeleteRows = false;
            this.dgvPesquisaFacas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPesquisaFacas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.artigo,
            this.upc,
            this.cliente,
            this.nome,
            this.descr,
            this.grupo,
            this.pecas,
            this.rotlingua,
            this.tipocodbarras,
            this.tiporotulo});
            this.dgvPesquisaFacas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPesquisaFacas.Location = new System.Drawing.Point(0, 25);
            this.dgvPesquisaFacas.Name = "dgvPesquisaFacas";
            this.dgvPesquisaFacas.ReadOnly = true;
            this.dgvPesquisaFacas.RowHeadersVisible = false;
            this.dgvPesquisaFacas.Size = new System.Drawing.Size(944, 495);
            this.dgvPesquisaFacas.TabIndex = 1;
            // 
            // artigo
            // 
            this.artigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.artigo.HeaderText = "Artigo";
            this.artigo.Name = "artigo";
            this.artigo.ReadOnly = true;
            this.artigo.Width = 65;
            // 
            // upc
            // 
            this.upc.HeaderText = "UPC";
            this.upc.Name = "upc";
            this.upc.ReadOnly = true;
            this.upc.Width = 65;
            // 
            // cliente
            // 
            this.cliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cliente.HeaderText = "Cliente";
            this.cliente.Name = "cliente";
            this.cliente.ReadOnly = true;
            this.cliente.Width = 70;
            // 
            // nome
            // 
            this.nome.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.nome.HeaderText = "Nome";
            this.nome.Name = "nome";
            this.nome.ReadOnly = true;
            // 
            // descr
            // 
            this.descr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descr.HeaderText = "Descrição";
            this.descr.Name = "descr";
            this.descr.ReadOnly = true;
            // 
            // grupo
            // 
            this.grupo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.grupo.HeaderText = "Grupo Embal";
            this.grupo.Name = "grupo";
            this.grupo.ReadOnly = true;
            this.grupo.Width = 103;
            // 
            // pecas
            // 
            this.pecas.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.pecas.HeaderText = "Peças Inner";
            this.pecas.Name = "pecas";
            this.pecas.ReadOnly = true;
            this.pecas.Width = 96;
            // 
            // rotlingua
            // 
            this.rotlingua.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.rotlingua.HeaderText = "Lingua Rotulo";
            this.rotlingua.Name = "rotlingua";
            this.rotlingua.ReadOnly = true;
            this.rotlingua.Width = 107;
            // 
            // tipocodbarras
            // 
            this.tipocodbarras.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.tipocodbarras.HeaderText = "Tipo Cod Barras";
            this.tipocodbarras.Name = "tipocodbarras";
            this.tipocodbarras.ReadOnly = true;
            this.tipocodbarras.Width = 110;
            // 
            // tiporotulo
            // 
            this.tiporotulo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.tiporotulo.HeaderText = "Tipo Rotulo";
            this.tiporotulo.Name = "tiporotulo";
            this.tiporotulo.ReadOnly = true;
            this.tiporotulo.Width = 88;
            // 
            // PesquisaFacas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 520);
            this.Controls.Add(this.dgvPesquisaFacas);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PesquisaFacas";
            this.Text = "Pesquisa Facas";
            this.Load += new System.EventHandler(this.PesquisaFacas_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPesquisaFacas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox txtSearch;
        private System.Windows.Forms.ToolStripButton btnSearch;
        private System.Windows.Forms.DataGridView dgvPesquisaFacas;
        private System.Windows.Forms.ToolStripButton btnExport;
        private System.Windows.Forms.DataGridViewTextBoxColumn artigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn upc;
        private System.Windows.Forms.DataGridViewTextBoxColumn cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn descr;
        private System.Windows.Forms.DataGridViewTextBoxColumn grupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn pecas;
        private System.Windows.Forms.DataGridViewTextBoxColumn rotlingua;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipocodbarras;
        private System.Windows.Forms.DataGridViewTextBoxColumn tiporotulo;
    }
}