using System;
using System.Collections.Generic;

namespace GameServer.Models
{
    public class MapWithDestructibleWalls : MapPrototype
    {
        public List<MapObject>[,] moList;
        
        public MapWithDestructibleWalls()
        {
            MapBuilder newMap = new MapBuilder();
            newMap.BuildIndestructibleWalls().BuildDestructibleWalls().AddPlayers();
            moList = newMap.getMoList();
        }

        public List<MapObject>[,] getMoList()
        {
            return moList;
        }

        public override MapPrototype Clone()
        {
            return MemberwiseClone() as MapPrototype;
        }
    }
}
