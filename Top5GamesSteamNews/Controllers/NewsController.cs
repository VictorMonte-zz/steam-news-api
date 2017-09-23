using Microsoft.AspNetCore.Mvc;
using Top5GamesSteamNews.Domain.Interfaces;

namespace Top5GamesSteamNews.Controllers
{
    public class NewsController : Controller
    {
        private const int QTD_ARTICLES = 1;
        private const int QTD_GAMES = 5;

        private INewsService _newsService;

        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        public IActionResult Index()
        {
            ViewBag.News = _newsService.Get(QTD_ARTICLES, QTD_GAMES);

            return View();
        }

    }
}