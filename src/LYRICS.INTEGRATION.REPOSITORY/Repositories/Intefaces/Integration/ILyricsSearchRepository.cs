using LYRICS.INTEGRATION.BUSINESSLOGIC.Models.Integration;

namespace LYRICS.INTEGRATION.REPOSITORY.Repositories.Intefaces.Integration
{
    public interface ILyricsSearchRepository
    {
        decimal AddLyricSearch(LyricsSearch model);
    }
}
