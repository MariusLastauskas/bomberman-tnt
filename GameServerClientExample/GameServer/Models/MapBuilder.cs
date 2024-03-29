﻿using GameServer.Controllers;
using GameServer.Models.AnstractFactory;
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
                    Random ran = new Random();
                    int prob = ran.Next(1, 101);

                    if (y % 2 > 0)
                    {
                        MapObject wall = new Wall(true);
                        Coordinates c = new Coordinates(x, y);
                        wall.SetCoordinates(c);
                        if (prob < 70)
                        {
                            moList[x, y].Add(wall);
                        }
                        
                    }
                    else
                    {
                        if (x % 2 > 0)
                        {
                            MapObject wall = new Wall(true);
                            Coordinates c = new Coordinates(x, y);
                            wall.SetCoordinates(c);
                            if (prob < 70)
                            {
                                moList[x, y].Add(wall);
                            }
                            
                        }
                        
                    }
                }
            }
            //pranaikinti langelius

            moList[1, 1].Clear();
            moList[1, 2].Clear();
            moList[1, 3].Clear();
            moList[2, 1].Clear();
            moList[3, 1].Clear();
            moList[Width - 4, Width - 2].Clear();
            moList[Width - 3, Width - 2].Clear();
            moList[Width - 2, Width - 2].Clear();
            moList[Width - 2, Width - 3].Clear();
            moList[Width - 2, Width - 4].Clear();

            //panaikinu 10 random deziu(ateityje turetu buti algoritmas

            //.......


            return this;
        }

        public override Builder AddPlayers()
        {
            AbstractFactory factory = new BlueFactory();
            MapObject p1 = factory.getPlayer(new Coordinates(1, 1));

            moList[1, 1].Add(p1);
            factory = new RedFactory();
            MapObject p2 = factory.getPlayer(new Coordinates(Width - 2, Width - 2));
            moList[Width - 2, Width - 2].Add(p2);
            GlobalVar.getGm().setPlayers((Player)p1, (Player)p2);
            return this;
        }

        public Map build()
        {
            Map map = new Map(moList);
            return map;
        }
    }
}
