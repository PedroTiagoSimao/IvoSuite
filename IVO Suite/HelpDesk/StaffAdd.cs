using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IVO_Suite.HelpDesk
{
    public partial class StaffAdd : Form
    {
        public string strSql;
        public string strConn;
        public string strAction;
        public string idStaff;

        Staff frmStaff;

        SqlConnection cnn;
        SqlCommand cmd;
        SqlDataReader dr;

        public StaffAdd(string ConnectionString, string Action, string StaffID, Staff StaffForm)
        {
            InitializeComponent();
            strConn = ConnectionString;
            strAction = Action;
            idStaff = StaffID;
            frmStaff = StaffForm;
        }

        private void StaffAdd_Load(object sender, EventArgs e)
        {
            cnn = new SqlConnection(strConn);
            if (strAction == "edit")
            {
                GetStaff();
            }
        }

        private void GetStaff()
        {
            strSql = "Select * FROM Staff WHERE id=" + idStaff;
            cmd = new SqlCommand(strSql, cnn);
            if(cnn.State == ConnectionState.Closed)cnn.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    lblId.Text = dr[0].ToString();
                    txtNome.Text = dr[1].ToString();
                    txtDepart.Text = dr[2].ToString();
                    txtExtensao.Text = dr[3].ToString();
                    txtEmail.Text = dr[4].ToString();
                }
            }
            dr.Close();
            cnn.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            if (strAction == "edit")
            {
                strSql = "UPDATE Staff SET sname='" + txtNome.Text + "', sdepartment='" + txtDepart.Text + "', " +
                    @"sphone='" + txtExtensao.Text + "', semail='" + txtEmail.Text + "' WHERE id=" + idStaff;
                cmd = new SqlCommand(strSql, cnn);
                try
                {
                    if (cnn.State == ConnectionState.Closed) cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                    frmStaff.GetStaff();
                    this.Close();
                }
                catch (SqlException se)
                {
                    MessageBox.Show(se.ErrorCode + "\n" + se.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (strAction == "new")
            {
                strSql = "INSERT INTO Staff (sname, sdepartment, sphone, semail) VALUES " +
                    @"('" + txtNome.Text + "','" + txtDepart.Text + "','" + txtExtensao.Text + "','" + txtEmail.Text + "')";
                cmd = new SqlCommand(strSql, cnn);
                try
                {
                    if (cnn.State == ConnectionState.Closed) cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                    frmStaff.GetStaff();
                    this.Close();
                }
                catch (SqlException se)
                {
                    MessageBox.Show(se.ErrorCode + "\n" + se.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtNome_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Save();
            }
        }

        private void txtDepart_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Save();
            }
        }

        private void txtEmail_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Save();
            }
        }

        private void txtExtensao_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Save();
            }
        }
    }
}
