using LYRICS.INTEGRATION.BUSINESSLOGIC.Models.LyricsOvh;

namespace LYRICS.INTEGRATION.WEB.Models.LyricsSearch
{
    public class SearchViewModel
    {
        public SearchViewModel() { }

        public string Author { get; set; } = null!;

        public string Title { get; set; } = null!;

        public SearchResponseViewModel SearchReponse { get; set; } = new SearchResponseViewModel();

        #region [ PARSES ]

        public SearchRequest GetSearchRequest()
        {
            return new SearchRequest()
            {
                Author = this.Author,
                Title = this.Title
            };
        }

        public SearchResponseViewModel GetSearchResponseViewModel(SearchResponse response)
        {
            return new SearchResponseViewModel()
            {
                Lyrics = response.Lyrics,
                Error = response.Error
            };
        }
        #endregion [ PARSES ]
    }
}
