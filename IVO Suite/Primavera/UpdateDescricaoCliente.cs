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
    public partial class UpdateDescricaoCliente : Form
    {
        SqlConnection cnn;
        SqlCommand cmd;
        string strConn;

        public UpdateDescricaoCliente(string strConnPri)
        {
            InitializeComponent();
            strConn = strConnPri;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            cnn = new SqlConnection(strConn);

            cmd = new SqlCommand("UPDATE _IVO_LinhasPackingList SET DescricaoCliente=ArtigoCliente.DescricaoCli, ArtigoCliente=ArtigoCliente.ReferenciaCli " +
                @"FROM _IVO_LinhasPackingList, ArtigoCliente " +
                @"WHERE _IVO_LinhasPackingList.Artigo=ArtigoCliente.Artigo " +
                @"and ArtigoCliente.Cliente='" + txtCliente.Text + "'", cnn);

            try
            {
                if (cnn.State == ConnectionState.Closed) cnn.Open();
                cmd.ExecuteNonQuery();
                cnn.Close();
                MessageBox.Show("Descrições do packing list actualizadas com sucesso", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException se)
            {
                MessageBox.Show(se.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
