namespace LYRICS.INTEGRATION.WEB.Models.LyricsSearch
{
    public class SearchResponseViewModel
    {
        public SearchResponseViewModel() { }

        public string Lyrics { get; set; } = string.Empty;

        public string Error { get; set; } = string.Empty;
    }
}
