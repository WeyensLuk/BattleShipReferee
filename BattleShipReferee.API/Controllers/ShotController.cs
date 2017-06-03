using BattleShipReferee.API.Business;
using BattleShipReferee.API.Domain;
using System.Web;
using System.Web.Http;

namespace BattleShipReferee.API.Controllers
{
    public class ShotController
    {
        [HttpPost]
        public void Shot(ShotRequest request)
        {
            var resultNotifier = new ResultNotifier();
            var gameState = GameInstance.Instance.GetGame(request.GameId);
            var activePlayer = gameState.ActivePlayer;
            if (activePlayer.Id != request.PlayerId) throw new HttpException(400, "It's not your turn! Keep it in your pants!");
            var result = gameState.InActivePlayer.ProcessShot(request.Location);
            resultNotifier.Notify(activePlayer, result.ToString());

            activePlayer.IsMyTurn = false;
            if (gameState.HasGameEnded())
            {
                resultNotifier.Notify(activePlayer, "You won!");
                resultNotifier.Notify(gameState.InActivePlayer, "You lose! SUCKER!");
            }
            else
            {
                new TurnNotifier().Notify(gameState.InActivePlayer);
            }
        }
    }
}