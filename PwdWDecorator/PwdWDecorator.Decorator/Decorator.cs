using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PwdWDecorator.Decorator
{
    public class Decorator : Component
    {
        protected Component component;

        public void SetComponent(Component component)
        {
            this.component = component;
        }

        public override string Hash(string data)
        {
            if (component != null)
            {
                return component.Hash(data);
            }
            return data;
        }
    }
}
