using Moq;
using RecordStore.Repository;
using RecordStore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordStoreTests.ServiceTests
{
    public class RecordServiceTests
    {
        private Mock<IRecordRepository> _mockRepository;
        private RecordService _recordService;
        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<IRecordRepository>();
            _recordService = new RecordService(_mockRepository.Object);
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}
