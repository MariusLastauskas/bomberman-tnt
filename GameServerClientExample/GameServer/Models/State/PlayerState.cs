using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameServer.Models.State
{
    public abstract class PlayerState
    {
        public abstract void Handle(Player context);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="state">1 - up, 2 - right, 3 - down, 4 - left</param>
        public abstract void GoNext(Player context, int state);
    }
}
