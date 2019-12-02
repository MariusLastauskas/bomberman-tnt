using GameServer.Models.Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameServer.Models.Adapter
{
    public class WallHitAdapter
    {
        public WallHitAdapter() { }

        public void Hit(Wall wall, CompositeExplosion compositeExplosion)
        {
            if (wall.isDestroyable())
            {
                MapManagerStub MapManagerStub = new MapManagerStub();
                MapManagerStub.CreateExplosion(wall.Coordinates, wall, compositeExplosion);
            }
        }
    }
}
