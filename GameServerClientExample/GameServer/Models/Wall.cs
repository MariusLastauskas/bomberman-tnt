/**
 * @(#) Wall.cs
 */

namespace GameServer.Models
{
	public class Wall : MapObject
	{
		public bool Destroyable;
        /// <summary>
        /// Nesunaikinama siena
        /// </summary>
        public Wall()
        {
            isWalkable = false;
            Destroyable = false;    
        }
        /// <summary>
        /// Sunaikinama siena
        /// </summary>
        /// <param name="destroyable"></param>
        public Wall(bool destroyable)
        {
            isWalkable = false;
            Destroyable = true;
        }

        public Wall(bool destroyable, Coordinates coord) :base(coord)
        {
            isWalkable = false;
            Destroyable = true;
        }

        public bool isDestroyable()
        {
            return Destroyable;
        }
        
    }
}
