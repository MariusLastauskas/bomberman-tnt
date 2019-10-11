

using System;
using System.Drawing;
/**
* @(#) BlueBomb.cs
*/
namespace GameServer.Models
{
	
	public class BlueBomb : Bomb
	{
        public BlueBomb(Player player)
        {
            this.isWalkable = false;
            this.SetBombToPlayer(player);
            //this.SetCoordinates(player.) player coordinates
            this.SetColor(Color.FromKnownColor(KnownColor.Blue));
            Timer();
        }

        
    }
}
