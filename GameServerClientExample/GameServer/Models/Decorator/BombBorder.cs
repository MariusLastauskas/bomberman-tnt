using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameServer.Models.Decorator
{
    public class BombBorder : BombDecorator
    {
        public string BorderColor;
        public int BorderRadius;
        public int BorderThickness;

        public BombBorder(string borderColor, int borderRadius, int borderThickness)
        {
            BorderColor = borderColor;
            BorderRadius = borderRadius;
            BorderThickness = borderThickness;
        }
       
        public override void Operation()
        {
            base.Operation();
            SetBorder();

        }

        public void SetBorder()
        {
            Console.WriteLine("Bomb border " + BorderColor);
        }
    }
}
