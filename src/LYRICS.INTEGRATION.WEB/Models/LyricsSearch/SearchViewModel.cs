using LYRICS.INTEGRATION.BUSINESSLOGIC.Models.LyricsOvh;

namespace LYRICS.INTEGRATION.WEB.Models.LyricsSearch
{
    public class SearchViewModel
    {
        public SearchViewModel() { }

        public string Author { get; set; } = null!;

        public string Title { get; set; } = null!;

        public SearchResponseViewModel? SearchReponse { get; set; }

        #region [ PARSES ]

        public SearchRequest GetSearchRequest()
        {
            return new SearchRequest()
            {
                Author = this.Author,
                Title = this.Title
            };
        }

        public void GetSearchResponseViewModel(SearchResponse response)
        {
            SearchReponse = new SearchResponseViewModel()
            {
                Lyrics = response.Lyrics,
                Error = response.Error
            };
        }
        #endregion [ PARSES ]
    }
}
