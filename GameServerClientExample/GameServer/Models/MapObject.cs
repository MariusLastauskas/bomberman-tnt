

using GameServer.Models.Decorator;
using System.Collections.Generic;
/**
* @(#) MapObject.cs
*/
namespace GameServer.Models
{
	public abstract class MapObject : Component
	{
        public bool isWalkable = true;

        //public List<string> decorations = new List<string>();
        //Map map;

        public Coordinates Coordinates { get; set; }

        public MapObject() { }

        public MapObject(Coordinates coords)
        {
            SetCoordinates(coords);
        }

        public Coordinates GetCoordinates(  )
		{
            return Coordinates;
		}
		
		public void SetCoordinates( Coordinates a)
		{
            Coordinates = a;
            CoordinatesUpdated();

        }
        public void CoordinatesUpdated()
        {
            //map.Update(this.ID);
        }

        public override void Operation()
        {
            
        }

    }
	
}
    