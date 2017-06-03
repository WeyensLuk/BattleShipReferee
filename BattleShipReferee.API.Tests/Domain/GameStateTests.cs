using BattleShipReferee.API.Domain;
using NUnit.Framework;

namespace BattleShipReferee.API.Tests.Domain
{
    public class GameStateTests
    {
        [Test]
        public void IsGameReady_WhenNoPlayersAreSetup_False()
        {
            var gameState = new GameState();

            Assert.That(gameState.IsGameReady(), Is.False);
        }

        [Test]
        public void IsGameReady_WhenOnlyOnePlayerIsSetup_False()
        {
            var gameState = new GameState
            {
                PlayerOne = new Player()
            };

            Assert.That(gameState.IsGameReady(), Is.False);
        }

        [Test]
        public void IsGameReady_WhenBothPlayersAreSetup_True()
        {
            var gameState = new GameState
            {
                PlayerOne = new Player(),
                PlayerTwo = new Player()
            };

            Assert.That(gameState.IsGameReady(), Is.True);
        }

        [Test]
        public void GetActivePlayer_PlayerOneIsActive_ReturnsPlayerOne()
        {
            var playerOne = new Player
            {
                IsMyTurn = true
            };
            var gameState = new GameState
            {
                PlayerOne = playerOne,
                PlayerTwo = new Player()
            };

            Assert.That(gameState.GetActivePlayer(), Is.EqualTo(playerOne));
        }

        [Test]
        public void GetActivePlayer_PlayerTwoIsActive_ReturnsPlayerTwo()
        {
            var playerTwo = new Player
            {
                IsMyTurn = true
            };
            var gameState = new GameState
            {
                PlayerOne = new Player(),
                PlayerTwo = playerTwo
            };

            Assert.That(gameState.GetActivePlayer(), Is.EqualTo(playerTwo));
        }

        [Test]
        public void GetActivePlayer_NoOneIsActive_ThrowsException()
        {
            var gameState = new GameState
            {
                PlayerOne = new Player(),
                PlayerTwo = new Player()
            };

            Assert.That(() => { gameState.GetActivePlayer(); }, Throws.ArgumentException);
        }
    }
}