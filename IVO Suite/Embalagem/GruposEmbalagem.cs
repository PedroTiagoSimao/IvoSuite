using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Data.Odbc;

namespace IVO_Suite.Embalagem
{
    public partial class GruposEmbalagem : Form
    {
        OdbcConnection cnn;
        DataSet dsMain;
        public int geId;
        public string strConn;
        public string strIdGrupo;
        public string sqlWhere;

        public GruposEmbalagem(string connectionString)
        {
            InitializeComponent();
            strConn = connectionString;
        }

        private void GruposEmbalagem_Load(object sender, EventArgs e)
        {
            cnn = new OdbcConnection(strConn);
            dsMain = new DataSet();
            sqlWhere = "";
            GetGE();
            txtSearch.Focus();
        }

        public void GetGE()
        {
            dgvGE.Rows.Clear();
            string SQL = "SELECT g.id,g.GECOD,g.GEDESCR,g.GETIPO,g.GEPESS,g.GEPCHR, "+
                    @"(select count(*) from _IVO_ComposicaoGE where idGrupo=g.GECOD), g.COD "+
                    @"FROM _IVO_GruposEmbalagem AS g "+ sqlWhere +" ORDER BY g.id,g.GECOD ";
            OdbcCommand cmd = new OdbcCommand(SQL, cnn);
            OdbcDataReader dr;
            if (cnn.State == ConnectionState.Closed) cnn.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    dgvGE.Rows.Add(dr[0], dr[1], dr[7], dr[2], dr[3], dr[4], dr[5], dr[6]);
                }
            }
            dr.Close();
            cnn.Close();
        }

        private void Procurar()
        {
            sqlWhere = " WHERE g.GEDESCR LIKE '%" + txtSearch.Text + "%' OR G.COD LIKE '%" + txtSearch.Text + "%' ";
            GetGE();
        }

        private void dgvGE_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewCell cid = dgvGE.Rows[e.RowIndex].Cells["gecod"];
                DataGridViewCell id = dgvGE.Rows[e.RowIndex].Cells["id"];
                geId = Convert.ToInt32(cid.Value);
                strIdGrupo = id.Value.ToString();
            }
        }

        private void dgvGE_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            CompGruposEmbalagem cge = new CompGruposEmbalagem(geId, strConn, this);
            cge.MdiParent = this.MdiParent;
            cge.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddGrupo_Click(object sender, EventArgs e)
        {
            Addgrupo ag = new Addgrupo(strConn, this, "insert", "");
            ag.MdiParent = this.MdiParent;
            ag.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string sql0 = "SELECT distinct c.numdoc, c.serie FROM _IVO_LinhasGE as l left join CabecDoc as c on l.numdoc=c.id where l.grupo=" + geId;
            string sql1 = "DELETE FROM _IVO_ComposicaoGE WHERE idGrupo=" + geId;
            string sql2 = "DELETE FROM _IVO_GruposEmbalagem WHERE GECOD=" + geId;
            string strEncs = "";
            OdbcConnection cn = new OdbcConnection(strConn);
            OdbcCommand cm = new OdbcCommand(sql0, cn);
            cn.Open();
            OdbcDataReader dr = cm.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    strEncs = strEncs + dr[0].ToString() + "-" + dr[1].ToString() + "; ";
                }

                MessageBox.Show("Existem artigos associados a este grupo de embalagem. Não é possivel eliminar.\nEncomenda(s): " + strEncs, "Impossivel eliminar");
            }
            else
            {
                OdbcCommand cmd;
                try
                {
                    if (cnn.State == ConnectionState.Closed) cnn.Open();
                    cmd = new OdbcCommand(sql1, cnn);
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                }
                catch (OdbcException oe)
                {
                    MessageBox.Show(oe.Message, "Erro ao eliminar componentes do grupo");
                }

                try
                {
                    if (cnn.State == ConnectionState.Closed) cnn.Open();
                    cmd = new OdbcCommand(sql2, cnn);
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                }
                catch (OdbcException oe)
                {
                    MessageBox.Show(oe.Message, "Erro ao eliminar grupo");
                }

                GetGE();
            }   
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Addgrupo ag = new Addgrupo(strConn, this, "edit", strIdGrupo);
            ag.MdiParent = this.MdiParent;
            ag.Show();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Procurar();
        }

        private void _KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Procurar();
            }
        }
    }
}
