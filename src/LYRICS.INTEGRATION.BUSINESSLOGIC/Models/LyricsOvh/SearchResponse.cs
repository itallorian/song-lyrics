using Newtonsoft.Json;

namespace LYRICS.INTEGRATION.BUSINESSLOGIC.Models.LyricsOvh
{
    public class SearchResponse
    {
        [JsonProperty("lyrics")]
        public string Lyrics { get; set; } = string.Empty;

        [JsonProperty("error")]
        public string Error { get; set; } = string.Empty;
    }
}
