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

namespace IVO_Suite.Encomendas
{
    public partial class DetalheEncomenda : Form
    {
        OdbcConnection cnn;
        OdbcConnection CalcCnn;
        public string strConn;
        public string eID;
        public string gID;
        public string aID;
        public string refArtigo;
        public string leID; //ID da Linha da Encomenda
        public int rowIndex;
        public int rowIndexLinhasPE;
        public int QttEnc;
        public string strNum;
        public string strSerie;
        
        //id linha compGE
        public int lID;

        public DetalheEncomenda(string connectionString, string encomendaID)
        {
            InitializeComponent();
            strConn = connectionString;
            eID = encomendaID;
        }

        private void DetalheEncomenda_Load(object sender, EventArgs e)
        {
            cnn = new OdbcConnection(strConn);
            CalcCnn = new OdbcConnection(strConn);
            if (eID != null) { GetCabecDoc(); }
            GetLinhasDoc();
            GetGruposEmbalagem();
        }

        public void GetCabecDoc()
        {
            string sql = "SELECT ID, ENTIDADE, NOME, NUMDOC, DATA, DATAVENCIMENTO, TOTALMERC, SERIE, REQUISICAO FROM CABECDOC WHERE ID='" + eID + "'";
            OdbcCommand cmd = new OdbcCommand(sql, cnn);
            cnn.Open();
            OdbcDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    string ent = dr[1].ToString();
                    txtEnt.Text = ent.Replace("'", "''");
                    txtNome.Text = dr[2].ToString();
                    string d = dr[4].ToString();
                    d = d.Remove(10, d.Length - 10);
                    lblData.Text = d;
                    string v = dr[5].ToString();
                    v = v.Remove(10, v.Length - 10);
                    lblDataVenc.Text = v;
                    txtTotalECL.Text = dr[6].ToString();
                    txtEnc.Text = dr[3].ToString() + " | " + dr[7].ToString();
                    strNum = dr[3].ToString();
                    strSerie = dr[7].ToString();
                    txtPO.Text = dr[8].ToString();
                }
            }
            dr.Close();
            cnn.Close();
        }

        public void GetLinhasDoc()
        {
            if (eID != null)
            {
                dgvLinhasDoc.Rows.Clear();
                dgvLinhasPE.Rows.Clear();
                string sql = "SELECT L.ARTIGO, L.DESCRICAO, L.QUANTIDADE, L.DATAENTREGA, " +
                    @"(SELECT COUNT(*) FROM _IVO_LinhasGE WHERE _IVO_LinhasGE.numdoc=L.IdCabecDoc " +
                    @"and _IVO_LinhasGE.artigo=L.Artigo), L.ID, A.CODBARRAS, A.CDU_REFANTIGA, S.QuantTrans "+
                    @"FROM ((LINHASDOC AS L LEFT JOIN ARTIGO AS A ON L.ARTIGO=A.ARTIGO) "+
                    @"left join LinhasDocStatus as S on S.idLinhasDoc=L.id) "+
                    @"WHERE L.IDCABECDOC='" + eID + "' " +
                    @"ORDER BY L.NUMLINHA";
                OdbcCommand cmd = new OdbcCommand(sql, cnn);
                cnn.Open();
                OdbcDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        int s = Convert.ToInt32(dr[4].ToString());
                        string strArtigo = dr[0].ToString();
                        string strUPC = dr[6].ToString();
                        Bitmap sPlano = (s > 1) ? IVO_Suite.Properties.Resources.Check_16x16 : IVO_Suite.Properties.Resources.Remove_16x16;
                        dgvLinhasDoc.Rows.Add(dr[6], dr[7], dr[0], dr[1], dr[2], dr[3], dr[8]);
                        if (strUPC.Length > 1) dgvLinhasPE.Rows.Add(dr[6], dr[0], dr[2], dr[3], sPlano, dr[5]);
                    }
                }
                dr.Close();
                cnn.Close();
            }
        }

        public void GetGruposEmbalagem()
        {
            string sql = "SELECT GECOD, GEDESCR FROM _IVO_GruposEmbalagem";
            ArrayList grps = new ArrayList();

            OdbcCommand cmd = new OdbcCommand(sql, cnn);
            cnn.Open();
            OdbcDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    grps.Add(new IVO.AddValue(dr[0].ToString() + " - " + dr[1].ToString(), dr[0].ToString()));
                }
            }
            dr.Close();
            cnn.Close();
            if (grps.Count > 0)
            {
                cmbGrupoEmbalagem.DataSource = grps;
                cmbGrupoEmbalagem.DisplayMember = "Display";
                cmbGrupoEmbalagem.ValueMember = "Value";
            }
        }

        public void GetCompGruposEmbalagem()
        {
            dgvCompGE.Rows.Clear();
            
            //Popular linhas já compostas [ELIMINADO, DISFUNCIONAL]
            //GetCompGE(eID, aID);


            if (gID != "IVO_Suite.IVO+AddValue")
            {
                string sql = "SELECT C.id, A.ARTIGO, A.DESCRICAO, C.quant, A.CDU_REFANTIGA, C.obs FROM _IVO_ComposicaoGE AS C LEFT JOIN ARTIGO AS A ON A.ARTIGO=C.IDARTIGO WHERE IDGRUPO=" + gID;
                OdbcCommand cmd = new OdbcCommand(sql, cnn);
                cnn.Open();
                try
                {
                    OdbcDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            int q = Convert.ToInt32(dr[3]);
                            dgvCompGE.Rows.Add(dr[0], dr[1], dr[4], dr[2], CalcQuant2(QttEnc, q), dr[5]);
                        }
                    }
                }
                catch (OdbcException oe)
                {
                    MessageBox.Show(oe.Message, "ERRO SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                cnn.Close();
            }
        }

        private double CalcQuant2(double QuantEncomenda, double valor)
        {
            double Total;
            Total =Convert.ToDouble(QuantEncomenda / valor);
            Total = Math.Ceiling((double) QuantEncomenda/valor);
            return RoundUp(Total, 1);
        }

        public static double RoundUp(double figure, int precision)
        {
            double newFigure = Math.Round(figure, precision);
            double difference = figure - newFigure; double tolerance = 1 / Math.Pow(10, precision + 1);

            if (difference > tolerance)
            //Figure was rounded down
            {
                double padding = 1 / Math.Pow(10, precision); newFigure += padding;
            }
            return newFigure;
        }

        private void cmbGrupoEmbalagem_SelectedValueChanged(object sender, EventArgs e)
        {
            if (leID != null)
            {
                gID = cmbGrupoEmbalagem.SelectedValue.ToString();
                GetCompGruposEmbalagem();
            }
        }

        private void dgvLinhasPE_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewCell a = dgvLinhasPE.Rows[e.RowIndex].Cells["peArtigo"];
                DataGridViewCell q = dgvLinhasPE.Rows[e.RowIndex].Cells["peQuant"];
                DataGridViewCell r = dgvLinhasPE.Rows[e.RowIndex].Cells["CodBarras"];
                refArtigo = r.Value.ToString();
                aID = a.Value.ToString();
                rowIndexLinhasPE = e.RowIndex;
                QttEnc = Convert.ToInt32(q.Value);
                GetCompGE(eID, aID);
            }
        }

        public void SaveLinhasPE()
        {
            OdbcCommand cmd;
            string sql;
            int sGrupo = 0;
            DataGridViewCell i;
            DataGridViewCell a;
            DataGridViewCell d;
            DataGridViewCell q;
            DataGridViewCell o;

            if (cnn.State == ConnectionState.Closed) cnn.Open();

            foreach (DataGridViewRow row in dgvCompGE.Rows)
            {
                if (cnn.State == ConnectionState.Closed) cnn.Open();
                if (sGrupo == 0)
                {
                    try
                    {
                        if (cnn.State == ConnectionState.Closed) cnn.Open();
                        cmd = new OdbcCommand("DELETE FROM _IVO_LinhasGE WHERE idLinhaDoc='" + leID + "'", cnn);
                        cmd.ExecuteNonQuery();
                        cnn.Close();
                    }
                    catch (OdbcException oe)
                    {
                        if (cnn.State == ConnectionState.Open) cnn.Close();
                        MessageBox.Show(oe.Message);
                    }

                    //Gravar Nome do Grupo
                    sql = "INSERT INTO _IVO_LinhasGE " +
                                @"([numdoc],[artigo],[grupo],[descr]," +
                                @"idLinhaDoc) VALUES " +
                                @"('" + eID + "','" + aID + "'," + gID + ",'" + cmbGrupoEmbalagem.Text + "','" + leID + "')";

                    try
                    {
                        if (cnn.State == ConnectionState.Closed) cnn.Open();
                        cmd = new OdbcCommand(sql, cnn);
                        cmd.ExecuteNonQuery();
                    }
                    catch (OdbcException oe)
                    {
                        if (cnn.State == ConnectionState.Open) cnn.Close();
                        MessageBox.Show(oe.Message);
                    }

                }

                i = dgvCompGE.Rows[row.Index].Cells["id"];
                a = dgvCompGE.Rows[row.Index].Cells["cpeartigo"];
                d = dgvCompGE.Rows[row.Index].Cells["cpedescr"];
                q = dgvCompGE.Rows[row.Index].Cells["cpequant"];
                o = dgvCompGE.Rows[row.Index].Cells["obs"];

                if (a.Value != null && d.Value!= null)
                {
                    if (!Convert.IsDBNull(q.Value))
                    {
                        sql = "INSERT INTO _IVO_LinhasGE " +
                            @"([numdoc],[artigo],[grupo],[item],[descr],[quant],[obs]," +
                            @"[idLinhaDoc]) VALUES " +
                            @"('" + eID + "', '" + aID + "', " + gID + ", '" + a.Value + "', '" + d.Value + "', " + Convert.ToInt32(q.Value) + ", '" + o.Value + "'," +
                            @"'" + leID + "')";

                        try
                        {
                            if (cnn.State == ConnectionState.Closed) cnn.Open();
                            cmd = new OdbcCommand(sql, cnn);
                            cmd.ExecuteNonQuery();
                        }
                        catch (OdbcException oe)
                        {
                            if (cnn.State == ConnectionState.Open) cnn.Close();
                            MessageBox.Show(oe.Message);
                        }
                    }
                    sGrupo++;
                }
            }
            if (cnn.State == ConnectionState.Open) cnn.Close();

        }

        public void GetCompGE(string NumDocumento, string idArtigo)
        {
            dgvCompGE.Rows.Clear();
            
            string sql = "SELECT l.id,l.numdoc,l.artigo,l.grupo,l.item,l.descr,l.quant,l.obs,a.CDU_REFANTIGA "+
                        @"FROM [_IVO_LinhasGE] as l left join Artigo as a on a.artigo = l.item "+
                        @"WHERE l.artigo='" + aID + "' AND l.numdoc='" + eID + "'";

            OdbcCommand cmd = new OdbcCommand(sql, CalcCnn);
            if (CalcCnn.State == ConnectionState.Closed) CalcCnn.Open();
            OdbcDataReader dr = cmd.ExecuteReader();
            
            rowIndex = 0;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    dgvCompGE.Rows.Add(dr[0], dr[4], dr[8], dr[5], dr[6], dr[7]);
                    rowIndex++;
                }
            }
            dr.Close();
            CalcCnn.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvLinhasPE_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewCell a = dgvLinhasPE.Rows[e.RowIndex].Cells["peArtigo"];
                DataGridViewCell q = dgvLinhasPE.Rows[e.RowIndex].Cells["peQuant"];
                DataGridViewCell l = dgvLinhasPE.Rows[e.RowIndex].Cells["idlinha"];
                aID = a.Value.ToString();
                leID = l.Value.ToString();
                rowIndexLinhasPE = e.RowIndex;
                QttEnc = Convert.ToInt32(q.Value);
                GetCompGE(eID, aID);
            }
        }

        private void btnEliminarLinhaCompGE_Click(object sender, EventArgs e)
        {
            string sql = "DELETE FROM [_IVO_LinhasGE] WHERE ID=" + lID;
            OdbcCommand cmd = new OdbcCommand(sql, cnn);
            try
            {
                if (MessageBox.Show("Deseja eliminar esta linha?", "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (cnn.State == ConnectionState.Closed) cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                    GetCompGE(eID, aID);
                    GetLinhasDoc();
                }
            }
            catch (OdbcException oe)
            {
                MessageBox.Show(oe.Message, "ERRO SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvCompGE_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewCell l = dgvCompGE.Rows[e.RowIndex].Cells["id"];
                rowIndex = e.RowIndex;
                lID = Convert.ToInt32(l.Value);
            }
        }

        private void dgvCompGE_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                dgvCompGE.CurrentCell = dgvCompGE.Rows[e.RowIndex].Cells[e.ColumnIndex];
                DataGridViewCell l = dgvCompGE.Rows[e.RowIndex].Cells["id"];
                rowIndex = e.RowIndex;
                lID = Convert.ToInt32(l.Value);
            }
        }

        public void UpdateLinhas()
        {
            string sql = "";
            decimal dQ = 0;
            string sO = "";

            DataGridViewCell q = dgvCompGE.Rows[rowIndex].Cells["cpequant"];
            DataGridViewCell o = dgvCompGE.Rows[rowIndex].Cells["obs"];

            if (!Convert.IsDBNull(q.Value) || q.Value != "Infinity")
            {
                dQ = Convert.ToDecimal(q.Value);
                sO = Convert.ToString(o.Value);

                sql = "UPDATE _IVO_LinhasGE SET quant=" + dQ + ", obs='" + sO + "' where id=" + lID;
            }
            else
            {
                sO = Convert.ToString(o.Value);
                sql = "UPDATE _IVO_LinhasGE SET obs='" + sO + "' where id=" + lID;
            }

            try
            {
                if (cnn.State == ConnectionState.Closed) cnn.Open();
                OdbcCommand cmd = new OdbcCommand(sql, cnn);
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
            catch (OdbcException oe)
            {
                MessageBox.Show(oe.Message);
            }
        }

        private void dgvCompGE_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewCell l = dgvCompGE.Rows[e.RowIndex].Cells["id"];
                rowIndex = e.RowIndex;
                lID = Convert.ToInt32(l.Value);
            }
        }

        private void dgvCompGE_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            UpdateLinhas();
        }

        private void btnCopiarGE_Click(object sender, EventArgs e)
        {
            //APLICAR GE ESCOLHIDO A TODAS AS REFERENCIAS
            foreach (DataGridViewRow row in dgvLinhasPE.SelectedRows)
            {
                if (leID != "")
                {
                    SaveLinhasPE();
                }

                leID = "";
                GetLinhasDoc();
            }
        }

        private void btnDelGE_Click(object sender, EventArgs e)
        {
            string sql = "DELETE FROM _IVO_LinhasGE WHERE numdoc='" + eID + "' and artigo='" + aID + "'";
            OdbcCommand del = new OdbcCommand(sql, cnn);
            if(MessageBox.Show("Deseja eliminar o Plano de Embalagem desta referencia?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (cnn.State == ConnectionState.Closed) cnn.Open();
                try
                {
                    del.ExecuteNonQuery();
                    dgvCompGE.Rows.Clear();
                }
                catch (OdbcException oe)
                {
                    MessageBox.Show(oe.Message, "ERRO SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                cnn.Close();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string rptSource = "S:\\Produção\\Informatica\\REPORTS PRIMAVERA\\ANTIGO_EMBAL1_non.rpt";
            //string rptSource = "D:\\EMBAL1_non.rpt";
            string rptFilter = "{CabecDoc.NumDoc} = " + strNum + " and {CabecDoc.Serie} = '" + strSerie + "'";
            rptPrintPreviewForm pp = new rptPrintPreviewForm(rptSource, rptFilter);
            pp.MdiParent = this.MdiParent;
            pp.Show();
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            Embalagem.Historico h = new Embalagem.Historico(strConn, txtNome.Text, aID);
            h.MdiParent = this.MdiParent;
            h.Show();
        }

        private void dgvLinhasPE_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Embalagem.Historico h = new Embalagem.Historico(strConn, txtNome.Text, refArtigo);
            h.MdiParent = this.MdiParent;
            h.Show();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}
