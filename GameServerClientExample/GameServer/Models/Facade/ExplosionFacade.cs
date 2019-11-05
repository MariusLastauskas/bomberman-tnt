using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameServer.Models.Facade
{
    public class ExplosionFacade
    {
        MapManagerStub MapManagerStub = new MapManagerStub();

        public ExplosionFacade() { }
        public void Explode(Bomb bomb)
        {
            Map map = Map.GetInstance;
            RecursiveExplode(new Coordinates(bomb.Coordinates.PosX -1, bomb.Coordinates.PosY),-1, 0, bomb.getPower());
            RecursiveExplode(new Coordinates(bomb.Coordinates.PosX + 1, bomb.Coordinates.PosY), 1, 0, bomb.getPower());
            RecursiveExplode(new Coordinates(bomb.Coordinates.PosX, bomb.Coordinates.PosY -1), 0, -1, bomb.getPower());
            RecursiveExplode(new Coordinates(bomb.Coordinates.PosX, bomb.Coordinates.PosY +1), 0, 1, bomb.getPower());
            map.HitMapObj(bomb.Coordinates);
            map.removeObject(bomb);
        }
        private void RecursiveExplode(Coordinates cord, int X, int Y, int power)
        {
            Map map = Map.GetInstance;
            bool canContinue = map.HitMapObj(cord);
            if (canContinue && power > 1)
            {
                Coordinates newCords = new Coordinates(cord.PosX + X, cord.PosY + Y);
                RecursiveExplode(newCords, X, Y, power - 1);
            }
        }
    }
}
