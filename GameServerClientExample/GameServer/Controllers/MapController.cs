using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GameServer.Models;
using GameServer.Models.AnstractFactory;
using GameServer.Models.Command;

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
                            if (map[i, j][k] is RedPlayer)
                            {
                                map[i, j][k] = map[i, j][k] as RedPlayer;
                            }
                            if (map[i, j][k] is BluePlayer)
                            {
                                map[i, j][k] = map[i, j][k] as BluePlayer;
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
        [HttpPatch]
        public IActionResult MovePlayer([FromHeader] string authToken, [FromHeader] string action)
        {
            Player p;
            if (GlobalVar.getGm().player1 != null && GlobalVar.getGm().player1.AuthToken == authToken)
            {
                p = GlobalVar.getGm().player1;
            } else if (GlobalVar.getGm().player2 != null && GlobalVar.getGm().player2.AuthToken == authToken)
            {
                p = GlobalVar.getGm().player2;
            } else
            {
                return BadRequest();
            }

            switch (action)
            {
                case "plant":
                    if (GlobalVar.getGm().PlantBomb(authToken))
                    {
                        return Ok();
                    }
                    return BadRequest();
                case "up":
                    ICommand verticalCommand = new VerticalMoveCommand(p);
                    Invoker verticalInvoker = new Invoker();
                    verticalInvoker.addCommand(verticalCommand);
                    verticalInvoker.run();
                    return Ok();
                    break;
                case "down":
                    new VerticalMoveCommand(p).Undo();
                    return Ok();
                    break;
                case "left":
                    new HorizontalMoveCommand(p).Undo();
                    return Ok();
                    break;
                case "right":
                    ICommand horizontalCommand = new HorizontalMoveCommand(p);
                    Invoker horizontalInvoker = new Invoker();
                    horizontalInvoker.addCommand(horizontalCommand);
                    horizontalInvoker.run();
                    return Ok();
                    break;
                default:
                    return BadRequest();
            }
        }
    }
}