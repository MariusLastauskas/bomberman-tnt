using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameServer.Models.Command;

namespace GameServer.Models.Iterator
{
    public class InvokerIterator: IIteratable<ICommand>
    {
        private int index;
        private Invoker invoker;

        public InvokerIterator(Invoker invoker)
        {
            this.invoker = invoker;
        }

        public ICommand first()
        {
            index = 0;
            return invoker.commands[index];
        }

        public ICommand next()
        {
            index++;
            return invoker.commands[index];
        }

        public bool hasNext()
        {
            return invoker.commands.Count > index + 1;
        }

        public void remove()
        {
            invoker.commands.RemoveAt(index);
        }
    }
}
