﻿using GameServer.Models.Adapter;
using System;
using System.Collections.Generic;

namespace GameServer.Models
{
    /// <summary>
    /// singletone Map
    /// </summary>
    public sealed class Map
    {
        private static readonly object InstanceLock = new object();
        private List<MapObject>[,] mapContainer;
        private MapManagerStub MapManagerStub = new MapManagerStub();
        

        private Map()
        {

        }
        private static Map instance = null;
        public static Map GetInstance
        {
            get
            {
                if (instance == null)
                {
                    lock (InstanceLock)
                    {
                        if (instance == null)
                        {
                            MapBuilder builder = new MapBuilder();
                            builder.BuildIndestructibleWalls().BuildDestructibleWalls().AddPlayers();
                            instance = builder.build();
                        }
                    }
                }
                return instance;
            }
        }

        public void AddMapObj(MapObject mapObj)
        { 
            Coordinates c = mapObj.GetCoordinates();
            long cx = c.PosX;
            long cy = c.PosY;

            mapContainer[cx, cy].Add(mapObj);
        }
        

        public Map(List<MapObject>[,] mapObj)
        {
            this.mapContainer = mapObj;
        }

        public List<MapObject>[,] getMapContainer()
        {
            return mapContainer;
        }
        public void removeMap()
        {
            instance = null;
            mapContainer = null;
        }
        public void removeObject(MapObject obj)
        {
            mapContainer[obj.Coordinates.PosX, obj.Coordinates.PosY].Remove(obj);
        }
        public void CleanArena()
        {
            mapContainer = new MapBuilder().getMoList();
            
        }
    }
}
