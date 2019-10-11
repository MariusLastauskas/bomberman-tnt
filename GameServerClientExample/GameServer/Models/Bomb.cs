

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
        private Color Color = Color.FromKnownColor(KnownColor.ForestGreen);

        public void Explode( )
		{
            if (exploded == false)
            {
                exploded = true;
                //is not implemented yet
                //player.placedBombCount--;
            }
		}

        public void SetColor(Color color)
        {
            Color = color;
        }

        public void SetBombToPlayer(Player player)
        {
            this.player = player;
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
