//using Microsoft.AspNetCore.Mvc;
//using PressYourLuck.Helpers;
//using PressYourLuck.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Newtonsoft.Json;


//namespace PressYourLuck.Controllers
//{
//    public class GameController : Controller
//    {
//        public IActionResult Index(List<Card> game)
//        {
//            List<Card> tileList = null;
//            if (game == null || game.Count == 0)
//            {
//                tileList = GameHelper.GenerateNewGame();

//            }
//            else
//            {
//                tileList = game;
//            }
//            SaveCurrentGame(tileList);
//            return View(tileList);
//        }

//        [HttpPost]
//        public IActionResult Index(int indexCard)
//        {
//            return View();
//        }

//        public IActionResult CardPicked(int indexCard)
//        {
//            List<Card> currGame = GetCurrentGame();
//            foreach (Card currCard in currGame)
//            {
//                if(currCard.TileIndex == indexCard)
//                {
//                    currCard.Visible = true;
//                    //multiple amount
//                }
//            }
//            return View(currGame);
//        }

//        private void SaveCurrentGame(List<Card> game)
//        {
//            string tmpGameInString = JsonConvert.SerializeObject(game);
//            HttpContext.Session.SetString("ssnCurrentGame", tmpGameInString);
//        }

//        private List<Card> GetCurrentGame()
//        {
//            List<Card> currentGame = null;
//            string tmpGameString = HttpContext.Session.GetString("ssnCurrentGame");
//            if (string.IsNullOrEmpty(tmpGameString))
//            {
//               currentGame = JsonConvert.DeserializeObject<List<Card>>(tmpGameString);
//            }

//            return currentGame;
//        }

//        private void ClearGame()
//        {
//            HttpContext.Session.Remove("ssnCurrentGame");
//        }
//    }
//}
