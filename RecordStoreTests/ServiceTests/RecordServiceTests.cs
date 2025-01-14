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
        public void Test_GetAllRecords_Invokes_Once()
        {
            //Arrange
            //Act
            _recordService.GetAllRecords();

            //Assert
            _mockRepository.Verify(x => x.GetAllRecords(), Times.Once);
        }
    }
}
