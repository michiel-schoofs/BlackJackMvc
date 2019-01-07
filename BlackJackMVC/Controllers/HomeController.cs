using BlackJackMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BlackJackMVC.Controllers
{
    public class HomeController : Controller
    {
        private BlackJack _blackJack;

        public IActionResult Index()
        {
            _blackJack = new BlackJack();
            HttpContext.Session.SetString("BlackJack",JsonConvert.SerializeObject(_blackJack));
            return View(_blackJack);
        }

        public IActionResult NextCard() {
            _blackJack = JsonConvert.DeserializeObject<BlackJack>(HttpContext.Session.GetString("BlackJack"));
            _blackJack.GivePlayerAnotherCard();
            HttpContext.Session.SetString("BlackJack", JsonConvert.SerializeObject(_blackJack));
            return View("Index",_blackJack);
        }

        public IActionResult Pass() {
            _blackJack = JsonConvert.DeserializeObject<BlackJack>(HttpContext.Session.GetString("BlackJack"));
            _blackJack.PassToDealer();
            HttpContext.Session.SetString("BlackJack", JsonConvert.SerializeObject(_blackJack));
            return View("Index", _blackJack);
        }
    }
}