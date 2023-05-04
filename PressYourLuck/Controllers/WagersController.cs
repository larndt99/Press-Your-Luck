//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using PressYourLuck.Data;
//using PressYourLuck.Models;

//namespace PressYourLuck.Controllers
//{
//    public class WagersController : Controller
//    {
//        private readonly GeneralContext _context;

//        public WagersController(GeneralContext context)
//        {
//            _context = context;
//        }



//        // GET: Wagers/Create
//        public IActionResult Create()
//        {
//            string playerName = Request.Cookies["PlayerName"];
//            if (string.IsNullOrEmpty(playerName))
//            {
//                return RedirectToAction("Create", "Players");
//            }

//            string coinsTotal = Request.Cookies["CoinsTotal"];
//            ViewData["PlayerName"] = playerName;
//            ViewData["CoinsTotal"] = coinsTotal;

//            Wager newWager = new Wager();
//            newWager.Name = playerName;
//            newWager.CoinsBet = 0.0;

//            return View(newWager);
//        }

//        // POST: Wagers/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("Name,CoinsBet")] Wager wager)
//        {
//            if (ModelState.IsValid)
//            {
//                //_context.Add(wager);
//                //await _context.SaveChangesAsync();
//                var tmpTotal = Request.Cookies["CoinsTotal"];
//                double coinsTotal = Convert.ToDouble(tmpTotal);
//                coinsTotal -= wager.CoinsBet;

//                Response.Cookies.Append("CoinsTotal", coinsTotal.ToString("N2"));


//                string playerName = wager.Name;
                
//                return RedirectToAction("Index", "Game");
//            }
//            return View(wager);
//        }

//    }
//}
