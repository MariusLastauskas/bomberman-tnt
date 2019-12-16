using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameServer.Models.ChainOfResponsibility
{
    public class ThrowBombH : PowerUpHandler
    {
        public override void HandleRequest(PowerUp powerUp, Player player)
        {
            if (powerUp.getType() == 4)
            {
                player.SetCanThrow();
            }
            else if (successor != null)
            {
                successor.HandleRequest(powerUp, player);
            }
        }
    }
}
