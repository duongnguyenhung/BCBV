using System;
using DevExpress.XtraSplashScreen;
using Stimulsoft.Report;
using System.Globalization;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using Stimulsoft.Report.Dictionary;
using System.Data;
using Oracle.DataAccess.Client;
using Excel = Microsoft.Office.Interop.Excel;

namespace HISSMS
{
    public partial class XtraUserControlTTHUYQT : DevExpress.XtraEditors.XtraUserControl
    {
        public XtraUserControlTTHUYQT()
        {
            InitializeComponent();
        }
        public string thangqt;
        public string namqt;
        public string maloaikcb;
        public int slbncv3360;
        public DataTable Table_7980 = new DataTable();
        public DataTable table_Cv3360 = new DataTable();
        public DataTable Table_tthuyqt = new DataTable();
        public DataTable Table_kqtthuyqt = new DataTable();
        public string so_lieu_7980;
        void khoi_tao_du_lieu()
        {
            DataTable so_lieu = new DataTable();
            so_lieu.Columns.Add("solieu", typeof(int));
            so_lieu.Columns.Add("A2");
            so_lieu.Rows.Add(1, "Nội trú");
            so_lieu.Rows.Add(2, "Ngoại trú");
            so_lieu.Rows.Add(3, "Tất cả");
        }


        private string dateToSchemaMonth(string tungay, string denngay)
        {
            DateTime oTungay = DateTime.ParseExact(tungay, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime oDenngay = DateTime.ParseExact(denngay, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            int period = -MonthDiff(oTungay, oDenngay);
            string result = oTungay.ToString("MMyy");
            DateTime tmp = oTungay;
            for (int i = 0; i < period; i++)
            {
                tmp = tmp.AddMonths(1);
                result = result + "," + tmp.ToString("MMyy");
            }
            return result;
            ;
        }

        private string datauser(string tungay, string denngay)
        {
            string oTungay = DateTime.ParseExact(tungay, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd/MM/yyyy");
            string oDenngay = DateTime.ParseExact(denngay, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd/MM/yyyy");
            OracleConnection conn = Database.GetDBConnection();
            string thang_nam = "select mmyy from hsoft.tables";
            OracleCommand cmd_thang_nam = new OracleCommand(thang_nam, conn);
            string result = "";
            try
            {
                conn.Open();
                cmd_thang_nam.CommandType = CommandType.Text;
                DataSet ds_thang_nam = new DataSet();
                OracleDataAdapter da_thang_nam = new OracleDataAdapter();
                da_thang_nam.SelectCommand = cmd_thang_nam;
                da_thang_nam.Fill(ds_thang_nam, "thang_nam");
                int row = ds_thang_nam.Tables["thang_nam"].Rows.Count - 1;
                for (int a = 0; a <= row; a++)
                {
                    string mmyy = Convert.ToString(ds_thang_nam.Tables["thang_nam"].Rows[a].ItemArray[0]);
                    string select_user = "SELECT a.id FROM hsoft" + mmyy + ".v_m38ll a"
                 + " where to_date(to_char(a.ngayqt,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + oTungay + "','dd/mm/yyyy') and to_date('" + oDenngay + "','dd/mm/yyyy') and a.useridduyet IS NOT NULL";
                    string query = select_user;
                    //MessageBox.Show(query);
                    OracleCommand cmd = new OracleCommand(query, conn);
                    try
                    {

                        //conn.Open();
                        cmd.CommandType = CommandType.Text;
                        DataSet ds = new DataSet();
                        OracleDataAdapter da = new OracleDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(ds, "data");
                        int row1 = ds.Tables["data"].Rows.Count;
                        if (row1 > 0)
                        {
                            if (result == "")
                            {
                                result = result + mmyy;
                            }
                            else
                            {
                                result = result + "," + mmyy;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    conn.Close();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn.Close();
            return result;
        }

        private int MonthDiff(DateTime d1, DateTime d2)
        {
            int retVal = 0;

            if (d1.Month < d2.Month)
            {
                retVal = (d1.Month + 12) - d2.Month;
                retVal += ((d1.Year - 1) - d2.Year) * 12;
            }
            else
            {
                retVal = d1.Month - d2.Month;
                retVal += (d1.Year - d2.Year) * 12;
            }
            return retVal;
        }



        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {
            //
        }

        private void Mau_79_80_Load(object sender, EventArgs e)
        {
            //
        }

        

        

        public string Xu_ly_ngay(string ngay)
        {
            string ngay_dung = "";
            if (ngay.Length == 1)
            {
                ngay_dung = "0" + ngay;
            }
            else if (ngay.Length == 2)
            {
                ngay_dung = ngay;
            }
            return ngay_dung;
        }

        

        

       
        private void simpleButton_xemdulieu_Click(object sender, EventArgs e)
        {
            Form_viewdata f = new Form_viewdata();
            f.Visible = true;
            f.load_data(Table_7980);
            
        }

        

        private void simpleButton_DL3360_Click(object sender, EventArgs e)
        {
            Form_viewdata f = new Form_viewdata();
            f.Visible = true;
            f.load_data(table_Cv3360);
        }

        public void du_lieu_tthuyqt(string tungay, string denngay, string solieu)
        {
            OracleConnection conn = Database.GetDBConnection();
            var cmd = new OracleCommand();
            Table_tthuyqt.Clear();
            //string so_lieu_kcb = Class_CorrectData.Get_LoaiKCB(Convert.ToInt16(solieu));
            string mmyy_user = datauser(tungay, denngay);
            //MessageBox.Show(so_lieu_kcb + mmyy_user);
            try
            {
                cmd.Connection = conn;
                cmd.CommandText = "select * from (table(hsoft.vnpt.func_tthuyqt('" + mmyy_user + "','" + tungay + "','" + denngay + "','" + solieu + "')))";
                cmd.CommandType = CommandType.Text;


                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    Table_tthuyqt.Load(reader);
                    MessageBox.Show("Xử lý dữ liệu thành công");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn.Close();

        }
        public void du_lieu_tai_bv(string tungay, string denngay, string solieu)
        {
            OracleConnection conn = Database.GetDBConnection();
            var cmd = new OracleCommand();
            Table_7980.Clear();
            string so_lieu_kcb = solieu;
            string mmyy_user = datauser(tungay, denngay);
            MessageBox.Show(so_lieu_kcb + mmyy_user);
            try
            {
                cmd.Connection = conn;
                cmd.CommandText = "select * from (table(hsoft.vnpt.func_bc_mau79802the('" + mmyy_user + "','" + tungay + "','" + denngay + "','" + so_lieu_kcb + "')))";
                cmd.CommandType = CommandType.Text;


                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    Table_7980.Load(reader);
                    MessageBox.Show("Xử lý dữ liệu thành công");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn.Close();

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string solieu = "";
            if (this.dateEdit_tungay.Text == "" || this.dateEdit_denngay.Text == "")
            {
                XtraMessageBox.Show("Vui lòng nhập ngày báo cáo! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.cb_solieu.Text == "")
            {
                XtraMessageBox.Show("Vui lòng chọn số liệu! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                if (this.cb_solieu.Text=="Nội trú")
                {
                    solieu = "AND solieu=1";
                    so_lieu_7980 = "=1";
                }
                if (this.cb_solieu.Text == "Ngoại trú")
                {
                    solieu = "AND solieu!=1";
                    so_lieu_7980 = "!=1";
                }
            }
            SplashScreenManager.ShowForm(this.ParentForm, typeof(WaitForm), true, true, false);
            try
            {
                du_lieu_tthuyqt(dateEdit_tungay.Text, dateEdit_denngay.Text,solieu);
                gridControl1.DataSource = Table_tthuyqt;
                simpleButton3.Enabled = true;
            }
            finally
            {
                SplashScreenManager.CloseForm(false);
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            du_lieu_tai_bv(dateEdit_tungay.Text, dateEdit_denngay.Text, so_lieu_7980);
            Table_kqtthuyqt = Class_CorrectData.TTHuyQT(Table_tthuyqt, Table_7980);
            gridControl2.DataSource = Table_kqtthuyqt;
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            Form_viewdata f = new Form_viewdata();
            f.Visible = true;
            f.load_data(Table_7980);
        }
    }
}
