using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace IVO_Suite.Reports
{
    public partial class PlanoEmbalagemPreview : Form
    {
        public string nd;
        public string strConn;
        private OdbcDataAdapter dAdapter = new OdbcDataAdapter();
        OdbcConnection cnn;

        public PlanoEmbalagemPreview( string numDoc, string ConnectionStr)
        {
            InitializeComponent();
            nd = numDoc;
            strConn = ConnectionStr;
        }

        private void PlanoEmbalagemPreview_Load(object sender, EventArgs e)
        {
            cnn = new OdbcConnection(strConn);

            string query = "";
            cnn.Open();
            OdbcCommand cmd = new OdbcCommand(query, cnn);
            dAdapter.SelectCommand = cmd;
            DBSet dbs = new DBSet();
            dbs.Clear();
            dAdapter.Fill(dbs, "LinhasGrupoEmbalagem");

            PlanoEmbalamento planEmb = new PlanoEmbalamento();
            planEmb.SetDataSource(dbs);
            crystalReportViewer1.ReportSource = planEmb;
        }
    }
}
