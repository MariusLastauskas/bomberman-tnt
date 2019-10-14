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
        public ActionResult<Builder> GetGameMap()
        {
            //if (GlobalVar.gm == null || GlobalVar.gm.map == null)
            //{
                //return NoContent();
            //}
            return new MapBuilder().BuildDestructibleWalls();
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