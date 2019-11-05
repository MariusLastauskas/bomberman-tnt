/**
 * @(#) BlueFactory.cs
 */

namespace GameServer.Models.AnstractFactory
{
    public class BlueFactory : AbstractFactory
    {

        public override MapObject getBomb(Player player)
        {
            return new BlueBomb(player);
        }

        public override MapObject getPlayer(Coordinates coordinates)
        {
            return new BluePlayer(1, 3, 3, 1, coordinates);
        }
    }

}
