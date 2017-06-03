using System;

namespace BattleShipReferee.API.Domain
{
    public class GameState
    {
        public Player ActivePlayer
        {
            get
            {
                if (PlayerOne.IsMyTurn && PlayerTwo.IsMyTurn) throw new ArgumentException("All players are active?????");
                if (PlayerOne.IsMyTurn) return PlayerOne;
                if (PlayerTwo.IsMyTurn) return PlayerTwo;
                throw new ArgumentException("No player is active.");
            }
        }

        public Player InActivePlayer
        {
            get
            {
                if (!PlayerOne.IsMyTurn && !PlayerTwo.IsMyTurn) throw new ArgumentException("No player is active.");
                if (!PlayerOne.IsMyTurn) return PlayerOne;
                if (!PlayerTwo.IsMyTurn) return PlayerTwo;
                throw new ArgumentException("All players are active?????");
            }
        }

        public Player PlayerOne { get; set; }
        public Player PlayerTwo { get; set; }

        public bool HasGameEnded()
        {
            return !PlayerOne.BoardState.AnyBoats() && !PlayerTwo.BoardState.AnyBoats();
        }

        public bool IsGameReady()
        {
            return PlayerOne != null && PlayerTwo != null;
        }
    }
}