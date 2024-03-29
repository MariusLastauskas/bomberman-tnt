﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameServer.Models.Iterator
{
    public interface IAggregatable<T>
    {
        IIteratable<T> getIterator();
    }
}
