﻿using GameServer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Testing
{
    public class PowerUpTest
    {
        [Fact]
        public void PlayerMovementSpeedTest()
        {
            Map map = Map.GetInstance;
            map.CleanArena();
            Player player = new Player(1, 1, 3, 1, new Coordinates(6, 6));
            PowerUp power = new PowerUp(0, new Coordinates(6, 6));
            map.AddMapObj(player);
            map.AddMapObj(power);
            player.CheckForPowerUps();
            player.CheckForPowerUps();
            Assert.Equal(2, player.MovementSpeed);
            map.removeMap();
        }

        [Fact]
        public void PlayerExtraBombPowerUpTest()
        {
            Map map = Map.GetInstance;
            map.CleanArena();
            Player player = new Player(1, 1, 3, 1, new Coordinates(6, 6));
            PowerUp power = new PowerUp(1, new Coordinates(6, 6));
            map.AddMapObj(player);
            map.AddMapObj(power);
            player.CheckForPowerUps();
            player.CheckForPowerUps();
            Assert.Equal(2, player.NumberOfBombs);
            map.removeMap();
        }

        [Fact]
        public void PlayerBombPowerPowerUpTest()
        {
            Map map = Map.GetInstance;
            map.CleanArena();
            Player player = new Player(1, 1, 3, 1, new Coordinates(6, 6));
            PowerUp power = new PowerUp(2, new Coordinates(6, 6));
            map.AddMapObj(player);
            map.AddMapObj(power);
            player.CheckForPowerUps();
            player.CheckForPowerUps();
            Assert.Equal(2, player.BombPower);
            map.removeMap();
        }

        /// <summary>
        /// tests if explosion length works propertly
        /// </summary>
        /// <param name="pover"></param>
        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        public void ExplosionLengthTest(int pover)
        {
            Map map = Map.GetInstance;
            map.CleanArena();
            Player player = new Player(1, pover, 3, 1, new Coordinates(6, 6));
            Bomb bomb = new Bomb(player);
            map.AddMapObj(bomb);
            bomb.Explode();
            int cnt = 0;
            foreach (var list in map.getMapContainer())
            {
                cnt += list.Count;
            }
            Assert.Equal(1 + pover * 4, cnt);
            map.removeMap();
        }

        [Fact]
        public void PlayerKickPowerUpTest()
        {
            Map map = Map.GetInstance;
            map.CleanArena();
            Player player = new Player(1, 1, 3, 1, new Coordinates(6, 6));
            PowerUp power = new PowerUp(3, new Coordinates(6, 6));
            map.AddMapObj(player);
            map.AddMapObj(power);
            player.CheckForPowerUps();
            player.CheckForPowerUps();
            Assert.Equal(2, player.MovementSpeed);
            map.removeMap();
        }

        [Fact]
        public void PlayerThrowPowerUpTest()
        {
            Map map = Map.GetInstance;
            map.CleanArena();
            Player player = new Player(1, 1, 3, 1, new Coordinates(6, 6));
            PowerUp power = new PowerUp(4, new Coordinates(6, 6));
            map.AddMapObj(player);
            map.AddMapObj(power);
            player.CheckForPowerUps();
            player.CheckForPowerUps();
            Assert.Equal(2, player.MovementSpeed);
            map.removeMap();
        }
    }
}
