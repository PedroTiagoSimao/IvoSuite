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

namespace IVO_Suite.Embalagem
{
    public partial class PlanosEmbalamento : Form
    {
        SqlConnection cnn;
        SqlCommand cmd;
        SqlDataReader dr;
        public string strConn;
        public int idPlano;
        public int nPlano;
        public string sqlQuery;
        public bool doEdit;
        PlanearEmbalamento frmPE;

        public PlanosEmbalamento(string ODBCConnectionString, PlanearEmbalamento FormPlanearEmbalamento)
        {
            InitializeComponent();
            strConn = ODBCConnectionString;
            frmPE = FormPlanearEmbalamento;
        }

        private void PlanosEmbalamento_Load(object sender, EventArgs e)
        {
            cnn = new SqlConnection(strConn);
            GetPlanos(cmbEditPlano.ComboBox);
        }

        private void GetPlanos(ComboBox PlanosBox)
        {
            ArrayList pEmbal = new ArrayList();
            string sql = "SELECT ID, NPLANO, SEMANA, ANO, ABERTO FROM _IVO_PlanoEmbalamento";
            cmd = new SqlCommand(sql, cnn);
            if (cnn.State == ConnectionState.Closed) cnn.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    pEmbal.Add(new IVO.AddValue(dr[1].ToString() + " | " + dr[2].ToString() + " | " + dr[3].ToString(), dr[0].ToString()));
                }
            }
            dr.Close();
            cnn.Close();

            PlanosBox.DataSource = pEmbal;
            if (pEmbal.Count != 0)
            {
                PlanosBox.DisplayMember = "Display";
                PlanosBox.ValueMember = "Value";
            }
        }

        private void SavePlano(bool Edit)
        {
            string str = "";
            int i = 0;
            if (chkOpen.Checked == true) i = 1;
            if (txtAno.Text != "")
            {
                if (txtnPlano.Text != "")
                {
                    if (txtSemana.Text != "")
                    {
                            if (Edit)
                            {
                                /*if (CheckLinhasPlano(idPlano.ToString()))
                                {
                                    str = "editado";
                                    sqlQuery = "UPDATE _IVO_PlanoEmbalamento SET nplano='" + txtnPlano.Text + "', " +
                                        @"semana='" + txtSemana.Text + "', ano='" + txtAno.Text + "', aberto=" + i + " WHERE id=" + idPlano;
                                }
                                else
                                {
                                    MessageBox.Show("Este plano ja contém linhas de encomenda.\nElimine as linhas do plano antes de fazer qualquer alteração.", "Impossivel Editar", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                    return;
                                }*/

                                str = "editado";
                                sqlQuery = "UPDATE _IVO_PlanoEmbalamento SET nplano='" + txtnPlano.Text + "', " +
                                    @"semana='" + txtSemana.Text + "', ano='" + txtAno.Text + "', aberto=" + i + " WHERE id=" + idPlano;
                            }
                            else
                            {
                                if (CheckPlanoNumber(txtnPlano.Text, txtAno.Text))
                                {
                                    str = "adicionado";
                                    sqlQuery = "INSERT INTO _IVO_PlanoEmbalamento (nplano, semana, ano, aberto) VALUES " +
                                        @"('" + txtnPlano.Text + "', '" + txtSemana.Text + "', '" + txtAno.Text + "', " + i + ")";
                                }
                                else
                                {
                                    MessageBox.Show("Nº de Plano escolhido já atribuido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                    txtnPlano.Focus();
                                    return;
                                }
                            }

                            cmd = new SqlCommand(sqlQuery, cnn);
                            try
                            {
                                if (cnn.State == ConnectionState.Closed) cnn.Open();
                                cmd.ExecuteNonQuery();
                                cnn.Close();
                                MessageBox.Show("Plano " + str + " com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                GetPlanos(cmbEditPlano.ComboBox);
                                txtAno.Text = "";
                                txtnPlano.Text = "";
                                txtSemana.Text = "";
                                idPlano = 0;
                                frmPE.GetPlanosEmbalamento();
                            }
                            catch (SqlException oe)
                            {
                                MessageBox.Show(oe.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                    }
                    else
                    {
                        MessageBox.Show("Falta definir a semana correspondente", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtSemana.Focus();
                        txtSemana.BackColor = Color.Orange;
                    }
                }
                else
                {
                    MessageBox.Show("Falta definir o nº do plano", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtnPlano.Focus();
                    txtnPlano.BackColor = Color.Orange;
                }
            }
            else
            {
                MessageBox.Show("Falta definir o ano correspondente", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAno.Focus();
                txtAno.BackColor = Color.Orange;
            }
        }

        private void cmbEditPlano_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEditPlano.ComboBox.SelectedValue.ToString() != "IVO_Suite.IVO+AddValue")
            {
                idPlano = Convert.ToInt32(cmbEditPlano.ComboBox.SelectedValue.ToString());
                EditPlano(idPlano);
            }
        }

        private void EditPlano(int id)
        {
            sqlQuery = "SELECT * FROM _IVO_PlanoEmbalamento WHERE ID=" + id;
            cmd = new SqlCommand(sqlQuery, cnn);
            if (cnn.State == ConnectionState.Closed) cnn.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    txtnPlano.Text = dr[1].ToString();
                    txtSemana.Text = dr[2].ToString();
                    txtAno.Text = dr[3].ToString();
                    if (dr[4].ToString() == "1") { chkOpen.Checked = true; } else { chkOpen.Checked = false; }
                }
            }
            dr.Close();
            cnn.Close();
            txtnPlano.Focus();
        }

        private bool CheckPlanoNumber(string nPlano, string Ano)
        {
            string checkQuery = "SELECT * FROM _IVO_PlanoEmbalamento WHERE nplano='" + nPlano + "'  AND ano='" + Ano + "'";
            SqlCommand checkCmd = new SqlCommand(checkQuery, cnn);
            if (cnn.State == ConnectionState.Closed) cnn.Open();
            SqlDataReader checkDr = checkCmd.ExecuteReader();
            if (checkDr.HasRows)
            {
                checkDr.Close();
                cnn.Close(); 
                return false;
            }
            else
            {
                checkDr.Close();
                cnn.Close(); 
                return true;
            }
        }

        private bool CheckLinhasPlano(string nPlano)
        {
            string checkQuery = "SELECT * FROM _IVO_LinhasPlanoEmbalamento WHERE idPlano='" + nPlano + "'";
            SqlCommand checkCmd = new SqlCommand(checkQuery, cnn);
            if (cnn.State == ConnectionState.Closed) cnn.Open();
            SqlDataReader checkDr = checkCmd.ExecuteReader();
            if (checkDr.HasRows)
            {
                checkDr.Close();
                cnn.Close();
                return false;
            }
            else
            {
                checkDr.Close();
                cnn.Close();
                return true;
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            if (idPlano == 0)
            {
                SavePlano(false);
            }
            else
            {
                SavePlano(true);
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            idPlano = 0;
            txtnPlano.Text = "";
            txtSemana.Text = "";
            txtAno.Text = "";
            txtnPlano.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtnPlano_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            { txtSemana.Focus(); }
        }

        private void txtSemana_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            { txtAno.Focus(); }
        }

        private void txtAno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                doEdit = idPlano == 0 ? false : true;
                SavePlano(doEdit);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string encs = "";
            string sql = "select C.numdoc, C.serie from _IVO_LinhasPlanoEmbalamento as P left join CabecDoc as C on C.id=P.idCabecDoc where P.idPlano=" + txtnPlano.Text;
            cmd = new SqlCommand(sql, cnn);
            if (cnn.State == ConnectionState.Closed) cnn.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    encs = encs + dr[0].ToString() + "-" + dr[1].ToString() + "; ";
                }
                dr.Close();
                cnn.Close();
                MessageBox.Show("Não é permitido eliminar planos com encomendas associadas.\nEncomendas: " + encs, "Erro ao eliminar plano");
            }
            else
            {
                dr.Close();
                cnn.Close();
                sql = "DELETE FROM _IVO_PlanoEmbalamento WHERE ID=" + idPlano;
                SqlCommand cm = new SqlCommand(sql, cnn);
                try
                {
                    cnn.Open();
                    cm.ExecuteNonQuery();
                    cnn.Close();
                    idPlano = 0;
                    txtnPlano.Text = "";
                    txtSemana.Text = "";
                    txtAno.Text = "";
                    txtnPlano.Focus();
                    dr.Close();
                    cnn.Close();
                    GetPlanos(cmbEditPlano.ComboBox);
                    frmPE.GetPlanosEmbalamento();
                }
                catch (SqlException se)
                {
                    MessageBox.Show(se.Message, "Erro ao eliminar plano");
                }
            }
        }
    }
}
