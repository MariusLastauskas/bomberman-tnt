﻿using GameServer.Models;
using GameServer.Models.AnstractFactory;
using GameServer.Models.Memento;
using GameServer.Models.Mediator;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Testing
{
    public class FactoryTests
    {
        [Fact]
        public async void TimerClicksMementoSaves()
        {
            Timer timer = new Timer();
            timer.StartTimer();
            timer.MemetnoTimer();
            await Task.Delay(1000);
            int t = timer.GetTime();
            await Task.Delay(1000);
            timer.ResetMementoTimer();
            Assert.True(t < timer.GetTime());
        }

        [Fact]
        public async void MementoResets()
        {
            Timer timer = new Timer();
            timer.StartTimer();
            timer.MemetnoTimer();
            await Task.Delay(1000);
            await Task.Delay(1000);
            timer.ResetMementoTimer();
            Assert.True(150 == timer.GetTime());
        }
        [Fact]
        public async void MediatorTest()
        {
            PlayerMediator mediator = new PlayerMediator();
            PlayerA playerA = new PlayerA(mediator);
            PlayerB playerB = new PlayerB(mediator);
            mediator.playerA = playerA;
            mediator.playerb = playerB;
            
            playerA.Send("aa");
            playerB.Send("bb");

            Assert.True(playerA.GetChat().Count == 2);
            
        }
        /// <summary>
        /// creates blue player
        /// </summary>
        [Fact]
        public void BluePlayerCreateTest()
        {
            Map map = Map.GetInstance;
            map.CleanArena();
            BluePlayer player = new BluePlayer(1, 1, 1, 1, new Coordinates(5, 5));
            MapManagerStub mapManager = new MapManagerStub();
            map.AddMapObj(player);
            Assert.True(map.getMapContainer()[5, 5][0] is BluePlayer, "not a blue player");
            map.removeMap();
        }

        /// <summary>
        /// creates red player
        /// </summary>
        [Fact]
        public void RedPlayerCreateTest()
        {
            Map map = Map.GetInstance;
            MapManagerStub mapManager = new MapManagerStub();
            Assert.True(map.getMapContainer()[13, 13][0] is RedPlayer, "not a red player");
            map.removeMap();
        }

        /// <summary>
        /// checks if blue player HAS BLUE COLOR ASSIGNED
        /// </summary>
        [Fact]
        public void BluePlayerColorTest()
        {
            BluePlayer player = new BluePlayer(1, 1, 1, 1, new Coordinates(5, 5));
            Assert.Equal(Color.FromKnownColor(KnownColor.Blue), player.GetColor());
        }

        /// <summary>
        /// checks if red player HAS BLUE COLOR ASSIGNED
        /// </summary>
        [Fact]
        public void RedPlayerColorTest()
        {
            RedPlayer player = new RedPlayer(1, 1, 1, 1, new Coordinates(5, 5));
            Assert.Equal(Color.FromKnownColor(KnownColor.Red), player.GetColor());
        }
        /// <summary>
        /// tests if blue player plants blue bombs
        /// </summary>
        [Fact]
        public void BluePlayerPlantBlueBombTest()
        {
            Map map = Map.GetInstance;
            map.CleanArena();
            MapManagerStub mapManager = new MapManagerStub();
            BluePlayer player = new BluePlayer(1,1,1,1, new Coordinates(5,5));
            mapManager.PlaceBomb(player);
            Assert.True(map.getMapContainer()[5, 5][0] is BlueBomb, "not a blue bomb");
            map.removeMap();
        }

        /// <summary>
        /// tests if red player plants red bombs
        /// </summary>
        [Fact]
        public void RedPlayerPlantRedBombTest()
        {
            Map map = Map.GetInstance;
            map.CleanArena();
            MapManagerStub mapManager = new MapManagerStub();
            RedPlayer player = new RedPlayer(1, 1, 1, 1, new Coordinates(5, 5));
            mapManager.PlaceBomb(player);
            Assert.True(map.getMapContainer()[5, 5][0] is RedBomb, "not a blue bomb");
            map.removeMap();
        }

        /// <summary>
        /// tests the color of the red bombs
        /// </summary>
        [Fact]
        public void RedBombGetColorTest()
        {
            Map map = Map.GetInstance;
            map.CleanArena();
            MapManagerStub mapManager = new MapManagerStub();
            RedPlayer player = new RedPlayer(1, 1, 1, 1, new Coordinates(5, 5));
            mapManager.PlaceBomb(player);
            RedBomb bomb = map.getMapContainer()[5, 5][0] as RedBomb;
            Assert.Equal(Color.FromKnownColor(KnownColor.Red), bomb.GetColor());
            map.removeMap();
        }

        /// <summary>
        /// tests the color of the blue bombs
        /// </summary>
        [Fact]
        public void BlueBombGetColorTest()
        {
            Map map = Map.GetInstance;
            map.CleanArena();
            MapManagerStub mapManager = new MapManagerStub();
            BluePlayer player = new BluePlayer(1, 1, 1, 1, new Coordinates(5, 5));
            mapManager.PlaceBomb(player);
            BlueBomb bomb = map.getMapContainer()[5, 5][0] as BlueBomb;
            Assert.Equal(Color.FromKnownColor(KnownColor.Blue), bomb.GetColor());
            map.removeMap();
        }
    }
}
