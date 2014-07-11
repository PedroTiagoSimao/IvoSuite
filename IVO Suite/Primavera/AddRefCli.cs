using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Diagnostics;

namespace IVO_Suite.Primavera
{
    public partial class AddRefCli : Form
    {
        public string strAction;
        public string strConn;
        public string strArtigo;
        public string strSql;
        public string strRefIvo;
        public string strCliente;
        public string strAnexoID;
        public string strRotuloLingua;
        public string strUPC;
        RefCli rc;

        SqlConnection cnn;
        SqlDataReader dr;
        SqlCommand cmd;

        public AddRefCli(string strConnectionString, string Action, string strArtigoPrimavera, string Cliente, RefCli frmRefCli, string UPC)
        {
            InitializeComponent();
            strAction = Action;
            strConn = strConnectionString;
            strArtigo = strArtigoPrimavera;
            strCliente = Cliente;
            strUPC = UPC;
            rc = frmRefCli;
        }

        private void AddRefCli_Load(object sender, EventArgs e)
        {
            cnn = new SqlConnection(strConn);
            this.Text = "Referência de Cliente para o Artigo [" + strArtigo + "]";
            GetClientes();
            GetGrupoEmbalagem();
            GetAnexo();

            if (strAction == "new")
            {
               
            }

            if (strAction == "edit")
            {
                cmbClientes.Enabled = false;
                strSql = "select * from ArtigoCliente where Cliente='"+ strCliente + "' and Artigo='" + strArtigo + "'";
                cmd = new SqlCommand(strSql, cnn);
                cnn.Open();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        cmbClientes.SelectedText = dr[1].ToString();
                        txtDescricaoCli.Text = dr[2].ToString();
                        txtReferenciaCli.Text = dr[3].ToString();
                        cmbGrupoEmbalagem.SelectedItem = dr[6].ToString();
                        cmbTipoCodBarras.SelectedItem = dr[7].ToString();
                        txtCodBarras.Text = dr[8].ToString();
                        cmbTipoRotulo.SelectedItem = dr[9].ToString();
                        strRotuloLingua = dr[10].ToString();
                        txtPecasInner.Text = dr[11].ToString();
                        txtPecasMaster.Text = dr[12].ToString();

                        switch (strRotuloLingua)
                        {
                            default:
                                rbtnOutraLingua.Checked = true;
                                txtOutraLingua.Text = dr[10].ToString();
                                break;

                            case "Português":
                                rbtnPortugues.Checked = true;
                                break;

                            case "Inglês":
                                rbtnIngles.Checked = true;
                                break;
                        }
                    }
                }
                dr.Close();
                cnn.Close();
            }
        }

        private void GetGrupoEmbalagem()
        {
            strSql = "select COD from _IVO_GruposEmbalagem where datalength(COD) > 0 order by COD";
            cmd = new SqlCommand(strSql, cnn);
            cnn.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    cmbGrupoEmbalagem.Items.Add(dr[0]);
                }
            }
            dr.Close();
            cnn.Close();
        }

        private void GetClientes()
        {
            strSql = "select Cliente from Clientes";
            cmd = new SqlCommand(strSql, cnn);
            cnn.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    cmbClientes.Items.Add(dr[0]);
                }
            }
            dr.Close();
            cnn.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (strAction == "new")
            {
                if (cmbClientes.SelectedItem.ToString() != "")
                {
                    if (txtReferenciaCli.Text != "")
                    {
                        if (txtDescricaoCli.Text != "")
                        {
                            AddReferenciaCliente();
                        }
                        else
                        {
                            MessageBox.Show("Falta definiar a DESCRIÇÃO do cliente!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtDescricaoCli.Focus();
                            txtDescricaoCli.BackColor = Color.Orange;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Falta definir a REFERÊNCIA do cliente!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtReferenciaCli.Focus();
                        txtReferenciaCli.BackColor = Color.Orange;
                    }
                }
                else
                {
                    MessageBox.Show("Falta seleccionar o cliente!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbClientes.Focus();
                    cmbClientes.BackColor = Color.Orange;
                }
            }
            else
            {
                AddReferenciaCliente();
            }
        }

        private void AddReferenciaCliente()
        {
            string DescricaoCliente = txtDescricaoCli.Text;
            DescricaoCliente = DescricaoCliente.Replace("'", "''");

            if (rbtnPortugues.Checked) strRotuloLingua = "Português";
            if (rbtnIngles.Checked) strRotuloLingua = "Inglês";
            if (rbtnOutraLingua.Checked) strRotuloLingua = txtOutraLingua.Text;

            string strGrupoEmbalagem = "";
            if (string.IsNullOrEmpty(cmbGrupoEmbalagem.SelectedIndex.ToString()) || cmbGrupoEmbalagem.SelectedIndex.ToString() == "-1")
            {
                strGrupoEmbalagem = "";
            }
            else
            {
                strGrupoEmbalagem = cmbGrupoEmbalagem.SelectedItem.ToString();
            }

            string strTipoRotulo = "";
            if (string.IsNullOrEmpty(cmbTipoRotulo.SelectedIndex.ToString()) || cmbTipoRotulo.SelectedIndex.ToString() == "-1")
            {
                strTipoRotulo = "";
            }
            else
            {
                strTipoRotulo = cmbTipoRotulo.SelectedItem.ToString();
            }

            string TipoCodBarras = "";
            if (string.IsNullOrEmpty(cmbTipoCodBarras.SelectedIndex.ToString()) || cmbTipoCodBarras.SelectedIndex.ToString() == "-1")
            {
                TipoCodBarras = "";
            }
            else
            {
                TipoCodBarras = cmbTipoCodBarras.SelectedItem.ToString();
            }

            if (strAction == "new")
            {
                if (CheckCodBarras(cmbClientes.SelectedItem.ToString(), strArtigo, txtCodBarras.Text))
                {
                    strSql = "Insert into ArtigoCliente (Artigo, Cliente, DescricaoCli, ReferenciaCli, " +
                        @"CDU_GrupoEmbalagem, CDU_CodBarras, CDU_TipoRotulo, CDU_TipoCodBarras, CDU_RotLingua, CDU_PecasInner, CDU_PecasMaster) Values " +
                        @"('" + strArtigo + "', " +
                        @"'" + cmbClientes.SelectedItem.ToString() + "', " +
                        @"'" + DescricaoCliente + "', " +
                        @"'" + txtReferenciaCli.Text.ToString() + "', " +
                        @"'" + strGrupoEmbalagem + "', " +
                        @"'" + txtCodBarras.Text.ToString() + "', " +
                        @"'" + strTipoRotulo + "', " +
                        @"'" + TipoCodBarras + "', " +
                        @"'" + strRotuloLingua + "', " +
                        @"'" + txtPecasInner.Text + "', " +
                        @"'" + txtPecasMaster.Text + "'" +
                        @")";


                }
                else
                {
                    MessageBox.Show("O código de barras escolhido já se encontra atribuido a uma referência.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCodBarras.Focus();
                }
            }

            if (strAction == "edit")
            {
                if (CheckCodBarras(strCliente, strArtigo, txtCodBarras.Text))
                {
                    strSql = "UPDATE ArtigoCliente SET " +
                    @"DescricaoCli = '" + DescricaoCliente + "', ReferenciaCli = '" + txtReferenciaCli.Text + "', " +
                    @"CDU_GrupoEmbalagem = '" + strGrupoEmbalagem + "', " +
                    @"CDU_CodBarras = '" + txtCodBarras.Text + "', " +
                    @"CDU_TipoRotulo = '" + strTipoRotulo + "', " +
                    @"CDU_TipoCodBarras = '" + TipoCodBarras + "', " +
                    @"CDU_RotLingua = '" + strRotuloLingua + "', " +
                    @"CDU_PecasInner='" + txtPecasInner.Text + "', " +
                    @"CDU_PecasMaster='" + txtPecasMaster.Text + "' " +
                    @"WHERE Cliente=" + strCliente + " AND Artigo='" + strArtigo + "'";
                }
                else
                {
                    MessageBox.Show("O código de barras escolhido já se encontra atribuido a uma referência.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCodBarras.Focus();
                }

            }
            cmd = new SqlCommand(strSql, cnn);

            try
            {
                if (cnn.State == ConnectionState.Closed) cnn.Open();
                cmd.ExecuteNonQuery();
                cnn.Close();
                rc.GetArtigo(strUPC);
                this.Close();
            }
            catch (SqlException se)
            {
                MessageBox.Show(se.ErrorCode + "\n" + se.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool CheckCodBarras(string Cliente, string Artigo, string CodBarras)
        {
            if (CodBarras != "")
            {
                strSql = "SELECT * FROM ArtigoCliente WHERE Cliente=" + Cliente + " AND CDU_CodBarras='" + CodBarras + "'";
                int i = 0;
                cmd = new SqlCommand(strSql, cnn);
                if (cnn.State == ConnectionState.Closed) cnn.Open();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    if (strAction == "edit")//VERIFICAR TENDO EM CONTA QUE EXISTE 1
                    {
                        while (dr.Read())
                        {
                            i++;
                        }

                        if (i >= 0 && i < 2)
                        {
                            dr.Close();
                            cnn.Close();
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        dr.Close();
                        cnn.Close();
                        return false;
                    }

                }
                else
                {
                    dr.Close();
                    cnn.Close();
                    return true;
                }
            }
            else
            {
                return true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAnexo_Click(object sender, EventArgs e)
        {
            FileStream fs;
            OpenFileDialog oFileDlg = new OpenFileDialog();
            oFileDlg.InitialDirectory = Environment.SpecialFolder.Desktop.ToString();
            oFileDlg.Filter = "All files (*.*)|*.*";
            oFileDlg.FilterIndex = 2;
            oFileDlg.RestoreDirectory = true;
            if (oFileDlg.ShowDialog() == DialogResult.OK)

            {
                if (oFileDlg.OpenFile() != null)
                {
                    try
                    {

                        fs = new FileStream(oFileDlg.FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                        byte[] buffer = new byte[fs.Length];
                        fs.Read(buffer, 0, (int)fs.Length);
                        fs.Close();

                        FileInfo f = new FileInfo(oFileDlg.FileName);

                        //string SQLQuery = "INSERT INTO ATTACHMENTS (DOCNAME, DOCDATEIN, DOCTID, DOCIMG) VALUES " +
                        //    "(@Filename, getdate(), @TicketID, @FileData)";

                        string SQLQuery = "INSERT INTO _IVO_Anexos (AnexoArtigo, AnexoCliente, AnexoNome, Anexo) VALUES " +
                            @"(@Artigo, @Cliente, @Filename, @FileData)";

                        SqlCommand doc = new SqlCommand(SQLQuery, cnn);
                        doc.Parameters.AddWithValue("@Artigo", strArtigo);
                        doc.Parameters.AddWithValue("@Cliente", strCliente);
                        doc.Parameters.AddWithValue("@Filename", f.Name.ToString());
                        doc.Parameters.AddWithValue("@FileData", buffer);

                        try
                        {
                            if (cnn.State == ConnectionState.Closed) cnn.Open();
                            doc.ExecuteNonQuery();
                            cnn.Close();
                            GetAnexo();
                        }
                        catch (SqlException se)
                        {
                            MessageBox.Show(se.Message + "\n" + SQLQuery, "SQL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Não foi possivel abrir o ficheiro seleccionado.\nErro: " + ex.Message, "ERRO IO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void GetAnexo()
        {
            dgvAnexo.Rows.Clear();
            strSql = "SELECT AnexoNome, Anexo, id FROM _IVO_Anexos WHERE AnexoArtigo='" + strArtigo + "' and AnexoCliente='" + strCliente + "'";
            cmd = new SqlCommand(strSql, cnn);
            if (cnn.State == ConnectionState.Closed) cnn.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    dgvAnexo.Rows.Add(dr[0], dr[1], dr[2]);
                }
            }
            dr.Close();
            cnn.Close();
        }

        private void dgvAnexoCell_Double_Click(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell cRotNome = dgvAnexo.Rows[e.RowIndex].Cells["rotnome"];
            DataGridViewCell cRotAnexo = dgvAnexo.Rows[e.RowIndex].Cells["rotanexo"];

            byte[] _file = (byte[])cRotAnexo.Value;
            using (Stream s = File.Create(cRotNome.Value.ToString()))
            {
                s.Write(_file, 0, _file.Length);
            }
            Process.Start(cRotNome.Value.ToString());
        }

        private void eliminarAnexoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            strSql = "DELETE FROM _IVO_Anexos WHERE id=" + strAnexoID;
            cmd = new SqlCommand(strSql, cnn);
            try
            {
                cnn.Open();
                cmd.ExecuteNonQuery();
                cnn.Close();
                GetAnexo();
            }
            catch (SqlException se)
            {
                MessageBox.Show(se.Message);
            }
        }

        private void dgvAnexo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell cAnexoID = dgvAnexo.Rows[e.RowIndex].Cells["id"];
            strAnexoID = cAnexoID.Value.ToString();
        }

        private void txtOutraLingua_Enter(object sender, EventArgs e)
        {
            rbtnOutraLingua.Checked = true;
        }

        private void cmbClientes_Leave(object sender, EventArgs e)
        {
            strCliente = cmbClientes.Text.ToString();
        }
    }
}
