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
    public partial class Historico : Form
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

        public Historico(string SQLConnectionString, string SearchCliente, string SearchArtigo)
        {
            InitializeComponent();
            strConn = SQLConnectionString;
            strArtigo = SearchArtigo;
            strCliente = SearchCliente;
        }

        private void Historico_Load(object sender, EventArgs e)
        {
            cnn = new OdbcConnection(strConn);
            cnn2 = new OdbcConnection(strConn);
            txtArtigo.Text = strArtigo;
            txtCliente.Text = strCliente;
            GetHistory(strCliente, strArtigo);
        }

        private void GetHistory(string FilterClient, string FilterItem)
        {

            strWhere = " and cl.Nome LIKE '%" + FilterClient + "%' and (a.CodBarras LIKE '%" + FilterItem + "%' or ac.ReferenciaCli LIKE '%" + FilterItem + "%') ";
            string strOrder = " order by C.serie, C.numDoc desc ";

            strSql = "select cl.Nome, ac.ReferenciaCli, a.CodBarras, g.item, lp.idplano, C.numDoc, C.serie, g.obs, ar.CDU_REFANTIGA, ge.COD, ge.GEDESCR from " +
                @"((((((((_IVO_LinhasPlanoEmbalamento as lp left join LinhasDoc as ld on ld.Id=lp.idLinhaDoc)" +
                @"left join _IVO_LinhasGE as g on g.idLinhaDoc=ld.Id)" +
                @"left join CabecDoc as c on c.Id=ld.IdCabecDoc)" +
                @"left join Clientes as cl on cl.Cliente=c.Entidade)" +
                @"left join Artigo as a on a.Artigo=ld.Artigo)"+
                @"left join Artigo as ar on ar.Artigo=g.item) "+
                @"left join ArtigoCliente as ac on a.Artigo=ac.Artigo) "+
                @"left join _IVO_GruposEmbalagem as ge on ge.GECOD=g.grupo) where g.item is not null " + strWhere + " " + strOrder + "";

            dgvHistory.Rows.Clear();

            cmd = new OdbcCommand(strSql, cnn);
            if (cnn.State == ConnectionState.Closed) cnn.Open();
            dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    string enc = dr[4].ToString() + "-" + dr[5].ToString();
                    dgvHistory.Rows.Add(enc, dr[0], dr[1].ToString(), dr[2].ToString(), dr[9].ToString(), dr[8].ToString(), dr[10].ToString(), dr[3].ToString(), dr[4].ToString(), dr[7].ToString());
                }
            }
            dr.Close();
            cnn.Close();

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            GetHistory(txtCliente.Text, txtArtigo.Text);
        }

        private void txtClient_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) GetHistory(txtCliente.Text, txtArtigo.Text);
        }

        private void txtArtigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) GetHistory(txtCliente.Text, txtArtigo.Text);
        }

        private void btnExport_Click(object sender, EventArgs e)
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
