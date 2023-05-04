﻿using Microsoft.AspNetCore.Http;
using PressYourLuck.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PressYourLuck.Helpers
{
    public static class GameHelper
    {
        private const int maxCards = 12;
        //This creates a collection of 12 tiles with randomly generated values
        public static List<Card> GenerateNewGame()
        {
            var tileList = new List<Card>();
            Random r = new Random();
            for (int i = 0; i < maxCards; i++)
            {
                double randomValue = 0;
                if (r.Next(1,4) != 1)
                {
                    randomValue = (r.NextDouble() + 0.5) * 2;
                }

                var tile = new Card()
                {
                    TileIndex = i,
                    Visible = false,
                    Value = randomValue
                };

                tileList.Add(tile);
            }
            return tileList;
        }

        /*
        * There are MANY other helpers you may want to create here.  I've created some
        *  placeholder as well as hints for others you may find useful:
        *
        * 
        * HINT: Remember that your HttpContext is not available in this class so you may
        * need to pass it into methods that need it!
        * 
        */


        // - GetCurrentGame - If there is no current game state in session Generate a New Game
        // and store it in session, otherwise deserialize the List<Tile> from session
        public static List<Card> GetCurrentGame(HttpContext httpContext)
        {
            var tileList = new List<Card>();

            //code goes here

            return tileList;
        }

        // - SaveCurrentGame - Save the current state of the game to session. 
        public static void SaveCurrentGame(/* parameters? */)
        {
            //code goes here
        }

       /* - PickATileAndUpdateGame - code that contains the game logic as 
        * mentioned in Part 4 of the assignment. Hint: you'll need to pass in the
        * id of the selected tile as one of the parameters.
        */
        public static double PickTileAndUpdateGame(/* parameters? */)
        {
            //code goes here
            return 0.0;
        }

        // - ClearCurrentGame - clear the current game state from session
        public static void ClearCurrentGame(/* parameters? */)
        {
            //code goes here
        }

        //- Finally, methods to serialize and deserialzie the Tile list.
        public static string SerializeTileList(/* parameters? */)
        {
            var result = "";
            //code goes here
            return result;
        }

        public static List<Card> DeserializeTileList(/* parameters? */)
        {
            var results = new List<Card>();
            //code goes here
            return results;
        }
    }
}
