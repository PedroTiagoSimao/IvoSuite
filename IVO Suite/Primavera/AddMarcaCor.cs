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
    public partial class AddMarcaCor : Form
    {
        string strTabela;
        string strCodigo;
        string strDescricao;
        string strFormTitle;
        string strConn;
        string strSql;
        string strId;
        MarcasCores frmMarcasCores;

        SqlConnection cnn;
        SqlCommand cmd;
        //SqlDataReader dr;

        public AddMarcaCor(string Tabela, string ConnectionString, MarcasCores FormMarcasCores, string IdMarcaCor)
        {
            InitializeComponent();
            strTabela = Tabela;
            strConn = ConnectionString;
            frmMarcasCores = FormMarcasCores;
            strId = IdMarcaCor;
        }

        private void DefineVariables(string Tabela)
        {
            if (Tabela == "_IVO_Cores")
            {
                strCodigo = "CodigoCor";
                strDescricao = "DescricaoCor";
                strFormTitle = "Cor Técnica";
            }

            if (Tabela == "_IVO_Marcas")
            {
                strCodigo = "CodigoMarca";
                strDescricao = "DescricaoMarca";
                strFormTitle = "Marca Técnica";
                txtRefForn.Visible = false;
                lblRefForn.Visible = false;
                txtPantone.Visible = false;
                lblPantone.Visible = false;
            }
        }

        private void AddMarcaCor_Load(object sender, EventArgs e)
        {
            cnn = new SqlConnection(strConn);
            DefineVariables(strTabela);

            if (strId == "")
            {
                this.Name = "Adicionar " + strFormTitle;
            }
            else
            {
                this.Name = "Editar " + strFormTitle;
                GetData(strId);
            }
        }

        private void GetData(string Id)
        {
            strSql = "SELECT * FROM " + strTabela + " WHERE ID=" + Id;
            cmd = new SqlCommand(strSql, cnn);
            if (cnn.State == ConnectionState.Closed) cnn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    txtCodigo.Text = dr[1].ToString();
                    txtDescricao.Text = dr[2].ToString();
                    txtObs.Text = dr[3].ToString();
                    txtPantone.Text = dr[4].ToString();
                    txtRefForn.Text = dr[5].ToString();
                }
            }
            dr.Close();
            cnn.Close();
        }

        private void Save()
        {
            strSql = "INSERT INTO " + strTabela + " " +
                @"(" + strCodigo + ", " + strDescricao + ", RefForn, Pantone, Obs) VALUES " +
                @"('" + txtCodigo.Text + "', '" + txtDescricao.Text + "', '" + txtRefForn.Text + "', '" + txtPantone.Text + "', '" + txtObs.Text + "')";

            cmd = new SqlCommand(strSql, cnn);
            try
            {
                if (cnn.State == ConnectionState.Closed) cnn.Open();
                cmd.ExecuteNonQuery();
                cnn.Close();
                MessageBox.Show(strFormTitle + " adicionada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmMarcasCores.GetData(strTabela);
                this.Close();
            }
            catch (SqlException se)
            {
                MessageBox.Show(se.Message + "\r\n" + strSql, "Erro SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Edit(string Id)
        {
            strSql = "UPDATE " + strTabela + " SET " +
                @"" + strCodigo + "='" + txtCodigo.Text + "', " + strDescricao + "='" + txtDescricao.Text + "', " +
                @"RefForn='" + txtRefForn.Text + "', Pantone='" + txtPantone.Text + "', Obs='" + txtObs.Text + "' WHERE ID=" + Id;

            cmd = new SqlCommand(strSql, cnn);
            try
            {
                if (cnn.State == ConnectionState.Closed) cnn.Open();
                cmd.ExecuteNonQuery();
                cnn.Close();
                MessageBox.Show(strFormTitle + " editada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmMarcasCores.GetData(strTabela);
                this.Close();
            }
            catch (SqlException se)
            {
                MessageBox.Show(se.Message + "\r\n" + strSql, "Erro SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (strId == "")
            {
                Save();
            }
            else
            {
                Edit(strId);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
