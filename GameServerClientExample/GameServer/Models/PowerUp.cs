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
        public int Type { get; set; }
        public string title;

        public PowerUp(int type, Coordinates coords) : base (coords)
        {
            switch (type) {
                case 0:
                    title = "extraSpeed";
                    break;
                case 1:
                    title = "extraBomb";
                    break;
                case 2:
                    title = "extraRange";
                    break;
                case 3:
                    title = "kickBomb";
                    break;
                case 4:
                    title = "throwBomb";
                    break;
            }
            Type = type;
        }

        public int getType()
        {
            return Type;
        }

    }
	
}
