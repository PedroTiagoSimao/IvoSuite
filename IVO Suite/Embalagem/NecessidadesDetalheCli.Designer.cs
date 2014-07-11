namespace IVO_Suite.Embalagem
{
    partial class NecessidadesDetalheCli
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NecessidadesDetalheCli));
            this.btnPrint = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.dgvDetalhe = new System.Windows.Forms.DataGridView();
            this.enc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ano = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.artigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.refantiga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qttartigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gecod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.entrega = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnPrint.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalhe)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPrint
            // 
            this.btnPrint.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.btnPrint.Location = new System.Drawing.Point(0, 0);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(952, 25);
            this.btnPrint.TabIndex = 0;
            this.btnPrint.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::IVO_Suite.Properties.Resources.Print_16x16;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // dgvDetalhe
            // 
            this.dgvDetalhe.AllowUserToAddRows = false;
            this.dgvDetalhe.AllowUserToDeleteRows = false;
            this.dgvDetalhe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalhe.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.enc,
            this.ano,
            this.cliente,
            this.artigo,
            this.refantiga,
            this.quant,
            this.qttartigo,
            this.gecod,
            this.entrega,
            this.id});
            this.dgvDetalhe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetalhe.Location = new System.Drawing.Point(0, 25);
            this.dgvDetalhe.Name = "dgvDetalhe";
            this.dgvDetalhe.ReadOnly = true;
            this.dgvDetalhe.RowHeadersVisible = false;
            this.dgvDetalhe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalhe.Size = new System.Drawing.Size(952, 409);
            this.dgvDetalhe.TabIndex = 1;
            this.dgvDetalhe.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalhe_CellClick);
            this.dgvDetalhe.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalhe_CellDoubleClick);
            // 
            // enc
            // 
            this.enc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.enc.HeaderText = "Nº Enc";
            this.enc.Name = "enc";
            this.enc.ReadOnly = true;
            this.enc.Width = 67;
            // 
            // ano
            // 
            this.ano.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ano.HeaderText = "Ano";
            this.ano.Name = "ano";
            this.ano.ReadOnly = true;
            this.ano.Width = 53;
            // 
            // cliente
            // 
            this.cliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cliente.HeaderText = "Cliente";
            this.cliente.Name = "cliente";
            this.cliente.ReadOnly = true;
            // 
            // artigo
            // 
            this.artigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.artigo.HeaderText = "Artigo";
            this.artigo.Name = "artigo";
            this.artigo.ReadOnly = true;
            this.artigo.Width = 65;
            // 
            // refantiga
            // 
            this.refantiga.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.refantiga.HeaderText = "Ref. Antiga";
            this.refantiga.Name = "refantiga";
            this.refantiga.ReadOnly = true;
            this.refantiga.Width = 90;
            // 
            // quant
            // 
            this.quant.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.quant.HeaderText = "Quant. Encomenda";
            this.quant.Name = "quant";
            this.quant.ReadOnly = true;
            this.quant.Width = 124;
            // 
            // qttartigo
            // 
            this.qttartigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.qttartigo.HeaderText = "Quant. Artigo";
            this.qttartigo.Name = "qttartigo";
            this.qttartigo.ReadOnly = true;
            this.qttartigo.Width = 97;
            // 
            // gecod
            // 
            this.gecod.HeaderText = "Grupo";
            this.gecod.Name = "gecod";
            this.gecod.ReadOnly = true;
            // 
            // entrega
            // 
            this.entrega.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.entrega.HeaderText = "Semana";
            this.entrega.Name = "entrega";
            this.entrega.ReadOnly = true;
            this.entrega.Width = 75;
            // 
            // id
            // 
            this.id.HeaderText = "cid";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // NecessidadesDetalheCli
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 434);
            this.Controls.Add(this.dgvDetalhe);
            this.Controls.Add(this.btnPrint);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NecessidadesDetalheCli";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalhe Encomendas Cliente";
            this.Load += new System.EventHandler(this.NecessidadesDetalheCli_Load);
            this.btnPrint.ResumeLayout(false);
            this.btnPrint.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalhe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip btnPrint;
        private System.Windows.Forms.DataGridView dgvDetalhe;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.DataGridViewTextBoxColumn enc;
        private System.Windows.Forms.DataGridViewTextBoxColumn ano;
        private System.Windows.Forms.DataGridViewTextBoxColumn cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn artigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn refantiga;
        private System.Windows.Forms.DataGridViewTextBoxColumn quant;
        private System.Windows.Forms.DataGridViewTextBoxColumn qttartigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn gecod;
        private System.Windows.Forms.DataGridViewTextBoxColumn entrega;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
    }
}