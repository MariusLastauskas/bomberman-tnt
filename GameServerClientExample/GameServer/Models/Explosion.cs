
using System.Threading;
using System.Threading.Tasks;
/**
* @(#) Explosion.cs
*/
namespace GameServer.Models
{
	public class Explosion : MapObject
	{
        private MapManagerStub map;
        public Explosion(Coordinates coords) : base (coords)
        {
            map = new MapManagerStub();
            Timer();
        }

		public async void Timer()
		{
            await Task.Delay(1000);
            map.RemoveThis(this);
        }
		
	}
	
}
