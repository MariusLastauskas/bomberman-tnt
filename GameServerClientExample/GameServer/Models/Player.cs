using System;
using GameServer.Models.GameObserver;
using System.Collections.Generic;
using System.Windows.Input;
using GameServer.Models.Strategy;

namespace GameServer.Models
{
    public class Player : MapObject
    {
        public int PlacedBombCount { get; set; }
        public int NumberOfBombs { get; set; }
        public int BombPower { get; set; }
        public int Health { get; set; }
        public int MovementSpeed { get; set; }
        public bool TookDamage { get; set; }
        public MoveStrategy moveStrategy { get; set; }
        public PlantBombStrategy plantBombStrategy { get; set; }

        //Strategy classes: kick, throw, place, imune

        // public MapObserver mapObserver { get; set; }

        public Player() { }

        public Player(int numberOfBombs, int bombPower, int health, int movementSpeed)
        {
            NumberOfBombs = numberOfBombs;
            BombPower = bombPower;
            Health = health;
            MovementSpeed = movementSpeed;
            PlacedBombCount = 0;

            moveStrategy = new SimpleMove();
            plantBombStrategy = new SimplePlant();
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
        public void SetCanKick()
        {
            moveStrategy = new KickMove();
        }

        //Can he throw the bomb?
        public void SetCanThrow()
        {
            moveStrategy = new ThrowMove();
        }

        //Invinsible
        public void SetImuneTime()
        {
            plantBombStrategy = new ImunePlant();
        }

        public void SetCanPlantBomb()
        {
            plantBombStrategy = new SimplePlant();
        }

        public void Move(string direction)
        {
            moveStrategy.Move(this, direction);
        }
    }
}
