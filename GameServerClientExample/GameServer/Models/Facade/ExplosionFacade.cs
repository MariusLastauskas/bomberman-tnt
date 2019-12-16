using GameServer.Models.Adapter;
using GameServer.Models.Composite;
using GameServer.Models.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameServer.Models.Facade
{
    public class BombermanFacade
    {
        private MapManagerStub MapManagerStub = new MapManagerStub();
        private PlayerHitAdapter PlayerHitAdapter = new PlayerHitAdapter();
        private BombHitAdapter BombHitAdapter = new BombHitAdapter();
        private WallHitAdapter WallHitAdapter = new WallHitAdapter();
        private CompositeExplosion CompositeExplosion = new CompositeExplosion();
        private Visitorr Visitor = new Visitorr();
        private bool isFirst = false;
        public BombermanFacade() { }
        public CompositeExplosion Explode(Bomb bomb)
        {
            Map map = Map.GetInstance;
            RecursiveExplode(new Coordinates(bomb.Coordinates.PosX -1, bomb.Coordinates.PosY),-1, 0, bomb.GetPower());
            RecursiveExplode(new Coordinates(bomb.Coordinates.PosX + 1, bomb.Coordinates.PosY), 1, 0, bomb.GetPower());
            RecursiveExplode(new Coordinates(bomb.Coordinates.PosX, bomb.Coordinates.PosY -1), 0, -1, bomb.GetPower());
            RecursiveExplode(new Coordinates(bomb.Coordinates.PosX, bomb.Coordinates.PosY +1), 0, 1, bomb.GetPower());
            HitMapObj(bomb.Coordinates);
            map.removeObject(bomb);
            if (isFirst)
            {
                CompositeExplosion.setTimer();
            }
            return CompositeExplosion;
        }
        public void IsFirst()
        {
            isFirst = true;
        }
        private void RecursiveExplode(Coordinates cord, int X, int Y, int power)
        {
            Map map = Map.GetInstance;
            bool canContinue = HitMapObj(cord);
            if (canContinue && power > 1)
            {
                Coordinates newCords = new Coordinates(cord.PosX + X, cord.PosY + Y);
                RecursiveExplode(newCords, X, Y, power - 1);
            }
        }

        /// <summary>
        /// reik perdaryt sita dali
        /// </summary>
        /// <param name="coordinates"></param>
        public bool HitMapObj(Coordinates coordinates)
        {
            Map map = Map.GetInstance;
            List<MapObject> Objects = map.getMapContainer()[coordinates.PosX, coordinates.PosY];

            foreach (var mapObject in Objects)
            {
                if (mapObject is Player)
                {
                    Player player = mapObject as Player;
                    Visitor.visit(player);
                    PlayerHitAdapter.Hit(player);
                }
                else if (mapObject is Wall)
                {
                    Wall wall = mapObject as Wall;
                    Visitor.visit(wall, CompositeExplosion);
                    return false;
                }
                else if (mapObject is Bomb)
                {
                    Bomb bomb = mapObject as Bomb;
                    Visitor.visit(bomb, CompositeExplosion);
                    MapManagerStub.CreateExplosion(coordinates, CompositeExplosion);
                    return true;
                }
                else
                {
                }
            }
            MapManagerStub.CreateExplosion(coordinates, CompositeExplosion);
            return true;
        }
    }
}
