using System;
using DevExpress.XtraSplashScreen;
using Stimulsoft.Report;
using System.Globalization;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using Stimulsoft.Report.Dictionary;
using System.Data;
using Oracle.DataAccess.Client;

namespace HISSMS
{
    public partial class XtraUserControlMauTK373NNew : DevExpress.XtraEditors.XtraUserControl
    {
        public XtraUserControlMauTK373NNew()
        {
            InitializeComponent();
        }

        private void loadReport()
        {
            StiReport report = new StiReport();
            report.Load("Reports\\mau_tk37_NEW.mrt");
            StiSqlDatabase sqlDB = new StiSqlDatabase();
            sqlDB = (StiSqlDatabase)report.Dictionary.Databases["Oracle"];
            sqlDB.ConnectionString = FormHISSMS.conn_string;
            report.Compile();
            report["schemamonth"] = datauser(dateEditTuNgay.Text, dateEditDenNgay.Text);
            report["tungay"] = dateEditTuNgay.Text;
            report["denngay"] = dateEditDenNgay.Text;
            //MessageBox.Show(datauser(dateEditTuNgay.Text, dateEditDenNgay.Text));
            if (cb_solieu.Text=="Nội trú")
            {
                report["solieu"] = "and a.loaiba=1";
            }
            else if (cb_solieu.Text == "Tất cả")
            {
                report["solieu"] = "";
            }
            else
            {
                report["solieu"] = "and a.loaiba!=1";
            }
            
            report.Render(false);

            stiViewerControl.Report = report;
        }

        private string dateToSchemaMonth(string tungay, string denngay)
        {
            DateTime oTungay = DateTime.ParseExact(tungay, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime oDenngay = DateTime.ParseExact(denngay, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            int period = -MonthDiff(oTungay, oDenngay);
            string result = oTungay.ToString("MMyy");
            DateTime tmp = oTungay;
            for (int i=0;i<period;i++)
            {
                tmp = tmp.AddMonths(1);
                result = result +","+ tmp.ToString("MMyy");
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

        private void simpleButtonXem_Click(object sender, EventArgs e)
        {
            string sl=cb_solieu.Text;
            //MessageBox.Show(sl);
            if (this.dateEditTuNgay.Text == "" || this.dateEditDenNgay.Text == "")
            {
                XtraMessageBox.Show("Vui lòng nhập ngày báo cáo! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.cb_solieu.Text== "")
            {
                XtraMessageBox.Show("Vui lòng chọn số liệu! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            SplashScreenManager.ShowForm(this.ParentForm, typeof(WaitForm), true, true, false);
            try
            {
                loadReport();
                
            }
            finally
            {
                SplashScreenManager.CloseForm(false);
            }
        }

        private void cb_solieu_EditValueChanged(object sender, EventArgs e)
        {
            //
        }

        private void cb_solieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            //
        }
    }
}
