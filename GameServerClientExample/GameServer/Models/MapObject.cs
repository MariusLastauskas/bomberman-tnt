/**
 * @(#) MapObject.cs
 */

namespace GameServer.Models
{
	public abstract class MapObject
	{
        public int ID { get; set; }
        public bool isWalkable = true;

        //Map map;

        private Coordinates coordinates { get; set; }

        public Coordinates GetCoordinates(  )
		{
            return coordinates;
		}
		
		public void SetCoordinates( Coordinates a)
		{
            coordinates = a;
            CoordinatesUpdated();

        }
        public void CoordinatesUpdated()
        {
            //map.Update(this.ID);
        }
		
	}
	
}
