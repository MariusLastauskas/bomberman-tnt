﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameServer.Models.Strategy
{
    public class ImunePlant : PlantBombStrategy
    {
        public int ImuneTime { get; set; }

        public override void PlantBomb(Player player)
        {
            // Can't plant
        }
    }
}
