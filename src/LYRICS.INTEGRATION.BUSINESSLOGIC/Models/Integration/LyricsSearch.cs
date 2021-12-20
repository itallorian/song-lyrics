namespace LYRICS.INTEGRATION.BUSINESSLOGIC.Models.Integration
{
    public class LyricsSearch
    {
        public decimal LyricSearch { get; set; }

        public DateTime InsertionDate { get; set; }

        public string Author { get; set; } = null!;

        public string Title { get; set; } = null!;

        public bool Valid { get; set; }
    }
}
