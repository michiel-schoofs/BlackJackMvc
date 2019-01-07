using BlackJackMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlackJackMVC.Controllers
{
    public class HomeController : Controller
    {
        private BlackJack _blackJack;

        public IActionResult Index()
        {
            _blackJack = new BlackJack();
            return View(_blackJack);
        }
    }
}