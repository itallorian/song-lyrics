using LYRICS.INTEGRATION.DOMAIN.Factories.Interfaces;
using LYRICS.INTEGRATION.WEB.Models;
using LYRICS.INTEGRATION.WEB.Models.LyricsSearch;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LYRICS.INTEGRATION.WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILyricsSearchFactory _lyricsSearchFactory;

        public HomeController(ILyricsSearchFactory lyricsSearchFactory)
        {
            _lyricsSearchFactory = lyricsSearchFactory;
        }

        [HttpGet]
        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("/")]
        public async Task<IActionResult> Index([FromForm] SearchViewModel viewModel)
        {
            try
            {
                var request = viewModel.GetSearchRequest();

                var response = await _lyricsSearchFactory.ProcessSearch(request);

                viewModel.GetSearchResponseViewModel(response);

                return View(viewModel);
            }
            catch (Exception)
            {
                return RedirectToAction("Error");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}