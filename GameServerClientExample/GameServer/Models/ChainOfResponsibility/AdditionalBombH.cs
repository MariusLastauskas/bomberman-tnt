using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameServer.Models.ChainOfResponsibility
{
    public class AdditionalBombH : PowerUpHandler
    {
        public override void HandleRequest(PowerUp powerUp, Player player)
        {
            if (powerUp.getType() == 1)
            {
                player.IncreaseNumberOfBombs(1);
            }
            else if (successor != null)
            {
                successor.HandleRequest(powerUp, player);
            }
        }
    }
}
