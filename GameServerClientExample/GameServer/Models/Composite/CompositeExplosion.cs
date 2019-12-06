using GameServer.Models.Decorator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameServer.Models.Iterator;

namespace GameServer.Models.Composite
{
    public class CompositeExplosion : Component
    {
        public List<Component> children { get; set; }
        public bool isOldest { get; set; }

        public CompositeExplosion()
        {
            children = new List<Component>();
            isOldest = false;
        }
        public CompositeExplosion(List<Component> children)
        {
            this.children = children;
        }

        public override void Operation()
        {
            DeleteAll();
        }

        public void DeleteAll()
        {
            foreach (Component component in children)
            {
                component.Operation();
            }
        }
        public void AddChildren(Component comp)
        {
            children.Add(comp);
        }
        public async void setTimer()
        {
            await Task.Delay(1000);
            this.Operation();
        }
    }
}
