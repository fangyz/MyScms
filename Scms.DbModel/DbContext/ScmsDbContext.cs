using Microsoft.EntityFrameworkCore;

namespace Scms.DbModel
{
    public class ScmsDbContext : DbContext
    {
        public ScmsDbContext(DbContextOptions<ScmsDbContext> options) : base(options) { }


        public DbSet<Base_Bom> Base_Bom { get; set; }
        public DbSet<Base_ItemInfo> Base_ItemInfo { get; set; }

        //处理乐观并发
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Base_ItemInfo>().Property(s => s.RowVersion).IsConcurrencyToken();
        }

    }
}
