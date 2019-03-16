using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using BUS;

namespace QuanLyHoaDon
{
    public partial class frmLogin : Form
    {
        bool isLogin = false;
        LoginBUS bus = new LoginBUS();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user, pass;
            user = txtTK.Text.Trim();
            pass = txtMK.Text;
            bool b = false;
            try
            {
                b = bus.Login(user, pass);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Loi dang nhap\n" + ex.Message, "Login");
            }

            if (b)
            {
                isLogin = true;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
            {
                DialogResult result = MessageBox.Show("Sai TK hoac MK", "Dang nhap", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (result == System.Windows.Forms.DialogResult.Cancel)
                {
                    Application.Exit();
                }
                else
                {
                    txtMK.Text = "";
                    txtTK.Focus();
                }
            }
        }
    }
}
