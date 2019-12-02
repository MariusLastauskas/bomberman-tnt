using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameServer.Models.State
{
    interface IPlayerState
    {
        protected Player Player { get; set; };
        
    }
}
