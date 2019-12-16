using GameServer.Models.Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameServer.Models.Visitor
{
    public interface IVisitable
    {
        void accept(IVisitor visitor, CompositeExplosion composite);
    }
}
