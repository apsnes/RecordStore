using Microsoft.OpenApi.MicrosoftExtensions;
using System.ComponentModel.DataAnnotations;

namespace RecordStore.Entities
{
    public class Artist
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Artist biogrpahy is required")]
        public string? Description { get; set; }
    }
}
