using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel.Configuration;

namespace Extensions
{
    public class ConsoleTracingElement : BehaviorExtensionElement
    {
        public override Type BehaviorType
        {
            get { return typeof(ConsoleTracing); }
        }

        protected override object CreateBehavior()
        {
            return new ConsoleTracing();
        }
    }
}
