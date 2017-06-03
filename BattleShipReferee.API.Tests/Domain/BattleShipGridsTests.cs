using BattleShipReferee.API.Domain;
using NUnit.Framework;
using System.Collections.Generic;

namespace BattleShipReferee.API.Tests.Domain
{
    public class BattleShipGridsTests
    {
        [Test]
        public void AnyBoats_ABoat_True()
        {
            var battleShipGrid = new BoardState(new List<BattleShip> { new BattleShip { Fields = new List<string> { "A1" } } });

            Assert.That(battleShipGrid.AnyBoats(), Is.True);
        }

        [Test]
        public void AnyBoats_NoBoats_False()
        {
            var battleShipGrid = new BoardState(new List<BattleShip> { new BattleShip { Fields = new List<string> { "A1" } } });
            battleShipGrid.HitLocations.Add("A1");

            Assert.That(battleShipGrid.AnyBoats(), Is.False);
        }
    }
}