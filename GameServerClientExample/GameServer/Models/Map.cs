using System;
using System.Collections.Generic;

namespace GameServer.Models
{
    /// <summary>
    /// singletone Map
    /// </summary>
    public sealed class Map
    {
        private static readonly object InstanceLock = new object();
        private List<MapObject>[,] mapContainer;
        private MapManagerStub MapManagerStub = new MapManagerStub();
        
        private Map()
        {

        }
        private static Map instance = null;
        public static Map GetInstance
        {
            get
            {
                if (instance == null)
                {
                    lock (InstanceLock)
                    {
                        if (instance == null)
                        {
                            MapBuilder builder = new MapBuilder();
                            builder.BuildIndestructibleWalls().BuildDestructibleWalls().AddPlayers();
                            instance = builder.build();
                        }
                    }
                }
                return instance;
            }
        }

        public void AddMapObj(MapObject mapObj)
        { 
            Coordinates c = mapObj.GetCoordinates();
            long cx = c.PosX;
            long cy = c.PosY;

            mapContainer[cx, cy].Add(mapObj);
        }
        /// <summary>
        /// reik perdaryt sita dali
        /// </summary>
        /// <param name="coordinates"></param>
        public bool HitMapObj(Coordinates coordinates)
        {
            List<MapObject> Objects = mapContainer[coordinates.PosX, coordinates.PosY];

            foreach (var mapObject in Objects)
            {
                if (mapObject is Player)
                {
                    Player player = mapObject as Player;
                    player.DecreaseHealth(1);
                }
                else if (mapObject is Wall)
                {
                    Wall wall = mapObject as Wall;
                    if (wall.isDestroyable())
                    {
                        MapManagerStub.DestroyWall(wall);
                        MapManagerStub.CreateExplosion(coordinates);
                    }
                    return false;
                }
                else if (mapObject is Bomb)
                {
                    Bomb bomb = mapObject as Bomb;
                    bomb.Explode();
                    MapManagerStub.CreateExplosion(coordinates);
                    return true;
                }
                else {
                }
            }
            MapManagerStub.CreateExplosion(coordinates);
            return true;
        }

        public Map(List<MapObject>[,] mapObj)
        {
            this.mapContainer = mapObj;
        }

        public List<MapObject>[,] getMapContainer()
        {
            return mapContainer;
        }
        public void removeMap()
        {
            instance = null;
            mapContainer = null;
        }
        public void removeObject(MapObject obj)
        {
            mapContainer[obj.Coordinates.PosX, obj.Coordinates.PosY].Remove(obj);
        }
        public void CleanArena()
        {
            mapContainer = new MapBuilder().getMoList();
            
        }

        public List<MapObject> getObjectIn(long x, long y)
        {
            return mapContainer[x, y];
        }

        public void addObject(MapObject mo, long x, long y)
        {
            mapContainer[x, y].Add(mo);
        }
    }
}
