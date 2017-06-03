using BattleShipReferee.API.Domain;
using NUnit.Framework;

namespace BattleShipReferee.API.Tests.Domain
{
    public class GameInstanceTests
    {
        [Test]
        public void Add_AddNewGame_CreatesPlayerOneForNewGame()
        {
            var request = new RegisterRequest
            {
                GameId = "YoHans!",
                PlayerId = "Walter",
                Url = "huppeldepup",
                BattleShipGrid = new bool[10, 10]
            };
            GameInstance.Instance.Register(request);

            var gameState = GameInstance.Instance.GetGame("YoHans!");
            Assert.That(gameState.PlayerOne, Is.Not.Null);
            Assert.That(gameState.PlayerTwo, Is.Null);
            Assert.That(gameState.PlayerOne.Id, Is.EqualTo("Walter"));
            Assert.That(gameState.PlayerOne.Url, Is.EqualTo("huppeldepup"));
            Assert.That(gameState.PlayerOne.BattleShipGrid, Is.EqualTo(new FieldState[10, 10]));
        }

        [Test]
        public void Add_AddSecondPlayer_AddsSecondPlayerToGame()
        {
            GameInstance.Instance.Register(new RegisterRequest
            {
                GameId = "YoHans!",
                PlayerId = "Walter",
                Url = "huppeldepup",
                BattleShipGrid = new bool[10, 10]
            });

            var request = new RegisterRequest
            {
                GameId = "YoHans!",
                PlayerId = "Luc",
                Url = "huppeldepup2",
                BattleShipGrid = new bool[10, 10]
            };
            GameInstance.Instance.Register(request);


            var gameState = GameInstance.Instance.GetGame("YoHans!");
            Assert.That(gameState.PlayerOne, Is.Not.Null);
            Assert.That(gameState.PlayerTwo, Is.Not.Null);
            Assert.That(gameState.PlayerTwo.Id, Is.EqualTo("Luc"));
            Assert.That(gameState.PlayerTwo.Url, Is.EqualTo("huppeldepup2"));
            Assert.That(gameState.PlayerTwo.BattleShipGrid, Is.EqualTo(new FieldState[10, 10]));
        }

        [Test]
        public void Add_AddSecondGame_AddsSecondGame()
        {
            GameInstance.Instance.Register(new RegisterRequest
            {
                GameId = "YoHans!",
                PlayerId = "Walter",
                Url = "huppeldepup",
                BattleShipGrid = new bool[10, 10]
            });

            var request = new RegisterRequest
            {
                GameId = "YoWalter!",
                PlayerId = "Luc",
                Url = "huppeldepup2",
                BattleShipGrid = new bool[10, 10]
            };
            GameInstance.Instance.Register(request);


            Assert.That(GameInstance.Instance.GetGame("YoHans!"), Is.Not.Null);
            Assert.That(GameInstance.Instance.GetGame("YoWalter!"), Is.Not.Null);
        }
    }
}