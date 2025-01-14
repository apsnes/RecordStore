using Moq;
using RecordStore;
using RecordStore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
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
            _db = new RecordStoreDbContext();
            _recordRepository = new RecordRepository(_db);
        }
        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}
