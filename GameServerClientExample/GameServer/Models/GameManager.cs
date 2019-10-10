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
        public MapManager mm;

        public GameManager()
        {
            player1 = null;
            player2 = null;
            mm = null;
        }

        public GameManager(Player p1, Player p2)
        {
            player1 = p1;
            player2 = p2;
            mm = new MapManager();
        }

        public Player ConnectPlayer(string mac)
        {
            Player p = new Player();
            if (player1 == null || player1.Mac == mac)
            {
                p.Name = "player1";
                p.Mac = mac;
                player1 = p;
            }
            else if (player2 == null || player2.Mac == mac)
            {
                p.Name = "player2";
                p.Mac = mac;
                player2 = p;
            }

            if (player1 != null && player2 != null)
            {
                StartGame();
            }
            return p;
        }

        public bool DisconnectPlayer(string mac)
        {
            if (player1 != null && player1.Mac == mac)
            {
                player1 = null;
                mm = null;
                return true;
            }
            if (player2 != null && player2.Mac == mac)
            {
                player2 = null;
                mm = null;
                return true;
            }
            return false;
        }

        public void DisconnectPlayers()
        {
            player1 = null;
            player2 = null;
        }

        public void StartGame()
        {
            mm = new MapManager();
            mm.BuildMap(new Coordinates(player1.PosX, player1.PosY), new Coordinates(player2.PosX, player2.PosY));
        }

        public void UpdateGame()
        {
            mm.UpdatePlayerPos(new Coordinates(player1.PosX, player1.PosY), new Coordinates(player2.PosX, player2.PosY));
        }

        public void StopGame()
        {
            
        }
    }
}
