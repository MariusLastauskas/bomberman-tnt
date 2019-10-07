using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameServer.Models
{
    public class GameManager
    {
        private Player player1;
        private Player player2;
        private MapManager mm;

        public GameManager()
        {
            player1 = null;
            player2 = null;
            mm = new MapManager();
        }

        public GameManager(Player p1, Player p2)
        {
            player1 = p1;
            player2 = p2;
            mm = new MapManager();
        }

        public void ConnectPlayer(Player player)
        {
            if (player1 == null)
            {
                player1 = player;
            }
            else if (player2 == null)
            {
                player2 = player;
            }

            if (player1 != null && player2 != null)
            {
                StartGame();
            }
        }

        public void StartGame()
        {
            mm.BuildMap(new Coordinates(player1.PosX, player1.PosY), new Coordinates(player2.PosX, player2.PosY));
        }

        public void UpdateGame()
        {
            mm.UpdatePlayerPos(new Coordinates(player1.PosX, player1.PosY), new Coordinates(player2.PosX, player2.PosY));
        }
    }
}
