using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NhaSachHuflit.Models
{
    public class CSDL : DbContext
    {
        public CSDL()
            : base()
        {
            SqlConnectionStringBuilder sqlb = new SqlConnectionStringBuilder();
            sqlb.DataSource = "ADMIN\\SQLEXPRESS";
            sqlb.InitialCatalog = "NhaSachHuflit1";
            sqlb.IntegratedSecurity = true;
            this.Database.Connection.ConnectionString = sqlb.ConnectionString;
        }
        public DbSet<Sach> Sach { get; set; }
        public DbSet<DanhMuc> DanhMuc { get; set; }
        public DbSet<CongTyPhatHanh> CongTyPhatHanh { get; set; }
        public DbSet<NhaXuatBan> NhaXuatBan { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<SachBanChay> SachBanChay { get; set; }
        public DbSet<TacGia> TacGia { get; set; }
        public DbSet<PhanHoi> PhanHoi { get; set; }
    }

    public class Sach
    {
        [Key]
        public int id { get; set; }
        public int gia { get; set; }
        public string tensp { get; set; }
        public string hinh { get; set; }
        public string mota { get; set; }
        public string ttc_kichthuoc { get; set; }
        public string ttc_ngayxuatban { get; set; }
        public string ttc_loaibia { get; set; }
        public string ttc_sotrang { get; set; }
        public string ttc_nhaxuatban { get; set; }
        public string motasanpham { get; set; }
        public Nullable<int> MaDM { get; set; }
        public virtual DanhMuc DanhMuc { get; set; }
        public virtual CongTyPhatHanh CongTyPhatHanh { get; set; }
        public Nullable<int> MaNXB { get; set; }
        public virtual NhaXuatBan NhaXuatBan { get; set; }
        public virtual IEnumerable<OrderDetail> OrderDetail { get; set; }
        public virtual TacGia TacGia { get; set; }
    }
    public class SachBanChay
    {
        [Key]
        public int MaSach { get; set; }
        public int GiaBan { get; set; }
        public string TenSach { get; set; }
        public string HinhAnh { get; set; }
        public string MoTa { get; set; }
        public string ttc_kichthuoc { get; set; }
        public string ttc_ngayxuatban { get; set; }
        public string ttc_loaibia { get; set; }
        public string ttc_sotrang { get; set; }
        public string ttc_nhaxuatban { get; set; }
        public string motasanpham { get; set; }
        public Nullable<int> MaDM { get; set; }
        public virtual DanhMuc DanhMuc { get; set; }
        public virtual CongTyPhatHanh CongTyPhatHanh { get; set; }
        public Nullable<int> MaNXB { get; set; }
        public virtual NhaXuatBan NhaXuatBan { get; set; }
        public virtual IEnumerable<OrderDetail> OrderDetail { get; set; }
    }
    public class DanhMuc
    {
        [Key]
        public int MaDM { get; set; }
        public string TenDanhMuc { get; set; }
        public virtual IEnumerable<Sach> Sach { get; set; }
        public virtual IEnumerable<SachBanChay> SachBanChay { get; set; }
    }
    public class CongTyPhatHanh
    {
        [Key]
        public int MaCT { get; set; }
        public string TenCT { get; set; }
        public int SoLuongSach { get; set; }
        public virtual IEnumerable<Sach> Sach { get; set; }
        public virtual IEnumerable<SachBanChay> SachBanChay { get; set; }
    }
    public class NhaXuatBan
    {
        [Key]
        public int MaNXB { get; set; }
        public string TenNXB { get; set; }
        public int SoLuongSach { get; set; }
        public virtual IEnumerable<Sach> Sach { get; set; }
        public virtual IEnumerable<SachBanChay> SachBanChay { get; set; }
    }

    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        public string OrderName { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerAddress { get; set; }
        public virtual IEnumerable<OrderDetail> OrderDetail { get; set; }
    }

    public class OrderDetail
    {
        public Nullable<int> OrderID { get; set; }
        public virtual Order Order { get; set; }
        public Nullable<int> id { get; set; }
        public virtual Sach Sach { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public string Status { get; set; }

    }
    public class TacGia
    {
        [Key]
        public int MaTG { get; set; }
        public string Hinh { get; set; }
        public string TenTG { get; set; }
        public string TieuSu { get; set; }
        public string GioiTinh { get; set; }
        public virtual IEnumerable<Sach> Sach { get; set; }
    }
    public class PhanHoi
    {
        [Key]
        public int MaPhanHoi { get; set; }
        public string HoTen { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }
        public string NoiDung { get; set; }

    }
}