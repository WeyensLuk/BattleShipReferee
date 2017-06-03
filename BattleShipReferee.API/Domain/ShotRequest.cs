namespace BattleShipReferee.API.Domain
{
    public class ShotRequest
    {
        public string GameId { get; set; }
        public string PlayerId { get; set; }
        public string Location { get; set; }
    }
}