using System;
namespace GameServer.Models
{
    public class Player
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long Score { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }

        public Player()
        {
        }
    }
}
