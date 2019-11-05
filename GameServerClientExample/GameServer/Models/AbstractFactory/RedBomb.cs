

using System;
using System.Drawing;
/**
* @(#) RedBomb.cs
*/
namespace GameServer.Models.AnstractFactory
{
	
	public class RedBomb : Bomb
	{
        private Color Color { get; set; }
        public RedBomb(Player player) : base(player)
        {
            Color = Color.FromKnownColor(KnownColor.Red);
        }
        public Color GetColor()
        {
            return Color;
        }
    }
	
}
