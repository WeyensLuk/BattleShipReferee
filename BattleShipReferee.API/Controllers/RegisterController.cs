using System.Web.Http;
using BattleShipReferee.API.Business;
using BattleShipReferee.API.Domain;

namespace BattleShipReferee.API.Controllers
{
    public class RegisterController : ApiController
    {
        [HttpPost]
        public void Register(RegisterRequest registerRequest)
        {
            GameInstance.Instance.Register(registerRequest);
            if (!GameInstance.Instance.IsGameReady(registerRequest.GameId)) return;

            var gameState = GameInstance.Instance.GetGame(registerRequest.GameId);
            var player = new RandomTurnDeterminer().Determine(gameState);
            new TurnNotifier().Notify(player);
        }
    }
}