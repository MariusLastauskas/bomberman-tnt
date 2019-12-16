using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameServer.Models.ChainOfResponsibility
{
    public class KickBombH : PowerUpHandler
    {
        public override void HandleRequest(PowerUp powerUp, Player player)
        {
            if (powerUp.getType() == 3)
            {
                player.SetCanKick();
            }
            else if (successor != null)
            {
                successor.HandleRequest(powerUp, player);
            }
        }
    }
}
