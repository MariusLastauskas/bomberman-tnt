

using System.Drawing;
/**
* @(#) RedPlayer.cs
*/
namespace GameServer.Models.AnstractFactory
{
	
	public class RedPlayer : Player
	{
        public Color Color { get; set; }
        public RedPlayer(int bombNumber, int power, int heart, int speed) : base(bombNumber, power, heart, speed)
        {
            Color = Color.FromKnownColor(KnownColor.Red);
        }
    }
	
}
