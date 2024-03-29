﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameServer.Models.State
{
    public class LookingLeftState : PlayerState
    {
        public override void GoNext(Player context, int state)
        {
            PlayerState ps = null;

            if (state == 1)
            {
                ps = new LookingUpState();
                context.SetState(ps);
            }
            else if (state == 2)
            {
                ps = new LookingRightState();
                context.SetState(ps);
            }
            else if (state == 3)
            {
                ps = new LookingDownState();
                context.SetState(ps);
            }
        }

        public override void Handle(Player context)
        {
            Map map = Map.GetInstance;
            List<MapObject> Objects = map.getMapContainer()[context.Coordinates.PosX, context.Coordinates.PosY];

            foreach (var mapObject in Objects)
            {
                if (mapObject is Bomb)
                {
                    Bomb bomb = mapObject as Bomb;
                    bomb.BeThrown("left");
                }
            }
        }
    }
}
