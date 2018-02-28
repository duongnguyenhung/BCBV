using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Oracle.DataAccess.Client;


namespace HISSMS
{
    public partial class XtraUserControlThamSo : DevExpress.XtraEditors.XtraUserControl
    {
        public XtraUserControlThamSo()
        {
            InitializeComponent();
            loadThamSo();
        }

        private void simpleButtonLuu_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            OracleDataAdapter da = new OracleDataAdapter();
            cmd = FormHISSMS.conn.CreateCommand();
            cmd.Connection = FormHISSMS.conn;
            string sql = "Update sms_thamso set GIATRI=" + "'" + this.textEditAgentId.Text + "' where ID=1";
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            sql = "Update sms_thamso set GIATRI=" + "'" + this.textEditLabelId.Text + "' where ID=2";
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            sql = "Update sms_thamso set GIATRI=" + "'" + this.textEditTemplateId.Text + "' where ID=3";
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            sql = "Update sms_thamso set GIATRI=" + "'" + this.textEditIstelcosub.Text + "' where ID=4";
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            sql = "Update sms_thamso set GIATRI=" + "'" + this.textEditContractTypeId.Text + "' where ID=5";
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            sql = "Update sms_thamso set GIATRI=" + "'" + this.textEditApiUser.Text + "' where ID=6";
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            sql = "Update sms_thamso set GIATRI=" + "'" + this.textEditApiPass.Text + "' where ID=7";
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            sql = "Update sms_thamso set GIATRI=" + "'" + this.textEditSmsUsername.Text + "' where ID=8";
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            sql = "Update sms_thamso set GIATRI=" + "'" + this.textEditContractId.Text + "' where ID=9";
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            sql = "Update sms_thamso set GIATRI=" + "'" + this.timeEditGioGui.Text + "' where ID=12";
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            sql = "Update sms_thamso set GIATRI=" + "'" + this.richTextBoxNoiDung.Text + "' where ID=13";
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            sql = "Update sms_thamso set GIATRI=" + "'" + this.checkEditTuDongGui.Checked + "' where ID=10";
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            sql = "Update sms_thamso set GIATRI=" + "'" + this.spinEditSoNgay.Value + "' where ID=11";
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            loadThamSo();
            XtraMessageBox.Show("Cập nhật thành công!  ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void loadThamSo()
        {
            string sql = "select id,giatri from sms_thamso order by id asc";
            try
            {
                OracleCommand cmd = new OracleCommand(sql, FormHISSMS.conn);
                cmd.CommandType = CommandType.Text;
                DataTable dt = new DataTable();
                OracleDataAdapter da = new OracleDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    this.textEditAgentId.Text = dt.Rows[0]["giatri"].ToString();
                    this.textEditLabelId.Text = dt.Rows[1]["giatri"].ToString();
                    this.textEditTemplateId.Text = dt.Rows[2]["giatri"].ToString();
                    this.textEditIstelcosub.Text = dt.Rows[3]["giatri"].ToString();
                    this.textEditContractTypeId.Text = dt.Rows[4]["giatri"].ToString();
                    this.textEditApiUser.Text = dt.Rows[5]["giatri"].ToString();
                    this.textEditApiPass.Text = dt.Rows[6]["giatri"].ToString();
                    this.textEditSmsUsername.Text = dt.Rows[7]["giatri"].ToString();
                    this.textEditContractId.Text = dt.Rows[8]["giatri"].ToString();
                    try
                    {
                        this.timeEditGioGui.EditValue = dt.Rows[11]["giatri"].ToString();
                    }
                    catch (FormatException)
                    {
                    } 
                    this.richTextBoxNoiDung.Text = dt.Rows[12]["giatri"].ToString();
                    try
                    {
                        this.checkEditTuDongGui.Checked = Convert.ToBoolean(dt.Rows[9]["giatri"].ToString());
                    }
                    catch (FormatException)
                    {
                    }
                    try
                    {
                        this.spinEditSoNgay.Value = Int16.Parse(dt.Rows[10]["giatri"].ToString());
                    }
                    catch (FormatException)
                    {
                    }
                    FormHISSMS.arrayThamSo[int.Parse(dt.Rows[0]["ID"].ToString()) - 1] = dt.Rows[0]["GIATRI"].ToString();
                    FormHISSMS.arrayThamSo[int.Parse(dt.Rows[1]["ID"].ToString()) - 1] = dt.Rows[1]["GIATRI"].ToString();
                    FormHISSMS.arrayThamSo[int.Parse(dt.Rows[2]["ID"].ToString()) - 1] = dt.Rows[2]["GIATRI"].ToString();
                    FormHISSMS.arrayThamSo[int.Parse(dt.Rows[3]["ID"].ToString()) - 1] = dt.Rows[3]["GIATRI"].ToString();
                    FormHISSMS.arrayThamSo[int.Parse(dt.Rows[4]["ID"].ToString()) - 1] = dt.Rows[4]["GIATRI"].ToString();
                    FormHISSMS.arrayThamSo[int.Parse(dt.Rows[5]["ID"].ToString()) - 1] = dt.Rows[5]["GIATRI"].ToString();
                    FormHISSMS.arrayThamSo[int.Parse(dt.Rows[6]["ID"].ToString()) - 1] = dt.Rows[6]["GIATRI"].ToString();
                    FormHISSMS.arrayThamSo[int.Parse(dt.Rows[7]["ID"].ToString()) - 1] = dt.Rows[7]["GIATRI"].ToString();
                    FormHISSMS.arrayThamSo[int.Parse(dt.Rows[8]["ID"].ToString()) - 1] = dt.Rows[8]["GIATRI"].ToString();
                    FormHISSMS.arrayThamSo[int.Parse(dt.Rows[9]["ID"].ToString()) - 1] = dt.Rows[9]["GIATRI"].ToString();
                    FormHISSMS.arrayThamSo[int.Parse(dt.Rows[10]["ID"].ToString()) - 1] = dt.Rows[10]["GIATRI"].ToString();
                    FormHISSMS.arrayThamSo[int.Parse(dt.Rows[11]["ID"].ToString()) - 1] = dt.Rows[11]["GIATRI"].ToString();
                    FormHISSMS.arrayThamSo[int.Parse(dt.Rows[12]["ID"].ToString()) - 1] = dt.Rows[12]["GIATRI"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
