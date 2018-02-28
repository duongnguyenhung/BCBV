using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraTab;
using DevExpress.XtraSplashScreen;
using Oracle.DataAccess.Client;
using System.Configuration;

namespace HISSMS
{
    public partial class FormHISSMS : RibbonForm
    {
        static public string[] arrayThamSo = null;
        static public OracleConnection conn = null;
        static public string conn_string = null;

        public FormHISSMS()
        {
            InitializeComponent();
            arrayThamSo = new string[13];
            ConnectionStringSettingsCollection settings =
                ConfigurationManager.ConnectionStrings;
            if (settings != null)
            {
                foreach (ConnectionStringSettings cs in settings)
                {
                    if (cs.Name == "HIS")
                    {
                        conn_string = cs.ConnectionString;
                        conn = DBUtils.GetDBConnection(conn_string);
                        conn.Open();
                        //loadThamSo();
                    }
                }  
            }
        }

        private void loadThamSo()
        {
            string sql = "select * from sms_thamso";
            try
            {
                OracleCommand cmd = new OracleCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                DataTable dt = new DataTable();
                OracleDataAdapter da = new OracleDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    arrayThamSo[int.Parse(dt.Rows[0]["ID"].ToString())-1] = dt.Rows[0]["GIATRI"].ToString();
                    arrayThamSo[int.Parse(dt.Rows[1]["ID"].ToString())-1] = dt.Rows[1]["GIATRI"].ToString();
                    arrayThamSo[int.Parse(dt.Rows[2]["ID"].ToString())-1] = dt.Rows[2]["GIATRI"].ToString();
                    arrayThamSo[int.Parse(dt.Rows[3]["ID"].ToString())-1] = dt.Rows[3]["GIATRI"].ToString();
                    arrayThamSo[int.Parse(dt.Rows[4]["ID"].ToString())-1] = dt.Rows[4]["GIATRI"].ToString();
                    arrayThamSo[int.Parse(dt.Rows[5]["ID"].ToString())-1] = dt.Rows[5]["GIATRI"].ToString();
                    arrayThamSo[int.Parse(dt.Rows[6]["ID"].ToString())-1] = dt.Rows[6]["GIATRI"].ToString();
                    arrayThamSo[int.Parse(dt.Rows[7]["ID"].ToString())-1] = dt.Rows[7]["GIATRI"].ToString();
                    arrayThamSo[int.Parse(dt.Rows[8]["ID"].ToString())-1] = dt.Rows[8]["GIATRI"].ToString();
                    arrayThamSo[int.Parse(dt.Rows[9]["ID"].ToString())-1] = dt.Rows[9]["GIATRI"].ToString();
                    arrayThamSo[int.Parse(dt.Rows[10]["ID"].ToString())-1] = dt.Rows[10]["GIATRI"].ToString();
                    arrayThamSo[int.Parse(dt.Rows[11]["ID"].ToString())-1] = dt.Rows[11]["GIATRI"].ToString();
                    arrayThamSo[int.Parse(dt.Rows[12]["ID"].ToString())-1] = dt.Rows[12]["GIATRI"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDSBN_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(this.ParentForm, typeof(WaitForm), true, true, false);
            try
            {
                int pagecount = xtraTabControlMain.TabPages.Count;
                Boolean found = false;
                for (int i = 0; i < pagecount; i++)
                {
                    if (xtraTabControlMain.TabPages[i].Name == "xtraTabPageSMS")
                    {
                        found = true;
                        xtraTabControlMain.SelectedTabPage = xtraTabControlMain.TabPages[i];
                    }
                }
                if (!found)
                {
                    XtraTabPage xtraTabPageSMS = new DevExpress.XtraTab.XtraTabPage();
                    xtraTabPageSMS.Name = "xtraTabPageSMS";
                    xtraTabPageSMS.ShowCloseButton = DevExpress.Utils.DefaultBoolean.True;
                    xtraTabPageSMS.Text = "Danh sách hẹn tái khám";
                    XtraUserControlSMS userControlSMS = new XtraUserControlSMS();
                    userControlSMS.Dock = DockStyle.Fill;
                    xtraTabPageSMS.Controls.Add(userControlSMS);
                    xtraTabControlMain.TabPages.Add(xtraTabPageSMS);
                    xtraTabControlMain.SelectedTabPage = xtraTabPageSMS;
                }
            }
            finally
            {
                SplashScreenManager.CloseForm(false);
            }
        }

        private void iExit_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private void xtraTabControlMain_CloseButtonClick(object sender, EventArgs e)
        {
            xtraTabControlMain.TabPages.Remove(((XtraTabControl)sender).SelectedTabPage);
        }

        private void btnThamSo_ItemClick(object sender, ItemClickEventArgs e)
        {
            int pagecount = xtraTabControlMain.TabPages.Count;
            Boolean found = false;
            for (int i = 0; i < pagecount; i++)
            {
                if (xtraTabControlMain.TabPages[i].Name == "xtraTabPageThamSo")
                {
                    found = true;
                    xtraTabControlMain.SelectedTabPage = xtraTabControlMain.TabPages[i];
                }
            }
            if (!found)
            {
                XtraTabPage xtraTabPageThamSo = new DevExpress.XtraTab.XtraTabPage();
                xtraTabPageThamSo.Name = "xtraTabPageThamSo";
                xtraTabPageThamSo.ShowCloseButton = DevExpress.Utils.DefaultBoolean.True;
                xtraTabPageThamSo.Text = "Tham số";
                XtraUserControlThamSo userControlThamSo = new XtraUserControlThamSo();
                userControlThamSo.Dock = DockStyle.Fill;
                xtraTabPageThamSo.Controls.Add(userControlThamSo);
                xtraTabControlMain.TabPages.Add(xtraTabPageThamSo);
                xtraTabControlMain.SelectedTabPage = xtraTabPageThamSo;
            }
        }

        private void barButtonItemMau20_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(this.ParentForm, typeof(WaitForm), true, true, false);
            try
            {
                int pagecount = xtraTabControlMain.TabPages.Count;
                Boolean found = false;
                for (int i = 0; i < pagecount; i++)
                {
                    if (xtraTabControlMain.TabPages[i].Name == "xtraTabPageMau20")
                    {
                        found = true;
                        xtraTabControlMain.SelectedTabPage = xtraTabControlMain.TabPages[i];
                    }
                }
                if (!found)
                {
                    XtraTabPage xtraTabPageMau20 = new DevExpress.XtraTab.XtraTabPage();
                    xtraTabPageMau20.Name = "xtraTabPageMau20";
                    xtraTabPageMau20.ShowCloseButton = DevExpress.Utils.DefaultBoolean.True;
                    xtraTabPageMau20.Text = "Báo cáo mẫu 20";
                    XtraUserControlMau20 userControlMau20 = new XtraUserControlMau20();
                    userControlMau20.Dock = DockStyle.Fill;
                    xtraTabPageMau20.Controls.Add(userControlMau20);
                    xtraTabControlMain.TabPages.Add(xtraTabPageMau20);
                    xtraTabControlMain.SelectedTabPage = xtraTabPageMau20;
                }
            }
            finally
            {
                SplashScreenManager.CloseForm(false);
            }
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(this.ParentForm, typeof(WaitForm), true, true, false);
            try
            {
                int pagecount = xtraTabControlMain.TabPages.Count;
                Boolean found = false;
                for (int i = 0; i < pagecount; i++)
                {
                    if (xtraTabControlMain.TabPages[i].Name == "xtraTabPageMau21")
                    {
                        found = true;
                        xtraTabControlMain.SelectedTabPage = xtraTabControlMain.TabPages[i];
                    }
                }
                if (!found)
                {
                    XtraTabPage xtraTabPageMau21 = new DevExpress.XtraTab.XtraTabPage();
                    xtraTabPageMau21.Name = "xtraTabPageBaoCao";
                    xtraTabPageMau21.ShowCloseButton = DevExpress.Utils.DefaultBoolean.True;
                    xtraTabPageMau21.Text = "Báo cáo mẫu 21";
                    
                    XtraUserControlMau21 userControlMau21 = new XtraUserControlMau21();
                    userControlMau21.Dock = DockStyle.Fill;
                    xtraTabPageMau21.Controls.Add(userControlMau21);
                    xtraTabControlMain.TabPages.Add(xtraTabPageMau21);
                    xtraTabControlMain.SelectedTabPage = xtraTabPageMau21;
                }
            }
            finally
            {
                SplashScreenManager.CloseForm(false);
            }
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(this.ParentForm, typeof(WaitForm), true, true, false);
            try
            {
                int pagecount = xtraTabControlMain.TabPages.Count;
                Boolean found = false;
                for (int i = 0; i < pagecount; i++)
                {
                    if (xtraTabControlMain.TabPages[i].Name == "xtraTabPageMau19")
                    {
                        found = true;
                        xtraTabControlMain.SelectedTabPage = xtraTabControlMain.TabPages[i];
                    }
                }
                if (!found)
                {
                    XtraTabPage xtraTabPageMau19 = new DevExpress.XtraTab.XtraTabPage();
                    xtraTabPageMau19.Name = "xtraTabPageMau19";
                    xtraTabPageMau19.ShowCloseButton = DevExpress.Utils.DefaultBoolean.True;
                    xtraTabPageMau19.Text = "Báo cáo mẫu 19";
                    XtraUserControlMau19 userControlMau19 = new XtraUserControlMau19();
                    userControlMau19.Dock = DockStyle.Fill;
                    xtraTabPageMau19.Controls.Add(userControlMau19);
                    xtraTabControlMain.TabPages.Add(xtraTabPageMau19);
                    xtraTabControlMain.SelectedTabPage = xtraTabPageMau19;
                }
            }
            finally
            {
                SplashScreenManager.CloseForm(false);
            }
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(this.ParentForm, typeof(WaitForm), true, true, false);
            try
            {
                int pagecount = xtraTabControlMain.TabPages.Count;
                Boolean found = false;
                for (int i = 0; i < pagecount; i++)
                {
                    if (xtraTabControlMain.TabPages[i].Name == "xtraTabPageBaoCao")
                    {
                        found = true;
                        xtraTabControlMain.SelectedTabPage = xtraTabControlMain.TabPages[i];
                    }
                }
                if (!found)
                {
                    XtraTabPage xtraTabPageBaoCao1 = new DevExpress.XtraTab.XtraTabPage();
                    xtraTabPageBaoCao1.Name = "xtraTabPageBaoCao";
                    xtraTabPageBaoCao1.ShowCloseButton = DevExpress.Utils.DefaultBoolean.True;
                    xtraTabPageBaoCao1.Text = "Báo cáo mẫu 79 80";

                    XtraUserControlMau7980 userControlBaoCao = new XtraUserControlMau7980();
                    userControlBaoCao.Dock = DockStyle.Fill;
                    xtraTabPageBaoCao1.Controls.Add(userControlBaoCao);
                    xtraTabControlMain.TabPages.Add(xtraTabPageBaoCao1);
                    xtraTabControlMain.SelectedTabPage = xtraTabPageBaoCao1;
                }
            }
            finally
            {
                SplashScreenManager.CloseForm(false);
            }
        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(this.ParentForm, typeof(WaitForm), true, true, false);
            try
            {
                int pagecount = xtraTabControlMain.TabPages.Count;
                Boolean found = false;
                for (int i = 0; i < pagecount; i++)
                {
                    if (xtraTabControlMain.TabPages[i].Name == "xtraTabPageMauTK37")
                    {
                        found = true;
                        xtraTabControlMain.SelectedTabPage = xtraTabControlMain.TabPages[i];
                    }
                }
                if (!found)
                {
                    XtraTabPage xtraTabPageMauTK37 = new DevExpress.XtraTab.XtraTabPage();
                    xtraTabPageMauTK37.Name = "xtraTabPageMauTK37";
                    xtraTabPageMauTK37.ShowCloseButton = DevExpress.Utils.DefaultBoolean.True;
                    xtraTabPageMauTK37.Text = "Báo cáo mẫu thống kê 37";

                    XtraUserControlMauTK37 userControlMauTK37 = new XtraUserControlMauTK37();
                    userControlMauTK37.Dock = DockStyle.Fill;
                    xtraTabPageMauTK37.Controls.Add(userControlMauTK37);
                    xtraTabControlMain.TabPages.Add(xtraTabPageMauTK37);
                    xtraTabControlMain.SelectedTabPage = xtraTabPageMauTK37;
                }
            }
            finally
            {
                SplashScreenManager.CloseForm(false);
            }
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            int pagecount = xtraTabControlMain.TabPages.Count;
            Boolean found = false;
            for (int i = 0; i < pagecount; i++)
            {
                if (xtraTabControlMain.TabPages[i].Name == "xtraTabPageMauCPKP")
                {
                    found = true;
                    xtraTabControlMain.SelectedTabPage = xtraTabControlMain.TabPages[i];
                }
            }
            if (!found)
            {
                XtraTabPage xtraTabPageMauCPKP = new DevExpress.XtraTab.XtraTabPage();
                xtraTabPageMauCPKP.Name = "xtraTabPageMauCPKP";
                xtraTabPageMauCPKP.ShowCloseButton = DevExpress.Utils.DefaultBoolean.True;
                xtraTabPageMauCPKP.Text = "Mẫu CPKP";
                XtraUserControlMauCPKP userControlMauCPKP = new XtraUserControlMauCPKP();
                userControlMauCPKP.Dock = DockStyle.Fill;
                xtraTabPageMauCPKP.Controls.Add(userControlMauCPKP);
                xtraTabControlMain.TabPages.Add(xtraTabPageMauCPKP);
                xtraTabControlMain.SelectedTabPage = xtraTabPageMauCPKP;
            }
        }

        private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(this.ParentForm, typeof(WaitForm), true, true, false);
            try
            {
                int pagecount = xtraTabControlMain.TabPages.Count;
                Boolean found = false;
                for (int i = 0; i < pagecount; i++)
                {
                    if (xtraTabControlMain.TabPages[i].Name == "xtraTabPageBaoCao")
                    {
                        found = true;
                        xtraTabControlMain.SelectedTabPage = xtraTabControlMain.TabPages[i];
                    }
                }
                if (!found)
                {
                    XtraTabPage xtraTabPageBaoCao1 = new DevExpress.XtraTab.XtraTabPage();
                    xtraTabPageBaoCao1.Name = "xtraTabPageBaoCao";
                    xtraTabPageBaoCao1.ShowCloseButton = DevExpress.Utils.DefaultBoolean.True;
                    xtraTabPageBaoCao1.Text = "Báo cáo phân tích chi phí theo tuyến";

                    XtraUserControlMau2526TT userControlBaoCao = new XtraUserControlMau2526TT();
                    userControlBaoCao.Dock = DockStyle.Fill;
                    xtraTabPageBaoCao1.Controls.Add(userControlBaoCao);
                    xtraTabControlMain.TabPages.Add(xtraTabPageBaoCao1);
                    xtraTabControlMain.SelectedTabPage = xtraTabPageBaoCao1;
                }
            }
            finally
            {
                SplashScreenManager.CloseForm(false);
            }
        }

        private void barButtonItem8_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(this.ParentForm, typeof(WaitForm), true, true, false);
            try
            {
                int pagecount = xtraTabControlMain.TabPages.Count;
                Boolean found = false;
                for (int i = 0; i < pagecount; i++)
                {
                    if (xtraTabControlMain.TabPages[i].Name == "xtraTabPageBaoCao")
                    {
                        found = true;
                        xtraTabControlMain.SelectedTabPage = xtraTabControlMain.TabPages[i];
                    }
                }
                if (!found)
                {
                    XtraTabPage xtraTabPageBaoCao1 = new DevExpress.XtraTab.XtraTabPage();
                    xtraTabPageBaoCao1.Name = "xtraTabPageBaoCao";
                    xtraTabPageBaoCao1.ShowCloseButton = DevExpress.Utils.DefaultBoolean.True;
                    xtraTabPageBaoCao1.Text = "Báo cáo phân tích chi phí theo nhóm";

                    XtraUserControlMau2526TN userControlBaoCao = new XtraUserControlMau2526TN();
                    userControlBaoCao.Dock = DockStyle.Fill;
                    xtraTabPageBaoCao1.Controls.Add(userControlBaoCao);
                    xtraTabControlMain.TabPages.Add(xtraTabPageBaoCao1);
                    xtraTabControlMain.SelectedTabPage = xtraTabPageBaoCao1;
                }
            }
            finally
            {
                SplashScreenManager.CloseForm(false);
            }
        }

        private void barButtonItem9_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(this.ParentForm, typeof(WaitForm), true, true, false);
            try
            {
                int pagecount = xtraTabControlMain.TabPages.Count;
                Boolean found = false;
                for (int i = 0; i < pagecount; i++)
                {
                    if (xtraTabControlMain.TabPages[i].Name == "xtraTabPageMauTK373N")
                    {
                        found = true;
                        xtraTabControlMain.SelectedTabPage = xtraTabControlMain.TabPages[i];
                    }
                }
                if (!found)
                {
                    XtraTabPage xtraTabPageMauTK373N = new DevExpress.XtraTab.XtraTabPage();
                    xtraTabPageMauTK373N.Name = "xtraTabPageBaoCao";
                    xtraTabPageMauTK373N.ShowCloseButton = DevExpress.Utils.DefaultBoolean.True;
                    xtraTabPageMauTK373N.Text = "Báo cáo mẫu thống kê 37 3 nhóm";

                    XtraUserControlMauTK373N userControlMauTK373N = new XtraUserControlMauTK373N();
                    userControlMauTK373N.Dock = DockStyle.Fill;
                    xtraTabPageMauTK373N.Controls.Add(userControlMauTK373N);
                    xtraTabControlMain.TabPages.Add(xtraTabPageMauTK373N);
                    xtraTabControlMain.SelectedTabPage = xtraTabPageMauTK373N;
                }
            }
            finally
            {
                SplashScreenManager.CloseForm(false);
            }
        }

        private void barButtonItem10_ItemClick(object sender, ItemClickEventArgs e)
        {
            int pagecount = xtraTabControlMain.TabPages.Count;
            Boolean found = false;
            for (int i = 0; i < pagecount; i++)
            {
                if (xtraTabControlMain.TabPages[i].Name == "xtraTabPageSoKhamBenh")
                {
                    found = true;
                    xtraTabControlMain.SelectedTabPage = xtraTabControlMain.TabPages[i];
                }
            }
            if (!found)
            {
                XtraTabPage xtraTabPageSoKhamBenh = new DevExpress.XtraTab.XtraTabPage();
                xtraTabPageSoKhamBenh.Name = "xtraTabPageSoKhamBenh";
                xtraTabPageSoKhamBenh.ShowCloseButton = DevExpress.Utils.DefaultBoolean.True;
                xtraTabPageSoKhamBenh.Text = "Sổ Khám Bệnh";
                XtraUserControlSoKhamBenh userControlSoKhamBenh = new XtraUserControlSoKhamBenh();
                userControlSoKhamBenh.Dock = DockStyle.Fill;
                xtraTabPageSoKhamBenh.Controls.Add(userControlSoKhamBenh);
                xtraTabControlMain.TabPages.Add(xtraTabPageSoKhamBenh);
                xtraTabControlMain.SelectedTabPage = xtraTabPageSoKhamBenh;
            }
        }

        private void barButtonItem12_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(this.ParentForm, typeof(WaitForm), true, true, false);
            try
            {
                int pagecount = xtraTabControlMain.TabPages.Count;
                Boolean found = false;
                for (int i = 0; i < pagecount; i++)
                {
                    if (xtraTabControlMain.TabPages[i].Name == "xtraTabPageMau21KPN")
                    {
                        found = true;
                        xtraTabControlMain.SelectedTabPage = xtraTabControlMain.TabPages[i];
                    }
                }
                if (!found)
                {
                    XtraTabPage xtraTabPageMau21KPN = new DevExpress.XtraTab.XtraTabPage();
                    xtraTabPageMau21KPN.Name = "xtraTabPageBaoCao";
                    xtraTabPageMau21KPN.ShowCloseButton = DevExpress.Utils.DefaultBoolean.True;
                    xtraTabPageMau21KPN.Text = "Mẫu 21 không phân nhóm";

                    XtraUserControlMau21KPN userControlMau21KPN = new XtraUserControlMau21KPN();
                    userControlMau21KPN.Dock = DockStyle.Fill;
                    xtraTabPageMau21KPN.Controls.Add(userControlMau21KPN);
                    xtraTabControlMain.TabPages.Add(xtraTabPageMau21KPN);
                    xtraTabControlMain.SelectedTabPage = xtraTabPageMau21KPN;
                }
            }
            finally
            {
                SplashScreenManager.CloseForm(false);
            }
            
        }

        private void barButtonItem11_ItemClick(object sender, ItemClickEventArgs e)
        {
            int pagecount = xtraTabControlMain.TabPages.Count;
            Boolean found = false;
            for (int i = 0; i < pagecount; i++)
            {
                if (xtraTabControlMain.TabPages[i].Name == "xtraTabPageMauCPKPNG")
                {
                    found = true;
                    xtraTabControlMain.SelectedTabPage = xtraTabControlMain.TabPages[i];
                }
            }
            if (!found)
            {
                XtraTabPage xtraTabPageMauCPKPNG = new DevExpress.XtraTab.XtraTabPage();
                xtraTabPageMauCPKPNG.Name = "xtraTabPageMauCPKPNG";
                xtraTabPageMauCPKPNG.ShowCloseButton = DevExpress.Utils.DefaultBoolean.True;
                xtraTabPageMauCPKPNG.Text = "Mẫu CPKP Ngoại";
                XtraUserControlMauCPKPNG userControlMauCPKPNG = new XtraUserControlMauCPKPNG();
                userControlMauCPKPNG.Dock = DockStyle.Fill;
                xtraTabPageMauCPKPNG.Controls.Add(userControlMauCPKPNG);
                xtraTabControlMain.TabPages.Add(xtraTabPageMauCPKPNG);
                xtraTabControlMain.SelectedTabPage = xtraTabPageMauCPKPNG;
            }

        }

        private void barButtonItem13_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(this.ParentForm, typeof(WaitForm), true, true, false);
            try
            {
                int pagecount = xtraTabControlMain.TabPages.Count;
                Boolean found = false;
                for (int i = 0; i < pagecount; i++)
                {
                    if (xtraTabControlMain.TabPages[i].Name == "xtraTabPageBNTTU")
                    {
                        found = true;
                        xtraTabControlMain.SelectedTabPage = xtraTabControlMain.TabPages[i];
                    }
                }
                if (!found)
                {
                    XtraTabPage xtraTabPageBNTTU = new DevExpress.XtraTab.XtraTabPage();
                    xtraTabPageBNTTU.Name = "xtraTabPageBNTTU";
                    xtraTabPageBNTTU.ShowCloseButton = DevExpress.Utils.DefaultBoolean.True;
                    xtraTabPageBNTTU.Text = "Báo cáo bệnh nhận tồn tạm ứng";

                    XtraUserControlBNTTU userControlBNTTU = new XtraUserControlBNTTU();
                    userControlBNTTU.Dock = DockStyle.Fill;
                    xtraTabPageBNTTU.Controls.Add(userControlBNTTU);
                    xtraTabControlMain.TabPages.Add(xtraTabPageBNTTU);
                    xtraTabControlMain.SelectedTabPage = xtraTabPageBNTTU;
                }
            }
            finally
            {
                SplashScreenManager.CloseForm(false);
            }
        }

        private void barButtonItem14_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(this.ParentForm, typeof(WaitForm), true, true, false);
            try
            {
                int pagecount = xtraTabControlMain.TabPages.Count;
                Boolean found = false;
                for (int i = 0; i < pagecount; i++)
                {
                    if (xtraTabControlMain.TabPages[i].Name == "xtraTabPageMau7980new")
                    {
                        found = true;
                        xtraTabControlMain.SelectedTabPage = xtraTabControlMain.TabPages[i];
                    }
                }
                if (!found)
                {
                    XtraTabPage xtraTabPageMau7980new = new DevExpress.XtraTab.XtraTabPage();
                    xtraTabPageMau7980new.Name = "xtraTabPageBaoCao";
                    xtraTabPageMau7980new.ShowCloseButton = DevExpress.Utils.DefaultBoolean.True;
                    xtraTabPageMau7980new.Text = "Mẫu 79,80";

                    XtraUserControlMau7980new userControlMau7980new = new XtraUserControlMau7980new();
                    userControlMau7980new.Dock = DockStyle.Fill;
                    xtraTabPageMau7980new.Controls.Add(userControlMau7980new);
                    xtraTabControlMain.TabPages.Add(xtraTabPageMau7980new);
                    xtraTabControlMain.SelectedTabPage = xtraTabPageMau7980new;
                }
            }
            finally
            {
                SplashScreenManager.CloseForm(false);
            }
        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            int pagecount = xtraTabControlMain.TabPages.Count;
            Boolean found = false;
            for (int i = 0; i < pagecount; i++)
            {
                if (xtraTabControlMain.TabPages[i].Name == "xtraTabPageSoPTTT")
                {
                    found = true;
                    xtraTabControlMain.SelectedTabPage = xtraTabControlMain.TabPages[i];
                }
            }
            if (!found)
            {
                XtraTabPage xtraTabPageSoPTTT = new DevExpress.XtraTab.XtraTabPage();
                xtraTabPageSoPTTT.Name = "xtraTabPageSoPTTT";
                xtraTabPageSoPTTT.ShowCloseButton = DevExpress.Utils.DefaultBoolean.True;
                xtraTabPageSoPTTT.Text = "Sổ PT-TT";
                XtraUserControlSoPTTT userControlSoPTTT = new XtraUserControlSoPTTT();
                userControlSoPTTT.Dock = DockStyle.Fill;
                xtraTabPageSoPTTT.Controls.Add(userControlSoPTTT);
                xtraTabControlMain.TabPages.Add(xtraTabPageSoPTTT);
                xtraTabControlMain.SelectedTabPage = xtraTabPageSoPTTT;
            }
        }

        private void barButtonItem15_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(this.ParentForm, typeof(WaitForm), true, true, false);
            try
            {
                int pagecount = xtraTabControlMain.TabPages.Count;
                Boolean found = false;
                for (int i = 0; i < pagecount; i++)
                {
                    if (xtraTabControlMain.TabPages[i].Name == "xtraTabPageMau2526TTN")
                    {
                        found = true;
                        xtraTabControlMain.SelectedTabPage = xtraTabControlMain.TabPages[i];
                    }
                }
                if (!found)
                {
                    XtraTabPage xtraTabPageMau2526TTN = new DevExpress.XtraTab.XtraTabPage();
                    xtraTabPageMau2526TTN.Name = "xtraTabPageMau2526TTN";
                    xtraTabPageMau2526TTN.ShowCloseButton = DevExpress.Utils.DefaultBoolean.True;
                    xtraTabPageMau2526TTN.Text = "Báo cáo phân tích chi phí theo tuyến";

                    Mau2526TTN userControlMau2526TTN = new Mau2526TTN();
                    userControlMau2526TTN.Dock = DockStyle.Fill;
                    xtraTabPageMau2526TTN.Controls.Add(userControlMau2526TTN);
                    xtraTabControlMain.TabPages.Add(xtraTabPageMau2526TTN);
                    xtraTabControlMain.SelectedTabPage = xtraTabPageMau2526TTN;
                }
            }
            finally
            {
                SplashScreenManager.CloseForm(false);
            }
        }

        private void barButtonItem16_ItemClick(object sender, ItemClickEventArgs e)
        {
            int pagecount = xtraTabControlMain.TabPages.Count;
            Boolean found = false;
            for (int i = 0; i < pagecount; i++)
            {
                if (xtraTabControlMain.TabPages[i].Name == "xtraTabPageMau2526TNN")
                {
                    found = true;
                    xtraTabControlMain.SelectedTabPage = xtraTabControlMain.TabPages[i];
                }
            }
            if (!found)
            {
                XtraTabPage xtraTabPageMau2526TNN = new DevExpress.XtraTab.XtraTabPage();
                xtraTabPageMau2526TNN.Name = "xtraTabPageMau2526TNN";
                xtraTabPageMau2526TNN.ShowCloseButton = DevExpress.Utils.DefaultBoolean.True;
                xtraTabPageMau2526TNN.Text = "Sổ 25 26 Theo Nhóm";
                Mau2526TNN userControlMau2526TNN = new Mau2526TNN();
                userControlMau2526TNN.Dock = DockStyle.Fill;
                xtraTabPageMau2526TNN.Controls.Add(userControlMau2526TNN);
                xtraTabControlMain.TabPages.Add(xtraTabPageMau2526TNN);
                xtraTabControlMain.SelectedTabPage = xtraTabPageMau2526TNN;
            }
        }

        private void barButtonItem17_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(this.ParentForm, typeof(WaitForm), true, true, false);
            try
            {
                int pagecount = xtraTabControlMain.TabPages.Count;
                Boolean found = false;
                for (int i = 0; i < pagecount; i++)
                {
                    if (xtraTabControlMain.TabPages[i].Name == "xtraTabPageMau213Nhom")
                    {
                        found = true;
                        xtraTabControlMain.SelectedTabPage = xtraTabControlMain.TabPages[i];
                    }
                }
                if (!found)
                {
                    XtraTabPage xtraTabPageMau213Nhom = new DevExpress.XtraTab.XtraTabPage();
                    xtraTabPageMau213Nhom.Name = "xtraTabPageMau213Nhom";
                    xtraTabPageMau213Nhom.ShowCloseButton = DevExpress.Utils.DefaultBoolean.True;
                    xtraTabPageMau213Nhom.Text = "Mẫu 21 theo 3 nhóm";

                    XtraUserControlMau213Nhom userControlMau213Nhom = new XtraUserControlMau213Nhom();
                    userControlMau213Nhom.Dock = DockStyle.Fill;
                    xtraTabPageMau213Nhom.Controls.Add(userControlMau213Nhom);
                    xtraTabControlMain.TabPages.Add(xtraTabPageMau213Nhom);
                    xtraTabControlMain.SelectedTabPage = xtraTabPageMau213Nhom;
                }
            }
            finally
            {
                SplashScreenManager.CloseForm(false);
            }
        }

        private void barButtonItem18_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(this.ParentForm, typeof(WaitForm), true, true, false);
            try
            {
                int pagecount = xtraTabControlMain.TabPages.Count;
                Boolean found = false;
                for (int i = 0; i < pagecount; i++)
                {
                    if (xtraTabControlMain.TabPages[i].Name == "xtraTabPageMauTK373NhomTH")
                    {
                        found = true;
                        xtraTabControlMain.SelectedTabPage = xtraTabControlMain.TabPages[i];
                    }
                }
                if (!found)
                {
                    XtraTabPage xtraTabPageMauTK373NhomTH = new DevExpress.XtraTab.XtraTabPage();
                    xtraTabPageMauTK373NhomTH.Name = "xtraTabPageBaoCao";
                    xtraTabPageMauTK373NhomTH.ShowCloseButton = DevExpress.Utils.DefaultBoolean.True;
                    xtraTabPageMauTK373NhomTH.Text = "Mẫu TK37";

                    XtraUserControlMauTK373NNew userControlMauTK373NhomTH = new XtraUserControlMauTK373NNew();
                    userControlMauTK373NhomTH.Dock = DockStyle.Fill;
                    xtraTabPageMauTK373NhomTH.Controls.Add(userControlMauTK373NhomTH);
                    xtraTabControlMain.TabPages.Add(xtraTabPageMauTK373NhomTH);
                    xtraTabControlMain.SelectedTabPage = xtraTabPageMauTK373NhomTH;
                }
            }
            finally
            {
                SplashScreenManager.CloseForm(false);
            }
        }

        private void barButtonItem24_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(this.ParentForm, typeof(WaitForm), true, true, false);
            try
            {
                int pagecount = xtraTabControlMain.TabPages.Count;
                Boolean found = false;
                for (int i = 0; i < pagecount; i++)
                {
                    if (xtraTabControlMain.TabPages[i].Name == "xtraTabPageMauTK373NhomTH")
                    {
                        found = true;
                        xtraTabControlMain.SelectedTabPage = xtraTabControlMain.TabPages[i];
                    }
                }
                if (!found)
                {
                    XtraTabPage xtraTabPageMauTK373NhomTH = new DevExpress.XtraTab.XtraTabPage();
                    xtraTabPageMauTK373NhomTH.Name = "xtraTabPageBaoCao";
                    xtraTabPageMauTK373NhomTH.ShowCloseButton = DevExpress.Utils.DefaultBoolean.True;
                    xtraTabPageMauTK373NhomTH.Text = "Mẫu TK37 tổng hợp";

                    XtraUserControlMauTK373NhomTH userControlMauTK373NhomTH = new XtraUserControlMauTK373NhomTH();
                    userControlMauTK373NhomTH.Dock = DockStyle.Fill;
                    xtraTabPageMauTK373NhomTH.Controls.Add(userControlMauTK373NhomTH);
                    xtraTabControlMain.TabPages.Add(xtraTabPageMauTK373NhomTH);
                    xtraTabControlMain.SelectedTabPage = xtraTabPageMauTK373NhomTH;
                }
            }
            finally
            {
                SplashScreenManager.CloseForm(false);
            }
        }

        private void barButtonItem25_ItemClick(object sender, ItemClickEventArgs e)
        {
            int pagecount = xtraTabControlMain.TabPages.Count;
            Boolean found = false;
            for (int i = 0; i < pagecount; i++)
            {
                if (xtraTabControlMain.TabPages[i].Name == "xtraTabPageSoNoiSoi")
                {
                    found = true;
                    xtraTabControlMain.SelectedTabPage = xtraTabControlMain.TabPages[i];
                }
            }
            if (!found)
            {
                XtraTabPage xtraTabPageSoNoiSoi = new DevExpress.XtraTab.XtraTabPage();
                xtraTabPageSoNoiSoi.Name = "xtraTabPageSoXetNghiem";
                xtraTabPageSoNoiSoi.ShowCloseButton = DevExpress.Utils.DefaultBoolean.True;
                xtraTabPageSoNoiSoi.Text = "Sổ Nội Soi";
                XtraUserControlSoNoiSoi userControlSoNoiSoi = new XtraUserControlSoNoiSoi();
                userControlSoNoiSoi.Dock = DockStyle.Fill;
                xtraTabPageSoNoiSoi.Controls.Add(userControlSoNoiSoi);
                xtraTabControlMain.TabPages.Add(xtraTabPageSoNoiSoi);
                xtraTabControlMain.SelectedTabPage = xtraTabPageSoNoiSoi;
            }
        }

        private void barButtonItem26_ItemClick(object sender, ItemClickEventArgs e)
        {
            int pagecount = xtraTabControlMain.TabPages.Count;
            Boolean found = false;
            for (int i = 0; i < pagecount; i++)
            {
                if (xtraTabControlMain.TabPages[i].Name == "xtraTabPageSoXQuang")
                {
                    found = true;
                    xtraTabControlMain.SelectedTabPage = xtraTabControlMain.TabPages[i];
                }
            }
            if (!found)
            {
                XtraTabPage xtraTabPageSoXQuang = new DevExpress.XtraTab.XtraTabPage();
                xtraTabPageSoXQuang.Name = "xtraTabPageSoXQuang";
                xtraTabPageSoXQuang.ShowCloseButton = DevExpress.Utils.DefaultBoolean.True;
                xtraTabPageSoXQuang.Text = "Sổ X Quang";
                XtraUserControlSoXQuang userControlSoXQuang = new XtraUserControlSoXQuang();
                userControlSoXQuang.Dock = DockStyle.Fill;
                xtraTabPageSoXQuang.Controls.Add(userControlSoXQuang);
                xtraTabControlMain.TabPages.Add(xtraTabPageSoXQuang);
                xtraTabControlMain.SelectedTabPage = xtraTabPageSoXQuang;
            }
        }

        private void barButtonItem27_ItemClick(object sender, ItemClickEventArgs e)
        {
            int pagecount = xtraTabControlMain.TabPages.Count;
            Boolean found = false;
            for (int i = 0; i < pagecount; i++)
            {
                if (xtraTabControlMain.TabPages[i].Name == "xtraTabPageSoMRI")
                {
                    found = true;
                    xtraTabControlMain.SelectedTabPage = xtraTabControlMain.TabPages[i];
                }
            }
            if (!found)
            {
                XtraTabPage xtraTabPageSoMRI = new DevExpress.XtraTab.XtraTabPage();
                xtraTabPageSoMRI.Name = "xtraTabPageSoXetNghiem";
                xtraTabPageSoMRI.ShowCloseButton = DevExpress.Utils.DefaultBoolean.True;
                xtraTabPageSoMRI.Text = "Sổ MRI";
                XtraUserControlSoMRI userControlSoMRI = new XtraUserControlSoMRI();
                userControlSoMRI.Dock = DockStyle.Fill;
                xtraTabPageSoMRI.Controls.Add(userControlSoMRI);
                xtraTabControlMain.TabPages.Add(xtraTabPageSoMRI);
                xtraTabControlMain.SelectedTabPage = xtraTabPageSoMRI;
            }
        }

        private void barButtonItem28_ItemClick(object sender, ItemClickEventArgs e)
        {
            int pagecount = xtraTabControlMain.TabPages.Count;
            Boolean found = false;
            for (int i = 0; i < pagecount; i++)
            {
                if (xtraTabControlMain.TabPages[i].Name == "xtraTabPageSoXetNghiem")
                {
                    found = true;
                    xtraTabControlMain.SelectedTabPage = xtraTabControlMain.TabPages[i];
                }
            }
            if (!found)
            {
                XtraTabPage xtraTabPageSoXetNghiem = new DevExpress.XtraTab.XtraTabPage();
                xtraTabPageSoXetNghiem.Name = "xtraTabPageSoXetNghiem";
                xtraTabPageSoXetNghiem.ShowCloseButton = DevExpress.Utils.DefaultBoolean.True;
                xtraTabPageSoXetNghiem.Text = "Sổ Xét Nghiệm";
                XtraUserControlSoXetNghiem userControlSoXetNghiem = new XtraUserControlSoXetNghiem();
                userControlSoXetNghiem.Dock = DockStyle.Fill;
                xtraTabPageSoXetNghiem.Controls.Add(userControlSoXetNghiem);
                xtraTabControlMain.TabPages.Add(xtraTabPageSoXetNghiem);
                xtraTabControlMain.SelectedTabPage = xtraTabPageSoXetNghiem;
            }
        }

        private void barButtonItem29_ItemClick(object sender, ItemClickEventArgs e)
        {
            int pagecount = xtraTabControlMain.TabPages.Count;
            Boolean found = false;
            for (int i = 0; i < pagecount; i++)
            {
                if (xtraTabControlMain.TabPages[i].Name == "xtraTabPageSoSieuAm")
                {
                    found = true;
                    xtraTabControlMain.SelectedTabPage = xtraTabControlMain.TabPages[i];
                }
            }
            if (!found)
            {
                XtraTabPage xtraTabPageSoSieuAm = new DevExpress.XtraTab.XtraTabPage();
                xtraTabPageSoSieuAm.Name = "xtraTabPageSoSieuAm";
                xtraTabPageSoSieuAm.ShowCloseButton = DevExpress.Utils.DefaultBoolean.True;
                xtraTabPageSoSieuAm.Text = "Sổ siêu âm";
                XtraUserControlSoSieuAm userControlSoSieuAm = new XtraUserControlSoSieuAm();
                userControlSoSieuAm.Dock = DockStyle.Fill;
                xtraTabPageSoSieuAm.Controls.Add(userControlSoSieuAm);
                xtraTabControlMain.TabPages.Add(xtraTabPageSoSieuAm);
                xtraTabControlMain.SelectedTabPage = xtraTabPageSoSieuAm;
            }
        }

        private void barButtonItem30_ItemClick(object sender, ItemClickEventArgs e)
        {
            //
        }

        private void barButtonItem33_ItemClick(object sender, ItemClickEventArgs e)
        {
            int pagecount = xtraTabControlMain.TabPages.Count;
            Boolean found = false;
            for (int i = 0; i < pagecount; i++)
            {
                if (xtraTabControlMain.TabPages[i].Name == "xtraTabPageSoSieuAm")
                {
                    found = true;
                    xtraTabControlMain.SelectedTabPage = xtraTabControlMain.TabPages[i];
                }
            }
            if (!found)
            {
                XtraTabPage xtraTabPage79804210 = new DevExpress.XtraTab.XtraTabPage();
                xtraTabPage79804210.Name = "xtraTab79804210";
                xtraTabPage79804210.ShowCloseButton = DevExpress.Utils.DefaultBoolean.True;
                xtraTabPage79804210.Text = "79/80 4210";
                XtraUserControlMau79804210 userControl79804210 = new XtraUserControlMau79804210();
                userControl79804210.Dock = DockStyle.Fill;
                xtraTabPage79804210.Controls.Add(userControl79804210);
                xtraTabControlMain.TabPages.Add(xtraTabPage79804210);
                xtraTabControlMain.SelectedTabPage = xtraTabPage79804210;
            }
        }

        private void barButtonItem34_ItemClick(object sender, ItemClickEventArgs e)
        {
            int pagecount = xtraTabControlMain.TabPages.Count;
            Boolean found = false;
            for (int i = 0; i < pagecount; i++)
            {
                if (xtraTabControlMain.TabPages[i].Name == "xtraTabPageCV3360")
                {
                    found = true;
                    xtraTabControlMain.SelectedTabPage = xtraTabControlMain.TabPages[i];
                }
            }
            if (!found)
            {
                XtraTabPage xtraTabPageCV3360 = new DevExpress.XtraTab.XtraTabPage();
                xtraTabPageCV3360.Name = "xtraTabCV3360";
                xtraTabPageCV3360.ShowCloseButton = DevExpress.Utils.DefaultBoolean.True;
                xtraTabPageCV3360.Text = "CV3360";
                XtraUserControlCV3360 userControlCV3360 = new XtraUserControlCV3360();
                userControlCV3360.Dock = DockStyle.Fill;
                xtraTabPageCV3360.Controls.Add(userControlCV3360);
                xtraTabControlMain.TabPages.Add(xtraTabPageCV3360);
                xtraTabControlMain.SelectedTabPage = xtraTabPageCV3360;
            }
        }

        private void barButtonItem35_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(this.ParentForm, typeof(WaitForm), true, true, false);
            try
            {
                int pagecount = xtraTabControlMain.TabPages.Count;
                Boolean found = false;
                for (int i = 0; i < pagecount; i++)
                {
                    if (xtraTabControlMain.TabPages[i].Name == "xtraTabPageMau2526TT4210")
                    {
                        found = true;
                        xtraTabControlMain.SelectedTabPage = xtraTabControlMain.TabPages[i];
                    }
                }
                if (!found)
                {
                    XtraTabPage xtraTabPageMau2526TT4210 = new DevExpress.XtraTab.XtraTabPage();
                    xtraTabPageMau2526TT4210.Name = "xtraTabPageMau2526TT4210";
                    xtraTabPageMau2526TT4210.ShowCloseButton = DevExpress.Utils.DefaultBoolean.True;
                    xtraTabPageMau2526TT4210.Text = "Báo cáo phân tích chi phí theo tuyến";

                    Mau2526TT4210 userControlMau2526TT4210 = new Mau2526TT4210();
                    userControlMau2526TT4210.Dock = DockStyle.Fill;
                    xtraTabPageMau2526TT4210.Controls.Add(userControlMau2526TT4210);
                    xtraTabControlMain.TabPages.Add(xtraTabPageMau2526TT4210);
                    xtraTabControlMain.SelectedTabPage = xtraTabPageMau2526TT4210;
                }
            }
            finally
            {
                SplashScreenManager.CloseForm(false);
            }
        }

        private void barButtonItem36_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(this.ParentForm, typeof(WaitForm), true, true, false);
            try
            {
                int pagecount = xtraTabControlMain.TabPages.Count;
                Boolean found = false;
                for (int i = 0; i < pagecount; i++)
                {
                    if (xtraTabControlMain.TabPages[i].Name == "xtraTabPageMau2526TN4210")
                    {
                        found = true;
                        xtraTabControlMain.SelectedTabPage = xtraTabControlMain.TabPages[i];
                    }
                }
                if (!found)
                {
                    XtraTabPage xtraTabPageMau2526TN4210 = new DevExpress.XtraTab.XtraTabPage();
                    xtraTabPageMau2526TN4210.Name = "xtraTabPageMau2526TT4210";
                    xtraTabPageMau2526TN4210.ShowCloseButton = DevExpress.Utils.DefaultBoolean.True;
                    xtraTabPageMau2526TN4210.Text = "Báo cáo phân tích chi phí theo tuyến";

                    Mau2526TN4210 userControlMau2526TN4210 = new Mau2526TN4210();
                    userControlMau2526TN4210.Dock = DockStyle.Fill;
                    xtraTabPageMau2526TN4210.Controls.Add(userControlMau2526TN4210);
                    xtraTabControlMain.TabPages.Add(xtraTabPageMau2526TN4210);
                    xtraTabControlMain.SelectedTabPage = xtraTabPageMau2526TN4210;
                }
            }
            finally
            {
                SplashScreenManager.CloseForm(false);
            }
        }

        private void FormHISSMS_Load(object sender, EventArgs e)
        {
            //this.Close();
        }

        private void barButtonItem37_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(this.ParentForm, typeof(WaitForm), true, true, false);
            try
            {
                int pagecount = xtraTabControlMain.TabPages.Count;
                Boolean found = false;
                for (int i = 0; i < pagecount; i++)
                {
                    if (xtraTabControlMain.TabPages[i].Name == "xtraTabPageTTHUYQT")
                    {
                        found = true;
                        xtraTabControlMain.SelectedTabPage = xtraTabControlMain.TabPages[i];
                    }
                }
                if (!found)
                {
                    XtraTabPage xtraTabPageTTHuyQT = new DevExpress.XtraTab.XtraTabPage();
                    xtraTabPageTTHuyQT.Name = "xtraTabPageTTHUYQT";
                    xtraTabPageTTHuyQT.ShowCloseButton = DevExpress.Utils.DefaultBoolean.True;
                    xtraTabPageTTHuyQT.Text = "Kiểm tra tình trạng hủy quyết toán";

                    XtraUserControlTTHUYQT userControlTTHuyQT = new XtraUserControlTTHUYQT();
                    userControlTTHuyQT.Dock = DockStyle.Fill;
                    xtraTabPageTTHuyQT.Controls.Add(userControlTTHuyQT);
                    xtraTabControlMain.TabPages.Add(xtraTabPageTTHuyQT);
                    xtraTabControlMain.SelectedTabPage = xtraTabPageTTHuyQT;
                }
            }
            finally
            {
                SplashScreenManager.CloseForm(false);
            }
        }
    }
}