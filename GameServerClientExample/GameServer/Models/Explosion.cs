
using System.Threading;
/**
* @(#) Explosion.cs
*/
namespace GameServer.Models
{
	public class Explosion : MapObject
	{
        
        public Explosion(Coordinates coords) : base (coords)
        {
            Timer();
        }

		public void Timer()
		{
            Thread.Sleep(1000);
            //make it dissapear affter 1 sec
        }
		
	}
	
}
