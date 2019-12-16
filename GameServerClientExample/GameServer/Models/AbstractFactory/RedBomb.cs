

using System;
using System.Drawing;
/**
* @(#) RedBomb.cs
*/
namespace GameServer.Models.AnstractFactory
{
	
	public class RedBomb : Bomb
	{
        public string Title;
        public Color Color { get; set; }
        public RedBomb(Player player) : base(player)
        {
            Color = Color.FromKnownColor(KnownColor.Red);
            Title = "redBomb";
        }
        public Color GetColor()
        {
            return Color;
        }
    }
	
}
