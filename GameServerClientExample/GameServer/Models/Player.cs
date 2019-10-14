using System;
using GameServer.Models.GameObserver;
namespace GameServer.Models
{
    public class Player : MapObject
    {
        //public long Id { get; set; }
        //public string Name { get; set; }
        //public long Score { get; set; }
        //public long PosX { get; set; }
        //public long PosY { get; set; }
        //public string Mac { get; set; }

        public int PlacedBombCount { get; set; }
        public int NumberOfBombs { get; set; }
        public int BombPower { get; set; }
        public int Health { get; set; }
        public int MovementSpeed { get; set; }
        public bool CanKick { get; set; }
        public bool CanThrow { get; set; }
        public int ImuneTime { get; set; }

        //Strategy classes: kick, throw, place, imune

        public MapObserver mapObserver { get; set; }

        public Player() { }

        public Player(int numberOfBombs, int bombPower, int health, int movementSpeed)
        {
            NumberOfBombs = numberOfBombs;
            BombPower = bombPower;
            Health = health;
            MovementSpeed = movementSpeed;

            PlacedBombCount = 0;
            ImuneTime = 0;
            CanKick = false;
            CanThrow = false;
        }

        //---------------------
        //Increase or decrease the bomb placed count
        public void IncreasePlacedBombCount()
        {
            if (PlacedBombCount < NumberOfBombs)
            {
                PlacedBombCount++;
            }
        }

        public void DecreasePlacedBombCount()
        {
            if (PlacedBombCount > 0)
            {
                PlacedBombCount--;
            }
        }

        //More bombs
        public void IncreaseNumberOfBombs(int count)
        {
            NumberOfBombs += count;
        }

        //More power for the explosions (bomb power)
        public void IncreaseBombPower(int power)
        {
            BombPower += power;
        }

        //Health loss
        public void DecreaseHealth(int damage)
        {
            Health -= damage;
        }

        //More caffeine (speed)
        public void IncreaseMovementSpeed(int speed)
        {
            MovementSpeed += speed;
        }

        //Can he kick the bomb?
        public bool SetCanKick(bool decision)
        {
            return CanKick = decision;
        }

        //Can he throw the bomb?
        public bool SetCanThrow(bool decision)
        {
            return CanThrow = decision;
        }

        //Invinsible
        public void SetImuneTime(int time)
        {
            ImuneTime = time;
        }


    }
}
