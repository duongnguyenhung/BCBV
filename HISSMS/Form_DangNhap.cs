using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HISSMS
{
    public partial class Form_DangNhap : Form
    {
        public Form_DangNhap()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (textEdit1.Text == "bhyt" && textEdit2.Text == "bhyt")
            {
                Program.Rsltt = DialogResult.OK;
                Program.PQ = "bhyt";
                this.Close();
            }
            else if (textEdit1.Text == "dnhung" && textEdit2.Text == "sM!4@8Ea")
            {
                Program.Rsltt = DialogResult.OK;
                Program.PQ = "admin";
                this.Close();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập và mật khẩu không tồn tại!");
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form_DangNhap_Load(object sender, EventArgs e)
        {
            //
        }
    }
}
