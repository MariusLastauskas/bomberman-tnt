using System;
namespace GameServer.Models
{

    public class Coordinates
    {
        public long Id { get; set; }
        /// <summary>
        /// x koordinates
        /// </summary>
        public long PosX { get; set; }
        /// <summary>
        /// y koordinates
        /// </summary>
        public long PosY { get; set; }

        public Coordinates()
        {
        }

        public Coordinates(long x, long y)
        {
            PosX = x;
            PosY = y;
        }
    }
}
