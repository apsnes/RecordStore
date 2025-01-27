using System.ComponentModel.DataAnnotations;

namespace RecordStore.Entities
{
    public class Record
    {
        public int Id { get; set; }
        public string? Title { get; set; } = null;
        public string? Artist { get; set; } = null;
        public string? Genre { get; set; } = null;
        public int? ReleaseYear { get; set; } = null;
        public string? SpotifyEmbed { get; set; } = null;
        public int? ArtistId { get; set; } = null;
    }
}
