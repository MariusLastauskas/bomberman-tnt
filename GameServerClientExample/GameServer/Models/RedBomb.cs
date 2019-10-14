

using System;
using System.Drawing;
/**
* @(#) RedBomb.cs
*/
namespace GameServer.Models
{
	
	public class RedBomb : Bomb
	{
        public Color Color { get; set; }
        public RedBomb(Player player)
        {
            this.isWalkable = false;
            this.SetBombToPlayer(player);
            //this.SetCoordinates(player.) player coordinates
            Color = Color.FromKnownColor(KnownColor.Red);
            Timer();
        }
    }
	
}
