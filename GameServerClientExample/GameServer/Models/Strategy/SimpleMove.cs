using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameServer.Models;

namespace GameServer.Models.Strategy
{
    public class SimpleMove : MoveStrategy
    {
        public SimpleMove()
        {

        }

        public override void Move(Player p, string direction)
        {
            Map map = Map.GetInstance;
            long x, y;
            List<MapObject> mo;
            Coordinates coordinates;
            switch (direction)
            {
                case "up":
                    x = p.Coordinates.PosX - 1;
                    y = p.Coordinates.PosY;
                    break;
                case "down":
                    x = p.Coordinates.PosX + 1;
                    y = p.Coordinates.PosY;
                    break;
                case "left":
                    x = p.Coordinates.PosX;
                    y = p.Coordinates.PosY - 1;
                    break;
                case "right":
                    x = p.Coordinates.PosX;
                    y = p.Coordinates.PosY + 1;
                    break;
                default:
                    x = p.Coordinates.PosX;
                    y = p.Coordinates.PosY;
                    break;
            }

            mo = map.getObjectIn(x, y);

            if (mo.Count == 0 || mo[0].isWalkable)
            {
                coordinates = new Coordinates(x, y);
                map.removeObject(p);
                p.SetCoordinates(coordinates);
                map.addObject(p, x, y);
            }
            //map.UpdatePlayerPos(p, direction);
        }
    }
}
