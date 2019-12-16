using GameServer.Models.Adapter;
using GameServer.Models.Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameServer.Models.Visitor
{
    public class Visitorr : IVisitor
    {
        public void visit(Bomb bomb, CompositeExplosion composite)
        {
            BombHitAdapter bombHitAdapter = new BombHitAdapter();
            bombHitAdapter.Hit(bomb, composite);
        }

        public void visit(Wall wall, CompositeExplosion composite)
        {
            WallHitAdapter wallHitAdapter = new WallHitAdapter();
            wallHitAdapter.Hit(wall, composite);
        }

        public void visit(Player player)
        {
            PlayerHitAdapter playerHitAdapter = new PlayerHitAdapter();
            playerHitAdapter.Hit(player);
        }
    }
}
