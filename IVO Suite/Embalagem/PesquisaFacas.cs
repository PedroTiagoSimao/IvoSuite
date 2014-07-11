using System;   
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using CarlosAg.ExcelXmlWriter;
using System.Diagnostics;

namespace IVO_Suite.Embalagem
{
    public partial class PesquisaFacas : Form
    {
        SqlConnection cnn;
        public string StrConn;

        public PesquisaFacas(string ConnectionString)
        {
            InitializeComponent();
            StrConn = ConnectionString;
        }

        private void PesquisaFacas_Load(object sender, EventArgs e)
        {
            cnn = new SqlConnection(StrConn);
            Procurar("");
        }

        private void Procurar(String Filtro)
        {
            dgvPesquisaFacas.Rows.Clear();

            string SqlStr = "SELECT ArtigoCliente.Artigo, Artigo.CodBarras, ArtigoCliente.Cliente, Clientes.Nome, ArtigoCliente.DescricaoCli, " +
                @"ArtigoCliente.CDU_GrupoEmbalagem, ArtigoCliente.CDU_PecasInner, " +
                @"ArtigoCliente.CDU_RotLingua, ArtigoCliente.CDU_TipoCodBarras, ArtigoCliente.CDU_TipoRotulo " +
                @"FROM ArtigoCliente " +
                @"LEFT JOIN Clientes on Clientes.Cliente=ArtigoCliente.Cliente " +
                @"LEFT JOIN Artigo on Artigo.Artigo=ArtigoCliente.Artigo " +
                @"where ArtigoCliente.Artigo like '%" + Filtro + "%'";

            SqlCommand cmd = new SqlCommand(SqlStr, cnn);
            if (cnn.State == ConnectionState.Closed) cnn.Open();
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    dgvPesquisaFacas.Rows.Add(dr[0],dr[1],dr[2],dr[3],dr[4],dr[5], dr[6]);
                }
            }
            dr.Close();
            cnn.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Procurar(txtSearch.Text);
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Procurar(txtSearch.Text);
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

        private void btnExport_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = GetExcelSaveFileDialog())
            {
                if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    string fileName = saveFileDialog.FileName;

                    Workbook workbook = DataGridViewToExcel.ExcelGenerator.Generate(this.dgvPesquisaFacas);
                    workbook.Save(fileName);

                    Process.Start(fileName);
                }
            }
        }
    }
}
