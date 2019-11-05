/**
 * @(#) PowerUp.cs
 */

namespace GameServer.Models
{
	public class PowerUp : MapObject
	{
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
