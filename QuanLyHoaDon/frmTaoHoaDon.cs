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
    public partial class frmTaoHoaDon : Form
    {
        List<HoaDon> dt = new List<HoaDon>();
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
        private void FrmTaoHoaDon_Load(object sender, EventArgs e)
        {
            txtMaHD.Select();
            ShowHoaDon();
        }
        private void BtnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string maHD = txtMaHD.Text;
                DateTime ngay = DateTime.Parse(txtNgay.Value.ToString());
                string tenKH = txtTenKH.Text.ToString();
                string diaChi = txtDiaChi.Text.ToString();
                string sdt = txtSdt.Text.ToString();
                string maHH = txtMaHH.Text;
                string tenHH = cmbTenHH.Text;

                int soLuong = int.Parse(txtSoLuong.Text);
                string dvt = txtDvt.Text.ToString();
                int donGia = int.Parse(txtDonGia.Text);
                int chietKhau = int.Parse(txtChietKhau.Text);
                int thanhTien = int.Parse(txtThanhTien.Text);
                int daTra = int.Parse(txtDaTra.Text);
                int conNo = int.Parse(txtConNo.Text);
                HoaDon hd = new HoaDon(maHD,ngay,tenKH,diaChi,sdt,maHH,tenHH,soLuong,dvt,donGia,chietKhau,thanhTien,daTra,conNo);
                bool kq = HoaDonBUS.AddHoaDon(hd);
                if (kq)
                {
                    MessageBox.Show("Thêm thành công!");
                }
                else
                    MessageBox.Show("Thêm thất bại!");
                ShowHoaDon();
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        private void txtThanhTien_TextChanged(object sender, EventArgs e)
        {
            //
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            
            int a = int.Parse(txtDonGia.Text) * int.Parse(txtSoLuong.Text);
            int b = a - (a * int.Parse(txtChietKhau.Text) / 100);
            txtThanhTien.Text = b.ToString();
        }

        private void txtDaTra_TextChanged(object sender, EventArgs e)
        {
            
            if(txtDaTra.Text =="")
            {
                txtDaTra.Text = "";
            }
            int a = int.Parse(txtThanhTien.Text) - int.Parse(txtDaTra.Text);
            txtConNo.Text = a.ToString();
        }

        private void txtChietKhau_TextChanged(object sender, EventArgs e)
        {
            int a = int.Parse(txtDonGia.Text) * int.Parse(txtSoLuong.Text);
            int b = a - (a * int.Parse(txtChietKhau.Text) / 100);
            txtThanhTien.Text = b.ToString();
        }
    }
}
