//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging;
//using PressYourLuck.Models;
//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;

//namespace PressYourLuck.Controllers
//{
//    public class HomeController : Controller
//    {
//        private readonly ILogger<HomeController> _logger;

//        public HomeController(ILogger<HomeController> logger)
//        {
//            _logger = logger;
//        }

//        [HttpGet]
//        public IActionResult Index()
//        {
//            string playerName = Request.Cookies["PlayerName"];
//            if (string.IsNullOrEmpty(playerName))
//            {
//                return RedirectToAction("Create", "Players");
//            }

//            string coinsTotal = Request.Cookies["CoinsTotal"];
//            ViewData["PlayerName"] = playerName;
//            ViewData["CoinsTotal"] = coinsTotal;

//            Home newBet = new Home();
//            newBet.Name = playerName;
//            newBet.CoinsBet = 0.0;

//            return View(newBet);
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public IActionResult Index([Bind("Name,CoinsBet")] Home newBet)
//        {
//            if (ModelState.IsValid) //cookies
//            {
//                //_context.Add(player);
//                //await _context.SaveChangesAsync();
//                var optCookie = new CookieOptions { Expires = DateTime.Now.AddDays(60) };
//                Response.Cookies.Append("PlayerName", newBet.Name, optCookie);
//                Response.Cookies.Append("CoinsBet", newBet.CoinsBet.ToString("N2"), optCookie);

//                return RedirectToAction("Index", "Home");


//                //return RedirectToAction(nameof(Index));
//            }
//            return View(newBet);
//        }

//        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
//        public IActionResult Error()
//        {
//            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
//        }
//    }
//}
