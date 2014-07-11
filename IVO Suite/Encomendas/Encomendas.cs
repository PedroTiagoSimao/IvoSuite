using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Odbc;
using System.Collections;

namespace IVO_Suite.Encomendas
{
    public partial class Encomendas : Form
    {
        OdbcConnection cnn;
        public string strConn;
        public string sqlConn;
        public string docId;
        public string docAno;
        public string docNum;
        string sql;

        public Encomendas(string ConnectionString)
        {
            InitializeComponent();
            strConn = ConnectionString;
        }

        private void Encomendas_Load(object sender, EventArgs e)
        {
            cnn = new OdbcConnection(strConn);

            sql = "SELECT CD.id, CD.numdoc, CD.nome, CD.serie, CD.Referencia " +
                @"FROM CabecDoc AS CD LEFT JOIN CabecDocStatus as CDS on CDS.IdCabecDoc=CD.Id "+
                @"WHERE CD.TipoDoc='ECL' and CDS.Anulado=0 " +
                @"ORDER by CD.serie DESC, CD.numdoc desc";
            GetEncomendas(sql);
        }

        public void GetEncomendas(string Query)
        {
            dgvEnc.Rows.Clear();
            OdbcCommand cmd = new OdbcCommand(Query, cnn);
            cnn.Open();
            OdbcDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    dgvEnc.Rows.Add(dr[0], dr[1] + " | " + dr[3], dr[4], dr[2], dr[1], dr[3]);
                }
            }
            dr.Close();
            cnn.Close();
        }

        private void dgvEnc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewCell d = dgvEnc.Rows[e.RowIndex].Cells["id"];
                docId = d.Value.ToString();

                DataGridViewCell dAno = dgvEnc.Rows[e.RowIndex].Cells["ano"];
                docAno = dAno.Value.ToString();

                DataGridViewCell dNum = dgvEnc.Rows[e.RowIndex].Cells["enc"];
                docNum = dNum.Value.ToString();
            }
        }

        private void dgvEnc_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DetalheEncomenda de = new DetalheEncomenda(strConn, docId);
            de.MdiParent = this.MdiParent;
            de.Show();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchEncomenda();
        }

        private void SearchEncomenda()
        {
            string enc = "", po = "", ano = "";
            if(txtNumEnc.Text != "") enc = "AND CD.NumDoc LIKE '%" + txtNumEnc.Text + "%' ";
            if (txtNumPO.Text != "") po = "AND CD.Referencia LIKE '%" + txtNumPO.Text + "%' ";
            if (txtAno.Text != "") ano = "AND CD.Serie LIKE '%" + txtAno.Text + "%' ";

            sql = "SELECT CD.id, CD.numdoc, CD.nome, CD.serie, CD.Referencia " +
                @"FROM CabecDoc AS CD WHERE CD.TipoDoc='ECL' " +
                @"" + enc + po + ano + "" +
                @"ORDER by CD.numdoc DESC";

            GetEncomendas(sql);
        }

        private void txtNumEnc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchEncomenda();
                txtNumPO.Focus();
            }
        }

        private void txtNumPO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchEncomenda();
                txtAno.Focus();
            }
        }

        private void txtAno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtNumEnc.Focus();
                SearchEncomenda();
            }
        }

        private void imprimirEmbalagemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string rptSource = "S:\\Produção\\Informatica\\REPORTS PRIMAVERA\\EMBAL1_non.rpt";
            //string rptSource = "D:\\EMBAL1_non.rpt";
            string rptFilter = "{CabecDoc.TipoDoc} = 'ECL' and {CabecDoc.NumDoc} = " + docNum + " and {CabecDoc.Serie} = '" + docAno + "'";
            rptPrintPreviewForm pp = new rptPrintPreviewForm(rptSource, rptFilter);
            pp.MdiParent = this.MdiParent;
            pp.Show();
        }
    }
}
