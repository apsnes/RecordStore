using FluentAssertions;
using Moq;
using RecordStore.Controllers;
using RecordStore.Services;
using Microsoft.AspNetCore.Mvc;
using RecordStore.Entities;

namespace RecordStoreTests
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
    }
}