using System;
namespace GameServer.Models.Template
{
    public class GameTemplate
    {
        public virtual void setPlayers(Player p1, Player p2) { }

        public virtual void pingPlayer(ref DateTime ping) { }

        public virtual bool checkPing(DateTime ping) { return false; }

        public virtual bool CheckGameState() { return false; }

        public virtual bool DisconnectPlayer(string authToken) { return false; }

        public virtual bool DisconnectPlayer() { return false; }

        public virtual void StartGame() { }

        public virtual bool MovePlayer(string authToken, string direction) { return false; }

        public virtual bool PlantBomb(string authToken) { return false; }
    }
}
