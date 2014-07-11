using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Data.SqlClient;
using DGVPrinterHelper;

namespace IVO_Suite.Embalagem
{
    public partial class NecessidadesDetalheForn : Form
    {
        SqlConnection cnn;
        SqlCommand cmd;
        SqlDataReader dr;

        public string strConn;
        public string sqlQuery;
        public string strArtigo;
        public string strType;
        double iQuant;
        double iQuantTrans;
        double iQuantPendente;

        public NecessidadesDetalheForn(string Artigo, string connectionString)
        {
            InitializeComponent();
            strConn = connectionString;
            strArtigo = Artigo;
        }

        private void NecessidadesDetalhe_Load(object sender, EventArgs e)
        {
            cnn = new SqlConnection(strConn);
            GetDetalheFornecedor();
        }

        private void GetDetalheFornecedor()
        {
            sqlQuery = "select C.NumDoc, C.Serie, C.Nome, C.DataDoc, L.DataEntrega, L.Artigo, L.Unidade, S.Quantidade, S.QuantTrans " +
                        @"from ((LinhasCompras as L left join CabecCompras as C on C.Id=L.IdCabecCompras)" +
                        @"left join LinhasComprasStatus as S on S.IdLinhasCompras=L.Id) " +
                        @"where C.Serie>2011 and L.Fechado=0 and C.TipoDoc='ECF' and L.Artigo='" + strArtigo + "'";

            cmd = new SqlCommand(sqlQuery, cnn);
            if (cnn.State == ConnectionState.Closed) cnn.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    iQuant = Convert.ToDouble(dr[7].ToString());
                    iQuantTrans = Convert.ToDouble(dr[8].ToString());
                    iQuantPendente = iQuant - iQuantTrans;

                    if (iQuant > iQuantTrans) dgvDetalhe.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4], dr[5], dr[6], iQuant, iQuantTrans, iQuantPendente);
                }
            }
            dr.Close();
            cnn.Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "Detalhe Encomenda Fornecedor";
            printer.SubTitle = "Artigo de embalagem: " + strArtigo;
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit |
                                          StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "Ivo Cutelarias, Lda.";
            printer.FooterSpacing = 15;

            printer.PrintPreviewDataGridView(dgvDetalhe);
        }
    }
}
