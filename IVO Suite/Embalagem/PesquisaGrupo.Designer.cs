namespace IVO_Suite.Embalagem
{
    partial class PesquisaGrupo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PesquisaGrupo));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.txtArtigo = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.txtGrupo = new System.Windows.Forms.ToolStripTextBox();
            this.btnSearchGrupo = new System.Windows.Forms.ToolStripButton();
            this.dgvPesquisaGrupo = new System.Windows.Forms.DataGridView();
            this.artigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.upc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.refantiga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descGrupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gecod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPesquisaGrupo)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.txtArtigo,
            this.toolStripButton1,
            this.toolStripLabel2,
            this.toolStripSeparator1,
            this.toolStripLabel3,
            this.txtGrupo,
            this.btnSearchGrupo});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(911, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(109, 22);
            this.toolStripLabel1.Text = "Pesquisa de Artigo";
            // 
            // txtArtigo
            // 
            this.txtArtigo.Name = "txtArtigo";
            this.txtArtigo.Size = new System.Drawing.Size(116, 25);
            this.txtArtigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtArtigo_KeyDown);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::IVO_Suite.Properties.Resources.Search_16x16;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(382, 22);
            this.toolStripLabel2.Text = "Pesquisa efectudada nos campos Artigo, Cod. UP e Referência Antiga";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(110, 22);
            this.toolStripLabel3.Text = "Pesquisa de Grupo";
            // 
            // txtGrupo
            // 
            this.txtGrupo.Name = "txtGrupo";
            this.txtGrupo.Size = new System.Drawing.Size(100, 25);
            this.txtGrupo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtGrupo_KeyDown);
            // 
            // btnSearchGrupo
            // 
            this.btnSearchGrupo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSearchGrupo.Image = global::IVO_Suite.Properties.Resources.Search_16x16;
            this.btnSearchGrupo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSearchGrupo.Name = "btnSearchGrupo";
            this.btnSearchGrupo.Size = new System.Drawing.Size(23, 22);
            this.btnSearchGrupo.Text = "toolStripButton2";
            this.btnSearchGrupo.Click += new System.EventHandler(this.btnSearchGrupo_Click);
            // 
            // dgvPesquisaGrupo
            // 
            this.dgvPesquisaGrupo.AllowUserToAddRows = false;
            this.dgvPesquisaGrupo.AllowUserToDeleteRows = false;
            this.dgvPesquisaGrupo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPesquisaGrupo.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvPesquisaGrupo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPesquisaGrupo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.artigo,
            this.upc,
            this.refantiga,
            this.descricao,
            this.cod,
            this.descGrupo,
            this.gecod});
            this.dgvPesquisaGrupo.Location = new System.Drawing.Point(0, 32);
            this.dgvPesquisaGrupo.Name = "dgvPesquisaGrupo";
            this.dgvPesquisaGrupo.ReadOnly = true;
            this.dgvPesquisaGrupo.RowHeadersVisible = false;
            this.dgvPesquisaGrupo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPesquisaGrupo.Size = new System.Drawing.Size(911, 507);
            this.dgvPesquisaGrupo.TabIndex = 1;
            this.dgvPesquisaGrupo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPesquisaGrupo_CellClick);
            this.dgvPesquisaGrupo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPesquisaGrupo_CellDoubleClick);
            // 
            // artigo
            // 
            this.artigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.artigo.HeaderText = "Artigo Embal";
            this.artigo.Name = "artigo";
            this.artigo.ReadOnly = true;
            this.artigo.Width = 101;
            // 
            // upc
            // 
            this.upc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.upc.HeaderText = "Cod. UPC";
            this.upc.Name = "upc";
            this.upc.ReadOnly = true;
            this.upc.Width = 80;
            // 
            // refantiga
            // 
            this.refantiga.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.refantiga.HeaderText = "Ref. Antiga";
            this.refantiga.Name = "refantiga";
            this.refantiga.ReadOnly = true;
            this.refantiga.Width = 89;
            // 
            // descricao
            // 
            this.descricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descricao.HeaderText = "Descrição Artigo";
            this.descricao.Name = "descricao";
            this.descricao.ReadOnly = true;
            // 
            // cod
            // 
            this.cod.HeaderText = "Cod. Grupo";
            this.cod.Name = "cod";
            this.cod.ReadOnly = true;
            // 
            // descGrupo
            // 
            this.descGrupo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descGrupo.HeaderText = "Descrição Grupo";
            this.descGrupo.Name = "descGrupo";
            this.descGrupo.ReadOnly = true;
            // 
            // gecod
            // 
            this.gecod.HeaderText = "gecod";
            this.gecod.Name = "gecod";
            this.gecod.ReadOnly = true;
            this.gecod.Visible = false;
            // 
            // PesquisaGrupo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 538);
            this.Controls.Add(this.dgvPesquisaGrupo);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PesquisaGrupo";
            this.Text = "Pesquisa Grupo";
            this.Load += new System.EventHandler(this.PesquisaGrupo_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPesquisaGrupo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox txtArtigo;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.DataGridView dgvPesquisaGrupo;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripTextBox txtGrupo;
        private System.Windows.Forms.ToolStripButton btnSearchGrupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn artigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn upc;
        private System.Windows.Forms.DataGridViewTextBoxColumn refantiga;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn cod;
        private System.Windows.Forms.DataGridViewTextBoxColumn descGrupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn gecod;
    }
}