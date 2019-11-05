

using System.Drawing;
/**
* @(#) BluePlayer.cs
*/
namespace GameServer.Models.AnstractFactory
{
	
	public class BluePlayer : Player
	{
        private Color Color { get; set; }
        public BluePlayer() { }
        public BluePlayer(int bombNumber, int power, int heart, int speed, Coordinates coordinates) : base(bombNumber, power, heart, speed, coordinates)
        {
            Color = Color.FromKnownColor(KnownColor.Blue);
        }

        public Color GetColor()
        {
            return Color;
        }

    }
	
}
