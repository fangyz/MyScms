using Microsoft.EntityFrameworkCore;
using Scms.DbModel;

namespace Scms.CoreService
{
    public class ScmsDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=FYZ; Initial Catalog=SCMS; User Id=sa; Password=123;");
        }

        public DbSet<Base_Bom> Base_Bom { get; set; }
        public DbSet<Base_ItemInfo> Base_ItemInfo { get; set; }

        //处理乐观并发
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Base_ItemInfo>().Property(s => s.RowVersion).IsConcurrencyToken();
        }

    }
}
