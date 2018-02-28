using System;
using DevExpress.XtraSplashScreen;
using Stimulsoft.Report;
using System.Globalization;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using Stimulsoft.Report.Dictionary;

namespace HISSMS
{
    public partial class XtraUserControlMauTK373N : DevExpress.XtraEditors.XtraUserControl
    {
        public XtraUserControlMauTK373N()
        {
            InitializeComponent();
        }

        private void loadReport()
        {
            StiReport report = new StiReport();
            report.Load("Reports\\mau_tk37_3_nhom.mrt");
            StiSqlDatabase sqlDB = new StiSqlDatabase();
            sqlDB = (StiSqlDatabase)report.Dictionary.Databases["Oracle"];
            sqlDB.ConnectionString = FormHISSMS.conn_string;
            report.Compile();
            report["schemamonth"] = dateToSchemaMonth(dateEditTuNgay.Text, dateEditDenNgay.Text);
            report["tungay"] = dateEditTuNgay.Text;
            report["denngay"] = dateEditDenNgay.Text;
            if (cb_solieu.Text=="Nội trú")
            {
                report["solieu"] = "=1";
            }
            else
            {
                report["solieu"] = "!=1";
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
    }
}
