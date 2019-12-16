using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameServer.Models.ChainOfResponsibility
{
    public abstract class PowerUpHandler
    {
        protected PowerUpHandler successor;

        public void SetSuccessor(PowerUpHandler _successor)
        {
            successor = _successor;
        }

        public abstract void HandleRequest(PowerUp powerUp, Player player);
    }
}
