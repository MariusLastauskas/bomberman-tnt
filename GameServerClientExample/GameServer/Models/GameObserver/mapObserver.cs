using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameServer.Models.GameObserver
{
    public class MapObserver : Observer
    {
        List<MapObjectStub> mapObjects;
        MapStub subject;

        public MapObserver(MapStub subject)
        {
            mapObjects = new List<MapObjectStub>();
            this.subject = subject;
        }

        public override void Update(MapObjectStub mapObject)
        {
            for (int i = 0; i < mapObjects.Count; i++)
            {
                if (mapObjects[i].id == mapObject.id)
                {
                    mapObjects[i] = mapObject;
                    break;
                }
                if (i == mapObjects.Count - 1)
                {
                    mapObjects.Add(mapObject);
                }
            }
        }
    }
}
