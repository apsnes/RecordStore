namespace RecordStore.Entities
{
    public class Record
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Artist { get; set; }
        public string? Genre { get; set; }
        public int ReleaseYear { get; set; }
        public string? SpotifyEmbed { get; set; }
    }
}
