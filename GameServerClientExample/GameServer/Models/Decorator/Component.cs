﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameServer.Models.Iterator;

namespace GameServer.Models.Decorator
{
    public abstract class Component: IAggregatable<string>
    {
        public List<string> decorations = new List<string>();

        public abstract void Operation();

        public IIteratable<string> getIterator()
        {
            return new ComponentIterator(this);
        }
    }
}
