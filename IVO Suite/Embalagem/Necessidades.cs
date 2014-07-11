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
using DGVPrinterHelper;
using System.Drawing.Printing;
using CarlosAg.ExcelXmlWriter;
using System.Threading;
using System.Diagnostics;

namespace IVO_Suite.Embalagem
{
    public partial class Necessidades : Form
    {
        OdbcConnection cnn;
        OdbcConnection cnn2;
        OdbcCommand cmd;
        OdbcCommand cmd2;
        OdbcDataReader dr;
        OdbcDataReader dr2;

        public string strConn;
        public string sqlQuery;
        public string strArtigo;
        int iQuantNecessaria=0;
        int iQuantStock = 0;
        int iQuantPendente = 0;
        int iQuantProvisional = 0;
        int iQuantPrevista = 0;
        string strPlano = "";
        string wherePlano = "";
        string strSubTitulo = "";
        string strIdPlano;
        string strAno;
        string strTotalWhere = "";
        string strPrint;
        bool bNeg = false;

        public Necessidades(string connectionString, string idPlano)
        {
            InitializeComponent();
            strConn = connectionString;
            strIdPlano = idPlano;
        }

        private void Necessidades_Load(object sender, EventArgs e)
        {

            /*  ****************************************************
             *  
             * NOVA CONSULTA NECESSIDADES 25/07/2001
             *  
             *  select CGE.idArtigo, A.Descricao, A.CodBarras, A.CDU_REFANTIGA, SUM(CAST((CGE.quant * LinhasDoc.Quantidade)  as int)) as Necess, Pendente, A.STKActual, (A.STKActual-SUM(CAST((CGE.quant * LinhasDoc.Quantidade)  as int))) as Provisional, ((A.STKActual-SUM(CAST((CGE.quant * LinhasDoc.Quantidade)  as int))) - Pendente) as Previsto
             *  from LinhasDoc 
             *  left join _IVO_GruposEmbalagem as GE on GE.COD = LinhasDoc.CDU_GrupoEmbal 
             *  left join _IVO_ComposicaoGE  as CGE on cge.idGrupo = GE.COD
             *  left join _IVO_LinhasPlanoEmbalamento as LPE on LPE.idLinhaDoc=linhasdoc.id
             *  left join _IVO_PlanoEmbalamento as PE on PE.nplano=LPE.idPlano 
             *  left join Artigo as A on A.Artigo=idArtigo
             *  left join (select LC.Artigo, (SUM(LCS.Quantidade) - SUM(LCS.QuantTrans)) as Pendente from LinhasComprasStatus as LCS left join LinhasCompras as LC on LC.Id=LCS.IdLinhasCompras where LC.Quantidade>0 group by Artigo) as ABC on ABC.Artigo = idArtigo
             *  where PE.aberto=1 and idArtigo is not null
             *  group by idArtigo, A.Descricao, A.CodBarras, A.CDU_REFANTIGA, pe.ano, Pendente, A.STKActual
             *
             *
             * */

            cnn = new OdbcConnection(strConn);
            cnn2 = new OdbcConnection(strConn);

            cmbRef.Enabled = true;
            txtArtigo.Enabled = true;
            btnSearchArtigo.Enabled = true;

            GetAnos();
            GetPlanos();
            if (strIdPlano == "") { wherePlano = ""; } else { wherePlano = "and PE.nplano='" + strIdPlano + "'"; }
            strPrint = "Necessidades";
            GetNecessidades();
        }

        private void GetAnos()
        {
            sqlQuery = "select distinct ano from _IVO_PlanoEmbalamento";
            cmd = new OdbcCommand(sqlQuery, cnn);
            if (cnn.State == ConnectionState.Closed) cnn.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    cmbAno.Items.Add(dr[0]);
                    strAno = dr[0].ToString();
                }
            }
            dr.Close();
            cnn.Close();
        }

        private void GetPlanos()
        {
            cmbPlano.Items.Clear();
            sqlQuery = "select * from _IVO_PlanoEmbalamento WHERE aberto=1 and ano='" + strAno + "'";
            cmd = new OdbcCommand(sqlQuery, cnn);
            if (cnn.State == ConnectionState.Closed) cnn.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    cmbPlano.Items.Add(dr[1]);
                }
            }
            dr.Close();
            cnn.Close();
        }

        private void btnSwitch_Click(object sender, EventArgs e)
        {
            cmbPlano.Enabled = false;
            cmbAno.Enabled = false;
            btnSearch.Enabled = false;
            cmbRef.Enabled = true;
            txtArtigo.Enabled = true;
            btnSearchArtigo.Enabled = true;
            strPrint = "Total";
            GetTotal();
        }

        private void btnNecessidades_Click(object sender, EventArgs e)
        {
            cmbPlano.Enabled = true;
            cmbAno.Enabled = true;
            btnSearch.Enabled = true;
            cmbRef.Enabled = false;
            txtArtigo.Enabled = false;
            btnSearchArtigo.Enabled = false;
            strPrint = "Necessidades";
            GetNecessidades();
        }

        private void GetTotal()
        {
            dgvNecessidades.Rows.Clear();
            //dgvNecessidades.Columns["TotNec"].Visible = false;
            //dgvNecessidades.Columns["TotProv"].Visible = false;

            sqlQuery = "select distinct A.Artigo, A.Descricao, A.CodBarras, A.CDU_REFANTIGA " +
                @"from ((Artigo as A left join LinhasCompras as LC on LC.Artigo=A.Artigo) " +
                @"left join LinhasComprasStatus as LS on LS.IdLinhasCompras=LC.Id) " +
                @"where A.Familia='EMB' and A.ArtigoPai is not null " + strTotalWhere + " " +
                @"group by A.Artigo, A.Descricao, LC.Id, A.CodBarras, A.CDU_REFANTIGA";

            cmd = new OdbcCommand(sqlQuery, cnn);
            if (cnn.State == ConnectionState.Closed) cnn.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    strArtigo = dr[0].ToString();

                    iQuantStock = GetStock(strArtigo);
                    iQuantProvisional = iQuantStock - iQuantNecessaria;
                    iQuantPendente = GetQuantidade(strArtigo) - GetQuantTrans(strArtigo);
                    iQuantPrevista = iQuantStock + iQuantPendente;
                    dgvNecessidades.Rows.Add(dr[2], dr[3], dr[0], dr[1], "", "", iQuantStock, 0, iQuantPendente, iQuantPrevista);
                }
            }
            dr.Close();
            cnn.Close();
        }

        private void GetNecessidades()
        {
            string strPlano = cmbPlano.Text.ToString();
            
            dgvNecessidades.Rows.Clear();
            dgvNecessidades.Columns["TotNec"].Visible = true;
            dgvNecessidades.Columns["TotProv"].Visible = true;

            if (strPlano == "")
            {
                
                sqlQuery = "select GE.item, GE.descr, SUM(CAST(GE.quant as int)), A.CodBarras, A.CDU_REFANTIGA " +
                    @"from (((_IVO_LinhasGE as GE left join _IVO_LinhasPlanoEmbalamento as LPE on LPE.idLinhaDoc=GE.idLinhaDoc) " +
                    @"left join _IVO_PlanoEmbalamento as PE on PE.nplano=LPE.idPlano) left join Artigo as A on A.Artigo=GE.item) " +
                    @"where PE.aberto=1 and GE.item is not null " + wherePlano +
                    @"group by item, descr, A.CodBarras, A.CDU_REFANTIGA, pe.ano";
            }
            else
            {
                sqlQuery = "select GE.item, GE.descr, SUM(CAST(GE.quant as int)), A.CodBarras, A.CDU_REFANTIGA, pe.nplano, pe.semana, pe.ano " +
                    @"from (((_IVO_LinhasGE as GE left join _IVO_LinhasPlanoEmbalamento as LPE on LPE.idLinhaDoc=GE.idLinhaDoc) " +
                    @"left join _IVO_PlanoEmbalamento as PE on PE.nplano=LPE.idPlano) left join Artigo as A on A.Artigo=GE.item) " +
                    @"where PE.aberto=1 and GE.item is not null " + wherePlano + " " +
                    @"group by item, descr, A.CodBarras, A.CDU_REFANTIGA, pe.nplano, pe.semana, pe.ano";
            }

            cmd = new OdbcCommand(sqlQuery, cnn);
            if (cnn.State == ConnectionState.Closed) cnn.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {

                    if (strPlano == "")
                    {
                        strSubTitulo = "Total Necessidades";
                    }
                    else
                    {
                        strSubTitulo = "Plano " + dr[5].ToString() + " | Semana " + dr[6].ToString() + " | Ano " + dr[7].ToString();
                    }

                    strArtigo = dr[0].ToString();
                    iQuantNecessaria = Convert.ToInt32(dr[2].ToString());
                    iQuantStock = GetStock(strArtigo);
                    iQuantProvisional = iQuantStock - iQuantNecessaria;
                    iQuantPendente = GetQuantidade(strArtigo) - GetQuantTrans(strArtigo);
                    iQuantPrevista = iQuantProvisional + iQuantPendente;

                    if (bNeg)
                    {
                        if (iQuantPrevista < 0)
                        {
                            dgvNecessidades.Rows.Add(dr[3], dr[4], dr[0], dr[1], strPlano, iQuantNecessaria, iQuantStock, iQuantProvisional, iQuantPendente, iQuantPrevista);
                        }
                    }
                    else
                    {
                        dgvNecessidades.Rows.Add(dr[3], dr[4], dr[0], dr[1], strPlano, iQuantNecessaria, iQuantStock, iQuantProvisional, iQuantPendente, iQuantPrevista);
                    }
                }
            }
            dr.Close();
            cnn.Close();
        }

        private int GetQuantidade(string Artigo)
        {
            int Quantidade = 0;
            string sql = "select LCS.Quantidade " +
                @"from LinhasComprasStatus as LCS left join LinhasCompras as LC on LC.Id=LCS.IdLinhasCompras " +
                @"where LC.Artigo='" + Artigo + "' and LC.Quantidade>0";
            cmd2 = new OdbcCommand(sql, cnn2);
            if (cnn2.State == ConnectionState.Closed) cnn2.Open();
            dr2 = cmd2.ExecuteReader();
            if (dr2.HasRows)
            {
                while (dr2.Read())
                {
                    Quantidade = Quantidade + Convert.ToInt32(dr2[0].ToString());
                }
            }
            else
            {
                Quantidade = 0;
            }
            dr2.Close();
            cnn2.Close();
            return Quantidade;
        }

        private int GetQuantTrans(string Artigo)
        {
            int QuantTrans = 0;
            string sql = "select LCS.QuantTrans " +
                @"from LinhasComprasStatus as LCS left join LinhasCompras as LC on LC.Id=LCS.IdLinhasCompras " +
                @"where LC.Artigo='" + Artigo + "' and LC.Quantidade>0";
            cmd2 = new OdbcCommand(sql, cnn2);
            if (cnn2.State == ConnectionState.Closed) cnn2.Open();
            dr2 = cmd2.ExecuteReader();
            if (dr2.HasRows)
            {
                while (dr2.Read())
                {
                    QuantTrans = QuantTrans + Convert.ToInt32(dr2[0].ToString());
                }
            }
            else
            {
                QuantTrans = 0;
            }
            dr2.Close();
            cnn2.Close();
            return QuantTrans;
        }

        private int GetStock(string Artigo)
        {
            OdbcConnection cnnStk;
            OdbcCommand cmdStk;
            OdbcDataReader oDr;
            int Stck = 0;

            if (Artigo != "" || Artigo == null)
            {
                cnnStk = new OdbcConnection(strConn);

                cmdStk = new OdbcCommand("EXECUTE [PRIEIC].[dbo].[_IVO_ConsultaEMB] '" + Artigo + "'", cnnStk);
                cmdStk.CommandType = CommandType.StoredProcedure;
                cnnStk.Open();
                oDr = cmdStk.ExecuteReader();
                while (oDr.Read())
                {
                    Stck = Convert.ToInt32(oDr[0].ToString());
                }
                cnnStk.Close();
            }
            return Stck;
        }

        private void SearchPlano()
        {
            if (cmbPlano.ComboBox.SelectedItem == null)
            {
                strPlano = "";
            }
            else
            {
                strPlano = cmbPlano.ComboBox.SelectedItem.ToString();
            }
            if (strPlano == "") { wherePlano = ""; } else { wherePlano = "and PE.nplano='" + strPlano + "'"; }
            GetNecessidades();
        }

        private void dgvNecessidades_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewCell cellArtigo = dgvNecessidades.Rows[e.RowIndex].Cells["Artigo"];
                strArtigo = cellArtigo.Value.ToString();
            }
        }

        private void cmbPlano_SelectedIndexChanged(object sender, EventArgs e)
        {
            bNeg = false;
            strPlano = cmbPlano.ComboBox.SelectedItem.ToString();
            wherePlano = "and PE.nplano='" + strPlano + "'";
            GetNecessidades();
        }

        private void cmbAno_SelectedIndexChanged(object sender, EventArgs e)
        {
            strAno = cmbAno.ComboBox.SelectedItem.ToString();
            GetPlanos();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchPlano();
        }

        private void btnSearchArtigo_Click(object sender, EventArgs e)
        {
            bNeg = false;
            SearchArtigo();
        }

        private void SearchArtigo()
        {
            string strCampo = cmbRef.ComboBox.SelectedItem.ToString();

            switch (strCampo)
            {
                case "Ref.":
                    strCampo = "A.CodBarras";
                    break;

                case "Ref. Antiga":
                    strCampo = "A.CDU_REFANTIGA";
                    break;

                case "Artigo":
                    strCampo = "A.Artigo";
                    break;

                case "Descrição":
                    strCampo = "A.Descricao";
                    break;
            }
            string strRef = txtArtigo.Text.ToString();
            wherePlano = " and " + strCampo + " LIKE '%" + strRef + "%' ";
            GetNecessidades();
            //strTotalWhere = " and " + strCampo + " LIKE '%" + strRef + "%' ";
            //GetTotal();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (strPrint == "Necessidades") PrintNecessidades();
            if (strPrint == "Total") PrintGeral();
        }

        private void PrintNecessidades()
        {
            dgvNecessidades.Columns["TotPrev"].Visible = false;
            dgvNecessidades.Columns["TotPendente"].Visible = false;
            dgvNecessidades.Columns["TotProv"].Visible = false;
            dgvNecessidades.Columns["TotalStk"].Visible = false;

            DGVPrinter printer = new DGVPrinter();
            printer.Title = "Plano de Necessidades de Embalagem";
            printer.SubTitle = strSubTitulo;
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit |
                                          StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "Ivo Cutelarias, Lda.";
            printer.FooterSpacing = 15;

            printer.PrintPreviewDataGridView(dgvNecessidades);

            dgvNecessidades.Columns["TotPrev"].Visible = true;
            dgvNecessidades.Columns["TotPendente"].Visible = true;
            dgvNecessidades.Columns["TotProv"].Visible = true;
            dgvNecessidades.Columns["TotalStk"].Visible = true;
        }

        private void PrintDetalhe()
        {
            dgvNecessidades.Columns["TotPrev"].Visible = true;
            dgvNecessidades.Columns["TotPendente"].Visible = true;
            dgvNecessidades.Columns["TotProv"].Visible = true;
            dgvNecessidades.Columns["TotalStk"].Visible = true;

            DGVPrinter printer = new DGVPrinter();
            printer.PageSettings.Landscape = true;
            //Margins margins = new Margins(30, 30, 30, 30);
            //printer.PageSettings.Margins = margins;
            printer.Title = "Plano de Necessidades de Embalagem DETALHE";
            printer.SubTitle = strSubTitulo;
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit |
                                          StringFormatFlags.NoClip;
            
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "Ivo Cutelarias, Lda.";
            printer.FooterSpacing = 15;

            printer.PrintPreviewDataGridView(dgvNecessidades);
        }

        private void PrintGeral()
        {
            dgvNecessidades.Columns["TotPrev"].Visible = false;
            dgvNecessidades.Columns["TotPendente"].Visible = false;

            DGVPrinter printer = new DGVPrinter();
            printer.Title = "Plano de Necessidades de Embalagem";
            printer.SubTitle = strSubTitulo;
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit |
                                          StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "Ivo Cutelarias, Lda.";
            printer.FooterSpacing = 15;

            printer.PrintPreviewDataGridView(dgvNecessidades);

            dgvNecessidades.Columns["TotPrev"].Visible = true;
            dgvNecessidades.Columns["TotPendente"].Visible = true;
        }

        private void txtArtigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bNeg = false;
                SearchArtigo();
            }
        }

        private void cmbRef_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtArtigo.Focus();
            }
        }

        private void cmbPlano_KeyDown(object sender, KeyEventArgs e)
        {
            bNeg = false;
            SearchPlano();
        }

        private void verEncomendasFornecedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NecessidadesDetalheForn nd = new NecessidadesDetalheForn(strArtigo, strConn);
            nd.MdiParent = this.MdiParent;
            nd.Show();
        }

        private void verEncomendasClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NecessidadesDetalheCli nc = new NecessidadesDetalheCli(strArtigo, strConn);
            nc.MdiParent = this.MdiParent;
            nc.Show();
        }

        private void btnPrintDetalhe_Click(object sender, EventArgs e)
        {
            PrintDetalhe();
        }

        private void btnStockNegativo_Click(object sender, EventArgs e)
        {
            bNeg = true;
            GetNecessidades();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = GetExcelSaveFileDialog())
            {
                if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    string fileName = saveFileDialog.FileName;

                    Workbook workbook = DataGridViewToExcel.ExcelGenerator.Generate(this.dgvNecessidades);
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
