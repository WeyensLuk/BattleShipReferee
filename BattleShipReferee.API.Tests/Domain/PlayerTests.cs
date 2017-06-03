using BattleShipReferee.API.Domain;
using NUnit.Framework;
using System.Collections.Generic;

namespace BattleShipReferee.API.Tests.Domain
{
    public class PlayerTests
    {
        [Test]
        public void ProcessShot_DoubleShot_ThrowsException()
        {
            var ship = new BattleShip
            {
                Fields = new List<string> { "A1" }
            };

            var player = new Player
            {
                BoardState = new BoardState(new List<BattleShip> { ship })
            };

            player.ProcessShot("A1");

            Assert.That(() => { player.ProcessShot("A1"); }, Throws.ArgumentException);
        }

        [Test]
        public void ProcessShot_Hit_ReturnsHit()
        {
            var ship = new BattleShip
            {
                Fields = new List<string> { "A1", "A2" }
            };

            var player = new Player
            {
                BoardState = new BoardState(new List<BattleShip> { ship })
            };

            var result = player.ProcessShot("A1");

            Assert.That(result, Is.EqualTo(ShotResult.Hit));
        }

        [Test]
        public void ProcessShot_Miss_ReturnsMiss()
        {
            var player = new Player
            {
                BoardState = new BoardState(new List<BattleShip>())
            };

            var result = player.ProcessShot("A5");

            Assert.That(result, Is.EqualTo(ShotResult.Miss));
        }

        [Test]
        public void ProcessShot_Sunk_ReturnsSunk()
        {
            var ship = new BattleShip
            {
                Fields = new List<string> { "A1" }
            };

            var player = new Player
            {
                BoardState = new BoardState(new List<BattleShip> { ship })
            };

            var result = player.ProcessShot("A1");

            Assert.That(result, Is.EqualTo(ShotResult.Sunk));
        }
    }
}