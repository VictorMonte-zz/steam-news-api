using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
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
            ViewData["news"] = _newsService.Get(1, 5).Result;

            return View();
        }

    }
}