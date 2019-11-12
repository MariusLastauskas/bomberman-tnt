using System;
using System.Collections.Generic;

namespace GameServer.Models
{
    public class MapWithUndestructibleWalls : MapPrototype
    {
        public List<MapObject>[,] moList;
        
        public MapWithUndestructibleWalls()
        {
            MapBuilder newMap = new MapBuilder();
            newMap.BuildIndestructibleWalls().AddPlayers();
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
