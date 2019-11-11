

using GameServer.Models.Decorator;
/**
* @(#) BlueFactory.cs
*/
namespace GameServer.Models.AnstractFactory
{
    public class BlueFactory : AbstractFactory
    {

        public override MapObject getBomb(Player player)
        {
            BombDecorator bombIcon = new BombIcon();
            BombDecorator bombFire = new BombFire();
            BlueBomb bomb = new BlueBomb(player);
            bombIcon.SetComponent(bomb);
            bombFire.SetComponent(bombIcon);
            bombFire.Operation();
            return bomb;
        }

        public override MapObject getPlayer(Coordinates coordinates)
        {
            return new BluePlayer(1, 3, 3, 1, coordinates);
        }
    }

}
