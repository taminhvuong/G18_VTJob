using BTL_VTJob.Models;
using Microsoft.EntityFrameworkCore;

namespace BTL_VTJob.Data
{
    public class dbContext : DbContext
    {
        public dbContext(DbContextOptions<dbContext> options)
            : base(options)
        {
        }

        public DbSet<NguoiDung> Nguoidung
        { get; set; } = default!;
        public DbSet<DoanhNghiep> DoanhNghiep
        { get; set; } = default!;
        public DbSet<BaiTuyenDung> BaiTuyenDung
        { get; set; } = default!;
        public DbSet<CVUngTuyen> CVUngTuyen
        { get; set; } = default!;
        public DbSet<LoaiJob> LoaiJob
        { get; set; } = default!;
    }
}
