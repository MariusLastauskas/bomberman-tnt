using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameServer.Models
{
    public class MapManagerStub
    {
        MapBuilder builder = new MapBuilder();

        public MapManagerStub()     // Dar reikia implementuoti
        {

        }

        public void BuildMap()  // Dar reikia implementuoti
        {
            builder.BuildIndestructibleWalls().BuildDestructibleWalls();
            builder.build();
        }

        public bool UpdatePlayerPos(Player p, string direction)  // Dar reikia implementuoti
        {
            return true;
        }

        public void PlaceBomb(Player p)
        {

        }
    }
}
