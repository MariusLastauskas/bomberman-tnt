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
    /// API controller for connection management
    /// </summary>
    [Route("api/connection")]
    [ApiController]
    public class ConnectionController : ControllerBase
    {
        /// <summary>
        /// Gets if enough players are connected to start a game
        /// </summary>
        /// <returns>Ok if game is starting, NoContent if some players are missing</returns>
        [HttpGet("{mac}")]
        public IActionResult GetGameConnectionStatus()
        {
            if (GlobalVar.gm.CheckGameState())
            {
                return Ok();
            }
            return NoContent();
        }

        /// <summary>
        /// connects player with mac address provided if there is empty slot to play
        /// </summary>
        /// <param name="mac">mac address</param>
        /// <returns>player object</returns>
        [HttpPost]
        public ActionResult<Player> ConnectPlayer([FromBody] string mac)
        {
            return GlobalVar.gm.ConnectPlayer(mac);
        }

        /// <summary>
        /// disconnects player with provided mac address if there is one
        /// </summary>
        /// <param name="mac">mac address</param>
        /// <returns>NoContent if player is disconnected and NotFound if player with mac address does not exist</returns>
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
