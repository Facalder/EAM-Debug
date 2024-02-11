using Microsoft.EntityFrameworkCore;
using EAM.Shared.Models;
using EAM.Shared.StoredProcedures;

namespace EAM.Data
{
#pragma warning disable CS0436 // Type conflicts with imported type
    public partial class EAMDbContext : DbContext
    {
        public EAMDbContext()
        {
        }
        
        public EAMDbContext(DbContextOptions<EAMDbContext> options) 
            : base(options)
        {
        }

        public DbSet<xpAsset_Tree>? xpAsset_Tree { get; set; }
        public DbSet<xpAsset_Group>? xpAsset_Group { get; set; }
        public DbSet<xpAsset_Category>? xpAsset_Category { get; set; }
        public DbSet<xpAsset_Classification>? xpAsset_Classification { get; set; }
        public DbSet<xpAsset_Brand>? xpAsset_Brand { get; set; }
        public DbSet<xpAsset>? xpAsset { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //string connectionString = Configuration.GetConnectionString("DefaultConnection");
                //optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<xpAsset_Tree>().HasNoKey();
            modelBuilder.Entity<xpAsset_Group>().HasNoKey();
            modelBuilder.Entity<xpAsset_Category>().HasNoKey();
            modelBuilder.Entity<xpAsset_Classification>().HasNoKey();
            modelBuilder.Entity<xpAsset_Brand>().HasNoKey();
            modelBuilder.Entity<xpAsset>().HasNoKey();
            modelBuilder.Entity<xpAsset>().Property(e => e.Price).HasPrecision(12, 0);
            modelBuilder.Entity<xpAsset>().Property(e => e.Resale_Price).HasPrecision(12, 0);

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
#pragma warning restore CS0436 // Type conflicts with imported type
}
