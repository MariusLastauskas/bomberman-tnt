using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameServer.Models.Interpreter
{
    public interface Expression
    {
        NonTerminalExpression Execute(Context context);
    }
}
