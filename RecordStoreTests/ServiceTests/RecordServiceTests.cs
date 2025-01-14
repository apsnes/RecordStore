using Moq;
using RecordStore.Repository;
using RecordStore.Services;
using RecordStore.Entities;
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
        [Test]
        public void Test_GetRecordById_Invokes_Once()
        {
            //Arrange
            //Act
            _recordService.GetRecordById(1);

            //Assert
            _mockRepository.Verify(x => x.GetRecordById(1), Times.Once);
        }
        [Test]
        public void Test_AddRecord_Invokes_Once()
        {
            //Arrange
            //Act
            _recordService.AddRecord(new Record());

            //Assert
            _mockRepository.Verify(x => x.AddRecord(It.IsAny<Record>()), Times.Once);
        }
        [Test]
        public void Test_DeleteRecord_Ivokes_Once()
        {
            //Arrange
            //Act
            _recordService.DeleteRecordById(1);

            //Assert
            _mockRepository.Verify(x => x.DeleteRecordById(It.IsAny<int>()), Times.Once);
        }
        [Test]
        public void Test_UpdateRecord_Invokes_Once()
        {
            //Arrange
            //Act
            _recordService.UpdateRecord(new Record());

            //Assert
            _mockRepository.Verify(x => x.UpdateRecord(It.IsAny<Record>()), Times.Once);
        }
    }
}
