using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameServer.Models.Decorator
{
    public class BombBorder : BombDecorator
    {
        public string color;

        public BombBorder(string _color)
        {
            color = _color;
        }

        public override void Operation()
        {
            SetBorder();
            component.decorations.AddRange(this.decorations);
            base.Operation();
        }

        public void SetBorder()
        {
            decorations.Add(color);
        }
    }
}
