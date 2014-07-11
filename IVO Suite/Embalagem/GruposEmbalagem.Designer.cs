namespace IVO_Suite.Embalagem
{
    partial class GruposEmbalagem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GruposEmbalagem));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.btnAddGrupo = new System.Windows.Forms.ToolStripButton();
            this.dgvGE = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gecod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.getipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gepess = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gepchr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qttArtigos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.txtSearch = new System.Windows.Forms.ToolStripTextBox();
            this.btnSearch = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGE)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.toolStripButton1,
            this.btnAddGrupo,
            this.txtSearch,
            this.btnSearch});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(676, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.ToolTipText = "Fechar";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // btnAddGrupo
            // 
            this.btnAddGrupo.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnAddGrupo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddGrupo.Image = ((System.Drawing.Image)(resources.GetObject("btnAddGrupo.Image")));
            this.btnAddGrupo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddGrupo.Name = "btnAddGrupo";
            this.btnAddGrupo.Size = new System.Drawing.Size(23, 22);
            this.btnAddGrupo.Text = "toolStripButton2";
            this.btnAddGrupo.ToolTipText = "Adicionar Grupo";
            this.btnAddGrupo.Click += new System.EventHandler(this.btnAddGrupo_Click);
            // 
            // dgvGE
            // 
            this.dgvGE.AllowUserToAddRows = false;
            this.dgvGE.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.MenuBar;
            this.dgvGE.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvGE.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dgvGE.ColumnHeadersHeight = 35;
            this.dgvGE.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.gecod,
            this.cod,
            this.descr,
            this.getipo,
            this.gepess,
            this.gepchr,
            this.qttArtigos});
            this.dgvGE.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvGE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGE.Location = new System.Drawing.Point(0, 25);
            this.dgvGE.Name = "dgvGE";
            this.dgvGE.ReadOnly = true;
            this.dgvGE.RowHeadersVisible = false;
            this.dgvGE.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGE.Size = new System.Drawing.Size(676, 402);
            this.dgvGE.TabIndex = 1;
            this.dgvGE.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGE_CellClick);
            this.dgvGE.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGE_CellDoubleClick);
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // gecod
            // 
            this.gecod.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.gecod.HeaderText = "Num";
            this.gecod.Name = "gecod";
            this.gecod.ReadOnly = true;
            this.gecod.Width = 54;
            // 
            // cod
            // 
            this.cod.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cod.HeaderText = "Cod";
            this.cod.Name = "cod";
            this.cod.ReadOnly = true;
            this.cod.Width = 51;
            // 
            // descr
            // 
            this.descr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descr.HeaderText = "Descrição";
            this.descr.Name = "descr";
            this.descr.ReadOnly = true;
            // 
            // getipo
            // 
            this.getipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.getipo.HeaderText = "Tipo";
            this.getipo.Name = "getipo";
            this.getipo.ReadOnly = true;
            this.getipo.Visible = false;
            this.getipo.Width = 53;
            // 
            // gepess
            // 
            this.gepess.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.gepess.HeaderText = "Pess?";
            this.gepess.Name = "gepess";
            this.gepess.ReadOnly = true;
            this.gepess.Visible = false;
            this.gepess.Width = 61;
            // 
            // gepchr
            // 
            this.gepchr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.gepchr.HeaderText = "pcHr?";
            this.gepchr.Name = "gepchr";
            this.gepchr.ReadOnly = true;
            this.gepchr.Visible = false;
            this.gepchr.Width = 61;
            // 
            // qttArtigos
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.qttArtigos.DefaultCellStyle = dataGridViewCellStyle4;
            this.qttArtigos.HeaderText = "Nº de Artigos";
            this.qttArtigos.Name = "qttArtigos";
            this.qttArtigos.ReadOnly = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnEdit,
            this.btnDelete});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(122, 48);
            // 
            // btnEdit
            // 
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(121, 22);
            this.btnEdit.Text = "Editar";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(121, 22);
            this.btnDelete.Text = "Eliminar";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(56, 22);
            this.toolStripLabel2.Text = "Procurar";
            // 
            // txtSearch
            // 
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(100, 25);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this._KeyDown);
            // 
            // btnSearch
            // 
            this.btnSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSearch.Image = global::IVO_Suite.Properties.Resources.Search_16x16;
            this.btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(23, 22);
            this.btnSearch.Text = "toolStripButton2";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // GruposEmbalagem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 427);
            this.Controls.Add(this.dgvGE);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GruposEmbalagem";
            this.Text = "Grupos Embalagem";
            this.Load += new System.EventHandler(this.GruposEmbalagem_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGE)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.DataGridView dgvGE;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton btnAddGrupo;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnDelete;
        private System.Windows.Forms.ToolStripMenuItem btnEdit;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn gecod;
        private System.Windows.Forms.DataGridViewTextBoxColumn cod;
        private System.Windows.Forms.DataGridViewTextBoxColumn descr;
        private System.Windows.Forms.DataGridViewTextBoxColumn getipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn gepess;
        private System.Windows.Forms.DataGridViewTextBoxColumn gepchr;
        private System.Windows.Forms.DataGridViewTextBoxColumn qttArtigos;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox txtSearch;
        private System.Windows.Forms.ToolStripButton btnSearch;
    }
}