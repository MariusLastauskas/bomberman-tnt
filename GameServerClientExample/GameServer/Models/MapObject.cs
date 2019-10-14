/**
 * @(#) MapObject.cs
 */

namespace GameServer.Models
{
	public abstract class MapObject
	{
        public bool isWalkable = true;

        //Map map;

        private Coordinates Coordinates { get; set; }

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
		
	}
	
}
    