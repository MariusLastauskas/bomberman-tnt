using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameServer.Models.Interpreter
{
    public class Color : TerminalExpression
    {
        public string type = "color";
        public Asset color;

        public Color(Asset color)
        {
            this.color = color;
        }
    }
}
