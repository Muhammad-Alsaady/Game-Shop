using Game_Shop.UI.Models;
using Game_Shop.UI.Services.Repositroy;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Game_Shop.UI.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGameRepository gameRepository;

        public HomeController(ILogger<HomeController> logger, IGameRepository gameRepository)
        {
            _logger = logger;

            this.gameRepository = gameRepository;
        }

        public IActionResult Index()
        {
            return View(gameRepository.GetGames());
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