/**
 * @(#) PowerUp.cs
 */

namespace GameServer.Models
{
	public class PowerUp : MapObject
	{
        /// <summary>
        /// Types: 0 - speed, 1 - additionalBombs, 2 - explosiveRange, 3 - KickBomb, 4 - throwBomb
        /// </summary>
        private int Type { get; set; }

        public PowerUp(int type, Coordinates coords) : base (coords)
        {
            Type = type;
        }

        public int getType()
        {
            return Type;
        }

    }
	
}
