using Microsoft.EntityFrameworkCore;
using RecordStore.Entities;

namespace RecordStore
{
    public class RecordStoreDbContext : DbContext
    {
        public DbSet<Record> Records { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
            {
                optionsBuilder.UseInMemoryDatabase("RecordStore");
            }
            else
            {
                optionsBuilder.UseSqlServer("DefaultConnection");
            }
        }
    }
}
