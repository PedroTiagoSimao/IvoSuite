namespace IVO_Suite.Embalagem
{
    partial class CompGruposEmbalagem
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompGruposEmbalagem));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.btnAddArtigo = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.dgvCGE = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.artigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.refantiga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subfam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.obs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCGE)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnClose,
            this.btnAddArtigo,
            this.toolStripLabel1,
            this.btnSave});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(893, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnClose
            // 
            this.btnClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnClose.Image = global::IVO_Suite.Properties.Resources.Remove_16x16;
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(23, 22);
            this.btnClose.Text = "Fechar";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAddArtigo
            // 
            this.btnAddArtigo.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnAddArtigo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddArtigo.Image = global::IVO_Suite.Properties.Resources.Open_16x16;
            this.btnAddArtigo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddArtigo.Name = "btnAddArtigo";
            this.btnAddArtigo.Size = new System.Drawing.Size(23, 22);
            this.btnAddArtigo.Text = "Inserir Artigos";
            this.btnAddArtigo.Click += new System.EventHandler(this.btnAddArtigo_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(382, 22);
            this.toolStripLabel1.Text = "Apenas estão disponiveis os artigos da familia de Embalagem \'EMB\'";
            // 
            // btnSave
            // 
            this.btnSave.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSave.Image = global::IVO_Suite.Properties.Resources.Save_32x32;
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(23, 22);
            this.btnSave.Text = "Guardar Quantidades";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgvCGE
            // 
            this.dgvCGE.AllowUserToAddRows = false;
            this.dgvCGE.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgvCGE.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCGE.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dgvCGE.ColumnHeadersHeight = 35;
            this.dgvCGE.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.artigo,
            this.refantiga,
            this.descr,
            this.subfam,
            this.quant,
            this.obs,
            this.id});
            this.dgvCGE.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvCGE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCGE.Location = new System.Drawing.Point(0, 25);
            this.dgvCGE.Name = "dgvCGE";
            this.dgvCGE.RowHeadersVisible = false;
            this.dgvCGE.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCGE.Size = new System.Drawing.Size(893, 469);
            this.dgvCGE.TabIndex = 1;
            this.dgvCGE.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCGE_CellClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDelete});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(122, 26);
            // 
            // btnDelete
            // 
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(121, 22);
            this.btnDelete.Text = "Eliminar";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // artigo
            // 
            this.artigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.artigo.HeaderText = "Artigo";
            this.artigo.Name = "artigo";
            this.artigo.Width = 64;
            // 
            // refantiga
            // 
            this.refantiga.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.refantiga.HeaderText = "Ref. Antiga";
            this.refantiga.Name = "refantiga";
            this.refantiga.Width = 84;
            // 
            // descr
            // 
            this.descr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descr.HeaderText = "Descrição";
            this.descr.Name = "descr";
            // 
            // subfam
            // 
            this.subfam.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.subfam.HeaderText = "Sub-Familia";
            this.subfam.Name = "subfam";
            this.subfam.Width = 98;
            // 
            // quant
            // 
            this.quant.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle2.Format = "N3";
            dataGridViewCellStyle2.NullValue = null;
            this.quant.DefaultCellStyle = dataGridViewCellStyle2;
            this.quant.HeaderText = "Quant";
            this.quant.Name = "quant";
            this.quant.Width = 65;
            // 
            // obs
            // 
            this.obs.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.obs.HeaderText = "Obs.";
            this.obs.Name = "obs";
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.Visible = false;
            // 
            // CompGruposEmbalagem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 494);
            this.Controls.Add(this.dgvCGE);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CompGruposEmbalagem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CompGruposEmbalagem";
            this.Load += new System.EventHandler(this.CompGruposEmbalagem_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCGE)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.DataGridView dgvCGE;
        private System.Windows.Forms.ToolStripButton btnAddArtigo;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn artigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn refantiga;
        private System.Windows.Forms.DataGridViewTextBoxColumn descr;
        private System.Windows.Forms.DataGridViewTextBoxColumn subfam;
        private System.Windows.Forms.DataGridViewTextBoxColumn quant;
        private System.Windows.Forms.DataGridViewTextBoxColumn obs;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
    }
}