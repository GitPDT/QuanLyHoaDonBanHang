using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

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
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }
        private void Refresh_HD()
        {
            txtMaHD.Text = txtTenKH.Text = txtDiaChi.Text = txtSdt.Text = txtDvt.Text = cmbTenHH.Text = txtMaHH.Text = "";
            numChietKhau.Value = numDaTra.Value = numSoLg.Value =  0;
            txtConNo.Text = txtThanhTien.Text = txtDonGia.Text = "0";
            ShowHoaDon();
        }
        //Them hoa don
        private void BtnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string maHD = txtMaHD.Text;
                string ngay = (txtNgay.Value.ToString());
                string tenKH = txtTenKH.Text.ToString();
                string diaChi = txtDiaChi.Text.ToString();
                string sdt = txtSdt.Text.ToString();
                string maHH = txtMaHH.Text;
                string tenHH = cmbTenHH.Text;

                int soLuong = int.Parse(numSoLg.Value.ToString());
                string dvt = txtDvt.Text.ToString();
                int donGia = int.Parse(txtDonGia.Text);
                int chietKhau = int.Parse(numChietKhau.Text);
                int thanhTien = int.Parse(txtThanhTien.Text);
                int daTra = int.Parse(numDaTra.Text);
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
        private void txtDonGia_TextChanged(object sender, EventArgs e)
        {
           
        }
        //event value changed
        private void NumSoLg_ValueChanged(object sender, EventArgs e)
        {
            int a = int.Parse(txtDonGia.Text) * int.Parse(numSoLg.Value.ToString());
            int b = a - (a * int.Parse(numChietKhau.Text) / 100);
            txtThanhTien.Text = b.ToString();
        }
        //event 
        private void NumSoLg_Enter(object sender, EventArgs e)
        {
            int a = int.Parse(txtDonGia.Text) * int.Parse(numSoLg.Value.ToString());
            int b = a - (a * int.Parse(numChietKhau.Text) / 100);
            txtThanhTien.Text = b.ToString();
        }

        private void NumDaTra_ValueChanged(object sender, EventArgs e)
        {

            //
            int a = int.Parse(txtThanhTien.Text) - int.Parse(numDaTra.Text);
            txtConNo.Text = a.ToString();
        }
        //event
        private void NumDaTra_Enter(object sender, EventArgs e)
        {
            int a = int.Parse(txtThanhTien.Text) - int.Parse(numDaTra.Text);
            txtConNo.Text = a.ToString();
        }

        private void NumChietKhau_ValueChanged(object sender, EventArgs e)
        {
            int a = int.Parse(txtDonGia.Text) * int.Parse(numSoLg.Value.ToString());
            int b = a - (a * int.Parse(numChietKhau.Text) / 100);
            txtThanhTien.Text = b.ToString();
        }

        private void NumChietKhau_Enter(object sender, EventArgs e)
        {
            int a = int.Parse(txtDonGia.Text) * int.Parse(numSoLg.Value.ToString());
            int b = a - (a * int.Parse(numChietKhau.Text) / 100);
            txtThanhTien.Text = b.ToString();
        }

        private void CmbTenHH_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbTenHH.Text)
            {
                case "Thép":
                    txtMaHH.Text = "HH1";
                    txtDonGia.Text = "11000";
                    txtDvt.Text = "Kg";
                    break;
                case "Đinh vít 6mm":
                    txtMaHH.Text = "HH2";
                    txtDonGia.Text = "20000";
                    txtDvt.Text = "Kg";
                    break;
                case "Đinh vít 12mm":
                    txtMaHH.Text = "HH3";
                    txtDonGia.Text = "25000";
                    txtDvt.Text = "Kg";
                    break;
                case "Xi măng":
                    txtMaHH.Text = "HH4";
                    txtDonGia.Text = "80000";
                    txtDvt.Text = "Bao";
                    break;
                case "Gạch ốp tường":
                    txtMaHH.Text = "HH5";
                    txtDonGia.Text = "15000";
                    txtDvt.Text = "m2";
                    break;
                case "Gạch ốp sàn":
                    txtMaHH.Text = "HH6";
                    txtDonGia.Text = "17000";
                    txtDvt.Text = "m2";
                    break;
                case "Sắt":
                    txtMaHH.Text = "HH7";
                    txtDonGia.Text = "11000";
                    txtDvt.Text = "Kg";
                    break;
                case "Kẽm":
                    txtMaHH.Text = "HH8";
                    txtDonGia.Text = "16000";
                    txtDvt.Text = "Cuộn";
                    break;
            }
        }

        private void numChietKhau_MouseUp(object sender, MouseEventArgs e)
        {
            int a = int.Parse(txtThanhTien.Text) - int.Parse(numDaTra.Text);
            txtConNo.Text = a.ToString();
        }

        private void dgvHoaDon_DoubleClick(object sender, EventArgs e)
        {
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            if (dgvHoaDon.CurrentRow.Index != -1)
            {
                txtMaHD.Text = dgvHoaDon.CurrentRow.Cells[0].Value.ToString();
                txtNgay.Text = dgvHoaDon.CurrentRow.Cells[1].Value.ToString();
                txtTenKH.Text = dgvHoaDon.CurrentRow.Cells[2].Value.ToString();
                txtDiaChi.Text = dgvHoaDon.CurrentRow.Cells[3].Value.ToString();
                txtSdt.Text = dgvHoaDon.CurrentRow.Cells[4].Value.ToString();
                txtMaHH.Text = dgvHoaDon.CurrentRow.Cells[5].Value.ToString();
                cmbTenHH.Text = dgvHoaDon.CurrentRow.Cells[6].Value.ToString();
                numSoLg.Text = dgvHoaDon.CurrentRow.Cells[7].Value.ToString();
                txtDvt.Text = dgvHoaDon.CurrentRow.Cells[8].Value.ToString();
                txtDonGia.Text = dgvHoaDon.CurrentRow.Cells[9].Value.ToString();
                numChietKhau.Text = dgvHoaDon.CurrentRow.Cells[10].Value.ToString();
                txtThanhTien.Text = dgvHoaDon.CurrentRow.Cells[11].Value.ToString();
                numDaTra.Text = dgvHoaDon.CurrentRow.Cells[12].Value.ToString();
                txtConNo.Text = dgvHoaDon.CurrentRow.Cells[13].Value.ToString();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa?", "Cảnh báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    string id = txtMaHD.Text;
                    bool kq = HoaDonBUS.DeleteHoaDon(id);
                    if (kq)
                    {
                        ShowHoaDon();
                        
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Refresh_HD();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                string maHD = txtMaHD.Text;
                string ngay = (txtNgay.Value.ToString());
                string tenKH = txtTenKH.Text.ToString();
                string diaChi = txtDiaChi.Text.ToString();
                string sdt = txtSdt.Text.ToString();
                string maHH = txtMaHH.Text;
                string tenHH = cmbTenHH.Text;

                int soLuong = int.Parse(numSoLg.Value.ToString());
                string dvt = txtDvt.Text.ToString();
                int donGia = int.Parse(txtDonGia.Text);
                int chietKhau = int.Parse(numChietKhau.Text);
                int thanhTien = int.Parse(txtThanhTien.Text);
                int daTra = int.Parse(numDaTra.Text);
                int conNo = int.Parse(txtConNo.Text);
                HoaDon hd = new HoaDon(maHD, ngay, tenKH, diaChi, sdt, maHH, tenHH, soLuong, dvt, donGia, chietKhau, thanhTien, daTra, conNo);
                bool kq = HoaDonBUS.UpdateHoaDon(hd);
                if (kq)
                {
                    MessageBox.Show("Sửa thành công!");
                }
                else
                    MessageBox.Show("Sửa thất bại!");
                ShowHoaDon();
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string valueSearch = txtTimKiem.Text;
            
            if (rdoMa.Checked)
            {
                dgvHoaDon.DataSource = HoaDonBUS.SearchByID(valueSearch);
            }
            if (rdoNgay.Checked)
            {
                dgvHoaDon.DataSource = HoaDonBUS.SearchByDate(valueSearch);
            }
            if (rdoTen.Checked)
            {
                dgvHoaDon.DataSource = HoaDonBUS.SearchByName(valueSearch);
            }
            if (rdoSDT.Checked)
            {
                dgvHoaDon.DataSource = HoaDonBUS.SearchByPhone(valueSearch);
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            //
        }

        private void numDaTra_MouseUp(object sender, MouseEventArgs e)
        {
            int a = int.Parse(txtThanhTien.Text) - int.Parse(numDaTra.Text);
            txtConNo.Text = a.ToString();
        }

        private void numDaTra_MouseDown(object sender, MouseEventArgs e)
        {
            int a = int.Parse(txtThanhTien.Text) - int.Parse(numDaTra.Text);
            txtConNo.Text = a.ToString();
        }
    }
}
