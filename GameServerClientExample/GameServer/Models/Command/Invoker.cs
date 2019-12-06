using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameServer.Models.Iterator;

namespace GameServer.Models.Command
{
    public class Invoker
    {
        public List<ICommand> commands;

        public Invoker()
        {
            commands = new List<ICommand>();
        }

        public void addCommand(ICommand command)
        {
            commands.Add(command);
        }

        public void run()
        {
            foreach (ICommand command in commands)
            {
                command.Execute();
            }
        }

        public myIterator<ICommand> getIterator() {
            return new InvokerIterator(this);
        }
    }
}
