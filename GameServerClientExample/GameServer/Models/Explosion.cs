
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

        public Explosion(Coordinates coords, Wall wall) : base(coords)
        {
            map = new MapManagerStub();
            Timer(wall);
        }

        public async void Timer()
		{
            await Task.Delay(1000);
            
            map.RemoveThis(this);
        }
        public async void Timer(Wall wall)
        {
            await Task.Delay(1000);
            map.DestroyWall(wall);
            map.RemoveThis(this);
        }

    }
	
}
