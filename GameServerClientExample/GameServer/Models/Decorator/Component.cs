using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameServer.Models.Decorator
{
    public abstract class Component
    {
        public List<string> decorations = new List<string>();

        public abstract void Operation();
        //void Operation();
    }
}
