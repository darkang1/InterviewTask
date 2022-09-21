using InterviewTask.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRandomWordApiService _wordApiService;
        private readonly IMusicBrainzApiService _songApiService;
        private readonly IConfiguration _configuration;

        public HomeController(IRandomWordApiService wordApiService, IMusicBrainzApiService songApiService, IConfiguration configuration)
        {
            _wordApiService = wordApiService;
            _songApiService = songApiService;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(Models.WebInput model)
        {
            ViewBag.Num = model.NumOfSongs;
            try
            {
                string[] parsedWords = await _wordApiService.GetRandomWordsAsync(model.NumOfSongs);
                Song[] parsedSongs = await _songApiService.GetSongsByWordsAsync(parsedWords);

                // Sorting obtained records by RandomWord, as asked in the interview task
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
