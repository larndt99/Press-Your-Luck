//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using PressYourLuck.Data;
//using PressYourLuck.Models;
//using Microsoft.AspNetCore.Http;

//namespace PressYourLuck.Controllers
//{
//    public class PlayersController : Controller
//    {
//        private readonly GeneralContext _context;

//        public PlayersController(GeneralContext context)
//        {
//            _context = context;
//        }

       

       
//        // GET: Players/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: Players/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public IActionResult Create([Bind("Name,CoinsTotal")] Player player)
//        {
//            if (ModelState.IsValid) //cookies
//            {
//                //_context.Add(player);
//                //await _context.SaveChangesAsync();
//                var optCookie = new CookieOptions { Expires = DateTime.Now.AddDays(60) };
//                Response.Cookies.Append("PlayerName", player.Name, optCookie);
//                Response.Cookies.Append("CoinsTotal", player.CoinsTotal.ToString("N2"), optCookie);
               
//                return RedirectToAction("Index", "Home");


//                //return RedirectToAction(nameof(Index));
//            }
//            return View(player);
//        }

//        // GET: Players/Edit/5
//        public async Task<IActionResult> Edit(string id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var player = await _context.Player.FindAsync(id);
//            if (player == null)
//            {
//                return NotFound();
//            }
//            return View(player);
//        }

//        // POST: Players/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(string id, [Bind("Name,CoinsTotal")] Player player)
//        {
//            if (id != player.Name)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(player);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!PlayerExists(player.Name))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            return View(player);
//        }

//        private bool PlayerExists(string id)
//        {
//            return _context.Player.Any(e => e.Name == id);
//        }
//    }
//}
