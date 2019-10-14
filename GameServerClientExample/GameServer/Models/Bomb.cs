

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
        private MapManagerStub map;

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

        public void BeKicked(string direction)
        {
            KickTimer(direction, 100);
        }

        public async void KickTimer(string direction, int time)
        {
            while ( map.getObjectIn(direction) == null)
            {
                Coordinates newPos = this.GetCoordinates();
                switch (direction)
                {
                    case "up":
                        newPos.PosY++;
                        break;
                    case "down":
                        newPos.PosY--;
                        break;
                    case "left":
                        newPos.PosX--;
                        break;
                    case "right":
                        newPos.PosX++;
                        break;
                    default:
                        break;
                }
                this.SetCoordinates(newPos);
                await Task.Delay(time);
            }
        }

        public void BeThrown(string direction)
        {
            ThrowTimer(direction, 100);
        }

        public async void ThrowTimer(string direction, int time)
        {
            Coordinates newPos;
            while (map.getObjectIn(direction) != null)
            {
                newPos = this.GetCoordinates();
                switch (direction)
                {
                    case "up":
                        newPos.PosY++;
                        break;
                    case "down":
                        newPos.PosY--;
                        break;
                    case "left":
                        newPos.PosX--;
                        break;
                    case "right":
                        newPos.PosX++;
                        break;
                    default:
                        break;
                }
                this.SetCoordinates(newPos);
                await Task.Delay(time);
            }
            newPos = this.GetCoordinates();
            switch (direction)
            {
                case "up":
                    newPos.PosY++;
                    break;
                case "down":
                    newPos.PosY--;
                    break;
                case "left":
                    newPos.PosX--;
                    break;
                case "right":
                    newPos.PosX++;
                    break;
                default:
                    break;
            }
            this.SetCoordinates(newPos);
            await Task.Delay(time);
        }
    }
	
}
