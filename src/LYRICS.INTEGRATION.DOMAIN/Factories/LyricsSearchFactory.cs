using LYRICS.INTEGRATION.BUSINESSLOGIC.Models.LyricsOvh;
using LYRICS.INTEGRATION.DOMAIN.Factories.Interfaces;
using LYRICS.INTEGRATION.DOMAIN.Services.Interfaces.Integration;
using LYRICS.INTEGRATION.DOMAIN.Services.Interfaces.LyricsOvh;

namespace LYRICS.INTEGRATION.DOMAIN.Factories
{
    public class LyricsSearchFactory : ILyricsSearchFactory
    {
        private readonly ILyricsSearchService _lyricsSearchService;
        private readonly ILyricsOvhService _lyricsOvhService;

        public LyricsSearchFactory
            (
                ILyricsSearchService lyricsSearchService,
                ILyricsOvhService lyricsOvhService
            )
        {
            _lyricsSearchService = lyricsSearchService;
            _lyricsOvhService = lyricsOvhService;
        }

        public async Task<SearchResponse> ProcessSearch(SearchRequest request)
        {
            try
            {
                var response = await _lyricsOvhService.SearchLyricOvh(request);

                return response;
            }
            catch (Exception)
            {
                return new SearchResponse() { Error = "Error performing Lyric query." };
            }
        }
    }
}
