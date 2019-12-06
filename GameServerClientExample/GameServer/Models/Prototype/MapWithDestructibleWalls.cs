using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.IO;

namespace GameServer.Models
{
    public class MapWithDestructibleWalls : MapPrototype
    {
        public List<MapObject>[,] moList;
        
        public MapWithDestructibleWalls()
        {
            MapBuilder newMap = new MapBuilder();
            Stopwatch timer = new Stopwatch();
            timer.Start();
            newMap.BuildIndestructibleWalls().BuildDestructibleWalls().AddPlayers();
            timer.Stop();
            TimeSpan ts = timer.Elapsed;
            File.WriteAllLines(@"test.csv", new string[]{ ts.ToString(), Process.GetCurrentProcess().WorkingSet64.ToString() });
            Console.WriteLine("RunTime " + ts);
            moList = newMap.getMoList();
        }

        public List<MapObject>[,] getMoList()
        {
            return moList;
        }

        public override MapPrototype Clone()
        {
            return MemberwiseClone() as MapPrototype;
        }
    }
}
