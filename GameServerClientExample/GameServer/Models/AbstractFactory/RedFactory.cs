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

        public override MapObject getPlayer()
        {
            return new Player(1, 1, 3, 1);
        }
    }

}
