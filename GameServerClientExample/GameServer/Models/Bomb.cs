

using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
/**
* @(#) Bomb.cs
*/
namespace GameServer.Models
{
	public class Bomb : MapObject
	{
        private bool exploded = false;
		private Player player;

        public void Explode( )
		{
            if (exploded == false)
            {
                player.DecreasePlacedBombCount();
                exploded = true;
                //explosions are not implemented yet
            }
		}

        public void SetBombToPlayer(Player player)
        {
            this.player = player;
            player.IncreasePlacedBombCount();
        }
		
		public async void Timer()
		{
            await Task.Delay(3000);
            this.Explode();
		}

        public void HitByExplosion()
        {
            Explode();
        }

    }
	
}
