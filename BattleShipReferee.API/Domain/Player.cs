using System;

namespace BattleShipReferee.API.Domain
{
    public class Player
    {
        public BoardState BoardState { get; set; }
        public string Id { get; set; }
        public bool IsMyTurn { get; set; }
        public string Url { get; set; }

        public ShotResult ProcessShot(string location)
        {
            if (BoardState.IsAlreadyShot(location)) throw new ArgumentException($"{location} has already been shot");
            return BoardState.RegisterShot(location);
        }
    }
}