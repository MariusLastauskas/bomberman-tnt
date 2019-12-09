using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameServer.Models.Iterator
{
    public interface IIteratable<T>
    {
        bool hasNext();

        T next();

        T first();

        void remove();
    }
}
