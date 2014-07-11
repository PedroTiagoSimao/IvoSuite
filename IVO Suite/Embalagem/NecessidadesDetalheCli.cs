using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using DGVPrinterHelper;

namespace IVO_Suite.Embalagem
{
    public partial class NecessidadesDetalheCli : Form
    {
        SqlConnection cnn;
        SqlCommand cmd;
        SqlDataReader dr;

        public string strConn;
        public string sqlQuery;
        public string strArtigo;
        public string cId;
        public string strQttGrupo;

        public NecessidadesDetalheCli(string Artigo, string connectionString)
        {
            InitializeComponent();
            strConn = connectionString;
            strArtigo = Artigo;
        }

        private void NecessidadesDetalheCli_Load(object sender, EventArgs e)
        {
            cnn = new SqlConnection(strConn);
            GetDetalheCliente();
        }

        private void GetDetalheCliente()
        {
            /*sqlQuery = "select C.NumDoc, C.Serie, C.Nome, L.Artigo, A.CDU_REFANTIGA, L.Quantidade, L.DataEntrega, C.Id " +
                @"from ((((_IVO_LinhasGE as GE left join _IVO_LinhasPlanoEmbalamento as LPE on LPE.idLinhaDoc=GE.idLinhaDoc) " +
                @"left join LinhasDoc as L on L.Id=GE.idLinhaDoc) " +
                @"left join CabecDoc as C on C.Id=L.IdCabecDoc) " +
                @"left join Artigo as A on A.Artigo=L.Artigo) " +
                @"where GE.item='" + strArtigo + "'";*/

            sqlQuery = "SELECT CD.NumDoc, CD.Serie, CD.Nome, LD.Artigo, A.CDU_REFANTIGA, LD.Quantidade, " +
                @"(CAST(DATEPART(wk,LD.DataEntrega) AS VARCHAR)+ CAST(YEAR(LD.DataEntrega) AS VARCHAR)), CD.Id, " +
                @"SUM(LD.Quantidade/nullif(CAST(CG.quant AS INT),0)) as QttArtigo, GE.COD " +
                @"FROM _IVO_ComposicaoGE AS CG LEFT JOIN _IVO_GruposEmbalagem AS GE ON GE.GECOD=CG.idGrupo " +
                @"LEFT JOIN LinhasDoc AS LD ON LD.CDU_GrupoEmbal=GE.COD " +
                @"LEFT JOIN CabecDoc AS CD ON LD.IdCabecDoc=CD.Id " +
                @"LEFT JOIN CabecDocStatus as CDS on CDS.IdCabecDoc=CD.Id " +
                @"LEFT JOIN Artigo AS A ON A.Artigo=LD.Artigo " +
                @"LEFT JOIN LinhasDocStatus ON LinhasDocStatus.IdLinhasDoc=LD.Id " +
                @"where CDS.Anulado=0 and LinhasDocStatus.Fechado=0 and LinhasDocStatus.Quantidade>LinhasDocStatus.QuantTrans AND CG.idArtigo='" + strArtigo + "' and CD.NumDoc IS NOT NULL AND (CD.TipoDoc='ECL' OR CD.TipoDoc='ECN') " +
                @"group by CD.NumDoc, CD.Serie, CD.Nome, LD.Artigo, A.CDU_REFANTIGA, LD.Quantidade, LD.DataEntrega,CD.Id, GE.COD";

            cmd = new SqlCommand(sqlQuery, cnn);
            if (cnn.State == ConnectionState.Closed) cnn.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    dgvDetalhe.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4], dr[5], dr[8], dr[9], dr[6], dr[7]);
                }
            }
            dr.Close();
            cnn.Close();    
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "Detalhe Encomendas Cliente";
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

        private void dgvDetalhe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewCell id = dgvDetalhe.Rows[e.RowIndex].Cells["id"];
                cId = id.Value.ToString();
            }
        }

        private void dgvDetalhe_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Encomendas.DetalheEncomenda de = new Encomendas.DetalheEncomenda(strConn, cId);
            de.MdiParent = this.MdiParent;
            de.Show();
        }
    }
}
