

using System;
using System.Drawing;
/**
* @(#) RedBomb.cs
*/
namespace GameServer.Models
{
	
	public class RedBomb : Bomb
	{
        public RedBomb(Player player)
        {
            this.isWalkable = false;
            this.SetBombToPlayer(player);
            //this.SetCoordinates(player.) player coordinates
            this.SetColor(Color.FromKnownColor(KnownColor.Red));
            Timer();
        }
    }
	
}
