using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace IVO_Suite.Primavera
{
    public partial class CodPC : Form
    {
        public string strConn;
        SqlConnection cnn;
        public string where;
        public string Familia;
        public string SubFamilia;

        public CodPC(string ConnectionStr)
        {
            InitializeComponent();
            strConn = ConnectionStr;
        }

        private void CodPC_Load(object sender, EventArgs e)
        {
            cnn = new SqlConnection(strConn);
            try
            {
                cnn.Open();
            }
            catch (SqlException se)
            {
                MessageBox.Show(se.Message);
            }
            txtSubFamilia.Focus();
        }

        private void checkboxHeader_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvArt.RowCount; i++)
            {
                dgvArt[0, i].Value = ((CheckBox)dgvArt.Controls.Find("check", true)[0]).Checked;
            }
            dgvArt.EndEdit();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Familia = txtFamilia.Text;
            SubFamilia = txtSubFamilia.Text;
            Search(Familia, SubFamilia);
        }

        private void GetFamilia()
        {
        }

        private void GetSubFamilia(string Familia)
        {

        }

        private void Search(string Familia, string SubFamilia)
        {
            where = "";
            if (SubFamilia != "")
            {
                where = " WHERE [Familia]='" + Familia + "' AND [SubFamilia]='" + SubFamilia + "' ";
            }
            else
            {
                where = " WHERE [Familia]='" + Familia + "' ";
            }

            string query = "SELECT [Artigo], [Descricao], [CodBarras], [Familia], [SubFamilia] FROM Artigo" + where + " AND CodBarras is null";

            dgvArt.Rows.Clear();

            SqlCommand cmd = new SqlCommand(query, cnn);
            if(cnn.State == ConnectionState.Closed)cnn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    if (dr[0].ToString().Length > 17)
                    {
                        dgvArt.Rows.Add(1, dr[0], dr[2], dr[1], dr[3], dr[4]);
                    }
                }
            }
            else
            {
                txtSubFamilia.Text = "";
                txtSubFamilia.Focus();
            }

            dr.Close();
            cnn.Close();
        }

        private void txtArtigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search(txtFamilia.Text, txtSubFamilia.Text);
            }
        }

        private void txtSubFamilia_keyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSufixo.Text = txtSubFamilia.Text;
                txtSufixo.Focus();
                Search(txtFamilia.Text, txtSubFamilia.Text);
            }
        }

        private void txtCodPC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ApplyCode();
            }
        }

        private void btnApplyPC_Click(object sender, EventArgs e)
        {
            ApplyCode();
        }

        private void ApplyCode()
        {
            int i = 0;
            int c = 1;
            foreach (DataGridViewRow row in dgvArt.Rows)
            {
                //DataGridViewCell check = dgvArt.Rows[row.Index].Cells[0];
                if (Convert.ToBoolean(dgvArt.Rows[row.Index].Cells[0].Value))
                {
                    i++;
                }
            }

            if (txtSufixo.Text != "")
            {
                if (i > 0)
                {
                    if (MessageBox.Show("Atribuir código UPC ás " + i + " referências seleccionadas?", "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        foreach (DataGridViewRow row in dgvArt.Rows)
                        {
                            DataGridViewCell art = dgvArt.Rows[row.Index].Cells["id"];
                            //verificar se o codigo ja existe
                            string cod = "";
                            bool exist = true;

                            while (exist == true)
                            {
                                cod = txtSufixo.Text + "." + c.ToString();
                                cnn.Open();
                                SqlCommand v = new SqlCommand("SELECT [CodBarras] FROM Artigo" + where + " AND [CodBarras]='" + cod + "'", cnn);
                                SqlDataReader dr = v.ExecuteReader();
                                if (!dr.HasRows)
                                {
                                    exist = false;
                                }
                                dr.Close();
                                cnn.Close();
                                c++;
                            }

                            if (exist == false)
                            {
                                if (art.Value != null)
                                {
                                    string query = "UPDATE Artigo SET [CodBarras]='" + cod + "' WHERE [Artigo]='" + art.Value.ToString() + "'";
                                    try
                                    {
                                        SqlCommand e = new SqlCommand(query, cnn);
                                        cnn.Open();
                                        e.ExecuteNonQuery();
                                        cnn.Close();
                                        txtSubFamilia.Text = "";
                                        txtSubFamilia.Focus();
                                    }
                                    catch (SqlException se)
                                    {
                                        MessageBox.Show(se.Message);
                                    }
                                }
                            }
                            c++;
                        }

                        Search(Familia, SubFamilia);
                    }
                }
                else
                {
                    MessageBox.Show("Nenhuma referência seleccionada!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Falta definir sufixo do código.\nNormalmente é usada a linha comercial da familia em questão.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
