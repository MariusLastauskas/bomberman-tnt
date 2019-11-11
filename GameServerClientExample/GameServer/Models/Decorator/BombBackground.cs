using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameServer.Models.Decorator
{
    public class BombBackground : BombDecorator
    {
        public string BackgroundColor;
        
        public BombBackground(string backgroundColor)
        {
            BackgroundColor = backgroundColor;
        }

        public void SetBackground()
        {
            Console.WriteLine("Bomb background " + BackgroundColor);
        }

        public override void Operation()
        {
            base.Operation();
            SetBackground();
            
        }
    }
}
