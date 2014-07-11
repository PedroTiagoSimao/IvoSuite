using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IVO_Suite.Embalagem
{
    public partial class PrintEmbal : Form
    {
        public PrintEmbal()
        {
            InitializeComponent();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintEmbalagem();
        }

        private void PrintEmbal_Load(object sender, EventArgs e)
        {
            txtEncomenda.Focus();
        }

        private void PrintEmbalagem()
        {
            string rptSource = "S:\\Produção\\Informatica\\REPORTS PRIMAVERA\\EMBAL1_non.rpt";
            //string rptSource = "D:\\EMBAL1_non.rpt";
            string rptFilter = "{CabecDoc.NumDoc} = " + txtEncomenda.Text + " and {CabecDoc.Serie} = '" + txtAno.Text + "'";
            rptPrintPreviewForm pp = new rptPrintPreviewForm(rptSource, rptFilter);
            pp.MdiParent = this.MdiParent;
            pp.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtEncomenda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) txtAno.Focus();
        }

        private void txtAno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) PrintEmbalagem();
        }
    }
}
