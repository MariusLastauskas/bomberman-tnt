using System;
using System.Collections.Generic;

namespace GameServer.Models
{
    public class MapBuilder:Builder
    {
        const int Width = 15;

        private List<MapObject>[,] moList;

        public MapBuilder()
        {
            moList = new List<MapObject>[15,15];
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    moList[i, j] = new List<MapObject>();
                }
            }
        }

        public List<MapObject>[,] getMoList()
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
                moList[i, 0].Add(wall);
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
                            moList[x, y].Add(wall);
                        }
                        else if (x == Width - 1)
                        {
                            MapObject wall = new Wall();
                            Coordinates c = new Coordinates(x, y);
                            wall.SetCoordinates(c);
                            moList[x, y].Add(wall);
                        }
                        
                    }
                    else
                    {
                        if (x % 2 == 0)
                        {
                            MapObject wall = new Wall();
                            Coordinates c = new Coordinates(x, y);
                            wall.SetCoordinates(c);
                            moList[x, y].Add(wall);
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
                moList[i, Width - 1].Add(wall);
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
                        moList[x, y].Add(wall);
                    }
                    else
                    {
                        if (x % 2 > 0)
                        {
                            MapObject wall = new Wall(true);
                            Coordinates c = new Coordinates(x, y);
                            wall.SetCoordinates(c);
                            moList[x, y].Add(wall);
                        }
                        
                    }
                }
            }

            return this;
        }

        public Map build()
        {
            Map map = new Map(moList);
            return map;
        }

       

    }
}
