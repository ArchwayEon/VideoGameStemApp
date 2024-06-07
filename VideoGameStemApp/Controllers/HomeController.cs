using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VideoGameStemApp.Data;
using VideoGameStemApp.Models;

namespace VideoGameStemApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            var allGames = _db.VideoGames.ToList();
            return View(allGames);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(VideoGame newVideoGame)
        {
            if (ModelState.IsValid)
            {
                _db.VideoGames.Add(newVideoGame);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newVideoGame);
        }

        public IActionResult Details(int id)
        {
            var videoGame = _db.VideoGames.Find(id);
            if (videoGame == null)
            {
                return RedirectToAction("Index");
            }
            return View(videoGame);
        }

        public IActionResult Edit(int id)
        {
            var videoGame = _db.VideoGames.Find(id);
            if (videoGame == null)
            {
                return RedirectToAction("Index");
            }
            return View(videoGame);
        }

        [HttpPost]
        public IActionResult Edit(VideoGame videoGame)
        {
            if (ModelState.IsValid)
            {
                var gameToUpdate = _db.VideoGames.Find(videoGame.Id);
                gameToUpdate!.Title = videoGame.Title;
                gameToUpdate!.Developer = videoGame.Developer;
                gameToUpdate!.Genres = videoGame.Genres;
                gameToUpdate!.Rating = videoGame.Rating;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(videoGame);
        }

        public IActionResult Delete(int id)
        {
            var videoGame = _db.VideoGames.Find(id);
            if (videoGame == null)
            {
                return RedirectToAction("Index");
            }
            return View(videoGame);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var videoGame = _db.VideoGames.Find(id);
            _db.VideoGames.Remove(videoGame!);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
