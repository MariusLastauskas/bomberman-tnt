using GameServer.Models;
using GameServer.Models.AnstractFactory;
using System;
using System.Drawing;
using System.Threading;
using Xunit;

namespace Testing
{
    public class BombLogicTests
    {
        
        /// <summary>
        /// tests if player plants bombs where the user is
        /// </summary>
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
        /// <summary>
        /// tests if after explosion bomb counter goes up for a player
        /// </summary>
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
        /// <summary>
        /// tests if u can't place more bombs than you are supposed to
        /// </summary>
        /// <param name="plantBombCount"></param>
        [Theory]
        [InlineData(4)]
        [InlineData(3)]
        [InlineData(1)]

        public void PlayerPlantDifferentAmountOfBombs(int plantBombCount)
        {
            Map map = Map.GetInstance;
            map.CleanArena();
            Player player = new Player(3, 2, 3, 1, new Coordinates(6, 6));
            MapManagerStub mapManager = new MapManagerStub();
                int maxNumber = player.NumberOfBombs;
                for (int i = 0; i < plantBombCount; i++)
                {
                    mapManager.PlaceBomb(player);
                    player.Coordinates.PosY++;
                }
                int posBomb = player.PlacedBombCount;
                if (plantBombCount >= maxNumber)
                {
                    Assert.Equal(maxNumber, posBomb);
                }
                else
                {
                    Assert.Equal(plantBombCount, posBomb);
                }
            map.removeMap();
        }
        
        
        
        /// <summary>
        /// tests if player takes damage from the bomb
        /// </summary>
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
        /// <summary>
        /// tests if player does not recieve multiple dmg from multiple simultanius explosions
        /// </summary>
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
        /// <summary>
        /// tests if explosives do not damage unbreakable walls
        /// </summary>
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
        /// <summary>
        /// tests if bomb autodetonates after 3s time
        /// </summary>
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
        /// <summary>
        /// tests if bomb breaks breakable walls
        /// </summary>
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
        
        /// <summary>
        /// tests if explosion detonates another bomb
        /// </summary>
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
        /// <summary>
        /// tests if u can't have 2 bombs in a single space
        /// </summary>
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
            Thread.Sleep(1300);
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
