namespace BattleShipReferee.API.Domain
{
    public class RegisterRequest
    {
        public bool[,] BattleShipGrid { get; set; }
        public string GameId { get; set; }
        public string PlayerId { get; set; }
        public string Url { get; set; }
    }
}