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
            moList = new MapObject[Width,Width];
        }

        public MapObject[,] getMoList()
        {
            return moList;
        }

        public override Builder BuildIndestructibleWalls()
        {
            //sienu darymas 15x15
            //Pirmos eilutes sudarymas
            for (int i = 0; i < Width; i++)
            {
                MapObject wall = new Wall();
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
                            MapObject wall = new Wall();
                            Coordinates c = new Coordinates(x, y);
                            wall.SetCoordinates(c);
                            moList[x, y] = wall;
                        }
                        else if (x == Width - 1)
                        {
                            MapObject wall = new Wall();
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
                            MapObject wall = new Wall();
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
                MapObject wall = new Wall();
                Coordinates c = new Coordinates(i, Width - 1);
                wall.SetCoordinates(c);
                moList[i, Width - 1] = wall;
            }

            return this;
        }

        public override Builder BuildDestructibleWalls()
        {
            //likucio generavimas

            //Nuo 2 iki 14 eilutes sudarymas

            for (int y = 1; y < Width - 1; y++)
            {
                for (int x = 1; x < Width-1; x++)
                {
                    if (y % 2 > 0)
                    {
                        MapObject wall = new Wall(true);
                        Coordinates c = new Coordinates(x, y);
                        wall.SetCoordinates(c);
                        moList[x, y] = wall;
                    }
                    else
                    {
                        if (x % 2 > 0)
                        {
                            MapObject wall = new Wall(true);
                            Coordinates c = new Coordinates(x, y);
                            wall.SetCoordinates(c);
                            moList[x, y] = wall;
                        }
                        
                    }
                }
            }
            //pranaikinti langelius

            moList[1, 1] = null;
            moList[1, 2] = null;
            moList[1, 3] = null;
            moList[2, 1] = null;
            moList[3, 1] = null;
            moList[Width - 4, Width - 2] = null;
            moList[Width - 3, Width - 2] = null;
            moList[Width - 2, Width - 2] = null;
            moList[Width - 2, Width - 3] = null;
            moList[Width - 2, Width - 4] = null;

            //spawnina zaidejus

            

            return this;
        }

        public Map build()
        {
            Map map = new Map(moList);
            return map;
        }

       

    }
}
