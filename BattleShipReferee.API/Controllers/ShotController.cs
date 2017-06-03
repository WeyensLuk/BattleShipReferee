using System.Web;
using System.Web.Http;
using System.Web.UI.WebControls;
using BattleShipReferee.API.Business;
using BattleShipReferee.API.Domain;

namespace BattleShipReferee.API.Controllers
{
    public class ShotController
    {
        [HttpPost]
        public void Shot(ShotRequest request)
        {
            var gameState = GameInstance.Instance.GetGame(request.GameId);
            var activePlayer = gameState.ActivePlayer;
            if (activePlayer.Id != request.PlayerId) throw new HttpException(400, "It's not your turn! Keep it in your pants!");
            var result = gameState.InActivePlayer.ProcessShot(request.Location);
            new TurnNotifier().Notify(gameState.InActivePlayer);
            new ResultNotifier().Notify(activePlayer, result);
            if (gameState.HasGameEnded())
            {
                
            }
            
            activePlayer.IsMyTurn = false;
        }
    }
}