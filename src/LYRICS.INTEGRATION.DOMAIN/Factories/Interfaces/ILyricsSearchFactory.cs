using LYRICS.INTEGRATION.BUSINESSLOGIC.Models.LyricsOvh;

namespace LYRICS.INTEGRATION.DOMAIN.Factories.Interfaces
{
    public interface ILyricsSearchFactory
    {
        Task<SearchResponse> ProcessSearch(SearchRequest request);
    }
}
