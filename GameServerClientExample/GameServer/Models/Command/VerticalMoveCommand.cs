using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameServer.Models.Command
{
    public class VerticalMoveCommand : ICommand
    {
        Player p { get; set; }

        public VerticalMoveCommand(Player p)
        {
            this.p = p;
        }

        public void Execute()
        {
            p.Move("up");
        }

        public void Undo()
        {
            p.Move("down");
        }
    }
}
