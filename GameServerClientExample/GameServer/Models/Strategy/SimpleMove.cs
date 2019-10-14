using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameServer.Models.Strategy
{
    public class SimpleMove : MoveStrategy
    {
        MapManagerStub map;

        public SimpleMove()
        {
            map = new MapManagerStub();
        }

        public override void Move(Player p, string direction)
        {
            MapObject mo = map.getObjectIn(direction);
            if (mo == null || mo.isWalkable)
            {
                map.UpdatePlayerPos(p, direction);
            }
        }
    }
}
