using GameServer.Models.Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameServer.Models.Visitor
{
    public interface IVisitor
    {
        void visit(Bomb bomb, CompositeExplosion composite);
        void visit(Wall wall, CompositeExplosion composite);
        void visit(Player player);
    }
}
