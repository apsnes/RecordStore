using Microsoft.AspNetCore.Mvc;
using RecordStore.Entities;
using RecordStore.Services;

namespace RecordStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecordController : ControllerBase
    {
        private readonly IRecordService _recordService;
        public RecordController(IRecordService recordService)
        {
            _recordService = recordService;
        }
        [HttpGet]
        public IActionResult GetAllRecords()
        {
            var result = _recordService.GetAllRecords();
            if (result.Item1 == false) return BadRequest("No records found");
            return Ok(result.Item2);
        }
        [HttpGet("{id}")]
        public IActionResult GetRecordById(int id)
        {
            var result = _recordService.GetRecordById(id);
            if (result.Item1 == false) return BadRequest("Record not found");
            return Ok(result.Item2);
        }
        [HttpPost]
        public IActionResult AddRecord([FromBody] Record record)
        {
            var result = _recordService.AddRecord(record);
            if (result.Item1 == false) return BadRequest("Unable to add record");
            return Ok(result.Item2);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteRecordById(int id)
        {
            var result = _recordService.DeleteRecordById(id);
            if (result.Item1 == false) return BadRequest("Record not found");
            return Ok(result.Item2);
        }
        [HttpPatch]
        public IActionResult UpdateRecord(Record record)
        {
            var result = _recordService.UpdateRecord(record);
            if (result.Item1 == false) return BadRequest("Record not found");
            return Ok(result.Item2);
        }
    }
}
