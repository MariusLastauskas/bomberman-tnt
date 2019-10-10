using System;
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
        public int bombPower { get; set; }
        public int health { get; set; }
        public int movementSpeed { get; set; }
        public bool canKick { get; set; }
        public bool canThrow { get; set; }
        public int imuneTime { get; set; }

        //Strategy classes: kick, throw, place, imune

        public Player()
        {
        }
    }
}
