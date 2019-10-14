/**
 * @(#) Wall.cs
 */

namespace GameServer.Models
{
	public class Wall : MapObject
	{
		private bool Destroyable;
        public Wall()
        {
            isWalkable = false;
            Destroyable = false;    
        }
        public bool isDestroyable()
        {
            return Destroyable;
        }
        
    }
}
