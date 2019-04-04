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
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }
        private void Button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            frmTaoHoaDon frm = new frmTaoHoaDon();
            frm.Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            frmDanhSachHoaDon frm = new frmDanhSachHoaDon();
            frm.Show();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            FrmKhachHang frm = new FrmKhachHang();
            frm.Show();
        }

        private void BtnDangXuat_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmLogin frm = new FrmLogin();
            frm.ShowDialog();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            lbDangNhap.Text = "Đăng nhập thành công!";
        }

        private void BtnDoanhThu_Click(object sender, EventArgs e)
        {

        }
    }
}
