namespace IVO_Suite.Embalagem
{
    partial class PlanearEmbalamento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlanearEmbalamento));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnPlanoEmbalamento = new System.Windows.Forms.ToolStripButton();
            this.btnPrint = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvLinhasPlano = new System.Windows.Forms.DataGridView();
            this.eId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.enumdoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ecodbarras = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.erefivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.edataentrega = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.edataplano = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCabecDoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvEncomendas = new System.Windows.Forms.DataGridView();
            this.dgvEncMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnDetalhesEncomenda = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCopy2Plano = new System.Windows.Forms.Button();
            this.btnDeleteFromPlano = new System.Windows.Forms.Button();
            this.cmbPlanoEmbalamento = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNumPlano = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numdoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codbarras = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.refIvo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataentrega = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCabec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtEnc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtEntrege = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtPendente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLinhasPlano)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEncomendas)).BeginInit();
            this.dgvEncMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPlanoEmbalamento,
            this.btnPrint});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(952, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnPlanoEmbalamento
            // 
            this.btnPlanoEmbalamento.Image = global::IVO_Suite.Properties.Resources.Add_16x16;
            this.btnPlanoEmbalamento.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPlanoEmbalamento.Name = "btnPlanoEmbalamento";
            this.btnPlanoEmbalamento.Size = new System.Drawing.Size(128, 22);
            this.btnPlanoEmbalamento.Text = "Criar/Editar Plano";
            this.btnPlanoEmbalamento.ToolTipText = "Criar / Editar Planos";
            this.btnPlanoEmbalamento.Click += new System.EventHandler(this.btnPlanoEmbalamento_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPrint.Image = global::IVO_Suite.Properties.Resources.Print_16x16;
            this.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(23, 22);
            this.btnPrint.Text = "Imprimir";
            this.btnPrint.ToolTipText = "Imprimir plano seleccionado";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.Controls.Add(this.dgvLinhasPlano, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgvEncomendas, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnCopy2Plano, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnDeleteFromPlano, 1, 1);
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 68);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(928, 384);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // dgvLinhasPlano
            // 
            this.dgvLinhasPlano.AllowUserToAddRows = false;
            this.dgvLinhasPlano.AllowUserToDeleteRows = false;
            this.dgvLinhasPlano.AllowUserToOrderColumns = true;
            this.dgvLinhasPlano.ColumnHeadersHeight = 35;
            this.dgvLinhasPlano.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.eId,
            this.enumdoc,
            this.ecodbarras,
            this.erefivo,
            this.edataentrega,
            this.edataplano,
            this.idCabecDoc});
            this.dgvLinhasPlano.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLinhasPlano.Location = new System.Drawing.Point(578, 3);
            this.dgvLinhasPlano.Name = "dgvLinhasPlano";
            this.dgvLinhasPlano.ReadOnly = true;
            this.dgvLinhasPlano.RowHeadersVisible = false;
            this.tableLayoutPanel1.SetRowSpan(this.dgvLinhasPlano, 2);
            this.dgvLinhasPlano.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLinhasPlano.Size = new System.Drawing.Size(347, 378);
            this.dgvLinhasPlano.TabIndex = 1;
            this.dgvLinhasPlano.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLinhasPlano_CellClick);
            this.dgvLinhasPlano.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEncomendas_CellDoubleClick);
            // 
            // eId
            // 
            this.eId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.eId.HeaderText = "id";
            this.eId.Name = "eId";
            this.eId.ReadOnly = true;
            this.eId.Visible = false;
            // 
            // enumdoc
            // 
            this.enumdoc.HeaderText = "NumDoc";
            this.enumdoc.Name = "enumdoc";
            this.enumdoc.ReadOnly = true;
            this.enumdoc.Width = 60;
            // 
            // ecodbarras
            // 
            this.ecodbarras.HeaderText = "CodBarras";
            this.ecodbarras.Name = "ecodbarras";
            this.ecodbarras.ReadOnly = true;
            this.ecodbarras.Width = 70;
            // 
            // erefivo
            // 
            this.erefivo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.erefivo.HeaderText = "Ref";
            this.erefivo.Name = "erefivo";
            this.erefivo.ReadOnly = true;
            // 
            // edataentrega
            // 
            this.edataentrega.HeaderText = "Data Entrega";
            this.edataentrega.Name = "edataentrega";
            this.edataentrega.ReadOnly = true;
            this.edataentrega.Width = 70;
            // 
            // edataplano
            // 
            this.edataplano.HeaderText = "Adic. Plano";
            this.edataplano.Name = "edataplano";
            this.edataplano.ReadOnly = true;
            this.edataplano.Width = 70;
            // 
            // idCabecDoc
            // 
            this.idCabecDoc.HeaderText = "idCabecDoc";
            this.idCabecDoc.Name = "idCabecDoc";
            this.idCabecDoc.ReadOnly = true;
            this.idCabecDoc.Visible = false;
            // 
            // dgvEncomendas
            // 
            this.dgvEncomendas.AllowUserToAddRows = false;
            this.dgvEncomendas.AllowUserToDeleteRows = false;
            this.dgvEncomendas.AllowUserToOrderColumns = true;
            this.dgvEncomendas.ColumnHeadersHeight = 35;
            this.dgvEncomendas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.numdoc,
            this.codbarras,
            this.refIvo,
            this.dataentrega,
            this.idCabec,
            this.QtEnc,
            this.QtEntrege,
            this.QtPendente});
            this.dgvEncomendas.ContextMenuStrip = this.dgvEncMenuStrip;
            this.dgvEncomendas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEncomendas.Location = new System.Drawing.Point(3, 3);
            this.dgvEncomendas.Name = "dgvEncomendas";
            this.dgvEncomendas.ReadOnly = true;
            this.dgvEncomendas.RowHeadersVisible = false;
            this.tableLayoutPanel1.SetRowSpan(this.dgvEncomendas, 2);
            this.dgvEncomendas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEncomendas.Size = new System.Drawing.Size(523, 378);
            this.dgvEncomendas.TabIndex = 0;
            this.dgvEncomendas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEncomendas_CellClick);
            this.dgvEncomendas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEncomendas_CellDoubleClick);
            // 
            // dgvEncMenuStrip
            // 
            this.dgvEncMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDetalhesEncomenda});
            this.dgvEncMenuStrip.Name = "dgvEncMenuStrip";
            this.dgvEncMenuStrip.Size = new System.Drawing.Size(201, 26);
            // 
            // btnDetalhesEncomenda
            // 
            this.btnDetalhesEncomenda.Name = "btnDetalhesEncomenda";
            this.btnDetalhesEncomenda.Size = new System.Drawing.Size(200, 22);
            this.btnDetalhesEncomenda.Text = "Detalhes da Encomenda";
            this.btnDetalhesEncomenda.Click += new System.EventHandler(this.btnDetalhesEncomenda_Click);
            // 
            // btnCopy2Plano
            // 
            this.btnCopy2Plano.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnCopy2Plano.Location = new System.Drawing.Point(532, 3);
            this.btnCopy2Plano.Name = "btnCopy2Plano";
            this.btnCopy2Plano.Size = new System.Drawing.Size(40, 40);
            this.btnCopy2Plano.TabIndex = 2;
            this.btnCopy2Plano.Text = ">>";
            this.toolTip1.SetToolTip(this.btnCopy2Plano, "Adicionar linhas ao plano");
            this.btnCopy2Plano.UseVisualStyleBackColor = false;
            this.btnCopy2Plano.Click += new System.EventHandler(this.btnCopy2Plano_Click);
            // 
            // btnDeleteFromPlano
            // 
            this.btnDeleteFromPlano.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnDeleteFromPlano.Location = new System.Drawing.Point(532, 50);
            this.btnDeleteFromPlano.Name = "btnDeleteFromPlano";
            this.btnDeleteFromPlano.Size = new System.Drawing.Size(40, 40);
            this.btnDeleteFromPlano.TabIndex = 3;
            this.btnDeleteFromPlano.Text = "<<";
            this.toolTip1.SetToolTip(this.btnDeleteFromPlano, "Remover linhas do plano");
            this.btnDeleteFromPlano.UseVisualStyleBackColor = false;
            this.btnDeleteFromPlano.Click += new System.EventHandler(this.btnDeleteFromPlano_Click);
            // 
            // cmbPlanoEmbalamento
            // 
            this.cmbPlanoEmbalamento.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbPlanoEmbalamento.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPlanoEmbalamento.FormattingEnabled = true;
            this.cmbPlanoEmbalamento.Location = new System.Drawing.Point(124, 28);
            this.cmbPlanoEmbalamento.Name = "cmbPlanoEmbalamento";
            this.cmbPlanoEmbalamento.Size = new System.Drawing.Size(202, 23);
            this.cmbPlanoEmbalamento.TabIndex = 2;
            this.cmbPlanoEmbalamento.SelectedIndexChanged += new System.EventHandler(this.cmbEmbalamento_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(853, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nº Plano:";
            // 
            // lblNumPlano
            // 
            this.lblNumPlano.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNumPlano.AutoSize = true;
            this.lblNumPlano.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumPlano.Location = new System.Drawing.Point(912, 50);
            this.lblNumPlano.Name = "lblNumPlano";
            this.lblNumPlano.Size = new System.Drawing.Size(28, 15);
            this.lblNumPlano.TabIndex = 4;
            this.lblNumPlano.Text = "888";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Encomendas Pendentes";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Seleccionar Plano";
            // 
            // id
            // 
            this.id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            this.id.Width = 43;
            // 
            // numdoc
            // 
            this.numdoc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.numdoc.HeaderText = "NumDoc";
            this.numdoc.MinimumWidth = 50;
            this.numdoc.Name = "numdoc";
            this.numdoc.ReadOnly = true;
            this.numdoc.Width = 50;
            // 
            // codbarras
            // 
            this.codbarras.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.codbarras.HeaderText = "CodBarras";
            this.codbarras.MinimumWidth = 55;
            this.codbarras.Name = "codbarras";
            this.codbarras.ReadOnly = true;
            this.codbarras.Width = 55;
            // 
            // refIvo
            // 
            this.refIvo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.refIvo.HeaderText = "Ref";
            this.refIvo.Name = "refIvo";
            this.refIvo.ReadOnly = true;
            // 
            // dataentrega
            // 
            this.dataentrega.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataentrega.HeaderText = "Data Entrega";
            this.dataentrega.Name = "dataentrega";
            this.dataentrega.ReadOnly = true;
            this.dataentrega.Width = 94;
            // 
            // idCabec
            // 
            this.idCabec.HeaderText = "idCabec";
            this.idCabec.Name = "idCabec";
            this.idCabec.ReadOnly = true;
            this.idCabec.Visible = false;
            // 
            // QtEnc
            // 
            this.QtEnc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.QtEnc.HeaderText = "Enc";
            this.QtEnc.MinimumWidth = 35;
            this.QtEnc.Name = "QtEnc";
            this.QtEnc.ReadOnly = true;
            this.QtEnc.Width = 35;
            // 
            // QtEntrege
            // 
            this.QtEntrege.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.QtEntrege.HeaderText = "Satisf";
            this.QtEntrege.MinimumWidth = 35;
            this.QtEntrege.Name = "QtEntrege";
            this.QtEntrege.ReadOnly = true;
            this.QtEntrege.Width = 35;
            // 
            // QtPendente
            // 
            this.QtPendente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.QtPendente.HeaderText = "Pend";
            this.QtPendente.MinimumWidth = 35;
            this.QtPendente.Name = "QtPendente";
            this.QtPendente.ReadOnly = true;
            this.QtPendente.Width = 35;
            // 
            // PlanearEmbalamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 464);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.lblNumPlano);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbPlanoEmbalamento);
            this.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PlanearEmbalamento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Planeador de Embalamento";
            this.Load += new System.EventHandler(this.PlanearEmbalamento_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLinhasPlano)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEncomendas)).EndInit();
            this.dgvEncMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnPlanoEmbalamento;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnCopy2Plano;
        private System.Windows.Forms.Button btnDeleteFromPlano;
        private System.Windows.Forms.DataGridView dgvEncomendas;
        private System.Windows.Forms.ComboBox cmbPlanoEmbalamento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNumPlano;
        private System.Windows.Forms.DataGridView dgvLinhasPlano;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ContextMenuStrip dgvEncMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem btnDetalhesEncomenda;
        private System.Windows.Forms.ToolStripButton btnPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn eId;
        private System.Windows.Forms.DataGridViewTextBoxColumn enumdoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn ecodbarras;
        private System.Windows.Forms.DataGridViewTextBoxColumn erefivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn edataentrega;
        private System.Windows.Forms.DataGridViewTextBoxColumn edataplano;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCabecDoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn numdoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn codbarras;
        private System.Windows.Forms.DataGridViewTextBoxColumn refIvo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataentrega;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCabec;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtEnc;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtEntrege;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtPendente;
    }
}