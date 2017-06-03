using BattleShipReferee.API.Business;
using BattleShipReferee.API.Domain;
using System.Web;
using System.Web.Http;

namespace BattleShipReferee.API.Controllers
{
    [RoutePrefix("Shot")]
    public class ShotController : ApiController
    {
        [HttpPost, Route("", Name = "Shot")]
        public string Shot(ShotRequest request)
        {
            var gameState = GameInstance.Instance.GetGame(request.GameId);
            var activePlayer = gameState.ActivePlayer;
            if (activePlayer.Id != request.PlayerId) throw new HttpException(400, "It's not your turn! Keep it in your pants!");
            var result = gameState.InActivePlayer.ProcessShot(request.Location);

            if (gameState.HasGameEnded())
            {
                var resultNotifier = new ResultNotifier();
                resultNotifier.Notify(activePlayer, "You won!");
                resultNotifier.Notify(gameState.InActivePlayer, "You lose! SUCKER!");
            }
            else
            {
                new TurnNotifier().Notify(gameState.InActivePlayer);
            }
            activePlayer.IsMyTurn = false;
            return result.ToString();
        }
    }
}