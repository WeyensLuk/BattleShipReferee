using BattleShipReferee.API.Business;
using BattleShipReferee.API.Domain;
using System.Web.Http;

namespace BattleShipReferee.API.Controllers
{
    [RoutePrefix("Register")]
    public class RegisterController : ApiController
    {
        [HttpPost, Route("", Name = "Register")]
        public void Register([FromBody]RegisterRequest registerRequest)
        {
            GameInstance.Instance.Register(registerRequest);
            if (!GameInstance.Instance.IsGameReady(registerRequest.GameId)) return;

            var gameState = GameInstance.Instance.GetGame(registerRequest.GameId);
            var player = new RandomTurnDeterminer().Determine(gameState);
            new TurnNotifier().Notify(player);
        }
    }
}