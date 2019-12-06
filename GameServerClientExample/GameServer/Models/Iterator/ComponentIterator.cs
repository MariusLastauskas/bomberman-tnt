using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameServer.Models.Decorator;

namespace GameServer.Models.Iterator
{
    public class ComponentIterator: myIterator<string>
    {
        private int index;
        private Component component;

        public ComponentIterator(Component component)
        {
            index = 0;
            this.component = component;
        }

        public string first()
        {
            index = 0;
            return component.decorations[index];
        }

        public string next()
        {
            index++;
            return component.decorations[index];
        }

        public bool hasNext()
        {
            return component.decorations.Count > index + 1;
        }

        public void remove()
        {
            component.decorations.RemoveAt(index);
        }
    }
}
