using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace IVO_Suite.Primavera
{
    public partial class MarcasCores : Form
    {
        string strTabela;
        string strCodigo;
        string strDescricao;
        string strFormTitle;
        string strConn;
        string strSql;
        string strFilter;
        string strId;

        SqlConnection cnn;
        SqlCommand cmd;
        SqlDataReader dr;

        public MarcasCores(string Tabela, string ConnectionString)
        {
            InitializeComponent();
            strTabela = Tabela;
            strConn = ConnectionString;
        }

        private void DefineVariables(string Tabela)
        {
            if (Tabela == "_IVO_Cores")
            {
                strCodigo = "CodigoCor";
                strDescricao = "DescricaoCor";
                strFormTitle = "Cores Técnicas";
                dgvMarcaCor.Columns["reforn"].Visible = true;
                dgvMarcaCor.Columns["pantone"].Visible = true;
                dgvMarcaCor.Columns["obs"].Visible = true;
            }

            if (Tabela == "_IVO_Marcas")
            {
                strCodigo = "CodigoMarca";
                strDescricao = "DescricaoMarca";
                strFormTitle = "Marcas Técnicas";
                dgvMarcaCor.Columns["reforn"].Visible = false;
                dgvMarcaCor.Columns["pantone"].Visible = false;
                dgvMarcaCor.Columns["obs"].Visible = false;
            }
        }

        private void MarcasCores_Load(object sender, EventArgs e)
        {
            DefineVariables(strTabela);
            this.Text = strFormTitle;

            cnn = new SqlConnection(strConn);

            GetData(strTabela);
        }

        public void GetData(string Tabela)
        {
            if (txtCodigo.Text != "")
            {
                strFilter = " and " + strCodigo + " LIKE '%" + txtCodigo.Text + "%' ";
            }
            if (txtDescricao.Text != "")
            {
                strFilter = strFilter + " and " + strDescricao + " LIKE '%" + txtDescricao.Text + "%' ";
            }

            dgvMarcaCor.Rows.Clear();

            strSql = "SELECT id, " + strCodigo + ", " + strDescricao + ", Obs, RefForn, Pantone FROM " + Tabela + " WHERE ID>0 " + strFilter + " ORDER BY " + strCodigo + "";
            cmd = new SqlCommand(strSql, cnn);
            if (cnn.State == ConnectionState.Closed) cnn.Open();
            dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    dgvMarcaCor.Rows.Add(dr[1], dr[2], dr[3], dr[4], dr[5], dr[0]);
                }
            }
            dr.Close();
            cnn.Close();
            dgvMarcaCor.CurrentCell = dgvMarcaCor[0, dgvMarcaCor.Rows.Count - 1];
        }

        private void DeleteData(string strTabela)
        {
            if (MessageBox.Show("Deseja eliminar a linha seleccionada?", "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                strSql = "DELETE FROM " + strTabela + " WHERE ID=" + strId;
                cmd = new SqlCommand(strSql, cnn);
                try
                {
                    if (cnn.State == ConnectionState.Closed) cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                }
                catch (SqlException se)
                {
                    MessageBox.Show(se.Message, "Erro SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDescricao.Focus();
            }
        }

        private void txtDescricao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCodigo.Focus();
                strFilter = "";
                GetData(strTabela);
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            AddMarcaCor mc = new AddMarcaCor(strTabela, strConn, this, "");
            mc.MdiParent = this.MdiParent;
            mc.Show();
        }

        private void dgvMarcaCor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewCell cid = dgvMarcaCor.Rows[e.RowIndex].Cells["id"];
                strId = cid.Value.ToString();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteData(strTabela);
            GetData(strTabela);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            AddMarcaCor mc = new AddMarcaCor(strTabela, strConn, this, strId);
            mc.MdiParent = this.MdiParent;
            mc.Show();
        }

        private void dgvMarcaCor_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            AddMarcaCor mc = new AddMarcaCor(strTabela, strConn, this, strId);
            mc.MdiParent = this.MdiParent;
            mc.Show();
        }
    }
}
