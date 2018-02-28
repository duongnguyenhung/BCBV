using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Oracle.DataAccess.Client;
using System.Windows.Forms;


namespace HISSMS
{
    class Class_CorrectData
    {
        public static string Get_LoaiKCB(int maloaikcb)
        {
            if (maloaikcb==3)
            {
                return "=1";
            }
            else
            {
                return "!=1";
            }
            ;         
        }
        public static string Get_SoLechBN(int sl_bv,int slcv3360)
        {
            if (sl_bv > slcv3360)
            {
                return "Số lượng bệnh nhân tại dữ liệu BV đang nhiều hơn trên cổng giám định là " + (sl_bv - slcv3360);
            }
            else if (sl_bv < slcv3360)
            {
                return "Số lượng bệnh nhân tại dữ liệu BV đang ít hơn trên cổng giám định là " + (slcv3360 - sl_bv);
            }
            else
            {
                return "Số lượng bệnh nhân tại dữ liệu BV và cổng giám định không có chênh lệch";
            }
            
        }
        public static string Xulyngay(string ngay)
        {
            string ngay_dung=ngay.Substring(6, 2)+"/"+ ngay.Substring(4, 2) + "/" + ngay.Substring(0,4);
            return ngay_dung;
        }
        public static DataTable Quick_Scan_3360_7980(DataTable table7980, DataTable tablecv3360)
        {
            DataTable ketqua = new DataTable();
            ketqua = tablecv3360.Copy();
            ketqua.Clear();
            int flag = 0;
            for (int i = 0; i < tablecv3360.Rows.Count; i++)
            {
                flag = 0;
                DataRow dr_cv3360 = tablecv3360.Rows[i];
                for (int j = 0; j < table7980.Rows.Count; j++)
                {
                    DataRow dr_7980 = table7980.Rows[j];
                    if (dr_7980[3].ToString() == dr_cv3360[1].ToString() && dr_7980[1].ToString() == Xulyngay(dr_cv3360[14].ToString()) && dr_7980[2].ToString() == Xulyngay(dr_cv3360[15].ToString()))
                    {
                        if (Convert.ToInt32(dr_cv3360[19]) - Convert.ToInt32(dr_7980[14]) == 0)
                        {
                            flag = flag + 1;
                        }
                    }                            
                }
                if (flag == 0)
                {
                    ketqua.ImportRow(dr_cv3360);
                }

            }
            return ketqua;
        }
        public static DataTable Quick_Scan_7980_3360(DataTable table7980, DataTable tablecv3360)
        {
            DataTable ketqua_7980_3360 = new DataTable();
            ketqua_7980_3360 = table7980.Copy();
            ketqua_7980_3360.Clear();
            int flag = 0;
            for (int j = 0; j < table7980.Rows.Count; j++)
                
            {
                flag = 0;
                DataRow dr_7980 = table7980.Rows[j];
                
                for (int i = 0; i < tablecv3360.Rows.Count; i++)
                {
                    DataRow dr_cv3360 = tablecv3360.Rows[i];
                    if (dr_7980[3].ToString() == dr_cv3360[1].ToString() && dr_7980[1].ToString() == Xulyngay(dr_cv3360[14].ToString()) && dr_7980[2].ToString() == Xulyngay(dr_cv3360[15].ToString()))
                    {
                        if (Convert.ToInt32(dr_7980[14]) - Convert.ToInt32(dr_cv3360[19]) == 0)
                        {
                            flag = flag + 1;
                        }
                    }
                }
                if (flag == 0)
                {
                    ketqua_7980_3360.ImportRow(dr_7980);
                }

            }
            return ketqua_7980_3360;
        }
        public static DataTable TTHuyQT(DataTable tthuyqt, DataTable table7980)
        {
            DataTable ketqua_tthuyqt = new DataTable();
            ketqua_tthuyqt = tthuyqt.Copy();
            ketqua_tthuyqt.Clear();
            int flag = 0;
            for (int j = 0; j < tthuyqt.Rows.Count; j++)

            {
                flag = 0;
                DataRow dr_tthuyqt = tthuyqt.Rows[j];
                
                for (int i = 0; i < table7980.Rows.Count; i++)
                {
                    DataRow dr_7980 = table7980.Rows[i];
                    //MessageBox.Show(dr_tthuyqt[8].ToString() + dr_7980[30].ToString());

                    if (dr_tthuyqt[8].ToString() == dr_7980[30].ToString())
                    {
                        flag = flag + 1;
                        
                    }
                    
                }
                if (flag == 0)
                {
                    ketqua_tthuyqt.ImportRow(dr_tthuyqt);
                }
            }
            return ketqua_tthuyqt;
        }
    }
}
