using Microsoft.AspNetCore.Mvc;
using Top5GamesSteamNews.Domain.Interfaces;

namespace Top5GamesSteamNews.Controllers
{
    public class NewsController : Controller
    {
        private INewsService _newsService;

        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        public IActionResult Index()
        {
            ViewBag.News = _newsService.Get(1, 5);

            return View();
        }

    }
}