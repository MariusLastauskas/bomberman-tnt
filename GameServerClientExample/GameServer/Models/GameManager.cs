using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameServer.Models.Command;
using GameServer.Models.GameObserver;

namespace GameServer.Models
{
    public class GameManager
    {
        public Player player1;
        public Invoker invoker1;
        private DateTime p1ping;
        public Player player2;
        public Invoker invoker2;
        private DateTime p2ping;
        public MapStub map;
        private MapManagerStub mapManager;

        public GameManager()
        {
            player1 = null;
            player2 = null;
            invoker1 = null;
            invoker2 = null;
            map = null;
        }

        public GameManager(Player p1, Player p2)
        {
            map = new MapStub();
            player1 = p1;
            p1.MapObserver = new MapObserver(map);
            invoker1 = new Invoker();
            player2 = p2;
            p2.MapObserver = new MapObserver(map);
            invoker2 = new Invoker();
        }

        public void setPlayers(Player p1, Player p2)
        {
            player1 = p1;
            player2 = p2;
        }

        /// <summary>
        /// Resets player last ping time to current date
        /// </summary>
        /// <param name="ping">Player last ping time</param>
        public void pingPlayer(ref DateTime ping)
        {
            ping = DateTime.Now;
        }

        /// <summary>
        /// Checks if player has not been offline for more than 10s
        /// </summary>
        /// <param name="ping">Player last ping time</param>
        /// <returns>true if player is still active</returns>
        public bool checkPing(DateTime ping)
        {
            if ((DateTime.Now - ping).TotalSeconds > 20)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Checks if players in game are still active and stops the game if they are not
        /// </summary>
        /// <returns>are both players still active</returns>
        public bool CheckGameState()
        {
            if (!checkPing(p1ping) || !checkPing(p2ping) || player1 == null || player2 == null)
            {
                stopGame();
            }

            return mapManager != null;
        }

        /// <summary>
        /// Connects player to game by its authToken address
        /// </summary>
        /// <param name="authToken">authToken address</param>
        /// <returns>player connected</returns>
        public Player ConnectPlayer(string authToken)
        {
            Player p = new Player();
            p.MapObserver = new MapObserver(map);
            if (player1 == null || player1.AuthToken == authToken)
            {
                p.Name = "player1";
                p.AuthToken = authToken;
                player1 = p;
                pingPlayer(ref p1ping);
            }
            else if (player2 == null || player2.AuthToken == authToken)
            {
                p.Name = "player2";
                p.AuthToken = authToken;
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

        /// <summary>
        /// Disconnects player by its authToken address
        /// </summary>
        /// <param name="authToken">authToken address</param>
        /// <returns>true if player disconnected</returns>
        public bool DisconnectPlayer(string authToken)
        {
            if (player1 != null && player1.AuthToken == authToken)
            {
                player1 = null;
                map = null;
                return true;
            }
            if (player2 != null && player2.AuthToken == authToken)
            {
                player2 = null;
                map = null;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Disconnects all players
        /// </summary>
        public void DisconnectPlayers()
        {
            player1 = null;
            player2 = null;
        }

        /// <summary>
        /// Starts game, creates MapManager
        /// </summary>
        public void StartGame()
        {
            mapManager = new MapManagerStub();
            mapManager.BuildMap();
        }

        /// <summary>
        /// Moves player to direction
        /// </summary>
        /// <param name="authToken">authToken address</param>
        /// <param name="direction">direction</param>
        /// <returns>true if player can move the dirrection</returns>
        public bool MovePlayer(string authToken, string direction)
        {
            if (player1 != null && player1.AuthToken == authToken)
            {
                player1.Move(direction);
                //return mapManager.UpdatePlayerPos(player1, direction);
                return true;
            }

            if (player2 != null && player2.AuthToken == authToken)
            {
                player2.Move(direction);
                //return mapManager.UpdatePlayerPos(player2, direction);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Plants a bomb by player with authToken address provided
        /// </summary>
        /// <param name="authToken">authToken address</param>
        /// <returns>true if player can plant bomb</returns>
        public bool PlantBomb(string authToken)
        {
            if (player1 != null && player1.AuthToken == authToken && player1.PlacedBombCount < player1.NumberOfBombs)
            {
                mapManager.PlaceBomb(player1);
                return true;
            }
            if (player2 != null && player2.AuthToken == authToken && player2.PlacedBombCount < player2.NumberOfBombs)
            {
                mapManager.PlaceBomb(player2);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Stops the game, disconnects all players
        /// </summary>
        private void stopGame()
        {
            mapManager = null;
            DisconnectPlayers();
        }
    }
}
