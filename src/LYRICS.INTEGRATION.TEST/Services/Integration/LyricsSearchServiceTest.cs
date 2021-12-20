using LYRICS.INTEGRATION.BUSINESSLOGIC.Models.Integration;
using LYRICS.INTEGRATION.DOMAIN.Services.Integration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LYRICS.INTEGRATION.TEST.Services.Integration
{
    public class LyricsSearchServiceTest
    {
        private readonly MockSetup _mock;
        private readonly LyricsSearchService _service;

        public LyricsSearchServiceTest()
        {
            _mock = new MockSetup();

            _service = new LyricsSearchService
                (
                    _mock.LyricsSearchRepository.Object
                );
        }
        #region [ Add Lyric Search ]

        [Fact(DisplayName = "Add Lyric Search - Success")]
        public void Add_Lyric_Search_Success()
        {
            // Arrange
            var lyricSearch = GetLyricSearch();

            _mock.LyricsSearchRepository.Setup(r => r.AddLyricSearch(lyricSearch)).Returns(1);

            // Act
            var result = _service.AddLyricSearch(lyricSearch);

            // Assert
            Assert.True(result > 0);
        }

        [Fact(DisplayName = "Add Lyric Search - Fail")]
        public void Add_Lyric_Search_Fail()
        {
            // Arrange
            var lyricSearch = GetLyricSearch();

            _mock.LyricsSearchRepository.Setup(r => r.AddLyricSearch(lyricSearch)).Returns(0);

            // Act
            var result = _service.AddLyricSearch(lyricSearch);

            // Assert
            Assert.False(result > 0);
        }

        #region [ Add Lyric Search ]

        #region [ Aux ]

        private LyricsSearch GetLyricSearch()
        {
            return new LyricsSearch()
            {
                Author = "Author",
                Title = "Title",
                Valid = true
            };
        }

        #endregion [ Aux ]
    }
}
