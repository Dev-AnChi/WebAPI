using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class NhanVien
    {
        public string MaNV { get; set; }
        public string HoNV { get; set; }
        public string TenNV { get; set; }
        public bool GioiTinh { get; set; }
        public string NgaySinh { get; set; }
        public decimal Luong { get; set; }
        public string AnhNV { get; set; }
        public string DiaChi { get; set; }
        public string MaPB { get; set; }
    }
}