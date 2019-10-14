using GameServer.Models.AnstractFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace GameServer.Models
{
    public class MapManagerStub
    {
        AbstractFactory BlueFactory = new BlueFactory();
        AbstractFactory RedFactory = new BlueFactory();
        MapBuilder builder = new MapBuilder();


        public MapManagerStub()     // Dar reikia implementuoti
        {

        }

        public Map BuildMap()  
        {
            return Map.GetInstance;
        }

        public bool UpdatePlayerPos(Player p, string direction)  // Dar reikia implementuoti
        {
            return true;
        }

        public void PlaceBomb(Player p)
        {
            MapObject k;
            if(p is BluePlayer)
            {
                k = BlueFactory.getBomb(p);
            }else
            {
                k = RedFactory.getBomb(p);
            }
            Map map = Map.GetInstance;
            map.AddMapObj(k);

        }

        public MapObject getObjectIn(string direction) //kas cia blet? ka jis turi daryt?
        {
            return null;
        }
    }
}
