using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameServer.Models.GameObserver
{
    public abstract class Observer
    {
        public abstract void Update(MapObjectStub mapObject);
    }
}
