using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameServer.Models.Flyweight
{
    public class BreakableWallFlyweight : MapObject, IFlyweight
    {
        public bool Destroyable;
        /// <summary>
        /// Nesunaikinama siena
        /// </summary>
        public BreakableWallFlyweight()
        {
            isWalkable = false;
            Destroyable = true;
        }

        public void operation(Coordinates coordinates)
        {

        }

        public bool isDestroyable()
        {
            return Destroyable;
        }
    }
}
