/**
 * @(#) RedFactory.cs
 */

namespace GameServer.Models.AnstractFactory
{
    public class RedFactory : AbstractFactory
    {
        public override MapObject getBomb(Player player)
        {
            return new RedBomb(player);
        }

        public override MapObject getPlayer(Coordinates coordinates)
        {
            return new RedPlayer(1, 3, 3, 1, coordinates);
        }
    }

}
