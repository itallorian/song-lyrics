using LYRICS.INTEGRATION.BUSINESSLOGIC.Models.LyricsOvh;
using LYRICS.INTEGRATION.DOMAIN.Services.Interfaces.LyricsOvh;
using Newtonsoft.Json;

namespace LYRICS.INTEGRATION.DOMAIN.Services.LyricsOvh
{
    public class LyricsOvhService : ILyricsOvhService
    {
        #region [ PATHS ]

        private const string _searchLyricOvhPath = "https://api.lyrics.ovh/v1/{0}/{1}"; // 0 = Author, 1 = Title

        #endregion [ PATHS ]

        public LyricsOvhService() { }

        public async Task<SearchResponse> SearchLyricOvh(SearchRequest request)
        {
            try
            {
                var endpoint = string.Format(_searchLyricOvhPath, request.Author, request.Title);

                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync(endpoint);

                    var responseContent = await response.Content.ReadAsStringAsync();

                    var searchReponse = JsonConvert.DeserializeObject<SearchResponse>(responseContent);

                    return searchReponse ?? new SearchResponse { Error = "Error performing Lyric query." };
                }
            }
            catch (Exception)
            {
                return new SearchResponse() { Error = "Error performing Lyric query." };
            }
        }
    }
}
