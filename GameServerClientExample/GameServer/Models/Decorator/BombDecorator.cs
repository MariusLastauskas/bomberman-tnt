using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameServer.Models.Decorator
{
    public abstract class BombDecorator : Component
    {
        protected Component bombComponent;

        public void SetComponent(Component component)
        {
            bombComponent = component;
        }

        public override void Operation()
        {
            if (bombComponent != null)
            {
                bombComponent.Operation();
            }
        }
    }
}
