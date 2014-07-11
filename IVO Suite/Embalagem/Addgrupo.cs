using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Odbc;

namespace IVO_Suite.Embalagem
{
    public partial class Addgrupo : Form
    {
        GruposEmbalagem GE;
        OdbcConnection cnn;

        public string strConn;
        public int lastGE;
        public string strAction;
        public string strIdGrupo;

        public Addgrupo(string ConnectionString, GruposEmbalagem FormGruposEmbalagem, string Action, string IdGrupo)
        {
            InitializeComponent();
            strConn = ConnectionString;
            GE = FormGruposEmbalagem;
            strAction = Action;
            strIdGrupo = IdGrupo;
        }

        private void Addgrupo_Load(object sender, EventArgs e)
        {
            cnn = new OdbcConnection(strConn);

            if (strAction == "insert")
            {
                GetLastGrupo();
                txtNum.Enabled = false;
                txtNum.Text = lastGE.ToString();
                txtDescr.Focus();
                this.Text = "Adicionar Grupo";
            }

            if (strAction == "edit")
            {
                GetGrupo(strIdGrupo);
                txtNum.Enabled = false;
                txtDescr.Focus();
                this.Text = "Editar Grupo";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GetGrupo(string id)
        {
            string sql = "SELECT * FROM _IVO_GruposEmbalagem WHERE ID=" + id;
            OdbcCommand cmd = new OdbcCommand(sql, cnn);
            cnn.Open();
            OdbcDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    txtNum.Text = dr[1].ToString();
                    txtDescr.Text = dr[2].ToString();
                    txtCod.Text = dr[6].ToString();
                }
            }
            dr.Close();
            cnn.Close();   
        }

        public void GetLastGrupo()
        {
            string sql = "SELECT TOP 1 GECOD FROM _IVO_GruposEmbalagem ORDER BY ID DESC";
            OdbcCommand cmd = new OdbcCommand(sql, cnn);
            cnn.Open();
            OdbcDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    lastGE = Convert.ToInt32(dr[0]) + 1;
                }
            }
            dr.Close();
            cnn.Close();    

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(strAction == "insert") AdicionarGrupo();
            if (strAction == "edit") EditarGrupo();
            this.Close();
        }

        public void AdicionarGrupo()
        {
            if (!VerifyName(txtDescr.Text))
            {
                if (!VerifyCode(txtNum.Text))
                {
                    string sql = "INSERT INTO _IVO_GruposEmbalagem ([GECOD],[GEDESCR],[GETIPO],[GEPESS],[GEPCHR], [COD]) VALUES " +
                        @"('" + txtNum.Text + "','" + txtDescr.Text + "','" + cmbTipo.Text + "', '" + txtPess.Text + "'," +
                        @"'" + txtPcHr.Text + "', '" + txtCod.Text + "')";

                    OdbcCommand cmd = new OdbcCommand(sql, cnn);
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    ClearTxT();
                    GE.GetGE();
                    cnn.Close();
                }
                else
                {
                    MessageBox.Show("Código de grupo já existente!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNum.Focus();
                    txtNum.SelectAll();
                }
            }
            else
            {
                MessageBox.Show("Nome de grupo já existente!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDescr.Focus();
                txtDescr.SelectAll();
            }
        }

        public bool VerifyName(string GroupName)
        {
            string sql = "SELECT * FROM _IVO_GruposEmbalagem WHERE GEDESCR='" + GroupName + "'";
            OdbcCommand cmd = new OdbcCommand(sql, cnn);
            if (cnn.State == ConnectionState.Closed) cnn.Open();
            OdbcDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                dr.Close();
                cnn.Close();
                return true;
            }
            else
            {
                dr.Close();
                cnn.Close();
                return false;
            }
        }

        public bool VerifyCode(string GroupCode)
        {
            string sql = "SELECT * FROM _IVO_GruposEmbalagem WHERE GECOD='" + GroupCode + "'";
            OdbcCommand cmd = new OdbcCommand(sql, cnn);
            if (cnn.State == ConnectionState.Closed) cnn.Open();
            OdbcDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                dr.Close();
                cnn.Close();
                return true;
            }
            else
            {
                dr.Close();
                cnn.Close();
                return false;
            }
        }

        public void EditarGrupo()
        {
            string sql = "UPDATE _IVO_GruposEmbalagem SET [GECOD]='" + txtNum.Text + "',[GEDESCR]='" + txtDescr.Text + "', " +
            @"[GETIPO]='" + cmbTipo.Text + "',[GEPESS]='" + txtPess.Text + "',[GEPCHR]='" + txtPcHr.Text + "', " +
            @"[COD]='" + txtCod.Text + "' WHERE ID=" + strIdGrupo;

            OdbcCommand cmd = new OdbcCommand(sql, cnn);
            cnn.Open();
            cmd.ExecuteNonQuery();
            ClearTxT();
            GE.GetGE();
            cnn.Close();
        }

        public void ClearTxT()
        {
            txtNum.Text = "";
            txtDescr.Text = "";
            txtPcHr.Text = "";
            txtPess.Text = "";
        }
    }
}