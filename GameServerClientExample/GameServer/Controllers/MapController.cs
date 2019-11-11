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
        public List<MapObject>[,] GetGameMap()
        {
            //if (GlobalVar.gm == null || GlobalVar.gm.map == null)
            //{
            //return NoContent();
            //}
            List<MapObject>[,] map = new MapManagerStub().BuildMap().getMapContainer();

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] != null)
                    {
                        for (int k = 0; k < map[i, j].Count; k++)
                        {
                            if (map[i, j][k] is Wall)
                            {
                                map[i, j][k] = map[i, j][k] as Wall;
                            }
                            if (map[i, j][k] is Bomb)
                            {
                                map[i, j][k] = map[i, j][k] as Bomb;
                            }
                            if (map[i, j][k] is PowerUp)
                            {
                                map[i, j][k] = map[i, j][k] as PowerUp;
                            }
                            if (map[i, j][k] is Player)
                            {
                                map[i, j][k] = map[i, j][k] as Player;
                            }
                            if (map[i, j][k] is Explosion)
                            {
                                map[i, j][k] = map[i, j][k] as Explosion;
                            }
                        }
                    }
                }
            }
            return map;

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