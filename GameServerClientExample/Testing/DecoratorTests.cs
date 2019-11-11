using System;
using System.Collections.Generic;
using System.Text;
using GameServer.Models;
using GameServer.Models.AnstractFactory;
using System.Drawing;
using System.Threading;
using Xunit;

namespace Testing
{
    public class DecoratorTests
    {
        [Fact]
        public void BombDecoratorTest()
        {
            Map map = Map.GetInstance;
            map.CleanArena();
            MapManagerStub mapManager = new MapManagerStub();
            BluePlayer player = new BluePlayer(1, 1, 1, 1, new Coordinates(5, 5));
            mapManager.PlaceBomb(player);
            BlueBomb bomb = map.getMapContainer()[5, 5][0] as BlueBomb;
            Assert.Equal(2, bomb.decorations.Count);
            map.removeMap();
        }
    }
}
