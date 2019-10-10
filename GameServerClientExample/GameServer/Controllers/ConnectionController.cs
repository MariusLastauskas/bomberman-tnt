using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GameServer.Models;

namespace GameServer.Controllers
{
    [Route("api/connection")]
    [ApiController]
    public class ConnectionController : ControllerBase
    {
        [HttpGet("{mac}")]
        public IActionResult GetGameConnectionStatus(string mac)
        {
            if (GlobalVar.gm == null || GlobalVar.gm.mm == null)
            {
                return NoContent();
            }
            return Ok();
        }

        [HttpPost]
        public ActionResult<Player> ConnectPlayer([FromBody] string mac)
        {
            return GlobalVar.gm.ConnectPlayer(mac);
        }

        [HttpDelete("{mac}")]
        public IActionResult DisconnectPlayer(string mac)
        {
            if (GlobalVar.gm.DisconnectPlayer(mac))
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}
