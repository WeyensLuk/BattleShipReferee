using BattleShipReferee.API.Business;
using BattleShipReferee.API.Domain;
using Moq;
using NUnit.Framework;
using RestSharp;

namespace BattleShipReferee.API.Tests.Business
{
    public class TurnNotifierTests
    {
        [Test]
        public void Notify_Player_IsMyTurnIsTrue()
        {
            var restClientMock = new Mock<IRestClient>();
            var player = new Player
            {
                Url = "http://localhost:2000"
            };
            new TurnNotifier(restClientMock.Object).Notify(player);

            Assert.That(player.IsMyTurn, Is.True);
            restClientMock.Verify(mock => mock.Execute(It.IsAny<RestRequest>()));
        }
    }
}