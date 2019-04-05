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
    public partial class FrmKhachHang : Form
    {
        
        private string gender;
        List<KhachHang> listCus = new List<KhachHang>();
        KhachHang_BUS customerBUS = new KhachHang_BUS();
        public FrmKhachHang()
        {
            InitializeComponent();
        }
        private void LoadCus()
        {
            listCus = customerBUS.ShowKhachHang();
            dgvKhachHang.DataSource = listCus;
        }
        private void BtnAddCus_Click(object sender, EventArgs e)
        {
            try
            {
                string maKh = txtMaKH.Text;
                string tenKH = txtTenKH.Text;
                string diaChiKH = txtDiaChi.Text;
                string sdtKH = txtSDT.Text;
                if (rdoNam.Checked == true)
                {
                    gender = "Nam";
                }
                else
                    gender = "Nữ";
                KhachHang cus = new KhachHang(maKh, tenKH, diaChiKH, gender, sdtKH);
                bool result = customerBUS.AddCustomerBUS(cus);

                if (result == true)
                {
                    MessageBox.Show("Thêm thành công!");
                }
                else
                    MessageBox.Show("Thêm thất bại!");
                LoadCus();
                Clear();
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        private void Clear()
        {
            txtMaKH.Text = txtTenKH.Text = txtDiaChi.Text = txtSDT.Text = "";
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có muốn xóa?","Cảnh báo!",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.Yes)
            {
                try
                {
                    string id = txtMaKH.Text;
                    bool kq = customerBUS.Delete(id);
                    if (kq)
                    {
                        LoadCus();
                        Clear();
                    }
                    else
                        MessageBox.Show("Xóa thất bại!");
                    
                }
                catch (SqlException ex)
                {

                    throw ex;
                }
            }
            
        }

        private void DgvKhachHang_DoubleClick(object sender, EventArgs e)
        {
            if (dgvKhachHang.CurrentRow.Index != -1)
            {
                txtMaKH.Text = dgvKhachHang.CurrentRow.Cells[0].Value.ToString();
                txtTenKH.Text = dgvKhachHang.CurrentRow.Cells[1].Value.ToString();
                txtDiaChi.Text = dgvKhachHang.CurrentRow.Cells[2].Value.ToString();
                txtSDT.Text = dgvKhachHang.CurrentRow.Cells[4].Value.ToString();
                if (dgvKhachHang.CurrentRow.Cells[3].Value.ToString() == "Nam")
                {
                    rdoNam.Checked = true;
                }
                else
                    rdoNu.Checked = true;
            }
            btnDelete.Enabled = true;
            btnEdit.Enabled = true;
        }

        private void FrmKhachHang_Load_1(object sender, EventArgs e)
        {
            LoadCus();
            Clear();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                string maKh = txtMaKH.Text;
                string tenKH = txtTenKH.Text;
                string diaChiKH = txtDiaChi.Text;
                string sdtKH = txtSDT.Text;
                if (rdoNam.Checked == true)
                {
                    gender = "Nam";
                }
                else
                    gender = "Nữ";
                KhachHang cus = new KhachHang(maKh, tenKH, diaChiKH, gender, sdtKH);
                bool result = customerBUS.UpdateCustomer(cus);

                if (result == true)
                {
                    MessageBox.Show("Sửa thành công!");
                }
                else
                    MessageBox.Show("Không thể sửa mã khách hàng!");
                LoadCus();
                Clear();
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string valueToSearch = txtTimKiem.Text;
            if (rdoID.Checked)
            {
                dgvKhachHang.DataSource = customerBUS.SearchByID(valueToSearch);
            }
            else
            {
                dgvKhachHang.DataSource = customerBUS.SearchByName(valueToSearch);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtTimKiem.Text = "";
            LoadCus();
        }
    }
}
