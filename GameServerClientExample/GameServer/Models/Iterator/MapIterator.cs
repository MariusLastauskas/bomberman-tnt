using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameServer.Models.Iterator
{
    public class MapIterator : IIteratable<MapObject>
    {
        private Map map { get; set; }
        private Coordinates indexCoordinates;
        private int index;

        public MapIterator(Map map)
        {
            this.map = map;
            indexCoordinates = new Coordinates(0, 0);
            index = 0;
        }

        public MapObject first()
        {
            indexCoordinates.PosX = 0;
            indexCoordinates.PosY = 0;
            index = 0;
            return map.getObjectIn(indexCoordinates)[index];
        }

        public MapObject next()
        {
            if (map.getObjectIn(indexCoordinates).Count > index + 1)
            {
                index++;
            } else
            {
                index = 0;
                if (indexCoordinates.PosX < 15)
                {
                    indexCoordinates.PosX++;
                } else
                {
                    indexCoordinates.PosX = 0;
                    indexCoordinates.PosY++;
                }
            }

            return map.getObjectIn(indexCoordinates)[index];
        }

        public bool hasNext()
        {
            if (indexCoordinates.PosX < 15 || indexCoordinates.PosY < 15)
            {
                return true;
            }
            return map.getObjectIn(indexCoordinates).Count > index + 1;
        }

        public void remove()
        {
            map.removeObject(map.getObjectIn(indexCoordinates)[index]);
        }
    }
}
