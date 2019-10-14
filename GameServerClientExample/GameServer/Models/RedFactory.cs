/**
 * @(#) RedFactory.cs
 */

namespace GameServer.Models
{
    public class RedFactory : AbstractFactory
    {
        public override MapObject getBomb(Player player)
        {
            return new RedBomb(player);
        }

        public override MapObject getPlayer()
        {
            throw new System.NotImplementedException();
        }
    }

}
