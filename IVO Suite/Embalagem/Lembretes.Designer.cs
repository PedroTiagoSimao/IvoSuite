namespace IVO_Suite.Embalagem
{
    partial class Lembretes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Lembretes));
            this.dgvLembretes = new System.Windows.Forms.DataGridView();
            this.data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.enc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.obs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLembretes)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLembretes
            // 
            this.dgvLembretes.ColumnHeadersHeight = 21;
            this.dgvLembretes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvLembretes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.data,
            this.cliente,
            this.enc,
            this.obs});
            this.dgvLembretes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLembretes.Location = new System.Drawing.Point(0, 0);
            this.dgvLembretes.Name = "dgvLembretes";
            this.dgvLembretes.RowHeadersVisible = false;
            this.dgvLembretes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLembretes.Size = new System.Drawing.Size(611, 212);
            this.dgvLembretes.TabIndex = 0;
            // 
            // data
            // 
            this.data.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.data.HeaderText = "Data";
            this.data.Name = "data";
            this.data.Width = 55;
            // 
            // cliente
            // 
            this.cliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cliente.HeaderText = "Cliente";
            this.cliente.Name = "cliente";
            this.cliente.Width = 66;
            // 
            // enc
            // 
            this.enc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.enc.HeaderText = "Encomenda";
            this.enc.Name = "enc";
            this.enc.Width = 87;
            // 
            // obs
            // 
            this.obs.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.obs.HeaderText = "Observações";
            this.obs.Name = "obs";
            // 
            // Lembretes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 212);
            this.Controls.Add(this.dgvLembretes);
            this.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Lembretes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Lembretes";
            this.Load += new System.EventHandler(this.Lembretes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLembretes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLembretes;
        private System.Windows.Forms.DataGridViewTextBoxColumn data;
        private System.Windows.Forms.DataGridViewTextBoxColumn cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn enc;
        private System.Windows.Forms.DataGridViewTextBoxColumn obs;
    }
}