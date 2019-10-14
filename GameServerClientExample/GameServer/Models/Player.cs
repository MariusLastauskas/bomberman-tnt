using System;
using GameServer.Models.GameObserver;
using System.Collections.Generic;
using System.Windows.Input;
using GameServer.Models.Strategy;

namespace GameServer.Models
{
    public class Player : MapObject
    {
        public string Name { get; set; }
        public string AuthToken { get; set; }

        public int PlacedBombCount { get; set; }
        public int NumberOfBombs { get; set; }
        public int BombPower { get; set; }
        public int Health { get; set; }
        public int MovementSpeed { get; set; }

        public bool PlayerIsDead { get; set; }

        public MoveStrategy MoveStrategy { get; set; }
        public PlantBombStrategy PlantBombStrategy { get; set; }
        public MapObserver MapObserver { get; set; }

        //Strategy classes: kick, throw, place, imune


        public Player() { }

        public Player(int bombNumber, int power, int heart, int speed)
        {
            NumberOfBombs = bombNumber;
            BombPower = power;
            Health = heart;
            MovementSpeed = speed;
            PlacedBombCount = 0;

            MoveStrategy = new SimpleMove();
            PlantBombStrategy = new SimplePlant();

            PlayerIsDead = false;
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
            if (Health > 0)
            {
                Health -= damage;
            }
            else if (Health <= 0)
            {
                PlayerIsDead = true;
            }
        }

        //More caffeine (speed)
        public void IncreaseMovementSpeed(int speed)
        {
            MovementSpeed += speed;
        }

        //Can he kick the bomb?
        public void SetCanKick()
        {
            MoveStrategy = new KickMove();
        }

        //Can he throw the bomb?
        public void SetCanThrow()
        {
            MoveStrategy = new ThrowMove();
        }

        //Invinsible
        public void SetImuneTime()
        {
            PlantBombStrategy = new ImunePlant();
        }

        public void SetCanPlantBomb()
        {
            PlantBombStrategy = new SimplePlant();
        }

        public void Move(string direction)
        {
            MoveStrategy.Move(this, direction);
        }
    }
}
