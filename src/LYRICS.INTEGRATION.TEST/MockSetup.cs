using LYRICS.INTEGRATION.DOMAIN.Services.Interfaces.Integration;
using LYRICS.INTEGRATION.DOMAIN.Services.Interfaces.LyricsOvh;
using LYRICS.INTEGRATION.REPOSITORY.Repositories.Intefaces.Integration;
using Moq;

namespace LYRICS.INTEGRATION.TEST
{
    public class MockSetup
    {
        #region [ SERVICES ]

        public Mock<ILyricsSearchService> LyricsSearchService { get; set; } = new Mock<ILyricsSearchService>();

        public Mock<ILyricsOvhService> LyricsOvhService { get; set; } = new Mock<ILyricsOvhService>();

        #endregion [ SERVICES ]

        #region [ REPOSITORIES ]

        public Mock<ILyricsSearchRepository> LyricsSearchRepository { get; set; } = new Mock<ILyricsSearchRepository>();
        
        #endregion [ REPOSITORIES ]
    }
}
