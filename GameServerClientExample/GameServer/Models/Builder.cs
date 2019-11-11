using System;
namespace GameServer.Models
{
    public abstract class Builder
    { 
        public abstract Builder BuildDestructibleWalls();
        public abstract Builder BuildIndestructibleWalls();
        public abstract Builder AddPlayers();

        
    }
}
