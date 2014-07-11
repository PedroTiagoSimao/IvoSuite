using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace IVO_Suite.Encomendas
{
    public partial class PackingLists : Form
    {
        public string strConn;
        public string strSql;
        public string uidPackingList;
        private String[] arr;
        string strWhere = "";

        SqlConnection cnn;
        SqlCommand cmd;
        SqlDataReader dr;

        public PackingLists(string SqlConnectionString)
        {
            InitializeComponent();
            strConn = SqlConnectionString;
        }

        private void PackingLists_Load(object sender, EventArgs e)
        {
            cnn = new SqlConnection(strConn);

            arr = new String[9];
            arr[0] = "PT Ref IVO";
            arr[1] = "PT Ref IVO PDF";
            arr[2] = "PT Ref Cliente";
            arr[3] = "PT Ref Cliente PDF";
            arr[4] = "EN Ref IVO";
            arr[5] = "EN Ref IVO PDF";
            arr[6] = "EN Ref Cliente";
            arr[7] = "EN Ref Cliente PDF";
            arr[8] = "EN Descritivo";
            tsCmbReports.ComboBox.DataSource = arr;

            GetPackingLists();
        }

        public void GetPackingLists()
        {
            strSql = "select P.guid, P.ano, P.numero, P.cliente, P.data, C.Nome, P.datacriacao, P.fact " +
                @"from _IVO_PackingLists as P left join Clientes as C on C.Cliente=P.cliente " + strWhere + " ORDER BY P.datacriacao DESC";
            dgvPackingList.Rows.Clear();

            cmd = new SqlCommand(strSql, cnn);
            if(cnn.State == ConnectionState.Closed) cnn.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    dgvPackingList.Rows.Add(dr[0], dr[2], dr[1], dr[7], dr[3] + " - " + dr[5], dr[4], dr[6]);
                }
            }
            dr.Close();
            cnn.Close();

        }

        private void tsBtnAddPL_Click_1(object sender, EventArgs e)
        {
            AddPackingList addpl = new AddPackingList("0", strConn, this);
            addpl.MdiParent = this.MdiParent;
            addpl.Show();
        }

        private void dgvPackingList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewCell uid = dgvPackingList.Rows[e.RowIndex].Cells["uid"];
                uidPackingList = uid.Value.ToString();
            }
        }

        private void dgvPackingList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                AddPackingList AddPl = new AddPackingList(uidPackingList, strConn, this);
                AddPl.MdiParent = this.MdiParent;
                AddPl.Show();
            }
        }

        private void btnDeletePackingList_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem a certeza que deseja eliminar este Packing List?", "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                //Eliminar Packing List
                if (cnn.State == ConnectionState.Closed) cnn.Open();
                strSql = "DELETE FROM _IVO_PackingLists where guid='" + uidPackingList + "'";
                cmd = new SqlCommand(strSql, cnn);
                try
                {
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                }
                catch (SqlException se)
                {
                    MessageBox.Show(se.Message, "Erro ao eliminar packing list", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cnn.Close();
                }

                //Actualizar Lista de Packing Lists
                GetPackingLists();

                //Eliminar Linhas Packing List
                if (cnn.State == ConnectionState.Closed) cnn.Open();
                strSql = "DELETE FROM _IVO_LinhasPackingList where uidPackingList='" + uidPackingList + "'";
                cmd = new SqlCommand(strSql, cnn);
                try
                {
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                }
                catch (SqlException se)
                {
                    MessageBox.Show(se.Message, "Erro ao eliminar packing list", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cnn.Close();
                }
            }
        }

        private void tsBtnPrintPackingList_Click(object sender, EventArgs e)
        {
            string strReport = "PL_PT_REFCLI.rpt";

            /*
                PT Ref IVO
                PT Ref Cliente
                PT Ref Antiga
                EN Ref IVO
                EN Ref Cliente
                EN Ref Antiga
             */

            if (tsCmbReports.Text == "PT Ref IVO") strReport = "PL_PT_REFIVO.rpt";
            if (tsCmbReports.Text == "PT Ref IVO PDF") strReport = "PL_PT_REFIVO_PDF.rpt";
            if (tsCmbReports.Text == "PT Ref Cliente") strReport = "PL_PT_REFCLI.rpt";
            if (tsCmbReports.Text == "PT Ref Cliente PDF") strReport = "PL_PT_REFCLI_PDF.rpt";
            if (tsCmbReports.Text == "EN Ref IVO") strReport = "PL_EN_REFIVO.rpt";
            if (tsCmbReports.Text == "EN Ref IVO PDF") strReport = "PL_EN_REFIVO_PDF.rpt";
            if (tsCmbReports.Text == "EN Ref Cliente") strReport = "PL_EN_REFCLI.rpt";
            if (tsCmbReports.Text == "EN Ref Cliente PDF") strReport = "PL_EN_REFCLI_PDF.rpt";
            if (tsCmbReports.Text == "EN Descritivo") strReport = "PL_EN_DESC.rpt";

            string rptSource = "S:\\Produção\\Informatica\\REPORTS PRIMAVERA\\" + strReport;
            string rptFilter = "{_IVO_PackingLists.guid}='" + uidPackingList + "'";
            rptPrintPreviewForm pp = new rptPrintPreviewForm(rptSource, rptFilter);
            pp.MdiParent = this.MdiParent;
            pp.Show();
        }

        private void SearchPL()
        {
            if (txtSearch.Text != "")
            {
                strWhere = "where P.numero LIKE '%" + txtSearch.Text + "%'";
            }
            else
            {
                strWhere = "";
            }

            GetPackingLists();
        }

        private void tsBtnSearch_Click(object sender, EventArgs e)
        {
            SearchPL();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            SearchPL();
        }

        private void PackingLists_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F10)
            {
                AddPackingList addpl = new AddPackingList("0", strConn, this);
                addpl.MdiParent = this.MdiParent;
                addpl.Show();
            }
        }
    }
}
