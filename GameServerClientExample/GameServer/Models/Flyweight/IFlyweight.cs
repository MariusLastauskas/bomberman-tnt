using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameServer.Models.Flyweight
{
    interface IFlyweight
    {
        void operation(Coordinates coordinates);
    }
}
