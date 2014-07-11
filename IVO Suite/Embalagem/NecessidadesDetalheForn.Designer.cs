namespace IVO_Suite.Embalagem
{
    partial class NecessidadesDetalheForn
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NecessidadesDetalheForn));
            this.btnPrint = new System.Windows.Forms.ToolStrip();
            this.dgvDetalhe = new System.Windows.Forms.DataGridView();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.NumDoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Serie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fornecedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataDoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataEntrega = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Artigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Transformad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pendente = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            // dgvDetalhe
            // 
            this.dgvDetalhe.AllowUserToAddRows = false;
            this.dgvDetalhe.AllowUserToDeleteRows = false;
            this.dgvDetalhe.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetalhe.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDetalhe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalhe.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NumDoc,
            this.Serie,
            this.Fornecedor,
            this.DataDoc,
            this.DataEntrega,
            this.Artigo,
            this.UN,
            this.Quant,
            this.Transformad,
            this.Pendente});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetalhe.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDetalhe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetalhe.Location = new System.Drawing.Point(0, 25);
            this.dgvDetalhe.Name = "dgvDetalhe";
            this.dgvDetalhe.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetalhe.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDetalhe.RowHeadersVisible = false;
            this.dgvDetalhe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalhe.Size = new System.Drawing.Size(952, 409);
            this.dgvDetalhe.TabIndex = 1;
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
            // NumDoc
            // 
            this.NumDoc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.NumDoc.HeaderText = "NumDoc";
            this.NumDoc.Name = "NumDoc";
            this.NumDoc.ReadOnly = true;
            this.NumDoc.Width = 78;
            // 
            // Serie
            // 
            this.Serie.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Serie.HeaderText = "Série";
            this.Serie.Name = "Serie";
            this.Serie.ReadOnly = true;
            this.Serie.Width = 59;
            // 
            // Fornecedor
            // 
            this.Fornecedor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Fornecedor.HeaderText = "Fornecedor";
            this.Fornecedor.Name = "Fornecedor";
            this.Fornecedor.ReadOnly = true;
            this.Fornecedor.Width = 94;
            // 
            // DataDoc
            // 
            this.DataDoc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.DataDoc.HeaderText = "DataDoc";
            this.DataDoc.Name = "DataDoc";
            this.DataDoc.ReadOnly = true;
            this.DataDoc.Width = 79;
            // 
            // DataEntrega
            // 
            this.DataEntrega.HeaderText = "DataEntrega";
            this.DataEntrega.Name = "DataEntrega";
            this.DataEntrega.ReadOnly = true;
            // 
            // Artigo
            // 
            this.Artigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Artigo.HeaderText = "Artigo";
            this.Artigo.Name = "Artigo";
            this.Artigo.ReadOnly = true;
            // 
            // UN
            // 
            this.UN.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.UN.HeaderText = "UN";
            this.UN.Name = "UN";
            this.UN.ReadOnly = true;
            this.UN.Width = 48;
            // 
            // Quant
            // 
            this.Quant.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Quant.HeaderText = "Quant Encomenda";
            this.Quant.Name = "Quant";
            this.Quant.ReadOnly = true;
            this.Quant.Width = 121;
            // 
            // Transformad
            // 
            this.Transformad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Transformad.HeaderText = "Quant Satisfeita";
            this.Transformad.Name = "Transformad";
            this.Transformad.ReadOnly = true;
            this.Transformad.Width = 110;
            // 
            // Pendente
            // 
            this.Pendente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Pendente.HeaderText = "Quant. Pendente";
            this.Pendente.Name = "Pendente";
            this.Pendente.ReadOnly = true;
            this.Pendente.Width = 112;
            // 
            // NecessidadesDetalheForn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 434);
            this.Controls.Add(this.dgvDetalhe);
            this.Controls.Add(this.btnPrint);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NecessidadesDetalheForn";
            this.Text = "Detalhe Encomendas Fornecedor";
            this.Load += new System.EventHandler(this.NecessidadesDetalhe_Load);
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
        private System.Windows.Forms.DataGridViewTextBoxColumn NumDoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Serie;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fornecedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataDoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataEntrega;
        private System.Windows.Forms.DataGridViewTextBoxColumn Artigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn UN;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quant;
        private System.Windows.Forms.DataGridViewTextBoxColumn Transformad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pendente;
    }
}