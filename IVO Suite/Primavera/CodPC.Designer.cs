namespace IVO_Suite.Primavera
{
    partial class CodPC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CodPC));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.txtFamilia = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.txtSubFamilia = new System.Windows.Forms.ToolStripTextBox();
            this.btnSearch = new System.Windows.Forms.ToolStripButton();
            this.btnApplyPC = new System.Windows.Forms.ToolStripButton();
            this.txtSufixo = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.btnSelectAll = new System.Windows.Forms.ToolStripButton();
            this.dgvArt = new System.Windows.Forms.DataGridView();
            this.check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sfam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.txtFamilia,
            this.toolStripSeparator1,
            this.toolStripLabel2,
            this.txtSubFamilia,
            this.btnSearch,
            this.btnApplyPC,
            this.txtSufixo,
            this.toolStripLabel3,
            this.btnSelectAll});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(802, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(49, 22);
            this.toolStripLabel1.Text = "Familia";
            // 
            // txtFamilia
            // 
            this.txtFamilia.Name = "txtFamilia";
            this.txtFamilia.Size = new System.Drawing.Size(100, 25);
            this.txtFamilia.Text = "PA";
            this.txtFamilia.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtArtigo_KeyDown);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(73, 22);
            this.toolStripLabel2.Text = "Sub-Familia";
            // 
            // txtSubFamilia
            // 
            this.txtSubFamilia.Name = "txtSubFamilia";
            this.txtSubFamilia.Size = new System.Drawing.Size(100, 25);
            this.txtSubFamilia.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSubFamilia_keyDown);
            // 
            // btnSearch
            // 
            this.btnSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSearch.Image = global::IVO_Suite.Properties.Resources.Check_16x16;
            this.btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(23, 22);
            this.btnSearch.Text = "toolStripButton1";
            this.btnSearch.ToolTipText = "Procurar";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnApplyPC
            // 
            this.btnApplyPC.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnApplyPC.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnApplyPC.Image = global::IVO_Suite.Properties.Resources.Check_16x16;
            this.btnApplyPC.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnApplyPC.Name = "btnApplyPC";
            this.btnApplyPC.Size = new System.Drawing.Size(23, 22);
            this.btnApplyPC.Text = "toolStripButton2";
            this.btnApplyPC.ToolTipText = "Aplicar";
            this.btnApplyPC.Click += new System.EventHandler(this.btnApplyPC_Click);
            // 
            // txtSufixo
            // 
            this.txtSufixo.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.txtSufixo.Name = "txtSufixo";
            this.txtSufixo.Size = new System.Drawing.Size(100, 25);
            this.txtSufixo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodPC_KeyDown);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(40, 22);
            this.toolStripLabel3.Text = "Sufixo";
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSelectAll.Image = ((System.Drawing.Image)(resources.GetObject("btnSelectAll.Image")));
            this.btnSelectAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(104, 22);
            this.btnSelectAll.Text = "Seleccionar Tudo";
            // 
            // dgvArt
            // 
            this.dgvArt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvArt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArt.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.check,
            this.id,
            this.pc,
            this.desc,
            this.fam,
            this.sfam});
            this.dgvArt.Location = new System.Drawing.Point(12, 44);
            this.dgvArt.Name = "dgvArt";
            this.dgvArt.RowHeadersVisible = false;
            this.dgvArt.Size = new System.Drawing.Size(778, 407);
            this.dgvArt.TabIndex = 1;
            // 
            // check
            // 
            this.check.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.check.HeaderText = "";
            this.check.Name = "check";
            this.check.Width = 21;
            // 
            // id
            // 
            this.id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.id.HeaderText = "Referência";
            this.id.Name = "id";
            this.id.Width = 91;
            // 
            // pc
            // 
            this.pc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.pc.HeaderText = "Referência Comercial";
            this.pc.Name = "pc";
            this.pc.Width = 135;
            // 
            // desc
            // 
            this.desc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.desc.HeaderText = "Descrição";
            this.desc.Name = "desc";
            // 
            // fam
            // 
            this.fam.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.fam.HeaderText = "Familia";
            this.fam.Name = "fam";
            this.fam.Width = 74;
            // 
            // sfam
            // 
            this.sfam.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.sfam.HeaderText = "Sub-Familia";
            this.sfam.Name = "sfam";
            this.sfam.Width = 98;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "Lista de Artigos";
            // 
            // CodPC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 464);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvArt);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CodPC";
            this.Text = "Definir Código PC";
            this.Load += new System.EventHandler(this.CodPC_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox txtFamilia;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox txtSubFamilia;
        private System.Windows.Forms.ToolStripButton btnSearch;
        private System.Windows.Forms.ToolStripButton btnApplyPC;
        private System.Windows.Forms.ToolStripTextBox txtSufixo;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.DataGridView dgvArt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripButton btnSelectAll;
        private System.Windows.Forms.DataGridViewCheckBoxColumn check;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn pc;
        private System.Windows.Forms.DataGridViewTextBoxColumn desc;
        private System.Windows.Forms.DataGridViewTextBoxColumn fam;
        private System.Windows.Forms.DataGridViewTextBoxColumn sfam;
    }
}