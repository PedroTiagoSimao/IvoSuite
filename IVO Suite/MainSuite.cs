using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Odbc;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Principal;

namespace IVO_Suite
{
    public partial class MainSuite : Form
    {
        OdbcConnection cnn;
        public string cnnSql;
        public string sArmazem;
        public string strConnStock;
        public string strConnEnc;
        public string strConnHD;
        public string strConnPri;
        public MainSuite()
        {
            InitializeComponent();
        }

        private void MainSuite_Load(object sender, EventArgs e)
        {
            BackGroundImage("S:\\Produção\\Informatica\\bg101.png");

            cnnSql = "DSN=svr2_stcks";
            strConnEnc = "DSN=Primavera;Uid=sa;pwd=***";
            //strConnEnc = "DSN=PriTeste;Uid=sa;pwd=***";
            strConnHD = "Data Source=SVR\\LP750;Initial Catalog=IVOHD;User Id=sa;Password=***;";
            strConnPri = "Data Source=SVR\\LP750;Initial Catalog=PRIEIC;User Id=sa;Password=***;";
            //strConnPri = "Data Source=SVR\\LP750;Initial Catalog=PRITESTE;User Id=sa;Password=***;";
            cnn = new OdbcConnection("DSN=svr2_stcks");

            string fileV = "";
            string fileN = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
            if(System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
            {
             fileV = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
            }
            
            this.Text = fileN + " - " + fileV;
            

            DefineActiveMenus(WindowsIdentity.GetCurrent().Name.ToString());

            Embalagem.Lembretes l = new Embalagem.Lembretes(strConnPri);
            l.MdiParent = this;
            l.Show();
        }

        private void DefineActiveMenus(string GetUserName)
        {
            string[] UserName = GetUserName.Split(new Char[] {'\\'});

            tsmHelpdesk.Enabled = true;
            tsmEmbalagem.Enabled = true;
            tsmPrimavera.Enabled = true;
            tsmProdução.Enabled = true;
            tsmStock.Enabled = true;
        }

        private void BackGroundImage(string _file)
        {
            string imagepath = _file;
            System.IO.FileStream fs;
            this.BackgroundImageLayout = ImageLayout.Center;

            if (System.IO.File.Exists(imagepath))
            {
                fs = System.IO.File.OpenRead(imagepath);
                fs.Position = 0;
                foreach (Control ctl in this.Controls)
                {
                    if (ctl is MdiClient)
                    {
                        ctl.BackColor = Color.DimGray;
                        ctl.BackgroundImage = System.Drawing.Image.FromStream(fs);
                        break;
                    }
                }
            }
        }


        public void GetArmazens()
        {
            OdbcCommand gStck = new OdbcCommand("SELECT DISTINCT armazem FROM t_stock ORDER BY armazem", cnn);
            OdbcDataReader sR;
            cnn.Open();
            sR = gStck.ExecuteReader();
            if (sR.HasRows)
            {
                while (sR.Read())
                {
                    cmbArmazem.Items.Add(sR[0]);
                }
            }
            cnn.Close();
        }

        private void btnCheckStock_MouseEnter(object sender, EventArgs e)
        {
            cmbArmazem.Items.Add("Todos");
            GetArmazens();
        }

        private void cmbArmazem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbArmazem.Text != "Todos")
            {
                sArmazem = "WHERE ARMAZEM='" + cmbArmazem.Text + "'";
            }

            IVO_Stock.ListStock stck = new IVO_Stock.ListStock(cnnSql, sArmazem);
            stck.MdiParent = this;
            stck.Show();
        }

        private void inserirReferênciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IVO_Stock.AddRef ar = new IVO_Stock.AddRef();
            ar.MdiParent = this;
            ar.Show();
        }

        private void btnOpenGE_Click(object sender, EventArgs e)
        {
            Embalagem.GruposEmbalagem ge = new IVO_Suite.Embalagem.GruposEmbalagem(strConnEnc);
            ge.MdiParent = this;
            ge.Show();
        }

        private void btnEncomendas_Click(object sender, EventArgs e)
        {
            Encomendas.Encomendas enc = new IVO_Suite.Encomendas.Encomendas(strConnEnc);
            enc.MdiParent = this;
            enc.Show();
        }

        private void btnEE_Click(object sender, EventArgs e)
        {
            IVO_EE.Form1 ee = new IVO_EE.Form1();
            ee.MdiParent = this;
            ee.Show();
        }

        private void btnTickets_Click(object sender, EventArgs e)
        {
            IVO_HelpDesk.Main hdMain = new IVO_HelpDesk.Main();
            hdMain.MdiParent = this;
            hdMain.Show();
        }

        private void btnNotas_Click(object sender, EventArgs e)
        {
            IVO_HelpDesk.Notas hdNotas = new IVO_HelpDesk.Notas(strConnHD);
            hdNotas.MdiParent = this;
            hdNotas.Show();
        }

        private void btnCodPC_Click(object sender, EventArgs e)
        {
            Primavera.CodPC pc = new IVO_Suite.Primavera.CodPC(strConnPri);
            pc.MdiParent = this;
            pc.Show();
        }

        private void btnPCs_Click(object sender, EventArgs e)
        {
            HelpDesk.ListEquip pc = new IVO_Suite.HelpDesk.ListEquip(strConnHD);
            pc.MdiParent = this;
            pc.Show();
        }

        private void btnRecados_Click(object sender, EventArgs e)
        {
            IVO_Suite.HelpDesk.Recados rec = new IVO_Suite.HelpDesk.Recados(strConnHD);
            rec.MdiParent = this;
            rec.Show();
        }

        private void btnPlanearEmbalamento_Click(object sender, EventArgs e)
        {
            Embalagem.PlanearEmbalamento pe = new IVO_Suite.Embalagem.PlanearEmbalamento(strConnPri, strConnEnc);
            pe.MdiParent = this;
            pe.Show();
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            Embalagem.Historico h = new Embalagem.Historico(strConnEnc, "", "");
            h.MdiParent = this;
            h.Show();
        }

        private void btnCores_Click(object sender, EventArgs e)
        {
            Primavera.MarcasCores mc = new Primavera.MarcasCores("_IVO_Cores", strConnPri);
            mc.MdiParent = this;
            mc.Show();
        }

        private void btnMarcas_Click(object sender, EventArgs e)
        {
            Primavera.MarcasCores mc = new Primavera.MarcasCores("_IVO_Marcas", strConnPri);
            mc.MdiParent = this;
            mc.Show();
        }

        private void btnPackingLists_Click(object sender, EventArgs e)
        {
            Encomendas.PackingLists pl = new Encomendas.PackingLists(strConnPri);
            pl.MdiParent = this;
            pl.Show();
        }

        private void tsBtnUpdate_Click(object sender, EventArgs e)
        {
            Primavera.UpdateDescricaoCliente udc = new Primavera.UpdateDescricaoCliente(strConnPri);
            udc.MdiParent = this;
            udc.Show();
        }

        private void tsBtnRefCli_Click(object sender, EventArgs e)
        {
            Primavera.RefCli rc = new Primavera.RefCli(strConnPri);
            rc.MdiParent = this;
            rc.Show();
        }

        private void tsBtnStaff_Click(object sender, EventArgs e)
        {
            HelpDesk.Staff s = new HelpDesk.Staff(strConnHD);
            s.MdiParent = this;
            s.Show();
        }

        private void btnNecEmb_Click(object sender, EventArgs e)
        {
            Embalagem.Necessidades n = new Embalagem.Necessidades(strConnEnc, "");
            n.MdiParent = this;
            n.Show();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPesquisaGrupo_Click(object sender, EventArgs e)
        {
            Embalagem.PesquisaGrupoEmbalagem pg = new Embalagem.PesquisaGrupoEmbalagem(strConnPri);
            pg.MdiParent = this;
            pg.Show();
        }

        private void btnLembretes_Click(object sender, EventArgs e)
        {
            Embalagem.Lembretes l = new Embalagem.Lembretes(strConnPri);
            l.MdiParent = this;
            l.Show();
        }

        private void necessidades2011ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Embalagem.Necessidades2011 nec2 = new Embalagem.Necessidades2011(strConnPri, "");
            nec2.MdiParent = this;
            nec2.Show();
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void historico2011_Click(object sender, EventArgs e)
        {
            Embalagem.Historico2011 h2011 = new Embalagem.Historico2011(strConnEnc, "", "");
            h2011.MdiParent = this;
            h2011.Show();
        }

        private void imprimirEmbalagemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Embalagem.PrintEmbal PE = new Embalagem.PrintEmbal();
            PE.MdiParent = this;
            PE.Show();
        }

        private void pesquisaArtigosEmGrupoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Embalagem.PesquisaGrupo pg = new Embalagem.PesquisaGrupo(strConnPri);
            pg.MdiParent = this;
            pg.Show();
        }

        private void gruposComArtigosAZeroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Embalagem.ArtigosZero az = new Embalagem.ArtigosZero(strConnPri);
            az.MdiParent = this;
            az.Show();
        }

        private void pesquisaFacasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Embalagem.PesquisaFacas pf = new Embalagem.PesquisaFacas(strConnPri);
            pf.MdiParent = this;
            pf.Show();
        }
    }
}
