

using GameServer.Models.Decorator;
/**
* @(#) RedFactory.cs
*/
namespace GameServer.Models.AnstractFactory
{
    public class RedFactory : AbstractFactory
    {
        public override MapObject getBomb(Player player)
        {
            BombIcon bombIcon = new BombIcon();
            BombFire bombFire = new BombFire();
            RedBomb bomb = new RedBomb(player);
            bombIcon.SetComponent(bomb);
            bombFire.SetComponent(bombIcon);
            bombFire.Operation();
            return bomb;
        }

        public override MapObject getPlayer(Coordinates coordinates)
        {
            return new RedPlayer(1, 3, 3, 1, coordinates);
        }
    }

}
