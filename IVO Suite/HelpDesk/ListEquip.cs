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
using System.Threading;
using System.Diagnostics;

namespace IVO_Suite.HelpDesk
{
    public partial class ListEquip : Form
    {
        public string strConn;
        public string strSql;
        public int cid;
        SqlConnection cnn;
        SqlCommand cmd;
        SqlDataReader dr;

        public ListEquip(string ConnectionString)
        {
            InitializeComponent();
            strConn = ConnectionString;
        }

        private void ListComputadores_Load(object sender, EventArgs e)
        {
            cnn = new SqlConnection(strConn);
            
            GetComputers();
        }

        public void GetComputers()
        {
            strSql = "SELECT c.ID, c.name, c.adminuser, c.localiz, s.sname, c.type, c.serial, " +
                @"(select name from computers where id=e.idComposto), c.cpu, c.mhz, c.ram, c.ramtype " +
                @"FROM (Computers as c left join Componentes as e on e.idComponente=c.id) " +
                @"LEFT JOIN Staff as s on s.id=c.adminuser ORDER BY name";

            dgvComputers.Rows.Clear();
            cmd = new SqlCommand(strSql, cnn);
            if (cnn.State == ConnectionState.Closed) cnn.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    dgvComputers.Rows.Add(dr[0], dr[1], dr[5], dr[4], dr[3], dr[6], dr[7], dr[8], dr[9], dr[10], dr[11]);
                }
            }
            cnn.Close();
            dr.Close();
        }

        private void dgvComputers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewCell cellCid = dgvComputers.Rows[e.RowIndex].Cells["id"];
                cid = Convert.ToInt32(cellCid.Value);
            }
        }

        private void dgvComputers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            HelpDesk.Equipamentos pc = new Equipamentos(strConn, cid, this);
            pc.MdiParent = this.MdiParent;
            pc.Show();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GetComputers();
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

                    Workbook workbook = DataGridViewToExcel.ExcelGenerator.Generate(this.dgvComputers);
                    workbook.Save(fileName);

                    Process.Start(fileName);
                }
            }
        }
    }
}
