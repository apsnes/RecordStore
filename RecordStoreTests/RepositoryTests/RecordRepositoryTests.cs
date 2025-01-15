﻿using FluentAssertions;
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
            using (_db = new RecordStoreDbContext(options)) ;
            _recordRepository = new RecordRepository(_db);
        }
        [Test]
        public void Test_GetAllRecords_NoData_Returns_False()
        {
            //Arrange
            _db.Database.EnsureDeleted();

            //Act
            var result = _recordRepository.GetAllRecords();

            //Assert
            result.Item1.Should().BeFalse();
        }
        [Test]
        public void Test_GetAllRecords_ValidDb_Returns_True()
        {
            //Arrange
            _db.Database.EnsureDeleted();
            _db.Records.Add(new Record { Id = 1, Artist = "Artist1", Title = "Title1", ReleaseYear = 10, Genre = "rest" });
            _db.SaveChanges();

            //Act
            var result = _recordRepository.GetAllRecords();

            //Assert
            result.Item1.Should().BeTrue();
        }
        [Test]
        public void Test_GetRecordById_NoData_Returns_False()
        {
            //Arrange
            _db.Database.EnsureDeleted();

            //Act
            var result = _recordRepository.GetRecordById(1);

            //Assert
            result.Item1.Should().BeFalse();
        }
        [Test]
        public void Test_GetRecordById_ValidData_Returns_True()
        {
            //Arrange
            _db.Database.EnsureDeleted();
            _db.Records.Add(new Record { Id = 1, Artist = "Artist1", Title = "Title1", ReleaseYear = 10, Genre = "rest" });
            _db.SaveChanges();

            //Act
            var result = _recordRepository.GetRecordById(1);

            //Assert
            result.Item1.Should().BeTrue();
        }
        [Test]
        public void Test_AddRecord_ValidData_Changes_Correct_Number_Of_Rows()
        {
            //Arrange
            _db.Database.EnsureDeleted();
            var record = new Record { Id = 1, Artist = "Artist1", Title = "Title1", ReleaseYear = 10, Genre = "rest" };

            //Act
            var result = _recordRepository.AddRecord(record);
            _db.SaveChanges();

            //Assert
            result.Item1.Should().BeTrue();
        }
        [Test]
        public void Test_DeleteRecordById_ValidData_Changes_Correct_Number_Of_Rows()
        {
            //Arrange
            _db.Database.EnsureDeleted();
            var record = new Record { Id = 1, Artist = "Artist1", Title = "Title1", ReleaseYear = 10, Genre = "rest" };
            _db.Records.Add(record);
            _db.SaveChanges();

            //Act
            var result = _recordRepository.DeleteRecordById(1);
            _db.SaveChanges();

            //Assert
            result.Item1.Should().BeTrue();
        }
        [Test]
        public void Test_DeleteRecordById_InvalidData_Changes_No_Rows()
        {
            //Arrange
            _db.Database.EnsureDeleted();

            //Act
            var result = _recordRepository.DeleteRecordById(1);
            _db.SaveChanges();

            //Assert
            result.Item1.Should().BeFalse();
        }
        [Test]
        public void Test_UpdateRecord_ValidRecord_Changes_Correct_Number_Of_Rows()
        {
            //Arrange
            _db.Database.EnsureDeleted();
            _db.Records.Add(new Record { Id = 1, Artist = "Artist1", Title = "Title1", ReleaseYear = 10, Genre = "rest" });
            _db.SaveChanges();

            //Act
            var record = new Record { Id = 1, Artist = "Artist2", Title = "Title2", ReleaseYear = 20, Genre = "rock" };
            var result = _recordRepository.UpdateRecord(record);

            //Assert
            result.Item1.Should().BeTrue();
        }
        [Test]
        public void Test_UpdateRecord_ValidRecord_Changes_Correct_Values()
        {
            //Arrange
            _db.Database.EnsureDeleted();
            _db.Records.Add(new Record { Id = 1, Artist = "Artist1", Title = "Title1", ReleaseYear = 10, Genre = "rest" });
            _db.SaveChanges();

            //Act
            var record = new Record { Id = 1, Artist = "Artist2", Title = "Title2", ReleaseYear = 20, Genre = "rock" };
            var result = _recordRepository.UpdateRecord(record);

            //Assert
            result.Item2.Artist.Should().Be("Artist2");
            result.Item2.Id.Should().Be(1);
        }
        [Test]
        public void Test_UpdateRecord_InvalidRecord_Changes_No_Rows()
        {
            //Arrange
            _db.Database.EnsureDeleted();

            //Act
            var record = new Record { Id = 1, Artist = "Artist2", Title = "Title2", ReleaseYear = 20, Genre = "rock" };
            var result = _recordRepository.UpdateRecord(record);

            //Assert
            result.Item1.Should().BeFalse();
        }
    }
}
