using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameServer.Models.Memento
{
    public class Memento
    {
        public readonly int Timer;
        public Memento(int timer)
        {
            this.Timer = timer;
        }
    }
}
