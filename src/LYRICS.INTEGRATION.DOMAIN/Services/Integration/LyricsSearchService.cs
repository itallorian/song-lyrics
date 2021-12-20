using LYRICS.INTEGRATION.BUSINESSLOGIC.Models.Integration;
using LYRICS.INTEGRATION.DOMAIN.Services.Interfaces.Integration;
using LYRICS.INTEGRATION.REPOSITORY.Repositories.Intefaces.Integration;

namespace LYRICS.INTEGRATION.DOMAIN.Services.Integration
{
    public class LyricsSearchService : ILyricsSearchService
    {
        private readonly ILyricsSearchRepository _lyricsSearchRepository;

        public LyricsSearchService(ILyricsSearchRepository lyricsSearchRepository)
        {
            _lyricsSearchRepository = lyricsSearchRepository;
        }

        public decimal AddLyricSearch(LyricsSearch model)
        {
            try
            {
                return _lyricsSearchRepository.AddLyricSearch(model);
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
