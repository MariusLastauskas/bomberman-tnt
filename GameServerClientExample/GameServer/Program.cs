using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using GameServer.Models;

namespace GameServer
{

    public class Program
    {
        /*private static AbstractFactory abstractFactory;
        private static MapObject MapObject;
        private static MapObject bomb;
        private static MapObject bomb1;*/


        public static void Main(string[] args)
        {
           /* Player player = new Player();
            abstractFactory = new BlueFactory();
            bomb = abstractFactory.getBomb(player);
            abstractFactory = new RedFactory();
            bomb1 = abstractFactory.getBomb(player);*/
            // bombFactory testas, naudot su pause mygtuku ir debugginimu, nes neturim consoles

            CreateWebHostBuilder(args).Build().Run();

            


        }


        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
