using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace IVO_Suite.HelpDesk
{
    public partial class Equipamentos : Form
    {
        public string strConn;
        public string strSql;
        public string compListQuery;
        public string child;
        public string eID;
        SqlConnection cnn;
        SqlCommand cmd;
        SqlDataReader dr;
        public int id = 0;
        public string pc;
        public int tID;
        ListEquip le;

        IVO_HelpDesk.Main m;

        public Equipamentos(string ConnectionString, int ComputerID, ListEquip ListaEquipamentos)
        {
            InitializeComponent();
            strConn = ConnectionString;
            id = ComputerID;
            le = ListaEquipamentos;
        }

        private void Computadores_Load(object sender, EventArgs e)
        {
            this.Location = new Point(450, 0);
            cnn = new SqlConnection(strConn);
            cnn.Open();
            cnn.Close();
            GetStaff();
            GetComputer(id);
            GetTickets(id);
            GetComponentes(id);
            compListQuery = "SELECT c.ID, c.name, c.adminuser, c.localiz, s.sname, c.type, c.serial, (select name from computers where id=e.idComposto) FROM (Computers as c left join Componentes as e on e.idComponente=c.id) LEFT JOIN Staff as s on s.id=c.adminuser WHERE C.CHILD=0 ORDER BY name";
        }

        public void GetTickets(int ComputerID)
        {
            dgvPCTickets.Rows.Clear();
            strSql = "SELECT id, tdateopened, tdesc, tstaff, tstate, tdateclosed FROM Tickets WHERE tpc='" + ComputerID.ToString() + "'";
            cmd = new SqlCommand(strSql, cnn);
            if (cnn.State == ConnectionState.Closed) cnn.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    string state = dr[4].ToString();
                    switch (state)
                    {
                        case "0":
                            state = "Aberto";
                            break;

                        case "1":
                            state = "Stand By";
                            break;

                        case "2":
                            state = dr[5].ToString();
                            break;

                        case "3":
                            state = "CANCELADO";
                            break;
                    }
                    dgvPCTickets.Rows.Add(dr[0], dr[1], dr[2], dr[3], state);
                }
            }
            dr.Close();
            cnn.Close();
        }

        private void GetStaff()
        {
            cmbUsers.Items.Clear();
            ArrayList grps = new ArrayList();
            strSql = "SELECT id, sname FROM Staff ORDER BY sname";
            cmd = new SqlCommand(strSql, cnn);
            if (cnn.State == ConnectionState.Closed) cnn.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    grps.Add(new IVO.AddValue(dr[1].ToString(), dr[0].ToString()));
                }
            }
            dr.Close();
            cnn.Close();

            cmbUsers.DataSource = grps;
            cmbUsers.ValueMember = "Value";
            cmbUsers.DisplayMember = "Display";
        }

        private void GetComputer(int id)
        {
            if (id > 0)
            {
                strSql = "SELECT c.id,c.name,c.adminuser,c.localiz,c.obs,c.av,c.cpu,c.mhz,c.ram,c.ramtype," +
                    @"c.os,c.office,c.gravador,c.docpc,c.docos,c.docoffice, s.sname, c.type, c.serial, c.child, "+
                    @"(SELECT name from computers where id=e.idcomposto), c.syskey " +
                    "FROM ([Computers] as c LEFT JOIN Staff as s on s.id = c.adminuser) LEFT JOIN Componentes as e on e.idComponente=c.id WHERE c.id=" + id;
                cmd = new SqlCommand(strSql, cnn);
                if (cnn.State == ConnectionState.Closed) cnn.Open();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        txtname.Text = dr[1].ToString();
                        lblEquipamento.Text = dr[1].ToString();
                        cmbUsers.Text = dr[16].ToString();
                        txtlocaliz.Text = dr[3].ToString();
                        txtobs.Text = dr[4].ToString();
                        txtAv.Text = dr[5].ToString();
                        txtcpu.Text = dr[6].ToString();
                        txtmhz.Text = dr[7].ToString();
                        txtram.Text = dr[8].ToString();
                        txtramtype.Text = dr[9].ToString();
                        txtos.Text = dr[10].ToString();
                        txtoffice.Text = dr[11].ToString();
                        txtcdr.Text = dr[12].ToString();
                        txtdocbuy.Text = dr[13].ToString();
                        txtdocos.Text = dr[14].ToString();
                        txtdocoffice.Text = dr[15].ToString();
                        cmbTipo.Text = dr[17].ToString();
                        txtSerial.Text = dr[18].ToString();
                        txtComponente.Text = dr[20].ToString();
                        txtKey.Text = dr[21].ToString();

                        if (dr[19].ToString() == "1")
                        {
                            chkChild.Checked = true;
                            txtComponente.Visible = true;
                        }
                        
                    }
                }
                else
                {
                    MessageBox.Show("O identificador não existe na base de dados.\nContacte o Administrador do seu sistema", "Erro de identificador", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                dr.Close();
                cnn.Close();

                GetTickets(id);

            } 
        }

        private void Save(int ComputerID)
        {
            if (chkChild.Checked == true)
            {
                child = "1";
            }
            else
            {
                child = "0";
            }

            if (id == 0)
            {
                strSql = "INSERT INTO Computers ([name],[adminuser],[localiz],[obs],[av],[cpu],[mhz],[ram],[ramtype]," +
                    @"[os],[office],[gravador],[docpc],[docos],[docoffice], [type], [serial], [child], [syskey]) VALUES ('" + txtname.Text + "'," +
                    @"'" + cmbUsers.SelectedValue.ToString() + "','" + txtlocaliz.Text + "','" + txtobs.Text + "','" + txtAv.Text + "'," +
                    @"'" + txtcpu.Text + "','" + txtmhz.Text + "','" + txtram.Text + "','" + txtramtype.Text + "'," +
                    @"'" + txtos.Text + "','" + txtoffice.Text + "','" + txtcdr.Text + "','" + txtdocbuy.Text + "'," +
                    @"'" + txtdocos.Text + "','" + txtdocoffice.Text + "', '" + cmbTipo.Text + "', '" + txtSerial.Text + "', " +
                    @"" + child + ", '" + txtKey.Text + "')";

                cmd = new SqlCommand(strSql, cnn);
                try
                {
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                    ClearTextBoxes();
                }
                catch (SqlException se)
                {
                    MessageBox.Show(se.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (id > 0)
            {
                strSql = "UPDATE Computers SET " +
                    @"[name]='" + txtname.Text + "',[adminuser]='" + cmbUsers.SelectedValue.ToString() + "'," +
                    @"[localiz]='" + txtlocaliz.Text + "',[obs]='" + txtobs.Text + "'," +
                    @"[av]='" + txtAv.Text + "',[cpu]='" + txtcpu.Text + "',[mhz]='" + txtmhz.Text + "'," +
                    @"[ram]='" + txtram.Text + "',[ramtype]='" + txtramtype.Text + "'," +
                    @"[os]='" + txtos.Text + "',[office]='" + txtoffice.Text + "'," +
                    @"[gravador]='" + txtcdr.Text + "',[docpc]='" + txtdocbuy.Text + "'," +
                    @"[docos]='" + txtdocos.Text + "',[docoffice]='" + txtdocoffice.Text + "', " +
                    @"[type]='" + cmbTipo.Text + "', [serial]='" + txtSerial.Text + "', " +
                    @"[child]=" + child + ", syskey='" + txtKey.Text + "' WHERE id=" + id;

                cmd = new SqlCommand(strSql, cnn);
                try
                {
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                    ClearTextBoxes();
                }
                catch (SqlException se)
                {
                    MessageBox.Show(se.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ClearTextBoxes()
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save(id);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            id = 0;
            Equipamentos eq = new Equipamentos(strConn, 0, le);
            eq.MdiParent = this.MdiParent;
            eq.Show();
            ClearTextBoxes();
        }

        private void dgcPCTickets_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgvPCTickets.Columns[e.ColumnIndex].Name == "tstate")
            {
                if (e.Value != null)
                {
                    string stringValue = (string)e.Value;
                    if ((stringValue.IndexOf("2") > -1))
                    {
                        e.CellStyle.BackColor = Color.Green;
                        e.CellStyle.ForeColor = Color.White;
                    }

                    if ((stringValue == "CANCELADO"))
                    {
                        e.CellStyle.BackColor = Color.DarkGray;
                        e.CellStyle.ForeColor = Color.White;
                    }

                    if ((stringValue == "Stand By"))
                    {
                        e.CellStyle.BackColor = Color.Navy;
                        e.CellStyle.ForeColor = Color.White;
                    }
                }
            }
        }

        public void GetComponentes(int idComposto)
        {
            dgvComponentes.Rows.Clear();
            strSql = "select e.name, e.serial, e.id, c.id from Componentes as c left join computers as e on e.id=c.idcomponente where c.idcomposto=" + id;
            cmd = new SqlCommand(strSql, cnn);
            if (cnn.State == ConnectionState.Closed) cnn.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    dgvComponentes.Rows.Add(dr[0], dr[1], dr[3]);
                }
            }
            dr.Close();
            cnn.Close();
        }

        private void dgvPCTickets_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewCell cellTid = dgvPCTickets.Rows[e.RowIndex].Cells["tid"];
                tID = Convert.ToInt32(cellTid.Value);
            }
        }

        private void btnTickets_Click(object sender, EventArgs e)
        {
            m = new IVO_HelpDesk.Main();
            m.MdiParent = this.MdiParent;
            m.Show();

            IVO_HelpDesk.Ticket t = new IVO_HelpDesk.Ticket("new", strConn, "0", m, Convert.ToInt32(pc));
            t.MdiParent = this.MdiParent;
            t.Show();
        }

        private void dgvPCTickets_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            IVO_HelpDesk.Interventions i = new IVO_HelpDesk.Interventions(strConn, tID);
            i.MdiParent = this.MdiParent;
            i.Show();
        }

        private void btnAddComponente_Click(object sender, EventArgs e)
        {
            AddComponente ac = new AddComponente(strConn, id.ToString(), this);
            ac.MdiParent = this.MdiParent;
            ac.Show();
        }

        private void dgvComponentes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < -1)
            {
                DataGridViewCell CelleId = dgvComponentes.Rows[e.RowIndex].Cells["eid"];
                eID = CelleId.Value.ToString();
            }
        }

        private void dgvComponentes_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.Button == MouseButtons.Right)
            {
                dgvComponentes.Rows[e.RowIndex].Selected = true;
                Rectangle r = dgvComponentes.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                DataGridViewCell CelleId = dgvComponentes.Rows[e.RowIndex].Cells["eid"];
                eID = CelleId.Value.ToString();
                contextMenuStrip1.Show((Control)sender, r.Left + e.X, r.Top + e.Y);
            }
        }

        private void btnDeleteComponente_Click(object sender, EventArgs e)
        {
            strSql = "DELETE FROM Componentes where id=" + eID;
            cmd = new SqlCommand(strSql, cnn);
            try
            {
                if (cnn.State == ConnectionState.Closed) cnn.Open();
                cmd.ExecuteNonQuery();
                cnn.Close();
                GetComponentes(id);
            }
            catch (SqlException se)
            {
                MessageBox.Show(se.Message);
            }
        }

        private void chkChild_Click(object sender, EventArgs e)
        {
            if (chkChild.Checked == true)
            {
                txtComponente.Visible = true;
            }
            else
            {
                txtComponente.Visible = false;
            }
        }

        private void btnAddTicket_Click(object sender, EventArgs e)
        {
            IVO_HelpDesk.Main frmMain = new IVO_HelpDesk.Main();
            IVO_HelpDesk.Ticket ticket = new IVO_HelpDesk.Ticket("new", strConn, "0", frmMain, id);
            ticket.MdiParent = this.MdiParent;
            ticket.Show();
        }
    }
}
