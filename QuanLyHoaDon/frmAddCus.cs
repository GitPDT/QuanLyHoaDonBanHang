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
using System.Data.SqlClient;
namespace QuanLyHoaDon
{
    public partial class frmAddCus : Form
    {
        private string gender;
        List<KhachHang> listCus = new List<KhachHang>();
        KhachHang_BUS khachHangBus = new KhachHang_BUS();
        frmKhachHang obj = (frmKhachHang)Application.OpenForms["frmKhachHang"];
     
        public frmAddCus()
        {
            InitializeComponent();
           
        }

        
        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                string maKh = txtMaKH.Text;
                string tenKH = txtTenKH.Text;
                string diaChiKH = txtDiaChi.Text;
                string sdtKH = txtSdt.Text;
                KhachHang cus = new KhachHang(maKh, tenKH, diaChiKH, gender, sdtKH);
                bool result = khachHangBus.AddCustomerBUS(cus);
                
                if (result == true)
                {
                    this.Close();
                }
                else
                    MessageBox.Show("Thêm thất bại!");

                obj.load();
                
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
