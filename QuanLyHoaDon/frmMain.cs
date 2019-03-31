using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyHoaDon
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Show();
            this.Enabled = false;
            frmLogin frm = new frmLogin();
            DialogResult result = frm.ShowDialog();

            if (result == DialogResult.OK)
            {
                this.Enabled = true;
                lbDangNhap.Text = "Đăng nhập thành công!";
            }
            else
            {
                Application.Exit();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmTaoHoaDon frm = new frmTaoHoaDon();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmDanhSachHoaDon frm = new frmDanhSachHoaDon();
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmKhachHang frm = new frmKhachHang();
            frm.Show();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            lbDangNhap.Text = "";
            frmLogin frm = new frmLogin();
            frm.Show();
        }
    }
}
