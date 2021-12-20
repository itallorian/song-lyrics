using LYRICS.INTEGRATION.BUSINESSLOGIC.Models.LyricsOvh;
using LYRICS.INTEGRATION.DOMAIN.Factories;
using System.Threading.Tasks;
using Xunit;

namespace LYRICS.INTEGRATION.TEST.Factories
{
    public class LyricsSearchFactoryTest
    {
        private readonly MockSetup _mock;

        private readonly LyricsSearchFactory _factory;

        public LyricsSearchFactoryTest()
        {
            _mock = new MockSetup();

            _factory = new LyricsSearchFactory
                (
                    _mock.LyricsSearchService.Object,
                    _mock.LyricsOvhService.Object
                );
        }

        #region [ Process Search ]

        [Fact(DisplayName = "Process Search - Success")]
        public async void Process_Search_Success()
        {
            // Arrange
            var searchResquest = GetSearchRequest();

            var searchResponse = new SearchResponse()
            {
                Lyrics = "Lyrics"
            };

            _mock.LyricsOvhService.Setup(s => s.SearchLyricOvh(searchResquest)).Returns(Task.FromResult(searchResponse));

            // Act

            var response = await _factory.ProcessSearch(searchResquest);

            // Assert
            Assert.NotEmpty(response.Lyrics);
        }

        [Fact(DisplayName = "Process Search - Fail")]
        public async void Process_Search_Fail()
        {
            // Arrange
            var searchResquest = GetSearchRequest();

            var searchResponse = new SearchResponse()
            {
                Error = "Error"
            };

            _mock.LyricsOvhService.Setup(s => s.SearchLyricOvh(searchResquest)).Returns(Task.FromResult(searchResponse));

            // Act

            var response = await _factory.ProcessSearch(searchResquest);

            // Assert
            Assert.Empty(response.Lyrics);
        }

        #endregion [ Process Search ]

        #region [ Parse Lyric Search ]

        [Fact(DisplayName = "Parse Lyric Search - Valid")]
        public void Parse_Lyric_Search_Valid()
        {
            // Arrange
            var searchResquest = GetSearchRequest();

            var searchResponse = new SearchResponse()
            {
                Lyrics = "Lyrics"
            };

            // Act
            var result = _factory.ParseLyricSearch(searchResquest, searchResponse);

            // Assert
            Assert.True(result.Valid);
        }

        [Fact(DisplayName = "Parse Lyric Search - Not Valid")]
        public void Parse_Lyric_Search_Not_Valid()
        {
            // Arrange
            var searchResquest = GetSearchRequest();

            var searchResponse = new SearchResponse()
            {
                Error = "Error"
            };

            // Act
            var result = _factory.ParseLyricSearch(searchResquest, searchResponse);

            // Assert
            Assert.False(result.Valid);
        }

        #endregion [ Parse Lyric Search ]

        #region [ Aux ]

        private SearchRequest GetSearchRequest()
        {
            return new SearchRequest()
            {
                Author = "Author",
                Title = "Title"
            };
        }

        #endregion [ Aux ]
    }
}
