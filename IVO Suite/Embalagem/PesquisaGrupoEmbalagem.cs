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
    public partial class PesquisaGrupoEmbalagem : Form
    {
        SqlConnection cnn;
        public string strConn;

        public PesquisaGrupoEmbalagem(string ConnectionString)
        {
            InitializeComponent();
            strConn = ConnectionString;
        }

        private void PesquisaGrupoEmbalagem_Load(object sender, EventArgs e)
        {
            cnn = new SqlConnection(strConn);
        }

        private void getGrupos()
        {
            dgvGrupo.Rows.Clear();
            string strSql = "select G.id, G.GECOD, G.GEDESCR, A.Artigo from ((_IVO_ComposicaoGE as C " +
                @"left join _IVO_GruposEmbalagem as G on C.idGrupo=G.GECOD) " +
                @"left join Artigo as A on A.Artigo=C.idArtigo) " +
                @"where A.CodBarras='" + txtArtigo.Text.ToString() + "' " +
                @"ORDER BY G.GECOD";

            SqlCommand cmd = new SqlCommand(strSql, cnn);
            if (cnn.State == ConnectionState.Closed) cnn.Open();
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    dgvGrupo.Rows.Add(dr[0], dr[1], dr[2]);
                    lblArtigo.Text = dr[3].ToString();
                }
            }
            dr.Close();
            cnn.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            getGrupos();
        }

        private void txtArtigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                getGrupos();
            }
        }
    }
}
