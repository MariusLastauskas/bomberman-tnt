using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameServer.Models.Strategy
{
    public class SimplePlant : PlantBombStrategy
    {
        MapManagerStub map;

        public SimplePlant()
        {
            map = new MapManagerStub();
        }

        public override void PlantBomb(Player player)
        {
            if (player.PlacedBombCount < player.NumberOfBombs)
            {
                map.PlaceBomb(player);
            }
        }
    }
}
