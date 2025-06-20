using Microsoft.EntityFrameworkCore;
using CarInsurance.Models;


namespace CarInsurance.Data
{
    public class InsuranceDbContext :DbContext
    {
        public InsuranceDbContext(DbContextOptions<InsuranceDbContext> options) : base(options){}
        public DbSet<Insuree> Insurees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Insuree>(entity =>
            {
                entity.Property(e => e.DateOfBirth)
                      .HasColumnType("date"); // 👈 This forces SQL to use DATE, not DATETIME2
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
