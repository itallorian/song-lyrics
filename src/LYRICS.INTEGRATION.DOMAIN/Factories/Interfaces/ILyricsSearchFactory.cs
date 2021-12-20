using LYRICS.INTEGRATION.BUSINESSLOGIC.Models.Integration;
using LYRICS.INTEGRATION.BUSINESSLOGIC.Models.LyricsOvh;

namespace LYRICS.INTEGRATION.DOMAIN.Factories.Interfaces
{
    public interface ILyricsSearchFactory
    {
        Task<SearchResponse> ProcessSearch(SearchRequest request);

        LyricsSearch ParseLyricSearch(SearchRequest request, SearchResponse response);
    }
}
