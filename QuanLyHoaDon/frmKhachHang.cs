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
        private string gender;
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
            if (dgvKhachHang.Columns[e.ColumnIndex].Name =="delete")
            {
                try
                {
                    bool num = customerBUS.Delete(dgvKhachHang.CurrentRow.Cells["id"].Value.ToString());
                    load();     
                }
                catch (SqlException ex)
                {

                    MessageBox.Show("Loi" + ex.Message);
                }
            }
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            load();
        }

        private void btnAddCus_Click(object sender, EventArgs e)
        {
            try
            {
                string maKh = txtMaKH.Text;
                string tenKH = txtTenKH.Text;
                string diaChiKH = txtDiaChi.Text;
                string sdtKH = txtSDT.Text;
                KhachHang cus = new KhachHang(maKh, tenKH, diaChiKH, gender, sdtKH);
                bool result = customerBUS.AddCustomerBUS(cus);

                if (result == true)
                {
                    MessageBox.Show("Thêm thành công!");
                }
                else
                    MessageBox.Show("Thêm thất bại!");
                load();
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        private void rdoNam_CheckedChanged(object sender, EventArgs e)
        {
            gender = "Nam";
        }

        private void rdoNu_CheckedChanged(object sender, EventArgs e)
        {
            gender = "Nữ";
        }
    }
}
