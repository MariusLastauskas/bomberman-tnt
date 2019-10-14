/**
 * @(#) Wall.cs
 */

namespace GameServer.Models
{
	public class Wall : MapObject
	{
		private bool Destroyable;
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

        public void Hit()
        {
            if(Destroyable == true)
            {
                //destoy the wall
            }
        }
    }
}
