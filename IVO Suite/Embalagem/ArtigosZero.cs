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
    public partial class ArtigosZero : Form
    {
        public string strSql;
        public string strCnn;
        SqlCommand cmd;
        SqlConnection cnn;
        SqlDataReader dr;

        public ArtigosZero(string ConnectionString)
        {
            InitializeComponent();
            strCnn = ConnectionString;
        }

        private void ArtigosZero_Load(object sender, EventArgs e)
        {
            cnn = new SqlConnection(strCnn);
            Gethem();
        }

        private void Gethem()
        {
            strSql = "select CGE.idArtigo, GE.COD from _IVO_ComposicaoGE as CGE left join _IVO_GruposEmbalagem as GE on GE.GECOD=CGE.idGrupo where quant=0";
            cmd = new SqlCommand(strSql, cnn);
            if (cnn.State == ConnectionState.Closed) cnn.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    dgvZero.Rows.Add(dr[0], dr[1]);
                }
            }
            dr.Close();
            cnn.Close();
        }

        private void dgvZero_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvZero_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
