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
                            builder.BuildIndestructibleWalls().BuildDestructibleWalls();
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
        public void HitMapObj(Coordinates coordinates)
        {
            List<MapObject> Objects = mapContainer[coordinates.PosX, coordinates.PosY];

            foreach (var mapObject in Objects)
            if(mapObject is Player)
            {
                Player player = mapObject as Player;
                player.DecreaseHealth(1);
            } else if (mapObject is Wall)
            {
                Wall wall = mapObject as Wall;
                if(wall.isDestroyable())
                {
                    mapContainer[coordinates.PosX, coordinates.PosY] = null;
                }
            }
        }

        public Map(List<MapObject>[,] mapObj)
        {
            this.mapContainer = mapObj;
        }

        public List<MapObject>[,] getMapContainer()
        {
            return mapContainer;
        }
    }
}
