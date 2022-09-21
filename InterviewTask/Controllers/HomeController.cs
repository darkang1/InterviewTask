using InterviewTask.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRandomWordApiService _wordApiService;
        private readonly IMusicBrainzApiService _songApiService;

        public HomeController(IRandomWordApiService wordApiService, IMusicBrainzApiService songApiService)
        {
            _wordApiService = wordApiService;
            _songApiService = songApiService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(WebInput model)
        {
            try
            {
                string[] parsedWords = await _wordApiService.GetRandomWordsAsync(model.NumOfSongs);
                Song[] parsedSongs = await _songApiService.GetSongsByWordsAsync(parsedWords);
                parsedSongs = parsedSongs.OrderBy(x => x.UsedWord).ToArray();
                ViewBag.Words = parsedWords;
                ViewBag.Songs = parsedSongs;
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMsg = ex.Message;
            }
            return View("Index");
        }
    }
}
