using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BUS;
using System.Data.SqlClient;

namespace QuanLyHoaDon
{
    public partial class frmKhachHang : Form
    {
        List<KhachHang> listCus = new List<KhachHang>();
        KhachHang_BUS customerBUS = new KhachHang_BUS();
        public frmKhachHang()
        {
            InitializeComponent();
        }
        public void load()
        {
            listCus = customerBUS.ShowKhachHang();
            dgvKhachHang.DataSource = listCus;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            load();
        }

        private void btnAddCus_Click(object sender, EventArgs e)
        {
            frmAddCus frm = new frmAddCus();
            frm.ShowDialog();
        }
       
    }
}
