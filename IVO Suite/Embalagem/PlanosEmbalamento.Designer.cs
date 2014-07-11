namespace IVO_Suite.Embalagem
{
    partial class PlanosEmbalamento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlanosEmbalamento));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.cmbEditPlano = new System.Windows.Forms.ToolStripComboBox();
            this.txtnPlano = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSemana = new System.Windows.Forms.TextBox();
            this.txtAno = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnGravar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.chkOpen = new System.Windows.Forms.CheckBox();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.cmbEditPlano});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(337, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(79, 22);
            this.toolStripLabel1.Text = "Editar Plano Nº";
            // 
            // cmbEditPlano
            // 
            this.cmbEditPlano.Name = "cmbEditPlano";
            this.cmbEditPlano.Size = new System.Drawing.Size(150, 25);
            this.cmbEditPlano.Text = "Seleccionar Nº do Plano";
            this.cmbEditPlano.SelectedIndexChanged += new System.EventHandler(this.cmbEditPlano_SelectedIndexChanged);
            // 
            // txtnPlano
            // 
            this.txtnPlano.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtnPlano.Location = new System.Drawing.Point(12, 46);
            this.txtnPlano.Name = "txtnPlano";
            this.txtnPlano.Size = new System.Drawing.Size(60, 20);
            this.txtnPlano.TabIndex = 1;
            this.txtnPlano.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtnPlano_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nº Plano";
            // 
            // txtSemana
            // 
            this.txtSemana.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSemana.Location = new System.Drawing.Point(84, 46);
            this.txtSemana.Name = "txtSemana";
            this.txtSemana.Size = new System.Drawing.Size(80, 20);
            this.txtSemana.TabIndex = 3;
            this.txtSemana.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSemana_KeyDown);
            // 
            // txtAno
            // 
            this.txtAno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAno.Location = new System.Drawing.Point(176, 46);
            this.txtAno.Name = "txtAno";
            this.txtAno.Size = new System.Drawing.Size(80, 20);
            this.txtAno.TabIndex = 4;
            this.txtAno.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAno_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(85, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Semana";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(179, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Ano";
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Image = global::IVO_Suite.Properties.Resources.Remove_24x24;
            this.btnDelete.Location = new System.Drawing.Point(104, 81);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(40, 40);
            this.btnDelete.TabIndex = 10;
            this.toolTip1.SetToolTip(this.btnDelete, "Eliminar plano seleccionado");
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnGravar
            // 
            this.btnGravar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGravar.BackColor = System.Drawing.SystemColors.Control;
            this.btnGravar.Image = global::IVO_Suite.Properties.Resources.Check_24x24;
            this.btnGravar.Location = new System.Drawing.Point(58, 81);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(40, 40);
            this.btnGravar.TabIndex = 9;
            this.toolTip1.SetToolTip(this.btnGravar, "Gravar");
            this.btnGravar.UseVisualStyleBackColor = false;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancelar.Image = global::IVO_Suite.Properties.Resources.Cancel_24x24;
            this.btnCancelar.Location = new System.Drawing.Point(285, 81);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(40, 40);
            this.btnCancelar.TabIndex = 8;
            this.toolTip1.SetToolTip(this.btnCancelar, "Fechar");
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNovo.BackColor = System.Drawing.SystemColors.Control;
            this.btnNovo.Image = global::IVO_Suite.Properties.Resources.Add_24x24;
            this.btnNovo.Location = new System.Drawing.Point(12, 81);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(40, 40);
            this.btnNovo.TabIndex = 7;
            this.btnNovo.Text = ".";
            this.toolTip1.SetToolTip(this.btnNovo, "Criar Plano Novo");
            this.btnNovo.UseVisualStyleBackColor = false;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // chkOpen
            // 
            this.chkOpen.AutoSize = true;
            this.chkOpen.Checked = true;
            this.chkOpen.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOpen.Location = new System.Drawing.Point(268, 47);
            this.chkOpen.Name = "chkOpen";
            this.chkOpen.Size = new System.Drawing.Size(57, 17);
            this.chkOpen.TabIndex = 11;
            this.chkOpen.Text = "Aberto";
            this.chkOpen.UseVisualStyleBackColor = true;
            // 
            // PlanosEmbalamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 133);
            this.Controls.Add(this.chkOpen);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAno);
            this.Controls.Add(this.txtSemana);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtnPlano);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(345, 160);
            this.MinimumSize = new System.Drawing.Size(345, 160);
            this.Name = "PlanosEmbalamento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Plano de Embalamento";
            this.Load += new System.EventHandler(this.PlanosEmbalamento_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox cmbEditPlano;
        private System.Windows.Forms.TextBox txtnPlano;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSemana;
        private System.Windows.Forms.TextBox txtAno;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox chkOpen;
    }
}