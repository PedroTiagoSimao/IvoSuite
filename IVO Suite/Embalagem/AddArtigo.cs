using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Odbc;

namespace IVO_Suite.Embalagem
{
    public partial class AddArtigo : Form
    {
        OdbcConnection cnn;
        OdbcConnection cnn2;
        public int geId;
        public string strConn;
        CompGruposEmbalagem CGE;
        string strSearch = "";

        public AddArtigo(int GrupoEmbalagem, string ConnectionString, CompGruposEmbalagem CompGe)
        {
            InitializeComponent();
            geId = GrupoEmbalagem;
            strConn = ConnectionString;
            CGE = CompGe;  
        }

        private void AddArtigo_Load(object sender, EventArgs e)
        {
            cnn = new OdbcConnection(strConn);
            cnn2 = new OdbcConnection(strConn);
            this.Text = "Artigos do Grupo " + geId.ToString();
            GetArtigos();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (strSearch != "")
            {
                strSearch = " and artigo like'%" + txtSearch.Text + "%' or descricao like '%" + txtSearch.Text + "%' or CDU_REFANTIGA like '%" + txtSearch.Text + "%'";
            }
            else
            {
                strSearch = "";
            }
            GetArtigos();
        }

        public void GetArtigos()
        {
            dgvArtigos.Rows.Clear();
            string sql = "select artigo, descricao, CDU_REFANTIGA from Artigo where FAMILIA='EMB' " + strSearch;
            OdbcCommand cmd = new OdbcCommand(sql, cnn);
            if (cnn.State == ConnectionState.Closed) cnn.Open();
            OdbcDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    dgvArtigos.Rows.Add(check(dr[0].ToString()), dr[0], dr[2], dr[1]);
                }
            }
            dr.Close();
            cnn.Close();
        }

        public bool check(string Artigo)
        {
            OdbcCommand c = new OdbcCommand("select id from [_IVO_ComposicaoGE] where idartigo='" + Artigo + "' and idGrupo=" + geId, cnn2);
            cnn2.Open();
            OdbcDataReader cr = c.ExecuteReader();
            if (cr.HasRows)
            {
                cr.Close();
                cnn2.Close();
                return true;
            }
            else
            {
                cr.Close();
                cnn2.Close();
                return false;
            }
        }

        private void dgvArtigos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewCell c = dgvArtigos.Rows[e.RowIndex].Cells["select"];
                DataGridViewCell a = dgvArtigos.Rows[e.RowIndex].Cells["artigo"];

                UpdateGrupo(c.Value.ToString(), a.Value.ToString(), geId);

            }
        }

        public void UpdateGrupo(string Action, string Artigo, int GrupoEmbalagem)
        {
            switch (Action)
            {
                case "False" :
                    DeleteArtigo(Artigo, GrupoEmbalagem);
                    ActualizaLista();
                    break;

                case "True" :
                    InsertArtigo(Artigo, GrupoEmbalagem);
                    ActualizaLista();
                    break;
            }
        }

        public void InsertArtigo(string Artigo, int GrupoEmbalagem)
        {
            string sql = "INSERT INTO _IVO_ComposicaoGE (idArtigo,idGrupo) VALUES " +
                @"('" + Artigo + "'," + GrupoEmbalagem + ")";
            OdbcCommand insert = new OdbcCommand(sql, cnn);
            cnn.Open();
            insert.ExecuteNonQuery();
            cnn.Close();
        }

        public void DeleteArtigo(string Artigo, int GrupoEmbalagem)
        {
            string sql = "DELETE FROM _IVO_ComposicaoGE WHERE " +
                @"idArtigo='" + Artigo + "' and idGrupo=" + GrupoEmbalagem;
            OdbcCommand insert = new OdbcCommand(sql, cnn);
            cnn.Open();
            insert.ExecuteNonQuery();
            cnn.Close();
        }

        public void ActualizaLista()
        {
            CGE.getArtigos();
        }

        private void btnAddArtigos_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
