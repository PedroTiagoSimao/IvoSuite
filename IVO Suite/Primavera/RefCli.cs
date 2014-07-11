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
    public partial class RefCli : Form
    {
        public string strConn;
        public string strSql;
        public bool ArtigoExists;
        public string strCliente;
        public string strArtigo;
        public string strArtigoIvo;

        SqlConnection cnn;
        SqlDataReader dr;
        SqlCommand cmd;

        public RefCli(string strConnection)
        {
            InitializeComponent();
            strConn = strConnection;
        }

        private void RefCli_Load(object sender, EventArgs e)
        {
            cnn = new SqlConnection(strConn);
            //GetReferences();
        }

        private void GetReferences()
        {
            strSql = "SELECT CODBARRAS, DESCRICAO FROM ARTIGO WHERE CODBARRAS IS NOT NULL";
            cmd = new SqlCommand(strSql, cnn);
            cnn.Open();
            dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    cmbRefIvo.ComboBox.Items.Add(dr[0].ToString());
                }
            }

            dr.Close();
            cnn.Close();

        }

        public void GetArtigo(string Artigo)
        {

            strSql = "select Artigo.Artigo, Artigo.Descricao, Artigo.Familia, Artigo.SubFamilia " +
                @"from Artigo " +
                @"where Artigo.CodBarras='" + Artigo + "'";

            cmd = new SqlCommand(strSql, cnn);
            cnn.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    strArtigoIvo = dr[0].ToString();
                    txtArtigo.Text = strArtigoIvo;
                    txtDescrição.Text = dr[1].ToString();
                    txtFamilia.Text = dr[2].ToString();
                    txtSubFamilia.Text = dr[3].ToString();
                    ArtigoExists = true;
                }
            }
            else
            {
                ArtigoExists = false;
            }
            dr.Close();

            strSql = "select ArtigoCliente.Cliente, ArtigoCliente.ReferenciaCli, ArtigoCliente.DescricaoCli, " +
                @"ArtigoCliente.CDU_GrupoEmbalagem, ArtigoCliente.CDU_CodBarras, ArtigoCliente.CDU_TipoRotulo, CDU_Rotlingua, " +
                @"CDU_PecasInner, CDU_PecasMaster, CDU_TipoCodBarras, GE.GEDESCR " +
                @"from Artigo left join ArtigoCliente on ArtigoCliente.Artigo=Artigo.Artigo " +
                @"left join _IVO_GruposEmbalagem as GE on GE.COD=ArtigoCliente.CDU_GrupoEmbalagem "+
                @"where Artigo.CodBarras='" + Artigo + "'";

            cmd = new SqlCommand(strSql, cnn);
            dr = cmd.ExecuteReader();
            dgvRefCli.Rows.Clear();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    dgvRefCli.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[10], dr[9], dr[4], dr[5], dr[6], dr[7], dr[8]);
                }
            }
            cnn.Close();

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            GetArtigo(txtRef.Text);
        }

        private void btnAddRefCli_Click(object sender, EventArgs e)
        {
            if (ArtigoExists)
            {
                AddRefCli arc = new AddRefCli(strConn, "new", strArtigoIvo, "", this, txtRef.Text);
                arc.MdiParent = this.MdiParent;
                arc.Show();
            }
            else
            {
                MessageBox.Show("Falta seleccionar a referência Ivo, ou a\nreferênica seleccionada não existe!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbRefIvo.ComboBox.Focus();
                cmbRefIvo.ComboBox.BackColor = Color.Orange;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (strArtigo != null && strCliente != null)
            {
                AddRefCli arc = new AddRefCli(strConn, "edit", strArtigoIvo, strCliente, this, txtRef.Text);
                arc.MdiParent = this.MdiParent;
                arc.Show();
            }
            else
            {
                MessageBox.Show("Não há nada para editar!...", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvRefCli_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewCell dgvCliente = dgvRefCli.Rows[e.RowIndex].Cells["cliente"];
                strCliente = dgvCliente.Value.ToString();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (strArtigoIvo != null && strCliente != null)
            {
                if (MessageBox.Show("Deseja eliminar esta referência de cliente?", "Confirme", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    strSql = "Delete from ArtigoCliente where Artigo='" + strArtigoIvo + "' and Cliente='" + strCliente + "' ";
                    cmd = new SqlCommand(strSql, cnn);
                    try
                    {
                        if (cnn.State == ConnectionState.Closed) cnn.Open();
                        cmd.ExecuteNonQuery();
                        cnn.Close();
                        GetArtigo(strArtigo);
                    }
                    catch (SqlException se)
                    {
                        MessageBox.Show(se.ErrorCode + "\n" + se.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Não há nada para eliminar!...", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbRefIvo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cmbRefIvo.ComboBox.SelectedItem != null)
                {
                    strArtigo = cmbRefIvo.ComboBox.SelectedItem.ToString();
                    GetArtigo(strArtigo);
                }
                else
                {
                   MessageBox.Show("A referência seleccionada não existe!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRefreshRefs_Click(object sender, EventArgs e)
        {
            if (cmbRefIvo.ComboBox.SelectedItem != null)
            {
                strArtigo = cmbRefIvo.ComboBox.SelectedItem.ToString();
                GetArtigo(strArtigo);
            }
            else
            {
                MessageBox.Show("A referência seleccionada não existe!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvRefCli_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            AddRefCli arc = new AddRefCli(strConn, "edit", strArtigoIvo, strCliente, this, txtRef.Text);
            arc.MdiParent = this.MdiParent;
            arc.Show();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ArtigoExists)
            {
                AddRefCli arc = new AddRefCli(strConn, "new", strArtigoIvo, "", this, txtRef.Text);
                arc.MdiParent = this.MdiParent;
                arc.Show();
            }
            else
            {
                MessageBox.Show("Falta seleccionar a referência Ivo, ou a\nreferênica seleccionada não existe!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbRefIvo.ComboBox.Focus();
                cmbRefIvo.ComboBox.BackColor = Color.Orange;
            }
        }

        private void txtRef_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GetArtigo(txtRef.Text);
            }
        }

        private void RefCli_Shown(object sender, EventArgs e)
        {
            txtRef.Focus();
        }
    }
}
