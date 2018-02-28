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
    public partial class XtraUserControlCV3360 : DevExpress.XtraEditors.XtraUserControl
    {
        public XtraUserControlCV3360()
        {
            InitializeComponent();
        }
        public string thangqt;
        public string namqt;
        public string maloaikcb;
        public int slbncv3360;
        public DataTable Table_7980 = new DataTable();
        public DataTable table_Cv3360 = new DataTable();
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

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            xtraOpenFileDialog1.Filter = "Excel < 2003(*.xls)|*.xls|Excel > 2003(*.xlsx)|*.xlsx";
            xtraOpenFileDialog1.ShowDialog();
            if (xtraOpenFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox_duongdan.Text = xtraOpenFileDialog1.FileName;
                simpleButton_xulyfile.Enabled = true;
            }
            labelControl_thongbao.Text = "Đã chọn file CV3360, vui lòng bấm Import";
        }

        private void simpleButton_xulyfile_Click(object sender, EventArgs e)
        {
            try
            {
                System.Data.OleDb.OleDbConnection MyConnection;
                System.Data.DataSet DtSet;
                System.Data.OleDb.OleDbDataAdapter MyCommand;
                MessageBox.Show(textBox_duongdan.Text);
                MyConnection = new System.Data.OleDb.OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + textBox_duongdan.Text + "';Extended Properties=Excel 8.0;");
                MyCommand = new System.Data.OleDb.OleDbDataAdapter("select * from [Sheet1$]", MyConnection);
                MyCommand.TableMappings.Add("Table", "CV3360_Table");
                DtSet = new System.Data.DataSet();
                MyCommand.Fill(DtSet);
                int so_luong_bn = DtSet.Tables[0].Select().Length;
                //DataTable table_Cv3360;
                //DialogResult dialogResult = MessageBox.Show("Bạn có muốn làm mới nội dung CV3360 đã import không?", "Thông báo",MessageBoxButtons.YesNoCancel);
                //if (dialogResult == DialogResult.Yes)
                //{
                //    table_Cv3360.Clear();
               // }
                
                table_Cv3360 = DtSet.Tables[0];
                string t_tongchi = Convert.ToString(String.Format("{0:#,##0.##}", table_Cv3360.Compute("Sum(T_TONGCHI)", "")));
                string t_bntt = Convert.ToString(String.Format("{0:#,##0.##}", table_Cv3360.Compute("Sum(T_BNTT)", "")));
                string t_bhtt = Convert.ToString(String.Format("{0:#,##0.##}", table_Cv3360.Compute("Sum(T_BHTT)", "")));
                //MA_LOAIKCB
                //string ma_loaikcb = Convert.ToString(String.Format("{0:#,##0.##}", table_Cv3360.Compute("Max(MA_LOAIKCB)", "")));
                //DataRow[] dr = table_Cv3360.Select("SUM(T_TONGCHI)");
                object thang_qt = table_Cv3360.Compute("MAX(THANG_QT)", "");
                object nam_qt = table_Cv3360.Compute("MAX(NAM_QT)", "");
                object ma_loaikcb = table_Cv3360.Compute("MAX(MA_LOAIKCB)", "");
                thangqt = thang_qt.ToString();
                namqt = nam_qt.ToString();
                maloaikcb = ma_loaikcb.ToString();
                slbncv3360 = so_luong_bn;
                MessageBox.Show("Xử lý file excel thành công");
                labelControl_thongbao.Text = "Số liệu Tháng: " + thang_qt.ToString() + " Tổng số BN: " + so_luong_bn.ToString() + " Tổng CP: " + t_tongchi + " Tổng BNTT: " + t_bntt + " Tổng BHTT: " + t_bhtt;
                labelControltongbn.Text = "Tổng số BN: ";
                labelControl_tongchi.Text = "Tổng chi phí: " + t_tongchi;
                labelControltongbntt.Text = "Tổng BNTT: " + t_bntt;
                labelControltongbhtt.Text = "Tổng BHTT: " + t_bhtt;
                labelControlsobn.Text = Convert.ToString(String.Format("{0:#,##0.##}", so_luong_bn));
                simpleButtonxulysolieu.Enabled = true;
                MyConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
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

        public void du_lieu_tai_bv(string tungay,string denngay,string solieu)
        {
            OracleConnection conn = Database.GetDBConnection();
            var cmd = new OracleCommand();
            //var Table_7980 = new DataTable();
            Table_7980.Clear();
            string so_lieu_kcb = Class_CorrectData.Get_LoaiKCB(Convert.ToInt16(solieu));
            string mmyy_user = datauser(tungay,denngay);
            MessageBox.Show(so_lieu_kcb + mmyy_user);
            try
            {
                cmd.Connection = conn;
                cmd.CommandText = "select * from (table(hsoft.vnpt.func_bc_mau79802the('"+ mmyy_user + "','" + tungay + "','" + denngay + "','" + so_lieu_kcb + "')))";
                cmd.CommandType = CommandType.Text;
                
                
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    Table_7980.Load(reader);
                    MessageBox.Show("Xử lý dữ liệu thành công");
                }
                //DataSet ds_du_lieu_tai_bv = new DataSet();
                //OracleDataAdapter da_du_lieu_tai_bv = new OracleDataAdapter();
                //da_du_lieu_tai_bv.SelectCommand = cmd;
                //da_du_lieu_tai_bv.Fill(ds_du_lieu_tai_bv, "data");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            string soluong_7980 = Convert.ToString(String.Format("{0:#,##0.##}", Table_7980.Compute("COUNT(SOTHE)", "")));
            labelControl_sobn7980.Text = soluong_7980;
            int soluong_7980num = Convert.ToInt32(Table_7980.Compute("COUNT(SOTHE)", ""));
            string tongchi_7980 = Convert.ToString(String.Format("{0:#,##0.##}", Table_7980.Compute("Sum(T_TONGCHI)", "")));
            labelControl_tongcp7980.Text = "Tổng chi phí: " + tongchi_7980;
            string tongbntt_7980 = Convert.ToString(String.Format("{0:#,##0.##}", Table_7980.Compute("Sum(T_BNTT)", "")));
            labelControl_tongbntt7980.Text = "Tổng BNTT: " + tongbntt_7980;
            string tongbhtt_7980 = Convert.ToString(String.Format("{0:#,##0.##}", Table_7980.Compute("Sum(T_BHTT)", "")));
            labelControl_tongbhtt7980.Text = "Tổng BHTT: " + tongbhtt_7980;
            //MessageBox.Show(tongchi_7980);
            string ket_qua = Class_CorrectData.Get_SoLechBN(soluong_7980num, slbncv3360);
            labelControl_thongbao.Text = "Đã chuẩn hóa số liệu thành công, " + ket_qua;
            conn.Close();
            
        }

        private void simpleButtonxulysolieu_Click(object sender, EventArgs e)
        {
            int ngay_cuoi_thang = System.DateTime.DaysInMonth(Convert.ToInt32(namqt), Convert.ToInt32(thangqt));
            string tungay = String.Format("{0:dd/MM/yyyy}", "01"+"/"+ Xu_ly_ngay(thangqt) + "/"+ namqt);
            string denngay = String.Format("{0:dd/MM/yyyy}", ngay_cuoi_thang + "/" + Xu_ly_ngay(thangqt) + "/" + namqt);
            MessageBox.Show("Từ ngày " + tungay + "Đến ngày " + denngay + "Số liệu " + maloaikcb);
            du_lieu_tai_bv(tungay,denngay,maloaikcb);
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            gridControl_ketqua.DataSource = null;
            gridView1.Columns.Clear();
            DataTable kq = new DataTable();
            kq = Class_CorrectData.Quick_Scan_3360_7980(Table_7980,table_Cv3360);
            gridControl_ketqua.DataSource = kq;
            //MessageBox.Show("Xử lý thành công" + kq.Rows[0][0]);
            //Form_viewdata f = new Form_viewdata();
            //f.Visible = true;
            //f.load_data(kq);
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

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            gridControl_ketqua.DataSource = null;
            gridView1.Columns.Clear();
            DataTable kq2 = new DataTable();
            kq2 = Class_CorrectData.Quick_Scan_7980_3360(Table_7980, table_Cv3360);
            gridControl_ketqua.DataSource = kq2;
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            xtraSaveFileDialog1.ShowDialog();
            xtraSaveFileDialog1.DefaultExt = "xls";
            //gridControl_ketqua.ExportToXls();
            //xtraOpenFileDialog1.Filter = "Excel < 2003(*.xls)|*.xls|Excel > 2003(*.xlsx)|*.xlsx";
            //xtraOpenFileDialog1.ShowDialog();
            if (xtraSaveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                gridControl_ketqua.ExportToXls(xtraSaveFileDialog1.FileName);
            //   simpleButton_xulyfile.Enabled = true;
            }
            //labelControl_thongbao.Text = "Đã chọn file CV3360, vui lòng bấm Import";
        }
    }
}
