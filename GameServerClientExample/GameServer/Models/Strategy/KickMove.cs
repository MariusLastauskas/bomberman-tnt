using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameServer.Models.Strategy
{
    public class KickMove : MoveStrategy
    {
        MapManagerStub map;

        public KickMove()
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
            if (mo is Bomb)
            {
                (mo as Bomb).BeKicked(direction);
            }
        }
    }
}
