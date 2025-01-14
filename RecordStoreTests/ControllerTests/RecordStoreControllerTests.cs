using Moq;
using RecordStore.Controllers;
using RecordStore.Services;

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
        public void Test1()
        {
            Assert.Pass();
        }
    }
}