﻿using GameServer.Models.Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameServer.Models.Adapter
{
    public class BombHitAdapter
    {
        public BombHitAdapter()
        {
        }

        public void Hit(Bomb bomb)
        {
            bomb.Explode();
        }
        public void Hit(Bomb bomb, CompositeExplosion compositeExplosion)
        {
            bomb.Explode(compositeExplosion);
        }
    }
}
