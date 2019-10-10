using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameServer.Models
{
    public class GameManager
    {
        private Player player1;
        private DateTime p1ping;
        private Player player2;
        private DateTime p2ping;
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

        public void pingPlayer(ref DateTime ping)
        {
            ping = DateTime.Now;
        }

        public bool checkPing(DateTime ping)
        {
            if ((DateTime.Now - ping).TotalSeconds > 10)
            {
                return false;
            }
            return true;
        }

        public bool CheckGameState()
        {
            if (!checkPing(p1ping) || !checkPing(p2ping))
            {
                stopGame();
            }

            return mm != null;
        }

        public Player ConnectPlayer(string mac)
        {
            Player p = new Player();
            if (player1 == null || player1.Mac == mac)
            {
                p.Name = "player1";
                p.Mac = mac;
                player1 = p;
                pingPlayer(ref p1ping);
            }
            else if (player2 == null || player2.Mac == mac)
            {
                p.Name = "player2";
                p.Mac = mac;
                player2 = p;
                pingPlayer(ref p2ping);
            }

            if (!checkPing(p1ping))
            {
                player1 = null;
            }

            if (!checkPing(p2ping))
            {
                player2 = null;
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
            mm.BuildMap();
        }

        public bool MovePlayer(string mac, string direction)
        {
            if (player1 != null && player1.Mac == mac)
            {
                return mm.UpdatePlayerPos(player1, direction);
            }

            if (player2 != null && player2.Mac == mac)
            {
                return mm.UpdatePlayerPos(player2, direction);
            }

            return false;
        }

        public bool PlantBomb(string mac)
        {
            if (player1 != null && player1.Mac == mac && player1.placedBombCount < player1.numberOfBombs)
            {
                mm.PlaceBomb(player1);
                return true;
            }
            if (player2 != null && player2.Mac == mac && player2.placedBombCount < player2.numberOfBombs)
            {
                mm.PlaceBomb(player2);
                return true;
            }
            return false;
        }

        private void stopGame()
        {
            mm = null;
            DisconnectPlayers();
        }
    }
}
