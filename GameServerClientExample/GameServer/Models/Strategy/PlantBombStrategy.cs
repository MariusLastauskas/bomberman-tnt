using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameServer.Models.Strategy
{
    public abstract class PlantBombStrategy
    {
        public abstract void PlantBomb(Player player);
    }
}
