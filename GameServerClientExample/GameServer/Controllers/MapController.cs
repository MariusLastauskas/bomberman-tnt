using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GameServer.Models;

namespace GameServer.Controllers
{
    /// <summary>
    /// API controller for player action manipulations and map getting
    /// </summary>
    [Route("api/map")]
    [ApiController]
    public class MapController : ControllerBase
    {
        /// <summary>
        /// Gets game map object
        /// </summary>
        /// <returns>NoContent if game is not created, Map object if map is created</returns>
        [HttpGet]
        public MapObject[,] GetGameMap()
        {
            //if (GlobalVar.gm == null || GlobalVar.gm.map == null)
            //{
            //return NoContent();
            //}
            MapObject[,] map = new MapManagerStub().BuildMap().getMapContainer();
            MapObject[,] m = new MapObject[map.GetLength(0), map.GetLength(1)];

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] is Wall)
                    {
                        m[i, j] = map[i, j] as Wall;
                    }
                    if (map[i, j] is Bomb)
                    {
                        m[i, j] = map[i, j] as Bomb;
                    }
                    if (map[i, j] is PowerUp)
                    {
                        m[i, j] = map[i, j] as PowerUp;
                    }
                    if (map[i, j] is Player)
                    {
                        m[i, j] = map[i, j] as Player;
                    }
                }
            }
            return m;

        }

        /// <summary>
        /// Moves player in map
        /// </summary>
        /// <param name="mac">mac address of player</param>
        /// <param name="action">dirrection of movement or plant action</param>
        /// <returns>Ok if movement or plant is allowed, BadRequest if player cant move the dirrection or plant bomb</returns>
        [HttpPatch("{mac}")]
        public IActionResult MovePlayer(string mac, [FromBody] string action)
        {
            if (action == GlobalVar.PLANT_BOMB)
            {
                if (GlobalVar.gm.PlantBomb(mac))
                {
                    return Ok();
                }
                return BadRequest();
            }
            if (GlobalVar.gm.MovePlayer(mac, action))
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}