using System;
using GameServer.Models.GameObserver;
namespace GameServer.Models
{
    public class Player
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long Score { get; set; }
        public long PosX { get; set; }
        public long PosY { get; set; }
        public string Mac { get; set; }
        public int placedBombCount { get; set; }
        public int numberOfBombs { get; set; }
        public MapObserver mapObserver { get; set; }

        public Player()
        {
        }
    }
}
