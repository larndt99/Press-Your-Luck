using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PressYourLuck.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace PressYourLuck.Controllers
{
    public class GamesController : Controller
    {
        private readonly AuditContext _context;

        private const string ssnGame = "Game";
        private const string cookiePlayer = "Player";


        public GamesController(AuditContext context)
        {
            _context = context;
        }

        // GET: Games
        public IActionResult Index()
        {
            return View();
        }

        // GET: Games
        public async Task<IActionResult> Play(int? indexCard)
        {
            
            Player oldPlayer = null;
            string playerCookie = Request.Cookies[cookiePlayer];
            
            if (!string.IsNullOrEmpty(playerCookie))
            {
                oldPlayer = JsonConvert.DeserializeObject<Player>(playerCookie);
            }
            if (oldPlayer == null)
            {
                return RedirectToAction("Join");
            }

            //Get game from session
            string gameInString = HttpContext.Session.GetString(ssnGame);
            Game currentGame = JsonConvert.DeserializeObject<Game>(gameInString);
            double initialBet = currentGame.GameCoins;
            ViewData["GameTotal"] = currentGame.GameCoins;
            if (indexCard != null)
            {
                currentGame.RevealCard((int)indexCard);
                double newBet = currentGame.RevealCard((int)indexCard);
                ViewData["GameTotal"] = newBet;
                currentGame.GameCoins = newBet;


            }

            
            ViewData["PlayerName"] = currentGame.Player.Name;
            ViewData["CoinsTotal"] = oldPlayer.CoinsTotal;
          

            //Save game to session
            gameInString = JsonConvert.SerializeObject(currentGame);
            HttpContext.Session.SetString(ssnGame, gameInString);

            if (currentGame.GameCoins == 0)
            {
                TempData["Message"] = "Oh no! You busted out. Better luck next time!";

                Audit join = new Audit();
                join.PlayerName = currentGame.Player.Name;
                join.CreatedDate = DateTime.Now;
                join.Amount = Double.Parse(HttpContext.Session.GetString("Original Bet"));
                join.TypeId = 4;
                _context.Add(join);
                await _context.SaveChangesAsync();
            }
            else if (currentGame.GameCoins > initialBet)
            {
                TempData["Message"] = "Congrats you've found a multiplier! All remaining values have doubled. Will you Press Your Luck?";

            }

            if (currentGame.Player.CoinsTotal == 0)
            {
                TempData["Message"] = "You've lost all your coins and must enter more to keep playing";

           
            }

            return View(currentGame);
        }



        // GET: Games/Create
        public IActionResult Start()
        {
                
                Player oldPlayer = null;
                string playerCookie = Request.Cookies[cookiePlayer];
                if (!string.IsNullOrEmpty(playerCookie))
                {
                    oldPlayer = JsonConvert.DeserializeObject<Player>(playerCookie);
               
                }
                if (oldPlayer == null)
                {
                    return RedirectToAction("Join");
                }

                ViewData["PlayerName"] = oldPlayer.Name;
                ViewData["CoinsTotal"] = oldPlayer.CoinsTotal;

                return View();
        }
        public async Task<IActionResult> TakeCoins()
        {
            string gameInString = HttpContext.Session.GetString(ssnGame);
            Game currentGame = JsonConvert.DeserializeObject<Game>(gameInString);


            currentGame.Player.CoinsTotal += currentGame.GameCoins;
            ViewData["CoinsTotal"] = currentGame.Player.CoinsTotal;
            TempData["Message"] = "BIG WINNER! You chased out for " + currentGame.GameCoins + "! Care to press your luck again?";

            var options = new CookieOptions { Expires = DateTime.Now.AddDays(1) };
            Player player = new Player();
            player.Name = currentGame.Player.Name;
            player.CoinsTotal = currentGame.Player.CoinsTotal;
            string playerInString = JsonConvert.SerializeObject(player);
            Response.Cookies.Append(cookiePlayer, playerInString, options);

            Audit join = new Audit();
            join.PlayerName = player.Name;
            join.CreatedDate = DateTime.Now;
            join.Amount = player.CoinsTotal;
            join.TypeId = 3;
            _context.Add(join);
            await _context.SaveChangesAsync();


            gameInString = JsonConvert.SerializeObject(currentGame);
            HttpContext.Session.SetString(ssnGame, gameInString);

            return RedirectToAction("Start");

        }
        
        public async Task<IActionResult> LogOut()
        {
            string gameInString = HttpContext.Session.GetString(ssnGame);
            Game currentGame = JsonConvert.DeserializeObject<Game>(gameInString);


            Audit join = new Audit();
            join.PlayerName = currentGame.Player.Name;
            join.CreatedDate = DateTime.Now;
            join.Amount = currentGame.Player.CoinsTotal;
            join.TypeId = 2;
            _context.Add(join);
            await _context.SaveChangesAsync();

            TempData["Message"] = "You cashed out for " + currentGame.Player.CoinsTotal + " coins";
            HttpContext.Response.Cookies.Delete(cookiePlayer);
            
            return RedirectToAction("Join");
            
        }

        // POST: Games/Start

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Start([Bind("GameCoins")] Game game)
        {
            if(ModelState.IsValid)
            {
                HttpContext.Session.SetString("Original Bet", game.GameCoins.ToString());
                Player currentPlayer = null;
                string playerCookie = Request.Cookies[cookiePlayer];
                if (!string.IsNullOrEmpty(playerCookie))
                {
                    currentPlayer = JsonConvert.DeserializeObject<Player>(playerCookie);

                    
                }

                if(currentPlayer == null)
                {
                    return RedirectToAction("Join");
                }

                
                
                //currentPlayer.CoinsTotal -= game.GameCoins;
                game.Player = currentPlayer;
                game.Start();

                string gameInString = JsonConvert.SerializeObject(game);
                HttpContext.Session.SetString(ssnGame, gameInString);
                var options = new CookieOptions { Expires = DateTime.Now.AddDays(1) };
                string playerInString = JsonConvert.SerializeObject(currentPlayer);
                Response.Cookies.Append(cookiePlayer, playerInString, options);

                return RedirectToAction("Play");
            }
           
            return View(game);
        }

        // GET: Games/Create
        public IActionResult Join()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Join([Bind("Name, CoinsTotal")] Player player)
        {
            if (ModelState.IsValid)
            {
                var options = new CookieOptions { Expires = DateTime.Now.AddDays(1) };
                string playerInString = JsonConvert.SerializeObject(player);
                Response.Cookies.Append(cookiePlayer, playerInString, options);
                Audit join = new Audit();
                join.PlayerName = player.Name;
                join.CreatedDate = DateTime.Now;
                join.Amount = player.CoinsTotal;
                join.TypeId = 1;
                _context.Add(join);
                await _context.SaveChangesAsync();
                return RedirectToAction("Start");

            }
            return View(player);
        }

        // GET: Games/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var game = await _context.Game.FindAsync(id);
        //    if (game == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(game);
        //}

        // POST: Games/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,GameCoins,GameStage,GameStageMessage")] Game game)
        //{
        //    if (id != game.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(game);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!GameExists(game.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(game);
        //}

        // GET: Games/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var game = await _context.Game
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (game == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(game);
        //}

        //// POST: Games/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var game = await _context.Game.FindAsync(id);
        //    _context.Game.Remove(game);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool GameExists(int id)
        //{
        //    return _context.Game.Any(e => e.Id == id);
        //}
    }
}
