using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameServer.Models.Interpreter
{
    public class Context
    {
        private string outbound;

        public Context()
        {
            this.outbound = "";
        }
        public Context(string outbound)
        {
            this.outbound = outbound;
        }

        public string getOutbound()
        {
            return outbound;
        }
        public void setOutbound(string outbound)
        {
            this.outbound = outbound;
        }
    }
}
