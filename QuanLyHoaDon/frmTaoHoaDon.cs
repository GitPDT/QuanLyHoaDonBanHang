using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;

namespace QuanLyHoaDon
{
    public partial class frmTaoHoaDon : Form
    {
        DataTable dt = new DataTable();
        HoaDon_BUS HoaDonBUS = new HoaDon_BUS();
        public frmTaoHoaDon()
        {
            InitializeComponent();
        }
        public void ShowHoaDon()
        {
            dt = HoaDonBUS.ShowHoaDon();
            dgvHoaDon.DataSource = dt;
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void frmTaoHoaDon_Load(object sender, EventArgs e)
        {
            txtMaHD.Select();
            ShowHoaDon();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btKhoiTao_Click(object sender, EventArgs e)
        {

        }

        private void txtThanhTien_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
