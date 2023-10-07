namespace QuanLyBanHang.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietPhieuXuat")]
    public partial class ChiTietPhieuXuat
    {
        [Key]
        [StringLength(50)]
        public string MaCTPX { get; set; }

        [StringLength(50)]
        public string MaPX { get; set; }

        [StringLength(50)]
        public string MaHang { get; set; }

        [StringLength(50)]
        public string MaNV { get; set; }

        [StringLength(50)]
        public string Size { get; set; }

        [StringLength(50)]
        public string SoLuongXuat { get; set; }

        [StringLength(50)]
        public string DonGiaXuat { get; set; }

        public virtual Hang Hang { get; set; }

        public virtual NhanVien NhanVien { get; set; }

        public virtual PhieuXuat PhieuXuat { get; set; }
    }
}
