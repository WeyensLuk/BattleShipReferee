using System.Collections.Generic;

namespace BattleShipReferee.API.Domain
{
    public class RegisterRequest
    {
        public List<BattleShip> BattleShips { get; set; }
        public string GameId { get; set; }
        public string PlayerId { get; set; }
        public string Url { get; set; }
    }
}