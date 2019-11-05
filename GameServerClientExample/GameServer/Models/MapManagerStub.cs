using GameServer.Models.AnstractFactory;
using GameServer.Models.Facade;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace GameServer.Models
{
    public class MapManagerStub
    {
        AbstractFactory BlueFactory = new BlueFactory();
        AbstractFactory RedFactory = new RedFactory();
        Random rand = new Random();
        MapBuilder builder = new MapBuilder();
        private readonly AsyncLock m_lock = new AsyncLock();


        public MapManagerStub()     // Dar reikia implementuoti
        {

        }

        public Map BuildMap()  
        {
            return Map.GetInstance;
        }

        public bool UpdatePlayerPos(Player p, string direction)  // Dar reikia implementuoti
        {
            return true;
        }

        public void PlaceBomb(Player p)
        {
            MapObject k;
            if (p.NumberOfBombs > p.PlacedBombCount)
            {
                if (p is BluePlayer)
                {
                    k = BlueFactory.getBomb(p);
                }
                else
                {
                    k = RedFactory.getBomb(p);
                }
                Map map = Map.GetInstance;
                map.AddMapObj(k);
            }
        }
        public void CreateExplosion(Coordinates cord)
        {
            Explosion explosion = new Explosion(cord);
            Map map = Map.GetInstance;
            map.AddMapObj(explosion);
        }

        public void CreateExplosion(Coordinates cord, Wall wall)
        {
            Explosion explosion = new Explosion(cord, wall);
            Map map = Map.GetInstance;
            map.AddMapObj(explosion);
        }

        public void CreatePowerUp(Coordinates cord)
        {
            int type = rand.Next(0, 4);
            PowerUp powerUp = new PowerUp(type, cord);
            Map map = Map.GetInstance;
            map.AddMapObj(powerUp);
        }
        public async void DestroyWall(MapObject mapObject)
        {
            using (await m_lock.LockAsync())
            {
                if (mapObject != null)
                {
                    Map map = Map.GetInstance;
                    if (mapObject is Wall)
                    {
                        Wall wall = mapObject as Wall;
                        if (wall.isDestroyable())
                        {
                            var mapContainer = map.getMapContainer();
                            int cnt = 0;
                            for (int i = 0; i < mapContainer[wall.Coordinates.PosX, wall.Coordinates.PosY].Count; i++)
                            {
                                if (mapContainer[wall.Coordinates.PosX, wall.Coordinates.PosY][i] is Wall)
                                {
                                    cnt++;
                                }
                            }
                            if (cnt > 0)
                            {
                                mapContainer[wall.Coordinates.PosX, wall.Coordinates.PosY].Remove(wall);
                                if (rand.Next(1, 5) < 5)
                                    CreatePowerUp(mapObject.Coordinates);
                            }
                        }
                    }
                }
            }
        }

        public MapObject getObjectIn(string direction)
        {
            return null;
        }

        public void RemoveThis(MapObject obj)
        {
            Map map = Map.GetInstance;
            map.removeObject(obj);
        }
    }
}
