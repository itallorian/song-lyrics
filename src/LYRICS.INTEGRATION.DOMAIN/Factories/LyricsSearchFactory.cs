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
    }
}
