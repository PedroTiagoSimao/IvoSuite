using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Odbc;
using CarlosAg.ExcelXmlWriter;
using System.Threading;
using System.Diagnostics;

namespace IVO_Suite.Embalagem
{
    public partial class Historico2011 : Form
    {
        public string strSql;
        public string strArtigo;
        public string strCliente;
        public string strWhere;
        public string strConn;

        OdbcConnection cnn;
        OdbcConnection cnn2;
        OdbcCommand cmd;
        OdbcDataReader dr;

        public Historico2011(string SQLConnectionString, string SearchCliente, string SearchArtigo)
        {
            InitializeComponent();
            strConn = SQLConnectionString;
            strArtigo = SearchArtigo;
            strCliente = SearchCliente;
        }

        private void Historico2011_Load(object sender, EventArgs e)
        {
            cnn = new OdbcConnection(strConn);
            cnn2 = new OdbcConnection(strConn);
            txtArtigo.Text = strArtigo;
            txtCliente.Text = strCliente;
            GetHistory(strCliente, strArtigo, "", "");
        }

        private void GetHistory(string FilterClient, string FilterItem, string FilterGrupo, string FilterArtEmbal)
        {

            strWhere = " and cl.Nome LIKE '%" + FilterClient + "%' and (a.CodBarras LIKE '%" + FilterItem + "%' or ac.ReferenciaCli LIKE '%" + FilterItem + "%') ";
            strWhere = strWhere + " and cge.idArtigo LIKE '%" + FilterArtEmbal + "%' and ge.COD LIKE '%" + FilterGrupo + "%' ";
            string strOrder = " order by C.serie, C.numDoc desc ";

            /*strSql = "select cl.Nome, ac.ReferenciaCli, a.CodBarras, g.item, lp.idplano, C.numDoc, C.serie, g.obs, ar.CDU_REFANTIGA, ge.COD, ge.GEDESCR from " +
                @"((((((((_IVO_LinhasPlanoEmbalamento as lp left join LinhasDoc as ld on ld.Id=lp.idLinhaDoc)" +
                @"left join _IVO_LinhasGE as g on g.idLinhaDoc=ld.Id)" +
                @"left join CabecDoc as c on c.Id=ld.IdCabecDoc)" +
                @"left join Clientes as cl on cl.Cliente=c.Entidade)" +
                @"left join Artigo as a on a.Artigo=ld.Artigo)" +
                @"left join Artigo as ar on ar.Artigo=g.item) " +
                @"left join ArtigoCliente as ac on a.Artigo=ac.Artigo) " +
                @"left join _IVO_GruposEmbalagem as ge on ge.GECOD=g.grupo) where g.item is not null " + strWhere + " " + strOrder + "";*/

            strSql = "select cl.Cliente, cl.Nome, ac.ReferenciaCli, a.CodBarras, cge.idArtigo, " +
                @"(CAST(DATEPART(wk,ld.DataEntrega) AS VARCHAR)+ CAST(YEAR(ld.DataEntrega) AS VARCHAR)), "+
                @"C.numDoc, C.serie, cge.obs, ar.CDU_REFANTIGA, ge.COD, ge.GEDESCR from " +
                @"(((((((LinhasDoc as ld left join _IVO_GruposEmbalagem as ge on ge.COD=ld.CDU_GrupoEmbal) " +
                @"left join _IVO_ComposicaoGE as cge on cge.idGrupo=ge.GECOD) " +
                @"left join CabecDoc as c on c.Id=ld.IdCabecDoc) " +
                @"left join Clientes as cl on cl.Cliente=c.Entidade) " +
                @"left join Artigo as a on a.Artigo=ld.Artigo) " +
                @"left join Artigo as ar on ar.Artigo=cge.idArtigo) " +
                @"left join ArtigoCliente as ac on a.Artigo=ac.Artigo) " +
                @"where c.TipoDoc='ECL' and ld.CDU_GrupoEmbal is not null and ld.CDU_GrupoEmbal not like '**' " +
                @"" + strWhere + " " + strOrder;

            dgvHistory.Rows.Clear();

            cmd = new OdbcCommand(strSql, cnn);
            if (cnn.State == ConnectionState.Closed) cnn.Open();
            dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    string enc = dr[6].ToString() + "-" + dr[7].ToString();
                    string cliente = dr[0].ToString() + "-" + dr[1].ToString();
                    dgvHistory.Rows.Add(enc, cliente, dr[2].ToString(), dr[3].ToString(), dr[10].ToString(), dr[4].ToString(), dr[11].ToString(), dr[9].ToString(), dr[5].ToString(), dr[8].ToString());
                }
            }
            dr.Close();
            cnn.Close();

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            GetHistory(txtCliente.Text, txtArtigo.Text, "", "");
        }

        private void txtCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) GetHistory(txtCliente.Text, txtArtigo.Text, txtGrupo.Text, txtArtEmbal.Text);
        }

        private void txtArtigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) GetHistory(txtCliente.Text, txtArtigo.Text, txtGrupo.Text, txtArtEmbal.Text);
        }

        private void btnSearch2_Click(object sender, EventArgs e)
        {
            GetHistory(txtCliente.Text, txtArtigo.Text, txtGrupo.Text, txtArtEmbal.Text);
        }

        private void txtGrupo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) GetHistory(txtCliente.Text, txtArtigo.Text, txtGrupo.Text, txtArtEmbal.Text);
        }

        private void txtArtEmbal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) GetHistory(txtCliente.Text, txtArtigo.Text, txtGrupo.Text, txtArtEmbal.Text);
        }

        private void btnExport_Click_1(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = GetExcelSaveFileDialog())
            {
                if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    string fileName = saveFileDialog.FileName;

                    Workbook workbook = DataGridViewToExcel.ExcelGenerator.Generate(this.dgvHistory);
                    workbook.Save(fileName);

                    Process.Start(fileName);
                }
            }
        }

        private SaveFileDialog GetExcelSaveFileDialog()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.CheckPathExists = true;
            saveFileDialog.AddExtension = true;
            saveFileDialog.ValidateNames = true;
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            saveFileDialog.DefaultExt = ".xls";
            saveFileDialog.Filter = "Microsoft Excel Workbook (*.xls)|*.xls";
            return saveFileDialog;
        }

    }
}
