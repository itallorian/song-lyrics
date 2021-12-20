using System.ComponentModel.DataAnnotations;

namespace LYRICS.INTEGRATION.BUSINESSLOGIC.Models.LyricsOvh
{
    public class SearchRequest
    {
        [Required]
        public string Author { get; set; } = null!;

        [Required]
        public string Title { get; set; } = null!;
    }
}
