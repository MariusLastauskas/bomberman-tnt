

using System.Drawing;
/**
* @(#) RedPlayer.cs
*/
namespace GameServer.Models.AnstractFactory
{
	
	public class RedPlayer : Player
	{
        public Color Color { get; set; }
        public RedPlayer(int bombNumber, int power, int heart, int speed, Coordinates coordinates) : base(bombNumber, power, heart, speed, coordinates)
        {
            AuthToken = "redPlayer";
            Color = Color.FromKnownColor(KnownColor.Red);
        }
        public Color GetColor()
        {
            return Color;
        }
    }
	
}
