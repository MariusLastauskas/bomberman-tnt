using System;
using System.Collections.Generic;

namespace GameServer.Models
{
    public class MapBuilder:Builder
    {
        const int Width = 15;

        private MapObject[,] moList;

        public MapBuilder()
        {
            moList = new MapObject[15,15];
            return;
        }

        public override Builder BuildDestructibleWalls()
        {
            //sienu darymas 15x15
            //Pirmos eilutes sudarymas
            for (int i = 0; i < Width; i++)
            {
                Wall wall = new Wall();
                Coordinates c = new Coordinates(i, 0);
                wall.SetCoordinates(c);
                moList[i, 0] = wall;
            }
            //Nuo 2 iki 14 eilutes sudarymas

            for(int y = 1; y < Width - 1 ; y++)
            {
                for(int x = 0; x < Width; x++)
                {
                    if (y % 2 > 0)
                    {
                        if (x == 0)
                        {
                            Wall wall = new Wall();
                            Coordinates c = new Coordinates(x, y);
                            wall.SetCoordinates(c);
                            moList[x, y] = wall;
                        }
                        else if (x == Width - 1)
                        {
                            Wall wall = new Wall();
                            Coordinates c = new Coordinates(x, y);
                            wall.SetCoordinates(c);
                            moList[x, y] = wall;
                        }
                        else
                        {
                            moList[x, y] = null;
                        }
                        
                    }
                    else
                    {
                        if (x % 2 == 0)
                        {
                            Wall wall = new Wall();
                            Coordinates c = new Coordinates(x, y);
                            wall.SetCoordinates(c);
                            moList[x, y] = wall;
                        }
                        else
                        {
                            moList[x, y] = null;
                        }
                    }
                }
            }
            //Paskutines eilutes sudarymas
            for(int i = 0; i < Width; i++)
            {
                Wall wall = new Wall();
                Coordinates c = new Coordinates(i, Width - 1);
                wall.SetCoordinates(c);
                moList[i, Width - 1] = wall;
            }

            return this;
        }

        public override Builder BuildIndestructibleWalls()
        {
            //likucio generavimas

            return this;
        }

        public Map build()
        {
            Map map = new Map(moList);
            return map;
        }

       

    }
}
