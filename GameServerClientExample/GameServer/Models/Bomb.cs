

using System;
using System.Threading;
/**
* @(#) Bomb.cs
*/
namespace GameServer.Models
{
	public class Bomb : MapObject
	{
        private bool exploded = false;
		private Player player;
		public Bomb(Player player)
        {
            this.isWalkable = false;
            this.player = player;
            Timer();
        }

		public void Explode( )
		{
            if (exploded == false)
            {
                exploded = true;
                //is not implemented yet
                player.placedBombCount--;
            }
		}
		
		public void Timer(  )
		{
            Thread.Sleep(3000);
            this.Explode();
		}

        public void HitByExplosion()
        {
            Explode();
        }
		
	}
	
}
