using GameServer.Models;
using GameServer.Models.AnstractFactory;
using GameServer.Models.GameObserver;
using System;
using System.Drawing;
using System.Threading;
using Xunit;

namespace Testing
{
    public class ObserverTests
    {
        /// <summary>
        /// connecting/disconecting stubs to MapObserver
        /// </summary>
        [Fact]
        public void ObserverAttachDeatach()
        {
            MapStub stub = new MapStub();
            MapObserver obs1 = new MapObserver(stub);
            MapObserver obs2 = new MapObserver(stub);
            int pre = stub.Count();
            stub.Attach(obs1);
            stub.Attach(obs2);
            Assert.Equal(pre + 2, stub.Count());
            stub.Detach(obs1);
            stub.Detach(obs2);
            Assert.Equal(pre, stub.Count());
        }

        [Fact]
        public void GameManagerTest()
        {
            GameManager manager = new GameManager();
            Assert.Equal(0, manager.gameState);
            manager.ConnectPlayer("aa");
            manager.ConnectPlayer("ab");
            Assert.Equal(2, manager.gameState);
            manager.DisconnectPlayer("aa");
            manager.CheckGameState();
            Assert.Equal(0, manager.gameState);
        }

    }
}
