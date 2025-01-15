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
        //--------Get Requests--------
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
        public void Test_GetRecordsByArtist_Invokes_Once()
        {
            //Arrange
            //Act
            _recordService.GetRecordsByArtist("artist");

            //Assert
            _mockRepository.Verify(x => x.GetRecordsByArtist("artist"), Times.Once);
        }
        [Test]
        public void Test_GetRecordsByGenre_Invokes_Once()
        {
            //Arrange
            //Act
            _recordService.GetRecordsByGenre("genre");

            //Assert
            _mockRepository.Verify(x => x.GetRecordsByGenre("genre"), Times.Once);
        }
        [Test]
        public void Test_GetRecordsByYear_Invokes_Once()
        {
            //Arrange
            //Act
            _recordService.GetRecordsByReleaseYear(2021);

            //Assert
            _mockRepository.Verify(x => x.GetRecordsByReleaseYear(It.IsAny<int>()), Times.Once);
        }
        [Test]
        public void Test_GetRecordInfoByName_Invokes_Once()
        {
            //Arrange
            //Act
            _recordService.GetRecordInfoByName("recordName");

            //Assert
            _mockRepository.Verify(x => x.GetRecordInfoByName(It.IsAny<string>()), Times.Once);
        }
        //--------Post Requests--------
        [Test]
        public void Test_AddRecord_Invokes_Once()
        {
            //Arrange
            //Act
            _recordService.AddRecord(new Record());

            //Assert
            _mockRepository.Verify(x => x.AddRecord(It.IsAny<Record>()), Times.Once);
        }
        //--------Delete Requests--------
        [Test]
        public void Test_DeleteRecord_Ivokes_Once()
        {
            //Arrange
            //Act
            _recordService.DeleteRecordById(1);

            //Assert
            _mockRepository.Verify(x => x.DeleteRecordById(It.IsAny<int>()), Times.Once);
        }
        //---------Put Requests---------
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
