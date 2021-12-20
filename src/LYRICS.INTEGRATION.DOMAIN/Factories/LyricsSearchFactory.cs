using LYRICS.INTEGRATION.BUSINESSLOGIC.Models.Integration;
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

        #region [ PATH ]

        private const string _youtubeQueryPath = "https://www.youtube.com/results?search_query={0}";

        #endregion [ PATH ]

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

                var lyricSearch = this.ParseLyricSearch(request, response);

                _lyricsSearchService.AddLyricSearch(lyricSearch);

                if (lyricSearch.Valid == true)
                {
                    response.SearchUrl = GetQueryYoutubePath(request);
                }

                return response;
            }
            catch (Exception)
            {
                return new SearchResponse() { Error = "Error performing Lyric query." };
            }
        }

        public LyricsSearch ParseLyricSearch(SearchRequest request, SearchResponse response)
        {
            bool valid = string.IsNullOrEmpty(response.Lyrics) == false;

            var lycircsSearch = new LyricsSearch()
            {
                Author = request.Author,
                Title = request.Title,
                Valid = valid
            };

            return lycircsSearch;
        }

        private string GetQueryYoutubePath(SearchRequest request)
        {
            var query = string.Empty;

            var authorSplit = request.Author.Split(" ");
            var titleSplit = request.Title.Split(" ");

            foreach (var author in authorSplit)
            {
                query += string.Concat(author, "+");
            }

            foreach (var title in titleSplit)
            {
                query += string.Concat("+", title);
            }

            return string.Concat(_youtubeQueryPath, query);
        }
    }
}
