using System.Collections.Generic;
using System.Linq;

namespace BattleShipReferee.API.Domain
{
    public enum ShotResult
    {
        Hit,
        Miss,
        Sunk
    }

    public class BoardState
    {
        public BoardState(List<BattleShip> battleShips)
        {
            BattleShips = battleShips;
            HitLocations = new List<string>();
        }

        public List<BattleShip> BattleShips { get; set; }
        public List<string> HitLocations { get; set; }

        public bool AnyBoats()
        {
            return BattleShips.SelectMany(ship => ship.Fields).Any(field => !HitLocations.Contains(field));
        }

        public bool IsAlreadyShot(string location)
        {
            return HitLocations.Contains(location);
        }

        public ShotResult RegisterShot(string location)
        {
            return ShotResult.Hit;
        }
    }
}