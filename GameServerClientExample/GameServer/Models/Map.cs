using System;
using System.Collections.Generic;

namespace GameServer.Models
{
    public class Map
    {
        List<MapObject>[,] mapContainer;
        
        public void AddMapObj(MapObject mapObj)
        { 
            Coordinates c = mapObj.GetCoordinates();
            long cx = c.PosX;
            long cy = c.PosY;

            mapContainer[cx, cy].Add(mapObj);
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
