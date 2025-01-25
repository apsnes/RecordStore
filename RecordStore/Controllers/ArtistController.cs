using Microsoft.AspNetCore.Mvc;
using RecordStore.Entities;
using RecordStore.Services;

namespace RecordStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArtistController : Controller
    {
        private readonly IArtistService _artistService;
        public ArtistController(IArtistService artistService)
        {
            _artistService = artistService;
        }
        [HttpGet]
        public IActionResult GetAllArtists()
        {
            var result = _artistService.GetAllArtists();
            if (result.Item1 == false) return BadRequest("No artists found");
            return Ok(result.Item2);
        }
        [HttpGet("{id}")]
        public IActionResult GetArtistById(int id)
        {
            var result = _artistService.GetArtistById(id);
            if (result.Item1 == false) return BadRequest($"Artist with id: {id} not found");
            return Ok(result.Item2);
        }
        [HttpPost]
        public IActionResult AddArtist([FromBody] Artist artist)
        {
            var result = _artistService.AddArtist(artist);
            if (result == false) return BadRequest("Artist not added");
            return Ok("Artist added");
        }
        [HttpDelete]
        public IActionResult DeleteArtistById(int id)
        {
            var result = _artistService.DeleteArtistById(id);
            if (result == false) return BadRequest($"Artist with id: {id} not found");
            return Ok("Artist deleted");
        }
        [HttpPut]
        public IActionResult UpdateArtist([FromBody] Artist artist)
        {
            var result = _artistService.UpdateArtist(artist);
            if (result == false) return BadRequest("Artist not updated");
            return Ok("Artist updated");
        }
    }
}
