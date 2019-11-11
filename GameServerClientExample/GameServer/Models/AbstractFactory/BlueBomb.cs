

using System;
using System.Drawing;
/**
* @(#) BlueBomb.cs
*/
namespace GameServer.Models.AnstractFactory
{
	
	public class BlueBomb : Bomb
	{
        public Color Color { get; set; }
        public BlueBomb(Player player) : base(player)
        {
            Color = Color.FromKnownColor(KnownColor.Blue);
        }
        public Color GetColor()
        {
            return Color;
        }
    }
}
