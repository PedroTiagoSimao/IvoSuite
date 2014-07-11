using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace IVO_Suite.HelpDesk
{
    public partial class Staff : Form
    {
        public string strConn;
        public string strSql;
        public string idStaff;
        public int selectedIndex;

        SqlCommand cmd;
        SqlDataReader dr;
        SqlConnection cnn;

        public Staff(string ConnectionString)
        {
            InitializeComponent();
            strConn = ConnectionString;
        }

        private void Staff_Load(object sender, EventArgs e)
        {
            cnn = new SqlConnection(strConn);
            GetStaff();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 0);
            this.Height = this.MdiParent.Height - 77;
        }

        public void GetStaff()
        {
            dgvStaff.Rows.Clear();
            strSql = "SELECT * FROM STAFF ORDER BY sname";
            cmd = new SqlCommand(strSql, cnn);
            cnn.Open();
            dr = cmd.ExecuteReader();
            if(dr.HasRows)
            {
                while(dr.Read())
                {
                    dgvStaff.Rows.Add(dr[1], dr[2], dr[3], dr[4], dr[0]);
                    cmbStaff.Items.Add(dr[1]);
                }
            }
            dr.Close();
            cnn.Close();
        }

        private void SearchStaff()
        {
            dgvStaff.ClearSelection();

            foreach (DataGridViewRow row in dgvStaff.Rows)
            {
                if (row.Cells["sname"].Value.ToString() == cmbStaff.Text)
                {
                    row.Cells["sname"].Selected = true;
                    selectedIndex = row.Index;
                }
            }
        }

        private void txtStaff_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchStaff();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchStaff();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja apagar este registo?", "Confirme", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                strSql = "DELETE FROM Staff WHERE id=" + idStaff;
                cmd = new SqlCommand(strSql, cnn);
                try
                {
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                }
                catch (SqlException se)
                {
                    MessageBox.Show(se.ErrorCode + "\n" + se.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                GetStaff();
            }
        }

        private void dgvStaff_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewCell CellidStaff = dgvStaff.Rows[e.RowIndex].Cells["id"];
                idStaff = CellidStaff.Value.ToString();
                selectedIndex = e.RowIndex;
            }
        }

        private void btnAddStaff_Click(object sender, EventArgs e)
        {
            StaffAdd sa = new StaffAdd(strConn, "new", idStaff, this);
            sa.MdiParent = this.MdiParent;
            sa.Show();
        }

        private void dgvStaff_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            StaffAdd sa = new StaffAdd(strConn, "edit", idStaff, this);
            sa.MdiParent = this.MdiParent;
            sa.Show();
        }

        private void dgvStaff_SelectionChanged(object sender, EventArgs e)
        {
            dgvStaff.FirstDisplayedScrollingRowIndex = selectedIndex;
        }

        private void cmbStaff_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchStaff();
        }
    }
}
