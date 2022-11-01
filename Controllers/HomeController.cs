using Microsoft.AspNetCore.Mvc;
using RedditLab.Models;
using System.Diagnostics;

namespace RedditLab.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        PRAPIDAL db = new PRAPIDAL();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            Subreddit aww = db.GetSubreddit();

            Child[] posts = db.GetSubData(aww);

            return View(posts);
        }

        public IActionResult ViewPost(int Id)
        {
            Child post = db.GetPost(Id);

            return View(post);
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