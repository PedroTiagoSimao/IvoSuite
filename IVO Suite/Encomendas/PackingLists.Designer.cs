namespace IVO_Suite.Encomendas
{
    partial class PackingLists
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PackingLists));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsBtnAddPL = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.txtSearch = new System.Windows.Forms.ToolStripTextBox();
            this.tsBtnSearch = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.tsCmbReports = new System.Windows.Forms.ToolStripComboBox();
            this.tsBtnPrintPackingList = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.dgvPackingList = new System.Windows.Forms.DataGridView();
            this.uid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ano = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datacriacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsDgvPackingList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnDeletePackingList = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPackingList)).BeginInit();
            this.cmsDgvPackingList.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnAddPL,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.txtSearch,
            this.tsBtnSearch,
            this.toolStripSeparator2,
            this.toolStripLabel2,
            this.tsCmbReports,
            this.tsBtnPrintPackingList,
            this.toolStripSeparator3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(892, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsBtnAddPL
            // 
            this.tsBtnAddPL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnAddPL.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnAddPL.Image")));
            this.tsBtnAddPL.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnAddPL.Name = "tsBtnAddPL";
            this.tsBtnAddPL.Size = new System.Drawing.Size(23, 22);
            this.tsBtnAddPL.Text = "&New";
            this.tsBtnAddPL.Click += new System.EventHandler(this.tsBtnAddPL_Click_1);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(140, 22);
            this.toolStripLabel1.Text = "Procurar Nº Packing List";
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(85, 25);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // tsBtnSearch
            // 
            this.tsBtnSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnSearch.Image = global::IVO_Suite.Properties.Resources.Search_16x16;
            this.tsBtnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSearch.Name = "tsBtnSearch";
            this.tsBtnSearch.Size = new System.Drawing.Size(23, 22);
            this.tsBtnSearch.Text = "toolStripButton3";
            this.tsBtnSearch.Click += new System.EventHandler(this.tsBtnSearch_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(194, 22);
            this.toolStripLabel2.Text = "Imprimir Packing List selecionado";
            // 
            // tsCmbReports
            // 
            this.tsCmbReports.AutoCompleteCustomSource.AddRange(new string[] {
            "PT Ref IVO",
            "PT Ref Cliente",
            "EN Ref IVO",
            "EN Ref Cliente"});
            this.tsCmbReports.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsCmbReports.Name = "tsCmbReports";
            this.tsCmbReports.Size = new System.Drawing.Size(140, 25);
            this.tsCmbReports.Text = "PT Ref IVO";
            // 
            // tsBtnPrintPackingList
            // 
            this.tsBtnPrintPackingList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnPrintPackingList.Image = global::IVO_Suite.Properties.Resources.Print_16x16;
            this.tsBtnPrintPackingList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnPrintPackingList.Name = "tsBtnPrintPackingList";
            this.tsBtnPrintPackingList.Size = new System.Drawing.Size(23, 22);
            this.tsBtnPrintPackingList.Text = "Imprimir";
            this.tsBtnPrintPackingList.Click += new System.EventHandler(this.tsBtnPrintPackingList_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // dgvPackingList
            // 
            this.dgvPackingList.AllowUserToAddRows = false;
            this.dgvPackingList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvPackingList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPackingList.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvPackingList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPackingList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.uid,
            this.numero,
            this.ano,
            this.fact,
            this.cliente,
            this.data,
            this.datacriacao});
            this.dgvPackingList.ContextMenuStrip = this.cmsDgvPackingList;
            this.dgvPackingList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPackingList.Location = new System.Drawing.Point(0, 25);
            this.dgvPackingList.Name = "dgvPackingList";
            this.dgvPackingList.ReadOnly = true;
            this.dgvPackingList.RowHeadersVisible = false;
            this.dgvPackingList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPackingList.Size = new System.Drawing.Size(892, 598);
            this.dgvPackingList.TabIndex = 1;
            this.dgvPackingList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPackingList_CellClick);
            this.dgvPackingList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPackingList_CellDoubleClick);
            // 
            // uid
            // 
            this.uid.HeaderText = "uid";
            this.uid.Name = "uid";
            this.uid.ReadOnly = true;
            this.uid.Visible = false;
            // 
            // numero
            // 
            this.numero.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.numero.DefaultCellStyle = dataGridViewCellStyle2;
            this.numero.HeaderText = "Nº";
            this.numero.Name = "numero";
            this.numero.ReadOnly = true;
            this.numero.Width = 45;
            // 
            // ano
            // 
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.ano.DefaultCellStyle = dataGridViewCellStyle3;
            this.ano.HeaderText = "Ano";
            this.ano.Name = "ano";
            this.ano.ReadOnly = true;
            // 
            // fact
            // 
            this.fact.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.fact.HeaderText = "Factura";
            this.fact.Name = "fact";
            this.fact.ReadOnly = true;
            this.fact.Width = 74;
            // 
            // cliente
            // 
            this.cliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cliente.HeaderText = "Cliente";
            this.cliente.Name = "cliente";
            this.cliente.ReadOnly = true;
            // 
            // data
            // 
            this.data.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle4.Format = "d";
            dataGridViewCellStyle4.NullValue = null;
            this.data.DefaultCellStyle = dataGridViewCellStyle4;
            this.data.HeaderText = "Data de Expedição";
            this.data.Name = "data";
            this.data.ReadOnly = true;
            this.data.Width = 122;
            // 
            // datacriacao
            // 
            dataGridViewCellStyle5.Format = "d";
            dataGridViewCellStyle5.NullValue = null;
            this.datacriacao.DefaultCellStyle = dataGridViewCellStyle5;
            this.datacriacao.HeaderText = "Data de Criação";
            this.datacriacao.Name = "datacriacao";
            this.datacriacao.ReadOnly = true;
            // 
            // cmsDgvPackingList
            // 
            this.cmsDgvPackingList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDeletePackingList});
            this.cmsDgvPackingList.Name = "cmsDgvPackingList";
            this.cmsDgvPackingList.Size = new System.Drawing.Size(180, 26);
            // 
            // btnDeletePackingList
            // 
            this.btnDeletePackingList.Name = "btnDeletePackingList";
            this.btnDeletePackingList.Size = new System.Drawing.Size(179, 22);
            this.btnDeletePackingList.Text = "Eliminar Packing List";
            this.btnDeletePackingList.Click += new System.EventHandler(this.btnDeletePackingList_Click);
            // 
            // PackingLists
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 623);
            this.Controls.Add(this.dgvPackingList);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PackingLists";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Packing Lists";
            this.Load += new System.EventHandler(this.PackingLists_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PackingLists_KeyDown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPackingList)).EndInit();
            this.cmsDgvPackingList.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox txtSearch;
        private System.Windows.Forms.ToolStripButton tsBtnSearch;
        private System.Windows.Forms.DataGridView dgvPackingList;
        private System.Windows.Forms.ToolStripButton tsBtnAddPL;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ContextMenuStrip cmsDgvPackingList;
        private System.Windows.Forms.ToolStripMenuItem btnDeletePackingList;
        private System.Windows.Forms.ToolStripButton tsBtnPrintPackingList;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripComboBox tsCmbReports;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn uid;
        private System.Windows.Forms.DataGridViewTextBoxColumn numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn ano;
        private System.Windows.Forms.DataGridViewTextBoxColumn fact;
        private System.Windows.Forms.DataGridViewTextBoxColumn cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn data;
        private System.Windows.Forms.DataGridViewTextBoxColumn datacriacao;
    }
}