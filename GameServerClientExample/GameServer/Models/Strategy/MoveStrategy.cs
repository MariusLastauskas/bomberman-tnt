using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameServer.Models.Strategy
{
    public abstract class MoveStrategy
    {
        public abstract void Move(Player p, string direction);
    }
}
