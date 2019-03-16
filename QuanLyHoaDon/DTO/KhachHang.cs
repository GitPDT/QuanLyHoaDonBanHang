using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{

    public class KhachHang
    {
        public string MaKH { get; set; }
        public string TenKH { get; set; }
        public string DiaChi { get; set; }
        public string GioiTinh { get; set; }
        public string SDT { get; set; }
        public KhachHang(string id, string name, string address, string sex, string phone)
        {
            this.MaKH = id;
            this.TenKH = name;
            this.DiaChi = address;
            this.GioiTinh = sex;
            this.SDT = phone;
        }
    }
}
