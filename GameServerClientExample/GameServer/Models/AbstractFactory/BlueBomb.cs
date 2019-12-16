

using System;
using System.Drawing;
/**
* @(#) BlueBomb.cs
*/
namespace GameServer.Models.AnstractFactory
{
	
	public class BlueBomb : Bomb
	{
        public string Title;
        public Color Color { get; set; }
        public BlueBomb(Player player) : base(player)
        {
            Color = Color.FromKnownColor(KnownColor.Blue);
            Title = "blueBomb";
        }
        public Color GetColor()
        {
            return Color;
        }
    }
}
