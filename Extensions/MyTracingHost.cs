using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;

namespace Extensions
{
    public class MyTracingHost : ServiceHost
    {
        public MyTracingHost(Type serviceType, params Uri[] baseAddresses) : base(serviceType, baseAddresses) { }
        public MyTracingHost(object singleton, params Uri[] baseAddresses) : base(singleton, baseAddresses) { }

        protected override void OnOpening()
        {
            base.OnOpening();

            ConsoleTracing ct = 
                this.Description.Behaviors.Find<ConsoleTracing>();
            if (null == ct)
            {
				//this.Description.Behaviors.Add(
				//    new ConsoleTracing());
            }
        }
    }
}
