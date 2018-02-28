using System;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Oracle.DataAccess.Client;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraSplashScreen;
using System.IO;


namespace HISSMS
{
    public partial class XtraUserControlSMS : DevExpress.XtraEditors.XtraUserControl
    {
        
        string[] arrayTrangthai = null;
        string[] arrayHinhThucGui = null;
        OracleCommand cmd = null;

        public XtraUserControlSMS()
        {
            InitializeComponent();
            dateEditTuNgay.EditValue = DateTime.Now;
            dateEditDenNgay.EditValue = DateTime.Now;
            arrayTrangthai = new string[4];
            arrayTrangthai[0] = "";
            arrayTrangthai[1] = "OK";
            arrayTrangthai[2] = "Fail";
            arrayHinhThucGui = new string[4];
            arrayHinhThucGui[0] = "Gửi toàn bộ (tin thất bại + chưa gửi)";
            arrayHinhThucGui[1] = "Gửi tin thất bại";
            arrayHinhThucGui[2] = "Gửi tin chưa gửi";
            arrayHinhThucGui[3] = "Gửi theo danh sách chọn";
            this.comboBoxEditHinhThuc.Properties.Items.AddRange(arrayHinhThucGui);
            this.comboBoxEditHinhThuc.SelectedIndex = 0;
            timer1.Interval = 1000;
            timer1.Start();
        }
        private void simpleButtonXem_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(this.ParentForm, typeof(WaitForm), true, true, false);
            try {
                loadDsHen(dateEditTuNgay.Text, dateEditDenNgay.Text);
            }
            finally
            {
                SplashScreenManager.CloseForm(false);
            }
        }

        private void loadDsHen(string tungay, string denngay)
        {
            string sql = "select maql as ID,mabn as MaBN,hoten as HoTen,namsinh as NamSinh,sothe as SoThe,case when trim(cholam) is not null then trim(cholam) else replace(diachi,'.','') end DiaChi, didong as SoDienThoai,ngayhen as NgayHen,'' as NoiDung," 
            +"'' as TrangThai,0 as SoLanGui "
            +"from (select a.maql,a.mabn,b.hoten,b.namsinh,d.sothe,c.didong,a.ngayhen,"
            +"(case when replace(trim(b.sonha),',',null) is not null then (replace(trim(b.sonha),',',null) || ', ') else null end) || "
            +"(case when replace(trim(b.thon),',',null) is not null then (replace(trim(b.thon),',',null) || ', ') else null end) || "
            +"(case when replace(trim(g.tenpxa),',',null) is not null then (replace(trim(g.tenpxa),',',null) || ', ') else null end) || "
            +"(case when trim(e.tenquan) is not null then (trim(e.tenquan) || ', ') else null end) || trim(f.tentt) as diachi,cholam from hsoft.hen a "
            + "left join btdbn b on (a.mabn = b.mabn) left join dienthoai c on (b.mabn = c.mabn) left join bhyt d on (a.maql=d.maql) "
            +"left join btdquan e on (b.maqu=e.maqu) left join btdtt f on (b.matt=f.matt) left join btdpxa g on (b.maphuongxa=g.maphuongxa)  where to_date(to_char(a.ngayhen,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('" + tungay + "','dd/mm/yyyy') and to_date(to_char(a.ngayhen,'dd/mm/yyyy'),'dd/mm/yyyy') <= to_date('" + denngay + "','dd/mm/yyyy'))";
            try
            {
                cmd = new OracleCommand(sql, FormHISSMS.conn);
                cmd.CommandType = CommandType.Text;
                DataTable dt = new DataTable();
                OracleDataAdapter da = new OracleDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(dt);
                insertUpdateDsHen(dt);
                sql = "select MaBN, HoTen, DiaChi,SoDienThoai,NoiDung,to_char(NgayHen,'dd/mm/yyyy') as NgayHen,SoThe,NamSinh, TrangThai, SoLanGui,ID from sms_henkham where to_date(to_char(ngayhen,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('" + tungay + "','dd/mm/yyyy') and to_date(to_char(ngayhen,'dd/mm/yyyy'),'dd/mm/yyyy') <= to_date('" + denngay + "','dd/mm/yyyy')";
                dt = new DataTable();
                cmd = new OracleCommand(sql, FormHISSMS.conn);
                da = new OracleDataAdapter();
                da.SelectCommand = cmd;
                GridView view = gridControlSMS.MainView as GridView;
                foreach (GridColumn column in view.Columns)
                {
                    dt.Columns.Add(column.Name);
                    column.FieldName = column.Name;
                }
                da.Fill(dt);
                gridControlSMS.DataSource = dt; 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void xemDsHen(string tungay, string denngay)
        {
            string sql = "select MaBN, HoTen, DiaChi,SoDienThoai,NoiDung,to_char(NgayHen,'dd/mm/yyyy') as NgayHen,SoThe,NamSinh, TrangThai, SoLanGui,ID from sms_henkham where to_date(to_char(ngayhen,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('" + tungay + "','dd/mm/yyyy') and to_date(to_char(ngayhen,'dd/mm/yyyy'),'dd/mm/yyyy') <= to_date('" + denngay + "','dd/mm/yyyy')";
            OracleCommand cmd = new OracleCommand(sql, FormHISSMS.conn);
            DataTable dt = new DataTable();
            OracleDataAdapter da = new OracleDataAdapter();
            da.SelectCommand = cmd;
            GridView view = gridControlSMS.MainView as GridView;
            foreach (GridColumn column in view.Columns)
            {
                dt.Columns.Add(column.Name);
                column.FieldName = column.Name;
            }
            da.Fill(dt);
            gridControlSMS.DataSource = dt;
        }

        private void insertUpdateDsHen(DataTable dt)
        {
            int rowCount = 0;
            
            foreach(DataRow row in dt.Rows)
            {
                try
                {
                    string sql = "select 1 from sms_henkham where id=" + row.ItemArray[0].ToString();
                    cmd = new OracleCommand(sql, FormHISSMS.conn);
                    cmd.CommandType = CommandType.Text;
                    DataTable dttmp = new DataTable();
                    OracleDataAdapter da = new OracleDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dttmp);
                    if (dttmp.Rows.Count >= 1)
                    {
                        sql = "Update sms_henkham set HOTEN=" + "'" + row.ItemArray[2].ToString() + "',"
                        + "NAMSINH=" + "'" + row.ItemArray[3].ToString() + "',"
                        + "SOTHE=" + "'" + row.ItemArray[4].ToString() + "',"
                        + "DIACHI=" + "'" + row.ItemArray[5].ToString() + "',"
                        + "SODIENTHOAI=" + "'" + row.ItemArray[6].ToString() + "',"
                        + "NGAYHEN=to_date(" + "'" + row.ItemArray[7].ToString() + "','mm/dd/yyyy hh:mi:ss AM') where ID=" + row.ItemArray[0].ToString();
                    }
                    else
                    {
                        sql = "Insert into sms_henkham (ID,MABN, HOTEN, NAMSINH, SOTHE, DIACHI,SODIENTHOAI,NGAYHEN,NOIDUNG,TRANGTHAI,SOLANGUI) "
                        + " values ('" + row.ItemArray[0].ToString() + "',"
                        + "'" + row.ItemArray[1].ToString() + "',"
                        + "'" + row.ItemArray[2].ToString() + "',"
                        + "'" + row.ItemArray[3].ToString() + "',"
                        + "'" + row.ItemArray[4].ToString() + "',"
                        + "'" + row.ItemArray[5].ToString() + "',"
                        + "'" + row.ItemArray[6].ToString() + "',"
                        + "to_date('" + row.ItemArray[7].ToString() + "','mm/dd/yyyy hh:mi:ss AM'),"
                        + "'" + row.ItemArray[8].ToString() + "',"
                        + "'" + row.ItemArray[9].ToString() + "',"
                        + "'" + row.ItemArray[10].ToString()
                        + "')";
                    }
                    cmd = FormHISSMS.conn.CreateCommand();
                    cmd.CommandText = sql;
                    cmd.Connection = FormHISSMS.conn;
                    rowCount += cmd.ExecuteNonQuery();
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void gridView1_RowStyle(object sender, RowStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                string tranthai = View.GetRowCellDisplayText(e.RowHandle, View.Columns["TrangThai"]);
                if (Array.IndexOf(arrayTrangthai,tranthai) == 2)
                {
                    e.Appearance.BackColor = Color.FromArgb(150, Color.Tomato);
                    e.Appearance.BackColor2 = Color.White;
                }
                if (Array.IndexOf(arrayTrangthai, tranthai) == 1)
                {
                    e.Appearance.BackColor = Color.FromArgb(150, Color.LightGreen);
                    e.Appearance.BackColor2 = Color.White;
                }
            }
        }

        private void guiSMS()
        {
            SplashScreenManager.ShowForm(this.ParentForm, typeof(WaitForm), true, true, false);
            try
            {
                clsSMSConfig myConfig = new clsSMSConfig();
                myConfig.sms_agentid = FormHISSMS.arrayThamSo[0].Trim() == "" ? myConfig.sms_agentid : FormHISSMS.arrayThamSo[0];
                myConfig.sms_labelid = FormHISSMS.arrayThamSo[1].Trim() == "" ? myConfig.sms_labelid : FormHISSMS.arrayThamSo[1];
                myConfig.sms_templateid = FormHISSMS.arrayThamSo[2].Trim() == "" ? myConfig.sms_templateid : FormHISSMS.arrayThamSo[2];
                myConfig.sms_istelcosub = FormHISSMS.arrayThamSo[3].Trim() == "" ? myConfig.sms_istelcosub : FormHISSMS.arrayThamSo[3];
                myConfig.sms_contracttypeid = FormHISSMS.arrayThamSo[4].Trim() == "" ? myConfig.sms_contracttypeid : FormHISSMS.arrayThamSo[4];
                myConfig.sms_apiuser = FormHISSMS.arrayThamSo[5].Trim() == "" ? myConfig.sms_apiuser : FormHISSMS.arrayThamSo[5];
                myConfig.sms_apipass = FormHISSMS.arrayThamSo[6].Trim() == "" ? myConfig.sms_apipass : FormHISSMS.arrayThamSo[6];
                myConfig.sms_username = FormHISSMS.arrayThamSo[7].Trim() == "" ? myConfig.sms_username : FormHISSMS.arrayThamSo[7];
                myConfig.sms_contractid = FormHISSMS.arrayThamSo[8].Trim() == "" ? myConfig.sms_contractid : FormHISSMS.arrayThamSo[8];

                clsSMS mySMS = new clsSMS();
                string strDidong = "";
                string strNoidung = "";
                string res = "";
                string[] param = null;
                string sql = null;

                //strDidong = "84918882131";
                //strNoidung = "Hello";
                //param = new string[2];
                //param[0] = strNoidung;
                //param[1] = "";
                //res = mySMS.sendByList(get_seq(), myConfig.sms_labelid, myConfig.sms_templateid, myConfig.sms_istelcosub, myConfig.sms_contracttypeid, "", strDidong, myConfig.sms_agentid, myConfig.sms_apiuser, myConfig.sms_apipass, myConfig.sms_username, myConfig.sms_contractid, param);
                // XtraMessageBox.Show(res, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //return;
                if (this.comboBoxEditHinhThuc.Text == arrayHinhThucGui[0])
                {
                    for (int i = 0; i < gridView.DataRowCount; i++)
                    {
                        if (gridView.GetRowCellValue(i, "TrangThai").ToString() == arrayTrangthai[0] || gridView.GetRowCellValue(i, "TrangThai").ToString() == arrayTrangthai[2])
                        {
                            string ketqua = "";
                            string hoten = gridView.GetRowCellValue(i, "HoTen").ToString();
                            string ngayhen = gridView.GetRowCellValue(i, "NgayHen").ToString();
                            string strSolangui = gridView.GetRowCellValue(i, "SoLanGui").ToString();
                            string id = gridView.GetRowCellValue(i, "ID").ToString();
                            strDidong = gridView.GetRowCellValue(i, "SoDienThoai").ToString();
                            if (strDidong.Trim() != "")
                            {
                                strNoidung = FormHISSMS.arrayThamSo[12].Replace("<HoTen>", hoten);
                                strNoidung = strNoidung.Replace("<NgayHen>", strNoidung);
                                strNoidung = mySMS.EscapeXML(strNoidung);
                                param = new string[2];
                                param[0] = strNoidung;
                                param[1] = "";
                                //res = mySMS.sendByList(get_seq(), myConfig.sms_labelid, myConfig.sms_templateid, myConfig.sms_istelcosub, myConfig.sms_contracttypeid, "", strDidong, myConfig.sms_agentid, myConfig.sms_apiuser, myConfig.sms_apipass, myConfig.sms_username, myConfig.sms_contractid, param);
                                ketqua = mySMS.getValue(res, "<ERROR_DESC>", "</ERROR_DESC>");
                                ketqua = ketqua == "success" ? "1" : "2";
                            }
                            else
                            {
                                ketqua = "2";
                            }
                            int idxTrangthai = Int32.Parse(ketqua);
                            int solangui = Int32.Parse(strSolangui);
                            solangui += 1;
                            sql = "Update sms_henkham set TRANGTHAI=" + "'" + arrayTrangthai[idxTrangthai] + "',"
                            + "SOLANGUI=" + "'" + solangui + "' where ID=" + id;
                            cmd = FormHISSMS.conn.CreateCommand();
                            cmd.CommandText = sql;
                            cmd.Connection = FormHISSMS.conn;
                            cmd.ExecuteNonQuery();
                            gridView.SetRowCellValue(i, "TrangThai", arrayTrangthai[idxTrangthai]);
                            gridView.SetRowCellValue(i, "SoLanGui", solangui);
                        }
                    }
                }
                else if (this.comboBoxEditHinhThuc.Text == arrayHinhThucGui[1])
                {
                    for (int i = 0; i < gridView.DataRowCount; i++)
                    {
                        if (gridView.GetRowCellValue(i, "TrangThai").ToString() == arrayTrangthai[2])
                        {
                            string ketqua = "";
                            string hoten = gridView.GetRowCellValue(i, "HoTen").ToString();
                            string ngayhen = gridView.GetRowCellValue(i, "NgayHen").ToString();
                            string strSolangui = gridView.GetRowCellValue(i, "SoLanGui").ToString();
                            string id = gridView.GetRowCellValue(i, "ID").ToString();
                            strDidong = gridView.GetRowCellValue(i, "SoDienThoai").ToString();
                            if (strDidong.Trim() != "")
                            {
                                strNoidung = FormHISSMS.arrayThamSo[12].Replace("<HoTen>", hoten);
                                strNoidung = strNoidung.Replace("<NgayHen>", strNoidung);
                                strNoidung = mySMS.EscapeXML(strNoidung);
                                param = new string[2];
                                param[0] = strNoidung;
                                param[1] = "";
                                //res = mySMS.sendByList(get_seq(), myConfig.sms_labelid, myConfig.sms_templateid, myConfig.sms_istelcosub, myConfig.sms_contracttypeid, "", strDidong, myConfig.sms_agentid, myConfig.sms_apiuser, myConfig.sms_apipass, myConfig.sms_username, myConfig.sms_contractid, param);
                                ketqua = mySMS.getValue(res, "<ERROR_DESC>", "</ERROR_DESC>");
                                ketqua = ketqua == "success" ? "1" : "2";
                            }
                            else
                            {
                                ketqua = "2";
                            }
                            int idxTrangthai = Int32.Parse(ketqua);
                            int solangui = Int32.Parse(strSolangui);
                            solangui += 1;
                            sql = "Update sms_henkham set TRANGTHAI=" + "'" + arrayTrangthai[idxTrangthai] + "',"
                            + "SOLANGUI=" + "'" + solangui + "' where ID=" + id;
                            cmd = FormHISSMS.conn.CreateCommand();
                            cmd.CommandText = sql;
                            cmd.Connection = FormHISSMS.conn;
                            cmd.ExecuteNonQuery();
                            gridView.SetRowCellValue(i, "TrangThai", arrayTrangthai[idxTrangthai]);
                            gridView.SetRowCellValue(i, "SoLanGui", solangui);
                        }
                    }
                }
                else if (this.comboBoxEditHinhThuc.Text == arrayHinhThucGui[2])
                {
                    for (int i = 0; i < gridView.DataRowCount; i++)
                    {
                        if (gridView.GetRowCellValue(i, "TrangThai").ToString() == arrayTrangthai[0])
                        {
                            string ketqua = "";
                            string hoten = gridView.GetRowCellValue(i, "HoTen").ToString();
                            string ngayhen = gridView.GetRowCellValue(i, "NgayHen").ToString();
                            string strSolangui = gridView.GetRowCellValue(i, "SoLanGui").ToString();
                            string id = gridView.GetRowCellValue(i, "ID").ToString();
                            strDidong = gridView.GetRowCellValue(i, "SoDienThoai").ToString();
                            if (strDidong.Trim() != "")
                            {
                                strNoidung = FormHISSMS.arrayThamSo[12].Replace("<HoTen>", hoten);
                                strNoidung = strNoidung.Replace("<NgayHen>", strNoidung);
                                strNoidung = mySMS.EscapeXML(strNoidung);
                                param = new string[2];
                                param[0] = strNoidung;
                                param[1] = "";
                                //res = mySMS.sendByList(get_seq(), myConfig.sms_labelid, myConfig.sms_templateid, myConfig.sms_istelcosub, myConfig.sms_contracttypeid, "", strDidong, myConfig.sms_agentid, myConfig.sms_apiuser, myConfig.sms_apipass, myConfig.sms_username, myConfig.sms_contractid, param);
                                ketqua = mySMS.getValue(res, "<ERROR_DESC>", "</ERROR_DESC>");
                                ketqua = ketqua == "success" ? "1" : "2";
                            }
                            else
                            {
                                ketqua = "2";
                            }
                            int idxTrangthai = Int32.Parse(ketqua);
                            int solangui = Int32.Parse(strSolangui);
                            solangui += 1;
                            sql = "Update sms_henkham set TRANGTHAI=" + "'" + arrayTrangthai[idxTrangthai] + "',"
                            + "SOLANGUI=" + "'" + solangui + "' where ID=" + id;
                            cmd = FormHISSMS.conn.CreateCommand();
                            cmd.CommandText = sql;
                            cmd.Connection = FormHISSMS.conn;
                            cmd.ExecuteNonQuery();
                            gridView.SetRowCellValue(i, "TrangThai", arrayTrangthai[idxTrangthai]);
                            gridView.SetRowCellValue(i, "SoLanGui", solangui);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < gridView.SelectedRowsCount; i++)
                    {

                        string ketqua = "";
                        DataRow row = gridView.GetDataRow(gridView.GetSelectedRows()[i]);
                        string hoten = row["HoTen"].ToString();
                        string ngayhen = row["NgayHen"].ToString();
                        string strSolangui = row["SoLanGui"].ToString();
                        string id = row["ID"].ToString();
                        strDidong = row["SoDienThoai"].ToString();
                        if (strDidong.Trim() != "")
                        {
                            strNoidung = FormHISSMS.arrayThamSo[12].Replace("<HoTen>", hoten);
                            strNoidung = strNoidung.Replace("<NgayHen>", strNoidung);
                            strNoidung = mySMS.EscapeXML(strNoidung);
                            param = new string[2];
                            param[0] = strNoidung;
                            param[1] = "";
                            //res = mySMS.sendByList(get_seq(), myConfig.sms_labelid, myConfig.sms_templateid, myConfig.sms_istelcosub, myConfig.sms_contracttypeid, "", strDidong, myConfig.sms_agentid, myConfig.sms_apiuser, myConfig.sms_apipass, myConfig.sms_username, myConfig.sms_contractid, param);
                            ketqua = mySMS.getValue(res, "<ERROR_DESC>", "</ERROR_DESC>");
                            ketqua = ketqua == "success" ? "1" : "2";
                        }
                        else
                        {
                            ketqua = "2";
                        }
                        int idxTrangthai = Int32.Parse(ketqua);
                        int solangui = Int32.Parse(strSolangui);
                        solangui += 1;
                        sql = "Update sms_henkham set TRANGTHAI=" + "'" + arrayTrangthai[idxTrangthai] + "',"
                        + "SOLANGUI=" + "'" + solangui + "' where ID=" + id;
                        cmd = FormHISSMS.conn.CreateCommand();
                        cmd.CommandText = sql;
                        cmd.Connection = FormHISSMS.conn;
                        cmd.ExecuteNonQuery();
                        row["TrangThai"] = arrayTrangthai[idxTrangthai];
                        row["SoLanGui"] = solangui;
                    }

                }
            }
            finally
            {
                SplashScreenManager.CloseForm(false);
            }
        }

        private void simpleButtonGuiSMS_Click(object sender, EventArgs e)
        {
            if (FormHISSMS.arrayThamSo[11] == "True")
            {
                XtraMessageBox.Show("Vui lòng tắt tham số gửi tự động! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            guiSMS();
        }

        private String get_seq()
        {
            int n = new Random().Next(1, 1000000000);
            return n.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (FormHISSMS.arrayThamSo == null) return;
            DateTime date = DateTime.Now;
            Int64 addedDays = Convert.ToInt64(FormHISSMS.arrayThamSo[10]);
            date.AddDays(addedDays);
            string currentdate = date.ToString("dd/MM/yyyy");
            string time = date.Hour + ":" + date.Minute;

            if (FormHISSMS.arrayThamSo[9] == "True" && time == FormHISSMS.arrayThamSo[11].Trim())
            {
                loadDsHen(currentdate, currentdate);
                guiSMS();
            }
        }

        private void simpleButtonXem_Click_1(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(this.ParentForm, typeof(WaitForm), true, true, false);
            try
            {
                xemDsHen(dateEditTuNgay.Text, dateEditDenNgay.Text);
            }
            finally
            {
                SplashScreenManager.CloseForm(false);
            } 
        }

        private void simpleButtonExport_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Excel (2003)(.xls)|*.xls|Excel (2010) (.xlsx)|*.xlsx |RichText File (.rtf)|*.rtf |Pdf File (.pdf)|*.pdf |Html File (.html)|*.html";
                if (saveDialog.ShowDialog() != DialogResult.Cancel)
                {
                    string exportFilePath = saveDialog.FileName;
                    string fileExtenstion = new FileInfo(exportFilePath).Extension;
                    gridView.OptionsSelection.MultiSelect = false;
                    switch (fileExtenstion)
                    {
                        case ".xls":
                            gridControlSMS.ExportToXls(exportFilePath);
                            break;
                        case ".xlsx":
                            gridControlSMS.ExportToXlsx(exportFilePath);
                            break;
                        case ".rtf":
                            gridControlSMS.ExportToRtf(exportFilePath);
                            break;
                        case ".pdf":
                            gridControlSMS.ExportToPdf(exportFilePath);
                            break;
                        case ".html":
                            gridControlSMS.ExportToHtml(exportFilePath);
                            break;
                        case ".mht":
                            gridControlSMS.ExportToMht(exportFilePath);
                            break;
                        default:
                            break;
                    }
                    gridView.OptionsSelection.MultiSelect = true;
                    if (File.Exists(exportFilePath))
                    {
                        try
                        {
                            System.Diagnostics.Process.Start(exportFilePath);
                        }
                        catch
                        {
                            String msg = "Không thể mở file." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                            MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        String msg = "Không thể lưu file." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                        MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
