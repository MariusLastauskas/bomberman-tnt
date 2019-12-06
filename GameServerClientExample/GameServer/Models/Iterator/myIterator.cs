using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameServer.Models.Iterator
{
    public interface myIterator<T>
    {
        bool hasNext();

        T next();

        T first();

        void remove();
    }
}
