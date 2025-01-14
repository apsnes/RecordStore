using Microsoft.EntityFrameworkCore;
using RecordStore.Entities;

namespace RecordStore
{
    public class RecordStoreDbContext : DbContext
    {
        public DbSet<Record> Records { get; set; }
        public RecordStoreDbContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}
