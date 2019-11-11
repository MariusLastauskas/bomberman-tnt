using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameServer.Models.Adapter
{
    public class PlayerHitAdapter
    {
        public PlayerHitAdapter() { }

        public void Hit(Player player)
        {
            player.DecreaseHealth(1);
        }
    }
}
