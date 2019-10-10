using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GameServer.Models;

namespace GameServer.Controllers
{
    [Route("api/map")]
    [ApiController]
    public class MapController : ControllerBase
    {
        [HttpGet]
        public ActionResult<Map> GetGameConnectionStatus()
        {
            if (GlobalVar.gm == null || GlobalVar.gm.mm == null)
            {
                return NoContent();
            }
            return new Map();
        }

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