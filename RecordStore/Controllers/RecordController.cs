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
        //---------Get Requests---------
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
            if (result.Item1 == false) return BadRequest($"Record with id: {id} not found");
            return Ok(result.Item2);
        }
        [HttpGet("artist/{artist}")]
        public IActionResult GetRecordsByArtist(string artist)
        {
            var result = _recordService.GetRecordsByArtist(artist);
            if (result.Item1 == false) return BadRequest($"No records found by artist: {artist}");
            return Ok(result.Item2);
        }
        [HttpGet("year/{year}")]
        public IActionResult GetRecordsByReleaseYear(int year)
        {
            var result = _recordService.GetRecordsByReleaseYear(year);
            if (result.Item1 == false) return BadRequest($"No records found that were released in the year: {year}");
            return Ok(result.Item2);
        }
        [HttpGet("genre/{genre}")]
        public IActionResult GetRecordsByGenre(string genre)
        {
            var result = _recordService.GetRecordsByGenre(genre);
            if (result.Item1 == false) return BadRequest($"No records found in genre: {genre}");
            return Ok(result.Item2);
        }
        [HttpGet("record/{recordName}")]
        public IActionResult GetRecordInfoByName(string recordName)
        {
            var result = _recordService.GetRecordInfoByName(recordName);
            if (result.Item1 == false) return BadRequest($"Record not with name: {recordName} not found");
            return Ok(result.Item2);
        }
        //---------Post Requests---------
        [HttpPost]
        public IActionResult AddRecord([FromBody] Record record)
        {
            var result = _recordService.AddRecord(record);
            if (result.Item1 == false) return BadRequest($"Unable to add record with id: {record.Id}");
            return Ok(result.Item2);
        }
        //---------Delete Requests---------
        [HttpDelete("{id}")]
        public IActionResult DeleteRecordById(int id)
        {
            var result = _recordService.DeleteRecordById(id);
            if (result.Item1 == false) return BadRequest($"Record with id: {id} not found");
            return Ok(result.Item2);
        }
        //---------Put Requests---------
        [HttpPut]
        public IActionResult UpdateRecord(Record record)
        {
            Console.WriteLine("Ive been called!");
            var result = _recordService.UpdateRecord(record);
            if (result.Item1 == false) return BadRequest($"Record with id: {record.Id} not found");
            return Ok(result.Item2);
        }
    }
}
