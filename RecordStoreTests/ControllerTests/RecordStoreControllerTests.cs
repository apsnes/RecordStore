using FluentAssertions;
using Moq;
using RecordStore.Controllers;
using RecordStore.Services;
using Microsoft.AspNetCore.Mvc;
using RecordStore.Entities;

namespace RecordStoreTests.ControllerTests
{
    public class RecordStoreControllerTests
    {
        private Mock<IRecordService> _mockService;
        private RecordController _recordController;
        [SetUp]
        public void Setup()
        {
            _mockService = new Mock<IRecordService>();
            _recordController = new RecordController(_mockService.Object);
        }
        //--------Get Requests--------
        [Test]
        public void Test_GetAllRecords_NoData_Returns_BadRequest()
        {
            //Arrange
            _mockService.Setup(x => x.GetAllRecords()).Returns((false, null));

            //Act
            var result = _recordController.GetAllRecords();

            //Assert
            result.Should().BeOfType<BadRequestObjectResult>();
        }
        [Test]
        public void Test_GetAllRecords_ValidData_Returns_Ok()
        {
            //Arrange
            _mockService.Setup(x => x.GetAllRecords()).Returns((true, new List<Record>()));

            //Act
            var result = _recordController.GetAllRecords();

            //Assert
            result.Should().BeOfType<OkObjectResult>();
        }
        [Test]
        public void Test_GetRecordById_NoData_Returns_BadRequest()
        {
            //Arrange
            _mockService.Setup(x => x.GetRecordById(It.IsAny<int>())).Returns((false, null));

            //Act
            var result = _recordController.GetRecordById(1);

            //Assert
            result.Should().BeOfType<BadRequestObjectResult>();
        }
        [Test]
        public void Test_GetRecordById_ValidData_Returns_Ok()
        {
            //Arrange
            _mockService.Setup(x => x.GetRecordById(It.IsAny<int>())).Returns((true, new Record()));

            //Act
            var result = _recordController.GetRecordById(1);

            //Assert
            result.Should().BeOfType<OkObjectResult>();
        }
        [Test]
        public void Test_GetRecordsByArtist_NoData_Returns_BadRequest()
        {
            //Arrange
            _mockService.Setup(x => x.GetRecordsByArtist(It.IsAny<string>())).Returns((false, null));

            //Act
            var result = _recordController.GetRecordsByArtist("artist");

            //Assert
            result.Should().BeOfType<BadRequestObjectResult>();
        }
        [Test]
        public void Test_GetRecordsByArtist_ValidData_Returns_Ok()
        {
            //Arrange
            _mockService.Setup(x => x.GetRecordsByArtist(It.IsAny<string>())).Returns((true, new List<Record>()));

            //Act
            var result = _recordController.GetRecordsByArtist("artist");

            //Assert
            result.Should().BeOfType<OkObjectResult>();
        }
        [Test]
        public void Test_GetRecordsByReleaseYear_NoData_Returns_BadRequest()
        {
            //Arrange
            _mockService.Setup(x => x.GetRecordsByReleaseYear(It.IsAny<int>())).Returns((false, null));

            //Act
            var result = _recordController.GetRecordsByReleaseYear(10);

            //Assert
            result.Should().BeOfType<BadRequestObjectResult>();
        }
        [Test]
        public void Test_GetRecordsByReleaseYear_ValidData_Returns_Ok()
        {
            //Arrange
            _mockService.Setup(x => x.GetRecordsByReleaseYear(It.IsAny<int>())).Returns((true, new List<Record>()));

            //Act
            var result = _recordController.GetRecordsByReleaseYear(10);

            //Assert
            result.Should().BeOfType<OkObjectResult>();
        }
        [Test]
        public void Test_GetRecordsByGenre_NoData_Returns_BadRequest()
        {
            //Arrange
            _mockService.Setup(x => x.GetRecordsByGenre(It.IsAny<string>())).Returns((false, null));

            //Act
            var result = _recordController.GetRecordsByGenre("test");

            //Assert
            result.Should().BeOfType<BadRequestObjectResult>();
        }
        [Test]
        public void Test_GetRecordsByGenre_ValidData_Returns_Ok()
        {
            //Arrange
            _mockService.Setup(x => x.GetRecordsByGenre(It.IsAny<string>())).Returns((true, new List<Record>()));

            //Act
            var result = _recordController.GetRecordsByGenre("test");

            //Assert
            result.Should().BeOfType<OkObjectResult>();
        }
        [Test]
        public void Test_GetRecordInfoByName_NoData_Returns_BadRequest()
        {
            //Arrange
            _mockService.Setup(x => x.GetRecordInfoByName(It.IsAny<string>())).Returns((false, null));

            //Act
            var result = _recordController.GetRecordInfoByName("test");

            //Assert
            result.Should().BeOfType<BadRequestObjectResult>();
        }
        [Test]
        public void Test_GetRecordInfoByName_ValidData_Returns_Ok()
        {
            //Arrange
            _mockService.Setup(x => x.GetRecordInfoByName(It.IsAny<string>())).Returns((true, new Record()));

            //Act
            var result = _recordController.GetRecordInfoByName("test");

            //Assert
            result.Should().BeOfType<OkObjectResult>();
        }
        //--------Post Requests--------
        [Test]
        public void Test_AddRecord_ValidData_Returns_Ok()
        {
            //Arrange
            var record = new Record { Id = 1, Artist = "Artist1", Title = "Title1", ReleaseYear = 10, Genre = "rest" };
            _mockService.Setup(x => x.AddRecord(record)).Returns((true, record));

            //Act
            var result = _recordController.AddRecord(record);

            //Assert
            result.Should().BeOfType<OkObjectResult>();
        }
        [Test]
        public void Test_AddRecord_ValidData_Returns_Record()
        {
            //Arrange
            var record = new Record { Id = 1, Artist = "Artist1", Title = "Title1", ReleaseYear = 10, Genre = "rest" };
            _mockService.Setup(x => x.AddRecord(record)).Returns((true, record));

            //Act
            var result = _recordController.AddRecord(record);

            //Assert
            result.Should().BeOfType<OkObjectResult>().Which.Value.Should().Be(record);
        }
        [Test]
        public void Test_AddRecord_NoData_Returns_BadRequest()
        {
            //Arrange
            _mockService.Setup(x => x.AddRecord(It.IsAny<Record>())).Returns((false, null));

            //Act
            var result = _recordController.AddRecord(new Record());

            //Assert
            result.Should().BeOfType<BadRequestObjectResult>();
        }
        //--------Delete Requests--------
        [Test]
        public void Test_DeleteRecordById_ValidData_Returns_Ok()
        {
            //Arrange
            var record = new Record { Id = 1, Artist = "Artist1", Title = "Title1", ReleaseYear = 10, Genre = "rest" };
            _mockService.Setup(x => x.DeleteRecordById(1)).Returns((true, record));

            //Act
            var result = _recordController.DeleteRecordById(1);

            //Assert
            result.Should().BeOfType<OkObjectResult>();
        }
        [Test]
        public void Test_DeleteRecordById_InvalidData_Returns_BadRequest()
        {
            //Arrange
            _mockService.Setup(x => x.DeleteRecordById(It.IsAny<int>())).Returns((false, null));

            //Act
            var result = _recordController.DeleteRecordById(1);

            //Assert
            result.Should().BeOfType<BadRequestObjectResult>();
        }
        //--------Put Requests--------
        [Test]
        public void Test_UpdateRecord_ValidData_Returns_Ok()
        {
            //Arrange
            var record = new Record { Id = 1, Artist = "Artist1", Title = "Title1", ReleaseYear = 10, Genre = "rest" };
            _mockService.Setup(x => x.UpdateRecord(record)).Returns((true, record));

            //Act
            var result = _recordController.UpdateRecord(record);

            //Assert
            result.Should().BeOfType<OkObjectResult>();
        }
        [Test]
        public void Test_UpdateRecord_InvalidData_Returns_BadRequest()
        {
            //Arrange
            _mockService.Setup(x => x.UpdateRecord(It.IsAny<Record>())).Returns((false, null));

            //Act
            var result = _recordController.UpdateRecord(new Record());

            //Assert
            result.Should().BeOfType<BadRequestObjectResult>();
        }
    }
}