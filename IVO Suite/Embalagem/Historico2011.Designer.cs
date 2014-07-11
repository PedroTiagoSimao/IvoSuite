namespace IVO_Suite.Embalagem
{
    partial class Historico2011
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.txtCliente = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.txtArtigo = new System.Windows.Forms.ToolStripTextBox();
            this.btnSearch = new System.Windows.Forms.ToolStripButton();
            this.lblGe = new System.Windows.Forms.ToolStripLabel();
            this.btnExport = new System.Windows.Forms.ToolStripButton();
            this.dgvHistory = new System.Windows.Forms.DataGridView();
            this.Enc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.artigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UPC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.genum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.embalagem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gedescr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.refantiga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.plano = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.obs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.txtGrupo = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.txtArtEmbal = new System.Windows.Forms.ToolStripTextBox();
            this.btnSearch2 = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.txtCliente,
            this.toolStripSeparator1,
            this.toolStripLabel2,
            this.txtArtigo,
            this.btnSearch,
            this.lblGe,
            this.btnExport,
            this.toolStripSeparator2,
            this.toolStripLabel3,
            this.txtGrupo,
            this.toolStripLabel4,
            this.txtArtEmbal,
            this.btnSearch2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1355, 26);
            this.toolStrip1.TabIndex = 1;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(96, 23);
            this.toolStripLabel1.Text = "Nome do Cliente";
            // 
            // txtCliente
            // 
            this.txtCliente.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(400, 26);
            this.txtCliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCliente_KeyDown);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 26);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(93, 23);
            this.toolStripLabel2.Text = "Ref. Cliente/IVO";
            // 
            // txtArtigo
            // 
            this.txtArtigo.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtArtigo.Name = "txtArtigo";
            this.txtArtigo.Size = new System.Drawing.Size(100, 26);
            this.txtArtigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtArtigo_KeyDown);
            // 
            // btnSearch
            // 
            this.btnSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSearch.Image = global::IVO_Suite.Properties.Resources.Search_16x16;
            this.btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(23, 23);
            this.btnSearch.Text = "Procurar";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblGe
            // 
            this.lblGe.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblGe.Name = "lblGe";
            this.lblGe.Size = new System.Drawing.Size(0, 23);
            // 
            // btnExport
            // 
            this.btnExport.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnExport.Image = global::IVO_Suite.Properties.Resources.Excel_icon;
            this.btnExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(23, 23);
            this.btnExport.Text = "Exportar para Excel";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click_1);
            // 
            // dgvHistory
            // 
            this.dgvHistory.AllowUserToAddRows = false;
            this.dgvHistory.AllowUserToDeleteRows = false;
            this.dgvHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Enc,
            this.cliente,
            this.artigo,
            this.UPC,
            this.genum,
            this.embalagem,
            this.gedescr,
            this.refantiga,
            this.plano,
            this.obs});
            this.dgvHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHistory.Location = new System.Drawing.Point(0, 26);
            this.dgvHistory.Name = "dgvHistory";
            this.dgvHistory.ReadOnly = true;
            this.dgvHistory.RowHeadersVisible = false;
            this.dgvHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistory.Size = new System.Drawing.Size(1355, 531);
            this.dgvHistory.TabIndex = 2;
            // 
            // Enc
            // 
            this.Enc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Enc.HeaderText = "Nº Enc";
            this.Enc.Name = "Enc";
            this.Enc.ReadOnly = true;
            this.Enc.Width = 66;
            // 
            // cliente
            // 
            this.cliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cliente.HeaderText = "Cliente";
            this.cliente.Name = "cliente";
            this.cliente.ReadOnly = true;
            this.cliente.Width = 71;
            // 
            // artigo
            // 
            this.artigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.artigo.HeaderText = "Ref. Cliente";
            this.artigo.Name = "artigo";
            this.artigo.ReadOnly = true;
            this.artigo.Width = 88;
            // 
            // UPC
            // 
            this.UPC.HeaderText = "Ref. IVO";
            this.UPC.Name = "UPC";
            this.UPC.ReadOnly = true;
            // 
            // genum
            // 
            this.genum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.genum.HeaderText = "Grupo Embal";
            this.genum.Name = "genum";
            this.genum.ReadOnly = true;
            this.genum.Width = 94;
            // 
            // embalagem
            // 
            this.embalagem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.embalagem.HeaderText = "Embalagem";
            this.embalagem.Name = "embalagem";
            this.embalagem.ReadOnly = true;
            this.embalagem.Width = 96;
            // 
            // gedescr
            // 
            this.gedescr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gedescr.HeaderText = "Descrição";
            this.gedescr.Name = "gedescr";
            this.gedescr.ReadOnly = true;
            // 
            // refantiga
            // 
            this.refantiga.HeaderText = "Ref. Antiga";
            this.refantiga.Name = "refantiga";
            this.refantiga.ReadOnly = true;
            // 
            // plano
            // 
            this.plano.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.plano.HeaderText = "Plano";
            this.plano.Name = "plano";
            this.plano.ReadOnly = true;
            this.plano.Width = 63;
            // 
            // obs
            // 
            this.obs.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.obs.HeaderText = "Obs";
            this.obs.Name = "obs";
            this.obs.ReadOnly = true;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 26);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(40, 23);
            this.toolStripLabel3.Text = "Grupo";
            // 
            // txtGrupo
            // 
            this.txtGrupo.Name = "txtGrupo";
            this.txtGrupo.Size = new System.Drawing.Size(100, 26);
            this.txtGrupo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtGrupo_KeyDown);
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(39, 23);
            this.toolStripLabel4.Text = "Artigo";
            // 
            // txtArtEmbal
            // 
            this.txtArtEmbal.Name = "txtArtEmbal";
            this.txtArtEmbal.Size = new System.Drawing.Size(100, 26);
            this.txtArtEmbal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtArtEmbal_KeyDown);
            // 
            // btnSearch2
            // 
            this.btnSearch2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSearch2.Image = global::IVO_Suite.Properties.Resources.Search_16x16;
            this.btnSearch2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSearch2.Name = "btnSearch2";
            this.btnSearch2.Size = new System.Drawing.Size(23, 23);
            this.btnSearch2.Text = "toolStripButton1";
            this.btnSearch2.Click += new System.EventHandler(this.btnSearch2_Click);
            // 
            // Historico2011
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1355, 557);
            this.Controls.Add(this.dgvHistory);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Historico2011";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Historico2011";
            this.Load += new System.EventHandler(this.Historico2011_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox txtCliente;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox txtArtigo;
        private System.Windows.Forms.ToolStripButton btnSearch;
        private System.Windows.Forms.ToolStripLabel lblGe;
        private System.Windows.Forms.ToolStripButton btnExport;
        private System.Windows.Forms.DataGridView dgvHistory;
        private System.Windows.Forms.DataGridViewTextBoxColumn Enc;
        private System.Windows.Forms.DataGridViewTextBoxColumn cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn artigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn UPC;
        private System.Windows.Forms.DataGridViewTextBoxColumn genum;
        private System.Windows.Forms.DataGridViewTextBoxColumn embalagem;
        private System.Windows.Forms.DataGridViewTextBoxColumn gedescr;
        private System.Windows.Forms.DataGridViewTextBoxColumn refantiga;
        private System.Windows.Forms.DataGridViewTextBoxColumn plano;
        private System.Windows.Forms.DataGridViewTextBoxColumn obs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripTextBox txtGrupo;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripTextBox txtArtEmbal;
        private System.Windows.Forms.ToolStripButton btnSearch2;
    }
}