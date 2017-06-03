using System.Web;
using System.Web.Http;
using System.Web.UI.WebControls;
using BattleShipReferee.API.Domain;

namespace BattleShipReferee.API.Controllers
{
    public class ShotController
    {
        [HttpPost]
        public void Shot(ShotRequest request)
        {
            var gameState = GameInstance.Instance.GetGame(request.GameId);
            var activePlayer = gameState.GetActivePlayer();
            if (activePlayer.Id != request.PlayerId) throw new HttpException(400, "It's not your turn! Keep it in your pants!");







            activePlayer.IsMyTurn = false;
        }
    }
}