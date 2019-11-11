using System;
using System.Collections.Generic;

namespace GameServer.Models
{
    public class ConcreteMap : MapPrototype
    {
        public List<MapObject>[,] moList;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dWalls">If you want to build destructable walls dWalls = true</param>
        public ConcreteMap(bool dWalls)
        {
            if(dWalls == true)
            {
                MapBuilder newMap = new MapBuilder();
                newMap.BuildIndestructibleWalls().BuildDestructibleWalls().AddPlayers();
                moList = newMap.getMoList();
            }
            else if(dWalls == false)
            {
                MapBuilder newMap = new MapBuilder();
                newMap.BuildIndestructibleWalls().AddPlayers();
                moList = newMap.getMoList();
            }
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
