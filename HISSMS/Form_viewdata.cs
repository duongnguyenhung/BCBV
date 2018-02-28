using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using Oracle.DataAccess.Client;


namespace HISSMS
{
    public partial class Form_viewdata : Form
    {
        public Form_viewdata()
        {
            InitializeComponent();
        }

        private void Form_viewdata_Load(object sender, EventArgs e)
        {
           //
        }

        public void load_data(DataTable data_bh)
        {
            gridControl1.DataSource = data_bh;
            //dataGridView_table.DataSource = data_bh;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            xtraSaveFileDialog1.ShowDialog();
            xtraSaveFileDialog1.DefaultExt = "xls";
            if (xtraSaveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                gridControl1.ExportToXls(xtraSaveFileDialog1.FileName);
                //   simpleButton_xulyfile.Enabled = true;
            }
            
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
