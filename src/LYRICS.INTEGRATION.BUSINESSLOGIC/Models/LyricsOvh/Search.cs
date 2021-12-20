using Newtonsoft.Json;

namespace LYRICS.INTEGRATION.BUSINESSLOGIC.Models.LyricsOvh
{
    public class Search
    {
        [JsonProperty("lyrics")]
        public string Lyrics { get; set; } = string.Empty;

        [JsonProperty("error")]
        public string Error { get; set; } = string.Empty;
    }
}
