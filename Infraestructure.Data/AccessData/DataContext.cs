using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Data.AccessData
{
    public class DataContext : DbContext
    {
        public DataContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tbl_Person>()
                .HasIndex(b => b.Email)
                .IsUnique();
        }
    }
}
