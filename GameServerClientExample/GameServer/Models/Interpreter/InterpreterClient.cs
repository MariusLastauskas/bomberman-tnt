using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameServer.Models.Interpreter
{
    public class InterpreterClient
    {
        public NonTerminalExpression expression;

        public InterpreterClient(Context context)
        {
            expression = new NonTerminalExpression().Execute(context);
        }
    }
}
