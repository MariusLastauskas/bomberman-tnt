using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameServer.Models.Interpreter
{
    public class Size : TerminalExpression
    {
        public string type = "size";
        public Asset size;

        public Size(Asset size)
        {
            this.size = size;
        }
    }
}
