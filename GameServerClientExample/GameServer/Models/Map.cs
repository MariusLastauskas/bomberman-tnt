using System;
using System.Collections.Generic;

namespace GameServer.Models
{
    public class Map
    {
        MapObject[,] mapContainer;
        
        public void AddMapObj(MapObject mapObj)
        { 
            Coordinates c = mapObj.GetCoordinates();
            long cx = c.PosX;
            long cy = c.PosY;

            mapContainer[cx, cy] = mapObj;
        }

        public Map(MapObject[,] mapObj)
        {
            
            this.mapContainer = mapObj;
        }

        public MapObject[,] getMapContainer()
        {
            return mapContainer;
        }
    }
}
