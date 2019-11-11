using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameServer.Models.Decorator
{
    public class BombIcon : BombDecorator
    {
        public override void Operation()
        {
            base.Operation();
            SetIcon();
            component.decorations.AddRange(this.decorations);
        }

        public void SetIcon()
        {
            decorations.Add(@"BombPictures/bomb-svgrepo-com.svg");
        }
    }
}
