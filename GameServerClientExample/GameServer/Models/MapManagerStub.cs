﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameServer.Models
{
    public class MapManagerStub
    {
        AbstractFactory BlueFactory = new BlueFactory();
        AbstractFactory RedFactory = new BlueFactory();
        public MapManagerStub()     // Dar reikia implementuoti
        {

        }

        public void BuildMap()  // Dar reikia implementuoti
        {

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
            //padaryt bombos idejima i zemelapid

        }

        public MapObject getObjectIn(string direction)
        {
            return null;
        }
    }
}
