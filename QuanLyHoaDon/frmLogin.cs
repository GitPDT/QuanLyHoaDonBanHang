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
    public partial class FrmLogin : Form
    {
        LoginBUS bus = new LoginBUS();
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string user, pass;
            user = txtTK.Text.Trim();
            pass = txtMK.Text.Trim();
            bool b = false;
            try
            {
                b = bus.Login(user, pass);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi đăng nhập!\n" + ex.Message, "Login");
            }

            if (b)
            {
                this.Hide();
                FrmMain frm = new FrmMain();
                frm.ShowDialog();
            }
            else
            {
                if (txtMK.Text == "" && txtTK.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập tài khoản và mật khẩu!");
                }
                else if (txtTK.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập tên tài khoản!");
                }
                else if (txtMK.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập mật khẩu!");
                }
                else
                {
                    DialogResult result = MessageBox.Show("Tài khoản hoặc Mật khẩu không đúng!", "Đăng nhập", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    if (result == DialogResult.Cancel)
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
}
