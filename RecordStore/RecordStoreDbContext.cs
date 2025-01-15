using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using RecordStore.Entities;

namespace RecordStore
{
    public class RecordStoreDbContext : DbContext
    {
        public DbSet<Record> Records { get; set; }
        public RecordStoreDbContext(DbContextOptions<RecordStoreDbContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Record>().HasData(
            new Record
            {
                Id = 1,
                Title = "The Dark Side of the Moon",
                Artist = "Pink Floyd",
                Genre = "Progressive Rock",
                ReleaseYear = 1973
            },
            new Record
            {
                Id = 2,
                Title = "Abbey Road",
                Artist = "The Beatles",
                Genre = "Rock",
                ReleaseYear = 1969
            },
            new Record
            {
                Id = 3,
                Title = "Thriller",
                Artist = "Michael Jackson",
                Genre = "Pop",
                ReleaseYear = 1982
            });
        }
    }
}
