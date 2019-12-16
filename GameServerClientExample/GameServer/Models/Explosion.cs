
using GameServer.Models.Visitor;
using System.Threading;
using System.Threading.Tasks;
/**
* @(#) Explosion.cs
*/
namespace GameServer.Models
{
	public class Explosion : MapObject
	{
        public string title;
        private MapManagerStub map;
        private Wall willDestroy;
        public Explosion(Coordinates coords) : base (coords)
        {
            map = new MapManagerStub();
            title = "explosion";
            Timer();
        }

        public Explosion(Coordinates coords, Wall wall) : base(coords)
        {
            map = new MapManagerStub();
            title = "explosion";
            Timer(wall);
        }

        public void Timer()
		{
        }
        public void Timer(Wall wall)
        {
            willDestroy = wall;
            
        }
        public override void Operation()
        {
            base.Operation();
            map.DestroyWall(willDestroy);
            map.RemoveThis(this);
        }

    }
	
}
