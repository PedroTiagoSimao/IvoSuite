using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace IVO_Suite.Embalagem
{
    public partial class Lembretes : Form
    {
        SqlConnection cnn;
        SqlConnection cnn2;
        string strConn;
        string strSql;
        SqlCommand cmd;
        SqlDataReader dr;

        public Lembretes(string ConnectionString)
        {
            InitializeComponent();
            strConn = ConnectionString;
        }

        private void Lembretes_Load(object sender, EventArgs e)
        {
            Rectangle workingArea = Screen.GetWorkingArea(this);
            this.Location = new Point(workingArea.Right - (Size.Width+5),
                                      workingArea.Bottom - (Size.Height+70));

            cnn = new SqlConnection(strConn);
            cnn2 = new SqlConnection(strConn);
            GetEncIndefinidas();
            //getLembretes();
        }

        private void GetEncIndefinidas()
        {
            strSql = "SELECT LinhasDoc.DataEntrega, CabecDoc.Entidade, CabecDoc.NumDoc, CabecDoc.Serie " +
                @"FROM ((CabecDoc LEFT JOIN LinhasDoc ON CabecDoc.Id=LinhasDoc.IdCabecDoc) LEFT JOIN LinhasDocStatus ON LinhasDocStatus.IdLinhasDoc=LinhasDoc.Id) " +
                @"WHERE CabecDoc.TipoDoc='ECL' and (LinhasDoc.CDU_GrupoEmbal='**' OR LinhasDoc.CDU_GrupoEmbal IS NULL) "+
                @"AND LinhasDocStatus.Quantidade>LinhasDocStatus.QuantTrans AND CabecDoc.Serie>2010 AND LinhasDoc.TipoLinha='11' AND LinhasDoc.Artigo NOT LIKE '**'" +
                @"GROUP BY CabecDoc.NumDoc, LinhasDoc.DataEntrega, CabecDoc.Entidade, CabecDoc.Serie " +
                @"ORDER BY CabecDoc.NumDoc, CabecDoc.Serie";

            cmd = new SqlCommand(strSql, cnn);
            if (cnn.State == ConnectionState.Closed) cnn.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    dgvLembretes.Rows.Add(dr[0], dr[1], dr[2]+"-"+dr[3], "Esta encomenda contém artigos sem grupo de embalagem definido!");
                }
            }
            dr.Close();
            cnn.Close();
        }

        private void getLembretes()
        {
            //dgvLembretes.Rows.Clear();
            strSql = "SELECT * FROM _IVO_Lembretes";
            cmd = new SqlCommand(strSql, cnn);
            if (cnn.State == ConnectionState.Closed) cnn.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    dgvLembretes.Rows.Add(dr[1], dr[2], dr[3], dr[4]);
                }
            }
            dr.Close();
            cnn.Close();
        }

        public void Save()
        {
            //ELIMINAR ANTIGOS
            strSql = "DELETE FROM _IVO_Lembretes";
            SqlCommand cmd = new SqlCommand(strSql, cnn);
            if (cnn.State == ConnectionState.Closed) cnn.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException se)
            {
                MessageBox.Show("Erro sql", se.Message);
            }
            

            //INSERIR TABELA
            foreach(DataGridViewRow row in dgvLembretes.Rows)
            {
                if (row.Cells["data"].Value != null)
                {
                    strSql = "INSERT INTO _IVO_Lembretes (data, cliente, enc, obs) VALUES (" +
                        @"'" + row.Cells["data"].Value.ToString() + "', " +
                        @"'" + row.Cells["cliente"].Value.ToString() + "', " +
                        @"'" + row.Cells["enc"].Value.ToString() + "', " +
                        @"'" + row.Cells["obs"].Value.ToString() + "')";

                    cmd = new SqlCommand(strSql, cnn);
                    if (cnn.State == ConnectionState.Closed) cnn.Open();
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException se)
                    {
                        MessageBox.Show("Erro sql", se.Message);
                    }
                }
            }
            cnn.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

    }
}
