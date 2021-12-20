using LYRICS.INTEGRATION.BUSINESSLOGIC.Models.Integration;
using LYRICS.INTEGRATION.REPOSITORY.Context;
using LYRICS.INTEGRATION.REPOSITORY.Models.Integration.Tables;
using LYRICS.INTEGRATION.REPOSITORY.Repositories.Intefaces.Integration;

namespace LYRICS.INTEGRATION.REPOSITORY.Repositories.Integration
{
    public class LyricsSearchRepository : ILyricsSearchRepository
    {
        public LyricsSearchRepository() { }

        public decimal AddLyricSearch(LyricsSearch model)
        {
            try
            {
                using (var context = new IntegrationContext())
                {
                    var lyricSearch = new TB_LYRICS_SEARCH()
                    {
                        INSERTION_DATE = DateTime.Now,
                        AUTHOR = model.Author,
                        TITLE = model.Title,
                        VALID = model.Valid
                    };

                    context.Add(lyricSearch);
                    var ret = context.SaveChanges();

                    return lyricSearch.LYRIC_SEARCH;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
