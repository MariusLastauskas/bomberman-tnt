using System;
using GameServer.Models.GameObserver;

namespace GameServer.Models
{
    public class MapStub : Subject
    {
        public MapStub()
        {
            Attach(new MapObserver(this));
        }
    }
}
