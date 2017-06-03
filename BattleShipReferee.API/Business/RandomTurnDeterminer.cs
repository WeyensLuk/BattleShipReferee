using System;
using BattleShipReferee.API.Domain;

namespace BattleShipReferee.API.Business
{
    public class RandomTurnDeterminer
    {
        public Player Determine(GameState gameState)
        {
            var randomNumber = new Random().Next(0, 1000);
            return randomNumber >= 500 ? gameState.PlayerOne : gameState.PlayerTwo;
        }
    }
}