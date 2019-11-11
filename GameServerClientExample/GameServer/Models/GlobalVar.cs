using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameServer.Models;

namespace GameServer.Controllers
{
    /// <summary>
    /// Global variables
    /// </summary>
    public class GlobalVar
    {
        private static GameManager gm = new GameManager();
        public static GameManager getGm()
        {
            return gm;
        }
        public static string MOVE_UP = "up";
        public static string MOVE_DOWN = "down";
        public static string MOVE_LEFT = "left";
        public static string MOVE_RIGHT = "right";
        public static string PLANT_BOMB = "plant";
    }
}
