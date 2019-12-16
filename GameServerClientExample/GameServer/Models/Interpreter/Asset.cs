using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameServer.Models.Interpreter
{
    public class Asset : TerminalExpression
    {
        public string type;
        public string asset;

        public Asset(string asset)
        {
            type = "asset";
            this.asset = asset;
        }
    }
}
