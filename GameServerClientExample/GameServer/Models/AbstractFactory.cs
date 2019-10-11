/**
 * @(#) AbstractFactory.cs
 */

namespace GameServer.Models
{
	public abstract class AbstractFactory
	{
		public abstract MapObject getBomb(Player player);
		
		public abstract MapObject getPlayer(  );
		
	}
	
}
