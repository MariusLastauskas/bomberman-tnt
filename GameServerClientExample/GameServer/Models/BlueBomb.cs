

using System;
using System.Drawing;
/**
* @(#) BlueBomb.cs
*/
namespace GameServer.Models
{
	
	public class BlueBomb : Bomb
	{
        public Color Color { get; set; }
        public BlueBomb(Player player)
        {
            this.isWalkable = false;
            this.SetBombToPlayer(player);
            //this.SetCoordinates(player.) player coordinates
            Color = Color.FromKnownColor(KnownColor.Blue);
            Timer();
        }

        
    }
}
