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
            RecursiveExplode(bomb.Coordinates, -1, 0, bomb.getPower());
            RecursiveExplode(bomb.Coordinates, 1, 0, bomb.getPower());
            RecursiveExplode(bomb.Coordinates, 0, -1, bomb.getPower());
            RecursiveExplode(bomb.Coordinates, 0, 1, bomb.getPower());

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
