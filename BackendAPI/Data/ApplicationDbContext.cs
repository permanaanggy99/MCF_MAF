namespace BackendAPI.Data
{
    using Microsoft.EntityFrameworkCore;
    using BackendAPI.Models;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<TrBpkb> TrBpkbs { get; set; }
        public DbSet<MsStorageLocation> MsStorageLocations { get; set; }
        public DbSet<MsUser> MsUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TrBpkb>()
                .HasKey(t => t.AgreementNumber);

            modelBuilder.Entity<MsStorageLocation>()
                .HasKey(m => m.LocationId);

            modelBuilder.Entity<TrBpkb>()
                .HasOne(t => t.Location)
                .WithMany(m => m.TrBpkbs)
                .HasForeignKey(t => t.LocationId);

            modelBuilder.Entity<MsUser>()
                .HasKey(u => u.UserId);
        }
    }

}
