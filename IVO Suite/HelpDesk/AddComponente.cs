using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace IVO_Suite.HelpDesk
{
    public partial class AddComponente : Form
    {
        public string strSql;
        public string strConn;
        public string eID;
        public string cID;
        Equipamentos frmEquip;

        SqlCommand cmd;
        SqlDataReader dr;
        SqlConnection cnn;
        
        public AddComponente(string ConnectionString, string idEquipamento, Equipamentos frmEquipamentos)
        {
            InitializeComponent();
            strConn = ConnectionString;
            eID = idEquipamento;
            frmEquip = frmEquipamentos;
        }

        private void AddComponente_Load(object sender, EventArgs e)
        {
            cnn = new SqlConnection(strConn);
            GetEquip();
        }

        private void GetEquip()
        {
            strSql = "SELECT id, name, serial FROM Computers where child=1";
            cmd = new SqlCommand(strSql, cnn);
            if (cnn.State == ConnectionState.Closed) cnn.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    dgvCompomentes.Rows.Add(0, dr[1], dr[2], dr[0]);
                }
            }
            dr.Close();
            cnn.Close();
        }

        private void SaveComponentes()
        {
            int i = 0;
            foreach (DataGridViewRow row in dgvCompomentes.Rows)
            {
                //Verificar checkbox
                DataGridViewCell check = dgvCompomentes.Rows[i].Cells[0];
                bool vCheck = Convert.ToBoolean(check.Value);
                if (vCheck)
                {
                    DataGridViewCell CellCID = dgvCompomentes.Rows[row.Index].Cells["id"];
                    if (CellCID.Value != null) cID = CellCID.Value.ToString();

                    //Elimina existentes
                    /*strSql = "DELETE FROM Componentes WHERE idComposto=" + eID;
                    cmd = new SqlCommand(strSql, cnn);
                    if (cnn.State == ConnectionState.Closed) cnn.Open();
                    try
                    {
                        cmd.ExecuteNonQuery();
                        frmEquip.GetComponentes();
                    }
                    catch (SqlException se)
                    {
                        MessageBox.Show(se.Message);
                    }
                    cnn.Close();*/

                    //Save
                    strSql = "INSERT INTO Componentes (idComposto, idComponente) VALUES " +
                        @"(" + eID + ", " + cID + ")";
                    cmd = new SqlCommand(strSql, cnn);
                    if (cnn.State == ConnectionState.Closed) cnn.Open();
                    try
                    {
                        cmd.ExecuteNonQuery();
                        frmEquip.GetComponentes(Convert.ToInt32(eID));
                    }
                    catch (SqlException se)
                    {
                        MessageBox.Show(se.Message);
                    }
                    cnn.Close();
                }
                else
                {
                    //Limpa existência
                    /*strSql = "DELETE FROM Componentes WHERE idComposto=" + eID;
                    cmd = new SqlCommand(strSql, cnn);
                    if (cnn.State == ConnectionState.Closed) cnn.Open();
                    try
                    {
                        cmd.ExecuteNonQuery();
                        frmEquip.GetComponentes();
                    }
                    catch (SqlException se)
                    {
                        MessageBox.Show(se.Message);
                    }
                    cnn.Close();*/
                }
                i++;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveComponentes();
        }
    }
}
