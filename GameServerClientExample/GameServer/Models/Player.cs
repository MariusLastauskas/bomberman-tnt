using System;
using GameServer.Models.GameObserver;
using System.Collections.Generic;
using System.Windows.Input;
using GameServer.Models.Strategy;
using System.Threading.Tasks;
using GameServer.Models.State;

namespace GameServer.Models
{
    public class Player : MapObject, IPlayerState
    {
        public string Name { get; set; }
        public string AuthToken { get; set; }

        public int PlacedBombCount { get; set; }
        public int NumberOfBombs { get; set; }
        public int BombPower { get; set; }
        public int Health { get; set; }
        public int MovementSpeed { get; set; }

        public bool PlayerIsDead { get; set; }
        public bool Imune { get; set; }

        public MoveStrategy MoveStrategy { get; set; }
        public PlantBombStrategy PlantBombStrategy { get; set; }
        public MapObserver MapObserver { get; set; }

        //Strategy classes: kick, throw, place, imune


        public Player() { }

        public Player(int bombNumber, int power, int heart, int speed, Coordinates coords) : base(coords)
        {
            NumberOfBombs = bombNumber;
            BombPower = power;
            Health = heart;
            MovementSpeed = speed;
            PlacedBombCount = 0;

            MoveStrategy = new SimpleMove();
            PlantBombStrategy = new SimplePlant();

            PlayerIsDead = false;

            SetCoordinates(coords);
            Imune = false;
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
                if (!Imune)
                {
                    Imune = true;
                    Health -= damage;
                    ImuneCount();
                }
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
        public async void ImuneCount()
        {
            await Task.Delay(2000);
            Imune = false;
        }
        public void CheckForPowerUps()
        {
            Map map = Map.GetInstance;
            List<MapObject>[,] maps = map.getMapContainer();
            if (maps[Coordinates.PosX,Coordinates.PosY].Count > 1)
            {
                for(int i = 0; i < maps[Coordinates.PosX, Coordinates.PosY].Count; i++)
                {
                    if(maps[Coordinates.PosX, Coordinates.PosY][i] is PowerUp)
                    {
                        PowerUp up = maps[Coordinates.PosX, Coordinates.PosY][i] as PowerUp;
                        if(up.getType() == 0)
                        {
                            IncreaseMovementSpeed(1);
                        }
                        else if (up.getType() == 1)
                        {
                            IncreaseNumberOfBombs(1);
                        }
                        else if (up.getType() == 2)
                        {
                            IncreaseBombPower(1);
                        }
                        else if (up.getType() == 3)
                        {
                            SetCanKick();
                        }
                        else
                        {
                            SetCanThrow();
                        }
                        map.removeObject(up);
                    }
                }
                        
            }
        }
    }
}
