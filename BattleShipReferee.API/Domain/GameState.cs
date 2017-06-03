using System;
using System.Media;

namespace BattleShipReferee.API.Domain
{
    public class GameState
    {
        public Player PlayerOne { get; set; }
        public Player PlayerTwo { get; set; }

        public bool IsGameReady()
        {
            return PlayerOne != null && PlayerTwo != null;
        }

        public Player GetActivePlayer()
        {
            if (PlayerOne.IsMyTurn) return PlayerOne;
            if (PlayerTwo.IsMyTurn) return PlayerTwo;
            throw new ArgumentException("Game is finished.");
        }
    }
}