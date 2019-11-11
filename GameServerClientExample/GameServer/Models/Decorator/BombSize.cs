using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameServer.Models.Decorator
{
    public class BombSize : BombDecorator
    {
        public int Size;
        
        public BombSize(int bombSize)
        {
            Size = bombSize;
        }

        public override void Operation()
        {
            base.Operation();
            SetSize();
        }

        public void SetSize()
        {
            Console.WriteLine("Bomb size " + Size);
        }
    }
}
