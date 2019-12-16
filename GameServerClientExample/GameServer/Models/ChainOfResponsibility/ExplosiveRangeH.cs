using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameServer.Models.ChainOfResponsibility
{
    public class ExplosiveRangeH : PowerUpHandler
    {
        public override void HandleRequest(PowerUp powerUp, Player player)
        {
            if (powerUp.getType() == 2)
            {
                player.IncreaseBombPower(1);
            }
            else if (successor != null)
            {
                successor.HandleRequest(powerUp, player);
            }
        }
    }
}
