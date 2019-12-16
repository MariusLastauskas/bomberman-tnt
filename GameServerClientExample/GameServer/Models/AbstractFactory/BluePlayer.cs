

using System.Drawing;
/**
* @(#) BluePlayer.cs
*/
namespace GameServer.Models.AnstractFactory
{
	
	public class BluePlayer : Player
	{
        public string Title;
        public Color Color { get; set; }
        public BluePlayer() { }
        public BluePlayer(int bombNumber, int power, int heart, int speed, Coordinates coordinates) : base(bombNumber, power, heart, speed, coordinates)
        {
            AuthToken = "bluePlayer";
            Color = Color.FromKnownColor(KnownColor.Blue);
            Title = "bluePlayer";
        }

        public Color GetColor()
        {
            return Color;
        }

    }
	
}
