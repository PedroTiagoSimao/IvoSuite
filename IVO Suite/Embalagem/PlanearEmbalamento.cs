using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;

namespace IVO_Suite.Embalagem
{
    public partial class PlanearEmbalamento : Form
    {
        SqlConnection cnn;
        SqlCommand cmd;
        SqlDataReader dr;
        int idPlano;
        string strConn;
        string odbcConn;
        string sqlQuery;
        string idCDoc; //ID do cabeçalho da Encomenda

        public PlanearEmbalamento(string SqlConnectionString, string ODBCConnectionString)
        {
            InitializeComponent();
            strConn = SqlConnectionString;
            odbcConn = ODBCConnectionString;
        }

        private void PlanearEmbalamento_Load(object sender, EventArgs e)
        {
            cnn = new SqlConnection(strConn);
            GetPlanosEmbalamento();
            GetLinhasEncomenda();
            lblNumPlano.Text = "";
        }

        public void GetPlanosEmbalamento()
        {
            sqlQuery = "Select * from _IVO_PlanoEmbalamento where aberto=1";
            ArrayList pEmbal = new ArrayList();
            cmd = new SqlCommand(sqlQuery, cnn);
            if (cnn.State == ConnectionState.Closed) cnn.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    pEmbal.Add(new  IVO.AddValue(dr[1] + " | " + dr[2] + " | " + dr[3], dr[1].ToString()));
                }
            }
            dr.Close();
            cnn.Close();

            cmbPlanoEmbalamento.DataSource = pEmbal;
            if (pEmbal.Count > 0)
            {
                cmbPlanoEmbalamento.DisplayMember = "Display";
                cmbPlanoEmbalamento.ValueMember = "Value";
            }

        }

        private void GetLinhasPlano(int idPlano)
        {
            string dEntrega = "";
            string dPlano = "";
            dgvLinhasPlano.Rows.Clear();
            sqlQuery = "select C.NumDoc, C.Serie, A.CodBarras, L.Artigo, L.DataEntrega, L.id as idLinha, I.dataplano, I.idCabecDoc from " +
                @"((LinhasDoc as L left join Artigo as A on A.Artigo=L.Artigo) " +
                @"left join CabecDoc as C on C.Id=L.IdCabecDoc) " +
                @"left join _IVO_LinhasPlanoEmbalamento as I on I.idLinhaDoc=L.Id " +
                @"where L.Artigo is not null and A.ArtigoPai is not null and C.TipoDoc='ECL' " +
                @"and L.id=I.idLinhaDoc and I.idPlano='" + idPlano + "'";

            cmd = new SqlCommand(sqlQuery, cnn);
            if (cnn.State == ConnectionState.Closed) cnn.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    dPlano = dr[6].ToString();
                    dPlano = dPlano.Substring(0, 10);
                    dEntrega = dr[4].ToString();
                    dEntrega = dEntrega.Substring(0, 10);
                    dgvLinhasPlano.Rows.Add(dr[5], dr[0] + " | " + dr[1], dr[2], dr[3], dEntrega, dPlano, dr[7]);
                }
            }
            dr.Close();
            cnn.Close();
        }

        private void GetLinhasEncomenda()
        {
            string dEntrega = "";
            dgvEncomendas.Rows.Clear();

            sqlQuery = "select C.NumDoc, C.Serie, A.CodBarras, L.Artigo, L.DataEntrega, L.id as idLinha, C.ID, S.Quantidade, S.QuantTrans, (S.Quantidade-S.QuantTrans) as Pendente from " +
                @"((LinhasDoc as L left join Artigo as A on A.Artigo=L.Artigo) " +
                @"left join CabecDoc as C on C.Id=L.IdCabecDoc) " +
                @"left join LinhasDocStatus as S on S.IdLinhasDoc = L.id " +
                @"where L.Artigo is not null "+
                @"  and A.CodBarras is not null "+
                @"  and C.TipoDoc='ECL' "+
                @"  and (S.Quantidade-S.QuantTrans)>0 " +
                //Apenas linhas de doc SEM plano de embalamento [REMOVI PARA PODER MOSTRAR LINHAS PENDENTES]
                //@"and L.Id not in (select idLinhaDoc from _IVO_LinhasPlanoEmbalamento) "+
                @"ORDER BY C.Serie DESC, C.NumDoc DESC";

            cmd = new SqlCommand(sqlQuery, cnn);
            if (cnn.State == ConnectionState.Closed) cnn.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    dEntrega = dr[4].ToString();
                    dEntrega = dEntrega.Substring(0, 10);
                    dgvEncomendas.Rows.Add(dr[5], dr[0] + " | " + dr[1], dr[2], dr[3], dEntrega, dr[6], dr[7], dr[8], dr[9]);
                }
            }
            dr.Close();
            cnn.Close();
        }

        private void CopyLinha2Plano(string idPlano, string idLinhaDoc, string idCabecDoc)
        {
            sqlQuery = "INSERT INTO _IVO_LinhasPlanoEmbalamento (idPlano, idLinhaDoc, dataplano, idCabecDoc) VALUES " +
                @"('" + idPlano + "','" + idLinhaDoc + "', GetDate(), '" + idCabecDoc + "')";
            cmd = new SqlCommand(sqlQuery, cnn);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException se)
            {
                MessageBox.Show(se.Message, "Erro ao adicionar linha ao plano", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteLinhaFromPlano(string idPlano, string idLinhaDoc)
        {
            sqlQuery = "DELETE FROM _IVO_LinhasPlanoEmbalamento WHERE idLinhaDoc='" + idLinhaDoc + "' AND idPlano='" + idPlano + "'";
            cmd = new SqlCommand(sqlQuery, cnn);
            
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException se)
            {
                MessageBox.Show(se.Message, "Erro ao eliminar linha do plano", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool VerifyEmbalLinha(string idLinhaDoc)
        {
            sqlQuery = "Select * from _IVO_LinhasGE where idLinhaDoc='" + idLinhaDoc + "'";
            cmd = new SqlCommand(sqlQuery, cnn);
            if (cnn.State == ConnectionState.Closed) cnn.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Close();
                cnn.Close();
                return true;
            }
            else
            {
                dr.Close();
                cnn.Close();
                return false;
            }
        }

        private void ExecuteLinha(DataGridView selectedDGV)
        {
            if (selectedDGV.Name == "dgvEncomendas")
            {
                
                foreach (DataGridViewRow row in selectedDGV.SelectedRows)
                {
                    DataGridViewCell idLinha = row.Cells["id"];
                    DataGridViewCell artg = row.Cells["codbarras"];
                    DataGridViewCell idCabecC = row.Cells["idCabec"];
                    //if (VerifyEmbalLinha(idLinha.Value.ToString()))
                    //{
                        if (cnn.State == ConnectionState.Closed) cnn.Open();
                        CopyLinha2Plano(idPlano.ToString(), idLinha.Value.ToString(), idCabecC.Value.ToString());
                        cnn.Close();
                   // }
                   // else
                    //{
                    //    MessageBox.Show("A linha do artigo [" + artg.Value.ToString() + "] não tem embalagem definida.\nNão é permitido adicionar linhas a um plano sem antes definir os artigos de embalagem.", "Erro ao adicionar linha", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   // }

                }
                cnn.Close();

                GetLinhasEncomenda();
                GetLinhasPlano(idPlano);
                
            }

            if (selectedDGV.Name == "dgvLinhasPlano")
            {
                if (cnn.State == ConnectionState.Closed) cnn.Open();
                foreach (DataGridViewRow row in selectedDGV.SelectedRows)
                {
                    DataGridViewCell idLinha = row.Cells["eid"];
                    DeleteLinhaFromPlano(idPlano.ToString(), idLinha.Value.ToString());
                }
                cnn.Close();

                GetLinhasEncomenda();
                GetLinhasPlano(idPlano);
            }
        }

        private void cmbEmbalamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPlanoEmbalamento.SelectedValue.ToString() != "IVO_Suite.IVO+AddValue")
            {
                idPlano = Convert.ToInt32(cmbPlanoEmbalamento.SelectedValue.ToString());
                GetLinhasPlano(idPlano);
                lblNumPlano.Text = idPlano.ToString();
            }
        }

        private void btnPlanoEmbalamento_Click(object sender, EventArgs e)
        {
            PlanosEmbalamento pe = new PlanosEmbalamento(strConn, this);
            pe.MdiParent = this.MdiParent;
            pe.Show();
        }

        private void btnCopy2Plano_Click(object sender, EventArgs e)
        {
            if (idPlano > 0) ExecuteLinha(dgvEncomendas);
        }

        private void btnDeleteFromPlano_Click(object sender, EventArgs e)
        {
            if (idPlano > 0) ExecuteLinha(dgvLinhasPlano);
        }

        private void btnDetalhesEncomenda_Click(object sender, EventArgs e)
        {
            Encomendas.DetalheEncomenda de = new Encomendas.DetalheEncomenda(odbcConn, idCDoc);
            de.MdiParent = this.MdiParent;
            de.Show();
        }

        private void dgvEncomendas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewCell idC = dgvEncomendas.Rows[e.RowIndex].Cells["idCabec"];
                idCDoc = idC.Value.ToString();
            }
        }

        private void dgvEncomendas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Encomendas.DetalheEncomenda de = new Encomendas.DetalheEncomenda(odbcConn, idCDoc);
            de.MdiParent = this.MdiParent;
            de.Show();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (lblNumPlano.Text != "")
            {
                Necessidades n = new Necessidades(odbcConn, idPlano.ToString());
                n.MdiParent = this.MdiParent;
                n.Show();
            }
        }

        private void dgvLinhasPlano_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewCell idC = dgvLinhasPlano.Rows[e.RowIndex].Cells["idCabecDoc"];
                idCDoc = idC.Value.ToString();
            }
        }
    }
}
