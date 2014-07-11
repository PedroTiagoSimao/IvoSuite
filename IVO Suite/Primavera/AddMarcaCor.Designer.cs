namespace IVO_Suite.Primavera
{
    partial class AddMarcaCor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddMarcaCor));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtRefForn = new System.Windows.Forms.TextBox();
            this.lblRefForn = new System.Windows.Forms.Label();
            this.txtPantone = new System.Windows.Forms.TextBox();
            this.lblPantone = new System.Windows.Forms.Label();
            this.lblObs = new System.Windows.Forms.Label();
            this.txtObs = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "Código";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(91, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "Descrição";
            // 
            // txtCodigo
            // 
            this.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigo.Location = new System.Drawing.Point(15, 33);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(73, 22);
            this.txtCodigo.TabIndex = 3;
            // 
            // txtDescricao
            // 
            this.txtDescricao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescricao.Location = new System.Drawing.Point(94, 33);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(239, 22);
            this.txtDescricao.TabIndex = 4;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Image = global::IVO_Suite.Properties.Resources.Cancel_24x24;
            this.btnClose.Location = new System.Drawing.Point(293, 162);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(40, 43);
            this.btnClose.TabIndex = 5;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Image = global::IVO_Suite.Properties.Resources.Check_24x24;
            this.btnSave.Location = new System.Drawing.Point(247, 162);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(40, 43);
            this.btnSave.TabIndex = 6;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtRefForn
            // 
            this.txtRefForn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRefForn.Location = new System.Drawing.Point(15, 126);
            this.txtRefForn.Name = "txtRefForn";
            this.txtRefForn.Size = new System.Drawing.Size(136, 22);
            this.txtRefForn.TabIndex = 7;
            // 
            // lblRefForn
            // 
            this.lblRefForn.AutoSize = true;
            this.lblRefForn.Location = new System.Drawing.Point(12, 109);
            this.lblRefForn.Name = "lblRefForn";
            this.lblRefForn.Size = new System.Drawing.Size(89, 14);
            this.lblRefForn.TabIndex = 8;
            this.lblRefForn.Text = "Ref Fornecedor";
            // 
            // txtPantone
            // 
            this.txtPantone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPantone.Location = new System.Drawing.Point(163, 126);
            this.txtPantone.Name = "txtPantone";
            this.txtPantone.Size = new System.Drawing.Size(170, 22);
            this.txtPantone.TabIndex = 9;
            // 
            // lblPantone
            // 
            this.lblPantone.AutoSize = true;
            this.lblPantone.Location = new System.Drawing.Point(160, 109);
            this.lblPantone.Name = "lblPantone";
            this.lblPantone.Size = new System.Drawing.Size(52, 14);
            this.lblPantone.TabIndex = 10;
            this.lblPantone.Text = "Pantone";
            // 
            // lblObs
            // 
            this.lblObs.AutoSize = true;
            this.lblObs.Location = new System.Drawing.Point(12, 64);
            this.lblObs.Name = "lblObs";
            this.lblObs.Size = new System.Drawing.Size(76, 14);
            this.lblObs.TabIndex = 11;
            this.lblObs.Text = "Observações";
            // 
            // txtObs
            // 
            this.txtObs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtObs.Location = new System.Drawing.Point(15, 81);
            this.txtObs.Name = "txtObs";
            this.txtObs.Size = new System.Drawing.Size(318, 22);
            this.txtObs.TabIndex = 12;
            // 
            // AddMarcaCor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 217);
            this.Controls.Add(this.txtObs);
            this.Controls.Add(this.lblObs);
            this.Controls.Add(this.lblPantone);
            this.Controls.Add(this.txtPantone);
            this.Controls.Add(this.lblRefForn);
            this.Controls.Add(this.txtRefForn);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddMarcaCor";
            this.Text = "AddMarcaCor";
            this.Load += new System.EventHandler(this.AddMarcaCor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtRefForn;
        private System.Windows.Forms.Label lblRefForn;
        private System.Windows.Forms.TextBox txtPantone;
        private System.Windows.Forms.Label lblPantone;
        private System.Windows.Forms.Label lblObs;
        private System.Windows.Forms.TextBox txtObs;
    }
}