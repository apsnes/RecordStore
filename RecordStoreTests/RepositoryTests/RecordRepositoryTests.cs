using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using RecordStore;
using RecordStore.Entities;
using RecordStore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RecordStoreTests.RepositoryTests
{
    public class RecordRepositoryTests
    {
        private RecordRepository _recordRepository;
        private RecordStoreDbContext _db;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<RecordStoreDbContext>()
                  .UseInMemoryDatabase("TestDb")
                  .Options;
            _db = new RecordStoreDbContext(options);
            _recordRepository = new RecordRepository(_db);
        }
        [Test]
        public void Test_GetAllRecords_EmptyDB_Returns_False()
        {
            //Arrange
            _db.Records.Add(new Record { Id = 1, Artist = "Artist1", Title = "Title1", ReleaseYear = 10, Genre = "rest" });
            _db.SaveChanges();

            //Act
            var result = _recordRepository.GetAllRecords();

            //Assert
            result.Item1.Should().BeTrue();
        }
    }
}
