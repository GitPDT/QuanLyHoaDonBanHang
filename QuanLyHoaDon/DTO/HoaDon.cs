using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HoaDon
    {
        public string MaHD { get; set; }
        public string Ngay { get; set; }
       
        public string TenKH { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }
        public string MaHH { get; set; }
        public string TenHH { get; set; }
        public int SoLuong { get; set; }
        public string DonViTinh { get; set; }
        public int DonGia { get; set; }
        public int ChietKhau { get; set; }
        public int ThanhTien { get; set; }
        public int DaTra { get; set; }
        public int ConNo { get; set; }
        public HoaDon(string maHD, string ngay, string tenKH, string diaChi, string sdt,string maHH, string tenHH,
           int soLuong, string dvt, int donGia, int chietKhau, int thanhTien, int daTra, int conNo )
        {
            this.MaHD = maHD;
            this.Ngay = ngay;
            
            this.TenKH = tenKH;
            this.DiaChi = diaChi;
            this.SDT = sdt;
            this.MaHH = maHH;
            this.TenHH = tenHH;
            this.SoLuong = soLuong;
            this.DonViTinh = dvt;
            this.DonGia = donGia;
            this.ChietKhau = chietKhau;
            this.ThanhTien = thanhTien;
            this.DaTra = daTra;
            this.ConNo = conNo;
        }
    }
}
