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
        public DateTime Ngay { get; set; }
        public string MaKH { get; set; }
        public string TenKH { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }
        public string TenHH { get; set; }
        public int SoLuong { get; set; }
        public string DonViTinh { get; set; }
        public float DonGia { get; set; }
        public float ChietKhau { get; set; }
        public float ThanhTien { get; set; }
        public float DaTra { get; set; }
        public float ConNo { get; set; }
        public HoaDon(string maHD, DateTime ngay, string maKH, string tenKH, string diaChi, string sdt, string tenHH,
           int soLuong, string dvt, float donGia, float chietKhau, float thanhTien, float daTra, float conNo )
        {
            this.MaHD = maHD;
            this.Ngay = ngay;
            this.MaKH = maKH;
            this.TenKH = tenKH;
            this.DiaChi = diaChi;
            this.SDT = sdt;
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
