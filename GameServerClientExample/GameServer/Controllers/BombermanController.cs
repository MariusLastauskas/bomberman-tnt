using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace GameServer.Controllers
{
    public class BombermanController : Controller
    {
        public string uri_base = "https://localhost:44371";

        [Route("Bomberman")]
        public IActionResult Index()
        {
            return View();
        }
    }
}