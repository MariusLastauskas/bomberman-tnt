using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameServer.Models.Interpreter
{
    public class NonTerminalExpression: Expression
    {
        public List<TerminalExpression> list;

        public NonTerminalExpression()
        {
            list = new List<TerminalExpression>();
        }
        
        public NonTerminalExpression Execute(Context context)
        {
            string command = context.getOutbound();
            string[] parts = command.Split("reshape");

            Asset asset = new Asset(parts[1].Trim());
            TerminalExpression param = new TerminalExpression();

            if (parts[0].Trim() == "color")
            {
                param = new Color(asset);
            } else if (parts[0].Trim() == "size")
            {
                param = new Size(asset);
            }

            list.Add(param);
            list.Add(asset);

            return this;
        }
    }
}
