using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Odbc;
using System.Data.SqlClient;

namespace IVO_Suite.Embalagem
{
    public partial class CompGruposEmbalagem : Form
    {
        public int geId;
        public string strConn;
        int idArtigo;
        OdbcConnection cnn;
        GruposEmbalagem ge;
        SqlConnection sqlCnn;

        public CompGruposEmbalagem(int GrupoEmbalagem, string ConnectionString, GruposEmbalagem frmGruposEmbalagem)
        {
            InitializeComponent();
            geId = GrupoEmbalagem;
            strConn = ConnectionString;
            ge = frmGruposEmbalagem;
        }

        private void CompGruposEmbalagem_Load(object sender, EventArgs e)
        {
            cnn = new OdbcConnection(strConn);
            sqlCnn = new SqlConnection("Data Source=SVR\\LP750;Initial Catalog=PRIEIC;User Id=sa;Password=sapassword;");
            GetGrupoDetails();
            getArtigos();
        }

        public void GetGrupoDetails()
        {
            string SQL = "SELECT * FROM _IVO_GruposEmbalagem WHERE GECOD=" + geId.ToString();
            OdbcCommand cmd = new OdbcCommand(SQL, cnn);
            if (cnn.State == ConnectionState.Closed) cnn.Open();
            OdbcDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    this.Text = dr[6].ToString() + "-" + dr[2].ToString();
                }
            }
            dr.Close();
            cnn.Close();
        }

        public void getArtigos()
        {
            dgvCGE.Rows.Clear();
            string SQL = "SELECT a.artigo, a.descricao, S.Descricao, G.quant, G.id, G.Obs, a.CDU_REFANTIGA FROM (ARTIGO AS A LEFT JOIN [_IVO_ComposicaoGE] AS G ON G.idArtigo=A.Artigo) LEFT JOIN SubFamilias AS S ON S.SubFamilia=A.SubFamilia WHERE G.idGrupo=" + geId;
            OdbcCommand cmd = new OdbcCommand(SQL, cnn);
            if (cnn.State == ConnectionState.Closed) cnn.Open();
            OdbcDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    dgvCGE.Rows.Add(dr[0], dr[6], dr[1], dr[2], dr[3], dr[5], dr[4]);
                }
            }
            dr.Close();
            cnn.Close();

            //ge.GetGE();
        }

        public void SaveGrupo()
        {
            OdbcCommand delete = new OdbcCommand("DELETE FROM _IVO_ComposicaoGE WHERE idGrupo=" + geId, cnn);
            cnn.Open();
            delete.ExecuteNonQuery();
            cnn.Close();

            foreach (DataGridViewRow row in dgvCGE.Rows)
            {
                string strQuant = row.Cells["quant"].Value.ToString();
                strQuant = strQuant.Replace(",", ".");

                string sql = "INSERT INTO _IVO_ComposicaoGE (idArtigo,idGrupo, quant, obs) VALUES " +
                    @"('" + row.Cells["artigo"].Value.ToString() + "'," +
                    @"" + geId + ", " + strQuant + "," +
                    @"'" + row.Cells["obs"].Value.ToString() + "')";
                SqlCommand insert = new SqlCommand(sql, sqlCnn);
                sqlCnn.Open();
                insert.ExecuteNonQuery();
                sqlCnn.Close();
            }

            getArtigos();
        }

        private void DeleteArtigo()
        {
            try
            {

                OdbcCommand delete = new OdbcCommand("DELETE FROM _IVO_ComposicaoGE WHERE id=" + idArtigo, cnn);
                cnn.Open();
                delete.ExecuteNonQuery();
                cnn.Close();
            }
            catch (OdbcException oe)
            {
                MessageBox.Show(oe.Message, "Erro ao eliminar artigo.");
            }

            getArtigos();
        }

        private void btnAddArtigo_Click(object sender, EventArgs e)
        {
            AddArtigo aa = new AddArtigo(geId, strConn, this);
            aa.MdiParent = this.MdiParent;
            aa.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveGrupo();
        }

        private void dgvCGE_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewCell aId = dgvCGE.Rows[e.RowIndex].Cells["id"];
                idArtigo = Convert.ToInt32(aId.Value);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteArtigo();
        }
    }
}
