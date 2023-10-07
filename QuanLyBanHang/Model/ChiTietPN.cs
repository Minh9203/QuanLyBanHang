namespace QuanLyBanHang.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietPN")]
    public partial class ChiTietPN
    {
        [Key]
        [StringLength(50)]
        public string MaCTPN { get; set; }

        [StringLength(50)]
        public string MaPN { get; set; }

        [StringLength(50)]
        public string MaHang { get; set; }

        [StringLength(50)]
        public string MaNV { get; set; }

        [StringLength(50)]
        public string Size { get; set; }

        public int? SoLuongNhap { get; set; }

        public double? DonGiaNhap { get; set; }

        public virtual Hang Hang { get; set; }

        public virtual NhanVien NhanVien { get; set; }

        public virtual PhieuNhap PhieuNhap { get; set; }
    }
}
