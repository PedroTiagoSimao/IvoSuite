using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace IVO_Suite
{
    public partial class rptPrintPreviewForm : Form
    {
        public string rptSource;
        public string rptFilter;

        public rptPrintPreviewForm(string ReportSourceLocation, string ReportFilter)
        {
            InitializeComponent();
            rptSource = ReportSourceLocation;
            rptFilter = ReportFilter;
        }

        private void rptPrintPreviewForm_Load(object sender, EventArgs e)
        {
            this.Text = rptSource;

            ReportDocument rptToPrint = new ReportDocument();
            TableLogOnInfo rptTLI = new TableLogOnInfo();
            ConnectionInfo rptConnection = new ConnectionInfo();
            Tables rptTables;

            rptToPrint.Load(rptSource);

            rptConnection.ServerName = "svr\\lp750";
            rptConnection.UserID = "sa";
            rptConnection.Password = "sapassword";

            rptTables = rptToPrint.Database.Tables;

            foreach (Table rptTable in rptTables)
            {
                rptTLI = rptTable.LogOnInfo;
                rptTLI.ConnectionInfo = rptConnection;
                rptTable.ApplyLogOnInfo(rptTLI);
            }

            rptViewer.SelectionFormula = rptFilter;
            rptViewer.ReportSource = rptToPrint;
            rptViewer.Refresh();
        }
    }
}
