using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameServer.Models.Command
{
    public class HorizontalMoveCommand : ICommand
    {
        Player p { get; set; }

        public HorizontalMoveCommand(Player p)
        {
            this.p = p;
        }

        public void Execute()
        {
            p.Move("right");
        }

        public void Undo()
        {
            p.Move("left");
        }
    }
}
