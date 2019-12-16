

using System.Drawing;
/**
* @(#) RedPlayer.cs
*/
namespace GameServer.Models.AnstractFactory
{
	
	public class RedPlayer : Player
	{
        public string Title;
        public Color Color { get; set; }
        public RedPlayer(int bombNumber, int power, int heart, int speed, Coordinates coordinates) : base(bombNumber, power, heart, speed, coordinates)
        {
            AuthToken = "redPlayer";
            Color = Color.FromKnownColor(KnownColor.Red);
            Title = "redPlayer";
        }
        public Color GetColor()
        {
            return Color;
        }
    }
	
}
