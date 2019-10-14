/**
 * @(#) BlueFactory.cs
 */

namespace GameServer.Models
{
    public class BlueFactory : AbstractFactory
    {

        public override MapObject getBomb(Player player)
        {
            return new BlueBomb(player);
        }

        public override MapObject getPlayer()
        {
            throw new System.NotImplementedException();
        }
    }

}
