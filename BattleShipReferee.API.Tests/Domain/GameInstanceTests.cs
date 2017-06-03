using BattleShipReferee.API.Domain;
using NUnit.Framework;
using System.Collections.Generic;

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
                BattleShips = new List<BattleShip>()
            };
            GameInstance.Instance.Register(request);

            var gameState = GameInstance.Instance.GetGame("YoHans!");
            Assert.That(gameState.PlayerOne, Is.Not.Null);
            Assert.That(gameState.PlayerTwo, Is.Null);
            Assert.That(gameState.PlayerOne.Id, Is.EqualTo("Walter"));
            Assert.That(gameState.PlayerOne.Url, Is.EqualTo("huppeldepup"));
            Assert.That(gameState.PlayerOne.BoardState.BattleShips, Is.EqualTo(new List<BattleShip>()));
        }

        [Test]
        public void Add_AddSecondGame_AddsSecondGame()
        {
            GameInstance.Instance.Register(new RegisterRequest
            {
                GameId = "YoHans!",
                PlayerId = "Walter",
                Url = "huppeldepup",
                BattleShips = new List<BattleShip>()
            });

            var request = new RegisterRequest
            {
                GameId = "YoWalter!",
                PlayerId = "Luc",
                Url = "huppeldepup2",
                BattleShips = new List<BattleShip>()
            };
            GameInstance.Instance.Register(request);

            Assert.That(GameInstance.Instance.GetGame("YoHans!"), Is.Not.Null);
            Assert.That(GameInstance.Instance.GetGame("YoWalter!"), Is.Not.Null);
        }

        [Test]
        public void Add_AddSecondPlayer_AddsSecondPlayerToGame()
        {
            GameInstance.Instance.Register(new RegisterRequest
            {
                GameId = "YoHans!",
                PlayerId = "Walter",
                Url = "huppeldepup",
                BattleShips = new List<BattleShip>()
            });

            var request = new RegisterRequest
            {
                GameId = "YoHans!",
                PlayerId = "Luc",
                Url = "huppeldepup2",
                BattleShips = new List<BattleShip>()
            };
            GameInstance.Instance.Register(request);

            var gameState = GameInstance.Instance.GetGame("YoHans!");
            Assert.That(gameState.PlayerOne, Is.Not.Null);
            Assert.That(gameState.PlayerTwo, Is.Not.Null);
            Assert.That(gameState.PlayerTwo.Id, Is.EqualTo("Luc"));
            Assert.That(gameState.PlayerTwo.Url, Is.EqualTo("huppeldepup2"));
            Assert.That(gameState.PlayerTwo.BoardState.BattleShips, Is.EqualTo(new List<BattleShip>()));
        }
    }
}