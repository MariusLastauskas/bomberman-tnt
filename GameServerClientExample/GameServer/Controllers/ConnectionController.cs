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
        [HttpGet]
        public IActionResult GetGameConnectionStatus()
        {
            if (GlobalVar.getGm().CheckGameState())
            {
                return Ok();
            }
            return NoContent();
        }

        /// <summary>
        /// connects player with authToken address provided if there is empty slot to play
        /// </summary>
        /// <param name="authToken">authToken address</param>
        /// <returns>player object</returns>
        [HttpPost]
        public ActionResult<Player> ConnectPlayer([FromHeader] string authToken)
        {
            return GlobalVar.getGm().ConnectPlayer(authToken);
        }

        /// <summary>
        /// disconnects player with provided authToken address if there is one
        /// </summary>
        /// <param name="authToken">authToken address</param>
        /// <returns>NoContent if player is disconnected and NotFound if player with authToken address does not exist</returns>
        [HttpDelete]
        public IActionResult DisconnectPlayer([FromHeader] string authToken)
        {
            if (GlobalVar.getGm().DisconnectPlayer(authToken))
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}
