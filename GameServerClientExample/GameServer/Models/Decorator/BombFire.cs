using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameServer.Models.Decorator
{
    public class BombFire : BombDecorator
    {
        public override void Operation()
        {
            SetFire();
            component.decorations.AddRange(this.decorations);
            base.Operation();
        }

        public void SetFire()
        {
            decorations.Add(@"BombPictures/fire-svgrepo-com.svg");
        }
    }
}
