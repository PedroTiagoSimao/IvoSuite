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
using System.Drawing.Printing;
using CarlosAg.ExcelXmlWriter;
using System.Threading;
using System.Diagnostics;
using System.Globalization;

namespace IVO_Suite.Embalagem
{
    public partial class Necessidades2011 : Form
    {
        SqlConnection cnn;
        SqlConnection cnn2;
        SqlCommand cmd;
        SqlDataReader dr;

        public string strConn;
        public string sqlQuery;
        public string strArtigo;
        string strSubTitulo = "";
        string strIdPlano;
        string strPrint;
        string strSemana;
        string sqlWhere;
        string strQttGrupo;

        public Necessidades2011(string connectionString, string idPlano)
        {
            InitializeComponent();
            strConn = connectionString;
            strIdPlano = idPlano;
        }

        private void Necessidades2011_Load(object sender, EventArgs e)
        {
            cnn = new SqlConnection(strConn);
            cnn2 = new SqlConnection(strConn);
            strPrint = "Necessidades";
            sqlWhere = "";
            GetAnos();
            GetSemanas();
            GetTotal();
        }

        private void GetAnos()
        {
            int yearnow = Convert.ToInt32(DateTime.Now.Year);
            int year = yearnow - 2;

            while (year < yearnow + 12)
            {
                cmbAno.Items.Add(year);
                year++;
            }
            cmbAno.Items.Add("2099");
            cmbAno.SelectedIndex = cmbAno.FindStringExact(yearnow.ToString());
        }

        private void GetSemanas()
        {
            int i = 1;
            while (i < 53)
            {
                cmbSemana.Items.Add(i);
                i++;
            }
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            DateTime date1 = DateTime.Now;
            Calendar cal = dfi.Calendar;
            int week = cal.GetWeekOfYear(date1, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);

            cmbSemana.SelectedIndex = cmbSemana.FindStringExact(week.ToString());
        }

        private void GetTotal()
        {
            dgvNecessidades2.Rows.Clear();
            sqlQuery = "select CGE.idArtigo, A.Descricao, A.CodBarras, A.CDU_REFANTIGA, " +
                        @"SUM(CAST((LinhasDoc.Quantidade/nullif(CGE.quant,0))  as int)) as Necess, " +
                        @"Pendente, A.STKActual, (A.STKActual-SUM(CAST((LinhasDoc.Quantidade/nullif(CGE.quant,0))  as int))) as Provisional, " +
                        @"((A.STKActual-(SUM(CAST((LinhasDoc.Quantidade/nullif(CGE.quant,0))  as int))) + Pendente)) as Previsto " +
                        @"from LinhasDoc " +
                        @"left join CabecDoc on Cabecdoc.id=LinhasDoc.IdCabecDoc " +
                        @"left join CabecDocStatus on CabecDocStatus.idCabecDoc=Cabecdoc.id " +
                        @"left join _IVO_GruposEmbalagem as GE on GE.COD = LinhasDoc.CDU_GrupoEmbal " +
                        @"left join _IVO_ComposicaoGE  as CGE on cge.idGrupo = GE.GECOD " +
                        @"left join Artigo as A on A.Artigo=idArtigo " +
                        @"left join (select LC.Artigo, (SUM(LCS.Quantidade) - SUM(LCS.QuantTrans)) as Pendente "+
                            @"from LinhasComprasStatus as LCS "+
                            @"left join LinhasCompras as LC on LC.Id=LCS.IdLinhasCompras "+
                            @"left join CabecCompras as CC on LC.IdCabecCompras=CC.Id "+
                            @"where CC.Serie>2011 and LC.Quantidade>0 and LCS.Fechado=0 group by Artigo) "+
                                @"as ABC on ABC.Artigo = idArtigo " +
                        @"left join LinhasDocStatus on LinhasDocStatus.IdLinhasDoc=LinhasDoc.Id " +
                        @"where idArtigo is not null and CabecDocStatus.Anulado=0 and CabecDoc.TipoDoc='ECL' and " +
                        @"LinhasDocStatus.Fechado=0 and LinhasDocStatus.Quantidade>LinhasDocStatus.QuantTrans " + sqlWhere + " " +
                        @"group by idArtigo, A.Descricao, A.CodBarras, A.CDU_REFANTIGA, Pendente, A.STKActual";


            cmd = new SqlCommand(sqlQuery, cnn);
            if (cnn.State == ConnectionState.Closed) cnn.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    int iPrevisto = 0;
                    if (dr[8] == DBNull.Value) { iPrevisto = 0; } else { iPrevisto = Convert.ToInt32(dr[8]); }

                    int iPendente = 0;
                    if (dr[5] == DBNull.Value) { iPendente = 0; } else { iPendente = Convert.ToInt32(dr[5]); }

                    int iA = 0;
                    if (dr[6] == DBNull.Value) { iA = 0; } else { iA = Convert.ToInt32(dr[6]); }

                    int iB = 0;
                    if (dr[7] == DBNull.Value) { iB = 0; } else { iB = Convert.ToInt32(dr[7]); }

                    dgvNecessidades2.Rows.Add(dr[2], dr[3], dr[0], dr[1], dr[4], iA, iB, iPendente, iPrevisto);
                }
            }
            dr.Close();
            cnn.Close();
        }

        private void _CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewCell cellArtigo = dgvNecessidades2.Rows[e.RowIndex].Cells["Artigo"];
                //DataGridViewCell cellqttgrupo = dgvNecessidades2.Rows[e.RowIndex].Cells["qttgrupo"];
                strArtigo = cellArtigo.Value.ToString();
                strQttGrupo = "0";
            }
        }

        private void verEncomendasClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NecessidadesDetalheCli nc = new NecessidadesDetalheCli(strArtigo, strConn);
            nc.MdiParent = this.MdiParent;
            nc.Show();
        }

        private void verEncomendasFornecedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NecessidadesDetalheForn nd = new NecessidadesDetalheForn(strArtigo, strConn);
            nd.MdiParent = this.MdiParent;
            nd.Show();
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

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = GetExcelSaveFileDialog())
            {
                if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    string fileName = saveFileDialog.FileName;

                    Workbook workbook = DataGridViewToExcel.ExcelGenerator.Generate(this.dgvNecessidades2);
                    workbook.Save(fileName);

                    Process.Start(fileName);
                }
            }
        }

        private void btnSearchAnoPlano_Click(object sender, EventArgs e)
        {
            strSemana = cmbSemana.Text.ToString() + cmbAno.Text.ToString();
            sqlWhere = " and (CAST(DATEPART(wk,LinhasDoc.DataEntrega) AS VARCHAR)+ CAST(YEAR(DataEntrega) AS VARCHAR))='" + strSemana + "' ";
            strSubTitulo = strSemana;
            GetTotal();
        }

        private void PrintDetalhe()
        {
            dgvNecessidades2.Columns["previsto"].Visible = true;
            dgvNecessidades2.Columns["pendente"].Visible = true;
            dgvNecessidades2.Columns["provisional"].Visible = true;
            dgvNecessidades2.Columns["stock"].Visible = true;

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

            printer.PrintPreviewDataGridView(dgvNecessidades2);
        }

        private void btnPrintDetalhe_Click(object sender, EventArgs e)
        {
            PrintDetalhe();
        }

        private void PrintNecessidades()
        {
            dgvNecessidades2.Columns["previsto"].Visible = false;
            dgvNecessidades2.Columns["pendente"].Visible = false;
            dgvNecessidades2.Columns["provisional"].Visible = false;
            dgvNecessidades2.Columns["stock"].Visible = false;

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

            printer.PrintPreviewDataGridView(dgvNecessidades2);

            dgvNecessidades2.Columns["previsto"].Visible = true;
            dgvNecessidades2.Columns["pendente"].Visible = true;
            dgvNecessidades2.Columns["provisional"].Visible = true;
            dgvNecessidades2.Columns["stock"].Visible = true;
        }

        private void PrintGeral()
        {
            dgvNecessidades2.Columns["previsto"].Visible = false;
            dgvNecessidades2.Columns["pendente"].Visible = false;

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

            printer.PrintPreviewDataGridView(dgvNecessidades2);

            dgvNecessidades2.Columns["previsto"].Visible = true;
            dgvNecessidades2.Columns["pendente"].Visible = true;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (strPrint == "Necessidades") PrintNecessidades();
            if (strPrint == "Total") PrintGeral();
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
            sqlWhere = " and " + strCampo + " LIKE '%" + strRef + "%' ";
            GetTotal();
        }

        private void btnSearchArtigo_Click(object sender, EventArgs e)
        {
            SearchArtigo();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            sqlWhere = "";
            GetTotal();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgvr in dgvNecessidades2.Rows)
            {
                int i = Convert.ToInt32(dgvr.Cells["previsto"].Value);
                //int i = -1;
                if (i>=0)
                {
                    dgvr.Visible = false;
                }
            }  
        }

        private void txtArtigo__keyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchArtigo();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            PrintNecessidades();
        }

        private void btnSearchEncomenda_Click(object sender, EventArgs e)
        {
            SearchEncomenda();
        }

        private void SearchEncomenda()
        {
            if (txtCliente.Text != "")
            {
                sqlWhere = sqlWhere + " and CabecDoc.Entidade='" + txtCliente.Text + "' ";
            }
            if (txtEncomenda.Text != "")
            {
                sqlWhere = sqlWhere + " and Cabecdoc.NumDoc='" + txtEncomenda.Text + "' and Cabecdoc.Serie='" + txtAno.Text + "' ";
            }
            GetTotal();
        }

        private void txtCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtEncomenda.Focus();
            }
        }

        private void txtEncomenda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtAno.Focus();
            }
        }

        private void txtAno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchEncomenda();
            }
        }
    }
}
