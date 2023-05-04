using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PressYourLuck.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace PressYourLuck.Models
{
    public class Game
    {
        private const int _NumCards = 12;
        private const int _WinChanceBase = 2;
        public int Id { get; set; }
        public List<Card> CardDeck { get; set; }
        public Player Player { get; set; }
        //public string PlayerName { get; set; }
        //public double totalCoins { get; set; }
        public double GameCoins { get; set; }
        public GameState GameStage { get; set; }
        public string GameStageMessage { get; set; }

        public void Start()
        {
            Player.CoinsTotal -= GameCoins;
            ShuffleCards();
            GameStage = GameState.START;
            GameStageMessage = "Game starts. Ready to play. Good luck!";
        }

     

        public void ShuffleCards(int numCards = _NumCards)
        {
            CardDeck = new List<Card>();
            Random r = new Random();
            for(int i =0; i < numCards; i++)
            {
                double randomValue = 0;
                if(r.Next(0, _WinChanceBase) == 0)
                {
                    randomValue = (r.NextDouble() + 0.5) * 2;
                }

                Card newCard = new Card()
                {
                    TileIndex = i,
                    Visible = false,
                    Value = randomValue
                };
                CardDeck.Add(newCard);
            }
        }

    

        public double RevealCard(int indexCardPicked)
        {
            double updateCoin = 0;
            if (indexCardPicked >= 0)
            {
                
                foreach(Card currentCard in CardDeck)
                {
                    if(currentCard.TileIndex == indexCardPicked)
                    {
                        currentCard.Visible = true;
                        if(currentCard.Value > 0)
                        {
                            GameStage = GameState.WIN;
                            DoubleTheDeck();
                            GameStageMessage = "You Win!";

                            
                            double updateCoins = GameCoins * currentCard.Value;
                            Math.Round(updateCoins, 2);
                            return updateCoins;
                            
                        }
                        else
                        {
                            GameStage = GameState.LOSE;
                            FlipTheDeck();
                            GameStageMessage = "You Lose!";

                            


                            double updateCoins = 0;
                            return updateCoins;
                        }
                    }
                }
            }
            return updateCoin;
        }

        public void DoubleTheDeck()
        {
            foreach(Card currentCard in CardDeck)
            {
                if(!currentCard.Visible && currentCard.Value > 0)
                {
                    currentCard.Value *= 2;
                }
            }
        }

        public void FlipTheDeck()
        {
            foreach(Card currentCard in CardDeck)
            {
                currentCard.Visible = true;
            }
        }

        public double CashOut()
        {
            Player.CoinsTotal += GameCoins;
            return Player.CoinsTotal;
        }
    }



    public enum GameState
    {
        END,
        START,
        WIN,
        LOSE
    }
}
