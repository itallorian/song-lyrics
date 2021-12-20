using LYRICS.INTEGRATION.BUSINESSLOGIC.Models.LyricsOvh;

namespace LYRICS.INTEGRATION.DOMAIN.Services.Interfaces.LyricsOvh
{
    public interface ILyricsOvhService
    {
        Task<SearchResponse> SearchLyricOvh(SearchRequest request);
    }
}
