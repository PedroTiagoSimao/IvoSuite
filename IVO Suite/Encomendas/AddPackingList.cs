using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;

namespace IVO_Suite.Encomendas
{
    public partial class AddPackingList : Form
    {
        public string strConn;
        public string strSql;
        public string uidPackingList;
        public int PackingListNumber;
        public string idCabecDoc;
        public string idLinhaEncomenda;
        public string strRef;
        public string strRefAntiga;
        public string strArtigo;
        public string strDescricao;
        public string strQuant;
        public string strArtigoCliente;
        public string strDescricaoCliente;
        public string strVRef;
        public string strNumEnc;
        public string strAno;
        public string strAction;
        public string strTipoDoc;
        public string strClienteNome;
        public string strCliente;
        public int cx;
        PackingLists pl;

        private ToolStripControlHost dtsTSComponent;

        SqlConnection cnn;
        SqlConnection cnn2;
        SqlCommand cmd;
        SqlDataReader dr;

        public AddPackingList(string PackingListUID, string SqlConnectionString, PackingLists pkls)
        {
            InitializeComponent();
            dtsTSComponent = new ToolStripControlHost(dtpPackingList);
            maintoolStrip.Items.Add(dtsTSComponent);

            uidPackingList = PackingListUID;
            strConn = SqlConnectionString;
            pl = pkls;
        }

        private void AddPackingList_Load(object sender, EventArgs e)
        {
            cnn = new SqlConnection(strConn);
            cnn2 = new SqlConnection(strConn);

            if (uidPackingList == "0")
            {
                strAction = "New";
                cx = 1;
                GetPackingListNumber();
                uidPackingList = Guid.NewGuid().ToString();
                this.Text = "Novo Packing List";
            }
            else
            {
                strAction = "Edit";
                LoadPackingList();
                SetFormText();
            }

            GetEncomendas();
        }

        private void SetFormText()
        {
            this.Text = "Packing List Nº " + tsTxtNumPL.Text + " - " + strClienteNome;
        }

        private void LoadPackingList()
        {
            //Cabeçalho
            strSql = "select P.guid, P.ano, P.numero, P.cliente, P.data, C.Nome, P.caixas, P.peso, P.metros, P.fact " +
                @"from _IVO_PackingLists as P left join Clientes as C on C.Cliente=P.cliente " +
                @"WHERE P. guid='" + uidPackingList + "' ORDER BY Caixas";
            cmd = new SqlCommand(strSql, cnn);
            if (cnn.State == ConnectionState.Closed) cnn.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    strAno = dr[1].ToString();
                    strNumEnc = dr[2].ToString();
                    tsTxtNumPL.Text = strNumEnc + " | " + strAno;
                    tsTxtCliente.Text = dr[3].ToString();
                    strClienteNome = dr[5].ToString();
                    string[] d = dr[4].ToString().Split(new char[] { '-' });
                    int ano = Convert.ToInt32(d[2]);
                    int mes = Convert.ToInt32(d[1]);
                    int dia = Convert.ToInt32(d[0]);
                    dtpPackingList.Value = new DateTime(ano, mes, dia);
                    txtCaixas.Text = dr[6].ToString();
                    txtPeso.Text = dr[7].ToString();
                    txtDim.Text = dr[8].ToString();
                    txtFact.Text = dr[9].ToString();
                }
            }
            dr.Close();
            cnn.Close();

            //Linhas Packing List
            strSql = "SELECT [uidPackingList],[idCabecDoc],[idLinhaEncomenda],[Encomenda],[Ref],[Artigo],[Descricao],[Quant]," +
                @"[ArtigoCliente],[Palete],[Peso],[Tamanho],[Ano],[POCliente], [TipoDoc], [DescricaoCliente] FROM _IVO_LinhasPackingList " +
                @"WHERE [uidPackingList]='" + uidPackingList + "'";
            cmd = new SqlCommand(strSql, cnn);
            if (cnn.State == ConnectionState.Closed) cnn.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    dgvPackingList.Rows.Add(dr[3], dr[12], dr[13], dr[4], "", dr[8], dr[5], dr[6], dr[7],
                        dr[9], dr[10], dr[11], dr[13], dr[14], dr[15], dr[1], dr[2]);
                    string strCx = "";
                    if(dr[9].ToString() == "")
                    {
                        strCx = "0";
                    }
                    else
                    {
                        strCx = dr[9].ToString();
                    }
                    cx = Convert.ToInt32(strCx) + 1;
                }
            }
            dr.Close();
            cnn.Close();
        }

        private void GetPackingListNumber()
        {
            //contar packing lists
            strSql = "SELECT COUNT(*) FROM _IVO_PackingLists";
            cmd = new SqlCommand(strSql, cnn);
            cnn.Open();
            PackingListNumber = (int)cmd.ExecuteScalar() + 1;
            cnn.Close();

            //verificar se número já existe
            strSql = "SELECT * FROM _IVO_PackingLists WHERE numero='" + PackingListNumber.ToString() + "'";
            cmd = new SqlCommand(strSql, cnn);
            cnn.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                MessageBox.Show("Erro na criação do número do Packing List.\nContacte a assistência técnica.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                tsTxtNumPL.Text = PackingListNumber.ToString() + " | 2010";
            }
            dr.Close();
            cnn.Close();
        }

        private void GetEncomendas()
        {
            ArrayList enc = new ArrayList();
            //strSql = "SELECT CabecDoc.ID, CabecDoc.NumDoc, CabecDoc.SERIE, CabecDoc.Nome FROM " +
            //@"((CabecDoc LEFT JOIN LinhasDoc ON LinhasDoc.IdCabecDoc=CabecDoc.Id) "+
            //@"LEFT JOIN _IVO_LINHASPACKINGLIST ON _IVO_LINHASPACKINGLIST.IDLINHAENCOMENDA=LINHASDOC.ID) "+
            //@"WHERE TipoDoc='ECL' OR TipoDoc='ECN' AND _IVO_LinhasPackingList.id IS NULL  order by Serie desc, NumDoc desc";

            strSql = "SELECT CabecDoc.ID, CabecDoc.NumDoc, CabecDoc.SERIE, CabecDoc.Nome, CabecDoc.TipoDoc, CabecDoc.Entidade FROM " +
                @"CabecDoc WHERE TipoDoc='ECL' OR TipoDoc='ECN' " +
                @"Order by Serie desc, NumDoc desc";

            cmd = new SqlCommand(strSql, cnn);
            cnn.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    int i = 0;
                    if (dr[4].ToString() == "ECL") i = 1;
                    if (dr[4].ToString() == "ECN") i = 2;
                    ; enc.Add(new IVO.AddValue(dr[4] + "|" + dr[1] + "|" + dr[2] + " - " + dr[3], dr[5].ToString() + "." + i.ToString() + "." + dr[1].ToString() + "." + dr[2].ToString()));
                }
            }
            dr.Close();
            cnn.Close();

            cmbEncomendas.DataSource = enc;
            cmbEncomendas.DisplayMember = "Display";
            cmbEncomendas.ValueMember = "Value";
        }

        private void cmbEncomendas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEncomendas.SelectedValue.ToString() != "" || cmbEncomendas.SelectedValue.ToString() != "IVO_Suite.IVO+AddValue")
            {
                string strEnc = cmbEncomendas.SelectedValue.ToString();
                //MessageBox.Show(strEnc);
                string[] D = strEnc.Split(new char[] { '.' });
                if (D[0] != "IVO_Suite")
                {
                    strNumEnc = D[2];
                    strAno = D[3];
                    if (D[1] == "1") strTipoDoc = "ECL";
                    if (D[1] == "2") strTipoDoc = "ECN";
                    GetLinhasEncomenda(strNumEnc, strAno, strTipoDoc);
                }
            }
        }

        public void GetLinhasEncomenda(string NumEnc, string Ano, string TipoDoc)
        {
            /*strSql = "select L.id as idLinha, C.Id as idCabecDoc, A.CodBarras, A.Artigo, A.Descricao, L.Quantidade, " +
                @"AC.ReferenciaCli, C.Referencia, AC.DescricaoCli, A.CDU_REFANTIGA " +
                @"FROM (((LinhasDoc as L left join CabecDoc as C on C.id=L.idCabecDoc) " +
                @"left join Artigo as A on A.Artigo=L.Artigo)" +
                @"left join ArtigoCliente as AC on AC.Artigo=A.Artigo and AC.Cliente='" + Cliente + "')" +
                @"WHERE C.TipoDoc='" + TipoDoc + "' and C.NumDoc='" + NumEnc + "' and C.Serie='" + Ano + "' and L.TipoLinha not like '65'";*/

            strSql = "select L.id as idLinha, C.Id as idCabecDoc, A.CodBarras, A.Artigo, A.Descricao, L.Quantidade, " +
                @"AC.ReferenciaCli, C.Referencia, AC.DescricaoCli, A.CDU_REFANTIGA, C.Entidade " +
                @"FROM (((LinhasDoc as L left join CabecDoc as C on C.id=L.idCabecDoc) " +
                @"left join Artigo as A on A.Artigo=L.Artigo)" +
                @"left join ArtigoCliente as AC on AC.Artigo=A.Artigo and AC.Cliente=C.Entidade)" +
                @"WHERE C.TipoDoc='" + TipoDoc + "' and C.NumDoc='" + NumEnc + "' and C.Serie='" + Ano + "' and L.TipoLinha not like '65'";

            dgvEncomends.Rows.Clear();

            cmd = new SqlCommand(strSql, cnn);
            cnn.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    strCliente = dr[10].ToString();
                    //SqlCommand cmd2 = new SqlCommand("SELECT Sum(Quant+0) FROM _IVO_LinhasPackingList WHERE uidPackingList='" + uidPackingList + "' and Artigo='" + dr[3].ToString() + "'", cnn2);
                    SqlCommand cmd2 = new SqlCommand("SELECT Sum(Quant+0) FROM _IVO_LinhasPackingList WHERE Encomenda='" + NumEnc + "' and Ano='" + Ano + "' and Artigo='" + dr[3].ToString() + "'", cnn2);
                    cnn2.Open();
                    string qtt = cmd2.ExecuteScalar().ToString();
                    cnn2.Close();
                    dgvEncomends.Rows.Add(dr[0], dr[1], dr[2].ToString(), dr[9].ToString(), dr[6].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5], qtt, dr[7], dr[8]);
                }
            }
            dr.Close();
            cnn.Close();
        }

        private void AddLinhaPackingList()
        {
            dgvPackingList.Rows.Add(strNumEnc, strAno, strVRef, strRef, strRefAntiga, strArtigoCliente, strArtigo,
                strDescricao, strQuant, "", "", "", strVRef, strTipoDoc, strDescricaoCliente,
                idCabecDoc, idLinhaEncomenda);
        }

        private void AddLinhaPackingListAuto(string strQuant, string caixa)
        {
            dgvPackingList.Rows.Add(strNumEnc, strAno, strVRef, strRef, strRefAntiga, strArtigoCliente, strArtigo,
                strDescricao, strQuant, caixa, "", "", strVRef, strTipoDoc, strDescricaoCliente,
                idCabecDoc, idLinhaEncomenda);
        }

        private void dgvEncomendas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewCell idlinhaenc = dgvEncomends.Rows[e.RowIndex].Cells["eid"];
                DataGridViewCell idcabecdoc = dgvEncomends.Rows[e.RowIndex].Cells["idCabecDocenc"];
                DataGridViewCell refenc = dgvEncomends.Rows[e.RowIndex].Cells["refenc"];
                DataGridViewCell artigoenc = dgvEncomends.Rows[e.RowIndex].Cells["artigoenc"];
                DataGridViewCell descricaoenc = dgvEncomends.Rows[e.RowIndex].Cells["descricaoenc"];
                DataGridViewCell quantenc = dgvEncomends.Rows[e.RowIndex].Cells["quantenc"];
                DataGridViewCell artigoclienteenc = dgvEncomends.Rows[e.RowIndex].Cells["artigoclienteenc"];
                DataGridViewCell descricaoclieenc = dgvEncomends.Rows[e.RowIndex].Cells["descricaoclieenc"];
                DataGridViewCell vrefenc = dgvEncomends.Rows[e.RowIndex].Cells["vrefenc"];
                DataGridViewCell refantigaenc = dgvEncomends.Rows[e.RowIndex].Cells["refantigaenc"];

                idCabecDoc = idcabecdoc.Value.ToString();
                idLinhaEncomenda = idlinhaenc.Value.ToString();
                strRef = refenc.Value.ToString();
                strArtigo = artigoenc.Value.ToString();
                strDescricao = descricaoenc.Value.ToString();
                strQuant = quantenc.Value.ToString();
                strArtigoCliente = artigoclienteenc.Value.ToString();
                strDescricaoCliente = descricaoclieenc.Value.ToString();
                strVRef = vrefenc.Value.ToString();
                strRefAntiga = refantigaenc.Value.ToString();
            }
        }

        private void dgvEncomendas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                AddLinhaPackingList();
            }
        }

        private void DeleteLinhasPackingList()
        {
            strSql = "DELETE FROM _IVO_LinhasPackingList WHERE uidPackingList='" + uidPackingList + "'";
            cmd = new SqlCommand(strSql, cnn);
            if (cnn.State == ConnectionState.Closed) cnn.Open();
            try
            {
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
            catch (SqlException se)
            {
                MessageBox.Show(se.Message, "Erro ao eliminar Linhas do Packing List", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Save()
        {
            //Verificar se o cliente Existe
            if (ClienteExists(tsTxtCliente.Text))
            {
                //Actualizar texto do formulário

                SetFormText();
                //Eliminar linhas existentes neste Packing List
                DeleteLinhasPackingList();

                //Inserir ou editar cabeçalho
                string strMsg = "";

                //Data e Ano
                string[] d = dtpPackingList.Value.ToString().Split(new char[] { '-' });
                if (strAction == "New")
                {
                    strSql = "INSERT INTO _IVO_PackingLists (numero, data, cliente, guid, ano, datacriacao, caixas, peso, metros, fact) VALUES " +
                        @"('" + PackingListNumber.ToString() + "', '" + dtpPackingList.Value.ToShortDateString() + "', " +
                        @"'" + tsTxtCliente.Text + "', '" + uidPackingList + "', '" + d[2].Substring(0, 4) + "', GETDATE(), " +
                        @"'" + txtCaixas.Text + "', '" + txtPeso.Text + "', '" + txtDim.Text + "', '" + txtFact.Text + "')";
                    strMsg = "Erro ao inserir novo Packing List";

                    //Acção passa ano Edit para evitar escrita repetida do cabeçalho
                    strAction = "Edit";
                }
                else
                {
                    strSql = "UPDATE _IVO_PackingLists SET data='" + dtpPackingList.Value.ToShortDateString() + "', " +
                        @"cliente='" + tsTxtCliente.Text + "', caixas='" + txtCaixas.Text + "', peso='" + txtPeso.Text + "', " +
                        @"metros='" + txtDim.Text + "', fact='" + txtFact.Text + "' where guid='" + uidPackingList + "'";
                    strMsg = "Erro ao editar Packing List";
                }
                //Executa anterior strSQL
                cmd = new SqlCommand(strSql, cnn);
                if (cnn.State == ConnectionState.Closed) cnn.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                }
                catch (SqlException se)
                {
                    MessageBox.Show(se.Message, strMsg, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Inserir Linhas do PackingList baseado no GUID do cabeçalho
                int i = 1;
                foreach (DataGridViewRow row in dgvPackingList.Rows)
                {
                    strDescricao = row.Cells["descricao"].Value.ToString().Replace("'", "''");
                    strDescricaoCliente = row.Cells["descricaocliente"].Value.ToString().Replace("'", "''");

                    strSql = "INSERT INTO _IVO_LinhasPackingList " +
                        @"([uidPackingList],[idCabecDoc],[idLinhaEncomenda],[Encomenda],[Ano],[Ref]," +
                        @"[Artigo],[Descricao],[Quant],[ArtigoCliente],[Palete],[Peso],[Tamanho],[POCliente], [TipoDoc], [DescricaoCliente]) VALUES " +
                        @"('" + uidPackingList + "', '" + idCabecDoc + "', '" + idLinhaEncomenda + "', " +
                        @"'" + row.Cells["enc"].Value.ToString() + "', " +
                        @"'" + row.Cells["ano"].Value.ToString() + "', " +
                        @"'" + row.Cells["referencia"].Value.ToString() + "', " +
                        @"'" + row.Cells["artigo"].Value.ToString() + "', " +
                        @"'" + strDescricao + "', " +
                        @"'" + row.Cells["quant"].Value.ToString() + "', " +
                        @"'" + row.Cells["artigocliente"].Value.ToString() + "', " +
                        @"'" + row.Cells["palete"].Value.ToString() + "', " +
                        @"'" + row.Cells["peso"].Value.ToString() + "', " +
                        @"'" + row.Cells["tamanho"].Value.ToString() + "', " +
                        @"'" + row.Cells["vref"].Value.ToString() + "', " +
                        @"'" + row.Cells["tipodoc"].Value.ToString() + "', " +
                        @"'" + strDescricaoCliente + "')";

                    cmd = new SqlCommand(strSql, cnn);
                    if (cnn.State == ConnectionState.Closed) cnn.Open();
                    try
                    {
                        cmd.ExecuteNonQuery();
                        cnn.Close();
                    }
                    catch (SqlException se)
                    {
                        MessageBox.Show(se.Message, "Erro ao escrever linha " + i.ToString() + ".", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    i++;
                }

                cnn.Close();
            }
            else
            {
                MessageBox.Show("Cliente inexistente.\nPor favor verifique!", "Cliente Inexistente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tsTxtCliente.Focus();
            }
        }

        private void tsSavePL_Click(object sender, EventArgs e)
        {
            Save();
            pl.GetPackingLists();

            GetLinhasEncomenda(strNumEnc, strAno, strTipoDoc);
        }

        bool ClienteExists(string Numero)
        {
            string checkSql = "SELECT Cliente, Nome FROM Clientes WHERE Cliente='" + tsTxtCliente.Text + "'";
            cmd = new SqlCommand(checkSql, cnn);
            if (cnn.State == ConnectionState.Closed) cnn.Open();
            dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    strClienteNome = dr[1].ToString();
                }
                cnn.Close();
                dr.Close();
                return true;
            }
            else
            {
                cnn.Close();
                dr.Close();
                return false;
            }
        }

        private void tsBtnDeleteLinha_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvPackingList.SelectedRows)
            {
                dgvPackingList.Rows.Remove(row);
            }
        }

        private void AddPackingList_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Deseja gravar as alterações feitas?", "Atenção", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                Save();
                pl.GetPackingLists();
            }
            else if (result == System.Windows.Forms.DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        private void dgvPackingList_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (this.dgvPackingList.RowCount - 1 > 0)
            {
                this.dgvPackingList.CurrentCell = this.dgvPackingList[0, dgvPackingList.Rows.Count - 1];
            }
        }

        private void OpenDialog()
        {
            string value1 = "";
            string value2 = "";
            if (InputBox(ref value1, ref value2, strArtigo, strQuant) == DialogResult.OK)
            {
                int i = 0;
                int total;
                bool isTotal = Int32.TryParse(value1, out total);

                if (isTotal)
                {
                    int porcaixa;
                    bool isPorcaixa = Int32.TryParse(value2, out porcaixa);

                    if (isPorcaixa)
                    {
                        while (i < total)
                        {
                            if (total - i < porcaixa) porcaixa = total - i;
                            AddLinhaPackingListAuto(porcaixa.ToString(), cx.ToString());
                            i = i + porcaixa;
                            cx++;
                        }

                    }
                    else
                    {
                        MessageBox.Show("Quant. por caixa não é valido!");
                        OpenDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Total não é valido!");
                    OpenDialog();
                }
            }
        }

        public static DialogResult InputBox(ref string value1, ref string value2, string artigo, string quant)
        {
            Form form = new Form();
            Label label1 = new Label();
            TextBox textBox1 = new TextBox();
            Label label2 = new Label();
            TextBox textBox2 = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = artigo;
            label1.Text = "Total";
            textBox1.Text = quant;

            label2.Text = "Quant. p/ Caixa";
            textBox2.Text = "";

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label1.SetBounds(9, 20, 372, 13);
            textBox1.SetBounds(12, 36, 180, 20);

            label2.SetBounds(140, 20, 372, 13);
            textBox2.SetBounds(140, 36, 200, 20);

            buttonOk.SetBounds(180, 72, 75, 23);
            buttonCancel.SetBounds(265, 72, 75, 23);

            label1.AutoSize = true;
            textBox1.Anchor = textBox1.Anchor | AnchorStyles.Right;

            label2.AutoSize = true;
            textBox2.Anchor = textBox2.Anchor | AnchorStyles.Right;

            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(360, 107);
            form.Controls.AddRange(new Control[] { label1, textBox1, label2, textBox2, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label1.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value1 = textBox1.Text;
            value2 = textBox2.Text;
            return dialogResult;
        }

        private void adicionarUltiplasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenDialog();
        }

        private void SearchEncomenda()
        {
            if (txtEnc.Text != "")
            {
                if (txtAno.Text != "")
                {
                    string strMercado = cmbMercado.Text.ToString();

                    if (strMercado == "Internacional") { strTipoDoc = "ECL"; }
                    if (strMercado == "Nacional") { strTipoDoc = "ECN"; }
                    strNumEnc = txtEnc.Text;
                    strAno = txtAno.Text;
                    GetLinhasEncomenda(strNumEnc, strAno, strTipoDoc);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchEncomenda();
         }

        private void txtEnc_KeyDown(object sender, KeyEventArgs e)
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
                cmbMercado.Focus();
            }
        }

        private void cmbMercado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchEncomenda();
            }
        }
    }
}