using GameServer.Models;
using GameServer.Models.AnstractFactory;
using System;
using System.Drawing;
using System.Threading;
using Xunit;

namespace Testing
{
    public class UnitTest1
    {

        [Fact]
        public void BluePlayerCreateTest()
        {
            Map map = Map.GetInstance;
            MapManagerStub mapManager = new MapManagerStub();
            Assert.True(map.getMapContainer()[1, 1][0] is BluePlayer, "not a blue player");
            map.removeMap();
        }

        [Fact]
        public void RedPlayerCreateTest()
        {
            Map map = Map.GetInstance;
            MapManagerStub mapManager = new MapManagerStub();
            Assert.True(map.getMapContainer()[13, 13][0] is RedPlayer, "not a red player");
            map.removeMap();
        }

        [Fact]
        public void BluePlayerColorTest()
        {
            Map map = Map.GetInstance;
            MapManagerStub mapManager = new MapManagerStub();
            BluePlayer player = map.getMapContainer()[1, 1][0] as BluePlayer;
            Assert.Equal(Color.FromKnownColor(KnownColor.Blue), player.GetColor());
            map.removeMap();
        }

        [Fact]
        public void RedPlayerColorTest()
        {
            Map map = Map.GetInstance;
            MapManagerStub mapManager = new MapManagerStub();
            RedPlayer player = map.getMapContainer()[13, 13][0] as RedPlayer;
            Assert.Equal(Color.FromKnownColor(KnownColor.Red), player.GetColor());
            map.removeMap();
        }

        [Fact]
        public void BluePlayerPlantBlueBombTest()
        {
            Map map = Map.GetInstance;
            MapManagerStub mapManager = new MapManagerStub();
            if (map.getMapContainer()[1, 1][0] is Player)
            {
                Player player = map.getMapContainer()[1, 1][0] as Player;
                mapManager.PlaceBomb(player);
                Assert.True(map.getMapContainer()[1, 1][1] is BlueBomb, "not a blue bomb");
            }
            else
                Assert.True(false, "player not found");
            map.removeMap();
        }

        [Fact]
        public void PlayerPlantBombOnUserTest()
        {
            Map map = Map.GetInstance;
            MapManagerStub mapManager = new MapManagerStub();
            if (map.getMapContainer()[1, 1][0] is Player)
            {
                Player player = map.getMapContainer()[1, 1][0] as Player;
                int preBomb = player.PlacedBombCount;
                mapManager.PlaceBomb(player);
                int posBomb = player.PlacedBombCount;
                Assert.Equal(preBomb + 1, posBomb);
            }
            else
                Assert.True(false, "player not found");
            map.removeMap();
        }

        [Fact]
        public void PlayerPlantBombCountAfterExplosionTest()
        {
            Map map = Map.GetInstance;
            MapManagerStub mapManager = new MapManagerStub();
            if (map.getMapContainer()[1, 1][0] is Player)
            {
                Player player = map.getMapContainer()[1, 1][0] as Player;
                int preBomb = player.PlacedBombCount;
                mapManager.PlaceBomb(player);
                Bomb bomb = map.getMapContainer()[1, 1][1] as Bomb;
                bomb.Explode();
                int posBomb = player.PlacedBombCount;
                Assert.Equal(preBomb, posBomb);
            }
            else
                Assert.True(false, "player not found");
            map.removeMap();
        }

        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        [InlineData(4)]

        public void PlayerPlantDifferentAmountOfBombs(int plantBombCount)
        {
            Map map = Map.GetInstance;
            MapManagerStub mapManager = new MapManagerStub();
            if (map.getMapContainer()[1, 1][0] is Player)
            {
                Player player = map.getMapContainer()[1, 1][0] as Player;
                int maxNumber = player.NumberOfBombs;
                for (int i = 0; i < plantBombCount; i++)
                {
                    mapManager.PlaceBomb(player);
                }
                int posBomb = player.PlacedBombCount;
                if (posBomb >= maxNumber)
                {
                    Assert.True(maxNumber == posBomb, "planted more bombs than should");
                }
                else
                {
                    Assert.True(plantBombCount == posBomb, "not enough bombs planted");
                }
            }
            else
                Assert.True(false, "player not found");
            map.removeMap();
        }

        [Fact]
        public void RedPlayerPlantRedBombTest()
        {
            Map map = Map.GetInstance;
            MapManagerStub mapManager = new MapManagerStub();
            if (map.getMapContainer()[13, 13][0] is Player)
            {
                Player player = map.getMapContainer()[13, 13][0] as Player;
                mapManager.PlaceBomb(player);
                var container = map.getMapContainer();
                Assert.True(container[13, 13][1] is RedBomb, "is not a red bomb");
            }
            else
                Assert.True(false, "player not found");
            map.removeMap();
        }

        [Fact]
        public void RedBombGetColorTest()
        {
            Map map = Map.GetInstance;
            MapManagerStub mapManager = new MapManagerStub();
            if (map.getMapContainer()[13, 13][0] is Player)
            {
                Player player = map.getMapContainer()[13, 13][0] as Player;
                mapManager.PlaceBomb(player);
                var container = map.getMapContainer();
                RedBomb bomb = container[13, 13][1] as RedBomb;
                Assert.Equal(Color.FromKnownColor(KnownColor.Red), bomb.GetColor());
            }
            else
                Assert.True(false, "player not found");
            map.removeMap();
        }

        [Fact]
        public void BlueBombGetColorTest()
        {
            Map map = Map.GetInstance;
            MapManagerStub mapManager = new MapManagerStub();
            if (map.getMapContainer()[1, 1][0] is Player)
            {
                Player player = map.getMapContainer()[1, 1][0] as Player;
                mapManager.PlaceBomb(player);
                var container = map.getMapContainer();
                BlueBomb bomb = container[1, 1][1] as BlueBomb;
                Assert.Equal(Color.FromKnownColor(KnownColor.Blue), bomb.GetColor());
            }
            else
                Assert.True(false, "player not found");
            map.removeMap();
        }

        [Fact]
        public void BombExplosionOnPlayerTest()
        {
            Map map = Map.GetInstance;
            MapManagerStub mapManager = new MapManagerStub();
            if (map.getMapContainer()[13, 13][0] is Player)
            {
                Player player = map.getMapContainer()[13, 13][0] as Player;
                mapManager.PlaceBomb(player);
                int initial = player.Health;
                Bomb bomb = map.getMapContainer()[13, 13][1] as Bomb;
                bomb.Explode();
                int after = player.Health;
                var container = map.getMapContainer();
                Assert.Equal(initial - 1, after);
            }
            else
                Assert.True(false, "player not found");
            map.removeMap();
        }

        [Fact]
        public void BombMultipleExplosionOnPlayerTest()
        {
            Map map = Map.GetInstance;
            MapManagerStub mapManager = new MapManagerStub();
            if (map.getMapContainer()[13, 13][0] is Player)
            {
                Player player = map.getMapContainer()[13, 13][0] as Player;
                Player player2 = new Player(3, 3, 3, 3, new Coordinates(12, 13));
                mapManager.PlaceBomb(player);
                mapManager.PlaceBomb(player2);
                int initial = player.Health;
                Bomb bomb = map.getMapContainer()[13, 13][1] as Bomb;
                bomb.Explode();
                int after = player.Health;
                var container = map.getMapContainer();
                Assert.Equal(initial - 1, after);
            }
            else
                Assert.True(false, "player not found");
            map.removeMap();
        }

        [Fact]
        public void BombExplosionNearUnbreakableWallTest()
        {
            Map map = Map.GetInstance;
            MapManagerStub mapManager = new MapManagerStub();
            if (map.getMapContainer()[13, 13][0] is Player)
            {
                Player player = map.getMapContainer()[13, 13][0] as Player;
                mapManager.PlaceBomb(player);
                Bomb bomb = map.getMapContainer()[13, 13][1] as Bomb;
                bomb.Explode();
                Assert.Single(map.getMapContainer()[13, 14]);
            }
            else
                Assert.True(false, "player not found");
            map.removeMap();
        }

        [Fact]
        public void BombAutoDetonateTest()
        {
            Map map = Map.GetInstance;
            MapManagerStub mapManager = new MapManagerStub();
            if (map.getMapContainer()[13, 13][0] is Player)
            {
                Player player = map.getMapContainer()[13, 13][0] as Player;
                mapManager.PlaceBomb(player);
                Thread.Sleep(3100);
                Assert.True(map.getMapContainer()[13, 13][1] is Explosion);
            }
            else
                Assert.True(false, "did not detonate");
            map.removeMap();
        }

        [Fact]
        public void BombExplosionNearBreakableWallTest()
        {
            Map map = Map.GetInstance;
            MapManagerStub mapManager = new MapManagerStub();
            if (map.getMapContainer()[13, 13][0] is Player)
            {
                Player player = map.getMapContainer()[13, 13][0] as Player;
                mapManager.PlaceBomb(player);
                Bomb bomb = map.getMapContainer()[13, 13][1] as Bomb;
                map.AddMapObj(new Wall(true, new Coordinates(12, 13)));
                bomb.Explode();
                Thread.Sleep(1100);
                //po sprogimo sienos nebelieka arba po jos lieka powerUp
                if (map.getMapContainer()[12, 13].Count == 1)
                {
                    Assert.True(true);
                }
                else if (map.getMapContainer()[12, 13].Count == 2)
                {
                    Assert.True(map.getMapContainer()[12, 13][0] is PowerUp || map.getMapContainer()[12, 13][1] is PowerUp, "nevienas ne powerUp, bet 2");
                }
                else
                {
                    Assert.True(false, "sienai susprogus atsirado daugiau arba maziau obijektu nei turejo");
                }

                Assert.Single(map.getMapContainer()[13, 14]);
            }
            else
                Assert.True(false, "player not found");
            map.removeMap();
        }
        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        public void ExplosionLengthTest(int pover)
        {
            Map map = Map.GetInstance;
            map.CleanArena();
            Player player = new Player(1, pover, 3, 1, new Coordinates(6, 6));
            Bomb bomb = new Bomb(player);
            map.AddMapObj(bomb);
            bomb.Explode();
            int cnt = 0;
            foreach (var list in map.getMapContainer())
            {
                cnt += list.Count;
            }
            Assert.Equal(1 + pover * 4, cnt);
            map.removeMap();
        }

        [Fact]
        public void ExplosionDetonateBombTest()
        {
            Map map = Map.GetInstance;
            map.CleanArena();
            Player player = new Player(1, 2, 3, 1, new Coordinates(6, 6));
            Player player2 = new Player(1, 2, 3, 1, new Coordinates(8, 6));
            Bomb bomb = new Bomb(player);
            Bomb bomb2 = new Bomb(player2);
            map.AddMapObj(bomb);
            map.AddMapObj(bomb2);
            bomb.Explode();
            int cnt = 0;
            foreach (var list in map.getMapContainer())
            {
                cnt += list.Count;
            }
            Assert.Equal((1 + 2 * 4) * 2, cnt);
            map.removeMap();
        }

        [Fact]
        public void TwoBombsInSingleSpace()
        {
            Map map = Map.GetInstance;
            MapManagerStub mapManager = new MapManagerStub();
            if (map.getMapContainer()[13, 13][0] is Player)
            {
                Player player = map.getMapContainer()[13, 13][0] as Player;
                int pre = map.getMapContainer()[13, 13].Count;
                mapManager.PlaceBomb(player);
                mapManager.PlaceBomb(player);
                int pos = map.getMapContainer()[13, 13].Count;
                Assert.Equal(pre + 1, pos);
            }
            map.removeMap();
        }

        [Fact]
        public void doubleExplosionInRowWallDestruction()
        {
            Map map = Map.GetInstance;
            map.CleanArena();
            Player player = new Player(1, 3, 3, 1, new Coordinates(6, 6));
            Player player2 = new Player(1, 2, 3, 1, new Coordinates(7, 6));
            Wall wall1 = new Wall(true, new Coordinates(8, 6));
            Wall wall2 = new Wall(true, new Coordinates(9, 6));
            Bomb bomb = new Bomb(player);
            Bomb bomb2 = new Bomb(player2);
            map.AddMapObj(wall1);
            map.AddMapObj(wall2);
            map.AddMapObj(bomb);
            map.AddMapObj(bomb2);
            bomb.Explode();
            Thread.Sleep(1100);
            int cnt = 0;
            foreach (var list in map.getMapContainer())
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if(list[i] is Wall)
                    {
                        cnt++;
                    }
                }
            }
            Assert.Equal(1, cnt);
            map.removeMap();
        }
    }
}
