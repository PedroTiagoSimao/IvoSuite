using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace IVO_Suite.Embalagem
{
    public partial class PesquisaGrupo : Form
    {
        SqlConnection cnn;
        SqlCommand cmd;
        SqlDataReader dr;
        public string strconn;
        public int intGeCod;

        public PesquisaGrupo(string ConnectionString)
        {
            strconn = ConnectionString;
            InitializeComponent();
        }

        private void PesquisaGrupo_Load(object sender, EventArgs e)
        {
            cnn = new SqlConnection(strconn);
            txtArtigo.Focus();
        }

        private void SearchArtigo(string StrArtigo)
        {
            dgvPesquisaGrupo.Rows.Clear();

            string sql = "select _IVO_ComposicaoGE.idArtigo, _IVO_GruposEmbalagem.COD, "+
                @"_IVO_GruposEmbalagem.GEDESCR, Artigo.CodBarras, "+
                @"Artigo.CDU_REFANTIGA, Artigo.Descricao, _IVO_GruposEmbalagem.GECOD "+
                @"from (_IVO_GruposEmbalagem "+
                    @"left join _IVO_ComposicaoGE on _IVO_ComposicaoGE.idGrupo=_IVO_GruposEmbalagem.GECOD) " +
                @"left join Artigo on Artigo.Artigo=_IVO_ComposicaoGE.idArtigo " +
                @"where _IVO_ComposicaoGE.idArtigo LIKE '%" + StrArtigo + "%' OR Artigo.CodBarras LIKE '%" + StrArtigo + "%' "+
                @"OR Artigo.CDU_REFANTIGA LIKE '%" + StrArtigo + "%'";

            cmd = new SqlCommand(sql, cnn);
            cnn.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    dgvPesquisaGrupo.Rows.Add(dr[0], dr[3], dr[4], dr[5], dr[1], dr[2], dr[6]);
                }
            }
            dr.Close();
            cnn.Close();
        }

        private void txtArtigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchArtigo(txtArtigo.Text);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            SearchArtigo(txtArtigo.Text);

        }

        private void dgvPesquisaGrupo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewCell cellGeCod = dgvPesquisaGrupo.Rows[e.RowIndex].Cells["gecod"];
                intGeCod = Convert.ToInt32(cellGeCod.Value);
            }
        }

        private void dgvPesquisaGrupo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            GruposEmbalagem ge = new GruposEmbalagem("DSN=Primavera;Uid=sa;pwd=sapassword");
            ge.MdiParent = this.MdiParent;
            ge.Show();

            CompGruposEmbalagem cge = new CompGruposEmbalagem(intGeCod, "DSN=Primavera;Uid=sa;pwd=sapassword", ge);
            cge.MdiParent = ge.MdiParent;
            cge.Show();
        }

        private void btnSearchGrupo_Click(object sender, EventArgs e)
        {
            SearchGrupo(txtGrupo.Text);
        }

        private void SearchGrupo(string StrGrupo)
        {
            dgvPesquisaGrupo.Rows.Clear();

            string sql = "select _IVO_ComposicaoGE.idArtigo, _IVO_GruposEmbalagem.COD, _IVO_GruposEmbalagem.GEDESCR, Artigo.CodBarras, " +
                @"Artigo.CDU_REFANTIGA, Artigo.Descricao, _IVO_GruposEmbalagem.GECOD from (_IVO_GruposEmbalagem left join _IVO_ComposicaoGE on _IVO_ComposicaoGE.idGrupo=_IVO_GruposEmbalagem.GECOD) " +
                @"left join Artigo on Artigo.Artigo=_IVO_ComposicaoGE.idArtigo " +
                @"where _IVO_GruposEmbalagem.COD LIKE '%" + StrGrupo + "%' OR _IVO_GruposEmbalagem.GEDESCR LIKE '%" + StrGrupo + "%' " +
                @"ORDER BY _IVO_GruposEmbalagem.COD";

            cmd = new SqlCommand(sql, cnn);
            cnn.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    dgvPesquisaGrupo.Rows.Add(dr[0], dr[3], dr[4], dr[5], dr[1], dr[2], dr[6]);
                }
            }
            dr.Close();
            cnn.Close();
        }

        private void txtGrupo_KeyDown(object sender, KeyEventArgs e)
        {
            SearchGrupo(txtGrupo.Text);
        }
    }
}
